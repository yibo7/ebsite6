using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Amib.Threading;
using EbSite.Base;
using EbSite.Base.Static; 

namespace EbSite.Core.RedisUtils
{
    public delegate object GetObj();

    public class CacheRedisAsyncModel
    {
        private GetObj GetObjMemthro;
        private string sKey = string.Empty;
        private RedisHelper dbRedis;
        private string sKeySpace = string.Empty;
        private double CacheTime = 1;
        private ETimeSpanModel spanModel = ETimeSpanModel.XS;
        public string sKeyTime = string.Empty;
        public CacheRedisAsyncModel(RedisHelper _dbRedis,string _sKeySpace, string _sKey, double _CacheTime, ETimeSpanModel _spanModel, GetObj _GetObjMemthro)
        {
            GetObjMemthro = _GetObjMemthro;
            sKey = _sKey;
            dbRedis = _dbRedis;
            sKeySpace = _sKeySpace;
            sKeyTime = string.Concat(_sKey, "expire");

            CacheTime = _CacheTime;
            spanModel = _spanModel;

        }
        public object UpdateData(object o)
        {
            object obExpireDate = dbRedis.LTGetObj(sKeySpace, sKeyTime);
            if (Equals(obExpireDate, null))
            {
                object mdObj = GetObjMemthro();
                if (!Equals(mdObj, null))
                {
                    dbRedis.LTSaveObj(sKeySpace, sKey, mdObj);
                    UpdateExpire();
                }
            }

            return 1;

        }

        public void UpdateExpire()
        {
            //并保存过期策略
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
            dbRedis.LTSaveObj(sKeySpace, sKeyTime, DateTime.Now, ts);
        }
    }

      /// <summary>
        /// 基于Redis数据库的数据缓存
        /// </summary>
     public class CacheRedisAsync
    {
        private string sHost = "xsrds1";
        private RedisHelper dbRedis;
        /// <summary>
        /// 创建一个缓存实例
        /// </summary>
        /// <param name="_dbRedis">redis实例对象</param>
        /// <param name="ServerIndex">服务器，因为在redis实例里可以设置一组服务器，这里可以指定当前缓存使用服务器是哪台</param>
        public CacheRedisAsync(RedisHelper _dbRedis, int ServerIndex)
        {
            dbRedis = _dbRedis;
            sHost = string.Concat("eb", ServerIndex);
        }
        public CacheRedisAsync(RedisHelper _dbRedis)
        {
            dbRedis = _dbRedis;

        }

        public  T GetCacheItem<T>(string rawKey, string sCategory, double CacheTime, ETimeSpanModel spanModel, GetObj getObj) where T : class
        { 
            T model = dbRedis.LTGetObj(sHost, rawKey) as T;
            CacheRedisAsyncModel upModel = new CacheRedisAsyncModel(dbRedis, sHost, rawKey, CacheTime, spanModel, getObj);
            if (!Equals(model, null))
            {
                //ThreadPool.SetMaxThreads(3, 3);
                ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(upModel.UpdateData));
                //ThreadPoolManager.stThreadPool.QueueUserWorkItem(new WaitCallback(upModel.UpdateData));
            }
            else //如果不存在，第一次获取，并永久保存在缓存
            {
                model = getObj() as T;
                dbRedis.LTSaveObj(sHost, rawKey, model);
                upModel.UpdateExpire();
            }
            

            return model;
        }

         
    }

    
}