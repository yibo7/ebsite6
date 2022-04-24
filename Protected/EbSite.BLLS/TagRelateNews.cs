using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EbSite.Core;
using EbSite.Data.Interface;
using EbSite.Entity;
namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类TagRelateNews 的摘要说明。
	/// </summary>
	 public  class TagRelateNews
	{
        //private static readonly EbSite.DbProviderCms.GetInstance().TagRelateNews_TagRelateNews dal = new EbSite.DbProviderCms.GetInstance().TagRelateNews_TagRelateNews();
         const double cachetime = 60.0;
         private const string CacheTagRelateNews = "tagrelatenews";// private static readonly string[] MasterCacheKeyArray = { "SpecialNews" };
        // private static CacheManager bllCache;
        //static TagRelateNews()
        //{
        //    if (Equals(bllCache, null))
        //    {
        //        bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
        //    }
        //}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		static public  int GetMaxId()
		{
			return DbProviderCms.GetInstance().TagRelateNews_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		static public  bool Exists(int id)
		{
			return DbProviderCms.GetInstance().TagRelateNews_Exists(id);
		}

		

		/// <summary>
		/// 删除一条数据
		/// </summary>
		static public  void Delete(int id)
		{
			DbProviderCms.GetInstance().TagRelateNews_Delete(id);
		}
         /// <summary>
        /// 删除与某条内容脱离关联的记录
        /// </summary>
        /// <param name="ReserveIDs">更新后当前的标签ID</param>
        /// <param name="ContentID">内容ID</param>
       static public void DeleteByRemove(string ReserveIDs, long ContentID)
       {
             DbProviderCms.GetInstance().TagRelateNews_DeleteByRemove(ReserveIDs, ContentID);
       }
       static public string GetTagsByContentID(long ContentID)
       {
           return DbProviderCms.GetInstance().TagRelateNews_GetTagsByContentID(ContentID);
       }
         /// <summary>
       /// 当删除某个标签时同时删除与其关联的数据
         /// </summary>
         /// <param name="TagID"></param>
       static public void DeleteByTagDelete(int TagID)
       {
           DbProviderCms.GetInstance().TagRelateNews_DeleteByTagDelete(TagID);
       }
	    /// <summary>
        /// 增加一条数据
        /// </summary>
        static public int Add(EbSite.Entity.TagRelateNews model)
        {
            return DbProviderCms.GetInstance().TagRelateNews_Add(model);
        }

		#endregion  成员方法
	}
}

