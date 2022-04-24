using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类vote 的摘要说明。
	/// </summary>
    public class vote : EbSite.Base.BLL.BllBase<Entity.vote, int> 
	{
		public static readonly vote Instance = new vote();
		private  vote()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.vote_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.vote_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.vote model)
		{
			base.InvalidateCache();
			return dal.vote_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.vote model)
		{
			base.InvalidateCache();
			dal.vote_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dal.vote_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.vote GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
			Entity.vote etEntity = base.GetCacheItem<Entity.vote>(rawKey)  ;
			if (Equals(etEntity,null))
			{
				etEntity = dal.vote_GetEntity(id);
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
			return dal.vote_GetCount(strWhere);
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
			return dal.vote_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.vote> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dal.vote_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.vote> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.vote> lstData = base.GetCacheItem<List<Entity.vote>>(rawKey);
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
		public List<Entity.vote> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.vote> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.vote> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dal.vote_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.vote> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
			 List<Entity.vote> lstData = base.GetCacheItem<List<Entity.vote>>(rawKey)  ;
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
		public List<Entity.vote> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.vote> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.vote> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.vote> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.vote mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "VoteName".ToLower()))
					{
						sValue = mdEt.VoteName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AllowMaxSel".ToLower()))
					{
						sValue = mdEt.AllowMaxSel.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "IsMoreSel".ToLower()))
					{
						sValue = mdEt.IsMoreSel.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "MarkInt".ToLower()))
					{
						sValue = mdEt.MarkInt.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "MarkStr".ToLower()))
					{
						sValue = mdEt.MarkStr.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "VoteCount".ToLower()))
					{
						sValue = mdEt.VoteCount.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "StartDate".ToLower()))
					{
						sValue = mdEt.StartDate.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "EndDate".ToLower()))
					{
						sValue = mdEt.EndDate.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "IsItemColorRan".ToLower()))
					{
						sValue = mdEt.IsItemColorRan.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "VoteInfo".ToLower()))
					{
						sValue = mdEt.VoteInfo.ToString();
					}

                    else if (Equals(uc.ID.ToLower(), "ClassID".ToLower()))
                    {
                        sValue = mdEt.ClassID.ToString();
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
			Entity.vote mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "VoteName".ToLower()))
					{
						mdEntity.VoteName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AllowMaxSel".ToLower()))
					{
						mdEntity.AllowMaxSel = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "IsMoreSel".ToLower()))
					{
						mdEntity.IsMoreSel = bool.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "MarkInt".ToLower()))
					{
						mdEntity.MarkInt = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "MarkStr".ToLower()))
					{
						mdEntity.MarkStr = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "VoteCount".ToLower()))
					{
						mdEntity.VoteCount = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "StartDate".ToLower()))
					{
						mdEntity.StartDate = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "EndDate".ToLower()))
					{
						mdEntity.EndDate = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "IsItemColorRan".ToLower()))
					{
                        mdEntity.IsItemColorRan = bool.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "VoteInfo".ToLower()))
					{
						mdEntity.VoteInfo = column.ColumnValue;
					}
                    else if (Equals(column.ColumnName.ToLower(), "ClassID".ToLower()))
                    {
                        mdEntity.ClassID =int.Parse( column.ColumnValue);
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
		public Entity.vote GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.vote mdEt = new Entity.vote();
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
					else if(Equals(uc.ID.ToLower(),"VoteName".ToLower()))
					{
						mdEt.VoteName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AllowMaxSel".ToLower()))
					{
						mdEt.AllowMaxSel = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"IsMoreSel".ToLower()))
					{
						mdEt.IsMoreSel = bool.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"MarkInt".ToLower()))
					{
						mdEt.MarkInt = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"MarkStr".ToLower()))
					{
						mdEt.MarkStr = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"VoteCount".ToLower()))
					{
						mdEt.VoteCount = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"StartDate".ToLower()))
					{
						mdEt.StartDate = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"EndDate".ToLower()))
					{
						mdEt.EndDate = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"IsItemColorRan".ToLower()))
					{
						mdEt.IsItemColorRan = bool.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"VoteInfo".ToLower()))
					{
						mdEt.VoteInfo = sValue;
					}
                    else if (Equals(uc.ID.ToLower(), "ClassID".ToLower()))
                    {
                        mdEt.ClassID =int.Parse( sValue);
                    }
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法
       public void PostVoteSingle(int vid, int itemid)
       {
           base.InvalidateCache();
           dal.PostVoteSingle(vid, itemid);
       }

	    public void PostVoteMore(int vid, string itemids)
       {
           base.InvalidateCache();
           dal.PostVoteMore(vid, itemids);
	    }

	    #endregion  自定义方法
	}
}

