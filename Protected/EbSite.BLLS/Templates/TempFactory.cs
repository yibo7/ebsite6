
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.PageLink;
using EbSite.Base.Static;
using EbSite.Core;

namespace EbSite.BLL
{
    static public class TempFactory
    {
        //public static CacheManager CacheApp;
        //const double cachetime = 1.0;//
        //private const string cachetemp = "tempfactory"; //private static readonly string[] MasterCacheKeyArray = { "GetTemplates" };
        //static TempFactory()
        //{
        //    CacheApp = new CacheManager(CacheDuration, MasterCacheKeyArray);
        //}
       
        //静态工厂方法
        public static TemplatesPC Instance
        {
             get
             {
                 return GetInstance(Base.Host.Instance.CurrentSite.PageTheme);
             }

        }

        public static TemplatesPC GetInstance(string ThemeName)
        {
            return Base.AppStartInit.EbTemplatesPCs[ThemeName];
            //string rawKey = string.Concat("GetTemInstance", ThemeName);
            //TemplatesPC _Instance =EbSite.Base.Host.CacheApp.GetCacheItem<TemplatesPC>(rawKey,cachetemp);
            //if (_Instance == null)
            //{
            //    _Instance = new TemplatesPC(ThemeName);
            //    EbSite.Base.Host.CacheApp.AddCacheItem(rawKey, _Instance, cachetime, ETimeSpanModel.天, cachetemp);
            //    //CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance; 
        }



        //静态工厂方法移动版
        public static TemplatesMobile InstanceMobile
        {
            get
            {
                return GetInstanceMobile(Base.Host.Instance.CurrentSite.MobileTheme);
            }

        }

        public static TemplatesMobile GetInstanceMobile(string ThemeName)
        {
            return Base.AppStartInit.EbTemplatesMobiles[ThemeName];

            //string rawKey = string.Concat("GetTemInstance", ThemeName);
            //TemplatesMobile _Instance = EbSite.Base.Host.CacheApp.GetCacheItem<TemplatesMobile>(rawKey,cachetemp) ;
            //if (_Instance == null)
            //{
            //    _Instance = new TemplatesMobile(ThemeName);
            //    EbSite.Base.Host.CacheApp.AddCacheItem(rawKey, _Instance, cachetime,ETimeSpanModel.天, cachetemp);
            //   // CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;
        }


    }
}
