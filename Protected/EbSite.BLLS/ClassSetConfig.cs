using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类classsetconfig 的摘要说明。
	/// </summary>
	public class ClassSetConfig :   Base.BLL.BllBase<Entity.ClassSetConfig, int>
    {
		public static readonly ClassSetConfig Instance = new ClassSetConfig();
		private ClassSetConfig()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return DbProviderCms.GetInstance().ClassSetConfig_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return DbProviderCms.GetInstance().ClassSetConfig_Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.ClassSetConfig model)
		{
			
			int id =  DbProviderCms.GetInstance().ClassSetConfig_Add(model);
            base.InvalidateCache();
		    return id;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.ClassSetConfig model)
		{
			base.InvalidateCache();
			DbProviderCms.GetInstance().ClassSetConfig_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int Id)
		{
			base.InvalidateCache();
			
			DbProviderCms.GetInstance().ClassSetConfig_Delete(Id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.ClassSetConfig GetEntity(int Id)
		{
			
			string rawKey = string.Concat("GetEntity-", Id);
			Entity.ClassSetConfig etEntity =  base.GetCacheItem<Entity.ClassSetConfig>(rawKey) ;
			if (Equals(etEntity,null))
			{
				etEntity = DbProviderCms.GetInstance().ClassSetConfig_GetEntity(Id);
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
			return DbProviderCms.GetInstance().ClassSetConfig_GetCount(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public int GetCountCache(string strWhere)
		{
			string rawKey = string.Concat("GetCount-", strWhere);
			 string sCount =  base.GetCacheItem<string>(rawKey);
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
			return DbProviderCms.GetInstance().ClassSetConfig_GetList( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetList-", strWhere,Top,filedOrder);
			byte[] ibyte = base.GetCacheItem<byte[]>(rawKey);
			DataSet lstData = null;
			if (Equals(ibyte,null))
			{
				lstData = GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.ClassSetConfig> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return DbProviderCms.GetInstance().ClassSetConfig_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.ClassSetConfig> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
			 List<Entity.ClassSetConfig> lstData = base.GetCacheItem<List<Entity.ClassSetConfig>>(rawKey);
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
		public List<Entity.ClassSetConfig> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.ClassSetConfig> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.ClassSetConfig> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return DbProviderCms.GetInstance().ClassSetConfig_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.ClassSetConfig> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
			 List<Entity.ClassSetConfig> lstData = base.GetCacheItem<List<Entity.ClassSetConfig>>(rawKey);
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
				string sCount = base.GetCacheItem<string>(rawKeyCount);
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
		public List<Entity.ClassSetConfig> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.ClassSetConfig> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.ClassSetConfig> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.ClassSetConfig> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
		/// <summary>
		/// 修改时获取当前实例，并载入控件到PlaceHolder
		/// </summary>
		public void InitModifyCtr(string id, PlaceHolder ph)
		{
			if (!string.IsNullOrEmpty(id))
			{
				int ThisId = int.Parse(id);
				Entity.ClassSetConfig mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "Id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ClassId".ToLower()))
					{
						sValue = mdEt.ClassId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ConfigId".ToLower()))
					{
						sValue = mdEt.ConfigId.ToString();
					}
				SetValueFromControl(uc, sValue);
				}
			}
		}
		/// <summary>
		/// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
		/// </summary>
		public void SaveEntityFromCtr(PlaceHolder ph)
		{
				SaveEntityFromCtr(ph,null);
		}
		/// <summary>
		/// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
		/// </summary>
		public void SaveEntityFromCtr(PlaceHolder ph, List<EbSite.Base.BLL.OtherColumn> lstOtherColumn)
		{
			Entity.ClassSetConfig mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "Id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ClassId".ToLower()))
					{
						mdEntity.ClassId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ConfigId".ToLower()))
					{
						mdEntity.ConfigId = int.Parse(column.ColumnValue);
					}
				}
			}
			if (mdEntity.id>0)
			{
				Update(mdEntity);
			}else{
				 Add(mdEntity);
			}
		}
		/// <summary>
		/// 从PlaceHolder中获取一个实例
		/// </summary>
		public Entity.ClassSetConfig GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.ClassSetConfig mdEt = new Entity.ClassSetConfig();
			string sKeyID;
			if (GetIDFromCtr(ph, out sKeyID))
			{
				mdEt = GetEntity(int.Parse(sKeyID));
			}
			foreach (System.Web.UI.Control uc in ph.Controls)
			{
				if (Equals(uc.ID, null)) continue;
				string sValue = GetValueFromControl(uc);
					if(Equals(uc.ID.ToLower(),"Id".ToLower()))
					{
						mdEt.id = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ClassId".ToLower()))
					{
						mdEt.ClassId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ConfigId".ToLower()))
					{
						mdEt.ConfigId = int.Parse(sValue);
					}
			}
		return mdEt;
		}

        #endregion  成员方法

        #region  自定义方法

	    public int GetCountByConfigId(int ConfigId)
	    {
	       return GetCountCache(string.Format("ConfigId={0}", ConfigId));
	    }

	    public void  UpdateConfigId(Entity.ClassSetConfig md)
	    {
              DbProviderCms.GetInstance().ClassSetConfig_UpdateConfigId(md);
            base.InvalidateCache();
        }
        public void DeleteByClassIds(string ClassIds)
        {
            DbProviderCms.GetInstance().ClassSetConfig_DeleteByClassIds(ClassIds);
            base.InvalidateCache();
        }

        
        #endregion  自定义方法
    }
}

