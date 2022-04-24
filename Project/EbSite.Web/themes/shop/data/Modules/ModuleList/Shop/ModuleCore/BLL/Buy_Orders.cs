using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Modules.Shop.ModuleCore.Cart;

namespace EbSite.Modules.Shop.ModuleCore.BLL
{
	/// <summary>
	/// 业务逻辑类Buy_Orders 的摘要说明。
	/// </summary>
	public class Buy_Orders: Base.BLLBase<Entity.Buy_Orders, int> 
	{
        public static readonly Buy_Orders Instance = new Buy_Orders();
        private Buy_Orders()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public long GetMaxId()
		{
			return dalHelper.Buy_Orders_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dalHelper.Buy_Orders_Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.Buy_Orders model)
		{
			base.InvalidateCache();
			return dalHelper.Buy_Orders_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.Buy_Orders model)
		{
			base.InvalidateCache();
			dalHelper.Buy_Orders_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int ID)
		{
			base.InvalidateCache();
			
			dalHelper.Buy_Orders_Delete(ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.Buy_Orders GetEntity(int ID)
		{
            base.InvalidateCache();
			string rawKey = string.Concat("GetEntity-", ID);
            Entity.Buy_Orders etEntity = base.GetCacheItem<Entity.Buy_Orders>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.Buy_Orders_GetEntity(ID);
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
			return dalHelper.Buy_Orders_GetCount(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public int GetCountCache(string strWhere)
		{
            base.InvalidateCache();
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
			return dalHelper.Buy_Orders_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.Buy_Orders> GetListArray(int Top, string strWhere, string filedOrder)
		{
            base.InvalidateCache();
			return dalHelper.Buy_Orders_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.Buy_Orders> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.Buy_Orders> lstData = base.GetCacheItem<List<Entity.Buy_Orders>>(rawKey);
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
		public List<Entity.Buy_Orders> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.Buy_Orders> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.Buy_Orders> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
            base.InvalidateCache();
			return dalHelper.Buy_Orders_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.Buy_Orders> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.Buy_Orders> lstData = base.GetCacheItem<List<Entity.Buy_Orders>>(rawKey);
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
		public List<Entity.Buy_Orders> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.Buy_Orders> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
            base.InvalidateCache();
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.Buy_Orders> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.Buy_Orders> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.Buy_Orders mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "ID".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderId".ToLower()))
					{
						sValue = mdEt.OrderId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Remark".ToLower()))
					{
						sValue = mdEt.Remark.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "MerchandiserMarkID".ToLower()))
					{
						sValue = mdEt.MerchandiserMarkID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "MerchandiserRemark".ToLower()))
					{
						sValue = mdEt.MerchandiserRemark.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AdjustedDiscount".ToLower()))
					{
						sValue = mdEt.AdjustedDiscount.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderStatus".ToLower()))
					{
						sValue = mdEt.OrderStatus.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CloseReason".ToLower()))
					{
						sValue = mdEt.CloseReason.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderAddDate".ToLower()))
					{
						sValue = mdEt.OrderAddDate.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "PayDate".ToLower()))
					{
						sValue = mdEt.PayDate.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SendDate".ToLower()))
					{
						sValue = mdEt.SendDate.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "FinishDate".ToLower()))
					{
						sValue = mdEt.FinishDate.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserId".ToLower()))
					{
						sValue = mdEt.UserId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Username".ToLower()))
					{
						sValue = mdEt.Username.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "EmailAddress".ToLower()))
					{
						sValue = mdEt.EmailAddress.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "RealName".ToLower()))
					{
						sValue = mdEt.RealName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "QQ".ToLower()))
					{
						sValue = mdEt.QQ.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Wangwang".ToLower()))
					{
						sValue = mdEt.Wangwang.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "MSN".ToLower()))
					{
						sValue = mdEt.MSN.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SendRegion".ToLower()))
					{
						sValue = mdEt.SendRegion.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Address".ToLower()))
					{
						sValue = mdEt.Address.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ZipCode".ToLower()))
					{
						sValue = mdEt.ZipCode.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "SendToUserName".ToLower()))
					{
						sValue = mdEt.SendToUserName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "TelPhone".ToLower()))
					{
						sValue = mdEt.TelPhone.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CellPhone".ToLower()))
					{
						sValue = mdEt.CellPhone.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ShippingModeId".ToLower()))
					{
						sValue = mdEt.ShippingModeId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ModeName".ToLower()))
					{
						sValue = mdEt.ModeName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "RealShippingModeId".ToLower()))
					{
						sValue = mdEt.RealShippingModeId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "RealModeName".ToLower()))
					{
						sValue = mdEt.RealModeName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "RegionId".ToLower()))
					{
						sValue = mdEt.RegionId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Freight".ToLower()))
					{
						sValue = mdEt.Freight.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AdjustedFreight".ToLower()))
					{
						sValue = mdEt.AdjustedFreight.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "DeliveryOrderNumber".ToLower()))
					{
						sValue = mdEt.DeliveryOrderNumber.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Weight".ToLower()))
					{
						sValue = mdEt.Weight.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ExpressCompanyName".ToLower()))
					{
						sValue = mdEt.ExpressCompanyName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ExpressCompanyAbb".ToLower()))
					{
						sValue = mdEt.ExpressCompanyAbb.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "PaymentTypeId".ToLower()))
					{
						sValue = mdEt.PaymentTypeId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "PaymentType".ToLower()))
					{
						sValue = mdEt.PaymentType.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "PayFree".ToLower()))
					{
						sValue = mdEt.PayFree.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AdjustedPayFree".ToLower()))
					{
						sValue = mdEt.AdjustedPayFree.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "RefundStatus".ToLower()))
					{
						sValue = mdEt.RefundStatus.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "RefundAmount".ToLower()))
					{
						sValue = mdEt.RefundAmount.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "RefundRemark".ToLower()))
					{
						sValue = mdEt.RefundRemark.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderTotal".ToLower()))
					{
						sValue = mdEt.OrderTotal.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderPoint".ToLower()))
					{
						sValue = mdEt.OrderPoint.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderCostPrice".ToLower()))
					{
						sValue = mdEt.OrderCostPrice.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderProfit".ToLower()))
					{
						sValue = mdEt.OrderProfit.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ActualFreight".ToLower()))
					{
						sValue = mdEt.ActualFreight.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OtherCost".ToLower()))
					{
						sValue = mdEt.OtherCost.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OptionPrice".ToLower()))
					{
						sValue = mdEt.OptionPrice.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Amount".ToLower()))
					{
						sValue = mdEt.Amount.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ActivityId".ToLower()))
					{
						sValue = mdEt.ActivityId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ActivityName".ToLower()))
					{
						sValue = mdEt.ActivityName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "EightFree".ToLower()))
					{
						sValue = mdEt.EightFree.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "PayFreeFree".ToLower()))
					{
						sValue = mdEt.PayFreeFree.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderOptionFree".ToLower()))
					{
						sValue = mdEt.OrderOptionFree.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "DiscountId".ToLower()))
					{
						sValue = mdEt.DiscountId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "DiscountName".ToLower()))
					{
						sValue = mdEt.DiscountName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "DiscountValue".ToLower()))
					{
						sValue = mdEt.DiscountValue.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "DiscountValueType".ToLower()))
					{
						sValue = mdEt.DiscountValueType.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "DiscountAmount".ToLower()))
					{
						sValue = mdEt.DiscountAmount.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CouponName".ToLower()))
					{
						sValue = mdEt.CouponName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CouponCode".ToLower()))
					{
						sValue = mdEt.CouponCode.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CouponAmount".ToLower()))
					{
						sValue = mdEt.CouponAmount.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CouponValue".ToLower()))
					{
						sValue = mdEt.CouponValue.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "GroupId".ToLower()))
					{
						sValue = mdEt.GroupId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "GroupPrice".ToLower()))
					{
						sValue = mdEt.GroupPrice.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "GroupBuyStatus".ToLower()))
					{
						sValue = mdEt.GroupBuyStatus.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "GatewayOrderId".ToLower()))
					{
						sValue = mdEt.GatewayOrderId.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "IsPrinted".ToLower()))
					{
						sValue = mdEt.IsPrinted.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "TaobaoOrderId".ToLower()))
					{
						sValue = mdEt.TaobaoOrderId.ToString();
					}
                    else if (Equals(uc.ID.ToLower(), "TimeNumber".ToLower()))
					{
						sValue = mdEt.TimeNumber.ToString();
					}
                    else if (Equals(uc.ID.ToLower(), "ReviewedOrderDate".ToLower()))
                    {
                        sValue = mdEt.ReviewedOrderDate.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SureReceiptDate".ToLower()))
                    {
                        sValue = mdEt.SureReceiptDate.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "DelOrderDate".ToLower()))
                    {
                        sValue = mdEt.DelOrderDate.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "PanicBuyingId".ToLower()))
                    {
                        sValue = mdEt.PanicBuyingId.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "UserBalance".ToLower()))
                    {
                        sValue = mdEt.UserBalance.ToString();
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
			Entity.Buy_Orders mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "ID".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderId".ToLower()))
					{
						mdEntity.OrderId =long.Parse( column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Remark".ToLower()))
					{
						mdEntity.Remark = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "MerchandiserMarkID".ToLower()))
					{
						mdEntity.MerchandiserMarkID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "MerchandiserRemark".ToLower()))
					{
						mdEntity.MerchandiserRemark = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AdjustedDiscount".ToLower()))
					{
						mdEntity.AdjustedDiscount = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderStatus".ToLower()))
					{
						mdEntity.OrderStatus = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "CloseReason".ToLower()))
					{
						mdEntity.CloseReason = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderAddDate".ToLower()))
					{
						mdEntity.OrderAddDate = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "PayDate".ToLower()))
					{
						mdEntity.PayDate = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "SendDate".ToLower()))
					{
						mdEntity.SendDate = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "FinishDate".ToLower()))
					{
						mdEntity.FinishDate = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "UserId".ToLower()))
					{
						mdEntity.UserId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Username".ToLower()))
					{
						mdEntity.Username = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "EmailAddress".ToLower()))
					{
						mdEntity.EmailAddress = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "RealName".ToLower()))
					{
						mdEntity.RealName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "QQ".ToLower()))
					{
						mdEntity.QQ = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Wangwang".ToLower()))
					{
						mdEntity.Wangwang = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "MSN".ToLower()))
					{
						mdEntity.MSN = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "SendRegion".ToLower()))
					{
						mdEntity.SendRegion = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Address".ToLower()))
					{
						mdEntity.Address = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "ZipCode".ToLower()))
					{
						mdEntity.ZipCode = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "SendToUserName".ToLower()))
					{
						mdEntity.SendToUserName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "TelPhone".ToLower()))
					{
						mdEntity.TelPhone = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "CellPhone".ToLower()))
					{
						mdEntity.CellPhone = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "ShippingModeId".ToLower()))
					{
						mdEntity.ShippingModeId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ModeName".ToLower()))
					{
						mdEntity.ModeName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "RealShippingModeId".ToLower()))
					{
						mdEntity.RealShippingModeId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "RealModeName".ToLower()))
					{
						mdEntity.RealModeName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "RegionId".ToLower()))
					{
						mdEntity.RegionId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Freight".ToLower()))
					{
						mdEntity.Freight = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AdjustedFreight".ToLower()))
					{
						mdEntity.AdjustedFreight = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "DeliveryOrderNumber".ToLower()))
					{
						mdEntity.DeliveryOrderNumber = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Weight".ToLower()))
					{
						mdEntity.Weight = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ExpressCompanyName".ToLower()))
					{
						mdEntity.ExpressCompanyName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "ExpressCompanyAbb".ToLower()))
					{
						mdEntity.ExpressCompanyAbb = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "PaymentTypeId".ToLower()))
					{
						mdEntity.PaymentTypeId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "PaymentType".ToLower()))
					{
						mdEntity.PaymentType = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "PayFree".ToLower()))
					{
						mdEntity.PayFree = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AdjustedPayFree".ToLower()))
					{
						mdEntity.AdjustedPayFree = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "RefundStatus".ToLower()))
					{
						mdEntity.RefundStatus = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "RefundAmount".ToLower()))
					{
						mdEntity.RefundAmount = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "RefundRemark".ToLower()))
					{
						mdEntity.RefundRemark = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderTotal".ToLower()))
					{
						mdEntity.OrderTotal = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderPoint".ToLower()))
					{
						mdEntity.OrderPoint = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderCostPrice".ToLower()))
					{
						mdEntity.OrderCostPrice = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderProfit".ToLower()))
					{
						mdEntity.OrderProfit = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ActualFreight".ToLower()))
					{
						mdEntity.ActualFreight = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OtherCost".ToLower()))
					{
						mdEntity.OtherCost = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OptionPrice".ToLower()))
					{
						mdEntity.OptionPrice = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Amount".ToLower()))
					{
						mdEntity.Amount = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ActivityId".ToLower()))
					{
						mdEntity.ActivityId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ActivityName".ToLower()))
					{
						mdEntity.ActivityName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "EightFree".ToLower()))
					{
						mdEntity.EightFree = bool.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "PayFreeFree".ToLower()))
					{
						mdEntity.PayFreeFree = bool.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderOptionFree".ToLower()))
					{
						mdEntity.OrderOptionFree = bool.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "DiscountId".ToLower()))
					{
						mdEntity.DiscountId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "DiscountName".ToLower()))
					{
						mdEntity.DiscountName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "DiscountValue".ToLower()))
					{
						mdEntity.DiscountValue = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "DiscountValueType".ToLower()))
					{
						mdEntity.DiscountValueType = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "DiscountAmount".ToLower()))
					{
						mdEntity.DiscountAmount = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "CouponName".ToLower()))
					{
						mdEntity.CouponName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "CouponCode".ToLower()))
					{
						mdEntity.CouponCode = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "CouponAmount".ToLower()))
					{
						mdEntity.CouponAmount = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "CouponValue".ToLower()))
					{
						mdEntity.CouponValue = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "GroupId".ToLower()))
					{
						mdEntity.GroupId = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "GroupPrice".ToLower()))
					{
						mdEntity.GroupPrice = decimal.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "GroupBuyStatus".ToLower()))
					{
						mdEntity.GroupBuyStatus = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "GatewayOrderId".ToLower()))
					{
						mdEntity.GatewayOrderId = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "IsPrinted".ToLower()))
					{
                        mdEntity.IsPrinted = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "TaobaoOrderId".ToLower()))
					{
						mdEntity.TaobaoOrderId = column.ColumnValue;
					}
                    else if (Equals(column.ColumnName.ToLower(), "TimeNumber".ToLower()))
					{
                        mdEntity.TimeNumber = int.Parse(column.ColumnValue);
					}
                    else if (Equals(column.ColumnName.ToLower(), "ReviewedOrderDate".ToLower()))
                    {
                        mdEntity.ReviewedOrderDate = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "SureReceiptDate".ToLower()))
                    {
                        mdEntity.SureReceiptDate = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "DelOrderDate".ToLower()))
                    {
                        mdEntity.DelOrderDate = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "PanicBuyingId".ToLower()))
                    {
                        mdEntity.PanicBuyingId = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UserBalance".ToLower()))
                    {
                        mdEntity.UserBalance =decimal.Parse(column.ColumnValue);
                    }

                    else if (Equals(column.ColumnName.ToLower(), "iCome".ToLower()))
                    {
                        mdEntity.iCome = int.Parse(column.ColumnValue);
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
		public Entity.Buy_Orders GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.Buy_Orders mdEt = new Entity.Buy_Orders();
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
					else if(Equals(uc.ID.ToLower(),"OrderId".ToLower()))
					{
						mdEt.OrderId =long.Parse( sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Remark".ToLower()))
					{
						mdEt.Remark = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"MerchandiserMarkID".ToLower()))
					{
						mdEt.MerchandiserMarkID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"MerchandiserRemark".ToLower()))
					{
						mdEt.MerchandiserRemark = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AdjustedDiscount".ToLower()))
					{
						mdEt.AdjustedDiscount = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OrderStatus".ToLower()))
					{
						mdEt.OrderStatus = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"CloseReason".ToLower()))
					{
						mdEt.CloseReason = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"OrderAddDate".ToLower()))
					{
						mdEt.OrderAddDate = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"PayDate".ToLower()))
					{
						mdEt.PayDate = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"SendDate".ToLower()))
					{
						mdEt.SendDate = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"FinishDate".ToLower()))
					{
						mdEt.FinishDate = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"UserId".ToLower()))
					{
						mdEt.UserId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Username".ToLower()))
					{
						mdEt.Username = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"EmailAddress".ToLower()))
					{
						mdEt.EmailAddress = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"RealName".ToLower()))
					{
						mdEt.RealName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"QQ".ToLower()))
					{
						mdEt.QQ = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Wangwang".ToLower()))
					{
						mdEt.Wangwang = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"MSN".ToLower()))
					{
						mdEt.MSN = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"SendRegion".ToLower()))
					{
						mdEt.SendRegion = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Address".ToLower()))
					{
						mdEt.Address = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"ZipCode".ToLower()))
					{
						mdEt.ZipCode = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"SendToUserName".ToLower()))
					{
						mdEt.SendToUserName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"TelPhone".ToLower()))
					{
						mdEt.TelPhone = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"CellPhone".ToLower()))
					{
						mdEt.CellPhone = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"ShippingModeId".ToLower()))
					{
						mdEt.ShippingModeId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ModeName".ToLower()))
					{
						mdEt.ModeName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"RealShippingModeId".ToLower()))
					{
						mdEt.RealShippingModeId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"RealModeName".ToLower()))
					{
						mdEt.RealModeName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"RegionId".ToLower()))
					{
						mdEt.RegionId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Freight".ToLower()))
					{
						mdEt.Freight = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AdjustedFreight".ToLower()))
					{
						mdEt.AdjustedFreight = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"DeliveryOrderNumber".ToLower()))
					{
						mdEt.DeliveryOrderNumber = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Weight".ToLower()))
					{
						mdEt.Weight = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ExpressCompanyName".ToLower()))
					{
						mdEt.ExpressCompanyName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"ExpressCompanyAbb".ToLower()))
					{
						mdEt.ExpressCompanyAbb = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"PaymentTypeId".ToLower()))
					{
						mdEt.PaymentTypeId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"PaymentType".ToLower()))
					{
						mdEt.PaymentType = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"PayFree".ToLower()))
					{
						mdEt.PayFree = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AdjustedPayFree".ToLower()))
					{
						mdEt.AdjustedPayFree = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"RefundStatus".ToLower()))
					{
						mdEt.RefundStatus = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"RefundAmount".ToLower()))
					{
						mdEt.RefundAmount = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"RefundRemark".ToLower()))
					{
						mdEt.RefundRemark = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"OrderTotal".ToLower()))
					{
						mdEt.OrderTotal = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OrderPoint".ToLower()))
					{
						mdEt.OrderPoint = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OrderCostPrice".ToLower()))
					{
						mdEt.OrderCostPrice = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OrderProfit".ToLower()))
					{
						mdEt.OrderProfit = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ActualFreight".ToLower()))
					{
						mdEt.ActualFreight = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OtherCost".ToLower()))
					{
						mdEt.OtherCost = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OptionPrice".ToLower()))
					{
						mdEt.OptionPrice = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Amount".ToLower()))
					{
						mdEt.Amount = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ActivityId".ToLower()))
					{
						mdEt.ActivityId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ActivityName".ToLower()))
					{
						mdEt.ActivityName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"EightFree".ToLower()))
					{
						mdEt.EightFree = bool.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"PayFreeFree".ToLower()))
					{
						mdEt.PayFreeFree = bool.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OrderOptionFree".ToLower()))
					{
						mdEt.OrderOptionFree = bool.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"DiscountId".ToLower()))
					{
						mdEt.DiscountId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"DiscountName".ToLower()))
					{
						mdEt.DiscountName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"DiscountValue".ToLower()))
					{
						mdEt.DiscountValue = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"DiscountValueType".ToLower()))
					{
						mdEt.DiscountValueType = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"DiscountAmount".ToLower()))
					{
						mdEt.DiscountAmount = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"CouponName".ToLower()))
					{
						mdEt.CouponName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"CouponCode".ToLower()))
					{
						mdEt.CouponCode = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"CouponAmount".ToLower()))
					{
						mdEt.CouponAmount = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"CouponValue".ToLower()))
					{
						mdEt.CouponValue = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"GroupId".ToLower()))
					{
						mdEt.GroupId = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"GroupPrice".ToLower()))
					{
						mdEt.GroupPrice = decimal.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"GroupBuyStatus".ToLower()))
					{
						mdEt.GroupBuyStatus = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"GatewayOrderId".ToLower()))
					{
						mdEt.GatewayOrderId = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"IsPrinted".ToLower()))
					{
                        mdEt.IsPrinted = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"TaobaoOrderId".ToLower()))
					{
						mdEt.TaobaoOrderId = sValue;
					}
                    else if (Equals(uc.ID.ToLower(), "TimeNumber".ToLower()))
                    {
                        mdEt.TimeNumber = int.Parse(sValue);
                    }
                    else if (Equals(uc.ID.ToLower(), "ReviewedOrderDate".ToLower()))
                    {
                        mdEt.ReviewedOrderDate = DateTime.Parse(sValue);
                    }
                    else if (Equals(uc.ID.ToLower(), "SureReceiptDate".ToLower()))
                    {
                        mdEt.SureReceiptDate = DateTime.Parse(sValue);
                    }
                    else if (Equals(uc.ID.ToLower(), "DelOrderDate".ToLower()))
                    {
                        mdEt.DelOrderDate = DateTime.Parse(sValue);
                    }
                    else if (Equals(uc.ID.ToLower(), "PanicBuyingId".ToLower()))
                    {
                        mdEt.PanicBuyingId = int.Parse(sValue);
                    }
                    else if (Equals(uc.ID.ToLower(), "UserBalance".ToLower()))
                    {
                        mdEt.UserBalance = decimal.Parse(sValue);
                    }
                
                    
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法
		
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="dicArray">要更新的集合(如果value是字符串,需提前加上引号)</param>
        /// <param name="rid">更新记录ID</param>
        public bool UpdateByDic(Dictionary<string, object> dicArray, int rid)
        {
            return dalHelper.UpdateByDic(dicArray, rid);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="dicData">要更新的集合(如果value是字符串,需提前加上引号)</param>
        /// <param name="rids">更新记录ID集合</param>
        public bool UpdateByDic(Dictionary<string, object> dicArray, string rids)
        {
            return dalHelper.UpdateByDic(dicArray, rids);
        }
        /// <summary>
        /// 订单状态转换
        /// </summary>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public string ParseOrderState(string orderState)
        {
            string resultState = "未知";
            switch (orderState)
            {
                case "0":
                    resultState = string.Concat("<font style='color:#F14383;font-weight:bold;'>", GetStatusTips(0), "</font>");
                    break;
                case "1":
                    resultState = string.Concat("<font style='font-weight:bold;color:#0E529E;'>", GetStatusTips(1), "</font>");
                    break;
                case "2":
                    resultState = string.Concat("<font style='font-weight:bold;color:#00ff21;'>", GetStatusTips(2), "</font>");
                    break;
               
                case "3":
                    resultState = string.Concat("<font style='font-weight:bold;color:#734acc;'>", GetStatusTips(3), "</font>");
                    break;
                case "4":
                    resultState = string.Concat("<font style='color:red;'>",GetStatusTips(4),"</font>");
                    break;
                case "5":
                    resultState = string.Concat("<font style='font-weight:bold;color:#3fa130;'>", GetStatusTips(5), "</font>");
                    break;
                case "6":
                    resultState = string.Concat("<font style='font-weight:bold;color:#808080;'>", GetStatusTips(6), "</font>");
                    break;
                case "21":
                    resultState = string.Concat("<font style='font-weight:bold;color:#2d9642;'>", GetStatusTips(21), "</font>");
                    break;
            }
            return resultState;
        }

        public string GetStatusTips(int Status)
        {
            string tips = string.Empty;
            switch (Status)
            {
                case 0:
                    tips = "提交订单";
                    break;
                case 1:
                    tips = "审核订单";
                    break;
                case 2:
                    tips = "等待付款";
                    break;

                case 21:
                    tips = "已支付";
                    break;
                    
                case 3:
                    tips = "已发货";
                    break;
                case 4:
                    tips = "确认收货";
                    break;
                case 5:
                    tips = "交易完成";
                    break;
                case 6:
                    tips = "回收站";
                    break;
            }
            return tips;
        }

        public int GetStatusTips(ModuleCore.SystemEnum.OrderStatus orderEnum)
        {
            return (int)orderEnum;
        }
       
        /// <summary>
        /// 获取一个订单，以后直接查询
        /// </summary>
        /// <param name="sOrderNo"></param>
        /// <returns></returns>
        public Entity.Buy_Orders GetEntityByOrderNo(string sOrderNo)
        {
            Entity.Buy_Orders md = null;
            string[] Numbers = sOrderNo.Split('-');
            if (Numbers.Length == 2)
            {
                int id = EbSite.Core.Utils.StrToInt(Numbers[1], 0);
                if (id > 0)
                    md = GetEntity(id);
            }
            return md;
        }
       /// <summary>
       /// 
       /// </summary>
        /// <param name="md">订单主表</param>
        /// <param name="lstOov">订单选项值</param>
        /// <param name="CouponItemID">优惠券id</param>
        /// <param name="CartItems">购物车</param>
        /// <param name="CreditCartItems">积分商品购物车</param>
       /// <param name="GroupMd">团购实体</param>
       /// <param name="RushMd">抢购实体</param>
        /// <param name="Prepayments">预付款</param>
       /// <returns></returns>
        public long AddOrder(Entity.Buy_Orders md, List<EbSite.Entity.OrderOptionValue> lstOov, int CouponItemID, ICollection<Entity.Buy_CartItem> CartItems, ICollection<Entity.Buy_CreditCartItem> CreditCartItems, Entity.GroupBuy GroupMd, Entity.CountDownBuy RushMd, decimal Prepayments)
        {
            md.OrderAddDate = DateTime.Now;
            md.OrderId = EbSite.Core.SqlDateTimeInt.NewOrderNumberLong();
            bool IsOK = dalHelper.AddOrder(md, CartItems,CreditCartItems, CouponItemID, lstOov, GroupMd, RushMd, Prepayments);
            if (IsOK)//添加成功，由于定单选项费用,优惠券与订单不在同一个数据连接，所以不能放到事务，这样做通用的同时有点遗憾
            {
                //EbSite.BLL.CouponItems.Instance.Delete(CouponItemID);//优惠券使用后删除
                //foreach (var optionValue in lstOov)
                //{
                //    optionValue.OrderId = md.OrderId.ToString();
                //    EbSite.BLL.OrderOptionValue.Instance.Add(optionValue);
                //}
                return md.OrderId;
            }
            return 0;


        }
        public Entity.Buy_Orders GetEntityByOrderID(long sOrderNumber)
        {
            return dalHelper.Buy_Orders_GetEntity(sOrderNumber);
        }
        public string GetSqlWhere(string orderid,string state,string dateBegin,string dateEnd)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" UserId={0} and", EbSite.Base.Host.Instance.UserID);
            if (!string.IsNullOrEmpty(orderid))
            {
                sb.AppendFormat(" OrderId={0} and", orderid);
            }
            if (!string.IsNullOrEmpty(state))
            {
                sb.AppendFormat(" OrderStatus={0} and",state);
            }
            if (!string.IsNullOrEmpty(dateBegin) && !string.IsNullOrEmpty(dateEnd))
            {
                int sBeginScond = EbSite.Core.SqlDateTimeInt.GetSecond(Convert.ToDateTime(dateBegin + " 0:00:00"));
                int sEndScond = EbSite.Core.SqlDateTimeInt.GetSecond(Convert.ToDateTime(dateEnd + " 23:59:59"));
                sb.AppendFormat(" TimeNumber between {0} and {1} and", sBeginScond, sEndScond);
            }
            if (sb.Length > 0)
                sb = sb.Remove(sb.Length - 3, 3);
            return sb.ToString();
        }
        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="rID">buy_orders 表的自增id</param>
        /// <returns></returns>
        public bool CloseOrder(int rID, string CloseReason)
        {
            return dalHelper.Buy_Orders_CloseOrder(rID, CloseReason);
        }
        /// <summary>
        /// 获取要更新的打印状态值
        /// </summary>
        /// <param name="oldResult">原打印状态</param>
        /// <param name="pType">要修改的打印类型</param>
        /// <returns></returns>
        public string GetUpdatePrint(int oldResult,ModuleCore.SystemEnum.PrintType pType)
        {
            string result = "121";
            if (oldResult > 100)
            {
                string tmpStr = oldResult.ToString();
                if (pType == ModuleCore.SystemEnum.PrintType.快递单)
                {
                    result = string.Concat("2", tmpStr.Substring(1, 1), tmpStr.Substring(2, 1));
                }
                else if (pType == ModuleCore.SystemEnum.PrintType.购货单)
                {
                    result = string.Concat(tmpStr.Substring(0, 1), "2", tmpStr.Substring(2, 1));
                }
                else if (pType == ModuleCore.SystemEnum.PrintType.配送单)
                {
                    result = string.Concat(tmpStr.Substring(0, 1), tmpStr.Substring(1, 1),"2");
                }
            }
            return result;
        }
        /// <summary>
        /// 获取打印状态
        /// </summary>
        /// <param name="printState"></param>
        /// <param name="isLink"></param>
        /// <returns></returns>
        public string GetPrintStateTxt(object printState, bool isLink)
        {
            int tmpResult = EbSite.Core.Utils.ObjectToInt(printState, 0);
            string tmpStr = "<div style='height:25px;'><a onclick=\"PrintOrder(this,'KDD')\">快递单{0}</a></div><div style='height:25px;'><a onclick=\"PrintOrder(this,'GHD')\">购货单{1}</a></div><div style='height:25px;'><a onclick=\"PrintOrder(this,'PSD')\">配货单{2}</a></div>";
            if (!isLink)
            {
                tmpStr = "<div>快递单{0}</div><div>购货单{1}</div><div>配货单{2}</div>";
            }
            string tmpTmplate = "(<span style=\"color:#{0}\">{1}</span>)";
            string tKDD = string.Format(tmpTmplate, "f00;", "未");
            string tPSD = string.Format(tmpTmplate, "f00;", "未");
            string tGHD = string.Format(tmpTmplate, "f00;", "未");
            if (tmpResult > 100)
            {
                if (tmpResult.ToString().Substring(0, 1).Equals("2"))
                {
                    tKDD = string.Format(tmpTmplate, "1b792f;font-weight:bold;", "已");
                }
                if (tmpResult.ToString().Substring(2, 1).Equals("2"))
                {
                    tPSD = string.Format(tmpTmplate, "1b792f;font-weight:bold;", "已");
                }
                if (tmpResult.ToString().Substring(1, 1).Equals("2"))
                {
                    tGHD = string.Format(tmpTmplate, "1b792f;font-weight:bold;", "已");
                }

            }
            return string.Format(tmpStr, tKDD, tGHD, tPSD);
        }

		#endregion  自定义方法

        #region 订单统计

        /// <summary>
        /// 统计订单数据
        /// </summary>
        /// <param name="dateType">日期类型(m:月，d:天)</param>
        /// <param name="dateVal">日期值(2013,201306)</param>
        /// <param name="fieldType">要统计的字段名称(l:交易量，e:交易额，r:利润)</param>
        /// <param name="sumCount">总数</param>
        /// <param name="maxCount">最大交易数</param>
        /// <returns></returns>
        public DataTable GetOrderCount(string dateType, int dateVal, string fieldType, out int sumCount, out int maxCount)
        {
            return dalHelper.Buy_Orders_GetOrderCount(dateType, dateVal, fieldType, out sumCount, out maxCount);
        }

        /// <summary>
        /// 获取总金额
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="strTotalProfit">总利润</param>
        /// <returns></returns>
        public string GetTotalOrderPrice(string strWhere, out string strTotalProfit)
        {
            return dalHelper.Buy_Orders_GetTotalOrderPrice(strWhere, out strTotalProfit);
        }

        ///// <summary>
        ///// 获取订单转化率的信息
        ///// </summary>
        ///// <param name="p_OrderTotalPrice">订单总额</param>
        ///// <param name="p_TotalMemberQuantity">总会员数</param>
        ///// <param name="p_TotalViewTimes">总访问次数</param>
        ///// <param name="p_TotalOrderQuantity">总订单数量</param>
        ///// <param name="p_HaveOrderMemberQuantity">下过订单的会员数量</param>
        //public void GetOrderConverRate(out decimal orderTotalPrice, out int totalMemberQuantity, out int totalViewTimes, out int totalOrderQuantity, out int haveOrderMemberQuantity)
        //{
        //    orderTotalPrice = 0;//订单总金额
        //    totalMemberQuantity = 0;//总会员数
        //    totalViewTimes = 0;//总访问次数
        //    totalOrderQuantity = 0;//总订单量
        //    haveOrderMemberQuantity = 0;//下过订单的会员

        //    dalHelper.Buy_Orders_GetOrderConverRate(out orderTotalPrice, out totalMemberQuantity, out totalViewTimes, out totalOrderQuantity, out haveOrderMemberQuantity);

        //    Guid[] gu = new Guid[] { new Guid("2bff96b8-91c9-475b-9131-28e776f18ef3") };
        //    List<EbSite.Entity.NewsContent> ls = EbSite.Base.AppStartInit.NewsContentInstDefault.AllList(gu, "", SettingInfo.Instance.GetSiteID);
        //    if (ls != null && ls.Count > 0)
        //    {
        //        foreach (EbSite.Entity.NewsContent md in ls)
        //        {
        //            totalViewTimes += md.hits;
        //        }
        //    }
        //}

         /// <summary>
        /// 获取订单访问购买率
        /// </summary>
        /// <returns></returns>
        /// <param name="iTop">获取条数</param>
        public DataTable GetOrderViewRate(int iTop)
        {
            return dalHelper.Buy_Orders_GetOrderViewRate(iTop);
        }

        #endregion 订单统计

        #region 更新要定时更新的订单

        /// <summary>
        /// 更新在超过规定的天数内需要关闭的订单
        /// </summary>
        /// <param name="closeDays">规定的天数</param>
        /// <returns></returns>
        public bool UpdateAutoCloseOrder(int closeDays)
        {
            return dalHelper.Buy_Orders_UpdateAutoCloseOrder(closeDays);
        }
        /// <summary>
        /// 更新在超过规定的天数内自动完成的订单
        /// </summary>
        /// <param name="finishDays">规定的天数</param>
        /// <returns></returns>
        public bool UpdateAutoFinishOrder(int finishDays)
        {
            return dalHelper.Buy_Orders_UpdateAutoFinishOrder(finishDays);
        }

        #endregion 更新要定时更新的订单

	}
}

