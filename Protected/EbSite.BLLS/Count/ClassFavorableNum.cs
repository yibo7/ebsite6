using System;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using EbSite.BLL;

namespace EbSite.BLL.Count
{
    /// <summary>
    /// 添加收藏数
    /// </summary>
    public class ClassFavorableNum : CountBase
    {
        public static readonly ClassFavorableNum Instance = new ClassFavorableNum();
        public override string sCacheKey  //每类统计要重写不同的sCacheKey
        {
            get
            {
                return "CountFavorableNum";
            }
        }
        public ClassFavorableNum()
        {
            
        }
        override protected object AddToDb(object model)
        {
            DictionaryEntry de = (DictionaryEntry)model;
            if (!Equals(de, null) && !string.IsNullOrEmpty(de.Key.ToString()))
                NewsClass.AddFavorableNum(int.Parse(de.Key.ToString()), int.Parse(de.Value.ToString()));

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
                            //NewsClass.AddFavorableNum(int.Parse(de.Key.ToString()), int.Parse(de.Value.ToString()));
                        }
                    }
                }
            }
        }
    }
}
