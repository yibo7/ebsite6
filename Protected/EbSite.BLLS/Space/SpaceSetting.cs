using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类SpaceSetting 的摘要说明。
	/// </summary>
    public class SpaceSetting : Base.BLL.BllBase<Entity.SpaceSetting, int> 
	{
		public static readonly SpaceSetting Instance = new SpaceSetting();
		private  SpaceSetting()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.SpaceSetting_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.SpaceSetting_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.SpaceSetting model)
		{
			base.InvalidateCache();
			return dal.SpaceSetting_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.SpaceSetting model)
		{
			base.InvalidateCache();
			dal.SpaceSetting_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dal.SpaceSetting_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.SpaceSetting GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.SpaceSetting etEntity = base.GetCacheItem<Entity.SpaceSetting>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dal.SpaceSetting_GetEntity(id);
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
			return dal.SpaceSetting_GetCount(strWhere);
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
			return dal.SpaceSetting_GetList( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetList-", strWhere,Top,filedOrder);
			 DataSet lstData = base.GetCacheItem<DataSet>(rawKey) ;
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
		override public List<Entity.SpaceSetting> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dal.SpaceSetting_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.SpaceSetting> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.SpaceSetting> lstData = base.GetCacheItem<List<Entity.SpaceSetting>>(rawKey) ;
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
		public List<Entity.SpaceSetting> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.SpaceSetting> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.SpaceSetting> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dal.SpaceSetting_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.SpaceSetting> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.SpaceSetting> lstData = base.GetCacheItem<List<Entity.SpaceSetting>>(rawKey);
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
		public List<Entity.SpaceSetting> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.SpaceSetting> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.SpaceSetting> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.SpaceSetting> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.SpaceSetting mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
					{
						sValue = mdEt.UserID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Title".ToLower()))
					{
						sValue = mdEt.Title.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Description".ToLower()))
					{
						sValue = mdEt.Description.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ReWriteName".ToLower()))
					{
						sValue = mdEt.ReWriteName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ThemeID".ToLower()))
					{
						sValue = mdEt.ThemeID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ThemePath".ToLower()))
					{
						sValue = mdEt.ThemePath.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "DefaultTabID".ToLower()))
					{
						sValue = mdEt.DefaultTabID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Status".ToLower()))
					{
						sValue = mdEt.Status.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AddTime".ToLower()))
					{
						sValue = mdEt.AddTime.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UpdatedateTime".ToLower()))
					{
						sValue = mdEt.UpdatedateTime.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "VisitedTimes".ToLower()))
					{
						sValue = mdEt.VisitedTimes.ToString();
					}
				SetValueFromControl(uc, sValue);
				}
			}
		}
		/// <summary>
		/// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
		/// </summary>
        public void SaveEntityFromCtr(PlaceHolder ph, string sUserName)
		{
            SaveEntityFromCtr(ph, null, sUserName);
		}
		/// <summary>
		/// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
		/// </summary>
		public void SaveEntityFromCtr(PlaceHolder ph, List<EbSite.Base.BLL.OtherColumn> lstOtherColumn,string sUserName)
		{
			Entity.SpaceSetting mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "UserID".ToLower()))
					{
						mdEntity.UserID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Title".ToLower()))
					{
						mdEntity.Title = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Description".ToLower()))
					{
						mdEntity.Description = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "ReWriteName".ToLower()))
					{
						mdEntity.ReWriteName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "ThemeID".ToLower()))
					{
						mdEntity.ThemeID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ThemePath".ToLower()))
					{
						mdEntity.ThemePath = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "DefaultTabID".ToLower()))
					{
						mdEntity.DefaultTabID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Status".ToLower()))
					{
						mdEntity.Status = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AddTime".ToLower()))
					{
						mdEntity.AddTime = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "UpdatedateTime".ToLower()))
					{
						mdEntity.UpdatedateTime = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "VisitedTimes".ToLower()))
					{
						mdEntity.VisitedTimes = int.Parse(column.ColumnValue);
					}
				}
			}
			if (mdEntity.id>0)
			{
				Update(mdEntity);
			}else{
				int spid =  Add(mdEntity);
			    int gid =   EbSite.BLL.User.UserGroupProfile.GetRoleIDByUserName(sUserName);
			    List<Entity.SpaceTabsDefault> lst =  SpaceTabsDefault.Instance.GetDefaultTabsByUserGroup(gid);
                foreach (Entity.SpaceTabsDefault spaceTabsDefault in lst)
			    {
                    Entity.SpaceTabs md = new Entity.SpaceTabs();
			        md.ICOImg = spaceTabsDefault.ICOImg;
			        md.Layout = spaceTabsDefault.Layout;
			        md.Mark = "";
			        md.OrderNum = spaceTabsDefault.OrderNum;
			        md.ParentID = 0;
			        md.TabName = spaceTabsDefault.TabName;
			        md.UserID = mdEntity.UserID;
			        SpaceTabs.Instance.Add(md);
			    }
			}
		}
		/// <summary>
		/// 从PlaceHolder中获取一个实例
		/// </summary>
		public Entity.SpaceSetting GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.SpaceSetting mdEt = new Entity.SpaceSetting();
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
					else if(Equals(uc.ID.ToLower(),"UserID".ToLower()))
					{
						mdEt.UserID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Title".ToLower()))
					{
						mdEt.Title = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Description".ToLower()))
					{
						mdEt.Description = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"ReWriteName".ToLower()))
					{
						mdEt.ReWriteName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"ThemeID".ToLower()))
					{
						mdEt.ThemeID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ThemePath".ToLower()))
					{
						mdEt.ThemePath = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"DefaultTabID".ToLower()))
					{
						mdEt.DefaultTabID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Status".ToLower()))
					{
						mdEt.Status = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AddTime".ToLower()))
					{
						mdEt.AddTime = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"UpdatedateTime".ToLower()))
					{
						mdEt.UpdatedateTime = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"VisitedTimes".ToLower()))
					{
						mdEt.VisitedTimes = int.Parse(sValue);
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法
		public string GetThemePathByUserID(int UserID)
		{
		    return dal.SpaceSetting_GetThemePath(UserID).Trim();
		}
        public int GetSpaceIDByUserID(int id)
        {
            return dal.SpaceSetting_GetSpaceIDByUserID(id);
        }
        public Entity.SpaceSetting GetEntityByUserID(int Userid)
        {
            int sid = GetSpaceIDByUserID(Userid);

            return GetEntity(sid);
        }
        public void UpdateTheme(int UserID, int ThemeID, string ThemePath)
        {
            base.InvalidateCache();
            dal.SpaceSetting_UpdateTheme(UserID,  ThemeID,  ThemePath);
        }

        public int GetDefaultTabID(int iUserID)
        {
           return dal.SpaceSetting_GetDefaultTabID(iUserID);
        }
	    #endregion  自定义方法
	}
}

