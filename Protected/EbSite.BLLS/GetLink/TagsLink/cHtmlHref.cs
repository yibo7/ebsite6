using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.TagsLink
{
    public class cHtmlHref : IBase, ILinkTags
    {
        public cHtmlHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        public  string TagsList(int p, int OrderBy)
        {
            return string.Concat(IISPathFormHtml, Base.Configs.HtmlConfigs.ConfigsControl.Instance.TagsList, "odb", p, sDefaultName);
            //return string.Concat(IISPath, TaglistLink, "?p=", p, "&odb=", OrderBy);
        }
        /// <summary>
        /// 获取标签列表地址-分页 
        /// </summary>
        /// <returns></returns>
        public  string TagsList(int p)
        {

            string sUrl = Base.Configs.HtmlConfigs.ConfigsControl.Instance.TagsList;

            if (p > 1)
            {
                sUrl = string.Concat(sUrl, "/", PageSplit, p);
            }

            return string.Concat(IISPathFormHtml, sUrl, sDefaultName);
        }
        public  string TagsSearchList(object id, int p)
        {

            string sUrl = TagKey.GetHtmlName(int.Parse(id.ToString()));// string.Concat(Base.Configs.HtmlConfigs.ConfigsControl.Instance.TagsSearchList, "/", id);
            sUrl = sUrl.Replace(HtmlReNameRule.KeyID.ToLower(), id.ToString());//sUrl = sUrl.Replace("{#KeyID#}", id.ToString()).Replace("{#TitleSpell#}", TagKey.GetEname(int.Parse(id.ToString())));

            if (p > 1)
            {
                sUrl = string.Concat(sUrl, "/", PageSplit, p);
                //sUrl = string.Concat(sUrl, "/", id, PageSplit, p);
            }
            sUrl = string.Concat(IISPathFormHtml, sUrl, sDefaultName);

            return sUrl;

        }
    }
}
