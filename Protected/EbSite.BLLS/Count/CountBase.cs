using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

using System.Web;
using System.Web.Caching;
using Amib.Threading;
using EbSite.Base;
using EbSite.BLL.Count.Strategy;

namespace EbSite.BLL.Count
{
    /// <summary>
    /// 模板方法模式,定义一系列固定的办法与属性，变化的由子类重写实现
    /// </summary>
    public abstract class CountBase
    {

        
        //protected HtisModel hisMb = new HtisModel();
        /// <summary>
        /// 记录集，key为记录id,value为当前点击数
        /// </summary>
        protected Hashtable GetCurrentCacheHits
        {
            get
            {

                if (HttpRuntime.Cache.Get(sCacheKey) != null)
                {
                    return HttpRuntime.Cache.Get(sCacheKey) as Hashtable;
                }
                else
                {
                    return new Hashtable();
                }
            }

        }


        #region 清零操作
        /// <summary>
        /// 获取月点击最后点击时间
        /// </summary>
        protected DateTime MonthHitsLastTime = Base.Configs.CustumData.ConfigsControl.Instance.MonthHitsLastTime;
        /// <summary>
        /// 获取周点击最后点击时间
        /// </summary>
        protected DateTime WeekHitsLastTime = Base.Configs.CustumData.ConfigsControl.Instance.WeekHitsLastTime;
        /// <summary>
        /// 获取天点击最后点击时间
        /// </summary>
        protected DateTime DayHitsLastTime = Base.Configs.CustumData.ConfigsControl.Instance.DayHitsLastTime;
        /// <summary>
        /// 对过期的点击清零，及更新最后点击时间,由子类重写实现
        /// </summary>
        protected virtual void ResetHits()
        {
            
        }

        #endregion
        public virtual string sCacheKey  //每类统计要重写不同的sCacheKey
        {
            get
            {
                return "";
            }
        }
        private int _iID;
        /// <summary>
        /// 当前要统计的记录ID
        /// </summary>
        public int iID
        {
            get
            {
                return _iID;
            }
            set
            {
                _iID = value;
            }
        }

        abstract protected  object AddToDb(object model);
        protected void AddToPool(object model)
        {
            IWorkItemResult wir = stPool.QueueWorkItem(new WorkItemCallback(AddToDb), model);
            
        }

       

        //public int ClassID { get; set; }
        /// <summary>
        /// CacheItemRemovedCallback对象
        /// </summary>
       protected  CacheItemRemovedCallback onRemove = null;
        /// <summary>
        /// LockForAddHits锁
        /// </summary>
        protected object LockForAddHits = new object();
        private  SmartThreadPool stPool;
        public CountBase()
        {
            onRemove = new CacheItemRemovedCallback(ItemRemovedFromCache);
            stPool =  new SmartThreadPool(2 * 60 * 1000, 2, 1);//最大2线程，最小1个线程
        }
        /// <summary>
        /// 是否开启防作弊策略
        /// </summary>
        /// <returns></returns>
        public virtual bool IsOpenStrategy()
        {
            return false;
        }
       virtual public  void AddNum()
        {
            //对过期的点击清零，及更新最后点击时间
            ResetHits();
            //开防作弊策略,策略模式

            if (IsOpenStrategy())
            {
                if (!StrategyFactory.CreateInstance().IsAllowAdd()) return;
            }
            lock(LockForAddHits)
            {
                Hashtable htHit = GetCurrentCacheHits;

                if (htHit.ContainsKey(iID))  //检查是否已经存在当前记录的统计数据
                {
                    htHit[iID] = int.Parse(htHit[iID].ToString()) + 1;
                }
                else
                {
                    htHit.Add(iID, 1);   //添加一条记录的点击
                }
                //将当前统计写入到缓存，当缓存过期时一次性更新所有当前点击
                //int Minutes = Base.Configs.SysConfigs.ConfigsControl.Instance.HitsUpdateTimeLength;
                HttpRuntime.Cache.Insert(
                    sCacheKey,
                    htHit,
                    null,
                    DateTime.Now.AddSeconds(30),
                    TimeSpan.Zero,
                    System.Web.Caching.CacheItemPriority.High,
                    onRemove
                    );

                
            }
        }
        /// <summary>
        /// 缓存过期时把当前统计的数据更新到数据库,不同的统计要重写此办法
        /// </summary>
        /// <param name="obHits">缓存项里的hits</param>
        public virtual void UpdateHitsToDataBase(object obHits)
        {
            
        }
        /// <summary>
        /// ItemRemovedFromCacheHits锁
        /// </summary>
        protected object LockForItemRemovedFromCacheHits = new object();
        /// <summary>
        /// 当缓存被移除或过期是触发的回调事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        private void ItemRemovedFromCache(string key, object value, CacheItemRemovedReason reason)
        {
            try
            {
                //如果检查不是Cache.Insert与Cache.Removed触发的，也即是系统自动移除的时候就更新到数据库
                //因为用户每次访问时候都调用Cache.Insert,如果不做这个检查会每个访问都执行更新
                if (CacheItemRemovedReason.Removed != reason) 
               {
                   UpdateHitsToDataBase(value);
                   
               }
                
            }
            catch (Exception ex)
            {
                EbSite.Log.Factory.GetInstance().ErrorLog("统计累加数据出错:" + ex.Message);
                //using (StreamWriter streamWriter = new StreamWriter(ErrorLogFilePth, false))
                //{
                //    streamWriter.Write(string.Format("时间:{0}\r\n描述信息：{1}\r\n", DateTime.Now, ex.Message));
                //    streamWriter.Flush();
                //}
            }
        }
    }
}
