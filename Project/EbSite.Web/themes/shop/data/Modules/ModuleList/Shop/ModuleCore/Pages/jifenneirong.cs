using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EbSite.Base.Page;
using EbSite.Modules.Shop.ModuleCore.Cart;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class jifenneirong : BasePageM
    {

        protected ModuleCore.Entity.creditproduct Model = new creditproduct();

        protected global::EbSite.Control.Repeater RepHits;
        /// <summary>
        /// 积分 商品ID
        /// </summary>
        protected  int ProductID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["pid"]))
                {
                    return int.Parse(Request["pid"]);
                }
                else
                {

                    return -1;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Model = ModuleCore.BLL.creditproduct.Instance.GetEntity(ProductID);
            Page.Title = Model.SeoTitle;
            Page.MetaKeywords = Model.SeoKeyWord;
            Page.MetaDescription = Model.SeoDes;
            ExchangNumBind();
        }
        private void ExchangNumBind()
        {
            if (!Equals(RepHits, null))
            {
                List<Entity.creditproduct> ls = ModuleCore.BLL.creditproduct.Instance.GetListArrayCache(6,
                                                                                                        "IsSaling=1 and Stock>0 ",
                                                                                                        "ExchangeNum desc");
                RepHits.DataSource = ls;
                RepHits.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            

        }

        protected string GetNav(string Nav)
        {
            return string.Format("<a href='{0}'>{1}</a>{2}<a href='{3}'>积分商城</a>{2}<a href='{4}'>{5}</a>", HostApi.GetMainIndexHref(GetSiteID), SiteName, Nav, ShopLinkApi.JiFen(GetSiteID), ShopLinkApi.JiFenShow(GetSiteID, Model.id), Model.ProductName);

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