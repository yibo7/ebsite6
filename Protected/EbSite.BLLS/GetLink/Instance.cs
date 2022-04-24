using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.PageLink;
using EbSite.Base.Static;
using EbSite.BLL.GetLink.Mobile;
using EbSite.Core;

namespace EbSite.BLL.GetLink
{

    #region  实现分类连接实例

    public class LinkClass : IInstance<ILinkClass>
    {
        private static object _SyncRoot = new object();
        public static readonly LinkClass Instance = new LinkClass();
        override public ILinkClass GetInstance(int SiteID)
        {

            LinkType lt = BLL.Sites.Instance.GetLinkTypeClass(SiteID);
            ILinkClass _Instance;
            if (LinkType.Html == lt)
            {
                _Instance = GetHtmlInstance(SiteID, false);
            }
            else if (LinkType.Aspx == lt)
            {
                _Instance = GetAspxInstance(SiteID);
            }
            else if (LinkType.AutoHtml == lt)
            {
                _Instance = GetAutoHtmlInstance(SiteID);
            }
            else
            {
                _Instance = GetReWriteInstance(SiteID);
            }
            return _Instance;

        }
        override public ILinkClass GetMainInstance
        {
            get
            {
                return GetInstance(1);
            }

        }

        public Dictionary<string, ILinkClass> HtmlInstances = new Dictionary<string, ILinkClass>();//所有站点连接对象
        override protected ILinkClass GetHtmlInstance(int SiteID, bool isShowDefault)
        {
            string key = string.Concat(SiteID, isShowDefault);
            ILinkClass mLinkClass;

            if (HtmlInstances.ContainsKey(key))
                mLinkClass = HtmlInstances[key];
            else
            {
                lock (_SyncRoot)
                {
                    if (!HtmlInstances.ContainsKey(key))
                    {
                        ClassLink.cHtmlHref htmlhref = new ClassLink.cHtmlHref(SiteID);
                        htmlhref.isShowDefault = isShowDefault;
                        mLinkClass = htmlhref;
                        HtmlInstances.Add(key, mLinkClass);
                    }
                    else
                    {
                        mLinkClass = HtmlInstances[key];
                    }
                }

            }
            return mLinkClass;

            //string rawKey = string.Concat("LinkClassGetHtmlInstance", SiteID, "-", isShowDefault);
            //ClassLink.cHtmlHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<ClassLink.cHtmlHref>(rawKey,CacheIInstance); //CacheApp.GetCacheItem(rawKey) as ClassLink.cHtmlHref;
            //if (_Instance == null)
            //{
            //    ClassLink.cHtmlHref htmlhref = new ClassLink.cHtmlHref(SiteID);
            //    htmlhref.isShowDefault = isShowDefault;
            //    _Instance = htmlhref;
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, htmlhref, CacheDuration, ETimeSpanModel.秒, CacheIInstance); //CacheApp.AddCacheItem(rawKey, htmlhref);
            //}
            //return _Instance;
        }

        /// <summary>
        /// 为生成页面保存目录调用,只返回目录生成页面时要加上绝对路径与文件名称
        /// </summary>
        /// <returns></returns>
        override public ILinkClass GetHtmlInstance(int SiteID)
        {
            return GetHtmlInstance(SiteID, true);
        }

