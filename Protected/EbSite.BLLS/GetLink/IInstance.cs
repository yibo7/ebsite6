using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.PageLink;
using EbSite.Core;

namespace EbSite.BLL.GetLink
{
    //public enum LinkCatagory 
    //{
    //    /// <summary>
    //    /// 分类连接
    //    /// </summary>
    //    ClassLink = 0,
    //    /// <summary>
    //    /// 内容连接
    //    /// </summary>
    //    ContentLink = 1,
    //    /// <summary>
    //    /// 专题连接
    //    /// </summary>
    //    SpecialLink = 2,
    //    /// <summary>
    //    /// 标签连接
    //    /// </summary>
    //    TagsLink = 3,
    //      /// <summary>
    //    /// 其他连接
    //    /// </summary>
    //    OrtherLink = 4

    //}

    abstract public class IInstance<TYPE>
    {
       // protected static CacheManager CacheApp;
       protected  const double CacheDuration = 3600.0;//一个小时
        protected const string CacheIInstance = "linkinstance";// private static readonly string[] MasterCacheKeyArray = { "GetLinkInstance" };
        public IInstance()
        {
           // CacheApp = new CacheManager(CacheDuration, MasterCacheKeyArray);
        }

        abstract public TYPE GetInstance(int SiteID);
        abstract public TYPE GetMainInstance { get; }
        abstract protected TYPE GetHtmlInstance(int SiteID, bool isShowDefault);
        /// <summary>
        /// 为生成页面保存目录调用,只返回目录生成页面时要加上绝对路径与文件名称
        /// </summary>
        /// <returns></returns>
        public abstract TYPE GetHtmlInstance(int SiteID);

        /// <summary>
        /// 为生成页面时调用的动态url
        /// </summary>
        /// <returns></returns>
        public abstract TYPE GetAspxInstance(int SiteID);

        /// <summary>
        /// 为生成页面时调用的动态url
        /// </summary>
        /// <returns></returns>
        public abstract TYPE GetReWriteInstance(int SiteID);

        protected abstract TYPE GetAutoHtmlInstance(int SiteID);
       
    }
}
