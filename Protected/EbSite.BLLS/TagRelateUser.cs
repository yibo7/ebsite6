using System;
using System.Data;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Data.Interface;
using EbSite.Entity;
namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类TagRelateUser 的摘要说明。
	/// </summary>
	public class TagRelateUser
	{
        //private static readonly EbSite.DbProviderCms.GetInstance().TagRelateUser_TagRelateUser dal = new EbSite.DbProviderCms.GetInstance().TagRelateUser_TagRelateUser();
        const double cachetime = 60.0;

        private const string cacheTagRelateUser = "tagrelateuser";// private static readonly string[] MasterCacheKeyArray = {"BllTagRelateUser"};
       // private static CacheManager bllCache;
        //static TagRelateUser()
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
			return DbProviderCms.GetInstance().TagRelateUser_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		static public  bool Exists(int id)
		{
			return DbProviderCms.GetInstance().TagRelateUser_Exists(id);
		}
        static public void DeleteByRemove(string ReserveIDs, int UserID)
        {
            DbProviderCms.GetInstance().TagRelateUser_DeleteByRemove(ReserveIDs, UserID);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		static public  int  Add(EbSite.Entity.TagRelateUser model)
		{
			return DbProviderCms.GetInstance().TagRelateUser_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		static public  void Update(EbSite.Entity.TagRelateUser model)
		{
			DbProviderCms.GetInstance().TagRelateUser_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		static public  void Delete(int id)
		{
			DbProviderCms.GetInstance().TagRelateUser_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		static public  EbSite.Entity.TagRelateUser GetModel(int id)
		{
			return DbProviderCms.GetInstance().TagRelateUser_GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        static public EbSite.Entity.TagRelateUser GetModelByCache(int ID)
		{
            string CacheKey = "TagRelateUser-" + ID;
            Entity.TagRelateUser model = Host.CacheApp.GetCacheItem<Entity.TagRelateUser>(CacheKey, cacheTagRelateUser);//bllCache.GetCacheItem(CacheKey) as Entity.TagRelateUser;
            if (model == null)
            {
                model = DbProviderCms.GetInstance().TagRelateUser_GetModel(ID); ; ;
                Host.CacheApp.AddCacheItem(CacheKey, model, cachetime, ETimeSpanModel.M, cacheTagRelateUser);  //bllCache.AddCacheItem(CacheKey, model);
            }
            return model;
		}

		


		/// <summary>
		/// 获得数据列表
		/// </summary>
		//static public  DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return DbProviderCms.GetInstance().TagRelateUser_GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

