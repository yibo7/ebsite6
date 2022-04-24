using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;
using EbSite.Core.HttpModules;

namespace EbSite.BLL.GetLink.ContentLink
{
    public class cReWriteHref : IBase, ILinkContent
    {
        public cReWriteHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        public string GetContentLink(object iId, object HtmlPath, object cid, object PageIndex)
        {
            return GetContentLink(iId, cid, PageIndex);
        }
        public string GetContentLink(object iId, object cid, object PageIndex)
        {
            //long iContentId = Core.Utils.ObjectToLong(iId, 0);

            //if (UrlRules.ContentRuleHtmlNames2.ContainsKey(iContentId))
            //{
            //    return UrlRules.ContentRuleHtmlNames2[iContentId];
            //}

            int classid = Core.Utils.ObjectToInt(cid, 0);


            if (UrlRules.ClassRuleHtmlNameForContentPre2.ContainsKey(classid))
            {
                return string.Concat(UrlRules.ClassRuleHtmlNameForContentPre2[classid], Base.Configs.ContentSet.ConfigsControl.Instance.ContentPathRw.Replace("{分类ID}", cid.ToString()).Replace("{页码}", PageIndex.ToString()).Replace("{内容ID}", iId.ToString()));
            }
            return string.Concat(SiteFolder, Base.Configs.ContentSet.ConfigsControl.Instance.ContentPathRw.Replace("{分类ID}", cid.ToString()).Replace("{页码}", PageIndex.ToString()).Replace("{内容ID}", iId.ToString()));

             
        }
        //public string GetContentLink(object iID)
        //{
        //    return GetContentLink(iID, 0, 1);
        //}
        public string GetContentLink(object iId, Guid ModelID)
        {
            throw new NotImplementedException();
        }
    }
}
