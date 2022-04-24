using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.ContentLink
{
    public class cHtmlHref : IBase, ILinkContent
    {
        public cHtmlHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        public string GetContentLink(object iID, object HtmlPath, object cid, object PageIndex)
        {
            string sUrl = HtmlPath.ToString();
            sUrl = sUrl.Replace(HtmlReNameRule.KeyID.ToLower(), iID.ToString());
            sUrl = string.Concat(IISPathFormHtml, sUrl, sDefaultName);
            return sUrl;
        }
        public string GetContentLink(object iId, object ClassID, object PageIndex)
        {
          
            string sUrl = "/";
            if (!Equals(iId, null))
            {
                //yhl
                EbSite.Entity.NewsContent model = EbSite.Base.AppStartInit.GetNewsContentInst(int.Parse(ClassID.ToString())).GetModel(int.Parse(iId.ToString()), this.SiteID);

                //EbSite.Entity.NewsContent model = BLL.NewsContent.GetModel(int.Parse(iID.ToString()));
                if (!Equals(model, null))
                {
                    sUrl = model.HtmlName;
                    if (!string.IsNullOrEmpty(sUrl))
                    {
                        sUrl = sUrl.Replace(HtmlReNameRule.KeyID.ToLower(), iId.ToString());
                        sUrl = string.Concat(IISPathFormHtml, "/", sUrl, sDefaultName);
                    }
                    else //有时可能在模块扩展里添加数据，HtmlName为空的情况，给一个默认值，免费生成静态出错
                    {
                        sUrl = string.Concat(IISPathFormHtml, "/content/", iId, sDefaultName);
                    }

                }

            }
            return sUrl;
        }
        public string GetContentLink(object iId, Guid ModelID)
        {
            string sUrl = "/";
            if (!Equals(iId, null))
            {
                //yhl
                //int siteid = EbSite.Base.Host.Instance.GetSiteID;
                EbSite.Entity.NewsContent model = EbSite.Base.AppStartInit.GetNewsContentInst(ModelID, this.SiteID).GetModel(int.Parse(iId.ToString()), this.SiteID);

                //EbSite.Entity.NewsContent model = BLL.NewsContent.GetModel(int.Parse(iID.ToString()));
                if (!Equals(model, null))
                {
                    sUrl = model.HtmlName;
                    if (!string.IsNullOrEmpty(sUrl))
                    {
                        sUrl = sUrl.Replace(HtmlReNameRule.KeyID.ToLower(), iId.ToString());
                        sUrl = string.Concat(IISPathFormHtml,"/", sUrl, sDefaultName);
                    }
                    else //有时可能在模块扩展里添加数据，HtmlName为空的情况，给一个默认值，免费生成静态出错
                    {
                        sUrl = string.Concat(IISPathFormHtml,"/content/", iId, sDefaultName);
                    }

                }

            }
            return sUrl;
        }
        public string GetContentLink(object iId)
        {
            string sUrl = "/";
            if (!Equals(iId, null))
            {
                EbSite.Entity.NewsContent model = EbSite.Base.AppStartInit.NewsContentInstDefault.GetModel(int.Parse(iId.ToString()), this.SiteID);
                if (!Equals(model, null))
                {
                    sUrl = model.HtmlName;
                    if (!string.IsNullOrEmpty(sUrl))
                    {
                        sUrl = sUrl.Replace(HtmlReNameRule.KeyID.ToLower(), iId.ToString());
                        sUrl = string.Concat(IISPathFormHtml, "/", sUrl, sDefaultName);
                    }
                    else //有时可能在模块扩展里添加数据，HtmlName为空的情况，给一个默认值，免费生成静态出错
                    {
                        sUrl = string.Concat(IISPathFormHtml, "/content/", iId, sDefaultName);
                    }

                }

            }
            return sUrl;
        }
    }
}
