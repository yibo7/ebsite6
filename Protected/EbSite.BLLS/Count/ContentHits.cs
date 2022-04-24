using System;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using EbSite.BLL;
using EbSite.BLL.Count.Strategy;
using EbSite.Core.Strings;

namespace EbSite.BLL.Count
{
    /// <summary>
    /// 添加内容点击数
    /// </summary>
    public class ContentHits : ContentBase
    {
        

        public ContentHits(int _ClassID)
            : base(_ClassID)
        {
            
         
        }
        public static ContentHits Instance(int ClassID)
        {
            //可以优化，减少创建
            return new ContentHits(ClassID);
        }

        /// <summary>
        /// 对过期的点击清零，及更新最后点击时间,由子类重写实现
        /// </summary>
        protected override void ResetHits()
        {
          if (cConvert.DateDiff("month", MonthHitsLastTime, DateTime.Today) > 1)
            {
                //对内容表里的月点击清零
                NewsContentInst.ResetHits("m");

                //更新本月最点击时间
                Base.Configs.CustumData.ConfigsControl.Instance.MonthHitsLastTime = DateTime.Today;
                Base.Configs.CustumData.ConfigsControl.SaveConfig();

                //base.UpdateMonthHitsLastDate();
            }
            if (cConvert.DateDiff("week", WeekHitsLastTime, DateTime.Today)>1)
            {
                //对内容表里的本周点击清零
                NewsContentInst.ResetHits("w");

                //更新本周点击时间
                Base.Configs.CustumData.ConfigsControl.Instance.WeekHitsLastTime = DateTime.Today;
                Base.Configs.CustumData.ConfigsControl.SaveConfig();

                //base.UpdateWeekHitsLastDate();
            }

            if (cConvert.DateDiff("day", DayHitsLastTime, DateTime.Today) > 1)
            {
                //对内容表里的本周点击清零
                NewsContentInst.ResetHits("d");
                //更新今天最后点击时间
                Base.Configs.CustumData.ConfigsControl.Instance.DayHitsLastTime = DateTime.Today;
                Base.Configs.CustumData.ConfigsControl.SaveConfig();

                //base.UpdateDayHitsLastDate();
            }
        }
        override public void AddNum()
        {
            //对过期的点击清零，及更新最后点击时间
            ResetHits();
            //开防作弊策略,策略模式

            if (IsOpenStrategy())
            {
                if (!StrategyFactory.CreateInstance().IsAllowAdd()) return;
            }
            lock (LockForAddHits)
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
                int Minutes = Base.Configs.SysConfigs.ConfigsControl.Instance.HitsUpdateTimeLength;
                HttpRuntime.Cache.Insert(
                    sCacheKey,
                    htHit,
                    null,
                    DateTime.Now.AddSeconds(1),
                    TimeSpan.Zero,
                    System.Web.Caching.CacheItemPriority.High,
                    onRemove
                    );


            }
        }

        override protected object AddToDb(object model)
        {
            DictionaryEntry de = (DictionaryEntry)model;
            if (!Equals(de, null) && !string.IsNullOrEmpty(de.Key.ToString()))
                NewsContentInst.AddHits(int.Parse(de.Key.ToString()), int.Parse(de.Value.ToString()));

            return 1;
        }
        /// <summary>
        /// 缓存过期时把当前统计的数据更新到数据库,不同的统计要重写此办法
        /// </summary>
        public override void UpdateHitsToDataBase( object obHits)
        {
            if (object.Equals(obHits, null)) return;
            lock (LockForItemRemovedFromCacheHits)
            {
                Hashtable htCurrentHits = obHits as Hashtable;
                if (!object.Equals(htCurrentHits, null))
                {
                    if (htCurrentHits.Count > 0)
                    {
                        foreach (DictionaryEntry de in htCurrentHits)
                        { 
                            //放入池中的队列操作，可以减轻数据库的写入操作
                            AddToPool(de);
                            //NewsContentInst.AddHits(int.Parse(de.Key.ToString()), int.Parse(de.Value.ToString()));
                        }
                    }
                }
            }
        }

     
    }
}
