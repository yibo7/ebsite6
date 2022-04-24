using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.BLL.GetLink.OrtherLink
{
    public class cAutoHtmlHref : cReWriteHref
    {
        public cAutoHtmlHref(int _SiteID):base(_SiteID)
        {
            this.SiteID = _SiteID;
        }

        //public  string GetFormUrl(string modelid)
        //{
        //    return string.Concat(IISPath, modelid, "-", SiteID, CustomFormRw);
        //}
        ///// <summary>
        ///// 获取主站首页地址
        ///// </summary>
        ///// <returns></returns>
        //public string GetMainIndexHref()
        //{
        //    if (SiteID > 1)
        //    {
        //        return string.Concat(IndexLink, "?site=", SiteID);

        //    }
        //    else
        //    {
        //        return IndexLink;
        //    }

        //}
        //public string UserAlbumHref(int id, int index, int UserID)
        //{
        //    return string.Concat(SiteFolder, UserID, "-", id, "-", index, UserAlbumRw);
        //}
        //public string IndexForPage(int index)
        //{
        //    return string.Concat("{0}-", Base.Configs.ContentSet.ConfigsControl.Instance.IndexPathRw, "?site=", SiteID);
        //}
        //public string GetLoginApiBackUrl(string apptype)
        //{
        //    return string.Concat(SiteFolder, apptype, "-", LoginbindRw);
        //}


        //public string GetUserInfo(object UserID)
        //{
        //    return string.Concat(SiteFolder, UserID, UserInfoRw);
        //}
        //public string GetVoteView(object VoteID)
        //{
        //    return string.Concat(SiteFolder, VoteID, VoteViewRw);
        //}
        //public string GetVotePost(object VoteID)
        //{
        //    return string.Concat(SiteFolder, VoteID, VotePostRw);
        //}
        //public string GetTop(int itype, int PageIndex)
        //{
        //    return string.Concat(SiteFolder, itype, "-", PageIndex, TopRw);
        //}
    }
}
