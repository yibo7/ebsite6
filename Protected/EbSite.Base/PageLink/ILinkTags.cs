using System;
using System.Collections.Generic;

using System.Text;
using EbSite.Entity;

namespace EbSite.Base.PageLink
{
    public interface ILinkTags
    {

        /// <summary>
        /// 获取标签列表地址-用来获取分类，生成静态面页用
        /// </summary>
        /// <returns></returns>
        string TagsList(int p);
        /// <summary>
        /// 获取标签-按排序号
        /// </summary>
        /// <param name="p"></param>
        /// <param name="OrderBy">1 为最新标签 2为热门标签</param>
        /// <returns></returns>
        string TagsList(int p, int OrderBy);
        /// <summary>
        /// 获取标签搜索结果列表地址
        /// </summary>
        /// <returns></returns>
        string TagsSearchList(object id, int p);


    }
}
