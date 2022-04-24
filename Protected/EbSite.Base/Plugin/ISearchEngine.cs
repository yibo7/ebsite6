using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.Plugin.Base;

namespace EbSite.Base.Plugin
{
    public interface ISearchEngine : IProvider
    {

        /// <summary>
        /// 获取分词
        /// </summary>
        /// <param name="Content">词源.</param>
        /// <param name="Len">词字数的长度.</param>
        /// <param name="Top">返回多少个.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        List<string> SegmentWords(string Content,int Len,int Top);

        /// <summary>
        /// ebsite内容搜索
        /// </summary>
        /// <param name="KeyWord">搜索关键词</param>
        /// <param name="PageSize">每页显示多少条数据</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="recCount">记录总数</param>
        /// <param name="OrderBy">排序方式，如id desc</param>
        /// <param name="httpContext">当前请求上下文</param>
        /// <param name="SiteID">当前请求站点ID</param>
        /// <param name="time">本次搜索所花时间,毫秒</param>
        /// <returns></returns>
        object Query(String KeyWord, int PageSize, int PageIndex, out int recCount, string OrderBy, HttpContext httpContext, int SiteID,out long time);
    }
}
