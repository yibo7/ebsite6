
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Amib.Threading;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.EBSiteEventArgs;
using EbSite.BLL.ModelBll;
using EbSite.Core;
using EbSite.Core.RSS;
using EbSite.Data.Interface;
namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类searchword 的摘要说明。
	/// </summary>
    public class searchword : EbSite.Base.BLL.BllBase<Entity.searchword, Guid> 
	{
		public static readonly searchword Instance = new searchword();
		private  searchword()
		{
		}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid id)
		{
            return dal.searchword_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public Guid Add(Entity.searchword model)
		{
			base.InvalidateCache();
            if (model.id == Guid.Empty)
                model.id = Guid.NewGuid();
            dal.searchword_Add(model);
            return Guid.Empty;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.searchword model)
		{
			base.InvalidateCache();
			dal.searchword_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(Guid id)
		{
			base.InvalidateCache();
			
			dal.searchword_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.searchword GetEntity(Guid id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
			Entity.searchword etEntity = base.GetCacheItem<Entity.searchword>(rawKey)  ;
			if (Equals(etEntity,null))
			{
				etEntity = dal.searchword_GetEntity(id);
				if (!Equals(etEntity,null))
					base.AddCacheItem(rawKey, etEntity);
			}
			return etEntity;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public int GetCount(string strWhere)
		{
			return dal.searchword_GetCount(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public int GetCountCache(string strWhere)
		{
			string rawKey = string.Concat("GetCount-", strWhere);
			 string sCount = base.GetCacheItem<string>(rawKey) ;
			if (string.IsNullOrEmpty(sCount))
			{
				sCount = GetCount(strWhere).ToString();
				if (!string.IsNullOrEmpty(sCount))
					base.AddCacheItem(rawKey, sCount);
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
		public DataSet GetList(string strWhere)
		{
			return GetListCache(0,strWhere,"");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList()
		{
			return GetList("");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.searchword_GetList( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetListCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetList-", strWhere, Top, filedOrder);
            byte[] ibyte = base.GetCacheItem<byte[]>(rawKey);
            DataSet lstData = null;
            if (Equals(ibyte, null))
            {
                lstData = GetList(Top, strWhere, filedOrder);
                ibyte = EbSite.Core.DataSetHelper.GetBinaryFormatDataSet(lstData);
                if (!Equals(ibyte, null))
                    base.AddCacheItem(rawKey, ibyte);
            }
            else
            {
                lstData = Core.DataSetHelper.RetrieveDataSet(ibyte);
            }
            return lstData;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.searchword> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dal.searchword_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.searchword> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
			 List<Entity.searchword> lstData = base.GetCacheItem< List<Entity.searchword>>(rawKey) ;
			if (Equals(lstData,null))
			{
				//从基类调用，激活事件
				lstData = base.GetListArrayEv( Top,  strWhere,  filedOrder);
				if (!Equals(lstData,null))
					base.AddCacheItem(rawKey, lstData);
			}
			return lstData;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.searchword> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.searchword> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.searchword> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dal.searchword_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.searchword> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
			 List<Entity.searchword> lstData = base.GetCacheItem< List<Entity.searchword>>(rawKey) ;
			int iRecordCount = -1;
			if (Equals(lstData,null))
			{
				//从基类调用，激活事件
				lstData = base.GetListPagesEv(  PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
				if (!Equals(lstData,null))
				{
					base.AddCacheItem(rawKey, lstData);
					base.AddCacheItem(rawKeyCount, RecordCount.ToString());
				}
			}
			if(iRecordCount==-1)
			{
				string sCount = base.GetCacheItem<string>(rawKeyCount) ;
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
		public List<Entity.searchword> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
            return GetListPagesCache(PageIndex, PageSize, "", "", "searchcount desc", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.searchword> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.searchword> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.searchword> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
		public void AddKeyWord(string sKeyWord)
		{
            dal.searchword_Add(sKeyWord);


		}

        public static void AddWordToPool(string sKeyWord)
        {
            if (!string.IsNullOrEmpty(sKeyWord))
            {
                
                    IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(writesearchlog), sKeyWord);
               
            }
        }

        static private object writesearchlog(object obj)
        {
            string sKeyWord = obj.ToString();

            Instance.AddKeyWord(sKeyWord);

            return 1;
        }

         public void DeleteALL()
         {
             dal.searchword_DeleteALL();
         }
		#endregion  自定义方法
	}
}

