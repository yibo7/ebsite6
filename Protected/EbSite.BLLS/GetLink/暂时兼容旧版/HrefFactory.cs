
//using EbSite.Base.Configs.SysConfigs;
//using EbSite.Base.PageLink;
//using EbSite.Core;

//namespace EbSite.BLL.GetLink
//{
//    static public class HrefFactory
//    {
//        public static CacheManager CacheApp;
//        const double CacheDuration = 120.0;//
//        private static readonly string[] MasterCacheKeyArray = { "GetLink" };
//        static HrefFactory()
//        {
//            CacheApp = new CacheManager(CacheDuration, MasterCacheKeyArray);
//        }



//        private static object _SyncRoot = new object();
//        //public static ILink _Instance;
//        //静态工厂方法
//        public static ILink GetInstance(int SiteID)
//        {

//            LinkType lt = BLL.Sites.Instance.GetSiteLinkType(SiteID);// Base.Configs.SysConfigs.ConfigsControl.Instance.Linktype;
//             ILink _Instance;
//             if (LinkType.Html == lt)
//             {
//                 _Instance = GetHtmlInstance(SiteID, false);
//             }
//             else if (LinkType.Aspx == lt)
//             {
//                 _Instance = GetAspxInstance(SiteID);
//             }
//             else if (LinkType.AutoHtml == lt)
//             {
//                 _Instance = GetAutoHtmlInstance(SiteID);
//             }
//             else
//             {
//                 _Instance = GetReWriteInstance(SiteID);
//             }
//            return _Instance;

//        }
//        public static ILink GetMainInstance
//        {
//            get
//            {
//                return GetInstance(1);
//            }
            
//        }
//        private static ILink GetHtmlInstance(int SiteID, bool isShowDefault)
//        {
//            string rawKey = string.Concat("GetHtmlInstance", SiteID,"-", isShowDefault);
//            cHtmlHref _Instance = CacheApp.GetCacheItem(rawKey) as cHtmlHref;
//            if (_Instance == null)
//            {
//                cHtmlHref htmlhref = new cHtmlHref(SiteID);
//                htmlhref.isShowDefault = isShowDefault;
//                _Instance = htmlhref;
//                CacheApp.AddCacheItem(rawKey, htmlhref);
//            }
//            return _Instance; 
//        }

//        /// <summary>
//        /// 为生成页面保存目录调用,只返回目录生成页面时要加上绝对路径与文件名称
//        /// </summary>
//        /// <returns></returns>
//        public static ILink GetHtmlInstance(int SiteID)
//        {
//            return GetHtmlInstance(SiteID, true);
//        }
//        /// <summary>
//        /// 为生成页面时调用的动态url
//        /// </summary>
//        /// <returns></returns>
//        public static ILink GetAspxInstance(int SiteID)
//        {
//            string rawKey = string.Concat("GetAspxInstance", SiteID);
//            cAspxHref _Instance = CacheApp.GetCacheItem(rawKey) as cAspxHref;
//            if (_Instance == null)
//            {
//                _Instance = new cAspxHref(SiteID);
//                CacheApp.AddCacheItem(rawKey, _Instance);
//            }
//            return _Instance; 
           
//        }
//        /// <summary>
//        /// 为生成页面时调用的动态url
//        /// </summary>
//        /// <returns></returns>
//        public static ILink GetReWriteInstance(int SiteID)
//        {
//            string rawKey = string.Concat("GetReWriteInstance", SiteID);
//            cReWriteHref _Instance = CacheApp.GetCacheItem(rawKey) as cReWriteHref;
//            if (_Instance == null)
//            {
//                _Instance = new cReWriteHref(SiteID);
//                CacheApp.AddCacheItem(rawKey, _Instance);
//            }
//            return _Instance; 
//            //return new cReWriteHref(SiteID);
//        }
//        private static ILink GetAutoHtmlInstance(int SiteID)
//        {
//            string rawKey = string.Concat("GetAutoHtmlInstance", SiteID);
//            cAutoHtmlHref _Instance = CacheApp.GetCacheItem(rawKey) as cAutoHtmlHref;
//            if (_Instance == null)
//            {
//                _Instance = new cAutoHtmlHref(SiteID);
//                CacheApp.AddCacheItem(rawKey, _Instance);
//            }
//            return _Instance; 
//            //return new cAutoHtmlHref(SiteID);
//        }
//    }
//}
