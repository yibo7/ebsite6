using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Core;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类TagRelateClass 的摘要说明。
	/// </summary>
	public class TagRelateClass
	{
        const double cachetime = 60.0;
        private const string CacheTagRelateClass = "trclass";// private static readonly string[] MasterCacheKeyArray = { "SpecialNews" };
       //private static CacheManager bllCache;
       //static TagRelateClass()
       // {
       //     if (Equals(bllCache, null))
       //     {
       //         bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
       //     }
       // }

       #region 成员方法


       /// <summary>
       /// 是否存在该记录
       /// </summary>
       static public bool Exists(int id)
       {
           return DbProviderCms.GetInstance().TagRelateClass_Exists(id);
       }
       /// <summary>
       /// 增加一条数据
       /// </summary>
       static public int Add(EbSite.Entity.TagRelateClass model)
       {

           //Host.CacheApp.InvalidateCache(CacheTagRelateClass); 
           return DbProviderCms.GetInstance().TagRelateClass_Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       static public void Update(EbSite.Entity.TagRelateClass model)
       {
           DbProviderCms.GetInstance().TagRelateClass_Update(model);
           Host.CacheApp.InvalidateCache(CacheTagRelateClass);  //bllCache.InvalidateCache();
       }
       /// <summary>
       /// 删除一条数据
       /// </summary>
       static public void Delete(EbSite.Entity.TagRelateClass model)
       {
           DbProviderCms.GetInstance().TagRelateClass_Delete(model.id);

           Host.CacheApp.InvalidateCache(CacheTagRelateClass);//bllCache.InvalidateCache();
       }
       #endregion


		#region  自定义方法
       static public void DeleteByRemove(string ReserveIDs, int iClassID)
       {
           DbProviderCms.GetInstance().TagRelateClass_DeleteByRemove(ReserveIDs, iClassID);
       }
		#endregion  自定义方法
	}
}

