using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Modules.Shop.ModuleCore.BLL.GRShow;
using EbSite.Modules.Shop.ModuleCore.Cart;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mrushshow : GRShowBase
    {

        override protected BLL.GRShow.IBase Bll
        {
            get
            {
                return new Rush();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = string.Concat("[限时抢购]", ModelG.Title);

        }
        protected string GetNav(string Nav)
        {
            return string.Format("<a href='{0}'>{1}</a>{2}<a href='{3}'>限时抢购</a>{2}<a href='{4}'>{5}</a>", HostApi.GetMainIndexHref(GetSiteID), SiteName, Nav, ShopLinkApi.RushList(GetSiteID), ShopLinkApi.RushShow(GetSiteID, GroupId, ProductID), ModelG.Title);

        }
       
    }
}