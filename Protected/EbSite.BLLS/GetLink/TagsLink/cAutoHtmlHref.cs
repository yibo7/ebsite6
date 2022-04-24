using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.TagsLink
{
    public class cAutoHtmlHref : IBase, ILinkTags
    {
        public cAutoHtmlHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        public  string TagsList(int p)
        {
            return string.Concat(SiteFolder, p, TaglistLinkRw);
        }
        public  string TagsList(int p, int OrderBy)
        {
            return string.Concat(SiteFolder, p, "-", OrderBy, TaglistLinkRw);
        }
        public  string TagsSearchList(object id, int p)
        {
            return string.Concat(SiteFolder, id, "-", p, TagsSearchListLinkRw);
        }
    }
}
