using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.ContentLink
{
    public class cAutoHtmlHref : cReWriteHref
    {
        public cAutoHtmlHref(int _SiteID):base(_SiteID)
        {
            this.SiteID = _SiteID;
        }
        //public string GetContentLink(object iId, object HtmlPath, object cid, object PageIndex)
        //{
        //    return string.Concat(SiteFolder, cid, "-", iId, "-", PageIndex, ContentLinkRw);
        //}
        //public string GetContentLink(object iId, object cid, object PageIndex)
        //{
        //    return string.Concat(SiteFolder, cid, "-", iId, "-", PageIndex, ContentLinkRw);
        //}
        //public string GetContentLink(object iID)
        //{
        //    return string.Concat(SiteFolder, iID, ContentLinkRw);
        //}
        //public string GetContentLink(object iId, Guid ModelID)
        //{
        //    throw new  NotImplementedException();
        //}
    }
}
