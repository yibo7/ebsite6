using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类outlinks 的摘要说明。
	/// </summary>
    public class outlinks : EbSite.Base.BLL.BllBase<Entity.outlinks, int> 
	{
		public static readonly outlinks Instance = new outlinks();
		private  outlinks()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.outlinks_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.outlinks_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.outlinks model)
		{
			base.InvalidateCache();
			return dal.outlinks_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.outlinks model)
		{
			base.InvalidateCache();
			dal.outlinks_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dal.outlinks_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.outlinks GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.outlinks etEntity = base.GetCacheItem<Entity.outlinks>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dal.outlinks_GetEntity(id);
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
			return dal.outlinks_GetCount(strWhere);
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
			return dal.outlinks_GetList( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		
        public DataSet GetListCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListCache-", strWhere, Top, filedOrder);
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
		override public List<Entity.outlinks> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dal.outlinks_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.outlinks> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.outlinks> lstData = base.GetCacheItem<List<Entity.outlinks>>(rawKey);
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
		public List<Entity.outlinks> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.outlinks> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.outlinks> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dal.outlinks_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.outlinks> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.outlinks> lstData = base.GetCacheItem<List<Entity.outlinks>>(rawKey);
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
		public List<Entity.outlinks> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.outlinks> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.outlinks> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.outlinks> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.outlinks mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SiteName".ToLower()))
					{
						sValue = mdEt.SiteName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Url".ToLower()))
					{
						sValue = mdEt.Url.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "LogoUrl".ToLower()))
					{
						sValue = mdEt.LogoUrl.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "QQ".ToLower()))
					{
						sValue = mdEt.QQ.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Email".ToLower()))
					{
						sValue = mdEt.Email.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Tel".ToLower()))
					{
						sValue = mdEt.Tel.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Mobile".ToLower()))
					{
						sValue = mdEt.Mobile.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Demo".ToLower()))
					{
						sValue = mdEt.Demo.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "IsHaveLogo".ToLower()))
					{
						sValue = mdEt.IsHaveLogo.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
					{
						sValue = mdEt.OrderID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SiteID".ToLower()))
					{
						sValue = mdEt.SiteID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "IsAuditing".ToLower()))
					{
						sValue = mdEt.IsAuditing.ToString();
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
			Entity.outlinks mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "SiteName".ToLower()))
					{
						mdEntity.SiteName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Url".ToLower()))
					{
						mdEntity.Url = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "LogoUrl".ToLower()))
					{
						mdEntity.LogoUrl = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "QQ".ToLower()))
					{
						mdEntity.QQ = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Email".ToLower()))
					{
						mdEntity.Email = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Tel".ToLower()))
					{
						mdEntity.Tel = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Mobile".ToLower()))
					{
						mdEntity.Mobile = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Demo".ToLower()))
					{
						mdEntity.Demo = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "IsHaveLogo".ToLower()))
					{
						mdEntity.IsHaveLogo = bool.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderID".ToLower()))
					{
						mdEntity.OrderID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "SiteID".ToLower()))
					{
						mdEntity.SiteID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "IsAuditing".ToLower()))
					{
						mdEntity.IsAuditing = bool.Parse(column.ColumnValue);
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
		public Entity.outlinks GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.outlinks mdEt = new Entity.outlinks();
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
					else if(Equals(uc.ID.ToLower(),"SiteName".ToLower()))
					{
						mdEt.SiteName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Url".ToLower()))
					{
						mdEt.Url = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"LogoUrl".ToLower()))
					{
						mdEt.LogoUrl = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"QQ".ToLower()))
					{
						mdEt.QQ = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Email".ToLower()))
					{
						mdEt.Email = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Tel".ToLower()))
					{
						mdEt.Tel = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Mobile".ToLower()))
					{
						mdEt.Mobile = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Demo".ToLower()))
					{
						mdEt.Demo = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"IsHaveLogo".ToLower()))
					{
						mdEt.IsHaveLogo = bool.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OrderID".ToLower()))
					{
						mdEt.OrderID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"SiteID".ToLower()))
					{
						mdEt.SiteID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"IsAuditing".ToLower()))
					{
						mdEt.IsAuditing = bool.Parse(sValue);
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法
		
		#endregion  自定义方法
	}
}


