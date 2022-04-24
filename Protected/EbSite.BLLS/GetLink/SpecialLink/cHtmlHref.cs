using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.SpecialLink
{
    public class cHtmlHref : IBase, ILinkSpecial
    {
        public cHtmlHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        public  string GetSpecialHref(int iID, int pIndex)
        {
            Entity.SpecialClass Model = BLL.SpecialClass.GetModelByCache(iID);
            if (!Equals(Model, null))
            {
                return GetSpecialHref(iID, Model.HtmlName, pIndex,0);
            }
            else
            {
                return "/";
            }

        }

        public string GetSpecialHref(int iID, int pIndex, int ClassId)
        {

            Entity.SpecialClass Model = BLL.SpecialClass.GetModelByCache(iID);
            if (!Equals(Model, null))
            {
                return GetSpecialHref(iID, Model.HtmlName, pIndex, ClassId);
            }
            else
            {
                return "/";
            }
        }

        private string GetSpecialHref(int iID, object HtmlPath, int pIndex,int ClassId)
        {
            string sUrl = HtmlPath.ToString();

            sUrl = sUrl.Replace(HtmlReNameRule.KeyID.ToLower(), iID.ToString());

            if (pIndex > 1)
            {
                //sUrl = string.Concat(sUrl, "/", iID, PageSplit, pIndex);
                sUrl = string.Concat(sUrl, "/", PageSplit, pIndex);

            }
            if (ClassId > 0)
            {
                sUrl = string.Concat(sUrl, "c", ClassId);
            }
            return string.Concat(IISPathFormHtml, sUrl, sDefaultName);
        }
    }
}
