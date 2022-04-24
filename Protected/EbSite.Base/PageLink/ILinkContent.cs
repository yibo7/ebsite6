using System;
using System.Collections.Generic;

using System.Text;
using EbSite.Entity;

namespace EbSite.Base.PageLink
{
    public interface  ILinkContent
    {
        /// <summary>
        /// 获取内容页面地址
        /// </summary>
        /// <param name="HtmlPath">内容html命名</param>
        /// <returns></returns>
        //string GetContentLink(object iID, object HtmlPath);
        //string GetContentLink(object iID);
        string GetContentLink(object iID, object HtmlPath,object iCID,object PageIndex);
        string GetContentLink(object iID, object ClassID, object PageIndex);
        ///// <summary>
        ///// 主要用来配合生成静态页面用，前台页面不要使用此方法，只在动态页面里实现
        ///// </summary>
        ///// <param name="iID"></param>
        ///// <param name="ModelID"></param>
        ///// <returns></returns>
        //string GetContentLink(object iID, Guid ModelID);
        ///// <summary>
        ///// 为了兼容老版本，保留这个方法，此方法不传入分类ID,内容页面默认调用默认内容表
        ///// </summary>
        ///// <param name="iID">内容ID</param>
        ///// <returns></returns>
        //string GetContentLink(object iID);

    }
}
