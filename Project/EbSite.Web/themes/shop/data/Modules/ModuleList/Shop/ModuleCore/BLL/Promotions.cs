using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Shop.ModuleCore.BLL
{
	/// <summary>
	/// 业务逻辑类Promotions 的摘要说明。
	/// </summary>
	public class Promotions: Base.BLLBase<Entity.Promotions, int> 
	{
		public static readonly Promotions Instance = new Promotions();
		private  Promotions()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.Promotions_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dalHelper.Promotions_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.Promotions model)
		{
			base.InvalidateCache();
			return dalHelper.Promotions_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.Promotions model)
		{
			base.InvalidateCache();
			dalHelper.Promotions_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dalHelper.Promotions_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.Promotions GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.Promotions etEntity = base.GetCacheItem<Entity.Promotions>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.Promotions_GetEntity(id);
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
			return dalHelper.Promotions_GetCount(strWhere);
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
			return dalHelper.Promotions_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.Promotions> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.Promotions_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.Promotions> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.Promotions> lstData = base.GetCacheItem<List<Entity.Promotions>>(rawKey);
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
		public List<Entity.Promotions> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.Promotions> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.Promotions> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.Promotions_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.Promotions> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.Promotions> lstData = base.GetCacheItem<List<Entity.Promotions>>(rawKey);
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
		public List<Entity.Promotions> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.Promotions> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
            base.InvalidateCache();
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.Promotions> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.Promotions> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.Promotions mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "TitleName".ToLower()))
					{
						sValue = mdEt.TitleName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "PromoteType".ToLower()))
					{
						sValue = mdEt.PromoteType.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Description".ToLower()))
					{
						sValue = mdEt.Description.ToString();
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
			Entity.Promotions mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "TitleName".ToLower()))
					{
						mdEntity.TitleName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "PromoteType".ToLower()))
					{
						mdEntity.PromoteType = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Description".ToLower()))
					{
						mdEntity.Description = column.ColumnValue;
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
		public Entity.Promotions GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.Promotions mdEt = new Entity.Promotions();
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
					else if(Equals(uc.ID.ToLower(),"TitleName".ToLower()))
					{
						mdEt.TitleName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"PromoteType".ToLower()))
					{
						mdEt.PromoteType = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Description".ToLower()))
					{
						mdEt.Description = sValue;
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
		 #region 自定义方法

        /// <summary>
        /// 删除相关联的数据
        /// </summary>
        public void DeleteByType(int id, ModuleCore.BLL.EPromotionsType pType)
        {
            dalHelper.Promotions_DeleteByType(id, pType);
        }
        public List<Entity.Promotions> GetBuyNumGiveNum()
        {
           return GetListArray(string.Concat("PromoteType=", (int)EPromotionsType.买几送几));
        }
        /// <summary>
        /// 检测是否存在 买几送几 活动，返回活动集合的ID，逗号分开
        /// </summary>
        /// <returns></returns>
        public string ExistsPurchaseGift(List<Entity.Promotions> lst)
        {

            if(lst.Count>0)
            {
               StringBuilder sb = new StringBuilder();
                foreach (Entity.Promotions promotions in lst)
                {
                    sb.Append(promotions.id);
                    sb.Append(",");
                }
                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
            return string.Empty;
        }

        //买几送几，买几打折
        public void GetActivityInfo(int RoleID, int Quantity,long ProductId, out Entity.PromotionFullNumGiveWithName pfgwn, out Entity.PromotionWholesaleWithName pwwn)
        {
            dalHelper.GetActivityInfo(RoleID, Quantity, ProductId, out pfgwn, out pwwn);

        }
        //满额免费用，满额打折
        public void GetActivityInfo(int RoleID, decimal Price, out Entity.PromotionFullPriceCutWithName pfpwn, out Entity.PromotionPriceFreeWithName ppwn)
        {
            dalHelper.GetActivityInfo( RoleID,  Price, out  pfpwn, out ppwn);
        }
        public List<Entity.Activities> GetShowList(int PageIndex, int PageSize,int ActivitieID,  out int RecordCount)
        {
            return dalHelper.GetShowList(PageIndex,  PageSize,ActivitieID,  "", out RecordCount);
        }
        public string GetTitle(string id)
        {
            ModuleCore.Entity.Promotions model =
                       ModuleCore.BLL.Promotions.Instance.GetEntity(Convert.ToInt32(id));
            if (!Equals(model, null))
            {
                return model.TitleName;
            }
            return "";
        }
        public string GetRoles(string id)
        {
            string strRoles = "";
            List<ModuleCore.Entity.PromotionsRole> ls = ModuleCore.BLL.PromotionsRole.Instance.GetListArray("PromotionsID=" + id);
            foreach (var promotionsRole in ls)
            {
                EbSite.Modules.Shop.ModuleCore.Entity.ListItemModel lm = EbSite.Modules.Shop.ModuleCore.BLL.PromotionUserLevelType.GetPromotionUserLevelType(promotionsRole.UserRoleID.ToString());
                strRoles += lm.Text + ",";
            }
            if (strRoles.Length > 0)
                strRoles = strRoles.Remove(strRoles.Length - 1, 1);
            return strRoles;
        }
	    #endregion 自定义方法

        #region 主站的辅助方法
        public string GetName(string id)
        {
            EbSite.Entity.NewsContent model = EbSite.Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(Convert.ToInt32(id));
            if (!Equals(model, null))
                return model.NewsTitle;
            return "";

        }

        public string SmallPic(string id)
        {
            EbSite.Entity.NewsContent model = EbSite.Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(Convert.ToInt32(id));
            if (!Equals(model, null))
                return model.SmallPic;
            return "";

        }
        #endregion
    }
}

