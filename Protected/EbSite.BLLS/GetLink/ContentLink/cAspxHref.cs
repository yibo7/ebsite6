using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.ContentLink
{
    public class cAspxHref : IBase, ILinkContent
    {
        public cAspxHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        public string GetContentLink(object iId, object HtmlPath, object cid, object PageIndex)
        {
            return string.Concat(IISPath, ContentLink, "?id=", iId, "&site=", SiteID, "&cid=", cid, "&pi=", PageIndex);
        }
        public string GetContentLink(object iId, object cid, object PageIndex)
        {
            return string.Concat(IISPath, ContentLink, "?id=", iId, "&site=", SiteID, "&cid=", cid, "&pi=", PageIndex);
        }

        //public string GetContentLink(object iId, Guid ModelID)
        //{
        //    return string.Concat(IISPath, ContentLink, "?id=", iId, "&site=", SiteID, "&modelid=", ModelID);
        //}

        public string GetContentLink(object iID)
        {
            return string.Concat(IISPath, ContentLink, "?id=", iID, "&site=", SiteID);
        }
    }
}
