using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类spiderlog 的摘要说明。
	/// </summary>
	public class spiderlog 
	{
		public static readonly spiderlog Instance = new spiderlog();
        private const double cachetime = 60.0;

        private const string Cachespiderlog = "spiderlog";
        private  spiderlog()
		{
		}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Id)
		{
			return DbProviderCms.GetInstance().spiderlog_Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		 public int Add(Entity.spiderlog model)
		{
			 
			return DbProviderCms.GetInstance().spiderlog_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		 public void Update(Entity.spiderlog model)
		{
			
			DbProviderCms.GetInstance().spiderlog_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		 public void Delete(long Id)
		{
			
			DbProviderCms.GetInstance().spiderlog_Delete(Id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 public Entity.spiderlog GetEntity(long Id)
		{

            string rawKey = string.Concat("GetEntity-", Id);
            Entity.spiderlog etEntity = Host.CacheApp.GetCacheItem<Entity.spiderlog>(rawKey, Cachespiderlog);
            if (Equals(etEntity, null))
            {
                etEntity = DbProviderCms.GetInstance().spiderlog_GetEntity(Id);
                if (!Equals(etEntity, null))
                    Host.CacheApp.AddCacheItem(rawKey, etEntity, cachetime, ETimeSpanModel.M, Cachespiderlog);
            }
            return etEntity;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public int GetCount(string strWhere)
		{
			return DbProviderCms.GetInstance().spiderlog_GetCount(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public int GetCountCache(string strWhere)
		{
			string rawKey = string.Concat("GetCount-", strWhere);
			 string sCount = Host.CacheApp.GetCacheItem<string>(rawKey, Cachespiderlog);
            if (string.IsNullOrEmpty(sCount))
			{
				sCount = GetCount(strWhere).ToString();
				if (!string.IsNullOrEmpty(sCount)) 
                    Host.CacheApp.AddCacheItem(rawKey, sCount, cachetime, ETimeSpanModel.M, Cachespiderlog);
            }
			if (!string.IsNullOrEmpty(sCount))
			{
				return int.Parse(sCount);
			}
			return 0;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public int GetCount()
		{
			return GetCountCache("");
		} 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.spiderlog> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return DbProviderCms.GetInstance().spiderlog_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.spiderlog> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
			 List<Entity.spiderlog> lstData = Host.CacheApp.GetCacheItem<List<Entity.spiderlog>>(rawKey, Cachespiderlog);
            if (Equals(lstData,null))
			{
				//从基类调用，激活事件
				lstData = GetListArray( Top,  strWhere,  filedOrder);
				if (!Equals(lstData,null))
                    Host.CacheApp.AddCacheItem(rawKey, lstData, cachetime, ETimeSpanModel.M, Cachespiderlog);
            }
			return lstData;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.spiderlog> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.spiderlog> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.spiderlog> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return DbProviderCms.GetInstance().spiderlog_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.spiderlog> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
			 List<Entity.spiderlog> lstData = Host.CacheApp.GetCacheItem<List<Entity.spiderlog>>(rawKey, Cachespiderlog);
            int iRecordCount = -1;
			if (Equals(lstData,null))
			{
				//从基类调用，激活事件
				lstData = GetListPages(  PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
				if (!Equals(lstData,null))
				{
                    Host.CacheApp.AddCacheItem(rawKey, lstData, cachetime, ETimeSpanModel.M, Cachespiderlog);
                    Host.CacheApp.AddCacheItem(rawKeyCount, RecordCount, cachetime, ETimeSpanModel.M, Cachespiderlog); 
				}
			}
			if(iRecordCount==-1)
			{
				string sCount = Host.CacheApp.GetCacheItem<string>(rawKeyCount, Cachespiderlog); 
				if (!string.IsNullOrEmpty(sCount))
				{
					RecordCount = int.Parse(sCount);
				}
				else
				{
					RecordCount = GetCountCache(strWhere);
				}
			}
			else
			{
				RecordCount = iRecordCount;
			}
			return lstData;
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.spiderlog> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.spiderlog> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.spiderlog> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.spiderlog> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
		{
			string strWhere = "";
			if (!string.IsNullOrEmpty(sKeyWord)) strWhere = string.Format("{0} like '%{1}%'", ColumnName, sKeyWord);
			if (string.IsNullOrEmpty(strWhere))
			{
			RecordCount = 0;
			return null;
			}
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
		}


        #endregion  成员方法

        #region  自定义方法
        /// <summary>
        /// 统计来访数据
        /// </summary>
        /// <param name="spiderid">The spiderid.</param>
        /// <param name="itype">类型,1.今日来访，2昨日来访，3前7天来访，4前30天来访</param>
        /// <returns>System.Int32.</returns>
        public int GetLogCount(int spiderid, int itype)
	    {
	       return DbProviderCms.GetInstance().GetLogCount(spiderid, itype);

	    }

	    public List<Entity.ListItemModel> GetVisitSum(string strWhere,int iTop)
	    {
            return DbProviderCms.GetInstance().GetVisitSum(strWhere, iTop);
        }

	    public List<Entity.ListItemModel> GetVisitTime(int itype)
	    {
            return DbProviderCms.GetInstance().GetVisitTime(itype);
        }

	    #endregion  自定义方法
        }
}

