using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Shop.ModuleCore.BLL
{
	/// <summary>
	/// 业务逻辑类pointdetails 的摘要说明。
	/// </summary>
	public class pointdetails: Base.BLLBase<Entity.pointdetails, int> 
	{
		public static readonly pointdetails Instance = new pointdetails();
		private  pointdetails()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.pointdetails_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dalHelper.pointdetails_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.pointdetails model)
		{
			base.InvalidateCache();
			return dalHelper.pointdetails_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.pointdetails model)
		{
			base.InvalidateCache();
			dalHelper.pointdetails_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dalHelper.pointdetails_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.pointdetails GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.pointdetails etEntity = base.GetCacheItem<Entity.pointdetails>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.pointdetails_GetEntity(id);
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
			return dalHelper.pointdetails_GetCount(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public int GetCountCache(string strWhere)
		{
			string rawKey = string.Concat("GetCount-", strWhere);
            string sCount = base.GetCacheItem<string>(rawKey);
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
			return dalHelper.pointdetails_GetList( Top,  strWhere,  filedOrder);
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
                lstData = EbSite.Core.DataSetHelper.RetrieveDataSet(ibyte);
            }
            return lstData;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.pointdetails> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.pointdetails_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.pointdetails> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.pointdetails> lstData = base.GetCacheItem<List<Entity.pointdetails>>(rawKey);
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
		public List<Entity.pointdetails> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.pointdetails> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.pointdetails> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.pointdetails_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.pointdetails> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.pointdetails> lstData = base.GetCacheItem<List<Entity.pointdetails>>(rawKey);
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
		public List<Entity.pointdetails> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.pointdetails> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.pointdetails> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.pointdetails> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.pointdetails mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserId".ToLower()))
					{
						sValue = mdEt.UserId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "TradeType".ToLower()))
					{
						sValue = mdEt.TradeType.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Increased".ToLower()))
					{
						sValue = mdEt.Increased.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Reduced".ToLower()))
					{
						sValue = mdEt.Reduced.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Points".ToLower()))
					{
						sValue = mdEt.Points.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "TradeDate".ToLower()))
					{
						sValue = mdEt.TradeDate.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderId".ToLower()))
					{
						sValue = mdEt.OrderId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Remark".ToLower()))
					{
						sValue = mdEt.Remark.ToString();
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
			Entity.pointdetails mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "UserId".ToLower()))
					{
						mdEntity.UserId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "TradeType".ToLower()))
					{
						mdEntity.TradeType = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Increased".ToLower()))
					{
						mdEntity.Increased = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Reduced".ToLower()))
					{
						mdEntity.Reduced = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Points".ToLower()))
					{
						mdEntity.Points = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "TradeDate".ToLower()))
					{
						mdEntity.TradeDate = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderId".ToLower()))
					{
						mdEntity.OrderId = long.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Remark".ToLower()))
					{
						mdEntity.Remark = column.ColumnValue;
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
		public Entity.pointdetails GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.pointdetails mdEt = new Entity.pointdetails();
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
					else if(Equals(uc.ID.ToLower(),"UserId".ToLower()))
					{
						mdEt.UserId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"TradeType".ToLower()))
					{
						mdEt.TradeType = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Increased".ToLower()))
					{
						mdEt.Increased = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Reduced".ToLower()))
					{
						mdEt.Reduced = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Points".ToLower()))
					{
						mdEt.Points = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"TradeDate".ToLower()))
					{
						mdEt.TradeDate = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OrderId".ToLower()))
					{
						mdEt.OrderId = long.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Remark".ToLower()))
					{
						mdEt.Remark = sValue;
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
	
	}
}

