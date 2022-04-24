using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using EbSite.Base;
using EbSite.Base.EntityAPI;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;
using EbSite.Base.Static;
using EbSite.Core; 
using EbSite.Core.FSO;
using EbSite.Core.RedisUtils;

namespace EbSite.Plugin.EBCache
{

    [Extension("官方Redis缓存处理程序", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class CacheRedis : ICache
    {
        //private string sHost = "ebcahe";
        public T GetCacheItem<T>(string rawKey, string sCategory) where T :class
        {
            return dbHelper.LTGetObj(sCategory, rawKey) as T;

            //return dbHelper.Get(GetFullCacheKey(sCategory, rawKey)) as T;
            //if (dbHelper.Exists(rawKey))
            //{
            //    return dbHelper.GetEntity<T>(GetFullCacheKey(sCategory, rawKey));
            //}

            //return null;
           
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
            TimeSpan ts = dtSpan - DateTime.Now;
            dbHelper.LTSaveObj(sCategory, rawKey, value, ts);
            //dbHelper.Set(GetFullCacheKey(sCategory, rawKey), value, ts);
          
        }

        
        public void InvalidateCache(string sCategory)
        {
            
           
        }
        public void Remove(string sCategory, string rawKey)
        {
            dbHelper.LTDelKey(sCategory, rawKey);
            //dbHelper.Remove(GetFullCacheKey(sCategory, rawKey));
        }

        public void Clear()
        {
            //dbHelper.DeleteAll();
        }

        public List<string> GetCacheKeys
        {
            get
            {
                List<string> lst = new List<string>();

                return lst;
                //return dbHelper.GetAllKeys();
            }
        }

         
        //private string GetFullCacheKey(string sCategory, string cacheKey)
        //{
        //    return string.Concat(sCategory, ":", Utils.MD5(cacheKey));
        //}

        private RedisHelper dbHelper;
       //private object lockobj = new object();
       // private RedisHelper dbHelper
       // {
       //     get
       //     {
       //         if (_dbHelper == null)
       //         {
       //             lock (lockobj)
       //             {
       //                 if (_dbHelper == null)
       //                 {
       //                     _dbHelper = InitRedis(); ;

       //                 }
       //             }
       //         } 
       //         return _dbHelper;
       //     }
       // }
        private RedisHelper InitRedis()
        {

            string dbhostwrite = ConfigString.GetSingleValue("dbhostwrite");
            //string dbhostread = ConfigString.GetSingleValue("dbhostread");
            if (!string.IsNullOrEmpty(dbhostwrite))
            {
                string[] aWriteHost = HostApi.HuiCheSplit(dbhostwrite);
                //string[] aReadHost;
                //if (!string.IsNullOrEmpty(dbhostread))
                //{
                //    aReadHost = HostApi.HuiCheSplit(dbhostread);
                //}
                //else
                //{
                //    aReadHost = aWriteHost;
                //}
                return new RedisHelper(aWriteHost);//不再使用读写分开
                //return new RedisHelper(aWriteHost, aReadHost);
            }
            else
            {
                throw new Exception("redis数据库服务器未设置,至少要配置写入数据库主机！");
            }
        }

        #region 对插件底层接口的实现

        public ExtensionSettings GetSettings()
        {

            string sSettingsName = this.GetType().FullName;

            ExtensionSettings settings = new ExtensionSettings(sSettingsName);

            settings.AddParameter("dbhostwrite", "数据库主机", 500, true, true, ParameterType.StringMax);
            //settings.AddParameter("dbhostread", "读取数据库主机", 500, false, false, ParameterType.StringMax);
            //settings.AddParameter("pass", "密码", 300,false, false, ParameterType.String);
            //settings.AddParameter("isopenpool", "是否启用缓存池", 10, false, false, ParameterType.Boolean);

            settings.IsScalar = true;

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
           dbHelper =  InitRedis();


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
    <li>你可以不用配置读取主机，这样，写主机为读写两用，配置格式为:127.0.0.1:6379  每行代表一个主机，如果有密码，可以是pass@127.0.0.1:6379</li>
  </ul>
</div>
      ";
            }
        }

        #endregion
        
    }



}
