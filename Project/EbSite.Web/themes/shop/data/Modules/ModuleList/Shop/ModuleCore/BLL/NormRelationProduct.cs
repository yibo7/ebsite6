using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.Base.EntityAPI;

namespace EbSite.Modules.Shop.ModuleCore.BLL
{
	/// <summary>
	/// 业务逻辑类NormRelationProduct 的摘要说明。
	/// </summary>
	public class NormRelationProduct: Base.BLLBase<Entity.NormRelationProduct, int> 
	{
		public static readonly NormRelationProduct Instance = new NormRelationProduct();
		private  NormRelationProduct()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.NormRelationProduct_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dalHelper.NormRelationProduct_Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.NormRelationProduct model)
		{
			base.InvalidateCache();
			return dalHelper.NormRelationProduct_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.NormRelationProduct model)
		{
			base.InvalidateCache();
			dalHelper.NormRelationProduct_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int ID)
		{
			base.InvalidateCache();
			
			dalHelper.NormRelationProduct_Delete(ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.NormRelationProduct GetEntity(int ID)
		{
			
			string rawKey = string.Concat("GetEntity-", ID);
            Entity.NormRelationProduct etEntity = base.GetCacheItem<Entity.NormRelationProduct>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.NormRelationProduct_GetEntity(ID);
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
			return dalHelper.NormRelationProduct_GetCount(strWhere);
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
			return dalHelper.NormRelationProduct_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.NormRelationProduct> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.NormRelationProduct_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.NormRelationProduct> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.NormRelationProduct> lstData = base.GetCacheItem<List<Entity.NormRelationProduct>>(rawKey);
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
		public List<Entity.NormRelationProduct> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.NormRelationProduct> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.NormRelationProduct> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.NormRelationProduct_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.NormRelationProduct> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.NormRelationProduct> lstData = base.GetCacheItem<List<Entity.NormRelationProduct>>(rawKey);
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
		public List<Entity.NormRelationProduct> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.NormRelationProduct> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.NormRelationProduct> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.NormRelationProduct> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.NormRelationProduct mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "ID".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "PNumber".ToLower()))
					{
						sValue = mdEt.PNumber.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Stocks".ToLower()))
					{
						sValue = mdEt.Stocks.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SalePrice".ToLower()))
					{
						sValue = mdEt.SalePrice.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CostPrice".ToLower()))
					{
						sValue = mdEt.CostPrice.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "MarketPrice".ToLower()))
					{
						sValue = mdEt.MarketPrice.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Weight".ToLower()))
					{
						sValue = mdEt.Weight.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ProductID".ToLower()))
					{
						sValue = mdEt.ProductID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "NormsValues".ToLower()))
					{
						sValue = mdEt.NormsValues.ToString();
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
			Entity.NormRelationProduct mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "ID".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "PNumber".ToLower()))
					{
						mdEntity.PNumber = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Stocks".ToLower()))
					{
						mdEntity.Stocks = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "SalePrice".ToLower()))
					{
						mdEntity.SalePrice = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "CostPrice".ToLower()))
					{
						mdEntity.CostPrice = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "MarketPrice".ToLower()))
					{
						mdEntity.MarketPrice = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Weight".ToLower()))
					{
						mdEntity.Weight = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ProductID".ToLower()))
					{
						mdEntity.ProductID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "NormsValues".ToLower()))
					{
						mdEntity.NormsValues = column.ColumnValue;
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
		public Entity.NormRelationProduct GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.NormRelationProduct mdEt = new Entity.NormRelationProduct();
			string sKeyID;
			if (GetIDFromCtr(ph, out sKeyID))
			{
				mdEt = GetEntity(int.Parse(sKeyID));
			}
			foreach (System.Web.UI.Control uc in ph.Controls)
			{
				if (Equals(uc.ID, null)) continue;
				string sValue = GetValueFromControl(uc);
					if(Equals(uc.ID.ToLower(),"ID".ToLower()))
					{
						mdEt.id = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"PNumber".ToLower()))
					{
						mdEt.PNumber = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Stocks".ToLower()))
					{
						mdEt.Stocks = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"SalePrice".ToLower()))
					{
						mdEt.SalePrice = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"CostPrice".ToLower()))
					{
						mdEt.CostPrice = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"MarketPrice".ToLower()))
					{
						mdEt.MarketPrice = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Weight".ToLower()))
					{
						mdEt.Weight = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ProductID".ToLower()))
					{
						mdEt.ProductID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"NormsValues".ToLower()))
					{
						mdEt.NormsValues = sValue;
					}
			}
		return mdEt;
		}

		#endregion  成员方法

