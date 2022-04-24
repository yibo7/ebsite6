using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类SpaceTabs 的摘要说明。
	/// </summary>
    public class SpaceTabs : Base.BLL.BllBase<Entity.SpaceTabs, int> 
	{
		public static readonly SpaceTabs Instance = new SpaceTabs();
		private  SpaceTabs()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.SpaceTabs_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.SpaceTabs_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.SpaceTabs model)
		{
			base.InvalidateCache();
            model.OrderNum = GetMaxOrderID(model.UserID) + 1;
			return dal.SpaceTabs_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.SpaceTabs model)
		{
			base.InvalidateCache();
			dal.SpaceTabs_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dal.SpaceTabs_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.SpaceTabs GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.SpaceTabs etEntity = base.GetCacheItem<Entity.SpaceTabs>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dal.SpaceTabs_GetEntity(id);
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
			return dal.SpaceTabs_GetCount(strWhere);
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
			return dal.SpaceTabs_GetList( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetList-", strWhere,Top,filedOrder);
			 DataSet lstData = base.GetCacheItem<DataSet>(rawKey);
			if (Equals(lstData,null))
			{
				lstData = GetList( Top,  strWhere,  filedOrder);
				if (!Equals(lstData,null))
					base.AddCacheItem(rawKey, lstData);
			}
			return lstData;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.SpaceTabs> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dal.SpaceTabs_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.SpaceTabs> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.SpaceTabs> lstData = base.GetCacheItem<List<Entity.SpaceTabs>>(rawKey);
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
		public List<Entity.SpaceTabs> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.SpaceTabs> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.SpaceTabs> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dal.SpaceTabs_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.SpaceTabs> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.SpaceTabs> lstData = base.GetCacheItem<List<Entity.SpaceTabs>>(rawKey);
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
		public List<Entity.SpaceTabs> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.SpaceTabs> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.SpaceTabs> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.SpaceTabs> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.SpaceTabs mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "TabName".ToLower()))
					{
						sValue = mdEt.TabName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Layout".ToLower()))
					{
						sValue = mdEt.Layout.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderNum".ToLower()))
					{
						sValue = mdEt.OrderNum.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ICOImg".ToLower()))
					{
						sValue = mdEt.ICOImg.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
					{
						sValue = mdEt.UserID.ToString();
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
			Entity.SpaceTabs mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "TabName".ToLower()))
					{
						mdEntity.TabName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Layout".ToLower()))
					{
						mdEntity.Layout = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderNum".ToLower()))
					{
						mdEntity.OrderNum = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ICOImg".ToLower()))
					{
						mdEntity.ICOImg = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "UserID".ToLower()))
					{
						mdEntity.UserID = int.Parse(column.ColumnValue);
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
		public Entity.SpaceTabs GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.SpaceTabs mdEt = new Entity.SpaceTabs();
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
					else if(Equals(uc.ID.ToLower(),"TabName".ToLower()))
					{
						mdEt.TabName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Layout".ToLower()))
					{
						mdEt.Layout = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"OrderNum".ToLower()))
					{
						mdEt.OrderNum = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ICOImg".ToLower()))
					{
						mdEt.ICOImg = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"UserID".ToLower()))
					{
						mdEt.UserID = int.Parse(sValue);
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法

        public List<Entity.SpaceTabs> GetSubTabs(int UserID,int ParentID)
        {
            return GetListArray(0, string.Concat("UserID=", UserID, " and ParentID=", ParentID), "ordernum");
        }

	    public List<Entity.SpaceTabs> GetTabsByUserID(int UserID)
        {
            return GetListArray(0, string.Concat("ParentID=0 and (UserID=0 or UserID=", UserID,")"), " ordernum");
        }
        public string GetLayoutName(int id)
        {
            string rawKey = string.Concat("GetLayoutName-", id);
            string sLayoutName = base.GetCacheItem<string>(rawKey) ;
            if (string.IsNullOrEmpty(sLayoutName))
            {
                sLayoutName = dal.SpaceTabs_GetLayoutName(id);
                if (!string.IsNullOrEmpty(sLayoutName))
                    base.AddCacheItem(rawKey, sLayoutName);
            }
            return sLayoutName;
           
        }

        public int GetMaxOrderID(int UserId)
        {
            return dal.SpaceTabs_GetMaxOrderID(UserId);
        }

        public void UpdateOrders(int UserId, string SortStr)
        {
            Hashtable ht = new Hashtable();

            string[] aTabs = SortStr.Split('|');

            foreach (string aTab in aTabs)
            {
                string[] aTabData = aTab.Split(',');
                if(aTabData.Length==2)
                {
                    string sID = aTabData[0];
                    string sNum = aTabData[1];
                    if(!string.IsNullOrEmpty(sID)&&!string.IsNullOrEmpty(sNum))
                    {
                        ht.Add(sID, sNum);
                    }
                }
            }
            dal.SpaceTabs_UpdateOrders(UserId, ht);
        }

        public void UpdateLayout(int UserID, int TabID, string LayoutName)
        {
            dal.SpaceTabs_UpdateLayout(UserID,  TabID,  LayoutName);
            base.InvalidateCache();
        }
        public int GetTabIDFormMark(int ParentID, string Mark)
        {
            return dal.SpaceTabs_GetTabIDFormMark(ParentID, Mark);
        }
	    #endregion  自定义方法
	}
}

