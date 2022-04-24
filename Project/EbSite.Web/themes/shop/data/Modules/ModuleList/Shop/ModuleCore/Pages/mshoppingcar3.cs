using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.BLL.User;
using EbSite.Entity;
using EbSite.Modules.Shop.ModuleCore.Cart;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mshoppingcar3 : BasePageM
    {
        protected global::System.Web.UI.WebControls.Repeater rpPaymentPClass;
        protected global::System.Web.UI.WebControls.Repeater rpPayments;

        protected long OrderNumber;//string
        ////应付
        protected decimal TotalPay = 0;
        protected string PayKey;
        protected string PayInfo;

        //预付款
        protected decimal UMoney = 0;//本次使用金额

        protected string Tips = "订单提交成功，请您尽快付款!";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "订单支付";

            if (!string.IsNullOrEmpty(Request["hp"]) && !string.IsNullOrEmpty(Request["orderid"]))
            {
                Tips = "您正在帮朋友代付，如果不放心可以与朋友再次确实订单号后付款！";
                BindPayWay();
            }
            else
            {
                //验证用户是否登录
                if (EbSite.Base.Host.Instance.UserID < 0)
                {
                    base.CheckCurrentUserIsLogin();
                    //Response.Redirect(EbSite.Base.Host.Instance.LoginRw);
                }
                else
                {
                    if (!string.IsNullOrEmpty(Request["orderid"]))
                    {

                        BindPayWay();

                    }
                    else
                    {
                        bool isSendPay = false;
                        decimal iOrderTotal = 0;//用户要付款的金额
                        //是否团购 yhl 2013-09-13
                        string isGroup = Request["txtgroup"]; // 团购ID
                        string isRush = Request["txtrush"];//抢购id

                        //2013-11-05 yhl 使用预付款 begin
                        string uMoney = Request["tbMoney"];//本次使用金额
                        string uPass = Request["tbPassWord"];//支付密码

                        if (!string.IsNullOrEmpty(uMoney) && !string.IsNullOrEmpty(uPass))
                        {
                            UMoney = decimal.Parse(uMoney);//赋值
                            if (UMoney > 0)
                            {
                                if (!CheckUserPayPass(uPass)) //密码不对
                                {
                                    //加上提示 密码不对
                                    Response.Redirect(ShopLinkApi.PostCarUrl(GetSiteID), true);
                                }
                            }
                        }
                        //////////////// end

                        if (string.IsNullOrEmpty(isGroup) && string.IsNullOrEmpty(isRush))
                        {
                            isSendPay = SaveOrder(out iOrderTotal);
                        }
                        else if (!string.IsNullOrEmpty(isRush))//抢
                        {
                            isSendPay = SaveGroupRushOrder(0, EbSite.Core.Utils.StrToInt(isRush, 0), out iOrderTotal);
                        }
                        else
                        {
                            isSendPay = SaveGroupRushOrder(EbSite.Core.Utils.StrToInt(isGroup, 0), 0, out iOrderTotal);//团购       
                        }

                        #region yhl 2013-12-17 清空购物车 因为 购物完成后，事物已经把ebshop_buy_cartitem 表删除了，可是在往下跳转时又从购物车中 添加一次
                        ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
                        profile.ShopCart.Clear();
                        profile.Save();
                        #endregion

                        if (!isSendPay) //是否在线支付
                        {


                            if (iOrderTotal > 0)
                            {
                                //去除问号的参数，防止刷新
                                string surl = EbSite.Core.Strings.GetString.RegexReplace(Request.RawUrl, "\\?.*", "");
                                Response.Redirect(string.Concat("~", surl, "?orderid=", OrderNumber), true);
                            }
                            else
                            {
                                string url = HostApi.GetModuleUrl(GetMenuLuYou, GetMenuGuid);
                                Tips("订单生成成功", string.Format("订单已经提交成功，订单号:{0},应付金额:{1}元", OrderNumber, TotalPay), url);
                            }

                        }
                        else
                        {
                            string url = HostApi.GetModuleUrl(GetMenuLuYou, GetMenuGuid);
                            Tips("订单生成成功", string.Format("订单已经提交成功，订单号:{0},应付金额:{1}元,支付方式:货到付款", OrderNumber, TotalPay), url);
                        }

                    }

                }
            }



        }



        protected void BindPayWay()
        {
            rpPaymentPClass.ItemDataBound += new RepeaterItemEventHandler(rpPaymentPClass_ItemDataBound);
            rpPaymentPClass.DataSource = EbSite.BLL.PayTypeInfo.Instance.GetParent();
            rpPaymentPClass.DataBind();
            OrderNumber = long.Parse(Request["orderid"]);

            Entity.Buy_Orders mdOrder = BLL.Buy_Orders.Instance.GetEntityByOrderID(OrderNumber);
            if (!Equals(mdOrder, null))
            {
                TotalPay = mdOrder.OrderTotal;
                PayInfo = string.Format("订单号:{0} 时间:{1} 下单人ID:{2}", OrderNumber, DateTime.Now, UserID);
                PayKey = EbSite.Base.Host.Instance.EncodeByKey(string.Format("{0}-{1}", OrderNumber, TotalPay));
            }
            else
            {
                Response.Redirect(HostApi.GetErrPageRw("7"));
            }
        }
        protected bool SaveGroupRushOrder(int gid, int qid, out decimal iOrderTatal)
        {
            string address = Request["address"]; //配送地址ID
            string rdoDelivery = Request["rdoDelivery"]; //配送方式ID
            string sendtime = Request["sendtime"]; //配送时间ID
            string rdoPayment = Request["rdoPayment"]; //配送方式ID  0为在线支付，1为货到付款
            string ddlCoupon = Request["txtTick"]; //优惠券ID
            string optionitemids = Request["optionitemids"]; //订单选项ID集合，用_分开
            string txtRemark = Request["txtRemark"]; //订单留言

            //创建一个订单
            Entity.Buy_Orders mdOrder = new Buy_Orders();
            mdOrder.OrderStatus = 0; //等待付款

            mdOrder.Remark = txtRemark;

            ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
            CartManger ShopCart = profile.ShopCart;


            //更新活动信息
            ShopCart.UpdateGroupActivityInfo();

            Entity.GroupBuy groupModel = new GroupBuy();
            Entity.CountDownBuy rushModel = new CountDownBuy();

            //查出团购的价格
            if (gid > 0)
            {
                groupModel = ModuleCore.BLL.GroupBuy.Instance.GetEntity(gid);
                if (Equals(groupModel.BuySumOrder, null))
                {
                    groupModel.BuySumOrder = ShopCart.Count;
                }
                else
                {
                    groupModel.BuySumOrder += ShopCart.Count;
                }

                if (Equals(groupModel.Buyed, null))
                {
                    groupModel.Buyed = 1;
                }
                else
                {
                    groupModel.Buyed += 1;
                }

                if (!Equals(groupModel, null))
                {
                    mdOrder.GroupPrice = groupModel.BuyPrice;
                }
                mdOrder.GroupId = EbSite.Core.Utils.StrToInt(Request["txtgroup"], 0);
                mdOrder.GroupBuyStatus = Convert.ToInt32(SystemEnum.GroupBuyState.正在进行中);
            }
            if (qid > 0)
            {
                rushModel = ModuleCore.BLL.CountDownBuy.Instance.GetEntity(qid);
                if (Equals(rushModel.Buyed, null))
                {
                    rushModel.Buyed = 1;
                }
                else
                {
                    rushModel.Buyed += 1;
                }

                if (!Equals(groupModel, null))
                {
                    mdOrder.GroupPrice = rushModel.CountDownPrice;
                }
                mdOrder.PanicBuyingId = qid;
            }


            decimal TotalWeight = ShopCart.TotalWeight;
            mdOrder.Weight = int.Parse(TotalWeight.ToString());//商品重量
            mdOrder.Amount = ShopCart.TotalRealSellPrice;//折扣后的价格，但未加费用，在这个基础上计算费用
            mdOrder.OrderCostPrice = ShopCart.TotalCostPrice;//成本核算价格
            mdOrder.OrderProfit = ShopCart.TotalProfit;//成本利润
            mdOrder.OrderPoint = 0;//ShopCart.TotalPoints;//可得积分
            //mdOrder.ActivityId = ShopCart.ActivityId;
            //mdOrder.ActivityName = ShopCart.ActivityName;
            //mdOrder.EightFree = ShopCart.EightFree;
            //mdOrder.PayFreeFree = ShopCart.PayFreeFree;
            //mdOrder.OrderOptionFree = ShopCart.OrderOptionFree;
            //mdOrder.DiscountId = ShopCart.DiscountId;
            //mdOrder.DiscountName = ShopCart.DiscountName;
            //mdOrder.DiscountValue = ShopCart.DiscountValue;
            //mdOrder.DiscountValueType = ShopCart.DiscountValueType;
            //mdOrder.DiscountAmount = ShopCart.DiscountAmount;
            mdOrder.OrderTotal = ShopCart.OrderTotal;


            int CouponItemID = 0;
            bool isUseCoupon = false;
            if (!string.IsNullOrEmpty(ddlCoupon)) //优惠券处理
            {
                string sCouponName;
                decimal FullAmount, CouponValue;
                EbSite.Entity.CouponItems mdCouponItem = EbSite.BLL.CouponItems.Instance.GetEntity(ddlCoupon, out sCouponName, out FullAmount, out CouponValue);
                if (mdCouponItem != null)
                {
                    if (mdOrder.OrderTotal >= FullAmount)//mdOrder.DiscountAmount >= FullAmount
                    {
                        CouponItemID = mdCouponItem.id;
                        mdOrder.CouponName = sCouponName;
                        mdOrder.CouponCode = mdCouponItem.ClaimCode;
                        mdOrder.CouponAmount = FullAmount;
                        mdOrder.CouponValue = CouponValue;
                        isUseCoupon = true;
                    }

                }
            }


            if (UserID > 0)
            {
                Base.EntityAPI.MembershipUserEb mdUser = HostApi.EBMembershipInstance.Users_GetEntity(UserID);
                mdOrder.UserId = UserID;
                mdOrder.Username = mdUser.UserName;
                mdOrder.RealName = mdUser.NiName;
                mdOrder.EmailAddress = mdUser.emailAddress;
                //mdOrder.QQ = "";
                //mdOrder.Wangwang = "";
                //mdOrder.MSN = "";

            }
            else
            {
                mdOrder.UserId = HostApi.OnlineID;
                mdOrder.RealName = "匿名用户";
                mdOrder.Username = "";
                mdOrder.EmailAddress = "";
            }
            int iaddressid = 0;
            if (!string.IsNullOrEmpty(address))
            {
                iaddressid = int.Parse(address);
                EbSite.Entity.Address md = EbSite.BLL.Address.Instance.GetEntity(iaddressid);
                mdOrder.Address = md.AddressInfo; //收货详细地址
                mdOrder.ZipCode = md.PostCode; //邮编
                mdOrder.SendToUserName = md.UserRealName;//收货人姓名
                mdOrder.TelPhone = md.Phone; //收货人电话
                mdOrder.CellPhone = md.Mobile; //收货人手机
                //收货区域 如:浙江省，杭州市，下城区 即用户下单时选择的下拉,这里是区域ID，用逗号分开
                mdOrder.SendRegion = string.Concat(md.CountryName, ",", md.AreaID);//CountryName没使用的字段，所以暂时用来保存当前区域的低级区域ID,用逗号分开
                //查询地区所在区域ID
                mdOrder.RegionId = EbSite.BLL.SendArea.Instance.GetSendAreaIDByAreaIDs(mdOrder.SendRegion);
            }
            if (!string.IsNullOrEmpty(rdoDelivery))//配送及运费计算处理
            {
                EbSite.Entity.PsDelivery mdDelivery = EbSite.BLL.PsDelivery.Instance.GetEntity(int.Parse(rdoDelivery));
                mdOrder.ModeName = mdDelivery.ModeName;
                mdOrder.ShippingModeId = mdDelivery.id;
                //mdOrder.RealShippingModeId = mdDelivery.id;
                
                decimal CODTotalFree = 0;
                decimal dRree = EbSite.BLL.PsDelivery.Instance.GetFreeByWeight(mdDelivery.id, TotalWeight, iaddressid, mdOrder.OrderTotal, out CODTotalFree);//(mdDelivery.id, TotalWeight, iaddressid, mdOrder.DiscountAmount, out CODTotalFree);
                   
                if (!ShopCart.EightFree) //免运费 2014-3-24 yhl 添加
                {
                     mdOrder.Freight = dRree;
                    
                }
                if (!ShopCart.PayFreeFree) //免支付手续
                {
                    if (!string.IsNullOrEmpty(rdoPayment) && rdoPayment == "-1")
                    {
                        mdOrder.PayFree = CODTotalFree;//计算运费及货到付款费用
                    }
                }
                //if (ShopCart.OrderOptionFree) //免 订单选项费
                //{
                    
                //}
               

            }
            if (!string.IsNullOrEmpty(rdoPayment) && rdoPayment == "-1")
            {
                mdOrder.PaymentTypeId = -1;
                mdOrder.PaymentType = "货到付款";
            }
            else
            {
                mdOrder.PaymentTypeId = 0;
                mdOrder.PaymentType = "在线支付";
            }


            if (sendtime == "1")
            {
                mdOrder.Remark += " 只在工作日送货（双休日、假日不送货）";
            }

            List<EbSite.Entity.OrderOptionValue> lstOov = new List<EbSite.Entity.OrderOptionValue>();

            mdOrder.OrderTotal = mdOrder.ToPayMoney - UMoney;//将计算结果更新更数据库  2013-11-05 减去预付款的金额

            //flz 2013-12-13(如果用户是全额支付，状态改为 已支付)
            bool isUseUMoney = false;
            if (mdOrder.OrderTotal == 0 && UMoney > 0)
            {
                mdOrder.OrderStatus = ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(SystemEnum.OrderStatus.已支付);
                mdOrder.PayDate = DateTime.Now;
                isUseUMoney = true;
            }

            iOrderTatal = mdOrder.OrderTotal;//2013-11-05  最终用户要付款的金额

            decimal Prepayments = UMoney;//使用预付款 
            mdOrder.UserBalance = UMoney;

            mdOrder.iCome = OrderiCome;
            OrderNumber = BLL.Buy_Orders.Instance.AddOrder(mdOrder, lstOov, CouponItemID, ShopCart.CartItems, ShopCart.CreditCartItems, groupModel, rushModel, Prepayments);
            //判断是否用了优惠券
            if (isUseCoupon)
            {
                ModuleCore.BLL.buy_orderlog.Instance.Add(OrderNumber.ToString(), "用户使用了优惠券支付", SystemEnum.OrderLogType.全部显示);
            }
            //判断是否使用了预付款
            if (isUseUMoney)
            {
                ModuleCore.BLL.buy_orderlog.Instance.Add(OrderNumber.ToString(), "用户使用了预付款支付", SystemEnum.OrderLogType.全部显示);
            }
            //添加日志
            ModuleCore.BLL.buy_orderlog.Instance.Add(OrderNumber.ToString(), "您提交了订单，请等待系统确认", SystemEnum.OrderLogType.前台显示);
            TotalPay = mdOrder.OrderTotal;
            return (mdOrder.PaymentTypeId == -1);

        }
        protected bool SaveOrder(out decimal iOrderTatal)
        {
            string address = Request["address"]; //配送地址ID
            //string address2 = Request["radioAddress"]; //配送地址ID
            string rdoDelivery = Request["rdoDelivery"]; //配送方式ID
            string sendtime = Request["sendtime"]; //配送时间ID
            string rdoPayment = Request["rdoPayment"]; //配送方式ID  0为在线支付，1为货到付款
            string ddlCoupon = Request["txtTick"]; //优惠券ID
            string optionitemids = Request["optionitemids"]; //订单选项ID集合，用_分开
            string txtRemark = Request["txtRemark"]; //订单留言




            //创建一个订单
            Entity.Buy_Orders mdOrder = new Buy_Orders();
            mdOrder.OrderStatus = 0; //等待付款

            mdOrder.Remark = txtRemark;

            ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
            CartManger ShopCart = profile.ShopCart;


            //更新活动信息
            ShopCart.UpdateActivityInfo();


            decimal TotalWeight = ShopCart.TotalWeight;

            mdOrder.Weight = int.Parse(TotalWeight.ToString());//商品重量
            mdOrder.Amount = ShopCart.TotalRealSellPrice;//折扣后的价格，但未加费用，在这个基础上计算费用
            mdOrder.OrderCostPrice = ShopCart.TotalCostPrice;//成本核算价格
            mdOrder.OrderProfit = ShopCart.TotalProfit;//成本利润
            mdOrder.OrderPoint = ShopCart.TotalPoints;//可得积分
            mdOrder.ActivityId = ShopCart.ActivityId;
            mdOrder.ActivityName = ShopCart.ActivityName;
            mdOrder.EightFree = ShopCart.EightFree;
            mdOrder.PayFreeFree = ShopCart.PayFreeFree;
            mdOrder.OrderOptionFree = ShopCart.OrderOptionFree;
            mdOrder.DiscountId = ShopCart.DiscountId;
            mdOrder.DiscountName = ShopCart.DiscountName;
            mdOrder.DiscountValue = ShopCart.DiscountValue;
            mdOrder.DiscountValueType = ShopCart.DiscountValueType;
            mdOrder.DiscountAmount = ShopCart.DiscountAmount;
            mdOrder.OrderTotal = ShopCart.OrderTotal;


            int CouponItemID = 0;
            bool isUseCoupon = false;
            if (!string.IsNullOrEmpty(ddlCoupon)) //优惠券处理
            {
                string sCouponName;
                decimal FullAmount, CouponValue;
                EbSite.Entity.CouponItems mdCouponItem = EbSite.BLL.CouponItems.Instance.GetEntity(ddlCoupon, out sCouponName, out FullAmount, out CouponValue);
                if (mdCouponItem != null)
                {
                    if (mdOrder.OrderTotal >= FullAmount)//mdOrder.DiscountAmount >= FullAmount
                    {
                        CouponItemID = mdCouponItem.id;
                        mdOrder.CouponName = sCouponName;
                        mdOrder.CouponCode = mdCouponItem.ClaimCode;
                        mdOrder.CouponAmount = FullAmount;
                        mdOrder.CouponValue = CouponValue;
                        //flz(2013-12-13)如果用户用优惠券支付全额,则改变订单状态
                        if (mdOrder.CouponValue > 0 && mdOrder.OrderTotal == 0)
                        {
                            mdOrder.OrderStatus = ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(SystemEnum.OrderStatus.已支付);
                            mdOrder.PayDate = DateTime.Now;
                            isUseCoupon = true;
                        }
                    }
                }
            }

            if (UserID > 0)
            {
                Base.EntityAPI.MembershipUserEb mdUser = HostApi.EBMembershipInstance.Users_GetEntity(UserID);
                mdOrder.UserId = UserID;
                mdOrder.Username = mdUser.UserName;
                mdOrder.RealName = mdUser.NiName;
                mdOrder.EmailAddress = mdUser.emailAddress;
                //mdOrder.QQ = "";
                //mdOrder.Wangwang = "";
                //mdOrder.MSN = "";

            }
            else
            {
                mdOrder.UserId = HostApi.OnlineID;
                mdOrder.RealName = "匿名用户";
                mdOrder.Username = "";
                mdOrder.EmailAddress = "";
            }
            int iaddressid = 0;
            //EbSite.Core.Utils.TestDebug(address.ToString());
            if (!string.IsNullOrEmpty(address))
            {

                int.TryParse(address, out iaddressid);
                if (iaddressid > 0)
                {
                    EbSite.Entity.Address md = EbSite.BLL.Address.Instance.GetEntity(iaddressid);
                    mdOrder.Address = md.AddressInfo; //收货详细地址
                    mdOrder.ZipCode = md.PostCode; //邮编
                    mdOrder.SendToUserName = md.UserRealName;//收货人姓名
                    mdOrder.TelPhone = md.Phone; //收货人电话
                    mdOrder.CellPhone = md.Mobile; //收货人手机
                    //收货区域 如:浙江省，杭州市，下城区 即用户下单时选择的下拉,这里是区域ID，用逗号分开
                    mdOrder.SendRegion = string.Concat(md.CountryName, ",", md.AreaID);//CountryName没使用的字段，所以暂时用来保存当前区域的低级区域ID,用逗号分开
                    //查询地区所在区域ID
                    mdOrder.RegionId = EbSite.BLL.SendArea.Instance.GetSendAreaIDByAreaIDs(mdOrder.SendRegion);
                }
                else
                {
                    throw new Exception("无法获取地址ID，错误信息:" + address);
                }

            }
            if (!string.IsNullOrEmpty(rdoDelivery))//配送及运费计算处理
            {
                EbSite.Entity.PsDelivery mdDelivery = EbSite.BLL.PsDelivery.Instance.GetEntity(int.Parse(rdoDelivery));
                mdOrder.ModeName = mdDelivery.ModeName;
                mdOrder.ShippingModeId = mdDelivery.id;
                //mdOrder.RealShippingModeId = mdDelivery.id;
                //decimal CODTotalFree = 0;
                //decimal dRree = EbSite.BLL.PsDelivery.Instance.GetFreeByWeight(mdDelivery.id, TotalWeight, iaddressid, mdOrder.OrderTotal, out CODTotalFree);//(mdDelivery.id, TotalWeight, iaddressid, mdOrder.DiscountAmount, out CODTotalFree);
                //mdOrder.Freight = dRree;
                //if (!string.IsNullOrEmpty(rdoPayment) && rdoPayment == "-1")
                //{
                //    mdOrder.PayFree = CODTotalFree;//计算运费及货到付款费用
                //}



                decimal CODTotalFree = 0;
                decimal dRree = EbSite.BLL.PsDelivery.Instance.GetFreeByWeight(mdDelivery.id, TotalWeight, iaddressid, mdOrder.OrderTotal, out CODTotalFree);//(mdDelivery.id, TotalWeight, iaddressid, mdOrder.DiscountAmount, out CODTotalFree);

                if (!ShopCart.EightFree) //免运费 2014-3-24 yhl 添加
                {
                    mdOrder.Freight = dRree;

                }
                if (!ShopCart.PayFreeFree) //免支付手续
                {
                    if (!string.IsNullOrEmpty(rdoPayment) && rdoPayment == "-1")
                    {
                        mdOrder.PayFree = CODTotalFree;//计算运费及货到付款费用
                    }
                }
            }
            if (!string.IsNullOrEmpty(rdoPayment) && rdoPayment == "-1")
            {
                mdOrder.PaymentTypeId = -1;
                mdOrder.PaymentType = "货到付款";
            }
            else
            {
                mdOrder.PaymentTypeId = 0;
                mdOrder.PaymentType = "在线支付(未支付)";
            }


            if (sendtime == "1")
            {
                mdOrder.Remark += " 只在工作日送货（双休日、假日不送货）";
            }

            List<EbSite.Entity.OrderOptionValue> lstOov = new List<EbSite.Entity.OrderOptionValue>();

            if (!string.IsNullOrEmpty(optionitemids)) //订单选项费用，如果不为空，说明有选择
            {
                string[] aoptionitemids = optionitemids.Split('_');
                if (aoptionitemids.Length > 0) //订单选项的ID集合是用逗号分开的
                {
                    decimal OptionFree = 0;
                    foreach (string aoptionitemid in aoptionitemids)
                    {
                        if (!string.IsNullOrEmpty(aoptionitemid))
                        {
                            if (!string.IsNullOrEmpty(Request[aoptionitemid]))
                            {
                                int itemid = EbSite.Core.Utils.StrToInt(Request[aoptionitemid], 0);
                                EbSite.Entity.OrderOptionItems mdItem = EbSite.BLL.OrderOptionItems.Instance.GetEntity(itemid);
                                if (!Equals(mdItem, null))
                                {
                                    EbSite.Entity.OrderOptionValue oov = new OrderOptionValue();
                                    if (mdItem.CalculateMode == 0)//固定
                                    {
                                        oov.AdjustedPrice = mdItem.AppendMoney;
                                    }
                                    else  //百分比
                                    {
                                        oov.AdjustedPrice = (ShopCart.OrderTotal * mdItem.AppendMoney) / 100;//ShopCart.TotalRealSellPrice * mdItem.AppendMoney
                                    }

                                    oov.CustomerTitle = mdItem.UserInputTitle;
                                    oov.CustomerDescription = Request[string.Concat("opv", itemid)];//这个规则定死在模板
                                    oov.ItemDescription = mdItem.ItemName;
                                    oov.LookupItemId = itemid;
                                    oov.LookupListId = mdItem.OrderOptionID;
                                    lstOov.Add(oov);

                                    OptionFree += oov.AdjustedPrice;

                                }

                            }
                        }

                    }
                    //TotalPay = OptionFree;
                    mdOrder.OptionPrice = OptionFree;
                }

            }

            decimal iTotal = mdOrder.ToPayMoney - UMoney;//将计算结果更新更数据库  yhl 2013-11-05 减去 预付款的金额
            mdOrder.OrderTotal = iTotal;

            bool isUseUMoney = false;
            if (mdOrder.OrderTotal == 0 && UMoney > 0)
            {
                mdOrder.OrderStatus = ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(SystemEnum.OrderStatus.已支付);
                mdOrder.PayDate = DateTime.Now;
                isUseUMoney = true;
            }

            iOrderTatal = mdOrder.OrderTotal; //yhl 2013-11-05 用户最终的付款金额


            decimal Prepayments = UMoney;//使用预付款 
            mdOrder.UserBalance = UMoney;
            mdOrder.iCome = OrderiCome;
            OrderNumber = BLL.Buy_Orders.Instance.AddOrder(mdOrder, lstOov, CouponItemID, ShopCart.CartItems, ShopCart.CreditCartItems, new Entity.GroupBuy(), new Entity.CountDownBuy(), Prepayments);
            //添加日志
            ModuleCore.BLL.buy_orderlog.Instance.Add(OrderNumber.ToString(), "您提交了订单，请等待系统确认", SystemEnum.OrderLogType.前台显示);
            //判断是否用了优惠券
            if (isUseCoupon)
            {
                ModuleCore.BLL.buy_orderlog.Instance.Add(OrderNumber.ToString(), "用户使用了优惠券支付", SystemEnum.OrderLogType.全部显示);
            }
            //判断是否使用了预付款
            if (isUseUMoney)
            {
                ModuleCore.BLL.buy_orderlog.Instance.Add(OrderNumber.ToString(), "用户使用了预付款支付", SystemEnum.OrderLogType.全部显示);
            }
            TotalPay = mdOrder.OrderTotal;
            return (mdOrder.PaymentTypeId == -1);

        }

        protected void rpPaymentPClass_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                EbSite.Entity.PayTypeInfo drv = e.Item.DataItem as EbSite.Entity.PayTypeInfo;
                if (!Equals(drv, null))
                {

                    Repeater rpPayments = e.Item.FindControl("rpPayments") as Repeater;
                    if (!Equals(rpPayments, null))
                    {
                        rpPayments.DataSource = EbSite.BLL.Payment.Instance.GetListArrayByClassID(drv.id);
                        rpPayments.DataBind();
                    }
                }

            }
        }
        /// <summary>
        /// 检测用户的支付密码 YHL 2013-11-05
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        protected bool CheckUserPayPass(string pass)
        {
            bool key = false;

            EbSite.Entity.PayPass payModel =
                  EbSite.BLL.PayPass.Instance.GetEntityByUserID(EbSite.Base.Host.Instance.UserID);
            if (!Equals(payModel, null))
            {
                if (!string.IsNullOrEmpty(payModel.Pass))
                {
                    string sPass = UserIdentity.PassWordEncode(pass);
                    if (sPass == payModel.Pass)
                    {
                        key = true;
                    }
                }
            }

            return key;
        }



        virtual protected int OrderiCome
        {
            get
            {
                return Convert.ToInt32(SystemEnum.ComeType.pc);
            }
        }

        virtual protected Guid GetMenuLuYou
        {
            get { return new Guid("acd22185-6164-40ba-9a11-3c039d76c396"); }
        }
        virtual protected Guid GetMenuGuid
        {
            get
            {
                return new Guid("ac85e68f-7723-4c21-bcb8-90279f386c9b");
            }
        }
    }
}