using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore;
using EbSite.Modules.Shop.ModuleCore.BLL;
using EbSite.Modules.Shop.ModuleCore.Cart;
using System.Text;
using System.Web.UI.WebControls;
using NormRelationProduct = EbSite.Modules.Shop.ModuleCore.Entity.NormRelationProduct;

namespace EbSite.Modules.Shop
{


    public class AppStart : ModuleStartInit
    {
        static private int SiteID = 0;
        private static bool _startWasCalled;
        static public EbSite.Entity.ModuleInfo Model;

        public void Start()
        {
            if (_startWasCalled) return;
            _startWasCalled = true;

            //获取当前模块所在的站点Id,这样做可以防止别的站点下事件执行到这里搂
            //也就是说，如果当前访问非当前站点时，可以不处理事件(在下面会用到)
            //SiteID = SettingInfo.Instance.GetSiteID;
            EBSiteEvents.ApplicationBeginRequest += new EventHandler<EventArgs>(Application_BeginRequest);
            SettingInfo setting = new SettingInfo();

            //Log.Factory.GetInstance().InfoLog("来到模块ddd:"+ setting.CurrentModelID);
            // EbSite.BLL.ModulesBll.Modules.Instance.GetEntity(setting.CurrentModelID);
            //if (!Equals(Model, null))
            //{
            //    Log.Factory.GetInstance().InfoLog("成功获取模块ddd:" + Model.SetupPath);
            //}
            Model = SettingInfo.Instance.ModuleInfo;
            SiteID = Model.SiteID;


        }

        /*

        /// <summary>
        /// 要实现的方法 模块安装时执行(安装后) 向动态组件生成事件监听类  执行安装sql脚本
        /// </summary>
        /// <param name="ModuleID">传来已经安装好的模块ID</param>
        /// <param name="SetupPath">传来已经安装好的模块目录 格式是这样:/Modules/Order/</param>
        public void __Module_Setuped(Guid ModuleID, string SetupPath)
        {
            Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            System.Web.Configuration.ProfileSection profileSection = (System.Web.Configuration.ProfileSection)configuration.GetSection("system.web/profile");
            profileSection.AutomaticSaveEnabled = true;
            if (profileSection != null)
            {

                profileSection.Inherits = "EbSite.Modules.Shop.ModuleCore.Cart.ProfileCommon";
                profileSection.DefaultProvider = "eBSiteShopingCartProvider";


                ProviderSettings pps = new ProviderSettings("eBSiteShopingCartProvider", "EbSite.Modules.Shop.ModuleCore.Cart.CartProfileProvider");
                profileSection.Providers.Add(pps);

                ProfilePropertySettings ps = new ProfilePropertySettings("eBSiteShopingCart");
                ps.Type = "EbSite.Modules.Shop.ModuleCore.Cart.CartManger";
                ps.AllowAnonymous = true;
                ps.Provider = "eBSiteShopingCartProvider";
                profileSection.PropertySettings.Add(ps);

                configuration.Save();

            }
        }
        /// <summary>
        /// 要实现的方法 模块准备卸载前执行 删除动态组件监听事件类 执行删除sql脚本
        /// </summary>
        /// <param name="ModuleID">传来已经安装好的模块ID</param>
        /// <param name="SetupPath">传来已经安装好的模块目录 格式是这样:/Modules/Order/</param>
        public void __Module_Uninstalling(Guid ModuleID, string SetupPath)
        {
            Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            System.Web.Configuration.ProfileSection profileSection = (System.Web.Configuration.ProfileSection)configuration.GetSection("system.web/profile");
            profileSection.AutomaticSaveEnabled = true;
            if (profileSection != null)
            {
                //profileSection.Remove("DefaultProvider");
                //profileSection.Remove("Inherits");
                profileSection.Inherits = null;
                profileSection.DefaultProvider = null;

                profileSection.Providers.Remove("eBSiteShopingCartProvider");
                profileSection.PropertySettings.Remove("eBSiteShopingCart");

                configuration.Save();

            }
        }

    */

        private void OnPayed(object sender, PayedEventArgs e)
        {
            string trade_status = e.TradeStatus;
            ModuleCore.Entity.Buy_Orders mdEntity = ModuleCore.BLL.Buy_Orders.Instance.GetEntityByOrderNo(e.OrderNo);
            string strMsg = "";
            if (mdEntity != null)
            {
                //订单状态OrderStatus 0.等待买家付款 1.等待发货 2.已发货 3.成功订单 4.已关闭 5.历史订单 6.已删除
                if (trade_status == "WAIT_BUYER_PAY")
                {//该判断表示买家已在支付宝交易管理中产生了交易记录，但没有付款
                    strMsg = "买家已在支付宝交易管理中产生了交易记录，但没有付款";
                    EbSite.Base.Host.Instance.InsertLog("该判断表示买家已在支付宝交易管理中产生了交易记录，但没有付款", "号:" + e.OrderNo);
                    //判断该笔订单是否在商户网站中已经做过处理（可参考“集成教程”中“3.4返回数据处理”）
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //如果有做过处理，不执行商户的业务程序
                    mdEntity.OrderStatus = 2;
                }
                else if (trade_status == "WAIT_SELLER_SEND_GOODS")
                {//该判断示买家已在支付宝交易管理中产生了交易记录且付款成功，但卖家没有发货
                    strMsg = "买家已在支付宝交易管理中产生了交易记录且付款成功，但卖家没有发货";
                    EbSite.Base.Host.Instance.InsertLog("该判断示买家已在支付宝交易管理中产生了交易记录且付款成功，但卖家没有发货", "号:" + e.OrderNo);
                    //判断该笔订单是否在商户网站中已经做过处理（可参考“集成教程”中“3.4返回数据处理”）
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //如果有做过处理，不执行商户的业务程序
                    mdEntity.OrderStatus = 21;
                }
                else if (trade_status == "WAIT_BUYER_CONFIRM_GOODS")
                {
                    //该判断表示卖家已经发了货，但买家还没有做确认收货的操作
                    strMsg = "卖家已经发了货，等待买家做确认收货的操作";
                    EbSite.Base.Host.Instance.InsertLog("该判断表示卖家已经发了货，但买家还没有做确认收货的操作", "号:" + e.OrderNo);
                    //判断该笔订单是否在商户网站中已经做过处理（可参考“集成教程”中“3.4返回数据处理”）
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //如果有做过处理，不执行商户的业务程序
                    mdEntity.OrderStatus = 3;
                }
                else if (trade_status == "TRADE_FINISHED" || trade_status == "TRADE_SUCCESS")
                {
                    // TRADE_FINISHED(表示交易已经成功结束，通用即时到帐反馈的交易状态成功标志);
                    //TRADE_SUCCESS(表示交易已经成功结束，高级即时到帐反馈的交易状态成功标志);
                    //该判断表示买家已经确认收货，这笔交易完成
                    strMsg = "<span>订单已支付成功，请等待确认</span>";
                    EbSite.Base.Host.Instance.InsertLog("订单已经付款成功，请等待确认", "号:" + e.OrderNo);
                    //判断该笔订单是否在商户网站中已经做过处理（可参考“集成教程”中“3.4返回数据处理”）
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //如果有做过处理，不执行商户的业务程序
                    mdEntity.OrderStatus = 21;
                }
                else
                {
                    strMsg = "交易成功，但状态未知,号:" + e.OrderNo + ",状态号:" + trade_status;
                    mdEntity.OrderStatus = 21;
                    EbSite.Base.Host.Instance.InsertLog("交易成功，但状态未知", "号:" + e.OrderNo + ",状态号:" + trade_status);
                }

                //ModuleCore.BLL.Buy_Orders.Instance.Update(mdEntity);

                #region 已完成
                //flz
                if (mdEntity.OrderStatus > 0)
                {
                    decimal payPrice = 0;
                    try
                    {
                        payPrice = decimal.Parse(e.TotalFee);
                    }
                    catch
                    {
                        payPrice = 0;
                    }
                    DateTime dt = DateTime.Now;
                    string strPayMsg = string.Format("{0}{1}到账:{2}元【北迈商城自助支付—支付宝】", dt.ToString("yyyy-MM-dd"), e.Subject, payPrice);
                    //EbSite.Base.Plugin.Factory.SendMobile(string.Concat(strPayMsg, "[北迈汽配网]"), "13691074889", "cqs263");
                    //更新状态
                    Dictionary<string, object> dicArr = new Dictionary<string, object>();
                    dicArr.Add("orderstatus", mdEntity.OrderStatus);
                    dicArr.Add("paydate", "'" + dt + "'");
                    if (ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicArr, mdEntity.id))
                    {
                        ModuleCore.Entity.buy_orderlog reMd = new ModuleCore.Entity.buy_orderlog();
                        reMd.OrderID = mdEntity.OrderId;
                        reMd.OpDate = dt;
                        reMd.OpUserId = mdEntity.UserId;
                        reMd.OpUserName = mdEntity.Username;
                        reMd.OpType = 0;
                        reMd.OpCtent = strMsg;

                        ModuleCore.BLL.buy_orderlog.Instance.Add(reMd);
                    }
                }

                #endregion 已完成


            }
            else
            {
                EbSite.Base.Host.Instance.InsertLog("交易成功，获取订单编号失败", "取不到当前订单数据,返回状态为:" + trade_status);
            }

        }

