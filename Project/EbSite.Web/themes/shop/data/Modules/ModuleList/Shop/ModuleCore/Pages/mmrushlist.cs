using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Modules.Shop.ModuleCore.Cart;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mmrushlist : mrushlist
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
        override  protected void BindPages()
        {
            if (!Equals(pgCtr, null))
            {
                pgCtr.ReWritePatchUrl = ShopLinkApi.MRushListSplitPage(GetSiteID, ClassID);
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize =base.iPageSize;
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }
        }
    }
}