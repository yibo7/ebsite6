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
    public class mmgroupshow : mgroupshow
    {
        protected override void AddHeaderPram()
        {
            base.MobileAddHeaderPram();

        }

        protected override void InitStyle()
        {
            base.MobileInitStyle();
        }
        protected string MTitle
        {
            get
            {
                return SiteName;
            }
        }
    }
}