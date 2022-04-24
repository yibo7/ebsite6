using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;

namespace EbSite.Web.Pages
{
    public partial class Delivery : CustomPage
    {
        #region 控件定义
        protected global::System.Web.UI.WebControls.Label lbOtheradress;
        /// <summary>
        /// repShoppingCart control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Repeater repShoppingCart;
        protected global::System.Web.UI.WebControls.Repeater rpOrderOptions;
        protected global::System.Web.UI.WebControls.Repeater rpPayment;
        protected global::System.Web.UI.WebControls.Repeater rpPeiSong;

        /// <summary>
        /// ltlCount control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal ltlCount;

        /// <summary>
        /// ltlTotal control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal ltlTotal;


        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
           
            Response.Buffer = true;
            //Response.ExpiresAbsolute = DateTime.Now();
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            base.Title = "填写核对定单信息";
            if (!IsPostBack)
            {
                
                if (UserID > 0)
                {
                    lbOtheradress.Visible = true;
                }
                else
                {
                    lbOtheradress.Visible = false;
                }

                //BindCart();
                //BindOrderOptions();
                //BindPayment();
                //BindPeiSong();

            }
        }


        ///// <summary>
        ///// Bind repeater to Cart object in Profile
        ///// </summary>
        //private void BindCart()
        //{
        //    ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
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

        //    }
        //    else
        //    {
        //        repShoppingCart.Visible = false;

        //    }

        //}

        //private void BindOrderOptions()
        //{
        //    rpOrderOptions.ItemDataBound += new RepeaterItemEventHandler(rpOrderOptions_ItemDataBound);
        //    rpOrderOptions.DataSource = ModuleCore.BLL.OrderOptions.Instance.GetListArray("");
        //    rpOrderOptions.DataBind();

        //}
        //private void BindPayment()
        //{
        //    rpPayment.DataSource = EbSite.BLL.Payment.Instance.GetListArray(0, "OrderNumber");
        //    rpPayment.DataBind();

        //}
        //private void BindPeiSong()
        //{
        //    rpPeiSong.DataSource = EbSite.BLL.PsDelivery.Instance.FillList();
        //    rpPeiSong.DataBind();

        //}

        //protected void rpOrderOptions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{

        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {

        //        Entity.OrderOptions drv = e.Item.DataItem as Entity.OrderOptions;
        //        if (!Equals(drv, null))
        //        {
        //            ModuleCore.Ctrls.OrderOptions optionitems = e.Item.FindControl("optionitems") as Ctrls.OrderOptions;
        //            if (!Equals(optionitems, null))
        //            {
        //                if (drv.SelectMode == 1)
        //                    optionitems.ST = ShowType.下拉列表;
        //                else
        //                {
        //                    optionitems.ST = ShowType.列表选择;
        //                }
        //                optionitems.BindData(BLL.OrderOptionItems.Instance.GetListByOrderOptionID(drv.id));
        //            }
        //        }

        //        //string downName = drv["downName"].ToString();

        //        //if (downName == null || downName == String.Empty)

        //        //    ((Panel)(e.Item.FindControl("Panel1"))).Visible = false;

        //    }

        //}


    }
}