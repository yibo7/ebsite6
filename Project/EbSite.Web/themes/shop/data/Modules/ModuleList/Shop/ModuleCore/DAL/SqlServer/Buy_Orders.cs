using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Shop.ModuleCore.DAL.SqlServer
{
	/// <summary>
    /// 数据访问类Shop。
	/// </summary>
	public partial class Shop
	{
		private string sFieldBuy_Orders = "ID,OrderId,Remark,MerchandiserMarkID,MerchandiserRemark,AdjustedDiscount,OrderStatus,CloseReason,OrderAddDate,PayDate,SendDate,FinishDate,UserId,Username,EmailAddress,RealName,QQ,Wangwang,MSN,SendRegion,Address,ZipCode,SendToUserName,TelPhone,CellPhone,ShippingModeId,ModeName,RealShippingModeId,RealModeName,RegionId,Freight,AdjustedFreight,DeliveryOrderNumber,Weight,ExpressCompanyName,ExpressCompanyAbb,PaymentTypeId,PaymentType,PayFree,AdjustedPayFree,RefundStatus,RefundAmount,RefundRemark,OrderTotal,OrderPoint,OrderCostPrice,OrderProfit,ActualFreight,OtherCost,OptionPrice,Amount,ActivityId,ActivityName,EightFree,PayFreeFree,OrderOptionFree,DiscountId,DiscountName,DiscountValue,DiscountValueType,DiscountAmount,CouponName,CouponCode,CouponAmount,CouponValue,GroupId,GroupPrice,GroupBuyStatus,GatewayOrderId,IsPrinted,TaobaoOrderId";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int Buy_Orders_GetMaxId()
		{
			return DB.GetMaxID("ID", string.Format("{0}Buy_Orders",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Buy_Orders_Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Buy_Orders",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DB.Exists(strSql.ToString(),parameters);
		}

        public int Buy_Orders_Add(Entity.Buy_Orders model)
        {
            return Buy_Orders_Add(model, null);
        }

	    /// <summary>
		/// 增加一条数据
		/// </summary>
        public int Buy_Orders_Add(Entity.Buy_Orders model, SqlTransaction tran)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Buy_Orders(",sPre);
			strSql.Append("OrderId,Remark,MerchandiserMarkID,MerchandiserRemark,AdjustedDiscount,OrderStatus,CloseReason,OrderAddDate,PayDate,SendDate,FinishDate,UserId,Username,EmailAddress,RealName,QQ,Wangwang,MSN,SendRegion,Address,ZipCode,SendToUserName,TelPhone,CellPhone,ShippingModeId,ModeName,RealShippingModeId,RealModeName,RegionId,Freight,AdjustedFreight,DeliveryOrderNumber,Weight,ExpressCompanyName,ExpressCompanyAbb,PaymentTypeId,PaymentType,PayFree,AdjustedPayFree,RefundStatus,RefundAmount,RefundRemark,OrderTotal,OrderPoint,OrderCostPrice,OrderProfit,ActualFreight,OtherCost,OptionPrice,Amount,ActivityId,ActivityName,EightFree,PayFreeFree,OrderOptionFree,DiscountId,DiscountName,DiscountValue,DiscountValueType,DiscountAmount,CouponName,CouponCode,CouponAmount,CouponValue,GroupId,GroupPrice,GroupBuyStatus,GatewayOrderId,IsPrinted,TaobaoOrderId)");
			strSql.Append(" values (");
			strSql.Append("@ID,@OrderId,@Remark,@MerchandiserMarkID,@MerchandiserRemark,@AdjustedDiscount,@OrderStatus,@CloseReason,@OrderAddDate,@PayDate,@SendDate,@FinishDate,@UserId,@Username,@EmailAddress,@RealName,@QQ,@Wangwang,@MSN,@SendRegion,@Address,@ZipCode,@SendToUserName,@TelPhone,@CellPhone,@ShippingModeId,@ModeName,@RealShippingModeId,@RealModeName,@RegionId,@Freight,@AdjustedFreight,@DeliveryOrderNumber,@Weight,@ExpressCompanyName,@ExpressCompanyAbb,@PaymentTypeId,@PaymentType,@PayFree,@AdjustedPayFree,@RefundStatus,@RefundAmount,@RefundRemark,@OrderTotal,@OrderPoint,@OrderCostPrice,@OrderProfit,@ActualFreight,@OtherCost,@OptionPrice,@Amount,@ActivityId,@ActivityName,@EightFree,@PayFreeFree,@OrderOptionFree,@DiscountId,@DiscountName,@DiscountValue,@DiscountValueType,@DiscountAmount,@CouponName,@CouponCode,@CouponAmount,@CouponValue,@GroupId,@GroupPrice,@GroupBuyStatus,@GatewayOrderId,@IsPrinted,@TaobaoOrderId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderId", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@MerchandiserMarkID", SqlDbType.Int,4),
					new SqlParameter("@MerchandiserRemark", SqlDbType.Text),
					new SqlParameter("@AdjustedDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@OrderStatus", SqlDbType.Int,4),
					new SqlParameter("@CloseReason", SqlDbType.Text),
					new SqlParameter("@OrderAddDate", SqlDbType.DateTime),
					new SqlParameter("@PayDate", SqlDbType.DateTime),
					new SqlParameter("@SendDate", SqlDbType.DateTime),
					new SqlParameter("@FinishDate", SqlDbType.DateTime),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Username", SqlDbType.VarChar,64),
					new SqlParameter("@EmailAddress", SqlDbType.VarChar,255),
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@Wangwang", SqlDbType.VarChar,20),
					new SqlParameter("@MSN", SqlDbType.VarChar,128),
					new SqlParameter("@SendRegion", SqlDbType.VarChar,300),
					new SqlParameter("@Address", SqlDbType.VarChar,300),
					new SqlParameter("@ZipCode", SqlDbType.VarChar,20),
					new SqlParameter("@SendToUserName", SqlDbType.VarChar,50),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@CellPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ShippingModeId", SqlDbType.Int,4),
					new SqlParameter("@ModeName", SqlDbType.VarChar,50),
					new SqlParameter("@RealShippingModeId", SqlDbType.Int,4),
					new SqlParameter("@RealModeName", SqlDbType.VarChar,50),
					new SqlParameter("@RegionId", SqlDbType.Int,4),
					new SqlParameter("@Freight", SqlDbType.Decimal,9),
					new SqlParameter("@AdjustedFreight", SqlDbType.Decimal,9),
					new SqlParameter("@DeliveryOrderNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Weight", SqlDbType.Int,4),
					new SqlParameter("@ExpressCompanyName", SqlDbType.Text),
					new SqlParameter("@ExpressCompanyAbb", SqlDbType.Text),
					new SqlParameter("@PaymentTypeId", SqlDbType.Int,4),
					new SqlParameter("@PaymentType", SqlDbType.VarChar,100),
					new SqlParameter("@PayFree", SqlDbType.Decimal,9),
					new SqlParameter("@AdjustedPayFree", SqlDbType.Decimal,9),
					new SqlParameter("@RefundStatus", SqlDbType.Int,4),
					new SqlParameter("@RefundAmount", SqlDbType.Decimal,9),
					new SqlParameter("@RefundRemark", SqlDbType.Text),
					new SqlParameter("@OrderTotal", SqlDbType.Decimal,9),
					new SqlParameter("@OrderPoint", SqlDbType.Int,4),
					new SqlParameter("@OrderCostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OrderProfit", SqlDbType.Decimal,9),
					new SqlParameter("@ActualFreight", SqlDbType.Decimal,9),
					new SqlParameter("@OtherCost", SqlDbType.Decimal,9),
					new SqlParameter("@OptionPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@ActivityId", SqlDbType.Int,4),
					new SqlParameter("@ActivityName", SqlDbType.VarChar,200),
					new SqlParameter("@EightFree", SqlDbType.Bit,1),
					new SqlParameter("@PayFreeFree", SqlDbType.Bit,1),
					new SqlParameter("@OrderOptionFree", SqlDbType.Bit,1),
					new SqlParameter("@DiscountId", SqlDbType.Int,4),
					new SqlParameter("@DiscountName", SqlDbType.VarChar,200),
					new SqlParameter("@DiscountValue", SqlDbType.Decimal,9),
					new SqlParameter("@DiscountValueType", SqlDbType.Int,4),
					new SqlParameter("@DiscountAmount", SqlDbType.Decimal,9),
					new SqlParameter("@CouponName", SqlDbType.VarChar,100),
					new SqlParameter("@CouponCode", SqlDbType.VarChar,50),
					new SqlParameter("@CouponAmount", SqlDbType.Decimal,9),
					new SqlParameter("@CouponValue", SqlDbType.Decimal,9),
					new SqlParameter("@GroupId", SqlDbType.Int,4),
					new SqlParameter("@GroupPrice", SqlDbType.Decimal,9),
					new SqlParameter("@GroupBuyStatus", SqlDbType.Int,4),
					new SqlParameter("@GatewayOrderId", SqlDbType.VarChar,100),
					new SqlParameter("@IsPrinted", SqlDbType.Bit,1),
					new SqlParameter("@TaobaoOrderId", SqlDbType.VarChar,50)};
			parameters[0].Value = model.OrderId;
			parameters[1].Value = model.Remark;
			parameters[2].Value = model.MerchandiserMarkID;
			parameters[3].Value = model.MerchandiserRemark;
			parameters[4].Value = model.AdjustedDiscount;
			parameters[5].Value = model.OrderStatus;
			parameters[6].Value = model.CloseReason;
			parameters[7].Value = model.OrderAddDate;
			parameters[8].Value = model.PayDate;
			parameters[9].Value = model.SendDate;
			parameters[10].Value = model.FinishDate;
			parameters[11].Value = model.UserId;
			parameters[12].Value = model.Username;
			parameters[13].Value = model.EmailAddress;
			parameters[14].Value = model.RealName;
			parameters[15].Value = model.QQ;
			parameters[16].Value = model.Wangwang;
			parameters[17].Value = model.MSN;
			parameters[18].Value = model.SendRegion;
			parameters[19].Value = model.Address;
			parameters[20].Value = model.ZipCode;
			parameters[21].Value = model.SendToUserName;
			parameters[22].Value = model.TelPhone;
			parameters[23].Value = model.CellPhone;
			parameters[24].Value = model.ShippingModeId;
			parameters[25].Value = model.ModeName;
			parameters[26].Value = model.RealShippingModeId;
			parameters[27].Value = model.RealModeName;
			parameters[28].Value = model.RegionId;
			parameters[29].Value = model.Freight;
			parameters[30].Value = model.AdjustedFreight;
			parameters[31].Value = model.DeliveryOrderNumber;
			parameters[32].Value = model.Weight;
			parameters[33].Value = model.ExpressCompanyName;
			parameters[34].Value = model.ExpressCompanyAbb;
			parameters[35].Value = model.PaymentTypeId;
			parameters[36].Value = model.PaymentType;
			parameters[37].Value = model.PayFree;
			parameters[38].Value = model.AdjustedPayFree;
			parameters[39].Value = model.RefundStatus;
			parameters[40].Value = model.RefundAmount;
			parameters[41].Value = model.RefundRemark;
			parameters[42].Value = model.OrderTotal;
			parameters[43].Value = model.OrderPoint;
			parameters[44].Value = model.OrderCostPrice;
			parameters[45].Value = model.OrderProfit;
			parameters[46].Value = model.ActualFreight;
			parameters[47].Value = model.OtherCost;
			parameters[48].Value = model.OptionPrice;
			parameters[49].Value = model.Amount;
			parameters[50].Value = model.ActivityId;
			parameters[51].Value = model.ActivityName;
			parameters[52].Value = model.EightFree;
			parameters[53].Value = model.PayFreeFree;
			parameters[54].Value = model.OrderOptionFree;
			parameters[55].Value = model.DiscountId;
			parameters[56].Value = model.DiscountName;
			parameters[57].Value = model.DiscountValue;
			parameters[58].Value = model.DiscountValueType;
			parameters[59].Value = model.DiscountAmount;
			parameters[60].Value = model.CouponName;
			parameters[61].Value = model.CouponCode;
			parameters[62].Value = model.CouponAmount;
			parameters[63].Value = model.CouponValue;
			parameters[64].Value = model.GroupId;
			parameters[65].Value = model.GroupPrice;
			parameters[66].Value = model.GroupBuyStatus;
			parameters[67].Value = model.GatewayOrderId;
			parameters[68].Value = model.IsPrinted;
			parameters[69].Value = model.TaobaoOrderId;
	        object obj = null;
            if(!Equals(tran,null))
            {
                obj = DB.ExecuteScalar(tran,CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            }
			 
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
			return 0;		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Buy_Orders_Update(Entity.Buy_Orders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Buy_Orders set ",sPre);
			strSql.Append("OrderId=@OrderId,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("MerchandiserMarkID=@MerchandiserMarkID,");
			strSql.Append("MerchandiserRemark=@MerchandiserRemark,");
			strSql.Append("AdjustedDiscount=@AdjustedDiscount,");
			strSql.Append("OrderStatus=@OrderStatus,");
			strSql.Append("CloseReason=@CloseReason,");
			strSql.Append("OrderAddDate=@OrderAddDate,");
			strSql.Append("PayDate=@PayDate,");
			strSql.Append("SendDate=@SendDate,");
			strSql.Append("FinishDate=@FinishDate,");
			strSql.Append("UserId=@UserId,");
			strSql.Append("Username=@Username,");
			strSql.Append("EmailAddress=@EmailAddress,");
			strSql.Append("RealName=@RealName,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("Wangwang=@Wangwang,");
			strSql.Append("MSN=@MSN,");
			strSql.Append("SendRegion=@SendRegion,");
			strSql.Append("Address=@Address,");
			strSql.Append("ZipCode=@ZipCode,");
			strSql.Append("SendToUserName=@SendToUserName,");
			strSql.Append("TelPhone=@TelPhone,");
			strSql.Append("CellPhone=@CellPhone,");
			strSql.Append("ShippingModeId=@ShippingModeId,");
			strSql.Append("ModeName=@ModeName,");
			strSql.Append("RealShippingModeId=@RealShippingModeId,");
			strSql.Append("RealModeName=@RealModeName,");
			strSql.Append("RegionId=@RegionId,");
			strSql.Append("Freight=@Freight,");
			strSql.Append("AdjustedFreight=@AdjustedFreight,");
			strSql.Append("DeliveryOrderNumber=@DeliveryOrderNumber,");
			strSql.Append("Weight=@Weight,");
			strSql.Append("ExpressCompanyName=@ExpressCompanyName,");
			strSql.Append("ExpressCompanyAbb=@ExpressCompanyAbb,");
			strSql.Append("PaymentTypeId=@PaymentTypeId,");
			strSql.Append("PaymentType=@PaymentType,");
			strSql.Append("PayFree=@PayFree,");
			strSql.Append("AdjustedPayFree=@AdjustedPayFree,");
			strSql.Append("RefundStatus=@RefundStatus,");
			strSql.Append("RefundAmount=@RefundAmount,");
			strSql.Append("RefundRemark=@RefundRemark,");
			strSql.Append("OrderTotal=@OrderTotal,");
			strSql.Append("OrderPoint=@OrderPoint,");
			strSql.Append("OrderCostPrice=@OrderCostPrice,");
			strSql.Append("OrderProfit=@OrderProfit,");
			strSql.Append("ActualFreight=@ActualFreight,");
			strSql.Append("OtherCost=@OtherCost,");
			strSql.Append("OptionPrice=@OptionPrice,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("ActivityId=@ActivityId,");
			strSql.Append("ActivityName=@ActivityName,");
			strSql.Append("EightFree=@EightFree,");
			strSql.Append("PayFreeFree=@PayFreeFree,");
			strSql.Append("OrderOptionFree=@OrderOptionFree,");
			strSql.Append("DiscountId=@DiscountId,");
			strSql.Append("DiscountName=@DiscountName,");
			strSql.Append("DiscountValue=@DiscountValue,");
			strSql.Append("DiscountValueType=@DiscountValueType,");
			strSql.Append("DiscountAmount=@DiscountAmount,");
			strSql.Append("CouponName=@CouponName,");
			strSql.Append("CouponCode=@CouponCode,");
			strSql.Append("CouponAmount=@CouponAmount,");
			strSql.Append("CouponValue=@CouponValue,");
			strSql.Append("GroupId=@GroupId,");
			strSql.Append("GroupPrice=@GroupPrice,");
			strSql.Append("GroupBuyStatus=@GroupBuyStatus,");
			strSql.Append("GatewayOrderId=@GatewayOrderId,");
			strSql.Append("IsPrinted=@IsPrinted,");
			strSql.Append("TaobaoOrderId=@TaobaoOrderId");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@MerchandiserMarkID", SqlDbType.Int,4),
					new SqlParameter("@MerchandiserRemark", SqlDbType.Text),
					new SqlParameter("@AdjustedDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@OrderStatus", SqlDbType.Int,4),
					new SqlParameter("@CloseReason", SqlDbType.Text),
					new SqlParameter("@OrderAddDate", SqlDbType.DateTime),
					new SqlParameter("@PayDate", SqlDbType.DateTime),
					new SqlParameter("@SendDate", SqlDbType.DateTime),
					new SqlParameter("@FinishDate", SqlDbType.DateTime),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Username", SqlDbType.VarChar,64),
					new SqlParameter("@EmailAddress", SqlDbType.VarChar,255),
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@Wangwang", SqlDbType.VarChar,20),
					new SqlParameter("@MSN", SqlDbType.VarChar,128),
					new SqlParameter("@SendRegion", SqlDbType.VarChar,300),
					new SqlParameter("@Address", SqlDbType.VarChar,300),
					new SqlParameter("@ZipCode", SqlDbType.VarChar,20),
					new SqlParameter("@SendToUserName", SqlDbType.VarChar,50),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@CellPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ShippingModeId", SqlDbType.Int,4),
					new SqlParameter("@ModeName", SqlDbType.VarChar,50),
					new SqlParameter("@RealShippingModeId", SqlDbType.Int,4),
					new SqlParameter("@RealModeName", SqlDbType.VarChar,50),
					new SqlParameter("@RegionId", SqlDbType.Int,4),
					new SqlParameter("@Freight", SqlDbType.Decimal,9),
					new SqlParameter("@AdjustedFreight", SqlDbType.Decimal,9),
					new SqlParameter("@DeliveryOrderNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Weight", SqlDbType.Int,4),
					new SqlParameter("@ExpressCompanyName", SqlDbType.Text),
					new SqlParameter("@ExpressCompanyAbb", SqlDbType.Text),
					new SqlParameter("@PaymentTypeId", SqlDbType.Int,4),
					new SqlParameter("@PaymentType", SqlDbType.VarChar,100),
					new SqlParameter("@PayFree", SqlDbType.Decimal,9),
					new SqlParameter("@AdjustedPayFree", SqlDbType.Decimal,9),
					new SqlParameter("@RefundStatus", SqlDbType.Int,4),
					new SqlParameter("@RefundAmount", SqlDbType.Decimal,9),
					new SqlParameter("@RefundRemark", SqlDbType.Text),
					new SqlParameter("@OrderTotal", SqlDbType.Decimal,9),
					new SqlParameter("@OrderPoint", SqlDbType.Int,4),
					new SqlParameter("@OrderCostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OrderProfit", SqlDbType.Decimal,9),
					new SqlParameter("@ActualFreight", SqlDbType.Decimal,9),
					new SqlParameter("@OtherCost", SqlDbType.Decimal,9),
					new SqlParameter("@OptionPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@ActivityId", SqlDbType.Int,4),
					new SqlParameter("@ActivityName", SqlDbType.VarChar,200),
					new SqlParameter("@EightFree", SqlDbType.Bit,1),
					new SqlParameter("@PayFreeFree", SqlDbType.Bit,1),
					new SqlParameter("@OrderOptionFree", SqlDbType.Bit,1),
					new SqlParameter("@DiscountId", SqlDbType.Int,4),
					new SqlParameter("@DiscountName", SqlDbType.VarChar,200),
					new SqlParameter("@DiscountValue", SqlDbType.Decimal,9),
					new SqlParameter("@DiscountValueType", SqlDbType.Int,4),
					new SqlParameter("@DiscountAmount", SqlDbType.Decimal,9),
					new SqlParameter("@CouponName", SqlDbType.VarChar,100),
					new SqlParameter("@CouponCode", SqlDbType.VarChar,50),
					new SqlParameter("@CouponAmount", SqlDbType.Decimal,9),
					new SqlParameter("@CouponValue", SqlDbType.Decimal,9),
					new SqlParameter("@GroupId", SqlDbType.Int,4),
					new SqlParameter("@GroupPrice", SqlDbType.Decimal,9),
					new SqlParameter("@GroupBuyStatus", SqlDbType.Int,4),
					new SqlParameter("@GatewayOrderId", SqlDbType.VarChar,100),
					new SqlParameter("@IsPrinted", SqlDbType.Bit,1),
					new SqlParameter("@TaobaoOrderId", SqlDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.OrderId;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.MerchandiserMarkID;
			parameters[4].Value = model.MerchandiserRemark;
			parameters[5].Value = model.AdjustedDiscount;
			parameters[6].Value = model.OrderStatus;
			parameters[7].Value = model.CloseReason;
			parameters[8].Value = model.OrderAddDate;
			parameters[9].Value = model.PayDate;
			parameters[10].Value = model.SendDate;
			parameters[11].Value = model.FinishDate;
			parameters[12].Value = model.UserId;
			parameters[13].Value = model.Username;
			parameters[14].Value = model.EmailAddress;
			parameters[15].Value = model.RealName;
			parameters[16].Value = model.QQ;
			parameters[17].Value = model.Wangwang;
			parameters[18].Value = model.MSN;
			parameters[19].Value = model.SendRegion;
			parameters[20].Value = model.Address;
			parameters[21].Value = model.ZipCode;
			parameters[22].Value = model.SendToUserName;
			parameters[23].Value = model.TelPhone;
			parameters[24].Value = model.CellPhone;
			parameters[25].Value = model.ShippingModeId;
			parameters[26].Value = model.ModeName;
			parameters[27].Value = model.RealShippingModeId;
			parameters[28].Value = model.RealModeName;
			parameters[29].Value = model.RegionId;
			parameters[30].Value = model.Freight;
			parameters[31].Value = model.AdjustedFreight;
			parameters[32].Value = model.DeliveryOrderNumber;
			parameters[33].Value = model.Weight;
			parameters[34].Value = model.ExpressCompanyName;
			parameters[35].Value = model.ExpressCompanyAbb;
			parameters[36].Value = model.PaymentTypeId;
			parameters[37].Value = model.PaymentType;
			parameters[38].Value = model.PayFree;
			parameters[39].Value = model.AdjustedPayFree;
			parameters[40].Value = model.RefundStatus;
			parameters[41].Value = model.RefundAmount;
			parameters[42].Value = model.RefundRemark;
			parameters[43].Value = model.OrderTotal;
			parameters[44].Value = model.OrderPoint;
			parameters[45].Value = model.OrderCostPrice;
			parameters[46].Value = model.OrderProfit;
			parameters[47].Value = model.ActualFreight;
			parameters[48].Value = model.OtherCost;
			parameters[49].Value = model.OptionPrice;
			parameters[50].Value = model.Amount;
			parameters[51].Value = model.ActivityId;
			parameters[52].Value = model.ActivityName;
			parameters[53].Value = model.EightFree;
			parameters[54].Value = model.PayFreeFree;
			parameters[55].Value = model.OrderOptionFree;
			parameters[56].Value = model.DiscountId;
			parameters[57].Value = model.DiscountName;
			parameters[58].Value = model.DiscountValue;
			parameters[59].Value = model.DiscountValueType;
			parameters[60].Value = model.DiscountAmount;
			parameters[61].Value = model.CouponName;
			parameters[62].Value = model.CouponCode;
			parameters[63].Value = model.CouponAmount;
			parameters[64].Value = model.CouponValue;
			parameters[65].Value = model.GroupId;
			parameters[66].Value = model.GroupPrice;
			parameters[67].Value = model.GroupBuyStatus;
			parameters[68].Value = model.GatewayOrderId;
			parameters[69].Value = model.IsPrinted;
			parameters[70].Value = model.TaobaoOrderId;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Buy_Orders_Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Buy_Orders ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Buy_Orders Buy_Orders_GetEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldBuy_Orders +"  from {0}Buy_Orders ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;
			Entity.Buy_Orders model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Buy_Orders_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int Buy_Orders_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Buy_Orders ",sPre);
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			int iCount = 0;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text,strSql.ToString()))
			{
				while (dataReader.Read())
				{
					iCount = int.Parse(dataReader[0].ToString());
				}
			}
			return iCount;
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet Buy_Orders_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldBuy_Orders );
			strSql.AppendFormat(" FROM {0}Buy_Orders ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.Buy_Orders> Buy_Orders_GetListArray(string strWhere)
		{
			return Buy_Orders_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.Buy_Orders> Buy_Orders_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldBuy_Orders );
			strSql.AppendFormat(" FROM {0}Buy_Orders ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.Buy_Orders> list = new List<Entity.Buy_Orders>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Buy_Orders_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.Buy_Orders> Buy_Orders_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.Buy_Orders> list = new List<Entity.Buy_Orders>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"Buy_Orders", PageSize, PageIndex, Fileds, "ID", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(Buy_Orders_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.Buy_Orders Buy_Orders_ReaderBind(IDataReader dataReader)
		{
			Entity.Buy_Orders model=new Entity.Buy_Orders();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.OrderId=dataReader["OrderId"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["MerchandiserMarkID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MerchandiserMarkID=(int)ojb;
			}
			model.MerchandiserRemark=dataReader["MerchandiserRemark"].ToString();
			ojb = dataReader["AdjustedDiscount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AdjustedDiscount=(decimal)ojb;
			}
			ojb = dataReader["OrderStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderStatus=(int)ojb;
			}
			model.CloseReason=dataReader["CloseReason"].ToString();
			ojb = dataReader["OrderAddDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderAddDate=(DateTime)ojb;
			}
			ojb = dataReader["PayDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PayDate=(DateTime)ojb;
			}
			ojb = dataReader["SendDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SendDate=(DateTime)ojb;
			}
			ojb = dataReader["FinishDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FinishDate=(DateTime)ojb;
			}
			ojb = dataReader["UserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserId=(int)ojb;
			}
			model.Username=dataReader["Username"].ToString();
			model.EmailAddress=dataReader["EmailAddress"].ToString();
			model.RealName=dataReader["RealName"].ToString();
			model.QQ=dataReader["QQ"].ToString();
			model.Wangwang=dataReader["Wangwang"].ToString();
			model.MSN=dataReader["MSN"].ToString();
			model.SendRegion=dataReader["SendRegion"].ToString();
			model.Address=dataReader["Address"].ToString();
			model.ZipCode=dataReader["ZipCode"].ToString();
			model.SendToUserName=dataReader["SendToUserName"].ToString();
			model.TelPhone=dataReader["TelPhone"].ToString();
			model.CellPhone=dataReader["CellPhone"].ToString();
			ojb = dataReader["ShippingModeId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ShippingModeId=(int)ojb;
			}
			model.ModeName=dataReader["ModeName"].ToString();
			ojb = dataReader["RealShippingModeId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RealShippingModeId=(int)ojb;
			}
			model.RealModeName=dataReader["RealModeName"].ToString();
			ojb = dataReader["RegionId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RegionId=(int)ojb;
			}
			ojb = dataReader["Freight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Freight=(decimal)ojb;
			}
			ojb = dataReader["AdjustedFreight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AdjustedFreight=(decimal)ojb;
			}
			model.DeliveryOrderNumber=dataReader["DeliveryOrderNumber"].ToString();
			ojb = dataReader["Weight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight=(int)ojb;
			}
			model.ExpressCompanyName=dataReader["ExpressCompanyName"].ToString();
			model.ExpressCompanyAbb=dataReader["ExpressCompanyAbb"].ToString();
			ojb = dataReader["PaymentTypeId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PaymentTypeId=(int)ojb;
			}
			model.PaymentType=dataReader["PaymentType"].ToString();
			ojb = dataReader["PayFree"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PayFree=(decimal)ojb;
			}
			ojb = dataReader["AdjustedPayFree"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AdjustedPayFree=(decimal)ojb;
			}
			ojb = dataReader["RefundStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RefundStatus=(int)ojb;
			}
			ojb = dataReader["RefundAmount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RefundAmount=(decimal)ojb;
			}
			model.RefundRemark=dataReader["RefundRemark"].ToString();
			ojb = dataReader["OrderTotal"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderTotal=(decimal)ojb;
			}
			ojb = dataReader["OrderPoint"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderPoint=(int)ojb;
			}
			ojb = dataReader["OrderCostPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderCostPrice=(decimal)ojb;
			}
			ojb = dataReader["OrderProfit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderProfit=(decimal)ojb;
			}
			ojb = dataReader["ActualFreight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ActualFreight=(decimal)ojb;
			}
			ojb = dataReader["OtherCost"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OtherCost=(decimal)ojb;
			}
			ojb = dataReader["OptionPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OptionPrice=(decimal)ojb;
			}
			ojb = dataReader["Amount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Amount=(decimal)ojb;
			}
			ojb = dataReader["ActivityId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ActivityId=(int)ojb;
			}
			model.ActivityName=dataReader["ActivityName"].ToString();
			ojb = dataReader["EightFree"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EightFree=(bool)ojb;
			}
			ojb = dataReader["PayFreeFree"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PayFreeFree=(bool)ojb;
			}
			ojb = dataReader["OrderOptionFree"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderOptionFree=(bool)ojb;
			}
			ojb = dataReader["DiscountId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DiscountId=(int)ojb;
			}
			model.DiscountName=dataReader["DiscountName"].ToString();
			ojb = dataReader["DiscountValue"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DiscountValue=(decimal)ojb;
			}
			ojb = dataReader["DiscountValueType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DiscountValueType=(int)ojb;
			}
			ojb = dataReader["DiscountAmount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DiscountAmount=(decimal)ojb;
			}
			model.CouponName=dataReader["CouponName"].ToString();
			model.CouponCode=dataReader["CouponCode"].ToString();
			ojb = dataReader["CouponAmount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CouponAmount=(decimal)ojb;
			}
			ojb = dataReader["CouponValue"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CouponValue=(decimal)ojb;
			}
			ojb = dataReader["GroupId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GroupId=(int)ojb;
			}
			ojb = dataReader["GroupPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GroupPrice=(decimal)ojb;
			}
			ojb = dataReader["GroupBuyStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GroupBuyStatus=(int)ojb;
			}
			model.GatewayOrderId=dataReader["GatewayOrderId"].ToString();
			ojb = dataReader["IsPrinted"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPrinted=(bool)ojb;
			}
			model.TaobaoOrderId=dataReader["TaobaoOrderId"].ToString();
			return model;
		}

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="dicData">要更新的集合(如果value是字符串,需提前加上引号)</param>
        public bool UpdateByDic(Dictionary<string, object> dicArray, int rid)
        {
            if (dicArray != null && dicArray.Count > 0)
            {
                StringBuilder tmpSql = new StringBuilder();
                foreach (KeyValuePair<string, object> dic in dicArray)
                {
                    tmpSql.AppendFormat("{0}={1},", dic.Key, dic.Value);
                }
                if (tmpSql.Length > 0 && rid > 0)
                {
                    string strSql = string.Format("update {0}Buy_Orders set {1} where id={2}", sPre, tmpSql.ToString().TrimEnd(','), rid);
                    if (DB.ExecuteNonQuery(strSql) > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="dicArray">要更新的集合(如果value是字符串,需提前加上引号)</param>
        /// <param name="rid">要更新的ID集合</param>
        public bool UpdateByDic(Dictionary<string, object> dicArray, string rids)
        {
            if (dicArray != null && dicArray.Count > 0)
            {
                StringBuilder tmpSql = new StringBuilder();
                foreach (KeyValuePair<string, object> dic in dicArray)
                {
                    tmpSql.AppendFormat("{0}={1},", dic.Key, dic.Value);
                }
                if (tmpSql.Length > 0 && !string.IsNullOrEmpty(rids))
                {
                    string strSql = string.Format("update {0}Buy_Orders set {1} where id in({2})", sPre, tmpSql.ToString().TrimEnd(','), rids);
                    if (DB.ExecuteNonQuery(strSql) > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool AddOrder(Entity.Buy_Orders md, List<EbSite.Entity.OrderOptionValue> lstOov, int CouponItemID,
                      ICollection<Entity.Buy_OrderItem> CartItems)
        {
            return false;

        }

        public bool AddOrder(Entity.Buy_Orders md, ICollection<Entity.Buy_OrderItem> CartItems)
        {
            //Buy_Orders_Add(Entity.Buy_Orders model, SqlTransaction Trans);

            bool isSuccessed = true;
            SqlConnection cn = new SqlConnection(DB.ConnectionString());
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction();  //创建事务

            try
            {

                Buy_Orders_Add(md, tran);
                //添加定单对应的商品
                foreach (Entity.Buy_OrderItem orderItem in CartItems)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.AppendFormat("update {0}Buy_OrderItem set ", sPre);
                    strSql.Append("OrderId=@OrderId,");
                    strSql.Append("IsBuy=@IsBuy");
                    strSql.Append(" where id=@id ");
                    SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.VarChar,20),
					new SqlParameter("@IsBuy", SqlDbType.Bit,1)
                                          };
                    parameters[0].Value = orderItem.id;
                    parameters[1].Value = md.OrderId;
                    parameters[2].Value = true;
                    DB.ExecuteNonQuery(tran, CommandType.Text, strSql.ToString(), parameters);
                }

                //提交事务
                tran.Commit();
            }
            catch
            {
                //出错回滚
                tran.Rollback();
                isSuccessed = false;
                throw;
            }
            finally  //关闭联接
            {
                if (cn != null && cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return isSuccessed;
        }
        #endregion 自定义方法
	}
}

