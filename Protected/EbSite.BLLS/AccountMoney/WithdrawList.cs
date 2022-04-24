using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类WithdrawList 的摘要说明。
	/// </summary>
    public class WithdrawList : Base.BLL.BllBase<Entity.WithdrawList, int> 
	{
		public static readonly WithdrawList Instance = new WithdrawList();
        private const string CacheWithdraw = "widhdrawlist";
        const double CacheDuration = 60.0;
		private  WithdrawList()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return DbProviderUser.GetInstance().WithdrawList_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
            return DbProviderUser.GetInstance().WithdrawList_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.WithdrawList model)
		{
			base.InvalidateCache();
            return DbProviderUser.GetInstance().WithdrawList_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.WithdrawList model)
		{
			base.InvalidateCache();
            DbProviderUser.GetInstance().WithdrawList_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();

            DbProviderUser.GetInstance().WithdrawList_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.WithdrawList GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.WithdrawList etEntity = Host.CacheApp.GetCacheItem<Entity.WithdrawList>(rawKey, CacheWithdraw);
            //base.GetCacheItem(rawKey) as Entity.WithdrawList;
			if (Equals(etEntity,null))
			{
                etEntity = DbProviderUser.GetInstance().WithdrawList_GetEntity(id);
				if (!Equals(etEntity,null))
                    Host.CacheApp.AddCacheItem(rawKey, etEntity, CacheDuration, ETimeSpanModel.M, CacheWithdraw);//base.AddCacheItem(rawKey, etEntity);
			}
			return etEntity;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public int GetCount(string strWhere)
		{
            return DbProviderUser.GetInstance().WithdrawList_GetCount(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public int GetCountCache(string strWhere)
		{
			string rawKey = string.Concat("GetCount-", strWhere);
            string sCount = Host.CacheApp.GetCacheItem<string>(rawKey, CacheWithdraw); //base.GetCacheItem(rawKey) as string;
			if (string.IsNullOrEmpty(sCount))
			{
				sCount = GetCount(strWhere).ToString();
				if (!string.IsNullOrEmpty(sCount))
                    Host.CacheApp.AddCacheItem(rawKey, sCount, CacheDuration, ETimeSpanModel.M, CacheWithdraw);//base.AddCacheItem(rawKey, sCount);
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
            return DbProviderUser.GetInstance().WithdrawList_GetList(Top, strWhere, filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetList-", strWhere,Top,filedOrder);
            DataSet lstData = Host.CacheRawApp.GetCacheItem<DataSet>(rawKey, CacheWithdraw); //base.GetCacheItem(rawKey) as DataSet;
			if (Equals(lstData,null))
			{
				lstData = GetList( Top,  strWhere,  filedOrder);
				if (!Equals(lstData,null))
                    Host.CacheRawApp.AddCacheItem(rawKey, lstData, CacheDuration, ETimeSpanModel.M, CacheWithdraw);//base.AddCacheItem(rawKey, lstData);
			}
			return lstData;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.WithdrawList> GetListArray(int Top, string strWhere, string filedOrder)
		{
            return DbProviderUser.GetInstance().WithdrawList_GetListArray(Top, strWhere, filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.WithdrawList> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.WithdrawList> lstData = Host.CacheApp.GetCacheItem<List<Entity.WithdrawList>>(rawKey, CacheWithdraw); // base.GetCacheItem(rawKey) as List<Entity.WithdrawList>;
			if (Equals(lstData,null))
			{
				//从基类调用，激活事件
				lstData = base.GetListArrayEv( Top,  strWhere,  filedOrder);
				if (!Equals(lstData,null))
                    Host.CacheApp.AddCacheItem(rawKey, lstData, CacheDuration, ETimeSpanModel.M, CacheWithdraw);//base.AddCacheItem(rawKey, lstData);
			}
			return lstData;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.WithdrawList> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.WithdrawList> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.WithdrawList> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
            return DbProviderUser.GetInstance().WithdrawList_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表  YHL 时时数据
		/// </summary>
		public List<Entity.WithdrawList> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
           
            List<Entity.WithdrawList> lstData =new List<Entity.WithdrawList>();
            lstData = base.GetListPagesEv(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
		   
			return lstData;
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.WithdrawList> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.WithdrawList> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.WithdrawList> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.WithdrawList> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.WithdrawList mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserId".ToLower()))
					{
						sValue = mdEt.UserId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserName".ToLower()))
					{
						sValue = mdEt.UserName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "RequestTime".ToLower()))
					{
						sValue = mdEt.RequestTime.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Amount".ToLower()))
					{
						sValue = mdEt.Amount.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AccountName".ToLower()))
					{
						sValue = mdEt.AccountName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "BankName".ToLower()))
					{
						sValue = mdEt.BankName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CardNumber".ToLower()))
					{
						sValue = mdEt.CardNumber.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Remark".ToLower()))
					{
						sValue = mdEt.Remark.ToString();
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
			Entity.WithdrawList mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "UserId".ToLower()))
					{
						mdEntity.UserId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "UserName".ToLower()))
					{
						mdEntity.UserName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "RequestTime".ToLower()))
					{
						mdEntity.RequestTime = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Amount".ToLower()))
					{
						mdEntity.Amount = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AccountName".ToLower()))
					{
						mdEntity.AccountName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "BankName".ToLower()))
					{
						mdEntity.BankName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "CardNumber".ToLower()))
					{
						mdEntity.CardNumber = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Remark".ToLower()))
					{
						mdEntity.Remark = column.ColumnValue;
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
		public Entity.WithdrawList GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.WithdrawList mdEt = new Entity.WithdrawList();
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
					else if(Equals(uc.ID.ToLower(),"UserId".ToLower()))
					{
						mdEt.UserId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"UserName".ToLower()))
					{
						mdEt.UserName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"RequestTime".ToLower()))
					{
						mdEt.RequestTime = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Amount".ToLower()))
					{
						mdEt.Amount = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AccountName".ToLower()))
					{
						mdEt.AccountName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"BankName".ToLower()))
					{
						mdEt.BankName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"CardNumber".ToLower()))
					{
						mdEt.CardNumber = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Remark".ToLower()))
					{
						mdEt.Remark = sValue;
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法
        /// <summary>
        /// 申请提现 申请
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Agree"></param>
        /// <returns></returns>
		public bool BalanceDrawRequest_Update(int UserID, bool Agree)
		{
		    return DbProviderUser.GetInstance().BalanceDrawRequest_Update(UserID, Agree);
		}

         public bool BalanceDrawRequest_Add(Entity.WithdrawList withMd, decimal Amount, int UserId)
         {
             return DbProviderUser.GetInstance().BalanceDrawRequest_Add(withMd, Amount, UserId);
         }
		#endregion  自定义方法
	}
}

