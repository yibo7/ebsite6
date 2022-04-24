using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.TagsLink
{
    public class cAspxHref : IBase, ILinkTags
    {
        public cAspxHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        public  string TagsList(int p)
        {
            return string.Concat(TaglistLink, "?p=", p, "&site=", SiteID);
        }
        public  string TagsList(int p, int OrderBy)
        {
            return string.Concat(TaglistLink, "?p=", p, "&odb=", OrderBy, "&site=", SiteID);
        }
        public  string TagsSearchList(object id, int p)
        {
            return string.Concat(TagsSearchListLink, "?tid=", id, "&p=", p, "&site=", SiteID);
        }
    }
}
