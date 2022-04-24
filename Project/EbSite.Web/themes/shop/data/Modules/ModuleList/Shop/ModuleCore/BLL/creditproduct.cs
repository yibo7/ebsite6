using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Shop.ModuleCore.BLL
{
	/// <summary>
	/// 业务逻辑类creditproduct 的摘要说明。
	/// </summary>
	public class creditproduct: Base.BLLBase<Entity.creditproduct, int> 
	{
		public static readonly creditproduct Instance = new creditproduct();
		private  creditproduct()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.creditproduct_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dalHelper.creditproduct_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.creditproduct model)
		{
			base.InvalidateCache();
			return dalHelper.creditproduct_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.creditproduct model)
		{
			base.InvalidateCache();
			dalHelper.creditproduct_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dalHelper.creditproduct_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.creditproduct GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.creditproduct etEntity = base.GetCacheItem<Entity.creditproduct>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.creditproduct_GetEntity(id);
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
			return dalHelper.creditproduct_GetCount(strWhere);
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
			return dalHelper.creditproduct_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.creditproduct> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.creditproduct_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.creditproduct> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.creditproduct> lstData = base.GetCacheItem<List<Entity.creditproduct>>(rawKey);
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
		public List<Entity.creditproduct> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.creditproduct> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.creditproduct> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.creditproduct_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.creditproduct> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.creditproduct> lstData = base.GetCacheItem<List<Entity.creditproduct>>(rawKey);
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
		public List<Entity.creditproduct> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.creditproduct> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.creditproduct> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.creditproduct> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.creditproduct mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ProductName".ToLower()))
					{
						sValue = mdEt.ProductName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SmallImg".ToLower()))
					{
						sValue = mdEt.SmallImg.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "BigImg".ToLower()))
					{
						sValue = mdEt.BigImg.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Unit".ToLower()))
					{
						sValue = mdEt.Unit.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CostPrice".ToLower()))
					{
						sValue = mdEt.CostPrice.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "MarketPrice".ToLower()))
					{
						sValue = mdEt.MarketPrice.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Credit".ToLower()))
					{
						sValue = mdEt.Credit.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Outline".ToLower()))
					{
						sValue = mdEt.Outline.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SeoDes".ToLower()))
					{
						sValue = mdEt.SeoDes.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SeoKeyWord".ToLower()))
					{
						sValue = mdEt.SeoKeyWord.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SeoTitle".ToLower()))
					{
						sValue = mdEt.SeoTitle.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Info".ToLower()))
					{
						sValue = mdEt.Info.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AddTime".ToLower()))
					{
						sValue = mdEt.AddTime.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AddUserID".ToLower()))
					{
						sValue = mdEt.AddUserID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "IsSaling".ToLower()))
					{
						sValue = mdEt.IsSaling.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Stock".ToLower()))
					{
						sValue = mdEt.Stock.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ClassID".ToLower()))
					{
						sValue = mdEt.ClassID.ToString();
					}
                    else if (Equals(uc.ID.ToLower(), "ExchangeNum".ToLower()))
					{
                        sValue = mdEt.ExchangeNum.ToString();
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
			Entity.creditproduct mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ProductName".ToLower()))
					{
						mdEntity.ProductName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "SmallImg".ToLower()))
					{
						mdEntity.SmallImg = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "BigImg".ToLower()))
					{
						mdEntity.BigImg = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Unit".ToLower()))
					{
						mdEntity.Unit = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "CostPrice".ToLower()))
					{
						mdEntity.CostPrice = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "MarketPrice".ToLower()))
					{
						mdEntity.MarketPrice = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Credit".ToLower()))
					{
						mdEntity.Credit = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Outline".ToLower()))
					{
						mdEntity.Outline = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "SeoDes".ToLower()))
					{
						mdEntity.SeoDes = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "SeoKeyWord".ToLower()))
					{
						mdEntity.SeoKeyWord = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "SeoTitle".ToLower()))
					{
						mdEntity.SeoTitle = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Info".ToLower()))
					{
						mdEntity.Info = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AddTime".ToLower()))
					{
						mdEntity.AddTime = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AddUserID".ToLower()))
					{
						mdEntity.AddUserID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "IsSaling".ToLower()))
					{
						mdEntity.IsSaling = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Stock".ToLower()))
					{
						mdEntity.Stock = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ClassID".ToLower()))
					{
						mdEntity.ClassID = int.Parse(column.ColumnValue);
					}
                    else if (Equals(column.ColumnName.ToLower(), "ExchangeNum".ToLower()))
					{
                        mdEntity.ExchangeNum = int.Parse(column.ColumnValue);
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
		public Entity.creditproduct GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.creditproduct mdEt = new Entity.creditproduct();
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
					else if(Equals(uc.ID.ToLower(),"ProductName".ToLower()))
					{
						mdEt.ProductName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"SmallImg".ToLower()))
					{
						mdEt.SmallImg = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"BigImg".ToLower()))
					{
						mdEt.BigImg = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Unit".ToLower()))
					{
						mdEt.Unit = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"CostPrice".ToLower()))
					{
						mdEt.CostPrice = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"MarketPrice".ToLower()))
					{
						mdEt.MarketPrice = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Credit".ToLower()))
					{
						mdEt.Credit = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Outline".ToLower()))
					{
						mdEt.Outline = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"SeoDes".ToLower()))
					{
						mdEt.SeoDes = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"SeoKeyWord".ToLower()))
					{
						mdEt.SeoKeyWord = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"SeoTitle".ToLower()))
					{
						mdEt.SeoTitle = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Info".ToLower()))
					{
						mdEt.Info = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AddTime".ToLower()))
					{
						mdEt.AddTime = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AddUserID".ToLower()))
					{
						mdEt.AddUserID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"IsSaling".ToLower()))
					{
						mdEt.IsSaling = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Stock".ToLower()))
					{
						mdEt.Stock = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ClassID".ToLower()))
					{
						mdEt.ClassID = int.Parse(sValue);
					}
                    else if (Equals(uc.ID.ToLower(), "ExchangeNum".ToLower()))
					{
                        mdEt.ExchangeNum = int.Parse(sValue);
					}
                
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法
		
		#endregion  自定义方法
	}
}

