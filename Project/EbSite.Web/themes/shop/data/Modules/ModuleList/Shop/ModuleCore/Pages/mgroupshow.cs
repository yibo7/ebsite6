using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EbSite.Modules.Shop.ModuleCore.BLL;
using EbSite.Modules.Shop.ModuleCore.BLL.GRShow;
using EbSite.Modules.Shop.ModuleCore.Cart;
using NormRelationProduct = EbSite.Modules.Shop.ModuleCore.Entity.NormRelationProduct;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mgroupshow : GRShowBase
    {
        override protected BLL.GRShow.IBase Bll { 
            get
            {
                return  new Group();
            }   
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Title = string.Concat("[团购]",ModelG.Title);
            

        }

        protected string GetNav(string Nav)
        {
            return string.Format("<a href='{0}'>{1}</a>{2}<a href='{3}'>团购</a>{2}<a href='{4}'>{5}</a>", HostApi.GetMainIndexHref(GetSiteID), SiteName, Nav, ShopLinkApi.GroupList(GetSiteID), ShopLinkApi.GroupShow(GetSiteID, GroupId, ProductID), ModelG.Title);

        }
    }
}