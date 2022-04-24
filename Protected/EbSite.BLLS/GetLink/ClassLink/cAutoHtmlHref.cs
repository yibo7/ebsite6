using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.ClassLink
{
    public class cAutoHtmlHref : cReWriteHref
    {
        public cAutoHtmlHref(int _SiteID):base(_SiteID)
        {
            this.SiteID = _SiteID;
        }

        //public string GetClassHref(object iId, object HtmlPath, int pIndex)
        //{
        //    return string.Concat(SiteFolder, iId, "-", pIndex, "-0", ClassLinkRw);
        //}
        //public string GetClassHref(object iId, object HtmlPath, int pIndex, string OutLink)
        //{
        //    if (string.IsNullOrEmpty(OutLink))
        //    {
        //        return GetClassHref(iId, HtmlPath, pIndex);
        //    }
        //    else
        //    {
        //        return OutLink;
        //    }

        //}
        //public string GetClassHref(int iId, int Index)
        //{
        //    return string.Concat(SiteFolder, iId, "-", Index, "-0", ClassLinkRw);
        //}
        //public string GetClassHref_OrderBy(int iId, int Index, int OrderBy)
        //{
        //    return string.Concat(SiteFolder, iId, "-", Index, "-", OrderBy, ClassLinkRw);
        //}
        //public string GetAllClassHref()
        //{
        //    return string.Concat(SiteFolder, ClassLinkAllRw);
        //}

    }
}
