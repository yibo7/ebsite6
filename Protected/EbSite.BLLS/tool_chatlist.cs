using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类Tool_ChatList 的摘要说明。
	/// </summary>
	public class Tool_ChatList:EbSite.Base.BLL.BllBase<Entity.Tool_ChatList, int> 
	{
		public static readonly Tool_ChatList Instance = new Tool_ChatList();
        private Tool_ChatList()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return dal.tool_chatlist_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(int id)
		{
            return dal.tool_chatlist_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.Tool_ChatList model)
		{
			base.InvalidateCache();
            return dal.tool_chatlist_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.Tool_ChatList model)
		{
			base.InvalidateCache();
			dal.tool_chatlist_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dal.tool_chatlist_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.Tool_ChatList GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.Tool_ChatList etEntity = base.GetCacheItem<Entity.Tool_ChatList>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dal.tool_chatlist_GetEntity(id);
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
			return dal.tool_chatlist_GetCount(strWhere);
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
			return dal.tool_chatlist_GetList( Top,  strWhere,  filedOrder);
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
                lstData = Core.DataSetHelper.RetrieveDataSet(ibyte);
            }
            return lstData;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.Tool_ChatList> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dal.tool_chatlist_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.Tool_ChatList> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
			 List<Entity.Tool_ChatList> lstData = base.GetCacheItem<List<Entity.Tool_ChatList>>(rawKey)  ;
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
		public List<Entity.Tool_ChatList> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.Tool_ChatList> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.Tool_ChatList> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dal.tool_chatlist_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.Tool_ChatList> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
			 List<Entity.Tool_ChatList> lstData = base.GetCacheItem<List<Entity.Tool_ChatList>>(rawKey)  ;
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
		public List<Entity.Tool_ChatList> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.Tool_ChatList> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.Tool_ChatList> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.Tool_ChatList> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.Tool_ChatList mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SalerUserID".ToLower()))
					{
						sValue = mdEt.SalerUserID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SalerName".ToLower()))
					{
						sValue = mdEt.SalerName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SalerUserName".ToLower()))
					{
						sValue = mdEt.SalerUserName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
					{
						sValue = mdEt.UserID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserName".ToLower()))
					{
						sValue = mdEt.UserName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserNiName".ToLower()))
					{
						sValue = mdEt.UserNiName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserIP".ToLower()))
					{
						sValue = mdEt.UserIP.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Msg".ToLower()))
					{
						sValue = mdEt.Msg.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "DateTime".ToLower()))
					{
						sValue = mdEt.DateTime.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "IsSalerSay".ToLower()))
					{
						sValue = mdEt.IsSalerSay.ToString();
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
			Entity.Tool_ChatList mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
                        mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "SalerUserID".ToLower()))
					{
						mdEntity.SalerUserID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "SalerName".ToLower()))
					{
						mdEntity.SalerName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "SalerUserName".ToLower()))
					{
						mdEntity.SalerUserName =column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "UserID".ToLower()))
					{
						mdEntity.UserID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "UserName".ToLower()))
					{
						mdEntity.UserName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "UserNiName".ToLower()))
					{
						mdEntity.UserNiName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "UserIP".ToLower()))
					{
						mdEntity.UserIP = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Msg".ToLower()))
					{
						mdEntity.Msg = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "DateTime".ToLower()))
					{
						mdEntity.DateTime = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "IsSalerSay".ToLower()))
					{
						mdEntity.IsSalerSay = int.Parse(column.ColumnValue);
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
		public Entity.Tool_ChatList GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.Tool_ChatList mdEt = new Entity.Tool_ChatList();
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
					else if(Equals(uc.ID.ToLower(),"SalerUserID".ToLower()))
					{
						mdEt.SalerUserID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"SalerName".ToLower()))
					{
						mdEt.SalerName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"SalerUserName".ToLower()))
					{
						mdEt.SalerUserName =sValue;
					}
					else if(Equals(uc.ID.ToLower(),"UserID".ToLower()))
					{
						mdEt.UserID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"UserName".ToLower()))
					{
						mdEt.UserName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"UserNiName".ToLower()))
					{
						mdEt.UserNiName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"UserIP".ToLower()))
					{
						mdEt.UserIP = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Msg".ToLower()))
					{
						mdEt.Msg = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"DateTime".ToLower()))
					{
						mdEt.DateTime = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"IsSalerSay".ToLower()))
					{
						mdEt.IsSalerSay = int.Parse(sValue);
					}
			}
		return mdEt;
		}

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 获取聊天记录
        /// </summary>
        /// <param name="salerID">销售员ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public DataTable GetChatList(int salerID, int userID)
        {
            return dal.GetChatList(salerID, userID);
        }
        /// <summary>
        /// 获取聊天记录
        /// </summary>
        /// <param name="salerID">销售员ID</param>
        /// <returns></returns>
        public DataTable GetChatList(int salerID)
        {
            return dal.GetChatList(salerID);
        }

        #endregion 自定义方法
	}
}

