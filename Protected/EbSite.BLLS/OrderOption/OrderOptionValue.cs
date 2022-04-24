using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Web.UI.WebControls;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类OrderOptionValue 的摘要说明。
	/// </summary>
    public class OrderOptionValue : Base.BLL.BllBase<Entity.OrderOptionValue, int> 
	{
		public static readonly OrderOptionValue Instance = new OrderOptionValue();
		private  OrderOptionValue()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return DbProviderUser.GetInstance().OrderOptionValue_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return DbProviderUser.GetInstance().OrderOptionValue_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.OrderOptionValue model)
		{
			base.InvalidateCache();
			return DbProviderUser.GetInstance().OrderOptionValue_Add(model);
		}
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.OrderOptionValue model, DbTransaction Trans)
        {
            base.InvalidateCache();
            return DbProviderUser.GetInstance().OrderOptionValue_Add(model,Trans);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.OrderOptionValue model)
		{
			base.InvalidateCache();
			DbProviderUser.GetInstance().OrderOptionValue_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			DbProviderUser.GetInstance().OrderOptionValue_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.OrderOptionValue GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.OrderOptionValue etEntity = base.GetCacheItem<Entity.OrderOptionValue>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = DbProviderUser.GetInstance().OrderOptionValue_GetEntity(id);
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
			return DbProviderUser.GetInstance().OrderOptionValue_GetCount(strWhere);
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
			return DbProviderUser.GetInstance().OrderOptionValue_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.OrderOptionValue> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return DbProviderUser.GetInstance().OrderOptionValue_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.OrderOptionValue> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.OrderOptionValue> lstData = base.GetCacheItem<List<Entity.OrderOptionValue>>(rawKey);
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
		public List<Entity.OrderOptionValue> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.OrderOptionValue> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.OrderOptionValue> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return DbProviderUser.GetInstance().OrderOptionValue_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.OrderOptionValue> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.OrderOptionValue> lstData = base.GetCacheItem<List<Entity.OrderOptionValue>>(rawKey);
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
		public List<Entity.OrderOptionValue> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.OrderOptionValue> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.OrderOptionValue> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.OrderOptionValue> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.OrderOptionValue mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderId".ToLower()))
					{
						sValue = mdEt.OrderId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "LookupListId".ToLower()))
					{
						sValue = mdEt.LookupListId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "LookupItemId".ToLower()))
					{
						sValue = mdEt.LookupItemId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ListDescription".ToLower()))
					{
						sValue = mdEt.ListDescription.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ItemDescription".ToLower()))
					{
						sValue = mdEt.ItemDescription.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AdjustedPrice".ToLower()))
					{
						sValue = mdEt.AdjustedPrice.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CustomerTitle".ToLower()))
					{
						sValue = mdEt.CustomerTitle.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CustomerDescription".ToLower()))
					{
						sValue = mdEt.CustomerDescription.ToString();
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
			Entity.OrderOptionValue mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderId".ToLower()))
					{
						mdEntity.OrderId = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "LookupListId".ToLower()))
					{
						mdEntity.LookupListId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "LookupItemId".ToLower()))
					{
						mdEntity.LookupItemId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ListDescription".ToLower()))
					{
						mdEntity.ListDescription = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "ItemDescription".ToLower()))
					{
						mdEntity.ItemDescription = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AdjustedPrice".ToLower()))
					{
						mdEntity.AdjustedPrice = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "CustomerTitle".ToLower()))
					{
						mdEntity.CustomerTitle = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "CustomerDescription".ToLower()))
					{
						mdEntity.CustomerDescription = column.ColumnValue;
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
		public Entity.OrderOptionValue GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.OrderOptionValue mdEt = new Entity.OrderOptionValue();
			string sKeyID;
			if (GetIDFromCtr(ph, out sKeyID))
			{
				mdEt = GetEntity(int.Parse(sKeyID));
			}
			foreach (System.Web.UI.Control uc in ph.Controls)
			{
				if (Equals(uc.ID, null)) continue;
				string sValue = GetValueFromControl(uc);
					if(Equals(uc.ID.ToLower(),"id".ToLower()))
					{
						mdEt.id = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OrderId".ToLower()))
					{
						mdEt.OrderId = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"LookupListId".ToLower()))
					{
						mdEt.LookupListId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"LookupItemId".ToLower()))
					{
						mdEt.LookupItemId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ListDescription".ToLower()))
					{
						mdEt.ListDescription = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"ItemDescription".ToLower()))
					{
						mdEt.ItemDescription = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AdjustedPrice".ToLower()))
					{
						mdEt.AdjustedPrice = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"CustomerTitle".ToLower()))
					{
						mdEt.CustomerTitle = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"CustomerDescription".ToLower()))
					{
						mdEt.CustomerDescription = sValue;
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法
		
		#endregion  自定义方法
	}
}

