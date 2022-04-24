using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Shop.ModuleCore.BLL
{
	/// <summary>
	/// 业务逻辑类CountDownBuy 的摘要说明。
	/// </summary>
	public class CountDownBuy: Base.BLLBase<Entity.CountDownBuy, int> 
	{
		public static readonly CountDownBuy Instance = new CountDownBuy();
		private  CountDownBuy()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.CountDownBuy_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dalHelper.CountDownBuy_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.CountDownBuy model)
		{
			base.InvalidateCache();
			return dalHelper.CountDownBuy_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.CountDownBuy model)
		{
			base.InvalidateCache();
			dalHelper.CountDownBuy_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dalHelper.CountDownBuy_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.CountDownBuy GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.CountDownBuy etEntity = base.GetCacheItem<Entity.CountDownBuy>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.CountDownBuy_GetEntity(id);
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
			return dalHelper.CountDownBuy_GetCount(strWhere);
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
			return dalHelper.CountDownBuy_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.CountDownBuy> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.CountDownBuy_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.CountDownBuy> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.CountDownBuy> lstData = base.GetCacheItem<List<Entity.CountDownBuy>>(rawKey);
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
		public List<Entity.CountDownBuy> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.CountDownBuy> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.CountDownBuy> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.CountDownBuy_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.CountDownBuy> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.CountDownBuy> lstData = base.GetCacheItem<List<Entity.CountDownBuy>>(rawKey);
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
		public List<Entity.CountDownBuy> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.CountDownBuy> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.CountDownBuy> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.CountDownBuy> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.CountDownBuy mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ProductId".ToLower()))
					{
						sValue = mdEt.ProductId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "StartDate".ToLower()))
					{
						sValue = mdEt.StartDate.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "EndDate".ToLower()))
					{
						sValue = mdEt.EndDate.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Content".ToLower()))
					{
						sValue = mdEt.Content.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
					{
						sValue = mdEt.OrderID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CountDownPrice".ToLower()))
					{
						sValue = mdEt.CountDownPrice.ToString();
					}
                    else if (Equals(uc.ID.ToLower(), "Price".ToLower()))
                    {
                        sValue = mdEt.Price.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Title".ToLower()))
                    {
                        sValue = mdEt.Title.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SmallImg".ToLower()))
                    {
                        sValue = mdEt.SmallImg.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Status".ToLower()))
                    {
                        sValue = mdEt.Status.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Buyed".ToLower()))
                    {
                        sValue = mdEt.Buyed.ToString();
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
			Entity.CountDownBuy mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ProductId".ToLower()))
					{
						mdEntity.ProductId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "StartDate".ToLower()))
					{
						mdEntity.StartDate = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "EndDate".ToLower()))
					{
						mdEntity.EndDate = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Content".ToLower()))
					{
						mdEntity.Content = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderID".ToLower()))
					{
						mdEntity.OrderID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "CountDownPrice".ToLower()))
					{
						mdEntity.CountDownPrice = decimal.Parse(column.ColumnValue);
					}
                    else if (Equals(column.ColumnName.ToLower(), "Price".ToLower()))
                    {
                        mdEntity.Price = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Title".ToLower()))
                    {
                        mdEntity.Title =column.ColumnValue.ToString();
                    }
                    else if (Equals(column.ColumnName.ToLower(), "SmallImg".ToLower()))
                    {
                        mdEntity.SmallImg =column.ColumnValue.ToString();
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Status".ToLower()))
					{
						mdEntity.Status = int.Parse(column.ColumnValue);
					}
                    else if (Equals(column.ColumnName.ToLower(), "Buyed".ToLower()))
					{
                        mdEntity.Buyed = int.Parse(column.ColumnValue);
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
		public Entity.CountDownBuy GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.CountDownBuy mdEt = new Entity.CountDownBuy();
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
					else if(Equals(uc.ID.ToLower(),"ProductId".ToLower()))
					{
						mdEt.ProductId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"StartDate".ToLower()))
					{
						mdEt.StartDate = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"EndDate".ToLower()))
					{
						mdEt.EndDate = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Content".ToLower()))
					{
						mdEt.Content = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"OrderID".ToLower()))
					{
                        if (string.IsNullOrEmpty(sValue))
                        {
                            sValue = "100";
                        }
						mdEt.OrderID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"CountDownPrice".ToLower()))
					{
						mdEt.CountDownPrice = decimal.Parse(sValue);
					}
                    else if (Equals(uc.ID.ToLower(), "Price".ToLower()))
                    {
                        mdEt.Price = decimal.Parse(sValue);
                    }
                    else if (Equals(uc.ID.ToLower(), "Title".ToLower()))
                    {
                        mdEt.Title =sValue.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SmallImg".ToLower()))
                    {
                        mdEt.SmallImg =sValue.ToString();
                    }
                    else if(Equals(uc.ID.ToLower(),"Status".ToLower()))
					{
						mdEt.Status = int.Parse(sValue);
					}
                    else if (Equals(uc.ID.ToLower(), "Buyed".ToLower()))
					{
						mdEt.Buyed = int.Parse(sValue);
					}
                
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法
        /// <summary>
        /// 自动 检测 抢购状态 到期 改为进行中
        /// </summary>
        public void AutoSetGroupStaus()
        {
            //status=3 未开始 和已结束
            List<Entity.CountDownBuy> ls = CountDownBuy.Instance.GetListArray(0, "Status in(1,3) and StartDate <NOW()", "");
            foreach (var groupBuy in ls)
            {
                groupBuy.Status = Convert.ToInt32(SystemEnum.PanicBuyingState.正在进行中);
                groupBuy.Update();
            }

            //status=0 正在进行中 
            List<Entity.CountDownBuy> lsing = CountDownBuy.Instance.GetListArray(0, "Status=0 and EndDate <NOW()", "");
            foreach (var groupBuy in lsing)
            {
                groupBuy.Status = Convert.ToInt32(SystemEnum.PanicBuyingState.已结束);
                groupBuy.Update();
            }
        }

        /// <summary>
        /// 定时更新抢购状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateStatus()
        {
            return dalHelper.CountDownBuy_UpdateStatus();
        }

		#endregion  自定义方法
	}
}