        #region  自定义方法
        public List<ModuleCore.Entity.NormRelationProduct> GetListByProductID(int id)
        {
            return GetListArray(string.Concat("ProductID=", id));
        }
        /// <summary>
        /// 获取一个显示文本,此方法应再优化
        /// </summary>
        /// <param name="NormKey"></param>
        /// <returns></returns>
        public string GetShowInfoByNormKey(string NormKey)
        {
            string[] arry1 = NormKey.Split('_');
            StringBuilder sb = new StringBuilder();
            if(arry1.Length==2)
            {
                string[] arry =EbSite.Core.Strings.GetString.SplitString(arry1[1], "--");
                
                for (int i = 0; i < arry.Length; i++)
                {
                    string[] arry2 = arry[i].Split('-');
                    ModuleCore.Entity.Norms md = Norms.Instance.GetEntity(int.Parse(arry2[0]));
                    ModuleCore.Entity.NormsValue mdv = NormsValue.Instance.GetEntity(int.Parse(arry2[1]));
                    if (!Equals(md, null) && !Equals(mdv, null))
                    {
                        sb.Append("&nbsp;");
                        sb.Append(md.NormsName);
                        sb.Append(":");
                        sb.Append(mdv.NormsValueName);
                    }
                }
            }
            return sb.ToString();
        }

	    /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.NormRelationProduct GetEntityByNormID(string ID)
        {

            string rawKey = string.Concat("GetEntityByNormID-", ID);
            Entity.NormRelationProduct etEntity = base.GetCacheItem<Entity.NormRelationProduct>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = dalHelper.NormRelationProduct_GetEntityByNormID(ID);
                if (!Equals(etEntity, null))
                    base.AddCacheItem(rawKey, etEntity);
            }
            return etEntity;
        }

        public List<EbSite.Base.EntityAPI.ListItemModel> GetHeaderTextByList(List<Entity.NormRelationProduct> lst)
        {
            List<EbSite.Base.EntityAPI.ListItemModel> lstListItemModel = new List<ListItemModel>();
            if (!string.IsNullOrEmpty(lst[0].NormsValues))
            {
                string[] arry1 = lst[0].NormsValues.Split('_');
                if (arry1.Length == 2)
                {

                    string[] arry =EbSite.Core.Strings.GetString.SplitString(arry1[1], "--");
                    for (int i = 0; i < arry.Length; i++)
                    {
                        EbSite.Base.EntityAPI.ListItemModel md = new EbSite.Base.EntityAPI.ListItemModel();
                        string[] arry2 = arry[i].Split(new char[1] { '-' });
                        ModuleCore.Entity.Norms tmpMd = ModuleCore.BLL.Norms.Instance.GetEntity(int.Parse(arry2[0]));
                        if (tmpMd != null)
                        {
                            md.Text = tmpMd.NormsName;
                        }
                        else
                        {
                            md.Text = "";
                        }
                        md.ID = arry2[0];
                        lstListItemModel.Add(md);
                        //SkuTypes += "\"" + md.NormsName + "\"" + ",";
                    }
                }

            }
            return lstListItemModel;
        }
        public List<ChildTemp> GetDataListByList(List<Entity.NormRelationProduct> lst)
        {
            List<ChildTemp> lstListItemModel = new List<ChildTemp>();
            foreach (ModuleCore.Entity.NormRelationProduct normRelationProduct in lst)
            {
                string[] arr1 = normRelationProduct.NormsValues.Split('_');
                if (arr1.Length == 2)
                {
                    string ay = arr1[1];
                    string[] arry =EbSite.Core.Strings.GetString.SplitString(ay, "--");
                    for (int i = 0; i < arry.Length; i++)
                    {
                        ChildTemp md = new ChildTemp();
                        string[] arry2 = arry[i].Split('-');
                        md.pid = int.Parse(arry2[0]);
                        md.id = int.Parse(arry2[1]);
                        lstListItemModel.Add(md);
                        
                    }
                }


            }
            return lstListItemModel;
        }
        #endregion  自定义方法

        public List<Entity.NormRelationProduct> UnionGetListPages(int PageIndex, int PageSize,
                                                                                      out int RecordCount, string strWhere)
        {
            return dalHelper.NormRelationProduct_UnionGetListPages(PageIndex, PageSize, out RecordCount,strWhere);
        }
        /// <summary>
        /// 修改规格表中库存量
        /// </summary>
        /// <param name="id">库存ID</param>
        /// <param name="stocks">补充量</param>
        /// <returns></returns>
        public bool UpdateStocks(int id, int stocks, ModuleCore.Entity.productlog md)
        {
            return dalHelper.NormRelationProduct_UpdateStocks(id, stocks, md);
        }
        public bool UpdateStocksNoNorms(int productID, int stocks, ModuleCore.Entity.productlog md)
        {
            return dalHelper.NormRelationProduct_UpdateStocksNoNorms(productID, stocks, md);
        }
	}
    public class ChildTemp
    {
        public int pid { get; set; }
        public int id { get; set; }
    }
}

