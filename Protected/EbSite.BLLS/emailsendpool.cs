using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类emailsendpool 的摘要说明。
	/// </summary>
    public class emailsendpool : Base.BLL.BllBase<Entity.emailsendpool, int> 
	{
		public static readonly emailsendpool Instance = new emailsendpool();
		private  emailsendpool()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return DbProviderUser.GetInstance().emailsendpool_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return DbProviderUser.GetInstance().emailsendpool_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.emailsendpool model)
		{
			base.InvalidateCache();
			return DbProviderUser.GetInstance().emailsendpool_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.emailsendpool model)
		{
			base.InvalidateCache();
			DbProviderUser.GetInstance().emailsendpool_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			DbProviderUser.GetInstance().emailsendpool_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.emailsendpool GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.emailsendpool etEntity = base.GetCacheItem<Entity.emailsendpool>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = DbProviderUser.GetInstance().emailsendpool_GetEntity(id);
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
			return DbProviderUser.GetInstance().emailsendpool_GetCount(strWhere);
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
			return DbProviderUser.GetInstance().emailsendpool_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.emailsendpool> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return DbProviderUser.GetInstance().emailsendpool_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.emailsendpool> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.emailsendpool> lstData = base.GetCacheItem<List<Entity.emailsendpool>>(rawKey);
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
		public List<Entity.emailsendpool> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.emailsendpool> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.emailsendpool> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return DbProviderUser.GetInstance().emailsendpool_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.emailsendpool> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.emailsendpool> lstData = base.GetCacheItem<List<Entity.emailsendpool>>(rawKey);
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
		public List<Entity.emailsendpool> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.emailsendpool> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.emailsendpool> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.emailsendpool> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.emailsendpool mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Title".ToLower()))
					{
						sValue = mdEt.Title.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "MsgBody".ToLower()))
					{
						sValue = mdEt.MsgBody.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SendToUserID".ToLower()))
					{
						sValue = mdEt.SendToUserID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SendToEmail".ToLower()))
					{
						sValue = mdEt.SendToEmail.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AttaUrl".ToLower()))
					{
						sValue = mdEt.AttaUrl.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AddDateTime".ToLower()))
					{
						sValue = mdEt.AddDateTime.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AddDateTimeInc".ToLower()))
					{
						sValue = mdEt.AddDateTimeInc.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AddUserID".ToLower()))
					{
						sValue = mdEt.AddUserID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AddUserNiName".ToLower()))
					{
						sValue = mdEt.AddUserNiName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "IsSended".ToLower()))
					{
						sValue = mdEt.IsSended.ToString();
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
			Entity.emailsendpool mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Title".ToLower()))
					{
						mdEntity.Title = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "MsgBody".ToLower()))
					{
						mdEntity.MsgBody = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "SendToUserID".ToLower()))
					{
						mdEntity.SendToUserID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "SendToEmail".ToLower()))
					{
						mdEntity.SendToEmail = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AttaUrl".ToLower()))
					{
						mdEntity.AttaUrl = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AddDateTime".ToLower()))
					{
						mdEntity.AddDateTime = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AddDateTimeInc".ToLower()))
					{
						mdEntity.AddDateTimeInc = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AddUserID".ToLower()))
					{
						mdEntity.AddUserID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AddUserNiName".ToLower()))
					{
						mdEntity.AddUserNiName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "IsSended".ToLower()))
					{
						mdEntity.IsSended = int.Parse(column.ColumnValue);
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
		public Entity.emailsendpool GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.emailsendpool mdEt = new Entity.emailsendpool();
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
					else if(Equals(uc.ID.ToLower(),"Title".ToLower()))
					{
						mdEt.Title = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"MsgBody".ToLower()))
					{
						mdEt.MsgBody = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"SendToUserID".ToLower()))
					{
						mdEt.SendToUserID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"SendToEmail".ToLower()))
					{
						mdEt.SendToEmail = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AttaUrl".ToLower()))
					{
						mdEt.AttaUrl = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AddDateTime".ToLower()))
					{
						mdEt.AddDateTime = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AddDateTimeInc".ToLower()))
					{
						mdEt.AddDateTimeInc = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AddUserID".ToLower()))
					{
						mdEt.AddUserID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AddUserNiName".ToLower()))
					{
						mdEt.AddUserNiName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"IsSended".ToLower()))
					{
						mdEt.IsSended = int.Parse(sValue);
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法
		
		#endregion  自定义方法
	}
}