        private static string StartupOK = null;
        private static object _SyncRoot = new object();
        public void Application_BeginRequest(object sender, EventArgs e)
        {
            if (StartupOK == null)
            {
                lock (_SyncRoot)
                {
                    if (StartupOK == null)
                    {
                        EbSite.Base.EBSiteEvents.Payed += new EventHandler<PayedEventArgs>(OnPayed);
                        EbSite.Base.EBSiteEvents.ContentAdding += new EventHandler<EbSite.Base.EBSiteEventArgs.AddingContentEventArgs>(On_Adding);
                        EbSite.Base.EBSiteEvents.HttpModuleRuning += new EventHandler<HttpModuleRuningEventArgs>(On_HttpModuleRuning);
                        EbSite.Base.EBSiteEvents.ClassListLoading += new EventHandler<ClassListLaodingEventArgs>(On_ClassListLoading);
                        EbSite.Base.EBSiteEvents.GotoPay += new EventHandler<GotoPayEventArgs>(On_GotoPay);

                        // EbSite.Base.EBSiteEvents.ClassPageLoadingEvent += new EventHandler<ClassPageLoadingEventArgs>(On_ClassPageLoadingEvent);
                        EbSite.Base.EBSiteEvents.ClassPageLoadEvent += new EventHandler<ClassPageLoadEventArgs>(On_ClassPageLoadEvent);

                        EbSite.Base.EBSiteEvents.ContentPageLoadEvent += new EventHandler<ContentPageLoadEventArgs>(On_ContentPageLoadEvent);


                        EbSite.Base.EBSiteEvents.AllowContentEvent += new EventHandler<AllowContentEventArgs>(On_AllowContentEvent);

                        EbSite.Base.EBSiteEvents.IndexPageLoadEvent += new EventHandler<IndexPageLoadEventArgs>(On_IndexPageLoadEvent);

                        //EbSite.Base.EBSiteEvents.ContentItemBound +=
                        //    new EventHandler<RepeaterItemEventArgs>(rpListFeeOptionContentList_ItemBound);


                        EbSite.Base.EBSiteEvents.ContentDeleteing += new EventHandler<DeleteingContentEventArgs>(On_ContentDeleteing);


                     //   EbSite.Base.EBSiteEvents.SubClassBinding += new EventHandler<SubClassBindingEventArgs>(On_MobileSubClassBind);

                       // EbSite.Base.EBSiteEvents.Searching += new EventHandler<SearchEventArgs>(On_Searching);

                     //   EBSiteEvents.ClassItemBound += new EventHandler<ClassRepeaterItemEventArgs>(rpGetClassList_ItemBound);
                        StartupOK = "OK";
                    }
                }
            }


        }
     

        ///// <summary>
        ///// 搜索之前可以进行一些业务处理
        ///// </summary>
        //private static void On_Searching(object sender, SearchEventArgs e)
        //{
        //    if (e.SiteID == SiteDI)
        //    {
        //        if (!string.IsNullOrEmpty(e.KeyWord))
        //        {
        //            //e.KeyWord 当前搜索的关键词
        //            //e.Context  当前搜索的上下文     [Annex25] int 标实分类【1.产品 2.文章 】 所有的内容模型 都要用Annex25来标实。   
        //            e.Where = "annex25=1 and  newstitle like '%" + e.KeyWord + "%'";

        //        }
        //    }
        //}

        ///// <summary>
        ///// 手机版 现在 pc 版 也给拦截了YHL
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private static void On_MobileSubClassBind(object sender, SubClassBindingEventArgs e)
        //{
        //    if (e.SiteID == SettingInfo.Instance.GetSiteID)
        //    {
        //        if (e.ClassID == 0)
        //        {
        //            e.Where = "parentid=0 and annex9=1";
        //        }

        //    }
        //}
        private static void On_IndexPageLoadEvent(object sender, IndexPageLoadEventArgs e)
        {
            if (e.SiteID == SettingInfo.Instance.GetSiteID)
            {
                System.Web.UI.WebControls.Repeater rpList = e.Page.FindControl("rpFloorList") as System.Web.UI.WebControls.Repeater;
                if (!Equals(rpList, null))
                {
                    List<ModuleCore.Entity.FloorSet> ls = ModuleCore.BLL.FloorSetInfo.Instance.FillList();
                    List<ModuleCore.Entity.FloorSet> nls = (from i in ls orderby i.FloorId ascending select i).ToList();
                    //ExIndexPageLoadEvent ExIndexEvent = new ExIndexPageLoadEvent();
                    rpList.ItemDataBound += new RepeaterItemEventHandler(ExIndexPageLoadEvent.rpList_ItemDataBound);
                    rpList.DataSource = nls;
                    rpList.DataBind();
                }
                System.Web.UI.WebControls.Repeater rpMList = e.Page.FindControl("rpMFloorList") as System.Web.UI.WebControls.Repeater;
                if (!Equals(rpMList, null))
                {
                    List<ModuleCore.Entity.MFloorSet> ls = ModuleCore.BLL.MFloorSetInfo.Instance.FillList();
                    List<ModuleCore.Entity.MFloorSet> nls = (from i in ls orderby i.FloorId ascending select i).ToList();
                    rpMList.ItemDataBound += new RepeaterItemEventHandler(ExMobileIndexPageLoadEvent.rpMFloorList_ItemDataBound);
                    rpMList.DataSource = nls;
                    rpMList.DataBind();
                }
            }
        }



        private  void On_AllowContentEvent(object sender, AllowContentEventArgs e)
        {
            int key = e.ID;



        }

        private  void On_ContentDeleteing(object sender, DeleteingContentEventArgs arg)
        {
            if (arg.ID > 0)
            {
                //商品规格 NormRelationProduct
                //扩展属性 TypeRelationProduct
                //商品图片 ProductsImg
                //商品费用选项 ProductOptions ProductOptionItems
                //最佳组合  P_BestGroup
                //推荐配件 P_BestGroup
                //使用指南  P_UserBook
                ModuleCore.BLL.ProductOptions.Instance.DeleteProductOption(arg.ID);

                arg.StopDelete = false;
            }

        }
        private  void On_GotoPay(object sender, GotoPayEventArgs e)
        {
            if (e.OrderNamber > 0)//if (!string.IsNullOrEmpty(e.OrderNamber))
            {
                ModuleCore.Entity.Buy_Orders mdOrder = ModuleCore.BLL.Buy_Orders.Instance.GetEntityByOrderID(e.OrderNamber);
                if (!Equals(mdOrder, null))
                {

                    mdOrder.PaymentTypeId = e.Payment.id;
                    mdOrder.PaymentType = e.Payment.PaymentName;
                    ModuleCore.BLL.Buy_Orders.Instance.Update(mdOrder);
                }
            }
        }

