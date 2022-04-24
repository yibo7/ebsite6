using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.ClassLink
{
    public class cHtmlHref : IBase, ILinkClass
    {
        public cHtmlHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        public  string GetClassHref(object iID, object HtmlPath, int pIndex)
        {

            string sUrl = string.Empty;
            if (!Equals(HtmlPath, null))
                sUrl = HtmlPath.ToString();
            sUrl = sUrl.Replace(HtmlReNameRule.KeyID.ToLower(), iID.ToString());
            if (!Equals(HtmlPath,null))
            {
                string extension = System.IO.Path.GetExtension(HtmlPath.ToString()); //2012-11-14 yhl 添加
                if (string.IsNullOrEmpty(extension))
                {
                    if (pIndex > 1)
                    {
                        sUrl = string.Concat(sUrl, "/", PageSplit, pIndex);
                            //sUrl = string.Concat(sUrl, "/", iID, PageSplit, pIndex);
                    }
                    sUrl = string.Concat(IISPathFormHtml, sUrl, sDefaultName);
                }
                else
                {
                    string FileNameWithOutExtension = System.IO.Path.GetFileNameWithoutExtension(HtmlPath.ToString());
                        //2012-11-26 yhl 添加

                    if (pIndex > 1)
                    {
                        sUrl = string.Concat(FileNameWithOutExtension, "-", pIndex, extension); //peijiandaquan-2.shtml
                    }
                    sUrl = string.Concat(IISPathFormHtml, sUrl);
                }
            }
            return sUrl;
        }
        public  string GetClassHref(object iId, object HtmlPath, int pIndex, string OutLink)
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
        public  string GetClassHref(int iId, int Index)
        {
            //string CacheKey = string.Concat("GetClassHref-", iId, "-", Index);
            //string sHtmlUrl = bllCache.GetCacheItem(CacheKey) as string;
            //if (string.IsNullOrEmpty(sHtmlUrl))
            //{
            string sHtmlUrl = "";
            Entity.NewsClass Model = BLL.NewsClass.GetModelByCache(iId);
            if (!Equals(Model, null))
            {
                sHtmlUrl = GetClassHref(iId, Model.HtmlName, Index);
            }
            else
            {
                sHtmlUrl = "/";
            }
            //if (!string.IsNullOrEmpty(sHtmlUrl)) bllCache.AddCacheItem(CacheKey, sHtmlUrl);
            //}

            return sHtmlUrl;

        }

        public  string GetClassHref_OrderBy(int iId, int Index, int OrderBy)
        {
            string sUrl = "/classodb/";
            if (Index > 1)
            {
                sUrl = string.Concat(sUrl, iId, "p", Index);
            }
            else
            {
                sUrl = string.Concat(sUrl, iId);
            }
            sUrl = string.Concat(IISPathFormHtml, sUrl, sDefaultName);
            return sUrl;
        }
        public string GetAllClassHref()
        {
            return string.Concat(SiteFolder, ClassLinkAllRw);
        }

    }
}
