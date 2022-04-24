//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using EbSite.Base.EntityAPI;
//using EbSite.Base.Static;

//namespace EbSite.Core.EbCache
//{
//    public class TimerOutEventArgs : EventArgs
//    {
//        public string ValueKey { get; set; }
//        public object Value { get; set; }

//    }

//    abstract public class CacheBase
//    {
//        protected double CacheTimeLen = 60.0;
//        protected string MasterCacheKeyArray;
//        protected ETimeSpanModel TimeModel = ETimeSpanModel.M;
//        public event EventHandler<TimerOutEventArgs> TimerOutEvent;
//        protected void OnUccIndexPageLoadEvent(object sender, TimerOutEventArgs arg)
//        {
//            if (!Equals(TimerOutEvent, null))
//            {
//                TimerOutEvent(sender, arg);
//            }
//        }
//        /// <summary>
//        /// 构造
//        /// </summary>
//        /// <param name="dCacheDuration">缓存时间</param>
//        /// <param name="aMasterCacheKeyArray">缓存依赖项</param>
//        /// <param name="esm">过期时间模式</param>
//        public CacheBase(double dCacheDuration, string aMasterCacheKeyArray, ETimeSpanModel esm)
//        {
//            CacheTimeLen = dCacheDuration;
//            MasterCacheKeyArray = aMasterCacheKeyArray;
//            TimeModel = esm;
//        }
//       // /// <summary>
//       // /// 获取缓存里的一个对象
//       // /// </summary>
//       // /// <param name="rawKey">缓存的KEY</param>
//       // /// <returns></returns>
//       //abstract public T GetCacheItem(string rawKey);
//       // /// <summary>
//       // /// 添加一个缓存对象
//       // /// </summary>
//       ///// <param name="rawKey">缓存的KEY</param>
//       // /// <param name="value">对象</param>
//       //abstract public void AddCacheItem(string rawKey, T value);

//       /// <summary>
//       /// 获取缓存里的一个对象
//       /// </summary>
//       /// <param name="rawKey">缓存的KEY</param>
//       /// <returns></returns>
//       abstract public T2 GetCacheItem<T2>(string rawKey) where T2 : class;
//       /// <summary>
//       /// 添加一个缓存对象
//       /// </summary>
//       /// <param name="rawKey">缓存的KEY</param>
//       /// <param name="value">对象</param>
//       abstract public void AddCacheItem<T2>(string rawKey, T2 value);

//       abstract public void AddCacheItem<T2>(string rawKey, T2 value,double cachetime, ETimeSpanModel esm);

//       protected string GetFullCacheKey(string cacheKey)
//       {
//            return string.Concat(MasterCacheKeyArray,"_",  cacheKey);
//       }
//       //protected string GetCacheKey(string fullcacheKey)
//       //{
//       //    return fullcacheKey.Replace(string.Concat(MasterCacheKeyArray[0],"_"),"");
//       //}
//       abstract public void InvalidateCache();

//       abstract public  void RemoveACache(string sKey);

//       abstract public  void RemoveAllCache();

//       abstract public List<ListItemSimple> GetAllCacheList { get; }

       
    
//    }
//}
