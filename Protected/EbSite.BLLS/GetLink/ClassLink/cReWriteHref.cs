using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;
using EbSite.Core.HttpModules;

namespace EbSite.BLL.GetLink.ClassLink
{
    public class cReWriteHref : IBase, ILinkClass
    {
        public cReWriteHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        public string GetClassHref(object iId, object HtmlPath, int pIndex)
        {
            return GetClassHref(Core.Utils.StrToInt(iId.ToString(), 0), pIndex);
            //return string.Concat(SiteFolder, iId, "-", pIndex, "-0", ClassLinkRw);
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
        public string GetClassHref(int iId, int Index)
        {
            return GetClassHref_OrderBy(iId, Index, 0);
            //return string.Concat(SiteFolder, iId, "-", Index, "-0", ClassLinkRw);
        }
        public string GetClassHref_OrderBy(int iId, int Index, int OrderBy)
        {

            if (UrlRules.ClassRuleHtmlNames2.ContainsKey(iId))
            {
                if(Index<=1)
                    return UrlRules.ClassRuleHtmlNames2[iId];

                return  string.Concat(UrlRules.ClassRuleHtmlNames2[iId], Index,"/");

            } 
           return string.Concat(SiteFolder,Base.Configs.ContentSet.ConfigsControl.Instance.ListPathRw.Replace("{分类ID}", iId.ToString()).Replace("{页码}", Index.ToString()).Replace("{排序类别}", OrderBy.ToString()));
 
        }
        public string GetAllClassHref()
        {
            return string.Concat(SiteFolder, ClassLinkAllRw);
        }
    }
}
