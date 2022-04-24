using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.EntityAPI;
using EbSite.Base.Json;
using EbSite.Base.Page;
using EbSite.Entity;

using System.Text;
using EbSite.Modules.Shop.ModuleCore.BLL;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class orderprint : BasePageM
    {
        protected global::System.Web.UI.WebControls.Literal litOrderNum;
        protected global::System.Web.UI.WebControls.Literal litAddDate;
        protected global::System.Web.UI.WebControls.Literal litCustomName;
        protected global::System.Web.UI.WebControls.Literal litPhoneNum;
        protected global::System.Web.UI.WebControls.Literal litAddress;
        protected global::System.Web.UI.WebControls.Repeater rptItemList;
        protected global::System.Web.UI.WebControls.Repeater RepCredits;
        protected global::System.Web.UI.WebControls.Literal litGoodsPrice;
        protected global::System.Web.UI.WebControls.Literal litPayPrice;
        protected void Page_Load(object sender, EventArgs e)
        {
            string orderID = Request.QueryString["oid"];
            int iUserID = base.UserID;
            if (iUserID < 0)
            {
                Response.Redirect(EbSite.Base.Host.Instance.LoginRw);
            }

            if (!string.IsNullOrEmpty(orderID))
            {
                ModuleCore.Entity.Buy_Orders order = ModuleCore.BLL.Buy_Orders.Instance.GetEntity(int.Parse(orderID));
                if (order != null)
                {
                    this.litOrderNum.Text = order.OrderId.ToString();
                    this.litAddDate.Text = order.OrderAddDate.ToString();
                    this.litCustomName.Text = order.SendToUserName;
                    this.litPhoneNum.Text = order.CellPhone;
                    this.litAddress.Text = order.Address;
                    this.litGoodsPrice.Text = string.Format("{0}元 + 运费：{1}元 - 优惠：{2}元 + 支付手续费：{3}元 + 订单选项费用：{4}元", order.Amount, order.Freight, order.DiscountAmount, order.PayFree, order.OptionPrice);
                    this.litPayPrice.Text = order.OrderTotal.ToString();

                    List<ModuleCore.Entity.Buy_OrderItem> ls = ModuleCore.BLL.Buy_OrderItem.Instance.GetListArray("orderid=" + order.OrderId);
                    if (ls != null && ls.Count > 0)
                    {
                        this.rptItemList.DataSource = ls;
                        this.rptItemList.DataBind();
                    }
                    //
                    //加载积分 兑换商品列表
                    List<ModuleCore.Entity.creditproductorder> creditList = ModuleCore.BLL.creditproductorder.Instance.GetListArray(string.Format("a.orderid=\"{0}\"", order.OrderId));
                    if (creditList != null && creditList.Count > 0)
                    {
                        this.RepCredits.DataSource = creditList;
                        this.RepCredits.DataBind();
                    }
                }
            }
        }

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