        private  void On_HttpModuleRuning(object sender, HttpModuleRuningEventArgs e)
        {
            HttpContext httpContext = e.App.Context;
            string requestPath = httpContext.Request.Path.ToLower();

            #region


            string strRuleProductphotobox = GetLinks.Instance.RegexPhotoBoxUrlRule();
            string strRuleShoppingcar = GetLinks.Instance.RegexShoppingCarUrlRule();
            string strRulePostcar = GetLinks.Instance.RegexPostCarUrlRule();
            string strRuleGotoPay = GetLinks.Instance.RegexGoToPayUrlRule();
            string strRuleReducePriceUrl = GetLinks.Instance.RegexReducePriceUrl();

            string strRuleGroupList = GetLinks.Instance.RegexGroupListRule();
            string strRuleGroupShow = GetLinks.Instance.RegexGroupShowRule();

            string strRuleRushList = GetLinks.Instance.RegexRushListRule();
            string strRuleRushShow = GetLinks.Instance.RegexRushShowRule();

            string strRuleActFullQuantity = GetLinks.Instance.RegexActFullQRule();
            string strActFullMoney = GetLinks.Instance.RegexActFullMRule();

            string strRuleGetGroupUrl = GetLinks.Instance.RegexGetGroupUrlRule();

            string strRuleJiFen = GetLinks.Instance.RegexJiFenRule();
            string strRulejifenShow = GetLinks.Instance.RegexJiFenShowRule();


            string strRuleViewOrder = GetLinks.Instance.RegexViewOrderUrlRule();

            string strRulePrintOrder = GetLinks.Instance.RegexPrintOrderRule();

            string strCompare = GetLinks.Instance.RegexCompareRule();//对比页面

            string strRuleTradeComment = GetLinks.Instance.RegexTradeCommentRule();//商品评价




            #region 手机
            string strRuleMShoppingcar = GetLinks.Instance.MRegexShoppingCarUrlRule();

            string strRuleMPostcar = GetLinks.Instance.MRegexPostCarUrlRule();

            string strRuleMGotoPay = GetLinks.Instance.MRegexGoToPayUrlRule();

            string strRuleViewOrderM = GetLinks.Instance.RegexViewOrderMUrlRule();


            string strRuleMJiFen = GetLinks.Instance.RegexMJiFenRule();
            string strRuleMjifenShow = GetLinks.Instance.RegexMJiFenShowRule();


            string strRuleMRushList = GetLinks.Instance.RegexMRushListRule();
            string strRuleMRushShow = GetLinks.Instance.RegexMRushShowRule();


            string strRuleMGroupList = GetLinks.Instance.RegexMGroupListRule();
            string strRuleMGroupShow = GetLinks.Instance.RegexMGroupShowRule();

            string strRuleMActFullQuantity = GetLinks.Instance.RegexMActFullQRule();
            #endregion

            if (Core.Utils.IsMatchReWrite(requestPath, strRuleProductphotobox)) //商品相册页面
            {
                Match mc = Regex.Match(requestPath, strRuleProductphotobox);
                if (mc.Success)
                {

                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string ProductID = mc.Groups[2].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mproductphotobox.aspx"), "?pid=", ProductID, "&site=", iSiteID);
                    e.IsStop = true;
                }
            }

            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleShoppingcar))//购物车
            {
                Match mc = Regex.Match(requestPath, strRuleShoppingcar);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mshoppingcar1.aspx"), "?site=", iSiteID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRulePostcar))//提交订单
            {
                Match mc = Regex.Match(requestPath, strRulePostcar);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mshoppingcar2.aspx"), "?site=", iSiteID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleGotoPay))//付款
            {
                Match mc = Regex.Match(requestPath, strRuleGotoPay);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mshoppingcar3.aspx"), "?site=", iSiteID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleReducePriceUrl))//付款
            {
                Match mc = Regex.Match(requestPath, strRuleReducePriceUrl);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string ProductID = mc.Groups[2].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mreduceprice.aspx"), "?site=", iSiteID, "&pid=", ProductID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleGroupList))//团购列表
            {
                Match mc = Regex.Match(requestPath, strRuleGroupList);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    int iClassID = int.Parse(mc.Groups[2].Value);

                    int iPageIndex = int.Parse(mc.Groups[3].Value);

                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mgrouplist.aspx"), "?site=", iSiteID, "&cid=", iClassID, "&p=", iPageIndex);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleGroupShow))//团购内容
            {
                Match mc = Regex.Match(requestPath, strRuleGroupShow);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string GroupID = mc.Groups[2].Value;
                    string ProductID = mc.Groups[3].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mgroupshow.aspx"), "?site=", iSiteID, "&gid=", GroupID, "&id=", ProductID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleRushList))//抢购列表
            {
                Match mc = Regex.Match(requestPath, strRuleRushList);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    int iClassId = int.Parse(mc.Groups[2].Value);

                    int iPageIndex = int.Parse(mc.Groups[3].Value);

                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mrushlist.aspx"), "?site=", iSiteID, "&cid=", iClassId, "&p=", iPageIndex);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleRushShow))//抢购内容
            {
                Match mc = Regex.Match(requestPath, strRuleRushShow);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string GroupID = mc.Groups[2].Value;
                    string ProductID = mc.Groups[3].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mrushshow.aspx"), "?site=", iSiteID, "&qid=", GroupID, "&id=", ProductID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleActFullQuantity))//满量优惠活动
            {
                Match mc = Regex.Match(requestPath, strRuleActFullQuantity);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    int iActID = int.Parse(mc.Groups[2].Value);
                    int iPageIndex = int.Parse(mc.Groups[3].Value);
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mactfullquantity.aspx"), "?site=", iSiteID, "&id=", iActID, "&p=", iPageIndex);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strActFullMoney))//满额优惠活动
            {
                Match mc = Regex.Match(requestPath, strActFullMoney);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    int iActID = int.Parse(mc.Groups[2].Value);
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mactfullmoney.aspx"), "?site=", iSiteID, "&id=", iActID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleGetGroupUrl))//求团购
            {
                Match mc = Regex.Match(requestPath, strRuleGetGroupUrl);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string ProductID = mc.Groups[2].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("forgroup.aspx"), "?site=", iSiteID, "&pid=", ProductID);
                    e.IsStop = true;
                }
            }
            //      string strRuleJiFen = "jinfen-([0-9]+).ashx";
            //string strRulejifenShow = "jifenshow-([0-9]+)-([0-9]+).ashx";
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleJiFen))//积分商城
            {
                Match mc = Regex.Match(requestPath, strRuleJiFen);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    int iClassID = int.Parse(mc.Groups[2].Value);
                    int iPageIndex = int.Parse(mc.Groups[3].Value);
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mjifen.aspx"), "?site=", iSiteID, "&cid=", iClassID, "&p=", iPageIndex);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRulejifenShow))//积分内容
            {
                Match mc = Regex.Match(requestPath, strRulejifenShow);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string ProductID = mc.Groups[2].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mjifenshow.aspx"), "?site=", iSiteID, "&pid=", ProductID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleViewOrder))
            {
                #region 查看订单
                Match mc = Regex.Match(requestPath, strRuleViewOrder);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string iOrderID = mc.Groups[2].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("orderinfo.aspx"), "?site=", iSiteID, "&oid=", iOrderID);
                    e.IsStop = true;
                }
                #endregion 查看订单
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRulePrintOrder))
            {
                Match mc = Regex.Match(requestPath, strRulePrintOrder);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string iOrderID = mc.Groups[2].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("orderprint.aspx"), "?site=", iSiteID, "&oid=", iOrderID);
                    e.IsStop = true;
                }
            }
            //else if (Core.Utils.IsMatchReWrite(requestPath, strRuleproduct))//产品内容页面
            //{
            //    Match mc = Regex.Match(requestPath, strRuleproduct);
            //    if (mc.Success)
            //    {
            //        int iSiteID = int.Parse(mc.Groups[1].Value);
            //        string ProductID = mc.Groups[2].Value;
            //        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
            //        e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mcontent_product.aspx"), "?site=", iSiteID, "&id=", ProductID);
            //        e.IsStop = true;
            //    }
            //}
            //else if (Core.Utils.IsMatchReWrite(requestPath, strRuleproductClass))//产品分类页面
            //{
            //    Match mc = Regex.Match(requestPath, strRuleproductClass);
            //    if (mc.Success)
            //    {
            //        int iSiteID = int.Parse(mc.Groups[1].Value);
            //        string ProductID = mc.Groups[2].Value;
            //        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
            //        e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mlist_product.aspx"), "?site=", iSiteID, "&cid=", ProductID);
            //        e.IsStop = true;
            //    }
            //}
            else if (Core.Utils.IsMatchReWrite(requestPath, strCompare))//对比页面
            {
                Match mc = Regex.Match(requestPath, strCompare);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);

                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mcompare.aspx"), "?site=", iSiteID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleTradeComment))//商品评价
            {
                Match mc = Regex.Match(requestPath, strRuleTradeComment);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string orderid = mc.Groups[2].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mtradecomment.aspx"), "?site=", iSiteID, "&orderid=" + orderid);
                    e.IsStop = true;
                }
            }

            #region 手机


            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleMShoppingcar))//手机版购物车
            {
                Match mc = Regex.Match(requestPath, strRuleMShoppingcar);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("mmshoppingcar1.aspx"), "?site=", iSiteID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleMPostcar))//手机版 提交订单
            {
                Match mc = Regex.Match(requestPath, strRuleMPostcar);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("mmshoppingcar2.aspx"), "?site=", iSiteID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleMGotoPay))//手机版付款
            {
                Match mc = Regex.Match(requestPath, strRuleMGotoPay);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("mmshoppingcar3.aspx"), "?site=", iSiteID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleViewOrderM))
            {
                #region 查看订单
                Match mc = Regex.Match(requestPath, strRuleViewOrderM);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string iOrderID = mc.Groups[2].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("morderinfo.aspx"), "?site=", iSiteID, "&oid=", iOrderID);
                    e.IsStop = true;
                }
                #endregion 查看订单
            }



            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleMJiFen))//手机版积分商城
            {
                Match mc = Regex.Match(requestPath, strRuleMJiFen);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    int iClassID = int.Parse(mc.Groups[2].Value);
                    int iPageIndex = int.Parse(mc.Groups[3].Value);
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("mmjifen.aspx"), "?site=", iSiteID, "&cid=", iClassID, "&p=", iPageIndex);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleMjifenShow))//积分内容
            {
                Match mc = Regex.Match(requestPath, strRuleMjifenShow);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string ProductID = mc.Groups[2].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("mmjifenshow.aspx"), "?site=", iSiteID, "&pid=", ProductID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleMRushList))//手机版抢购列表
            {
                Match mc = Regex.Match(requestPath, strRuleMRushList);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    int iClassId = int.Parse(mc.Groups[2].Value);

                    int iPageIndex = int.Parse(mc.Groups[3].Value);

                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("mmrushlist.aspx"), "?site=", iSiteID, "&cid=", iClassId, "&p=", iPageIndex);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleMRushShow))//抢购内容
            {
                Match mc = Regex.Match(requestPath, strRuleMRushShow);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string GroupID = mc.Groups[2].Value;
                    string ProductID = mc.Groups[3].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("mmrushshow.aspx"), "?site=", iSiteID, "&qid=", GroupID, "&id=", ProductID);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleMGroupList))//手机版 团购列表
            {
                Match mc = Regex.Match(requestPath, strRuleMGroupList);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    int iClassID = int.Parse(mc.Groups[2].Value);

                    int iPageIndex = int.Parse(mc.Groups[3].Value);

                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("mmgrouplist.aspx"), "?site=", iSiteID, "&cid=", iClassID, "&p=", iPageIndex);
                    e.IsStop = true;
                }
            }
            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleMGroupShow))//手机版 团购内容
            {
                Match mc = Regex.Match(requestPath, strRuleMGroupShow);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    string GroupID = mc.Groups[2].Value;
                    string ProductID = mc.Groups[3].Value;
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("mmgroupshow.aspx"), "?site=", iSiteID, "&gid=", GroupID, "&id=", ProductID);
                    e.IsStop = true;
                }
            }

            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleMActFullQuantity))//手机版 满量优惠活动
            {
                Match mc = Regex.Match(requestPath, strRuleMActFullQuantity);
                if (mc.Success)
                {
                    int iSiteID = int.Parse(mc.Groups[1].Value);
                    int iActID = int.Parse(mc.Groups[2].Value);
                    int iPageIndex = int.Parse(mc.Groups[3].Value);
                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
                    e.RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("mmactfullquantity.aspx"), "?site=", iSiteID, "&id=", iActID, "&p=", iPageIndex);
                    e.IsStop = true;
                }
            }
            #endregion

            #endregion

        }
        ///// <summary>
        ///// 得到当站点的SiteID
        ///// </summary>
        //protected static int SiteDI
        //{
        //    get
        //    {
        //        return SettingInfo.Instance.GetSiteID;
        //    }
        //}
        private void On_ClassListLoading(object sender, ClassListLaodingEventArgs e)
        {
            if (e.SiteID == SiteID)
            {
                if (e.ClassID > 0)
                {
                    HttpContext httpContext = e.Context;//e.App.Context;
                    string requestPath = httpContext.Request.RawUrl.ToLower();
                    //shop/12560-3-0c.ashx?brand=28&special=86&valuestr=4_29-5_34-6_37
                    string ispecial = httpContext.Request.QueryString["special"];
                    string ibrand = httpContext.Request.QueryString["brand"];
                    string ivaluestr = httpContext.Request.QueryString["valuestr"];
                    StringBuilder strWhere = new StringBuilder();
                    StringBuilder strPageParameter = new StringBuilder();
                    if (!string.IsNullOrEmpty(ispecial))//要查此专题下与此分类下 的NewsID的集合
                    {
                        strWhere.AppendFormat("  id in(SELECT newsid	 from eb_specialnews where classid={0} and SpecialClassID={1}) and", e.ClassID, ispecial);
                        strPageParameter.AppendFormat("special,{0}|", ispecial);
                    }
                    if (!string.IsNullOrEmpty(ibrand))//annex11 商品品牌
                    {
                        strWhere.AppendFormat("  annex11={0} and", ibrand);
                        strPageParameter.AppendFormat("brand,{0}|", ibrand);
                    }
                    if (!string.IsNullOrEmpty(ivaluestr))//属性 
                    {
                        strPageParameter.AppendFormat("valuestr,{0}|", ivaluestr);
                        string[] arry = ivaluestr.Split('-');
                        for (int i = 0; i < arry.Count(); i++)
                        {
                            string[] arryAttributes = arry[i].Split('_');
                            strWhere.AppendFormat("  id IN ( SELECT ProductId FROM ebshop_typerelationproduct WHERE AttributeId={0} And item={1} ) and", arryAttributes[0], arryAttributes[1]);
                        }
                    }
                    //SELECT * from eb_newscontent where SiteID=3 and ClassID=12560 and annex11=26 and id IN ( SELECT ProductId FROM ebshop_typerelationproduct WHERE AttributeId=3 And item=8) and id IN ( SELECT ProductId FROM ebshop_typerelationproduct WHERE AttributeId=4 And item=29) and id in(SELECT newsid	 from eb_specialnews where subclassid=12560 and SpecialClassID=87);
                    if (strWhere.Length > 0)
                    {
                        strWhere.AppendFormat(" classid={0} and", e.ClassID);
                        strWhere = strWhere.Remove(strWhere.Length - 3, 3);
                        e.Where = strWhere.ToString();
                    }

                    string orderTs = e.Context.Request["orderby"];
                    string orderstr = "id desc";
                    if (!string.IsNullOrEmpty(orderTs))
                    {
                        if (orderTs == "1")// 销售量
                            orderstr = "annex21 desc";
                        if (orderTs == "2")// 价格从低到高排序
                            orderstr = "Annex16 asc";
                        if (orderTs == "3")// 价格从高到低排序
                            orderstr = "Annex16 desc";
                        if (orderTs == "4")// 评论数量
                            orderstr = "commentnum desc";
                        if (orderTs == "5")//最新上架
                            orderstr = "numbertime desc";
                    }
                    if (!string.IsNullOrEmpty(e.Where))
                        e.OrderBy = orderstr;
                    else
                    {
                        e.Where = "classid=" + e.ClassID;
                        e.OrderBy = orderstr;
                    }
                }
                else
                {
                    //手机主页 页面
                    string sType = e.Context.Request["t"];
                    if (!string.IsNullOrEmpty(sType))
                    {
                        if (sType == "1") //日排行
                        {
                            e.OrderBy = "dayhits  desc";
                        }
                        else if (sType == "2") // 周排行
                        {
                            e.OrderBy = "weekhits  desc";
                        }

                    }

                }

            }
        }

        private  void On_Adding(object sender, EbSite.Base.EBSiteEventArgs.AddingContentEventArgs e)
        {
            if (e.ID == 0) //添加前的ID为0
            {
                EbSite.Entity.NewsContent nc = (EbSite.Entity.NewsContent)sender;

                if (!Equals(nc, null))
                {
                    //e.StopAdd = true;//阻住当前的添加操作
                }
            }
        }
        //override public void Profile_MigrateAnonymous(Object sender, ProfileMigrateEventArgs e)
        //{
        //    try
        //    {
        //        ProfileBase p = ProfileBase.Create(e.AnonymousID, false);
        //        if (p is ProfileCommon)
        //        {
        //            ProfileCommon anonProfile = p as ProfileCommon;

        //            ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
        //            //商品
        //            foreach (ModuleCore.Entity.Buy_CartItem cartItem in anonProfile.ShopCart.CartItems)
        //            {
        //                profile.ShopCart.Add(cartItem);
        //            }
        //            ////积分商品 礼品必要要登录，所以不用这个了
        //            //foreach (ModuleCore.Entity.Buy_CreditCartItem cartItem in anonProfile.ShopCart.CreditCartItems)
        //            //{
        //            //    profile.ShopCart.AddCreditCartItem(cartItem);
        //            //}

        //            ProfileManager.DeleteProfile(e.AnonymousID);
        //            AnonymousIdentificationModule.ClearAnonymousIdentifier();

        //            // Save profile
        //            profile.Save();
        //        }
        //    }
        //    catch (Exception ep)
        //    {
        //        EbSite.Base.Host.Instance.InsertLog("用户数据迁移发生错误", ep.Message);

        //    }



        //}
        


        private static void On_ClassPageLoadEvent(object sender, ClassPageLoadEventArgs e)
        {
            int Special = -1;
            int Brand = -1;
            string orderby = "";
            string valusTag = "";

            if (e.ClassID > 0 && e.SiteID == SettingInfo.Instance.GetSiteID)
            {
                #region 接收 专题参数 品牌参数 排序参数
                //int Special = 0;
                if (!string.IsNullOrEmpty(e.Context.Request["special"]))
                {
                    Special = int.Parse(e.Context.Request["special"]);
                }
                // int Brand = 0;
                if (!string.IsNullOrEmpty(e.Context.Request["brand"]))
                {
                    Brand = int.Parse(e.Context.Request["brand"]);
                }
                // string orderby = "";
                if (!string.IsNullOrEmpty(e.Context.Request["orderby"]))
                {
                    orderby = e.Context.Request["orderby"];
                }
                // string valusTag="";//valueStr=2_8-1_4
                if (!string.IsNullOrEmpty(e.Context.Request["valueStr"]))
                {
                    valusTag = e.Context.Request["valueStr"];
                }

                #endregion

                ModuleCore.ExClassPageLoadEvent ExClassEvent = new ExClassPageLoadEvent(e.Context, e.ClassID);

                EbSite.Entity.NewsClass md = EbSite.BLL.NewsClass.GetModel(e.ClassID);
                //  drpGoodsType.SelectedValue = md.Annex8;//默认 选中类型
                if (!string.IsNullOrEmpty(md.Annex8))
                {
                    ModuleCore.Entity.TypeNames model = ModuleCore.BLL.TypeNames.Instance.GetEntity(Convert.ToInt32(md.Annex8));//品牌

                    if (!Equals(model, null))
                    {
                        List<ModuleCore.Entity.TypeNameValue> lst = ModuleCore.BLL.TypeNameValue.Instance.GetListArray(" IsSele=1 and typenameid=" + Convert.ToInt32(md.Annex8));//查出 允许检索的属性

                        List<ListItemModelEx> Nlst = new List<ListItemModelEx>();
                        #region 品牌
                        Control.Repeater exRpBrand = e.Page.FindControl("rpBrand") as Control.Repeater;
                        if (!Equals(exRpBrand, null))
                        {
                            if (!string.IsNullOrEmpty(model.BrandIDs))
                            {
                                List<ListItemModelEx> NlstBrand = new List<ListItemModelEx>();
                                ListItemModelEx mdbrand = new ListItemModelEx();
                                mdbrand.Text = "品牌";
                                mdbrand.Value = model.BrandIDs;


                                #region 对品牌 "不限" 的地址

                                StringBuilder iEUrl = new StringBuilder();
                                if (Special > 0)
                                {
                                    iEUrl.AppendFormat("&special={0}", Special);
                                }
                                if (!string.IsNullOrEmpty(orderby))
                                {
                                    iEUrl.AppendFormat("&orderby={0}", orderby);
                                }
                                if (!string.IsNullOrEmpty(valusTag))
                                {
                                    iEUrl.AppendFormat("&valueStr={0}", valusTag);
                                }
                                if (iEUrl.Length > 0)
                                    iEUrl = iEUrl.Remove(0, 1);
                                if (iEUrl.Length == 0)
                                {
                                    mdbrand.Url = EbSite.Base.Host.Instance.GetClassHref(e.ClassID, 1, SettingInfo.Instance.GetSiteID);
                                }
                                else
                                {
                                    mdbrand.Url = EbSite.Base.Host.Instance.GetClassHref(e.ClassID, 1, SettingInfo.Instance.GetSiteID) + "?" + iEUrl;
                                }


                                #endregion

                                if (Brand < 0)
                                {
                                    mdbrand.StyleBg = "cur";
                                }
                                NlstBrand.Add(mdbrand);
                                exRpBrand.ItemDataBound += new RepeaterItemEventHandler(ExClassEvent.rpBrand_ItemDataBound);
                                exRpBrand.DataSource = NlstBrand;
                                exRpBrand.DataBind();
                            }
                        }

                        #endregion

                        #region 专题

                        Control.Repeater exRpSpecial = e.Page.FindControl("rpSpecial") as Control.Repeater;
                        Control.Repeater exRpSpecialSmall = e.Page.FindControl("rpSpecialSmall") as Control.Repeater;

                        if (!Equals(exRpSpecial, null) && !Equals(exRpSpecialSmall, null))
                        {
                            if (model.IsSpecial)//关联 专题
                            {
                                List<ListItemModelEx> NlstSpecial = new List<ListItemModelEx>();
                                ListItemModelEx mdspecial = new ListItemModelEx();
                                int spParentID = 0;
                                if (Special > 0)
                                {
                                    // 获取某个分类下的子分类个数
                                    int smallSpecialnum = EbSite.BLL.SpecialClass.GetSubCount(Special, SettingInfo.Instance.GetSiteID);
                                    Entity.SpecialClass mdsp = EbSite.BLL.SpecialClass.GetModel(Special);
                                    spParentID = mdsp.ParentID;
                                    if (smallSpecialnum > 0)
                                    {
                                        mdspecial.Text = ExClassEvent.SpecialClass(Special, spParentID, Brand, orderby, valusTag);//"车型"; 奥迪-奥迪100
                                        mdspecial.ID = Special.ToString();
                                    }
                                    else
                                    {
                                        mdspecial.Text = ExClassEvent.SpecialClass(spParentID, spParentID, Brand, orderby, valusTag);//"车型";奥迪-奥迪100
                                        mdspecial.ID = spParentID.ToString();

                                        Entity.SpecialClass mdbigsp = EbSite.BLL.SpecialClass.GetModel(spParentID);
                                        spParentID = mdbigsp.ParentID;//父类的父类
                                    }
                                }
                                mdspecial.Url = ExClassEvent.SpecialUrl(spParentID, Brand, orderby, valusTag);
                                NlstSpecial.Add(mdspecial);
                                if (Special < 0) //没有 选专题的情况
                                {
                                    exRpSpecial.ItemDataBound += new RepeaterItemEventHandler(ExClassEvent.rpSpecial_ItemDataBound);
                                    mdspecial.StyleBg = "cur";
                                    exRpSpecial.DataSource = NlstSpecial; //一级专题
                                    exRpSpecial.DataBind();
                                }
                                else
                                {
                                    exRpSpecialSmall.ItemDataBound += new RepeaterItemEventHandler(ExClassEvent.rpSpecialSmall_ItemDataBound);
                                    exRpSpecialSmall.DataSource = NlstSpecial;//一级以外的专题
                                    exRpSpecialSmall.DataBind();
                                }
                            }
                        }



                        #endregion

                        #region 属性
                        Control.Repeater exRpSKUList = e.Page.FindControl("rpSKUList") as Control.Repeater;
                        if (!Equals(exRpBrand, null))
                        {
                            if (lst.Count > 0)
                            {
                                foreach (var listItemModel in lst)
                                {
                                    ListItemModelEx mdc = new ListItemModelEx();
                                    mdc.Text = listItemModel.ValueName;
                                    mdc.Value = listItemModel.id.ToString();
                                    if (!ExClassEvent.CheckSku(listItemModel.id))
                                    {
                                        mdc.StyleBg = "cur";
                                    }

                                    //
                                    if (!string.IsNullOrEmpty(valusTag))
                                    {
                                        string strurl = "";
                                        // string allurl = "";
                                        string[] ary = valusTag.Split('-');
                                        for (int i = 0; i < ary.Length; i++)
                                        {
                                            string key = ary[i].Split('_')[0];
                                            if (key != mdc.Value) //不是同类 加入
                                            {
                                                strurl += key + "_" + ary[i].Split('_')[1] + "-";
                                            }
                                        }

                                        #region 对属性 "不限" 的地址设置

                                        StringBuilder iEUrl = new StringBuilder();
                                        if (Special > 0)
                                        {
                                            iEUrl.AppendFormat("&special={0}", Special);
                                        }
                                        if (Brand > 0)
                                        {
                                            iEUrl.AppendFormat("&brand={0}", Brand);
                                        }
                                        if (!string.IsNullOrEmpty(orderby))
                                        {
                                            iEUrl.AppendFormat("&orderby={0}", orderby);
                                        }
                                        if (!string.IsNullOrEmpty(strurl))
                                        {
                                            strurl = strurl.Remove(strurl.Length - 1, 1);
                                            iEUrl.AppendFormat("&valueStr={0}", strurl);

                                        }
                                        if (iEUrl.Length > 0)
                                            iEUrl = iEUrl.Remove(0, 1);
                                        if (iEUrl.Length == 0)
                                        {
                                            mdc.Url = EbSite.Base.Host.Instance.GetClassHref(e.ClassID, 1,
                                                                                             SettingInfo.Instance.GetSiteID);
                                        }
                                        else
                                        {
                                            mdc.Url = EbSite.Base.Host.Instance.GetClassHref(e.ClassID, 1, SettingInfo.Instance.GetSiteID) + "?" + iEUrl;
                                        }
                                        #endregion

                                    }
                                    else
                                    {
                                        mdc.Url = EbSite.Base.Host.Instance.GetClassHref(e.ClassID, 1, EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID);
                                    }
                                    Nlst.Add(mdc);
                                }
                            }
                            exRpSKUList.ItemDataBound += new RepeaterItemEventHandler(ExClassEvent.rpSKUList_ItemDataBound);
                            exRpSKUList.DataSource = Nlst;
                            // iCount = Nlst.Count;
                            exRpSKUList.DataBind();
                        }

                        #endregion


                        #region 手机版列表页筛选

                        #region 手机专题

                        ModuleCore.ExMobileClassPageLoadEvent MExClassEvent = new ExMobileClassPageLoadEvent(e.Context, e.ClassID);
                        //车型筛选数据[专题]
                        Control.Repeater rptBigSpecialList = e.Page.FindControl("rptMBigSpecialList") as Control.Repeater;
                        Control.Repeater rptSpecialList = e.Page.FindControl("rptMSpecialList") as Control.Repeater;
                        if (rptBigSpecialList != null && rptSpecialList != null && model.IsSpecial)
                        {
                            List<ListItemModelEx> NlstSpecial = new List<ListItemModelEx>();
                            ListItemModelEx mdspecial = new ListItemModelEx();
                            int spParentID = 0;
                            if (Special > 0)
                            {
                                // 获取某个分类下的子分类个数
                                int smallSpecialnum = EbSite.BLL.SpecialClass.GetSubCount(Special, SettingInfo.Instance.GetSiteID);
                                Entity.SpecialClass mdsp = EbSite.BLL.SpecialClass.GetModel(Special);
                                spParentID = mdsp.ParentID;
                                if (smallSpecialnum > 0)
                                {
                                    mdspecial.Text = MExClassEvent.SpecialClass(Special, spParentID, Brand, orderby, valusTag);//"车型"; 奥迪-奥迪100
                                    mdspecial.ID = Special.ToString();
                                }
                                else
                                {
                                    mdspecial.Text = MExClassEvent.SpecialClass(spParentID, spParentID, Brand, orderby, valusTag);//"车型";奥迪-奥迪100
                                    mdspecial.ID = spParentID.ToString();

                                    Entity.SpecialClass mdbigsp = EbSite.BLL.SpecialClass.GetModel(spParentID);
                                    spParentID = mdbigsp.ParentID;//父类的父类
                                }
                            }
                            mdspecial.Url = MExClassEvent.SpecialUrl(spParentID, Brand, orderby, valusTag);
                            NlstSpecial.Add(mdspecial);
                            if (Special < 0) //没有 选专题的情况
                            {
                                rptSpecialList.ItemDataBound += new RepeaterItemEventHandler(MExClassEvent.rpSpecial_ItemDataBound);
                                mdspecial.StyleBg = "cur";
                                rptSpecialList.DataSource = NlstSpecial; //一级专题
                                rptSpecialList.DataBind();
                            }
                            else
                            {
                                rptBigSpecialList.ItemDataBound += new RepeaterItemEventHandler(MExClassEvent.rpSpecialSmall_ItemDataBound);
                                rptBigSpecialList.DataSource = NlstSpecial;//一级以外的专题
                                rptBigSpecialList.DataBind();
                            }
                        }
                        #endregion

                        #region 手机 品牌
                        //绑定品牌
                        Control.Repeater rptMBrandList = e.Page.FindControl("rptMBrandList") as Control.Repeater;
                        if (rptMBrandList != null && !string.IsNullOrEmpty(model.BrandIDs))
                        {
                            List<ListItemModelEx> NlstBrand = new List<ListItemModelEx>();
                            ListItemModelEx mdbrand = new ListItemModelEx();
                            mdbrand.Text = "品牌";
                            mdbrand.Value = model.BrandIDs;


                            #region 对品牌 "不限" 的地址

                            StringBuilder iEUrl = new StringBuilder();
                            if (Special > 0)
                            {
                                iEUrl.AppendFormat("&special={0}", Special);
                            }
                            if (!string.IsNullOrEmpty(orderby))
                            {
                                iEUrl.AppendFormat("&orderby={0}", orderby);
                            }
                            if (!string.IsNullOrEmpty(valusTag))
                            {
                                iEUrl.AppendFormat("&valueStr={0}", valusTag);
                            }
                            if (iEUrl.Length > 0)
                                iEUrl = iEUrl.Remove(0, 1);
                            if (iEUrl.Length == 0)
                            {
                                mdbrand.Url = EbSite.Base.Host.Instance.MGetClassHref(e.ClassID, 1, SettingInfo.Instance.GetSiteID);
                            }
                            else
                            {
                                mdbrand.Url = EbSite.Base.Host.Instance.MGetClassHref(e.ClassID, 1, SettingInfo.Instance.GetSiteID) + "?" + iEUrl;
                            }


                            #endregion

                            if (Brand < 0)
                            {
                                mdbrand.StyleBg = "cur";
                            }
                            NlstBrand.Add(mdbrand);
                            rptMBrandList.ItemDataBound += new RepeaterItemEventHandler(MExClassEvent.rpBrand_ItemDataBound);
                            rptMBrandList.DataSource = NlstBrand;
                            rptMBrandList.DataBind();
                        }
                        #endregion

                        #region 手机商品属性

                        Control.Repeater rpMBrand = e.Page.FindControl("rpMSKUList") as Control.Repeater;
                        if (rpMBrand != null && lst.Count > 0)
                        {
                            foreach (var listItemModel in lst)
                            {
                                ListItemModelEx mdc = new ListItemModelEx();
                                mdc.Text = listItemModel.ValueName;
                                mdc.Value = listItemModel.id.ToString();
                                if (!MExClassEvent.CheckSku(listItemModel.id))
                                {
                                    mdc.StyleBg = "cur";
                                }

                                //
                                if (!string.IsNullOrEmpty(valusTag))
                                {
                                    string strurl = "";
                                    // string allurl = "";
                                    string[] ary = valusTag.Split('-');
                                    for (int i = 0; i < ary.Length; i++)
                                    {
                                        string key = ary[i].Split('_')[0];
                                        if (key != mdc.Value) //不是同类 加入
                                        {
                                            strurl += key + "_" + ary[i].Split('_')[1] + "-";
                                        }
                                    }

                                    #region 对属性 "不限" 的地址设置

                                    StringBuilder iEUrl = new StringBuilder();
                                    if (Special > 0)
                                    {
                                        iEUrl.AppendFormat("&special={0}", Special);
                                    }
                                    if (Brand > 0)
                                    {
                                        iEUrl.AppendFormat("&brand={0}", Brand);
                                    }
                                    if (!string.IsNullOrEmpty(orderby))
                                    {
                                        iEUrl.AppendFormat("&orderby={0}", orderby);
                                    }
                                    if (!string.IsNullOrEmpty(strurl))
                                    {
                                        strurl = strurl.Remove(strurl.Length - 1, 1);
                                        iEUrl.AppendFormat("&valueStr={0}", strurl);

                                    }
                                    if (iEUrl.Length > 0)
                                        iEUrl = iEUrl.Remove(0, 1);
                                    if (iEUrl.Length == 0)
                                    {
                                        mdc.Url = EbSite.Base.Host.Instance.MGetClassHref(e.ClassID, 1,
                                                                                         SettingInfo.Instance.GetSiteID);
                                    }
                                    else
                                    {
                                        mdc.Url = EbSite.Base.Host.Instance.MGetClassHref(e.ClassID, 1, SettingInfo.Instance.GetSiteID) + "?" + iEUrl;
                                    }
                                    #endregion

                                }
                                else
                                {
                                    mdc.Url = EbSite.Base.Host.Instance.MGetClassHref(e.ClassID, 1, EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID);
                                }
                                Nlst.Add(mdc);
                            }
                            rpMBrand.ItemDataBound += new RepeaterItemEventHandler(MExClassEvent.rpSKUList_ItemDataBound);
                            rpMBrand.DataSource = Nlst;
                            // iCount = Nlst.Count;
                            rpMBrand.DataBind();
                        }

                        #endregion

                        #endregion 手机版列表页筛选
                    }
                    else
                    {
                        EbSite.Base.Host.Instance.Tips("出错了", "当前分类没有设置商品类型,请到后台为此分类设置一个商品类型");

                    }
                }
            }

            #region
            //Control.Repeater rpPct = e.Page.FindControl("rpListProduct") as Control.Repeater;
            //if (!Equals(rpPct, null))
            //{
            //    HttpContext httpContext = e.Context;//e.App.Context;
            //    string requestPath = httpContext.Request.RawUrl.ToLower();
            //    //shop/12560-3-0c.ashx?brand=28&special=86&valuestr=4_29-5_34-6_37
            //    string ispecial = httpContext.Request.QueryString["special"];
            //    string ibrand = httpContext.Request.QueryString["brand"];
            //    string ivaluestr = httpContext.Request.QueryString["valuestr"];
            //    StringBuilder strWhere = new StringBuilder();
            //    StringBuilder strPageParameter = new StringBuilder();
            //    if (!string.IsNullOrEmpty(ispecial))//要查此专题下与此分类下 的NewsID的集合
            //    {
            //        strWhere.AppendFormat(" and id in(SELECT newsid	 from eb_specialnews where subclassid={0} and SpecialClassID={1}) ", e.ClassID, ispecial);
            //        strPageParameter.AppendFormat("special,{0}|", ispecial);
            //    }
            //    if (!string.IsNullOrEmpty(ibrand))//annex11 商品品牌
            //    {
            //        strWhere.AppendFormat(" and annex11={0} ", ibrand);
            //        strPageParameter.AppendFormat("brand,{0}|", ibrand);
            //    }
            //    if (!string.IsNullOrEmpty(ivaluestr))//属性 
            //    {
            //        strPageParameter.AppendFormat("valuestr,{0}|", ivaluestr);
            //        string[] arry = ivaluestr.Split('-');
            //        for (int i = 0; i < arry.Count(); i++)
            //        {
            //            string[] arryAttributes = arry[i].Split('_');
            //            strWhere.AppendFormat(
            //                " and id IN ( SELECT ProductId FROM ebshop_typerelationproduct WHERE AttributeId={0} And item={1} ) ", arryAttributes[0], arryAttributes[1]);
            //        }
            //    }
            //    //SELECT * from eb_newscontent where SiteID=3 and ClassID=12560 and annex11=26 and id IN ( SELECT ProductId FROM ebshop_typerelationproduct WHERE AttributeId=3 And item=8) and id IN ( SELECT ProductId FROM ebshop_typerelationproduct WHERE AttributeId=4 And item=29) and id in(SELECT newsid	 from eb_specialnews where subclassid=12560 and SpecialClassID=87);

            //    Control.PagesContrl pgCtr = e.Page.FindControl("pgCtr") as Control.PagesContrl;
            //    if (!Equals(pgCtr, null))
            //    {
            //        int iCount = 0;
            //        string sWhere = string.Format("classid={0} {1} ", e.ClassID, strWhere);
            //        rpPct.DataSource = EbSite.BLL.NewsContent.GetListPages(pgCtr.PageIndex, pgCtr.PageSize, sWhere, out iCount, e.SiteID);
            //        rpPct.DataBind();
            //        pgCtr.AllCount = iCount;
            //        if (strPageParameter.Length > 0)
            //        {
            //            strPageParameter = strPageParameter.Remove(strPageParameter.Length - 1, 1);
            //            pgCtr.OtherPram = strPageParameter.ToString();
            //        }
            //    }

            //}
            #endregion

        }

        private static void On_ContentPageLoadEvent(object sender, ContentPageLoadEventArgs e)
        {
            if (e.ContentID > 0)
            {
                DataSet ds = ModuleCore.BLL.ProductsImg.Instance.GetProductShowData(e.ContentID);

                //-- 产品图片
                // -- 赠品
                // -- 使用指南
                //-- 推荐配件
                //-- 最佳组合
                //-- 相同品牌
                // -- 相同 价位




                #region 图片

                Control.Repeater rpPicListEx = e.Page.FindControl("rpPicList") as Control.Repeater;
                if (!Equals(rpPicListEx, null))
                {
                    DataTable dtImg = ds.Tables[0];
                    if (dtImg != null && dtImg.Rows.Count > 0)
                    {
                        rpPicListEx.DataSource = dtImg;
                        rpPicListEx.DataBind();


                        System.Web.UI.WebControls.Image imageProduct = e.Page.FindControl("ebproductbigimg") as Image;
                        if (!Equals(imageProduct, null))
                        {
                            imageProduct.ImageUrl = dtImg.Rows[0]["BigImg"].ToString();
                        }
                    }
                }

                #endregion

                #region 促销信息

                Control.Repeater rpCuXiaoListEx = e.Page.FindControl("rpCuXiaoList") as Control.Repeater;
                if (!Equals(rpCuXiaoListEx, null))
                {
                    List<CxInfo> cList = new List<CxInfo>();
                    //买几送几,批发打折 这类与产品关联
                    List<ModuleCore.Entity.PromotionProduct> ls =
                        ModuleCore.BLL.PromotionProduct.Instance.GetListArray(string.Concat("productid=", e.ContentID));
                    if (ls.Count > 0)
                    {
                        foreach (var promotionProduct in ls)
                        {
                            CxInfo md = new CxInfo();
                            md.Url = GetLinks.Instance.ActFullQuantity(e.SiteID, promotionProduct.PromotionsID);
                            //"ctent.aspx" + promotionProduct.PromotionsID.ToString();
                            md.Title =
                                ModuleCore.BLL.Promotions.Instance.GetTitle(promotionProduct.PromotionsID.ToString());
                            if (string.IsNullOrEmpty(md.Title)) //有活动信息被删除的现象，以后可以联合查询
                                continue;
                            md.SuitUser =
                                ModuleCore.BLL.Promotions.Instance.GetRoles(promotionProduct.PromotionsID.ToString());
                            cList.Add(md);
                        }
                    }

                    //满额打折,满额免费用这类不与产品关联
                    List<ModuleCore.Entity.Promotions> ls2 =
                        ModuleCore.BLL.Promotions.Instance.GetListArray("PromoteType in(1,3)");
                    if (ls2.Count > 0)
                    {
                        foreach (var promotionse in ls2)
                        {
                            CxInfo md = new CxInfo();
                            md.Url = GetLinks.Instance.ActFullMoney(e.SiteID, promotionse.id);
                            // "ctent.aspx" + promotionse.id;
                            md.Title = promotionse.TitleName;
                            md.SuitUser = ModuleCore.BLL.Promotions.Instance.GetRoles(promotionse.id.ToString());
                            cList.Add(md);
                        }
                    }
                    if (cList.Count > 0)
                    {
                        rpCuXiaoListEx.DataSource = cList;
                        rpCuXiaoListEx.DataBind();
                    }

                }

                #endregion


                #region 促销信息 手机版

                Control.Repeater rpCuXiaoListMEx = e.Page.FindControl("rpCuXiaoListM") as Control.Repeater;
                if (!Equals(rpCuXiaoListMEx, null))
                {
                    List<CxInfo> cList = new List<CxInfo>();
                    //买几送几,批发打折 这类与产品关联
                    List<ModuleCore.Entity.PromotionProduct> ls =
                        ModuleCore.BLL.PromotionProduct.Instance.GetListArray(string.Concat("productid=", e.ContentID));
                    if (ls.Count > 0)
                    {
                        foreach (var promotionProduct in ls)
                        {
                            CxInfo md = new CxInfo();
                            md.Url = GetLinks.Instance.MActFullQuantity(e.SiteID, promotionProduct.PromotionsID);
                            //"ctent.aspx" + promotionProduct.PromotionsID.ToString();
                            md.Title =
                                ModuleCore.BLL.Promotions.Instance.GetTitle(promotionProduct.PromotionsID.ToString());
                            if (string.IsNullOrEmpty(md.Title)) //有活动信息被删除的现象，以后可以联合查询
                                continue;
                            md.SuitUser =
                                ModuleCore.BLL.Promotions.Instance.GetRoles(promotionProduct.PromotionsID.ToString());
                            cList.Add(md);
                        }
                    }

                    //满额打折,满额免费用这类不与产品关联
                    List<ModuleCore.Entity.Promotions> ls2 =
                        ModuleCore.BLL.Promotions.Instance.GetListArray("PromoteType in(1,3)");
                    if (ls2.Count > 0)
                    {
                        foreach (var promotionse in ls2)
                        {
                            CxInfo md = new CxInfo();
                            md.Url = GetLinks.Instance.ActFullMoney(e.SiteID, promotionse.id);
                            // "ctent.aspx" + promotionse.id;
                            md.Title = promotionse.TitleName;
                            md.SuitUser = ModuleCore.BLL.Promotions.Instance.GetRoles(promotionse.id.ToString());
                            cList.Add(md);
                        }
                    }
                    if (cList.Count > 0)
                    {
                        rpCuXiaoListMEx.DataSource = cList;
                        rpCuXiaoListMEx.DataBind();
                    }

                }

                #endregion


                #region 赠品

                Control.Repeater rpZengPinListEx = e.Page.FindControl("rpZengPinList") as Control.Repeater;
                if (!Equals(rpZengPinListEx, null))
                {
                    DataTable dtGift = ds.Tables[1];
                    if (dtGift != null && dtGift.Rows.Count > 0)
                    {
                        rpZengPinListEx.DataSource = dtGift;
                        rpZengPinListEx.DataBind();
                    }
                }

                #endregion

                #region 规格

                Control.Repeater rpGGListEx = e.Page.FindControl("rpGGList") as Control.Repeater;
                if (!Equals(rpGGListEx, null))
                {
                    if (e.ContentID > 0)
                    {
                        rpGGListEx.ItemDataBound += new RepeaterItemEventHandler(rpGGListEx_ItemDataBound);
                        List<ModuleCore.Entity.NormRelationProduct> lst =
                            ModuleCore.BLL.NormRelationProduct.Instance.GetListByProductID(e.ContentID);
                        if (lst.Count > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            foreach (NormRelationProduct nrp in lst)
                            {
                                sb.Append(nrp.NormsValues);
                                sb.Append("#");
                            }
                            //sAllNormkey = sb.ToString();
                            System.Web.UI.HtmlControls.HtmlInputHidden imageProduct =
                                e.Page.FindControl("hpAllNormkey") as HtmlInputHidden;
                            if (!Equals(imageProduct, null))
                            {
                                imageProduct.Value = sb.ToString();
                            }

                            StrData = ModuleCore.BLL.NormRelationProduct.Instance.GetDataListByList(lst);
                            rpGGListEx.DataSource = ModuleCore.BLL.NormRelationProduct.Instance.GetHeaderTextByList(lst);
                            rpGGListEx.DataBind();

                        }
                    }
                }

                #endregion

                #region 费用

                Control.Repeater rpListFeeOptionEx = e.Page.FindControl("rpListFeeOption") as Control.Repeater;

                if (!Equals(rpListFeeOptionEx, null))
                {
                    rpListFeeOptionEx.ItemDataBound += new RepeaterItemEventHandler(rpListFeeOption_ItemDataBound);
                    List<ModuleCore.Entity.ProductOption> ls =
                        ModuleCore.BLL.ProductOptionItems.Instance.GetListArrayByPID(e.ContentID);
                    //List<ModuleCore.Entity.ProductOptions> ls = ModuleCore.BLL.ProductOptions.Instance.GetListArray("ProductID=" + e.ContentID);
                    if (ls.Count > 0)
                    {
                        rpListFeeOptionEx.DataSource = ls;
                        rpListFeeOptionEx.DataBind();

                    }
                }


                #endregion


                #region 使用指南

                Control.Repeater rpListZhiNanEx = e.Page.FindControl("repZhiNan") as Control.Repeater;

                if (!Equals(rpListZhiNanEx, null))
                {
                    DataTable dtUserBook = ds.Tables[2];
                    if (dtUserBook != null && dtUserBook.Rows.Count > 0)
                    {
                        rpListZhiNanEx.DataSource = dtUserBook;
                        rpListZhiNanEx.DataBind();

                    }
                }

                #endregion

                #region 推荐配件

                List<CxInfo> repTagList = new List<CxInfo>();
                Control.Repeater rpListTuiJianEx = e.Page.FindControl("repTuiJian") as Control.Repeater;

                if (!Equals(rpListTuiJianEx, null))
                {
                    DataTable dtBest = ds.Tables[3];
                    if (dtBest != null && dtBest.Rows.Count > 0)
                    {
                        CxInfo md = new CxInfo();
                        md.Title = "推荐配件";
                        md.Url = "tg11";
                        repTagList.Add(md);
                        rpListTuiJianEx.DataSource = dtBest;
                        rpListTuiJianEx.DataBind();
                    }
                }

                #endregion

                #region 最佳组合

                Control.Repeater rpListBestGroupEx = e.Page.FindControl("repBestGroup") as Control.Repeater;

                if (!Equals(rpListBestGroupEx, null))
                {
                    DataTable dtBG = ds.Tables[4];
                    if (dtBG != null && dtBG.Rows.Count > 0)
                    {
                        CxInfo md = new CxInfo();
                        md.Title = "最佳组合";
                        md.Url = "tg12";
                        repTagList.Add(md);
                        rpListBestGroupEx.DataSource = dtBG;
                        rpListBestGroupEx.DataBind();
                    }
                }

                #endregion


                #region 推荐配件 最佳组合 头部

                Control.Repeater repTagEx = e.Page.FindControl("repTag") as Control.Repeater;
                if (!Equals(repTagEx, null))
                {
                    if (repTagList.Count > 0)
                    {
                        repTagEx.DataSource = repTagList;
                        repTagEx.DataBind();
                    }
                }

                #endregion

                #region 相同品牌

                Control.Repeater rpListSameBrandEx = e.Page.FindControl("repSameBrand") as Control.Repeater;

                if (!Equals(rpListSameBrandEx, null))
                {
                    DataTable dtCame = ds.Tables[5];
                    if (dtCame != null && dtCame.Rows.Count > 0)
                    {
                        rpListSameBrandEx.DataSource = dtCame;
                        rpListSameBrandEx.DataBind();
                    }
                }

                #endregion

                #region  浏览了该商品用户还浏览了

                Control.Repeater rpListGoodsVisiteEx = e.Page.FindControl("repGoodsVisite") as Control.Repeater;

                if (!Equals(rpListGoodsVisiteEx, null))
                {
                    //SELECT * from eb_goods_visite where UserID in(SELECT UserID from eb_goods_visite where ContentID=346) ORDER BY NumTime desc LIMIT 6;
                    List<Entity.goods_visite> ls = EbSite.BLL.goods_visite.Instance.ListByProductID(6,
                                                                                                    string.Concat(
                                                                                                        " a.ClassID=",
                                                                                                        e.ClassID,
                                                                                                        " and  a.ContentID!=",
                                                                                                        e.ContentID,
                                                                                                        " and  a.UserID in(SELECT UserID from eb_goods_visite where ContentID=",
                                                                                                        e.ContentID," and ClassID=",e.ClassID,
                                                                                                        " order by numtime desc",
                                                                                                        ")"),
                                                                                                    " count desc",e.ClassID);
                    //  List<Entity.goods_visite> ls = EbSite.BLL.goods_visite.Instance.ListByProductID(6, string.Concat("b.Annex25=1 and a.ContentID!=", e.ContentID, " and  a.UserID in(SELECT UserID from eb_goods_visite where ContentID=", e.ContentID, " order by numtime desc", ")"), " count desc");
                    if (ls.Count > 0)
                    {
                        rpListGoodsVisiteEx.DataSource = ls;
                        rpListGoodsVisiteEx.DataBind();
                    }
                }

                #endregion


                #region 相同 价位

                Control.Repeater rpListSamePriceEx = e.Page.FindControl("repSamePrice") as Control.Repeater;

                if (!Equals(rpListSameBrandEx, null))
                {
                    DataTable dtPrice = ds.Tables[6];

                    if (dtPrice != null && dtPrice.Rows.Count > 0)
                    {
                        rpListSamePriceEx.DataSource = dtPrice;
                        rpListSamePriceEx.DataBind();
                    }
                }

                #endregion


                #region 规格属性参数

                Control.Repeater rpListGGParameterEx = e.Page.FindControl("rpListGGParameter") as Control.Repeater;

                if (!Equals(rpListGGParameterEx, null))
                {
                    List<ModuleCore.Entity.TypeRelationProduct> lst =
                        ModuleCore.BLL.TypeRelationProduct.Instance.GetListArrayCache(0, string.Concat("item>0 and ProductID=", e.ContentID, " GROUP BY attributeId"), "");
                    if (lst.Count > 0)
                    {
                        rpListGGParameterEx.DataSource = lst;
                        rpListGGParameterEx.DataBind();
                    }
                    //DataTable dtTRP = ds.Tables[7];
                    //if (dtTRP!=null&&dtTRP.Rows.Count>0)
                    //{
                    //    rpListGGParameterEx.DataSource = dtTRP;
                    //    rpListGGParameterEx.DataBind();
                    //}
                }

                #endregion

                #region 适用车型

                System.Web.UI.WebControls.Label suitcar = e.Page.FindControl("suitcar") as Label;
                if (!Equals(suitcar, null))
                {
                    StringBuilder sSpecial = new StringBuilder();
                    List<Entity.SpecialNews> lsSpecial = EbSite.BLL.SpecialNews.GetListArry("NewsID=" + e.ContentID);
                    if (lsSpecial.Count > 0)
                    {
                        foreach (var specialNewse in lsSpecial)
                        {
                            EbSite.Entity.SpecialClass md =
                                EbSite.BLL.SpecialClass.GetModelByCache(specialNewse.SpecialClassID);

                            sSpecial.AppendFormat("<a href='{0}'>{1}</a>  ",
                                                  EbSite.Base.Host.Instance.GetSpecialHref(specialNewse.SpecialClassID,
                                                                                           1), md.SpecialName);
                        }
                    }
                    suitcar.Text = sSpecial.ToString();
                }

                #endregion
            }
        }
        #region 费用
        private static void rpListFeeOption_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //ModuleCore.Entity.ProductOptions drData = (ModuleCore.Entity.ProductOptions)e.Item.DataItem;
                ModuleCore.Entity.ProductOption drData = (ModuleCore.Entity.ProductOption)e.Item.DataItem;
                if (!Equals(drData, null))
                {
                    //提取分类ID 
                    string strClassID = Convert.ToString(drData.id);
                    if (!string.IsNullOrEmpty(strClassID))
                    {
                        Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");

                        //llClassList.DataSource = GetDataSub(strClassID);
                        llClassList.DataSource = drData.ProductItems;
                        llClassList.DataBind();
                    }
                }


            }
        }

        private static List<ModuleCore.Entity.ProductOptionItems> GetDataSub(string strClassID)
        {
            //string CacheKey = string.Concat("BeiMaiBandGetDataSub", strClassID);
            //List<ModuleCore.Entity.ProductOptionItems> dl = EbSite.Base.Host.CacheApp.GetCacheItem(CacheKey) as List<ModuleCore.Entity.ProductOptionItems>;
            //if (dl == null)
            //{
            //    dl = ModuleCore.BLL.ProductOptionItems.Instance.GetListArray("ProductOptionID=" + strClassID);
            //    Base.Host.CacheApp.AddCacheItem(CacheKey, dl);
            //}
            List<ModuleCore.Entity.ProductOptionItems> dl = ModuleCore.BLL.ProductOptionItems.Instance.GetListArray("ProductOptionID=" + strClassID);
            return dl;
        }

        #endregion

        #region 规格
        private static List<ChildTemp> StrData = new List<ChildTemp>();
        // protected static string sAllNormkey;

        public static void rpGGListEx_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                EbSite.Base.EntityAPI.ListItemModel drData = (Base.EntityAPI.ListItemModel)e.Item.DataItem;
                //提取分类ID 
                string strClassID = drData.ID;
                if (!string.IsNullOrEmpty(strClassID))
                {
                    Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");

                    llClassList.DataSource = GetSkuBind(int.Parse(strClassID), false);
                    llClassList.DataBind();


                    Repeater llSkuPicList = (Repeater)e.Item.Controls[0].FindControl("rpSubPicList");

                    llSkuPicList.DataSource = GetSkuBind(int.Parse(strClassID), true);
                    llSkuPicList.DataBind();
                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isPicTemp">规格 后台 repeater LoadTemplete 加载没成功，前台 if 也失败了。固分成两个数据源</param>
        /// <returns></returns>
        public static List<SkuInfo> GetSkuBind(int id, bool isPicTemp)
        {
            bool ispicT = false;//是否是 图片模板
            //List<Base.EntityAPI.ListItemModel> nls = new List<Base.EntityAPI.ListItemModel>();
            List<SkuInfo> nls = new List<SkuInfo>();
            var xls = (from i in StrData where i.pid == id select i.id).Distinct().ToList();//所有的规格 里面有重复的 要过滤

            foreach (var childTemp in xls)
            {
                //EbSite.Base.EntityAPI.ListItemModel md = new Base.EntityAPI.ListItemModel();
                SkuInfo md = new SkuInfo();
                ModuleCore.Entity.NormsValue model = ModuleCore.BLL.NormsValue.Instance.GetEntity(childTemp);
                if (!Equals(model, null))
                {
                    if (!string.IsNullOrEmpty(model.NormsIco)) //图片
                    {
                        md.ID = childTemp.ToString();
                        md.Value = id.ToString(); //这是父ID
                        md.AltText = model.NormsValueName;
                        md.Text = model.NormsIco;
                        if (isPicTemp)
                            nls.Add(md);
                    }
                    else
                    {
                        md.ID = childTemp.ToString();
                        md.Value = id.ToString(); //这是父ID
                        md.AltText = model.NormsValueName;
                        md.Text = model.NormsValueName;
                        if (!isPicTemp)
                            nls.Add(md);
                    }
                }

            }

            return nls;
        }
        #endregion
    }
    /// <summary>
    /// 促销信息
    /// </summary>
    public class CxInfo
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 销促标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 适用人群
        /// </summary>
        public string SuitUser { get; set; }
    }
    /// <summary>
    /// 规格
    /// </summary>
    public class SkuInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 这是父ID
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string AltText { get; set; }
        /// <summary>
        /// 文字或图片路径
        /// </summary>
        public string Text { get; set; }


    }

}