using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类SpaceTabWidget 的摘要说明。
	/// </summary>
    public class SpaceTabWidget : Base.BLL.BllBase<Entity.SpaceTabWidget, int> 
	{
		public static readonly SpaceTabWidget Instance = new SpaceTabWidget();
		private  SpaceTabWidget()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.SpaceTabWidget_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.SpaceTabWidget_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.SpaceTabWidget model)
		{
			base.InvalidateCache();
			return dal.SpaceTabWidget_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.SpaceTabWidget model)
		{
			base.InvalidateCache();
			dal.SpaceTabWidget_Update(model);
		}

		

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.SpaceTabWidget GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
			Entity.SpaceTabWidget etEntity = base.GetCacheItem<Entity.SpaceTabWidget>(rawKey)  ;
			if (Equals(etEntity,null))
			{
				etEntity = dal.SpaceTabWidget_GetEntity(id);
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
			return dal.SpaceTabWidget_GetCount(strWhere);
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
			return dal.SpaceTabWidget_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.SpaceTabWidget> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dal.SpaceTabWidget_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.SpaceTabWidget> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.SpaceTabWidget> lstData = base.GetCacheItem<List<Entity.SpaceTabWidget>>(rawKey);
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
		public List<Entity.SpaceTabWidget> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.SpaceTabWidget> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.SpaceTabWidget> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dal.SpaceTabWidget_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.SpaceTabWidget> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.SpaceTabWidget> lstData = base.GetCacheItem<List<Entity.SpaceTabWidget>>(rawKey);
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
		public List<Entity.SpaceTabWidget> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.SpaceTabWidget> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.SpaceTabWidget> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.SpaceTabWidget> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.SpaceTabWidget mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "TabID".ToLower()))
					{
						sValue = mdEt.TabID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "WidgetID".ToLower()))
					{
						sValue = mdEt.WidgetID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "LayoutPane".ToLower()))
					{
						sValue = mdEt.LayoutPane.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
					{
						sValue = mdEt.UserID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderNum".ToLower()))
					{
						sValue = mdEt.OrderNum.ToString();
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
			Entity.SpaceTabWidget mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "TabID".ToLower()))
					{
						mdEntity.TabID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "WidgetID".ToLower()))
					{
						mdEntity.WidgetID = new Guid(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "LayoutPane".ToLower()))
					{
						mdEntity.LayoutPane = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "UserID".ToLower()))
					{
						mdEntity.UserID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderNum".ToLower()))
					{
						mdEntity.OrderNum = int.Parse(column.ColumnValue);
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
		public Entity.SpaceTabWidget GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.SpaceTabWidget mdEt = new Entity.SpaceTabWidget();
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
					else if(Equals(uc.ID.ToLower(),"TabID".ToLower()))
					{
						mdEt.TabID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"WidgetID".ToLower()))
					{
						mdEt.WidgetID = new Guid(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"LayoutPane".ToLower()))
					{
						mdEt.LayoutPane = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"UserID".ToLower()))
					{
						mdEt.UserID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OrderNum".ToLower()))
					{
						mdEt.OrderNum = int.Parse(sValue);
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法
        public List<Entity.SpaceTabWidget> GetListWidgets(int UserID,int TabID)
        {
            return GetListArray(0, string.Concat("(UserID=", UserID, ") and TabID=", TabID), "OrderNum");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateChange(int id, string Layout, Guid WidgetID, int OrderNum)
        {
            dal.SpaceTabWidget_UpdateChange(id,Layout,WidgetID,OrderNum);
            base.InvalidateCache();
        }
        /// <summary>
        /// 添加部件
        /// </summary>
        /// <param name="UserID">当前登录用户ID</param>
        /// <param name="TabID">当前标签ID</param>
        /// <param name="WidgetID">所选部件ID</param>
        public void AddWidgetToTab(int UserID, int TabID, string[] WidgetIDs)
        {
            
            foreach (string widgetID in WidgetIDs)
            {
                if(string.IsNullOrEmpty(widgetID))
                    continue;
                Entity.SpaceTabWidget md = new Entity.SpaceTabWidget();
                md.LayoutPane = "";
                md.OrderNum = 0;
                md.TabID = TabID;
                md.UserID = UserID;
                md.WidgetID = Guid.NewGuid();
                Add(md);
                //复制模板参数
                Entity.WidgetShow mdTem =  Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetEntityByID(new Guid(widgetID));

                Base.ExtWidgets.HomeWidgetManage.DataBLL.Instance.AddData(md.WidgetID, mdTem.TypeWidget, mdTem.Title, mdTem.ModulID);

                //同时复制一份原来样板，把ID改成此ID
                //if (!dal.SpaceTabWidget_Exists(UserID, TabID, widgetID))
                //{
                   
                //}
            }
            
            base.InvalidateCache();
        }
        public void DelWidgetFromTab(int UserID, int TabID, string WidgetIDs)
        {
            if (!string.IsNullOrEmpty(WidgetIDs))
            {
                dal.SpaceTabWidget_Dels(UserID, TabID, WidgetIDs);
                string[] aWidgetIDs = WidgetIDs.Split(',');
                foreach (string widgetID in aWidgetIDs)
                {
                    if (!string.IsNullOrEmpty(widgetID))
                        Base.ExtWidgets.HomeWidgetManage.DataBLL.Instance.Delete(widgetID);
                }
                
                base.InvalidateCache();
            }
           
        }
        public void Delete(int UserID, int TabID, string WidgetID)
        {
            DelWidgetFromTab(UserID, TabID, WidgetID);
        }

	    /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();
            dal.SpaceTabWidget_Delete(id);
        }
	    #endregion  自定义方法
	}
}

