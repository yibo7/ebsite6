using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.ClassLink
{
    public class cAspxHref : IBase, ILinkClass
    {
        public cAspxHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        public string GetClassHref(object iId, object HtmlPath, int pIndex)
        {
            return string.Concat(IISPath, ClassLink, "?cid=", iId, "&p=", pIndex, "&site=", SiteID);
        }
        public string GetClassHref(object iId, object HtmlPath, int pIndex, string OutLink)
        {
            if (string.IsNullOrEmpty(OutLink))
            {
                return GetClassHref(iId, HtmlPath, pIndex);
            }
            else
            {
                return OutLink;
            }

        }

        public string GetClassHref_OrderBy(int iId, int Index, int OrderBy)
        {
            return string.Concat(IISPath, ClassLink, "?cid=", iId, "&p=", Index, "&odb=", OrderBy, "&site=", SiteID);
        }

        public string GetClassHref(int iId, int Index)
        {
            return string.Concat(IISPath, ClassLink, "?cid=", iId, "&p=", Index, "&site=", SiteID);
        }
        public string GetAllClassHref()
        {
            return string.Concat(IISPath, ClassLinkAll, "?site=", SiteID);
        }
    }
}