        public Dictionary<int, ILinkClass> AspxInstances = new Dictionary<int, ILinkClass>();//所有站点连接对象
        /// <summary>
        /// 为生成页面时调用的动态url
        /// </summary>
        /// <returns></returns>
        override public ILinkClass GetAspxInstance(int SiteID)
        {

            ILinkClass mLinkClass;

            if (AspxInstances.ContainsKey(SiteID))
                mLinkClass = AspxInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!AspxInstances.ContainsKey(SiteID))
                    {
                        mLinkClass = new ClassLink.cAspxHref(SiteID);
                        AspxInstances.Add(SiteID, mLinkClass);
                    }
                    else
                    {
                        mLinkClass = AspxInstances[SiteID];
                    }
                }

            }
            return mLinkClass;

            //string rawKey = string.Concat("LinkClassGetAspxInstance", SiteID);
            //ClassLink.cAspxHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<ClassLink.cAspxHref>(rawKey, CacheIInstance); //CacheApp.GetCacheItem(rawKey) as ClassLink.cAspxHref;
            //if (_Instance == null)
            //{
            //    _Instance = new ClassLink.cAspxHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); //CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;

        }

        public Dictionary<int, ILinkClass> ReWriteInstances = new Dictionary<int, ILinkClass>();//所有站点连接对象
        /// <summary>
        /// 为生成页面时调用的动态url
        /// </summary>
        /// <returns></returns>
        override public ILinkClass GetReWriteInstance(int SiteID)
        {
            ILinkClass mLinkClass;

            if (ReWriteInstances.ContainsKey(SiteID))
                mLinkClass = ReWriteInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!ReWriteInstances.ContainsKey(SiteID))
                    {
                        mLinkClass = new ClassLink.cReWriteHref(SiteID);
                        ReWriteInstances.Add(SiteID, mLinkClass);
                    }
                    else
                    {
                        mLinkClass = ReWriteInstances[SiteID];
                    }
                }

            }
            return mLinkClass;

            //string rawKey = string.Concat("LinkClassGetReWriteInstance", SiteID);
            //ClassLink.cReWriteHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<ClassLink.cReWriteHref>(rawKey, CacheIInstance); //CacheApp.GetCacheItem(rawKey) as ClassLink.cReWriteHref;
            //if (_Instance == null)
            //{
            //    _Instance = new ClassLink.cReWriteHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); //CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;
        }
        public Dictionary<int, ILinkClass> AutoHtmlInstances = new Dictionary<int, ILinkClass>();//所有站点连接对象
        override protected ILinkClass GetAutoHtmlInstance(int SiteID)
        {
            ILinkClass mLinkClass;

            if (AutoHtmlInstances.ContainsKey(SiteID))
                mLinkClass = AutoHtmlInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!AutoHtmlInstances.ContainsKey(SiteID))
                    {
                        mLinkClass = new ClassLink.cAutoHtmlHref(SiteID);
                        AutoHtmlInstances.Add(SiteID, mLinkClass);
                    }
                    else
                    {
                        mLinkClass = AutoHtmlInstances[SiteID];
                    }
                }

            }
            return mLinkClass;

            //string rawKey = string.Concat("LinkClassGetAutoHtmlInstance", SiteID);
            //ClassLink.cAutoHtmlHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<ClassLink.cAutoHtmlHref>(rawKey, CacheIInstance);//CacheApp.GetCacheItem(rawKey) as ClassLink.cAutoHtmlHref;
            //if (_Instance == null)
            //{
            //    _Instance = new ClassLink.cAutoHtmlHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); //CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;
        }
    }
    #endregion

    #region  实现内容连接实例

    public class LinkContent : IInstance<ILinkContent>
    {
        private static object _SyncRoot = new object();
        public static readonly LinkContent Instance = new LinkContent();
        override public ILinkContent GetInstance(int SiteID)
        {

            LinkType lt = BLL.Sites.Instance.GetLinkTypeContent(SiteID);
            ILinkContent _Instance;
            if (LinkType.Html == lt)
            {
                _Instance = GetHtmlInstance(SiteID, false);
            }
            else if (LinkType.Aspx == lt)
            {
                _Instance = GetAspxInstance(SiteID);
            }
            else if (LinkType.AutoHtml == lt)
            {
                _Instance = GetAutoHtmlInstance(SiteID);
            }
            else
            {
                _Instance = GetReWriteInstance(SiteID);
            }
            return _Instance;

        }
        override public ILinkContent GetMainInstance
        {
            get
            {
                return GetInstance(1);
            }

        }
        private Dictionary<string, ILinkContent> HtmlInstances = new Dictionary<string, ILinkContent>();//所有站点连接对象
        override protected ILinkContent GetHtmlInstance(int SiteID, bool isShowDefault)
        {
            string key = string.Concat(SiteID, isShowDefault);
            ILinkContent mLinkContent;

            if (HtmlInstances.ContainsKey(key))
                mLinkContent = HtmlInstances[key];
            else
            {
                lock (_SyncRoot)
                {
                    if (!HtmlInstances.ContainsKey(key))
                    {
                        ContentLink.cHtmlHref htmlhref = new ContentLink.cHtmlHref(SiteID);
                        htmlhref.isShowDefault = isShowDefault;
                        mLinkContent = htmlhref;
                        HtmlInstances.Add(key, mLinkContent);
                    }
                    else
                    {
                        mLinkContent = HtmlInstances[key];
                    }
                }

            }
            return mLinkContent;

            //string rawKey = string.Concat("LinkContentGetHtmlInstance", SiteID, "-", isShowDefault);
            //ContentLink.cHtmlHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<ContentLink.cHtmlHref>(rawKey, CacheIInstance); //CacheApp.GetCacheItem(rawKey) as ContentLink.cHtmlHref;
            //if (_Instance == null)
            //{
            //    ContentLink.cHtmlHref htmlhref = new ContentLink.cHtmlHref(SiteID);
            //    htmlhref.isShowDefault = isShowDefault;
            //    _Instance = htmlhref;
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, htmlhref, CacheDuration, ETimeSpanModel.秒, CacheIInstance);// CacheApp.AddCacheItem(rawKey, htmlhref);
            //}
            //return _Instance;
        }

        /// <summary>
        /// 为生成页面保存目录调用,只返回目录生成页面时要加上绝对路径与文件名称
        /// </summary>
        /// <returns></returns>
        override public ILinkContent GetHtmlInstance(int SiteID)
        {
            return GetHtmlInstance(SiteID, true);
        }

        private Dictionary<int, ILinkContent> AspxInstances = new Dictionary<int, ILinkContent>();//所有站点连接对象
        /// <summary>
        /// 为生成页面时调用的动态url
        /// </summary>
        /// <returns></returns>
        override public ILinkContent GetAspxInstance(int SiteID)
        {
            ILinkContent mLinkClass;

            if (AspxInstances.ContainsKey(SiteID))
                mLinkClass = AspxInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!AspxInstances.ContainsKey(SiteID))
                    {
                        mLinkClass = new ContentLink.cAspxHref(SiteID);
                        AspxInstances.Add(SiteID, mLinkClass);
                    }
                    else
                    {
                        mLinkClass = AspxInstances[SiteID];
                    }
                }

            }
            return mLinkClass;

            //string rawKey = string.Concat("LinkContentGetAspxInstance", SiteID);
            //ContentLink.cAspxHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<ContentLink.cAspxHref>(rawKey, CacheIInstance);// CacheApp.GetCacheItem(rawKey) as ContentLink.cAspxHref;
            //if (_Instance == null)
            //{
            //    _Instance = new ContentLink.cAspxHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); //CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;

        }

        private Dictionary<int, ILinkContent> ReWriteInstances = new Dictionary<int, ILinkContent>();//所有站点连接对象
        /// <summary>
        /// 为生成页面时调用的动态url
        /// </summary>
        /// <returns></returns>
        override public ILinkContent GetReWriteInstance(int SiteID)
        {
            ILinkContent mLinkClass;

            if (ReWriteInstances.ContainsKey(SiteID))
                mLinkClass = ReWriteInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!ReWriteInstances.ContainsKey(SiteID))
                    {
                        mLinkClass = new ContentLink.cReWriteHref(SiteID);
                        ReWriteInstances.Add(SiteID, mLinkClass);
                    }
                    else
                    {
                        mLinkClass = ReWriteInstances[SiteID];
                    }
                }

            }
            return mLinkClass;

            //string rawKey = string.Concat("LinkContentGetReWriteInstance", SiteID);
            //ContentLink.cReWriteHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<ContentLink.cReWriteHref>(rawKey, CacheIInstance); //CacheApp.GetCacheItem(rawKey) as ContentLink.cReWriteHref;
            //if (_Instance == null)
            //{
            //    _Instance = new ContentLink.cReWriteHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); //CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;
        }

        private Dictionary<int, ILinkContent> AutoHtmlInstances = new Dictionary<int, ILinkContent>();//所有站点连接对象
        override protected ILinkContent GetAutoHtmlInstance(int SiteID)
        {

            ILinkContent mLinkClass;

            if (AutoHtmlInstances.ContainsKey(SiteID))
                mLinkClass = AutoHtmlInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!AutoHtmlInstances.ContainsKey(SiteID))
                    {
                        mLinkClass = new ContentLink.cAutoHtmlHref(SiteID);
                        AutoHtmlInstances.Add(SiteID, mLinkClass);
                    }
                    else
                    {
                        mLinkClass = AutoHtmlInstances[SiteID];
                    }
                }

            }
            return mLinkClass;

            //string rawKey = string.Concat("LinkContentGetAutoHtmlInstance", SiteID);
            //ContentLink.cAutoHtmlHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<ContentLink.cAutoHtmlHref>(rawKey, CacheIInstance); // CacheApp.GetCacheItem(rawKey) as ContentLink.cAutoHtmlHref;
            //if (_Instance == null)
            //{
            //    _Instance = new ContentLink.cAutoHtmlHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); // CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;
        }
    }
    #endregion

    #region  实现专题连接实例

    public class LinkSpecial : IInstance<ILinkSpecial>
    {
        private static object _SyncRoot = new object();
        public static readonly LinkSpecial Instance = new LinkSpecial();
        override public ILinkSpecial GetInstance(int SiteID)
        {

            LinkType lt = BLL.Sites.Instance.GetLinkTypeSpecial(SiteID);// Base.Configs.SysConfigs.ConfigsControl.Instance.Linktype;
            ILinkSpecial _Instance;
            if (LinkType.Html == lt)
            {
                _Instance = GetHtmlInstance(SiteID, false);
            }
            else if (LinkType.Aspx == lt)
            {
                _Instance = GetAspxInstance(SiteID);
            }
            else if (LinkType.AutoHtml == lt)
            {
                _Instance = GetAutoHtmlInstance(SiteID);
            }
            else
            {
                _Instance = GetReWriteInstance(SiteID);
            }
            return _Instance;

        }
        override public ILinkSpecial GetMainInstance
        {
            get
            {
                return GetInstance(1);
            }

        }
        private Dictionary<string, ILinkSpecial> HtmlInstances = new Dictionary<string, ILinkSpecial>();//所有站点连接对象
        override protected ILinkSpecial GetHtmlInstance(int SiteID, bool isShowDefault)
        {
            string key = string.Concat(SiteID, isShowDefault);
            ILinkSpecial mLinkSpecial;

            if (HtmlInstances.ContainsKey(key))
                mLinkSpecial = HtmlInstances[key];
            else
            {
                lock (_SyncRoot)
                {
                    if (!HtmlInstances.ContainsKey(key))
                    {
                        SpecialLink.cHtmlHref htmlhref = new SpecialLink.cHtmlHref(SiteID);
                        htmlhref.isShowDefault = isShowDefault;
                        mLinkSpecial = htmlhref;
                        HtmlInstances.Add(key, mLinkSpecial);
                    }
                    else
                    {
                        mLinkSpecial = HtmlInstances[key];
                    }
                }

            }
            return mLinkSpecial;

            //string rawKey = string.Concat("LinkSpecialGetHtmlInstance", SiteID, "-", isShowDefault);
            //SpecialLink.cHtmlHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<SpecialLink.cHtmlHref>(rawKey, CacheIInstance); //CacheApp.GetCacheItem(rawKey) as SpecialLink.cHtmlHref;
            //if (_Instance == null)
            //{
            //    SpecialLink.cHtmlHref htmlhref = new SpecialLink.cHtmlHref(SiteID);
            //    htmlhref.isShowDefault = isShowDefault;
            //    _Instance = htmlhref;
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); //CacheApp.AddCacheItem(rawKey, htmlhref);
            //}
            //return _Instance;
        }

        /// <summary>
        /// 为生成页面保存目录调用,只返回目录生成页面时要加上绝对路径与文件名称
        /// </summary>
        /// <returns></returns>
        override public ILinkSpecial GetHtmlInstance(int SiteID)
        {
            return GetHtmlInstance(SiteID, true);
        }


        private Dictionary<int, ILinkSpecial> AspxInstances = new Dictionary<int, ILinkSpecial>();//所有站点连接对象
        /// <summary>
        /// 为生成页面时调用的动态url
        /// </summary>
        /// <returns></returns>
        override public ILinkSpecial GetAspxInstance(int SiteID)
        {

            ILinkSpecial mLinkSpecial;

            if (AspxInstances.ContainsKey(SiteID))
                mLinkSpecial = AspxInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!AspxInstances.ContainsKey(SiteID))
                    {
                        mLinkSpecial = new SpecialLink.cAspxHref(SiteID);
                        AspxInstances.Add(SiteID, mLinkSpecial);
                    }
                    else
                    {
                        mLinkSpecial = AspxInstances[SiteID];
                    }
                }

            }
            return mLinkSpecial;

            //string rawKey = string.Concat("LinkSpecialGetAspxInstance", SiteID);
            //SpecialLink.cAspxHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<SpecialLink.cAspxHref>(rawKey, CacheIInstance); //CacheApp.GetCacheItem(rawKey) as SpecialLink.cAspxHref;
            //if (_Instance == null)
            //{
            //    _Instance = new SpecialLink.cAspxHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); //CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;

        }

        private Dictionary<int, ILinkSpecial> ReWriteInstances = new Dictionary<int, ILinkSpecial>();//所有站点连接对象
        /// <summary>
        /// 为生成页面时调用的动态url
        /// </summary>
        /// <returns></returns>
        override public ILinkSpecial GetReWriteInstance(int SiteID)
        {
            ILinkSpecial mLinkSpecial;

            if (ReWriteInstances.ContainsKey(SiteID))
                mLinkSpecial = ReWriteInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!ReWriteInstances.ContainsKey(SiteID))
                    {
                        mLinkSpecial = new SpecialLink.cReWriteHref(SiteID);
                        ReWriteInstances.Add(SiteID, mLinkSpecial);
                    }
                    else
                    {
                        mLinkSpecial = ReWriteInstances[SiteID];
                    }
                }

            }
            return mLinkSpecial;

            //string rawKey = string.Concat("LinkSpecialGetReWriteInstance", SiteID);
            //SpecialLink.cReWriteHref _Instance = EbSite.Base.Host.CacheApp.GetCacheItem<SpecialLink.cReWriteHref>(rawKey, CacheIInstance);// CacheApp.GetCacheItem(rawKey) as SpecialLink.cReWriteHref;
            //if (_Instance == null)
            //{
            //    _Instance = new SpecialLink.cReWriteHref(SiteID);
            //    EbSite.Base.Host.CacheApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); //CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;
        }

        private Dictionary<int, ILinkSpecial> AutoHtmlInstances = new Dictionary<int, ILinkSpecial>();//所有站点连接对象
        override protected ILinkSpecial GetAutoHtmlInstance(int SiteID)
        {
            ILinkSpecial mLinkSpecial;

            if (AutoHtmlInstances.ContainsKey(SiteID))
                mLinkSpecial = AutoHtmlInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!AutoHtmlInstances.ContainsKey(SiteID))
                    {
                        mLinkSpecial = new SpecialLink.cAutoHtmlHref(SiteID);
                        AutoHtmlInstances.Add(SiteID, mLinkSpecial);
                    }
                    else
                    {
                        mLinkSpecial = AutoHtmlInstances[SiteID];
                    }
                }

            }
            return mLinkSpecial;

            //string rawKey = string.Concat("LinkSpecialGetAutoHtmlInstance", SiteID);
            //SpecialLink.cAutoHtmlHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<SpecialLink.cAutoHtmlHref>(rawKey, CacheIInstance); //CacheApp.GetCacheItem(rawKey) as SpecialLink.cAutoHtmlHref;
            //if (_Instance == null)
            //{
            //    _Instance = new SpecialLink.cAutoHtmlHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); //CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;
        }
    }
    #endregion

    #region  实现标签连接实例

    public class LinkTags : IInstance<ILinkTags>
    {
        private static object _SyncRoot = new object();
        public static readonly LinkTags Instance = new LinkTags();
        override public ILinkTags GetInstance(int SiteID)
        {

            LinkType lt = BLL.Sites.Instance.GetLinkTypeTags(SiteID);// Base.Configs.SysConfigs.ConfigsControl.Instance.Linktype;
            ILinkTags _Instance;
            if (LinkType.Html == lt)
            {
                _Instance = GetHtmlInstance(SiteID, false);
            }
            else if (LinkType.Aspx == lt)
            {
                _Instance = GetAspxInstance(SiteID);
            }
            else if (LinkType.AutoHtml == lt)
            {
                _Instance = GetAutoHtmlInstance(SiteID);
            }
            else
            {
                _Instance = GetReWriteInstance(SiteID);
            }
            return _Instance;

        }
        override public ILinkTags GetMainInstance
        {
            get
            {
                return GetInstance(1);
            }

        }

        private Dictionary<string, ILinkTags> HtmlInstances = new Dictionary<string, ILinkTags>();//所有站点连接对象

        override protected ILinkTags GetHtmlInstance(int SiteID, bool isShowDefault)
        {

            string key = string.Concat(SiteID, isShowDefault);
            ILinkTags mLinkTags;

            if (HtmlInstances.ContainsKey(key))
                mLinkTags = HtmlInstances[key];
            else
            {
                lock (_SyncRoot)
                {
                    if (!HtmlInstances.ContainsKey(key))
                    {
                        TagsLink.cHtmlHref htmlhref = new TagsLink.cHtmlHref(SiteID);
                        htmlhref.isShowDefault = isShowDefault;
                        mLinkTags = htmlhref;
                        HtmlInstances.Add(key, mLinkTags);
                    }
                    else
                    {
                        mLinkTags = HtmlInstances[key];
                    }
                }

            }
            return mLinkTags;

            //string rawKey = string.Concat("LinkTagsGetHtmlInstance", SiteID, "-", isShowDefault);
            //TagsLink.cHtmlHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<TagsLink.cHtmlHref>(rawKey, CacheIInstance); //CacheApp.GetCacheItem(rawKey) as TagsLink.cHtmlHref;
            //if (_Instance == null)
            //{
            //    TagsLink.cHtmlHref htmlhref = new TagsLink.cHtmlHref(SiteID);
            //    htmlhref.isShowDefault = isShowDefault;
            //    _Instance = htmlhref;
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); // CacheApp.AddCacheItem(rawKey, htmlhref);
            //}
            //return _Instance;
        }

        /// <summary>
        /// 为生成页面保存目录调用,只返回目录生成页面时要加上绝对路径与文件名称
        /// </summary>
        /// <returns></returns>
        override public ILinkTags GetHtmlInstance(int SiteID)
        {
            return GetHtmlInstance(SiteID, true);
        }

        private Dictionary<int, ILinkTags> AspxInstances = new Dictionary<int, ILinkTags>();//所有站点连接对象
        /// <summary>
        /// 为生成页面时调用的动态url
        /// </summary>
        /// <returns></returns>
        override public ILinkTags GetAspxInstance(int SiteID)
        {
            ILinkTags mLinkSpecial;

            if (AspxInstances.ContainsKey(SiteID))
                mLinkSpecial = AspxInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!AspxInstances.ContainsKey(SiteID))
                    {
                        mLinkSpecial = new TagsLink.cAspxHref(SiteID);
                        AspxInstances.Add(SiteID, mLinkSpecial);
                    }
                    else
                    {
                        mLinkSpecial = AspxInstances[SiteID];
                    }
                }

            }
            return mLinkSpecial;

            //string rawKey = string.Concat("LinkTagsGetAspxInstance", SiteID);
            //TagsLink.cAspxHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<TagsLink.cAspxHref>(rawKey, CacheIInstance);// CacheApp.GetCacheItem(rawKey) as TagsLink.cAspxHref;
            //if (_Instance == null)
            //{
            //    _Instance = new TagsLink.cAspxHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); // CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;

        }

        private Dictionary<int, ILinkTags> ReWriteInstances = new Dictionary<int, ILinkTags>();//所有站点连接对象
        /// <summary>
        /// 为生成页面时调用的动态url
        /// </summary>
        /// <returns></returns>
        override public ILinkTags GetReWriteInstance(int SiteID)
        {
            ILinkTags mLinkTags;

            if (ReWriteInstances.ContainsKey(SiteID))
                mLinkTags = ReWriteInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!ReWriteInstances.ContainsKey(SiteID))
                    {
                        mLinkTags = new TagsLink.cReWriteHref(SiteID);
                        ReWriteInstances.Add(SiteID, mLinkTags);
                    }
                    else
                    {
                        mLinkTags = ReWriteInstances[SiteID];
                    }
                }

            }
            return mLinkTags;

            //string rawKey = string.Concat("LinkTagsGetReWriteInstance", SiteID);
            //TagsLink.cReWriteHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<TagsLink.cReWriteHref>(rawKey, CacheIInstance);// CacheApp.GetCacheItem(rawKey) as TagsLink.cReWriteHref;
            //if (_Instance == null)
            //{
            //    _Instance = new TagsLink.cReWriteHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); // CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;
        }

        private Dictionary<int, ILinkTags> AutoHtmlInstances = new Dictionary<int, ILinkTags>();//所有站点连接对象
        override protected ILinkTags GetAutoHtmlInstance(int SiteID)
        {
            ILinkTags mLinkTags;

            if (AutoHtmlInstances.ContainsKey(SiteID))
                mLinkTags = AutoHtmlInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!AutoHtmlInstances.ContainsKey(SiteID))
                    {
                        mLinkTags = new TagsLink.cAutoHtmlHref(SiteID);
                        AutoHtmlInstances.Add(SiteID, mLinkTags);
                    }
                    else
                    {
                        mLinkTags = AutoHtmlInstances[SiteID];
                    }
                }

            }
            return mLinkTags;

            //string rawKey = string.Concat("LinkTagsGetAutoHtmlInstance", SiteID);
            //TagsLink.cAutoHtmlHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<TagsLink.cAutoHtmlHref>(rawKey, CacheIInstance);//CacheApp.GetCacheItem(rawKey) as TagsLink.cAutoHtmlHref;
            //if (_Instance == null)
            //{
            //    _Instance = new TagsLink.cAutoHtmlHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); // CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;
        }
    }
    #endregion

    #region  实现其他连接实例

    public class LinkOrther : IInstance<ILinkOrther>
    {
        private static object _SyncRoot = new object();
        public static readonly LinkOrther Instance = new LinkOrther();
        override public ILinkOrther GetInstance(int SiteID)
        {

            LinkType lt = BLL.Sites.Instance.GetLinkTypeOrther(SiteID);// Base.Configs.SysConfigs.ConfigsControl.Instance.Linktype;
            ILinkOrther _Instance;
            if (LinkType.Html == lt)
            {
                _Instance = GetHtmlInstance(SiteID, false);
            }
            else if (LinkType.Aspx == lt)
            {
                _Instance = GetAspxInstance(SiteID);
            }
            else if (LinkType.AutoHtml == lt)
            {
                _Instance = GetAutoHtmlInstance(SiteID);
            }
            else
            {
                _Instance = GetReWriteInstance(SiteID);
            }
            return _Instance;

        }
        override public ILinkOrther GetMainInstance
        {
            get
            {
                return GetInstance(1);
            }

        }
        private Dictionary<string, ILinkOrther> HtmlInstances = new Dictionary<string, ILinkOrther>();//所有站点连接对象
        override protected ILinkOrther GetHtmlInstance(int SiteID, bool isShowDefault)
        {
            string key = string.Concat(SiteID, isShowDefault);
            ILinkOrther mLinkOrther;

            if (HtmlInstances.ContainsKey(key))
                mLinkOrther = HtmlInstances[key];
            else
            {
                lock (_SyncRoot)
                {
                    if (!HtmlInstances.ContainsKey(key))
                    {
                        OrtherLink.cHtmlHref htmlhref = new OrtherLink.cHtmlHref(SiteID);
                        htmlhref.isShowDefault = isShowDefault;
                        mLinkOrther = htmlhref;
                        HtmlInstances.Add(key, mLinkOrther);
                    }
                    else
                    {
                        mLinkOrther = HtmlInstances[key];
                    }
                }

            }
            return mLinkOrther;

            //string rawKey = string.Concat("LinkOrtherGetHtmlInstance", SiteID, "-", isShowDefault);
            //OrtherLink.cHtmlHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<OrtherLink.cHtmlHref>(rawKey, CacheIInstance);//CacheApp.GetCacheItem(rawKey) as OrtherLink.cHtmlHref;
            //if (_Instance == null)
            //{
            //    OrtherLink.cHtmlHref htmlhref = new OrtherLink.cHtmlHref(SiteID);
            //    htmlhref.isShowDefault = isShowDefault;
            //    _Instance = htmlhref;
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); //CacheApp.AddCacheItem(rawKey, htmlhref);
            //}
            //return _Instance;
        }

        /// <summary>
        /// 为生成页面保存目录调用,只返回目录生成页面时要加上绝对路径与文件名称
        /// </summary>
        /// <returns></returns>
        override public ILinkOrther GetHtmlInstance(int SiteID)
        {
            return GetHtmlInstance(SiteID, true);
        }

        private Dictionary<int, ILinkOrther> AspxInstances = new Dictionary<int, ILinkOrther>();//所有站点连接对象
        /// <summary>
        /// 为生成页面时调用的动态url
        /// </summary>
        /// <returns></returns>
        override public ILinkOrther GetAspxInstance(int SiteID)
        {
            ILinkOrther mLinkTags;

            if (AspxInstances.ContainsKey(SiteID))
                mLinkTags = AspxInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!AspxInstances.ContainsKey(SiteID))
                    {
                        mLinkTags = new OrtherLink.cAspxHref(SiteID);
                        AspxInstances.Add(SiteID, mLinkTags);
                    }
                    else
                    {
                        mLinkTags = AspxInstances[SiteID];
                    }
                }

            }
            return mLinkTags;

            //string rawKey = string.Concat("LinkOrtherGetAspxInstance", SiteID);
            //OrtherLink.cAspxHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<OrtherLink.cAspxHref>(rawKey, CacheIInstance); //CacheApp.GetCacheItem(rawKey) as OrtherLink.cAspxHref;
            //if (_Instance == null)
            //{
            //    _Instance = new OrtherLink.cAspxHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); // CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;

        }

        private Dictionary<int, ILinkOrther> ReWriteInstances = new Dictionary<int, ILinkOrther>();//所有站点连接对象
        /// <summary>
        /// 为生成页面时调用的动态url
        /// </summary>
        /// <returns></returns>
        override public ILinkOrther GetReWriteInstance(int SiteID)
        {
            ILinkOrther mLinkTags;

            if (ReWriteInstances.ContainsKey(SiteID))
                mLinkTags = ReWriteInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!ReWriteInstances.ContainsKey(SiteID))
                    {
                        mLinkTags = new OrtherLink.cReWriteHref(SiteID);
                        ReWriteInstances.Add(SiteID, mLinkTags);
                    }
                    else
                    {
                        mLinkTags = ReWriteInstances[SiteID];
                    }
                }

            }
            return mLinkTags;

            //string rawKey = string.Concat("LinkOrtherGetReWriteInstance", SiteID);
            //OrtherLink.cReWriteHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<OrtherLink.cReWriteHref>(rawKey, CacheIInstance);// CacheApp.GetCacheItem(rawKey) as OrtherLink.cReWriteHref;
            //if (_Instance == null)
            //{
            //    _Instance = new OrtherLink.cReWriteHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); //CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;
        }

        private Dictionary<int, ILinkOrther> AutoHtmlInstances = new Dictionary<int, ILinkOrther>();//所有站点连接对象

        override protected ILinkOrther GetAutoHtmlInstance(int SiteID)
        {

            ILinkOrther mLinkTags;

            if (AutoHtmlInstances.ContainsKey(SiteID))
                mLinkTags = AutoHtmlInstances[SiteID];
            else
            {
                lock (_SyncRoot)
                {
                    if (!AutoHtmlInstances.ContainsKey(SiteID))
                    {
                        mLinkTags = new OrtherLink.cAutoHtmlHref(SiteID);
                        AutoHtmlInstances.Add(SiteID, mLinkTags);
                    }
                    else
                    {
                        mLinkTags = AutoHtmlInstances[SiteID];
                    }
                }

            }
            return mLinkTags;

            //string rawKey = string.Concat("LinkOrtherGetAutoHtmlInstance", SiteID);
            //OrtherLink.cAutoHtmlHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<OrtherLink.cAutoHtmlHref>(rawKey, CacheIInstance);// CacheApp.GetCacheItem(rawKey) as OrtherLink.cAutoHtmlHref;
            //if (_Instance == null)
            //{
            //    _Instance = new OrtherLink.cAutoHtmlHref(SiteID);
            //    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, CacheDuration, ETimeSpanModel.秒, CacheIInstance); // CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;
        }
    }
    #endregion

    #region 移动版连接实例
    public class LinkMobile
    {
        private static IMobileHref _Instance;
        private static object _SyncRoot = new object();

        private static IMobileHref _InstanceAspx;

        static public IMobileHref Instance(int SiteID)
        {
            string rawKey = string.Concat("MobileInstance", SiteID);
            cMReWriteHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<cMReWriteHref>(rawKey, "ml");// as cMReWriteHref;
            if (_Instance == null)
            {
                lock (_SyncRoot)
                {
                    _Instance = new cMReWriteHref(SiteID);
                    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, 1, ETimeSpanModel.T, "ml");
                }
            }
            return _Instance;
        }
        static public IMobileHref InstanceAspx(int SiteID)
        {
            //if (_InstanceAspx == null)
            //{
            //    lock (_SyncRoot)
            //    {
            //        _InstanceAspx = new cMAspxHref(SiteID);
            //    }

            //}
            //return _InstanceAspx;

            string rawKey = string.Concat("MobileInstanceAspx", SiteID);
            cMAspxHref _Instance = EbSite.Base.Host.CacheRawApp.GetCacheItem<cMAspxHref>(rawKey, "ml");// as cMAspxHref;
            if (_Instance == null)
            {
                lock (_SyncRoot)
                {
                    _Instance = new cMAspxHref(SiteID);
                    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, 1, ETimeSpanModel.T, "ml");
                }
            }
            return _Instance;
        }
    }
    #endregion


}
