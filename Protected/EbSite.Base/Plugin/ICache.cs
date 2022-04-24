using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.Plugin.Base;
using EbSite.Base.Static;
using EbSite.Entity;

namespace EbSite.Base.Plugin
{
    public interface ICache : IProvider
    {
        /// <summary>
        /// 获取缓存里的一个对象
        /// </summary>
        /// <param name="rawKey">缓存的KEY</param>
        /// <param name="sCategory">类别</param>
        /// <returns></returns>
        T GetCacheItem<T>(string rawKey, string sCategory) where T : class;
        /// <summary>
        /// 添加一个缓存项
        /// </summary>
        /// <typeparam name="T">要缓存的对象类型</typeparam>
        /// <param name="rawKey">缓存键</param>
        /// <param name="value">要缓存的对象</param>
        /// <param name="cachetime">时间值</param>
        /// <param name="esm">时间间隔类型</param>
        /// <param name="sCategory">类别</param>
        void AddCacheItem<T>(string rawKey, T value, double cachetime, ETimeSpanModel esm, string sCategory);
        /// <summary>
        /// 清理某个类别下的缓存
        /// </summary>
        void InvalidateCache(string sCategory);
        /// <summary>
        /// 删除一个缓存
        /// </summary>
        /// <param name="sKey">缓存键值</param>
        void Remove(string sCategory,string sKey);
        /// <summary>
        /// 清除所有缓存
        /// </summary>
        void Clear();
        /// <summary>
        /// 获取缓存所有键值
        /// </summary>
        List<string> GetCacheKeys { get; }
    }
}
