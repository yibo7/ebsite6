using System;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using EbSite.BLL;
using EbSite.Core.Strings;

namespace EbSite.BLL.Count
{
    /// <summary>
    /// 添加分类点击数
    /// </summary>
    public class ClassHits : CountBase
    {
        public static readonly ClassHits Instance = new ClassHits();
        public override string sCacheKey  //每类统计要重写不同的sCacheKey
        {
            get
            {
                return "ClassHits-CacheKey";
            }
        }
        public ClassHits()
        {
            //base.iID = iID;
            //ResetHits();

        }

        /// <summary>
        /// 对过期的点击清零，及更新最后点击时间,由子类重写实现
        /// </summary>
        protected override void ResetHits()
        {
         if (cConvert.DateDiff("month", MonthHitsLastTime, DateTime.Today) > 1)
            {
             
                //对内容表里的月点击清零
                NewsClass.ResetHits("m");

                //更新本月最点击时间
                Base.Configs.CustumData.ConfigsControl.Instance.MonthHitsLastTime = DateTime.Today;
                Base.Configs.CustumData.ConfigsControl.SaveConfig();

                //base.UpdateMonthHitsLastDate();
            }
            if (cConvert.DateDiff("week", WeekHitsLastTime, DateTime.Today)>1)
            {
                //对内容表里的本周点击清零
                NewsClass.ResetHits("w");

                //更新本周点击时间
                Base.Configs.CustumData.ConfigsControl.Instance.WeekHitsLastTime = DateTime.Today;
                Base.Configs.CustumData.ConfigsControl.SaveConfig();

                //base.UpdateWeekHitsLastDate();
            }

            if (cConvert.DateDiff("day", DayHitsLastTime, DateTime.Today) > 1)
            {
                //对内容表里的本周点击清零
                NewsClass.ResetHits("d");
                //更新今天最后点击时间
                Base.Configs.CustumData.ConfigsControl.Instance.DayHitsLastTime = DateTime.Today;
                Base.Configs.CustumData.ConfigsControl.SaveConfig();

                //base.UpdateDayHitsLastDate();
            }
        }
        override protected object AddToDb(object model)
        {
            DictionaryEntry de = (DictionaryEntry)model;
            if (!Equals(de, null) && !string.IsNullOrEmpty(de.Key.ToString()))
                NewsClass.AddHits(int.Parse(de.Key.ToString()), int.Parse(de.Value.ToString()));

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
                            //NewsClass.AddHits(int.Parse(de.Key.ToString()), int.Parse(de.Value.ToString()));
                        }
                    }
                }
            }
        }

    }
}
