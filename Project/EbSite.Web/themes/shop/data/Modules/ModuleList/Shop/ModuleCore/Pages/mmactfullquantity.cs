using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Modules.Shop.ModuleCore.Cart;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mmactfullquantity : mactfullquantity
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
        override protected void BindPage()
        {
            if (!Equals(pgCtr, null))
            {
                pgCtr.ReWritePatchUrl = ShopLinkApi.MActFullQuantitySplitPage(GetSiteID, ActivitieID);// string.Concat(GetClassID, "-{0}-", OrderBy, HostApi.ClassLinkRw(GetSiteID)); //{0} 页码
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }
        }
    }
}