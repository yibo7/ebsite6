using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.OrtherLink
{
    /// <summary>
    /// 目前这些页面的静态页面不起用
    /// </summary>
    public class cHtmlHref : IBase, ILinkOrther
    {
        public cHtmlHref(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
        public  string GetFormUrl(string modelid)
        {
            return string.Concat(IISPath, modelid, "-", SiteID, CustomFormRw);
        }
        /// <summary>
        /// 获取主站首页地址
        /// </summary>
        /// <returns></returns>
        public  string GetMainIndexHref()
        {
            return string.Concat(IISPathFormHtml, sDefaultName);
        }
        public  string GetLoginApiBackUrl(string apptype)
        {
            return string.Concat(SiteFolder, apptype, "-", LoginbindRw);
        }
        public  string UserAlbumHref(int id, int index,int UserID)
        {
            return string.Concat(SiteFolder, id, "-", index, UserAlbumRw);
        }
        public  string IndexForPage(int index)
        {
            return string.Concat("{0}-", Base.Configs.ContentSet.ConfigsControl.Instance.IndexPathRw, "?site=", SiteID);
        }
        public string GetUserInfo(object UserID)
        {
            return string.Concat(IISPath, UserID, "-", UserInfoRw);
        }
        public string GetVoteView(object VoteID)
        {
            return string.Concat(IISPath, VoteID, "-", VoteViewRw);
        }
        public string GetVotePost(object VoteID)
        {
            return string.Concat(IISPath, VoteID, "-", VotePostRw);
        }
        //public string GetAlbum(object AlbumID, int PageIndex)
        //{
        //    return string.Concat(IISPath, AlbumID, "-", PageIndex, "-", AlbumRw);
        //}
        public string GetTop(int itype, int PageIndex)
        {
            return string.Concat(IISPath, itype, "-", PageIndex, "-", TopRw);
        }
    }
}
