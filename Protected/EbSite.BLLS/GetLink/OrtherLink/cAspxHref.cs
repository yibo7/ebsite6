using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.OrtherLink
{
    public class cAspxHref : IBase, ILinkOrther
    {
        public cAspxHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        /// <summary>
        /// 获取主站首页地址
        /// </summary>
        /// <returns></returns>
        public  string GetMainIndexHref()
        {
            if (SiteID > 1)
            {
                return string.Concat(IndexLink, "?site=", SiteID);

            }
            else
            {
                return IndexLink;
            }

        }
        public  string GetFormUrl(string modelid)
        {
            return string.Concat(IISPath, CustomForm, "?site=", SiteID, "&mid=", modelid);
        }
        public string UserAlbumHref(int id, int index, int UserID)
        {
            return string.Concat(IISPath, UserAlbum, "?al=", id, "&p=", index, "&site=", SiteID, "&uid=", UserID);
        }

        public  string IndexForPage(int index)
        {
            return string.Concat(base.IndexLink, "?p=", index, "&site=", SiteID);
        }
        public  string GetLoginApiBackUrl(string apptype)
        {
            return string.Concat(base.LoginBind, "?t=", apptype);
        }


        public string GetUserInfo(object UserID)
        {
            return string.Concat(IISPath, UserInfo(UserID), "?uid=", UserID, "&site=", SiteID);
        }
        public string GetVoteView(object VoteID)
        {
            return string.Concat(IISPath, VoteView, "?vid=", VoteID, "&site=", SiteID);
        }
        public string GetVotePost(object VoteID)
        {
            return string.Concat(IISPath, VotePost, "?vid=", VoteID, "&site=", SiteID);
        }
        //public string GetAlbum(object AlbumID, int PageIndex)
        //{
        //    return string.Concat(IISPath, Album, "?vid=", AlbumID, "&p=", PageIndex);
        //}
        public string GetTop(int itype, int PageIndex)
        {
            return string.Concat(IISPath, Top, "?t=", itype, "&p=", PageIndex,"&site=", SiteID);
        }
    }
}
