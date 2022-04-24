using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类TheThirdLoginCode 的摘要说明。
	/// </summary>
    public class TheThirdLoginCode : Base.BLL.BLLBaseUser<Entity.TheThirdLoginCode,int>
	{
		public static readonly TheThirdLoginCode Instance = new TheThirdLoginCode();
		private  TheThirdLoginCode()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return dal.thethirdlogincode_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
            return dal.thethirdlogincode_Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.TheThirdLoginCode model)
		{
			base.InvalidateCache();
            return dal.thethirdlogincode_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.TheThirdLoginCode model)
		{
			base.InvalidateCache();
            dal.thethirdlogincode_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int ID)
		{
			base.InvalidateCache();

            dal.thethirdlogincode_Delete(ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.TheThirdLoginCode GetEntity(int ID)
		{
			
			string rawKey = string.Concat("GetEntity-", ID);
            Entity.TheThirdLoginCode etEntity = base.GetCacheItem<Entity.TheThirdLoginCode>(rawKey);
			if (Equals(etEntity,null))
			{
                etEntity = dal.thethirdlogincode_GetEntity(ID);
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
            return dal.thethirdlogincode_GetCount(strWhere);
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
            return dal.thethirdlogincode_GetList(Top, strWhere, filedOrder);
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
		override public List<Entity.TheThirdLoginCode> GetListArray(int Top, string strWhere, string filedOrder)
		{
            return dal.thethirdlogincode_GetListArray(Top, strWhere, filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.TheThirdLoginCode> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
			 List<Entity.TheThirdLoginCode> lstData = base.GetCacheItem<List<Entity.TheThirdLoginCode>>(rawKey)  ;
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
		public List<Entity.TheThirdLoginCode> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.TheThirdLoginCode> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.TheThirdLoginCode> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
            return dal.thethirdlogincode_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.TheThirdLoginCode> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
			 List<Entity.TheThirdLoginCode> lstData = base.GetCacheItem<List<Entity.TheThirdLoginCode>>(rawKey)  ;
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
		public List<Entity.TheThirdLoginCode> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.TheThirdLoginCode> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.TheThirdLoginCode> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.TheThirdLoginCode> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.TheThirdLoginCode mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "ID".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "userid".ToLower()))
					{
						sValue = mdEt.userid.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "username".ToLower()))
					{
						sValue = mdEt.username.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "tokencode".ToLower()))
					{
						sValue = mdEt.tokencode.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "appname".ToLower()))
					{
						sValue = mdEt.appname.ToString();
					}
                    else if (Equals(uc.ID.ToLower(), "isbind".ToLower()))
                    {
                        sValue = mdEt.IsBind.ToString();
                    }
					else if (Equals(uc.ID.ToLower(), "otherinfo".ToLower()))
					{
						sValue = mdEt.otherinfo.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "adddate".ToLower()))
					{
						sValue = mdEt.adddate.ToString();
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
			Entity.TheThirdLoginCode mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "ID".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "userid".ToLower()))
					{
						mdEntity.userid = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "username".ToLower()))
					{
						mdEntity.username = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "tokencode".ToLower()))
					{
						mdEntity.tokencode = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "appname".ToLower()))
					{
						mdEntity.appname = column.ColumnValue;
					}
                    else if (Equals(column.ColumnName.ToLower(), "isbind".ToLower()))
                    {
                        mdEntity.IsBind = int.Parse(column.ColumnValue);
                    }
					else if(Equals(column.ColumnName.ToLower(), "otherinfo".ToLower()))
					{
						mdEntity.otherinfo = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "adddate".ToLower()))
					{
						mdEntity.adddate = DateTime.Parse(column.ColumnValue);
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
		public Entity.TheThirdLoginCode GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.TheThirdLoginCode mdEt = new Entity.TheThirdLoginCode();
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
					else if(Equals(uc.ID.ToLower(),"userid".ToLower()))
					{
						mdEt.userid = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"username".ToLower()))
					{
						mdEt.username = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"tokencode".ToLower()))
					{
						mdEt.tokencode = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"appname".ToLower()))
					{
						mdEt.appname = sValue;
					}
                    else if (Equals(uc.ID.ToLower(), "isbind".ToLower()))
                    {
                        mdEt.IsBind = int.Parse(sValue);
                    }
					else if(Equals(uc.ID.ToLower(),"otherinfo".ToLower()))
					{
						mdEt.otherinfo = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"adddate".ToLower()))
					{
						mdEt.adddate = DateTime.Parse(sValue);
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strCode)
        {
            return dal.thethirdlogincode_Exists(strCode);
        }
        /// <summary>
        /// 是否已经绑定过
        /// </summary>
        /// <param name="strToken">授权码</param>
        /// <returns></returns>
        public bool IsBind(string strToken)
        {
            return dal.thethirdlogincode_IsBind(strToken);
        }

        /// <summary>
        /// 根据授权码更新
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        public bool UpdateByToken(Entity.TheThirdLoginCode model)
        {
            return dal.thethirdlogincode_UpdateByToken(model);
        }

        /// <summary>
        /// 根据授权码获取用户ID
        /// </summary>
        /// <param name="strToken"></param>
        /// <returns></returns>
        public int GetUserIDByToken(string strToken)
        {
            return dal.thethirdlogincode_GetUserIDByToken(strToken);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.TheThirdLoginCode GetEntity(string Uid, string appName)
        {
            return dal.thethirdlogincode_GetEntity(Uid,appName);
        }
		#endregion  自定义方法
	}
}

