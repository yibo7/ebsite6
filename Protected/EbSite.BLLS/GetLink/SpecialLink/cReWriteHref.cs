using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;
using EbSite.Core.HttpModules;

namespace EbSite.BLL.GetLink.SpecialLink
{
    public class cReWriteHref : IBase, ILinkSpecial
    {
        public cReWriteHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }

        public  string GetSpecialHref(int iid, int index)
        {
            if (UrlRules.SpecialRuleHtmlNames2.ContainsKey(iid))
            {
                if (index <= 1)
                    return UrlRules.SpecialRuleHtmlNames2[iid];

                return string.Concat(UrlRules.SpecialRuleHtmlNames2[iid], index, "/");

            }

           return string.Concat(SiteFolder, Base.Configs.ContentSet.ConfigsControl.Instance.SpecialPathRw.Replace("{专题ID}", iid.ToString()).Replace("{页码}", index.ToString()));
             
        }

        public string GetSpecialHref(int iid, int index,int ClassId)
        {

            return string.Empty;
            //if (UrlRules.SpecialRuleHtmlNames2.ContainsKey(iid))
            //{
            //    if (index <= 1)
            //        return UrlRules.SpecialRuleHtmlNames2[iid];

            //    return string.Concat(UrlRules.SpecialRuleHtmlNames2[iid], index, "/");

            //}

            //return string.Concat(SiteFolder, Base.Configs.ContentSet.ConfigsControl.Instance.SpecialPathRw.Replace("{专题ID}", iid.ToString()).Replace("{页码}", index.ToString()));
        }
    }
}
