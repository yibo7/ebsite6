using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EbSite.Base.Page;
using EbSite.Control;
using EbSite.Modules.Shop.ModuleCore.Cart;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class jifen : BasePageM
    {

        protected global::EbSite.Control.Repeater ScoreRep;
        protected global::EbSite.Control.Repeater RepClass;
        private Entity.creditproductclass mdClass = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "积分商城";
            ScoreBind();
            ScoreClassBind();
            
        }
        private void ScoreClassBind()
        {
            List<Entity.creditproductclass> ls = ModuleCore.BLL.creditproductclass.Instance.GetListArrayCache(0, "", "");
            RepClass.DataSource = ls;
            RepClass.DataBind();
        }

        private void ScoreBind()
        {
            string strsq = "";//" IsSaling=1 and Stock>0";
            if (ClassID > 0)
            {
                strsq = string.Concat(" ClassID=" , ClassID);

                mdClass = ModuleCore.BLL.creditproductclass.Instance.GetEntity(ClassID);
            }
            List<Entity.creditproduct> ls = ModuleCore.BLL.creditproduct.Instance.GetListArrayCache(0, strsq, "");
            ScoreRep.DataSource = ls;
            ScoreRep.DataBind();
        }
        private int ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                else
                {

                    return -1;
                }
            }
        }

        protected string GetNav(string Nav)
        {
            if (ClassID > 0)
            {
                return string.Format("<a href='{0}'>{1}</a>{2}<a href='{3}'>积分商城</a>{2}<a href='{4}'>{5}</a>", HostApi.GetMainIndexHref(GetSiteID), SiteName, Nav, ShopLinkApi.JiFen(GetSiteID), ShopLinkApi.JiFen(GetSiteID, mdClass.id), mdClass.ClassName);
            }
            else
            {
                return string.Format("<a href='{0}'>{1}</a>{2}<a href='{3}'>积分商城</a>", HostApi.GetMainIndexHref(GetSiteID), SiteName, Nav, ShopLinkApi.JiFen(GetSiteID));
                
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