using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using EbSite.Base.Static;
using fastJSON;
using STSdb4.Database;

namespace EbSite.Core.EbCache
{
    public class STSdbCache: CacheBase
    {
        private CacheBll dbBll;
        public STSdbCache(double dCacheDuration, string[] aMasterCacheKeyArray, ETimeSpanModel esm)
            : base(dCacheDuration, aMasterCacheKeyArray, esm)
        {
            dbBll = new CacheBll(aMasterCacheKeyArray[0]);
        }
      
        public override void AddCacheItem<T2>(string rawKey, T2 value)
        {
            AddCacheItem<T2>(rawKey, value, CacheTimeLen, TimeModel);

        }
        override public void AddCacheItem<T2>(string rawKey, T2 value, double CacheTime, ETimeSpanModel spanModel)
        {

            if (!string.IsNullOrEmpty(rawKey) && !Equals(value, null))
            {
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
                CacheEntity md = new CacheEntity();
                md.Id = GetFullCacheKey(rawKey);
                md.ClassKey = MasterCacheKeyArray[0];
                md.ExpTime = dtSpan;
                if (typeof (T2) == typeof (string))
                {
                    md.Model = value.ToString();
                }
                else
                {
                    md.Model = JSON.ToJSON(value);
                }

                dbBll.InsertOne(md);
            }
            else
            {
                throw new Exception("缓存的键值为空，或者缓存的对象为null,不能写入缓存！");
            }
            
        }
         
        override public T2 GetCacheItem<T2>(string rawKey)
        {
            if (!string.IsNullOrEmpty(rawKey))
            {
                string fullkey = GetFullCacheKey(rawKey);
                CacheEntity md = dbBll.GetEntity(fullkey);
                if (!Equals(md, null))
                {
                    T2 obj = null;
                    if (typeof (T2) == typeof (string))
                    {
                        obj = (T2)(object)md.Model;
                    }
                    else
                    {
                        try
                        {
                            obj = JSON.ToObject<T2>(md.Model);
                        }
                        catch (Exception e)
                        {
                            Utils.TestDebug(md.Model);
                            throw new Exception("转换对象不成功：" + e.Message);
                        }
                        
                    }
                     
                    if (DateTime.Compare(DateTime.Now, md.ExpTime)>0)
                    {
                        dbBll.DeleteOne(fullkey);
                        TimerOutEventArgs toea = new TimerOutEventArgs();
                        toea.ValueKey = fullkey;
                        toea.Value = obj;
                        OnUccIndexPageLoadEvent(md, toea);
                    }
                    else
                    {
                        return obj;
                    }
                }

            }
            return null;
        }

        override public void InvalidateCache()
        {
            // 清除依赖项

            dbBll.ClearByClass(MasterCacheKeyArray[0]);

        }
        override public void RemoveACache(string sKey)
        {
            dbBll.DeleteOne(sKey);
        }

        override public void RemoveAllCache()
        {
            dbBll.Clear();
        }

        override public List<Entity.ListItemModel> GetAllCacheList
        {
            get
            {
                throw new NotImplementedException();
            }
        }


    }
}

        