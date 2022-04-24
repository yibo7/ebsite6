using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;
using EbSite.Core.HttpModules;

namespace EbSite.BLL.GetLink.SpecialLink
{
    public class cAutoHtmlHref : cReWriteHref
    {
        public cAutoHtmlHref(int _SiteID) : base(_SiteID)
        {
            this.SiteID = _SiteID;
        }
        //public  string GetSpecialHref(int iid, int index)
        //{
        //    if (UrlRules.SpecialRuleHtmlNames2.ContainsKey(iid))
        //    {
        //        return UrlRules.SpecialRuleHtmlNames2[iid];
        //    }
        //    return string.Concat(SiteFolder, iid, "-", index, SpecialLinkRw);
        //}
    }
}
