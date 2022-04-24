using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using EbSite.Base.Static;
using EbSite.Entity;

namespace EbSite.Core.EbCache
{
    public class RawCache: CacheBase 
    {
       protected CacheItemRemovedCallback onRemove = null;
       public RawCache(double dCacheDuration, string[] aMasterCacheKeyArray, ETimeSpanModel esm)
            : base(dCacheDuration, aMasterCacheKeyArray, esm)
        {
            onRemove = new CacheItemRemovedCallback(ItemRemovedFromCache);
            
        }

        //override public T GetCacheItem(string rawKey)
        //{
        //    return GetCacheItem<T>(rawKey);
                
        //}

        //override public void AddCacheItem(string rawKey, T value)
        //{
        //    AddCacheItem<T>(rawKey, value);
        //}

        override public T2 GetCacheItem<T2>(string rawKey) 
        {
            return HttpRuntime.Cache[GetFullCacheKey(rawKey)] as T2;
        }

        public override void AddCacheItem<T2>(string rawKey, T2 value)
        {
            AddCacheItem<T2>(rawKey, value,CacheTimeLen, TimeModel);

        }

        override public void AddCacheItem<T2>(string rawKey, T2 value, double CacheTime,ETimeSpanModel spanModel)
        {
            System.Web.Caching.Cache DataCache = HttpRuntime.Cache;

            // 创建一个依赖项，第一个缓存都使用同一key值(MasterCacheKeyArray[0])的DataCache做依赖项
            //所以清除所有当前缓存，只要删除他们共同的依赖项
            if (DataCache[MasterCacheKeyArray[0]] == null)
                DataCache[MasterCacheKeyArray[0]] = DateTime.Now;
            DateTime dtSpan;

            if (spanModel == ETimeSpanModel.秒)
            {
                dtSpan = DateTime.Now.AddSeconds(CacheTime);
            }
            else if (spanModel == ETimeSpanModel.分钟)
            {
                dtSpan = DateTime.Now.AddMinutes(CacheTime);
            }
            else if (spanModel == ETimeSpanModel.小时)
            {
                dtSpan = DateTime.Now.AddHours(CacheTime);
            }
            else if (spanModel == ETimeSpanModel.天)
            {
                dtSpan = DateTime.Now.AddDays(CacheTime);
            }
            else
            {
                dtSpan = DateTime.Now.AddSeconds(CacheTime);
            }
           
            System.Web.Caching.CacheDependency dependency = new System.Web.Caching.CacheDependency(null, MasterCacheKeyArray);
            DataCache.Insert(
                  GetFullCacheKey(rawKey),
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
            TimerOutEventArgs toea = new TimerOutEventArgs();
            toea.ValueKey = key;
            toea.Value = value;

            OnUccIndexPageLoadEvent(reason, toea);
        }

       override public void InvalidateCache()
        {
            // 清除依赖项
            HttpRuntime.Cache.Remove(MasterCacheKeyArray[0]);
        }
       override public  void RemoveACache(string sKey)
        {
            HttpRuntime.Cache.Remove(sKey);
        }

        override public  void RemoveAllCache()
        {
            string ConfigPath = HttpContext.Current.Request.PhysicalApplicationPath + "web.config";
            File.SetLastWriteTimeUtc(ConfigPath, DateTime.UtcNow);
        }

        override public  List<Entity.ListItemModel> GetAllCacheList
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

        