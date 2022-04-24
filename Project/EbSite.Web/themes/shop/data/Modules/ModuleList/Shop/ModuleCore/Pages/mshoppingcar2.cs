using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using EbSite.Base.Json;
using EbSite.Base.Page;
using EbSite.Entity;
using EbSite.Modules.Shop.ModuleCore.Cart;
using EbSite.Modules.Shop.ModuleCore.Ctrls;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mshoppingcar2 : MshoppingcarBase
    {
        #region 控件定义
       
        protected global::System.Web.UI.WebControls.Repeater rpAddress;
        protected global::System.Web.UI.WebControls.Repeater rpOrderOptions;
        protected global::System.Web.UI.WebControls.Repeater rpPeiSong;
        
        protected global::System.Web.UI.WebControls.Button btnSaveOrder;

        protected global::System.Web.UI.HtmlControls.HtmlInputHidden optionitemids;

        protected global::System.Web.UI.WebControls.Repeater rpTicket;

        protected global::System.Web.UI.WebControls.PlaceHolder phPayOffline;

        

        #endregion
       
        protected void Page_Load(object sender, EventArgs e)
        {
          
            Page.Title = "核实订单";
            
            if (!IsPostBack)
            {
                //验证用户是否登录
                if (EbSite.Base.Host.Instance.UserID < 0)
                {
                    base.CheckCurrentUserIsLogin();
                   // Response.Redirect(EbSite.Base.Host.Instance.LoginRw+"?ru="+ Server.UrlEncode(Request.RawUrl));// 加上 要定向的地址 yhl
                }
                else
                {
                    //更新用户访问信息，如在线信息,主要应用匿名购买的时候生成ID
                    //EbSite.BLL.User.UserOnline.CheckUserOnline();
                    //BindOrderOptions();
                    BindPeiSong();
                    BinAddress();
                    //BindTicket();
                    if (TotalCount < 1)
                    {
                        Tips("请先选择商品", "购物车里还没有可以结算的商品，请先选择商品！");
                        return;
                    }

                    EbSite.Entity.PayPass payModel =
                        EbSite.BLL.PayPass.Instance.GetEntityByUserID(EbSite.Base.Host.Instance.UserID);
                    if (!Equals(payModel, null))
                    {
                        Balance = payModel.Balance - payModel.RequestBalance; //账户可以使用的金额
                        if(!string.IsNullOrEmpty(payModel.Pass))
                        {
                            IsOpenBlance = true;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(Request["gid"]))
            {
                phPayOffline.Visible = false;
            }

        }


        protected void BinAddress()
        {
            rpAddress.DataSource = EbSite.BLL.Address.Instance.GetListByUserID(UserID);
            rpAddress.DataBind();
        }
        protected void BindOrderOptions()
        {
            //if (!Equals(rpOrderOptions, null))
            //{
            //    rpOrderOptions.ItemDataBound += new RepeaterItemEventHandler(rpOrderOptions_ItemDataBound);
            //    rpOrderOptions.DataSource = EbSite.BLL.OrderOptions.Instance.GetListArray("");
            //    rpOrderOptions.DataBind();
            //}

        }
        //private void BindPayment()
        //{
        //    rpPayment.DataSource = EbSite.BLL.Payment.Instance.GetListArray(0, "OrderNumber");
        //    rpPayment.DataBind();
            
        //}
        protected void BindPeiSong()
        {
            rpPeiSong.DataSource = EbSite.BLL.PsDelivery.Instance.FillList();
            rpPeiSong.DataBind();
            
        }
        
        protected void rpOrderOptions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                EbSite.Entity.OrderOptions drv = e.Item.DataItem as EbSite.Entity.OrderOptions;
                if (!Equals(drv,null))
                {
                    ModuleCore.Ctrls.OrderOptions optionitems = e.Item.FindControl("optionitems") as Ctrls.OrderOptions;
                    if(!Equals(optionitems,null))
                    {
                        if (drv.SelectMode == 1)
                            optionitems.ST =  ShowType.列表选择;
                        else
                        {
                            optionitems.ST = ShowType.下拉列表;
                        }
                        List<EbSite.Entity.OrderOptionItems> lst =EbSite.BLL.OrderOptionItems.Instance.GetListByOrderOptionID(drv.id);
                        optionitems.CtrClientID = string.Concat("opi", drv.id);
                        optionitems.Datasource = lst;
                        optionitemids.Value = string.Concat(optionitemids.Value,"_",optionitems.CtrClientID);
                        Repeater rpUserInput = e.Item.FindControl("rpUserInput") as Repeater;
                        if (!Equals(rpUserInput, null))
                        {
                            List<EbSite.Entity.OrderOptionItems> lstInput = new List<OrderOptionItems>();

                            foreach (OrderOptionItems orderOptionItemse in lst)
                            {
                                if(orderOptionItemse.IsUserInputRequired)
                                    lstInput.Add(orderOptionItemse);
                            }

                            rpUserInput.DataSource = lstInput;
                            rpUserInput.DataBind();
                        }

                    }
                    
                
                }

            }

        }

        protected void BindTicket()
        {
            if (!Equals(rpTicket, null))
            {
                //绑定优惠券
                List<EbSite.Entity.CouponItems> lsTicket =
                    EbSite.BLL.CouponItems.Instance.GetListArray("'status'=0 and  userid=" + base.UserID);
                List<EbSite.Entity.CouponItems> NlsTicket = new List<CouponItems>();
                if (lsTicket.Count > 0)
                {
                    foreach (var couponItemse in lsTicket)
                    {
                        EbSite.Entity.Coupons model =
                            EbSite.BLL.Coupons.Instance.GetEntity(Convert.ToInt32(couponItemse.CouponId));
                        if (model.Amount <= TotalMoney && model.EndDateTime > DateTime.Now)
                        {
                            NlsTicket.Add(couponItemse);
                        }
                    }
                }
                this.rpTicket.DataSource = NlsTicket;
                this.rpTicket.DataBind();
            }
        }

        ///// <summary>
        ///// Bind repeater to Cart object in Profile
        ///// </summary>
        //private void BindCart(ProfileCommon profile)
        //{
        //    //ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
        //    ICollection<ModuleCore.Entity.Buy_OrderItem> cart = profile.ShopCart.CartItems;
        //    if (cart.Count > 0)
        //    {
        //        repShoppingCart.DataSource = cart;
        //        repShoppingCart.DataBind();

        //        if (profile.ShopCart.CartItems.Count > 0)
        //        {
        //            ltlCount.Text = profile.ShopCart.Count.ToString();
        //            ltlTotal.Text = profile.ShopCart.TotalMember.ToString();
        //        }

        //        TotalWeight = profile.ShopCart.TotalWeight;
        //        TotalMoney = profile.ShopCart.TotalMember;


               
        //    }
        //    else
        //    {
        //        repShoppingCart.Visible = false;

        //    }

        //}


        #region 解决重写url后，保持postback地址不改变的问题

        //// <summary>
        ///  重写默认的HtmlTextWriter方法，修改form标记中的value属性，使其值为重写的URL而不是真实URL。
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (writer is System.Web.UI.Html32TextWriter)
            {
                writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
            }
            else
            {
                writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
            }

            base.Render(writer);
        }
        #endregion
    }
}