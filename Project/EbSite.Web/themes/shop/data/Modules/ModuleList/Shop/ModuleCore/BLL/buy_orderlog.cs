using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Shop.ModuleCore.BLL
{
	/// <summary>
	/// 业务逻辑类buy_orderlog 的摘要说明。
	/// </summary>
	public class buy_orderlog: Base.BLLBase<Entity.buy_orderlog, int> 
	{
		public static readonly buy_orderlog Instance = new buy_orderlog();
		private  buy_orderlog()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.buy_orderlog_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dalHelper.buy_orderlog_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.buy_orderlog model)
		{
			base.InvalidateCache();
			return dalHelper.buy_orderlog_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.buy_orderlog model)
		{
			base.InvalidateCache();
			dalHelper.buy_orderlog_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dalHelper.buy_orderlog_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        override public Entity.buy_orderlog GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.buy_orderlog etEntity = base.GetCacheItem<Entity.buy_orderlog>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.buy_orderlog_GetEntity(id);
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
			return dalHelper.buy_orderlog_GetCount(strWhere);
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
			return dalHelper.buy_orderlog_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.buy_orderlog> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.buy_orderlog_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.buy_orderlog> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.buy_orderlog> lstData = base.GetCacheItem<List<Entity.buy_orderlog>>(rawKey);
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
		public List<Entity.buy_orderlog> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.buy_orderlog> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.buy_orderlog> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.buy_orderlog_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.buy_orderlog> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.buy_orderlog> lstData = base.GetCacheItem<List<Entity.buy_orderlog>>(rawKey);
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
		public List<Entity.buy_orderlog> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.buy_orderlog> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.buy_orderlog> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.buy_orderlog> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.buy_orderlog mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
					{
						sValue = mdEt.OrderID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OpDate".ToLower()))
					{
						sValue = mdEt.OpDate.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OpUserId".ToLower()))
					{
						sValue = mdEt.OpUserId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OpUserName".ToLower()))
					{
						sValue = mdEt.OpUserName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OpType".ToLower()))
					{
						sValue = mdEt.OpType.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OpCtent".ToLower()))
					{
						sValue = mdEt.OpCtent.ToString();
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
			Entity.buy_orderlog mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderID".ToLower()))
					{
						mdEntity.OrderID = long.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OpDate".ToLower()))
					{
						mdEntity.OpDate = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OpUserId".ToLower()))
					{
						mdEntity.OpUserId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OpUserName".ToLower()))
					{
						mdEntity.OpUserName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "OpType".ToLower()))
					{
						mdEntity.OpType = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OpCtent".ToLower()))
					{
						mdEntity.OpCtent = column.ColumnValue;
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
		public Entity.buy_orderlog GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.buy_orderlog mdEt = new Entity.buy_orderlog();
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
					else if(Equals(uc.ID.ToLower(),"OrderID".ToLower()))
					{
						mdEt.OrderID = long.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OpDate".ToLower()))
					{
						mdEt.OpDate = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OpUserId".ToLower()))
					{
						mdEt.OpUserId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OpUserName".ToLower()))
					{
						mdEt.OpUserName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"OpType".ToLower()))
					{
						mdEt.OpType = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OpCtent".ToLower()))
					{
						mdEt.OpCtent = sValue;
					}
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="orderID">订单号</param>
        /// <param name="logMsg">日志内容</param>
        /// <param name="orderShowType">日志类型</param>
        /// <returns></returns>
        public int Add(string orderID, string logMsg, SystemEnum.OrderLogType orderShowType)
        {
            int result = 0;
            try
            {
                int uid = EbSite.Base.Host.Instance.UserID;
                string uname = EbSite.Base.Host.Instance.UserName;
                result=dalHelper.buy_orderlog_Add(orderID, logMsg, uid, uname, orderShowType);
            }
            catch
            {
                result = -1;
            }
            return result;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="orderID">订单ID</param>
        /// <param name="logMsg">日志内容</param>
        /// <param name="orderShowType">日志类型</param>
        /// <returns></returns>
        public int Add(int id, string logMsg, SystemEnum.OrderLogType orderShowType)
        {
            int result = 0;
            try
            {
                int uid = EbSite.Base.Host.Instance.UserID;
                string uname = EbSite.Base.Host.Instance.UserName;
                ModuleCore.Entity.Buy_Orders m = ModuleCore.BLL.Buy_Orders.Instance.GetEntity(id);
                result = dalHelper.buy_orderlog_Add(m.OrderId.ToString(), logMsg, uid, uname, orderShowType);
            }
            catch
            {
                result = -1;
            }
            return result;
        }

		#endregion  自定义方法

        /// <summary>
        /// 查出订单的日志
        /// </summary>
        /// <param name="lgOrderID">订单号</param>
        /// <param name="iKey">false 是 用户时显示。true 管理员 所有 </param>
        /// <returns></returns>
        public List<Entity.buy_orderlog> GetLogByOrderID(long lgOrderID, bool iKey)
        {
            StringBuilder sWhere = new StringBuilder();
               
            if (lgOrderID > 0)
            {
                sWhere.AppendFormat(" orderid={0} and", lgOrderID);
            }
            if (!iKey)//前台
            {
                sWhere.AppendFormat(" optype={0} and", 0);
            }
            if (sWhere.Length > 0)
                sWhere = sWhere.Remove(sWhere.Length - 3, 3);
            return buy_orderlog.Instance.GetListArray(0, sWhere.ToString(), "");
        }
	}
}

