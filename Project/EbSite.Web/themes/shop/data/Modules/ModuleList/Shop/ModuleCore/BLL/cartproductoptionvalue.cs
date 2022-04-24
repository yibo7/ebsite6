using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Shop.ModuleCore.BLL
{
	/// <summary>
	/// 业务逻辑类cartproductoptionvalue 的摘要说明。
	/// </summary>
	public class cartproductoptionvalue: Base.BLLBase<Entity.cartproductoptionvalue, int> 
	{
		public static readonly cartproductoptionvalue Instance = new cartproductoptionvalue();
		private  cartproductoptionvalue()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.cartproductoptionvalue_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dalHelper.cartproductoptionvalue_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.cartproductoptionvalue model)
		{
			base.InvalidateCache();
			return dalHelper.cartproductoptionvalue_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.cartproductoptionvalue model)
		{
			base.InvalidateCache();
			dalHelper.cartproductoptionvalue_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dalHelper.cartproductoptionvalue_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.cartproductoptionvalue GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.cartproductoptionvalue etEntity = base.GetCacheItem<Entity.cartproductoptionvalue>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.cartproductoptionvalue_GetEntity(id);
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
			return dalHelper.cartproductoptionvalue_GetCount(strWhere);
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
			return dalHelper.cartproductoptionvalue_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.cartproductoptionvalue> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.cartproductoptionvalue_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.cartproductoptionvalue> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.cartproductoptionvalue> lstData = base.GetCacheItem<List<Entity.cartproductoptionvalue>>(rawKey);
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
		public List<Entity.cartproductoptionvalue> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.cartproductoptionvalue> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.cartproductoptionvalue> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.cartproductoptionvalue_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.cartproductoptionvalue> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.cartproductoptionvalue> lstData = base.GetCacheItem<List<Entity.cartproductoptionvalue>>(rawKey);
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
		public List<Entity.cartproductoptionvalue> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.cartproductoptionvalue> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.cartproductoptionvalue> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.cartproductoptionvalue> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.cartproductoptionvalue mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CartItemID".ToLower()))
					{
						sValue = mdEt.CartItemID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ProductID".ToLower()))
					{
						sValue = mdEt.ProductID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ProductOptionId".ToLower()))
					{
						sValue = mdEt.ProductOptionId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ProductOptionItemId".ToLower()))
					{
						sValue = mdEt.ProductOptionItemId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OptionName".ToLower()))
					{
						sValue = mdEt.OptionName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ItemName".ToLower()))
					{
						sValue = mdEt.ItemName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "IsGive".ToLower()))
					{
						sValue = mdEt.IsGive.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AppendMoney".ToLower()))
					{
						sValue = mdEt.AppendMoney.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CalculateMode".ToLower()))
					{
						sValue = mdEt.CalculateMode.ToString();
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
			Entity.cartproductoptionvalue mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "CartItemID".ToLower()))
					{
						mdEntity.CartItemID =long.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ProductID".ToLower()))
					{
						mdEntity.ProductID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ProductOptionId".ToLower()))
					{
						mdEntity.ProductOptionId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ProductOptionItemId".ToLower()))
					{
						mdEntity.ProductOptionItemId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OptionName".ToLower()))
					{
						mdEntity.OptionName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "ItemName".ToLower()))
					{
						mdEntity.ItemName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "IsGive".ToLower()))
					{
						mdEntity.IsGive = bool.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AppendMoney".ToLower()))
					{
						mdEntity.AppendMoney = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "CalculateMode".ToLower()))
					{
						mdEntity.CalculateMode = int.Parse(column.ColumnValue);
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
		public Entity.cartproductoptionvalue GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.cartproductoptionvalue mdEt = new Entity.cartproductoptionvalue();
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
					else if(Equals(uc.ID.ToLower(),"CartItemID".ToLower()))
					{
						mdEt.CartItemID = long.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ProductID".ToLower()))
					{
						mdEt.ProductID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ProductOptionId".ToLower()))
					{
						mdEt.ProductOptionId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ProductOptionItemId".ToLower()))
					{
						mdEt.ProductOptionItemId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OptionName".ToLower()))
					{
						mdEt.OptionName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"ItemName".ToLower()))
					{
						mdEt.ItemName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"IsGive".ToLower()))
					{
						mdEt.IsGive = bool.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AppendMoney".ToLower()))
					{
						mdEt.AppendMoney = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"CalculateMode".ToLower()))
					{
						mdEt.CalculateMode = int.Parse(sValue);
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法

        public List<Entity.cartproductoptionvalue> GetListArrayByCarItemID(long CarItemID)
        {
           return GetListArray(string.Concat("CartItemID=", CarItemID));
        }
        public List<Entity.cartproductoptionvalue> GetSelOptionItemsByID(string OptIDs, long ProductId, long CartNumber, int Quantity, decimal MemberPrice)
        {
            //decimal _ProductOptionFree = 0;
            string[] aID = OptIDs.Split('_');

            bool ispost = false;

            foreach (string sid in aID)
            {
                int testid = 0;
                int.TryParse(sid, out testid);
                if (testid > 0)
                {
                    ispost = true;
                    break;
                }
            }
            if (ispost)
            {
                string IDs = string.Join(",", aID);
                List<Entity.ProductOptionItems> lst = ModuleCore.BLL.ProductOptionItems.Instance.GetListArrayInIDs(IDs);
                List<Entity.cartproductoptionvalue> SelOptionItems = new List<Entity.cartproductoptionvalue>();
                foreach (Entity.ProductOptionItems Item in lst)
                {
                    Entity.cartproductoptionvalue modle = new Entity.cartproductoptionvalue(Item, ProductId, CartNumber,
                                                                              Quantity, MemberPrice);
                    //_ProductOptionFree += modle.TotalPrice;
                    SelOptionItems.Add(modle);

                }
                //ProductOptionFree = _ProductOptionFree;
                return SelOptionItems;
            }
            else
            {
                //ProductOptionFree = 0;
                return new List<Entity.cartproductoptionvalue>();
            }

            
        }

        public void ClearCache()
        {
            base.InvalidateCache();
        }

	    #endregion  自定义方法
	}
}

