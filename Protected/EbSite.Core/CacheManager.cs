using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using EbSite.Base.Static;
using EbSite.Entity;


namespace EbSite.Core
{
    public class CacheRaw
    {

        private double CacheDuration = 60.0;
        private string[] MasterCacheKeyArray;
        /// <summary>
        /// 缓存类
        /// </summary>
        /// <param name="dCacheDuration">缓存时间，单位为秒</param>
        /// <param name="aMasterCacheKeyArray"></param>
        public CacheRaw(double dCacheDuration, string[] aMasterCacheKeyArray)
        {

            CacheDuration = dCacheDuration;
            MasterCacheKeyArray = aMasterCacheKeyArray;
        }
        public CacheRaw(string[] aMasterCacheKeyArray)
        {
            MasterCacheKeyArray = aMasterCacheKeyArray;
        }
        private string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKeyArray[0], "-", cacheKey);
        }
        public object GetCacheItem(string rawKey)
        {
            return HttpRuntime.Cache[GetCacheKey(rawKey)];
        }
        /// <summary>
        /// 添加缓存项
        /// </summary>
        /// <param name="rawKey">缓存键</param>
        /// <param name="value">缓存对象</param>
        /// <param name="cachetime">缓存时间</param>
        /// <param name="spanModel">时间模式</param>
        public void AddCacheItem(string rawKey, object value, double cachetime, ETimeSpanModel spanModel)
        {
            System.Web.Caching.Cache DataCache = HttpRuntime.Cache;

            // 创建一个依赖项，第一个缓存都使用同一key值(MasterCacheKeyArray[0])的DataCache做依赖项
            //所以清除所有当前缓存，只要删除他们共同的依赖项
            if (DataCache[MasterCacheKeyArray[0]] == null)
                DataCache[MasterCacheKeyArray[0]] = DateTime.Now;
            DateTime dtSpan;

            if (spanModel == ETimeSpanModel.M)
            {
                dtSpan = DateTime.Now.AddSeconds(cachetime);
            }
            else if (spanModel == ETimeSpanModel.FZ)
            {
                dtSpan = DateTime.Now.AddMinutes(cachetime);
            }
            else if (spanModel == ETimeSpanModel.XS)
            {
                dtSpan = DateTime.Now.AddHours(cachetime);
            }
            else if (spanModel == ETimeSpanModel.T)
            {
                dtSpan = DateTime.Now.AddDays(cachetime);
            }
            else
            {
                dtSpan = DateTime.Now.AddSeconds(cachetime);
            }

            // 添加缓存依赖项
            System.Web.Caching.CacheDependency dependency = new System.Web.Caching.CacheDependency(null, MasterCacheKeyArray);
            DataCache.Insert(GetCacheKey(rawKey), value, dependency, dtSpan, System.Web.Caching.Cache.NoSlidingExpiration);
        }
        public void AddCacheItem(string rawKey, object value)
        {
            AddCacheItem(rawKey, value, CacheDuration, ETimeSpanModel.M);
            //System.Web.Caching.Cache DataCache = HttpRuntime.Cache;

            //// 创建一个依赖项，第一个缓存都使用同一key值(MasterCacheKeyArray[0])的DataCache做依赖项
            ////所以清除所有当前缓存，只要删除他们共同的依赖项
            //if (DataCache[MasterCacheKeyArray[0]] == null)
            //    DataCache[MasterCacheKeyArray[0]] = DateTime.Now;

            //// 添加缓存依赖项
            //System.Web.Caching.CacheDependency dependency = new System.Web.Caching.CacheDependency(null, MasterCacheKeyArray);
            //DataCache.Insert(GetCacheKey(rawKey), value, dependency, DateTime.Now.AddSeconds(CacheDuration), System.Web.Caching.Cache.NoSlidingExpiration);
        }
        public void InvalidateCache()
        {
            // 清除依赖项
            HttpRuntime.Cache.Remove(MasterCacheKeyArray[0]);
        }
        public static void RemoveACache(string sKey)
        {
            HttpRuntime.Cache.Remove(sKey);
        }

        public static void RemoveAllCache()
        {
            string ConfigPath = HttpContext.Current.Request.PhysicalApplicationPath + "web.config";
            File.SetLastWriteTimeUtc(ConfigPath, DateTime.UtcNow);
            //foreach (IDictionaryEnumerator dictionaryEnumerator in GetAllCacheList)
            //{
            //    RemoveACache(dictionaryEnumerator.Key.ToString());
            //}
        }

        public static List<Entity.ListItemModel> GetAllCacheList
        {
            get
            {
                List<Entity.ListItemModel> lst = new List<Entity.ListItemModel>();
                IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();

                while (CacheEnum.MoveNext())
                {
                    Entity.ListItemModel md = new ListItemModel(CacheEnum.Key.ToString(), CacheEnum.Value.ToString());
                    lst.Add(md);

                }
                return lst;
            }
        }
    }
}
