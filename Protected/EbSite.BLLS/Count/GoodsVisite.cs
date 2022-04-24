using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.BLL;
using EbSite.BLL.Count.Strategy;

namespace EbSite.BLL.Count
{
    /// <summary>
    /// 记录用户对内容页面的访问记录
    /// </summary>
    public class GoodsVisite : CountBase
    {
        public static readonly GoodsVisite Instance = new GoodsVisite();
        public override string sCacheKey  //每类统计要重写不同的sCacheKey
        {
            get
            {
                return "GoodsVisiteCount";
            }
        }
        public GoodsVisite()
        {
         
        }
       
        public int ClassID = 0;
        /// <summary>
        /// 缓存过期时把当前统计的数据更新到数据库,不同的统计要重写此办法
        /// </summary>
        public override void UpdateHitsToDataBase(object obHits)
        {
            if (object.Equals(obHits, null)) return;
            lock (LockForItemRemovedFromCacheHits)
            {
                List<Entity.goods_visite> htCurrentHits = obHits as List<Entity.goods_visite>;
                if (!Equals(htCurrentHits, null))
                {
                    if (htCurrentHits.Count > 0)
                    {
                        foreach (Entity.goods_visite model in htCurrentHits)
                        {
                            AddToPool(model);

                        }

                        
                    }
                }
            }
        }

        override protected object AddToDb(object model)
        {
          Entity.goods_visite md=  model as Entity.goods_visite;
            if (!Equals(md, null))
            {
                EbSite.BLL.goods_visite.Instance.AddVisite(md);


            }
              

            return 1;
        }
        private List<Entity.goods_visite> GetCurrentCacheObj
        {
            get
            {

                if (HttpRuntime.Cache.Get(sCacheKey) != null)
                {
                    return HttpRuntime.Cache.Get(sCacheKey) as List<Entity.goods_visite>;
                }
                else
                {
                    //return new List<Entity.goods_visite>();
                    return null;
                }
            }
             

        }

        /// <summary>
        /// 这个与众不同，所以重写了
        /// </summary>
        override public void AddNum()
        {
          
            lock (LockForAddHits)
            {
                List<Entity.goods_visite> _GetCurrentCacheObj = GetCurrentCacheObj;
                if(Equals(_GetCurrentCacheObj, null))
                    _GetCurrentCacheObj = new List<Entity.goods_visite>();
                long ip = EbSite.Core.IpToInt.ConvertIPToLong(Core.Utils.GetClientIP());
                int UserId = EbSite.Base.Host.Instance.UserID;
                if (_GetCurrentCacheObj.Exists(d => d.ContentID == iID && d.ClassID == ClassID&&d.Ip== ip&&d.UserID== UserId))
                {
                    Entity.goods_visite model = _GetCurrentCacheObj.SingleOrDefault(d => d.ContentID == iID && d.ClassID == ClassID && d.Ip == ip && d.UserID == UserId);

                    if (!Equals(model, null))
                    {
                        model.Count = model.Count + 1;
                        model.NumTime = EbSite.Core.SqlDateTimeInt.GetSecond(DateTime.Now);
                        //model.ClassID = ClassID;
                        
                    }
                }
                else
                {
                    Entity.goods_visite model = new Entity.goods_visite();
                    model.ContentID = iID;
                    model.Count = 1;
                    model.UserID = UserId;//EbSite.Base.Host.Instance.UserID;
                    model.NumTime = EbSite.Core.SqlDateTimeInt.GetSecond(DateTime.Now);
                    model.Ip = ip;//EbSite.Core.IpToInt.ConvertIPToLong(Core.Utils.GetClientIP());
                    model.ClassID = ClassID;
                    _GetCurrentCacheObj.Add(model);
                    //htHit.Add(iID, model);   //添加一条记录的点击
                }

               
                //将当前统计写入到缓存，当缓存过期时一次性更新所有当前点击
                //int Minutes = Base.Configs.SysConfigs.ConfigsControl.Instance.HitsUpdateTimeLength;

                HttpRuntime.Cache.Insert(
                    sCacheKey,
                    _GetCurrentCacheObj,
                    null,
                    DateTime.Now.AddSeconds(1),
                    TimeSpan.Zero,
                    System.Web.Caching.CacheItemPriority.High,
                    onRemove
                    );


            }
        }


    }
}
