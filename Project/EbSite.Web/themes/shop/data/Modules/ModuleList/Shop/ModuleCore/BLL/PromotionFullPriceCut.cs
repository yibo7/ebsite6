using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Shop.ModuleCore.BLL
{
	/// <summary>
	/// 业务逻辑类PromotionFullPriceCut 的摘要说明。
	/// </summary>
	public class PromotionFullPriceCut: Base.BLLBase<Entity.PromotionFullPriceCut, int> 
	{
		public static readonly PromotionFullPriceCut Instance = new PromotionFullPriceCut();
		private  PromotionFullPriceCut()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.PromotionFullPriceCut_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dalHelper.PromotionFullPriceCut_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.PromotionFullPriceCut model)
		{
			base.InvalidateCache();
			return dalHelper.PromotionFullPriceCut_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.PromotionFullPriceCut model)
		{
			base.InvalidateCache();
			dalHelper.PromotionFullPriceCut_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dalHelper.PromotionFullPriceCut_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.PromotionFullPriceCut GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.PromotionFullPriceCut etEntity = base.GetCacheItem<Entity.PromotionFullPriceCut>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.PromotionFullPriceCut_GetEntity(id);
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
			return dalHelper.PromotionFullPriceCut_GetCount(strWhere);
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
			return dalHelper.PromotionFullPriceCut_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.PromotionFullPriceCut> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.PromotionFullPriceCut_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.PromotionFullPriceCut> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.PromotionFullPriceCut> lstData = base.GetCacheItem<List<Entity.PromotionFullPriceCut>>(rawKey);
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
		public List<Entity.PromotionFullPriceCut> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.PromotionFullPriceCut> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.PromotionFullPriceCut> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.PromotionFullPriceCut_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.PromotionFullPriceCut> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.PromotionFullPriceCut> lstData = base.GetCacheItem<List<Entity.PromotionFullPriceCut>>(rawKey);
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
		public List<Entity.PromotionFullPriceCut> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.PromotionFullPriceCut> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.PromotionFullPriceCut> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.PromotionFullPriceCut> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.PromotionFullPriceCut mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "PromotionsID".ToLower()))
					{
						sValue = mdEt.PromotionsID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Amount".ToLower()))
					{
						sValue = mdEt.Amount.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "DiscountValue".ToLower()))
					{
						sValue = mdEt.DiscountValue.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ValueType".ToLower()))
					{
						sValue = mdEt.ValueType.ToString();
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
			Entity.PromotionFullPriceCut mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "PromotionsID".ToLower()))
					{
						mdEntity.PromotionsID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Amount".ToLower()))
					{
						mdEntity.Amount = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "DiscountValue".ToLower()))
					{
						mdEntity.DiscountValue = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ValueType".ToLower()))
					{
						mdEntity.ValueType = int.Parse(column.ColumnValue);
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
		public Entity.PromotionFullPriceCut GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.PromotionFullPriceCut mdEt = new Entity.PromotionFullPriceCut();
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
					else if(Equals(uc.ID.ToLower(),"PromotionsID".ToLower()))
					{
						mdEt.PromotionsID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Amount".ToLower()))
					{
						mdEt.Amount = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"DiscountValue".ToLower()))
					{
						mdEt.DiscountValue = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ValueType".ToLower()))
					{
						mdEt.ValueType = int.Parse(sValue);
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.PromotionFullPriceCut GetEntity(string strWhere)
        {
            return dalHelper.PromotionFullPriceCut_GetEntity(strWhere);
        }

		#endregion  自定义方法
	}
}

