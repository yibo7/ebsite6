using System;
using System.Collections.Generic;

using System.Text;
using EbSite.Entity;

namespace EbSite.Base.PageLink
{
    public interface ILinkClass
    {

        /// <summary>
        /// 获取分类页面连接-最新排序
        /// </summary>
        /// <param name="HtmlPath">分类html命名</param>
        /// <returns></returns>
        string GetClassHref(object iID, object HtmlPath, int pIndex);
        string GetClassHref(object iID, object HtmlPath, int pIndex, string OutLink);
        string GetClassHref(int iID, int Index);
        /// <summary>
        /// 所有分类页面
        /// </summary>
        /// <returns></returns>
        string GetAllClassHref();
        /// <summary>
        /// 获取列表-按排序号
        /// </summary>
        /// <param name="iID"></param>
        /// <param name="Index"></param>
        /// <param name="OrderBy">排序，0默认按ID排序，1按点击率排序，2按收藏排序，3按评论数排序，4好评或星级或顶一下排序，5按发布日期排序</param>
        /// <returns></returns>
        string GetClassHref_OrderBy(int iID, int Index, int OrderBy);

    }
}
