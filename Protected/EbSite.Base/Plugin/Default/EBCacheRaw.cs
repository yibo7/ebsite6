using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Static;
using EbSite.Core; 
using EbSite.Entity;
namespace EbSite.Base.Plugin.Default
{
    [Extension("默认缓存处理程序", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class EBCacheRaw : ICache
    {


        public T GetCacheItem<T>(string rawKey, string sCategory) where T : class
        {
            string sKey = GetFullCacheKey(sCategory, rawKey);
            return HttpRuntime.Cache[sKey] as T;
        }
        public void AddCacheItem<T>(string rawKey, T value, double CacheTime, ETimeSpanModel spanModel, string sCategory)
        {
            System.Web.Caching.Cache DataCache = HttpRuntime.Cache;

            // 创建一个依赖项，第一个缓存都使用同一key值(MasterCacheKeyArray[0])的DataCache做依赖项
            //所以清除所有当前缓存，只要删除他们共同的依赖项
            if (DataCache[sCategory] == null)
                DataCache[sCategory] = DateTime.Now;
            DateTime dtSpan;

            if (spanModel == ETimeSpanModel.M)
            {
                dtSpan = DateTime.Now.AddSeconds(CacheTime);
            }
            else if (spanModel == ETimeSpanModel.FZ)
            {
                dtSpan = DateTime.Now.AddMinutes(CacheTime);
            }
            else if (spanModel == ETimeSpanModel.XS)
            {
                dtSpan = DateTime.Now.AddHours(CacheTime);
            }
            else if (spanModel == ETimeSpanModel.T)
            {
                dtSpan = DateTime.Now.AddDays(CacheTime);
            }
            else
            {
                dtSpan = DateTime.Now.AddSeconds(CacheTime);
            }
            System.Web.Caching.CacheDependency dependency = new System.Web.Caching.CacheDependency(null, new[] { sCategory });
            DataCache.Insert(
                  GetFullCacheKey(sCategory, rawKey),
                  value,
                  dependency,
                  dtSpan,
                  TimeSpan.Zero,
                  System.Web.Caching.CacheItemPriority.High,
                  onRemove
                  );
        }

        private void ItemRemovedFromCache(string key, object value, CacheItemRemovedReason reason)
        {
            //TimerOutEventArgs toea = new TimerOutEventArgs();
            //toea.ValueKey = key;
            //toea.Value = value;

            //OnUccIndexPageLoadEvent(reason, toea);
        }

        public void InvalidateCache(string sCategory)
        {
            // 清除依赖项
            HttpRuntime.Cache.Remove(sCategory);
        }
        public void Remove(string sCategory,string sKey)
        {
            HttpRuntime.Cache.Remove(sKey);
        }

        public void Clear()
        {
            string ConfigPath = HttpContext.Current.Request.PhysicalApplicationPath + "web.config";
            File.SetLastWriteTimeUtc(ConfigPath, DateTime.UtcNow);
        }
        //public  List<EbSite.Entity.ListItemModel> GetCacheKeys
        //{
        //    get
        //    {
        //        List<EbSite.Entity.ListItemModel> lst = new List<EbSite.Entity.ListItemModel>();
        //        IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();

        //        while (CacheEnum.MoveNext())
        //        {
        //            EbSite.Entity.ListItemModel md = new ListItemModel(CacheEnum.Key.ToString(), CacheEnum.Value.ToString());
        //            lst.Add(md);

        //        }
        //        return lst;
        //    }
        //}
        public List<string> GetCacheKeys
        {
            get
            {
                List<string> lst = new List<string>();
                IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();

                while (CacheEnum.MoveNext())
                {

                    lst.Add(CacheEnum.Key.ToString());

                }
                return lst;
            }
        }

        protected CacheItemRemovedCallback onRemove = null;
        private string GetFullCacheKey(string sCategory, string cacheKey)
        {
            return string.Concat(sCategory, "_", cacheKey);
        }

        #region 对插件底层接口的实现

        public ExtensionSettings GetSettings()
        {

            string sSettingsName = this.GetType().FullName;



            ExtensionSettings settings = new ExtensionSettings(sSettingsName);


            //settings.AddParameter("Description", "条款", 300, true, true, ParameterType.StringMax);
            //settings.AddParameter("ImgUpload", "图片上传", 300, true, true, ParameterType.Upload);
            //settings.Help = ConfigHelpHtml;
            ////是否单个
            //settings.IsScalar = true;

            PluginManager.Instance.ImportSettings(settings);

            return PluginManager.Instance.GetSettings(sSettingsName);

        }
        private Host HostApi;
        private ExtensionSettings ConfigString;
        /// <summary>
        /// 初始化插件。这是类调用的第一个方法。
        /// </summary>
        /// <param name="host">提供了访问主系统的api</param>
        /// <param name="config">Configuration string for the plugin.</param>
        public void Init(Host host, ExtensionSettings config)
        {
            this.HostApi = host;
            ConfigString = config;

            //ConfigString.GetSingleValue("Description");

            onRemove = new CacheItemRemovedCallback(ItemRemovedFromCache);
        }

        /// <summary>
        /// 注销插件后将调用此办法
        /// </summary>
        public void Shutdown()
        {

        }

        /// <summary>
        /// HTML文本显示为插件的帮助配置信息
        /// </summary>
        public string ConfigHelpHtml
        {
            get
            {
                return @"
<div>
  <b>使用帮助:</b><br/>
  <ul>
    <li>在后台安装后，可以在系统的配置里选择。</li>
  </ul>
</div>
      ";
            }
        }

        #endregion

    }

}
