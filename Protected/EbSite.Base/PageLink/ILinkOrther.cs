using System;
using System.Collections.Generic;

using System.Text;
using EbSite.Entity;

namespace EbSite.Base.PageLink
{
    public interface  ILinkOrther
    {
        /// <summary>
        /// 获取主站首页地址
        /// </summary>
        /// <returns></returns>
        string GetMainIndexHref();
        /// <summary>
        /// 个人收藏专辑连接
        /// </summary>
        /// <param name="iID">专辑ID</param>
        /// <param name="Index">页码</param>
        /// <returns></returns>
        string UserAlbumHref(int iID, int Index,int UserID);
        /// <summary>
        /// 首页有分页列表情况
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        string IndexForPage(int Index);
        /// <summary>
        /// 表单模型地址
        /// </summary>
        /// <param name="modelid">表单模型Id</param>
        /// <returns></returns>
        string GetFormUrl(string modelid);
        /// <summary>
        /// 获取第三方登录回调地址
        /// </summary>
        /// <param name="apptype">插件app名称，如 QQ,SINA</param>
        /// <returns></returns>
        string GetLoginApiBackUrl(string apptype);

        /// <summary>
        /// 获取用户默认信息页面
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        string GetUserInfo(object UserID);
        /// <summary>
        /// 获取投票展示页
        /// </summary>
        /// <param name="VoteID"></param>
        /// <returns></returns>
        string GetVoteView(object VoteID);
        /// <summary>
        /// 获取投票提交页
        /// </summary>
        /// <param name="VoteID"></param>
        /// <returns></returns>
        string GetVotePost(object VoteID);
        ///// <summary>
        ///// 获取个人专辑页
        ///// </summary>
        ///// <param name="AlbumID"></param>
        ///// <param name="PageIndex"></param>
        ///// <returns></returns>
        //string GetAlbum(object AlbumID, int PageIndex);
        /// <summary>
        /// 获取排行榜
        /// </summary>
        /// <param name="itype">排行榜类别，0为所有，1为月，2为周，3为日</param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        string GetTop(int itype, int PageIndex);



    }
}
