using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Shop.ModuleCore.BLL
{
	/// <summary>
	/// 业务逻辑类ProductsImg 的摘要说明。
	/// </summary>
	public class ProductsImg: Base.BLLBase<Entity.ProductsImg, int> 
	{
		public static readonly ProductsImg Instance = new ProductsImg();
		private  ProductsImg()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.ProductsImg_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dalHelper.ProductsImg_Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.ProductsImg model)
		{
			base.InvalidateCache();
			return dalHelper.ProductsImg_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.ProductsImg model)
		{
			base.InvalidateCache();
			dalHelper.ProductsImg_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int ID)
		{
			base.InvalidateCache();
			
			dalHelper.ProductsImg_Delete(ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.ProductsImg GetEntity(int ID)
		{
			
			string rawKey = string.Concat("GetEntity-", ID);
            Entity.ProductsImg etEntity = base.GetCacheItem<Entity.ProductsImg>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.ProductsImg_GetEntity(ID);
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
			return dalHelper.ProductsImg_GetCount(strWhere);
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
			return dalHelper.ProductsImg_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.ProductsImg> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.ProductsImg_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.ProductsImg> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.ProductsImg> lstData = base.GetCacheItem<List<Entity.ProductsImg>>(rawKey);
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
		public List<Entity.ProductsImg> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.ProductsImg> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.ProductsImg> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.ProductsImg_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.ProductsImg> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.ProductsImg> lstData = base.GetCacheItem<List<Entity.ProductsImg>>(rawKey);
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
		public List<Entity.ProductsImg> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.ProductsImg> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.ProductsImg> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.ProductsImg> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.ProductsImg mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "ID".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ProductName".ToLower()))
					{
						sValue = mdEt.ProductName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ProductID".ToLower()))
					{
						sValue = mdEt.ProductID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "BigImg".ToLower()))
					{
						sValue = mdEt.BigImg.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SmallImg".ToLower()))
					{
						sValue = mdEt.SmallImg.ToString();
					}
                    else if (Equals(uc.ID.ToLower(), "Title".ToLower()))
					{
                        sValue = mdEt.Title.ToString();
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
			Entity.ProductsImg mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "ID".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ProductName".ToLower()))
					{
						mdEntity.ProductName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "ProductID".ToLower()))
					{
						mdEntity.ProductID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "BigImg".ToLower()))
					{
						mdEntity.BigImg = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "SmallImg".ToLower()))
					{
						mdEntity.SmallImg = column.ColumnValue;
					}
                    else if (Equals(column.ColumnName.ToLower(), "Title".ToLower()))
					{
                        mdEntity.Title = column.ColumnValue;
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
		public Entity.ProductsImg GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.ProductsImg mdEt = new Entity.ProductsImg();
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
					else if(Equals(uc.ID.ToLower(),"ProductName".ToLower()))
					{
						mdEt.ProductName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"ProductID".ToLower()))
					{
						mdEt.ProductID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"BigImg".ToLower()))
					{
						mdEt.BigImg = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"SmallImg".ToLower()))
					{
						mdEt.SmallImg = sValue;
					}
                    else if (Equals(uc.ID.ToLower(), "Title".ToLower()))
					{
                        mdEt.Title = sValue;
					}
                
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法
		public List<ModuleCore.Entity.ProductsImg> GetListByProductID(long id)
		{
            return GetListArray(string.Concat("ProductID=" , id));
		}

         public DataSet GetProductShowData(int id)
         {
             return dalHelper.GetProductShowData(id);
         }
		#endregion  自定义方法
	}
}

