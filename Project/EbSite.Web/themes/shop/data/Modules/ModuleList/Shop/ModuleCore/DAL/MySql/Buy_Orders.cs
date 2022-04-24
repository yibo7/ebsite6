using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using EbSite.Entity;
using EbSite.Modules.Shop.ModuleCore.Entity;
using MySql.Data.MySqlClient;
namespace EbSite.Modules.Shop.ModuleCore.DAL.MySql
{
    /// <summary>
    /// 数据访问类Shop。
    /// </summary>
    public partial class Shop
    {
        private string sFieldBuy_Orders = "ID,OrderId,Remark,MerchandiserMarkID,MerchandiserRemark,AdjustedDiscount,OrderStatus,CloseReason,OrderAddDate,PayDate,SendDate,FinishDate,UserId,Username,EmailAddress,RealName,QQ,Wangwang,MSN,SendRegion,Address,ZipCode,SendToUserName,TelPhone,CellPhone,ShippingModeId,ModeName,RealShippingModeId,RealModeName,RegionId,Freight,AdjustedFreight,DeliveryOrderNumber,Weight,ExpressCompanyName,ExpressCompanyAbb,PaymentTypeId,PaymentType,PayFree,AdjustedPayFree,RefundStatus,RefundAmount,RefundRemark,OrderTotal,OrderPoint,OrderCostPrice,OrderProfit,ActualFreight,OtherCost,OptionPrice,Amount,ActivityId,ActivityName,EightFree,PayFreeFree,OrderOptionFree,DiscountId,DiscountName,DiscountValue,DiscountValueType,DiscountAmount,CouponName,CouponCode,CouponAmount,CouponValue,GroupId,GroupPrice,GroupBuyStatus,GatewayOrderId,IsPrinted,TaobaoOrderId,TimeNumber,ReviewedOrderDate,SureReceiptDate,DelOrderDate,PanicBuyingId,UserBalance,iCome";

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public long Buy_Orders_GetMaxId()
        {
            return DB.GetMaxID("ID", "Buy_Orders", sPre);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Buy_Orders_Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}Buy_Orders", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            return DB.Exists(strSql.ToString(), parameters);
        }

        public int Buy_Orders_Add(Entity.Buy_Orders model)
        {
            return Buy_Orders_Add(model, null);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Buy_Orders_Add(Entity.Buy_Orders model, MySqlTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}Buy_Orders(", sPre);
            strSql.Append("OrderId,Remark,MerchandiserMarkID,MerchandiserRemark,AdjustedDiscount,OrderStatus,CloseReason,OrderAddDate,PayDate,SendDate,FinishDate,UserId,Username,EmailAddress,RealName,QQ,Wangwang,MSN,SendRegion,Address,ZipCode,SendToUserName,TelPhone,CellPhone,ShippingModeId,ModeName,RealShippingModeId,RealModeName,RegionId,Freight,AdjustedFreight,DeliveryOrderNumber,Weight,ExpressCompanyName,ExpressCompanyAbb,PaymentTypeId,PaymentType,PayFree,AdjustedPayFree,RefundStatus,RefundAmount,RefundRemark,OrderTotal,OrderPoint,OrderCostPrice,OrderProfit,ActualFreight,OtherCost,OptionPrice,Amount,ActivityId,ActivityName,EightFree,PayFreeFree,OrderOptionFree,DiscountId,DiscountName,DiscountValue,DiscountValueType,DiscountAmount,CouponName,CouponCode,CouponAmount,CouponValue,GroupId,GroupPrice,GroupBuyStatus,GatewayOrderId,IsPrinted,TaobaoOrderId,TimeNumber,ReviewedOrderDate,SureReceiptDate,DelOrderDate,PanicBuyingId,UserBalance,iCome)");
            strSql.Append(" values (");
            strSql.Append("?OrderId,?Remark,?MerchandiserMarkID,?MerchandiserRemark,?AdjustedDiscount,?OrderStatus,?CloseReason,?OrderAddDate,?PayDate,?SendDate,?FinishDate,?UserId,?Username,?EmailAddress,?RealName,?QQ,?Wangwang,?MSN,?SendRegion,?Address,?ZipCode,?SendToUserName,?TelPhone,?CellPhone,?ShippingModeId,?ModeName,?RealShippingModeId,?RealModeName,?RegionId,?Freight,?AdjustedFreight,?DeliveryOrderNumber,?Weight,?ExpressCompanyName,?ExpressCompanyAbb,?PaymentTypeId,?PaymentType,?PayFree,?AdjustedPayFree,?RefundStatus,?RefundAmount,?RefundRemark,?OrderTotal,?OrderPoint,?OrderCostPrice,?OrderProfit,?ActualFreight,?OtherCost,?OptionPrice,?Amount,?ActivityId,?ActivityName,?EightFree,?PayFreeFree,?OrderOptionFree,?DiscountId,?DiscountName,?DiscountValue,?DiscountValueType,?DiscountAmount,?CouponName,?CouponCode,?CouponAmount,?CouponValue,?GroupId,?GroupPrice,?GroupBuyStatus,?GatewayOrderId,?IsPrinted,?TaobaoOrderId,?TimeNumber,?ReviewedOrderDate,?SureReceiptDate,?DelOrderDate,?PanicBuyingId,?UserBalance,?iCome)");
            strSql.Append(";select @@IDENTITY;");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderId", MySqlDbType.Int64,15),
					new MySqlParameter("?Remark", MySqlDbType.Text),
					new MySqlParameter("?MerchandiserMarkID", MySqlDbType.Int32,4),
					new MySqlParameter("?MerchandiserRemark", MySqlDbType.Text),
					new MySqlParameter("?AdjustedDiscount", MySqlDbType.Decimal,18),
					new MySqlParameter("?OrderStatus", MySqlDbType.Int32,4),
					new MySqlParameter("?CloseReason", MySqlDbType.Text),
					new MySqlParameter("?OrderAddDate", MySqlDbType.DateTime),
					new MySqlParameter("?PayDate",MySqlDbType.DateTime),
					new MySqlParameter("?SendDate",MySqlDbType.DateTime),
					new MySqlParameter("?FinishDate",MySqlDbType.DateTime),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Username", MySqlDbType.VarChar,64),
					new MySqlParameter("?EmailAddress", MySqlDbType.VarChar,255),
					new MySqlParameter("?RealName", MySqlDbType.VarChar,50),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,20),
					new MySqlParameter("?Wangwang", MySqlDbType.VarChar,20),
					new MySqlParameter("?MSN", MySqlDbType.VarChar,128),
					new MySqlParameter("?SendRegion", MySqlDbType.VarChar,300),
					new MySqlParameter("?Address", MySqlDbType.VarChar,300),
					new MySqlParameter("?ZipCode", MySqlDbType.VarChar,20),
					new MySqlParameter("?SendToUserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?TelPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?CellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?ShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?ModeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?RealShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?RealModeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Freight", MySqlDbType.Decimal,18),
					new MySqlParameter("?AdjustedFreight", MySqlDbType.Decimal,18),
					new MySqlParameter("?DeliveryOrderNumber", MySqlDbType.VarChar,50),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?ExpressCompanyName", MySqlDbType.Text),
					new MySqlParameter("?ExpressCompanyAbb", MySqlDbType.Text),
					new MySqlParameter("?PaymentTypeId", MySqlDbType.Int32,4),
					new MySqlParameter("?PaymentType", MySqlDbType.VarChar,100),
					new MySqlParameter("?PayFree", MySqlDbType.Decimal,18),
					new MySqlParameter("?AdjustedPayFree", MySqlDbType.Decimal,18),
					new MySqlParameter("?RefundStatus", MySqlDbType.Int32,4),
					new MySqlParameter("?RefundAmount", MySqlDbType.Decimal,18),
					new MySqlParameter("?RefundRemark", MySqlDbType.Text),
					new MySqlParameter("?OrderTotal", MySqlDbType.Decimal,18),
					new MySqlParameter("?OrderPoint", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderCostPrice", MySqlDbType.Decimal,18),
					new MySqlParameter("?OrderProfit", MySqlDbType.Decimal,18),
					new MySqlParameter("?ActualFreight", MySqlDbType.Decimal,18),
					new MySqlParameter("?OtherCost", MySqlDbType.Decimal,18),
					new MySqlParameter("?OptionPrice", MySqlDbType.Decimal,18),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,18),
					new MySqlParameter("?ActivityId", MySqlDbType.Int32,4),
					new MySqlParameter("?ActivityName", MySqlDbType.VarChar,200),
					new MySqlParameter("?EightFree", MySqlDbType.Bit),
					new MySqlParameter("?PayFreeFree", MySqlDbType.Bit),
					new MySqlParameter("?OrderOptionFree", MySqlDbType.Bit),
					new MySqlParameter("?DiscountId", MySqlDbType.Int32,4),
					new MySqlParameter("?DiscountName", MySqlDbType.VarChar,200),
					new MySqlParameter("?DiscountValue", MySqlDbType.Decimal,18),
					new MySqlParameter("?DiscountValueType", MySqlDbType.Int32,4),
					new MySqlParameter("?DiscountAmount", MySqlDbType.Decimal,18),
					new MySqlParameter("?CouponName", MySqlDbType.VarChar,100),
					new MySqlParameter("?CouponCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?CouponAmount", MySqlDbType.Decimal,18),
					new MySqlParameter("?CouponValue", MySqlDbType.Decimal,18),
					new MySqlParameter("?GroupId", MySqlDbType.Int32,4),
					new MySqlParameter("?GroupPrice", MySqlDbType.Decimal,18),
					new MySqlParameter("?GroupBuyStatus", MySqlDbType.Int32,4),
					new MySqlParameter("?GatewayOrderId", MySqlDbType.VarChar,100),
					new MySqlParameter("?IsPrinted", MySqlDbType.Int32,4),
					new MySqlParameter("?TaobaoOrderId", MySqlDbType.VarChar,50),
                    new MySqlParameter("?TimeNumber",MySqlDbType.Int32,4),
                    new MySqlParameter("?ReviewedOrderDate", MySqlDbType.DateTime),
					new MySqlParameter("?SureReceiptDate", MySqlDbType.DateTime),
					new MySqlParameter("?DelOrderDate", MySqlDbType.DateTime),
                    new MySqlParameter("?PanicBuyingId",MySqlDbType.Int32,4),
                    new MySqlParameter("?UserBalance",MySqlDbType.Decimal,18),
                    new MySqlParameter("?iCome",MySqlDbType.Int32,4) };
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
            parameters[70].Value = model.TimeNumber;
            parameters[71].Value = model.ReviewedOrderDate;
            parameters[72].Value = model.SureReceiptDate;
            parameters[73].Value = model.DelOrderDate;
            parameters[74].Value = model.PanicBuyingId;
            parameters[75].Value = model.UserBalance;
            parameters[76].Value = model.iCome;

            object obj = null;

            if (Trans == null)
            {
                obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                obj = DB.ExecuteScalar(Trans, CommandType.Text, strSql.ToString(), parameters);

            }
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }

        public void Buy_Orders_Update(Entity.Buy_Orders model)
        {
            Buy_Orders_Update(model, null);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Buy_Orders_Update(Entity.Buy_Orders model, MySqlTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}Buy_Orders set ", sPre);
            strSql.Append("OrderId=?OrderId,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("MerchandiserMarkID=?MerchandiserMarkID,");
            strSql.Append("MerchandiserRemark=?MerchandiserRemark,");
            strSql.Append("AdjustedDiscount=?AdjustedDiscount,");
            strSql.Append("OrderStatus=?OrderStatus,");
            strSql.Append("CloseReason=?CloseReason,");
            strSql.Append("OrderAddDate=?OrderAddDate,");
            strSql.Append("PayDate=?PayDate,");
            strSql.Append("SendDate=?SendDate,");
            strSql.Append("FinishDate=?FinishDate,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("Username=?Username,");
            strSql.Append("EmailAddress=?EmailAddress,");
            strSql.Append("RealName=?RealName,");
            strSql.Append("QQ=?QQ,");
            strSql.Append("Wangwang=?Wangwang,");
            strSql.Append("MSN=?MSN,");
            strSql.Append("SendRegion=?SendRegion,");
            strSql.Append("Address=?Address,");
            strSql.Append("ZipCode=?ZipCode,");
            strSql.Append("SendToUserName=?SendToUserName,");
            strSql.Append("TelPhone=?TelPhone,");
            strSql.Append("CellPhone=?CellPhone,");
            strSql.Append("ShippingModeId=?ShippingModeId,");
            strSql.Append("ModeName=?ModeName,");
            strSql.Append("RealShippingModeId=?RealShippingModeId,");
            strSql.Append("RealModeName=?RealModeName,");
            strSql.Append("RegionId=?RegionId,");
            strSql.Append("Freight=?Freight,");
            strSql.Append("AdjustedFreight=?AdjustedFreight,");
            strSql.Append("DeliveryOrderNumber=?DeliveryOrderNumber,");
            strSql.Append("Weight=?Weight,");
            strSql.Append("ExpressCompanyName=?ExpressCompanyName,");
            strSql.Append("ExpressCompanyAbb=?ExpressCompanyAbb,");
            strSql.Append("PaymentTypeId=?PaymentTypeId,");
            strSql.Append("PaymentType=?PaymentType,");
            strSql.Append("PayFree=?PayFree,");
            strSql.Append("AdjustedPayFree=?AdjustedPayFree,");
            strSql.Append("RefundStatus=?RefundStatus,");
            strSql.Append("RefundAmount=?RefundAmount,");
            strSql.Append("RefundRemark=?RefundRemark,");
            strSql.Append("OrderTotal=?OrderTotal,");
            strSql.Append("OrderPoint=?OrderPoint,");
            strSql.Append("OrderCostPrice=?OrderCostPrice,");
            strSql.Append("OrderProfit=?OrderProfit,");
            strSql.Append("ActualFreight=?ActualFreight,");
            strSql.Append("OtherCost=?OtherCost,");
            strSql.Append("OptionPrice=?OptionPrice,");
            strSql.Append("Amount=?Amount,");
            strSql.Append("ActivityId=?ActivityId,");
            strSql.Append("ActivityName=?ActivityName,");
            strSql.Append("EightFree=?EightFree,");
            strSql.Append("PayFreeFree=?PayFreeFree,");
            strSql.Append("OrderOptionFree=?OrderOptionFree,");
            strSql.Append("DiscountId=?DiscountId,");
            strSql.Append("DiscountName=?DiscountName,");
            strSql.Append("DiscountValue=?DiscountValue,");
            strSql.Append("DiscountValueType=?DiscountValueType,");
            strSql.Append("DiscountAmount=?DiscountAmount,");
            strSql.Append("CouponName=?CouponName,");
            strSql.Append("CouponCode=?CouponCode,");
            strSql.Append("CouponAmount=?CouponAmount,");
            strSql.Append("CouponValue=?CouponValue,");
            strSql.Append("GroupId=?GroupId,");
            strSql.Append("GroupPrice=?GroupPrice,");
            strSql.Append("GroupBuyStatus=?GroupBuyStatus,");
            strSql.Append("GatewayOrderId=?GatewayOrderId,");
            strSql.Append("IsPrinted=?IsPrinted,");
            strSql.Append("TaobaoOrderId=?TaobaoOrderId,");

            strSql.Append("TimeNumber=?TimeNumber,");
            strSql.Append("ReviewedOrderDate=?ReviewedOrderDate,");
            strSql.Append("SureReceiptDate=?SureReceiptDate,");
            strSql.Append("DelOrderDate=?DelOrderDate,");
            strSql.Append("PanicBuyingId=?PanicBuyingId,");
            strSql.Append("UserBalance=?UserBalance");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderId", MySqlDbType.Int64,15),
					new MySqlParameter("?Remark", MySqlDbType.Text),
					new MySqlParameter("?MerchandiserMarkID", MySqlDbType.Int32,4),
					new MySqlParameter("?MerchandiserRemark", MySqlDbType.Text),
					new MySqlParameter("?AdjustedDiscount", MySqlDbType.Decimal,18),
					new MySqlParameter("?OrderStatus", MySqlDbType.Int32,4),
					new MySqlParameter("?CloseReason", MySqlDbType.Text),
					new MySqlParameter("?OrderAddDate",MySqlDbType.DateTime),
					new MySqlParameter("?PayDate",MySqlDbType.DateTime),
					new MySqlParameter("?SendDate",MySqlDbType.DateTime),
					new MySqlParameter("?FinishDate",MySqlDbType.DateTime),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Username", MySqlDbType.VarChar,64),
					new MySqlParameter("?EmailAddress", MySqlDbType.VarChar,255),
					new MySqlParameter("?RealName", MySqlDbType.VarChar,50),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,20),
					new MySqlParameter("?Wangwang", MySqlDbType.VarChar,20),
					new MySqlParameter("?MSN", MySqlDbType.VarChar,128),
					new MySqlParameter("?SendRegion", MySqlDbType.VarChar,300),
					new MySqlParameter("?Address", MySqlDbType.VarChar,300),
					new MySqlParameter("?ZipCode", MySqlDbType.VarChar,20),
					new MySqlParameter("?SendToUserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?TelPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?CellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?ShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?ModeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?RealShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?RealModeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Freight", MySqlDbType.Decimal,18),
					new MySqlParameter("?AdjustedFreight", MySqlDbType.Decimal,18),
					new MySqlParameter("?DeliveryOrderNumber", MySqlDbType.VarChar,50),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?ExpressCompanyName", MySqlDbType.Text),
					new MySqlParameter("?ExpressCompanyAbb", MySqlDbType.Text),
					new MySqlParameter("?PaymentTypeId", MySqlDbType.Int32,4),
					new MySqlParameter("?PaymentType", MySqlDbType.VarChar,100),
					new MySqlParameter("?PayFree", MySqlDbType.Decimal,18),
					new MySqlParameter("?AdjustedPayFree", MySqlDbType.Decimal,18),
					new MySqlParameter("?RefundStatus", MySqlDbType.Int32,4),
					new MySqlParameter("?RefundAmount", MySqlDbType.Decimal,18),
					new MySqlParameter("?RefundRemark", MySqlDbType.Text),
					new MySqlParameter("?OrderTotal", MySqlDbType.Decimal,18),
					new MySqlParameter("?OrderPoint", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderCostPrice", MySqlDbType.Decimal,18),
					new MySqlParameter("?OrderProfit", MySqlDbType.Decimal,18),
					new MySqlParameter("?ActualFreight", MySqlDbType.Decimal,18),
					new MySqlParameter("?OtherCost", MySqlDbType.Decimal,18),
					new MySqlParameter("?OptionPrice", MySqlDbType.Decimal,18),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,18),
					new MySqlParameter("?ActivityId", MySqlDbType.Int32,4),
					new MySqlParameter("?ActivityName", MySqlDbType.VarChar,200),
					new MySqlParameter("?EightFree", MySqlDbType.Bit),
					new MySqlParameter("?PayFreeFree", MySqlDbType.Bit),
					new MySqlParameter("?OrderOptionFree", MySqlDbType.Bit),
					new MySqlParameter("?DiscountId", MySqlDbType.Int32,4),
					new MySqlParameter("?DiscountName", MySqlDbType.VarChar,200),
					new MySqlParameter("?DiscountValue", MySqlDbType.Decimal,18),
					new MySqlParameter("?DiscountValueType", MySqlDbType.Int32,4),
					new MySqlParameter("?DiscountAmount", MySqlDbType.Decimal,18),
					new MySqlParameter("?CouponName", MySqlDbType.VarChar,100),
					new MySqlParameter("?CouponCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?CouponAmount", MySqlDbType.Decimal,18),
					new MySqlParameter("?CouponValue", MySqlDbType.Decimal,18),
					new MySqlParameter("?GroupId", MySqlDbType.Int32,4),
					new MySqlParameter("?GroupPrice", MySqlDbType.Decimal,18),
					new MySqlParameter("?GroupBuyStatus", MySqlDbType.Int32,4),
					new MySqlParameter("?GatewayOrderId", MySqlDbType.VarChar,100),
					new MySqlParameter("?IsPrinted", MySqlDbType.Int32,4),
					new MySqlParameter("?TaobaoOrderId", MySqlDbType.VarChar,50),
                    new MySqlParameter("?TimeNumber", MySqlDbType.Int32,11),
					new MySqlParameter("?ReviewedOrderDate", MySqlDbType.DateTime),
					new MySqlParameter("?SureReceiptDate", MySqlDbType.DateTime),
					new MySqlParameter("?DelOrderDate", MySqlDbType.DateTime),
                    new MySqlParameter("?PanicBuyingId",MySqlDbType.Int32,4),
                    new MySqlParameter("?UserBalance",MySqlDbType.Decimal,18) };
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
            parameters[71].Value = model.TimeNumber;
            parameters[72].Value = model.ReviewedOrderDate;
            parameters[73].Value = model.SureReceiptDate;
            parameters[74].Value = model.DelOrderDate;
            parameters[75].Value = model.PanicBuyingId;
            parameters[76].Value = model.UserBalance;



            if (Trans == null)
            {
                DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                DB.ExecuteNonQuery(Trans, CommandType.Text, strSql.ToString(), parameters);
            }

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Buy_Orders_Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Buy_Orders ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Buy_Orders Buy_Orders_GetEntity(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldBuy_Orders + "  from {0}Buy_Orders ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;
            Entity.Buy_Orders model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Buy_Orders_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Buy_Orders_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}Buy_Orders ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            int iCount = 0;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
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
        public DataSet Buy_Orders_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldBuy_Orders);
            strSql.AppendFormat(" FROM {0}Buy_Orders ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.Buy_Orders> Buy_Orders_GetListArray(string strWhere)
        {
            return Buy_Orders_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Buy_Orders> Buy_Orders_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldBuy_Orders);
            strSql.AppendFormat(" FROM {0}Buy_Orders ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
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
        public List<Entity.Buy_Orders> Buy_Orders_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = Buy_Orders_GetCount(sbSql.ToString());
            List<Entity.Buy_Orders> list = new List<Entity.Buy_Orders>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "Buy_Orders", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
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
            Entity.Buy_Orders model = new Entity.Buy_Orders();
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["OrderId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderId = (long)ojb;
            }

            model.Remark = dataReader["Remark"].ToString();
            ojb = dataReader["MerchandiserMarkID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MerchandiserMarkID = (int)ojb;
            }
            model.MerchandiserRemark = dataReader["MerchandiserRemark"].ToString();
            ojb = dataReader["AdjustedDiscount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AdjustedDiscount = (decimal)ojb;
            }
            ojb = dataReader["OrderStatus"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderStatus = (int)ojb;
            }
            model.CloseReason = dataReader["CloseReason"].ToString();
            ojb = dataReader["OrderAddDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderAddDate = (DateTime)ojb;
            }
            ojb = dataReader["PayDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PayDate = (DateTime)ojb;
            }
            ojb = dataReader["SendDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SendDate = (DateTime)ojb;
            }
            ojb = dataReader["FinishDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.FinishDate = (DateTime)ojb;
            }
            ojb = dataReader["UserId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserId = (int)ojb;
            }
            model.Username = dataReader["Username"].ToString();
            model.EmailAddress = dataReader["EmailAddress"].ToString();
            model.RealName = dataReader["RealName"].ToString();
            model.QQ = dataReader["QQ"].ToString();
            model.Wangwang = dataReader["Wangwang"].ToString();
            model.MSN = dataReader["MSN"].ToString();
            model.SendRegion = dataReader["SendRegion"].ToString();
            model.Address = dataReader["Address"].ToString();
            model.ZipCode = dataReader["ZipCode"].ToString();
            model.SendToUserName = dataReader["SendToUserName"].ToString();
            model.TelPhone = dataReader["TelPhone"].ToString();
            model.CellPhone = dataReader["CellPhone"].ToString();
            ojb = dataReader["ShippingModeId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ShippingModeId = (int)ojb;
            }
            model.ModeName = dataReader["ModeName"].ToString();
            ojb = dataReader["RealShippingModeId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RealShippingModeId = (int)ojb;
            }
            model.RealModeName = dataReader["RealModeName"].ToString();
            ojb = dataReader["RegionId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RegionId = (int)ojb;
            }
            ojb = dataReader["Freight"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Freight = (decimal)ojb;
            }
            ojb = dataReader["AdjustedFreight"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AdjustedFreight = (decimal)ojb;
            }
            model.DeliveryOrderNumber = dataReader["DeliveryOrderNumber"].ToString();
            ojb = dataReader["Weight"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Weight = (int)ojb;
            }
            model.ExpressCompanyName = dataReader["ExpressCompanyName"].ToString();
            model.ExpressCompanyAbb = dataReader["ExpressCompanyAbb"].ToString();
            ojb = dataReader["PaymentTypeId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PaymentTypeId = (int)ojb;
            }
            model.PaymentType = dataReader["PaymentType"].ToString();
            ojb = dataReader["PayFree"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PayFree = (decimal)ojb;
            }
            ojb = dataReader["AdjustedPayFree"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AdjustedPayFree = (decimal)ojb;
            }
            ojb = dataReader["RefundStatus"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RefundStatus = (int)ojb;
            }
            ojb = dataReader["RefundAmount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RefundAmount = (decimal)ojb;
            }
            model.RefundRemark = dataReader["RefundRemark"].ToString();
            ojb = dataReader["OrderTotal"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderTotal = (decimal)ojb;
            }
            ojb = dataReader["OrderPoint"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderPoint = (int)ojb;
            }
            ojb = dataReader["OrderCostPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderCostPrice = (decimal)ojb;
            }
            ojb = dataReader["OrderProfit"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderProfit = (decimal)ojb;
            }
            ojb = dataReader["ActualFreight"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ActualFreight = (decimal)ojb;
            }
            ojb = dataReader["OtherCost"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OtherCost = (decimal)ojb;
            }
            ojb = dataReader["OptionPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OptionPrice = (decimal)ojb;
            }
            ojb = dataReader["Amount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Amount = (decimal)ojb;
            }
            ojb = dataReader["ActivityId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ActivityId = (int)ojb;
            }
            model.ActivityName = dataReader["ActivityName"].ToString();
            ojb = dataReader["EightFree"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if (ojb.ToString().Equals("1") || ojb.ToString().Equals("true"))
                {
                    model.EightFree = true;
                }
                else
                {
                    model.EightFree = false;
                }
            }
            ojb = dataReader["PayFreeFree"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if (ojb.ToString().Equals("1") || ojb.ToString().Equals("true"))
                {
                    model.PayFreeFree = true;
                }
                else
                {
                    model.PayFreeFree = false;
                }
            }
            ojb = dataReader["OrderOptionFree"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if (ojb.ToString().Equals("1") || ojb.ToString().Equals("true"))
                {
                    model.OrderOptionFree = true;
                }
                else
                {
                    model.OrderOptionFree = false;
                }
            }
            ojb = dataReader["DiscountId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.DiscountId = (int)ojb;
            }
            model.DiscountName = dataReader["DiscountName"].ToString();
            ojb = dataReader["DiscountValue"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.DiscountValue = (decimal)ojb;
            }
            ojb = dataReader["DiscountValueType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.DiscountValueType = (int)ojb;
            }
            ojb = dataReader["DiscountAmount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.DiscountAmount = (decimal)ojb;
            }
            model.CouponName = dataReader["CouponName"].ToString();
            model.CouponCode = dataReader["CouponCode"].ToString();
            ojb = dataReader["CouponAmount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CouponAmount = (decimal)ojb;
            }
            ojb = dataReader["CouponValue"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CouponValue = (decimal)ojb;
            }
            ojb = dataReader["GroupId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.GroupId = (int)ojb;
            }
            ojb = dataReader["GroupPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.GroupPrice = (decimal)ojb;
            }
            ojb = dataReader["GroupBuyStatus"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.GroupBuyStatus = (int)ojb;
            }
            model.GatewayOrderId = dataReader["GatewayOrderId"].ToString();
            ojb = dataReader["IsPrinted"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsPrinted = (int)ojb;
                //if (ojb.ToString().Equals("1") || ojb.ToString().Equals("true"))
                //{
                //    model.IsPrinted = true;
                //}
                //else
                //{
                //    model.IsPrinted = false;
                //}
            }

            model.TaobaoOrderId = dataReader["TaobaoOrderId"].ToString();

            ojb = dataReader["TimeNumber"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TimeNumber = (int)ojb;
            }

            ojb = dataReader["ReviewedOrderDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ReviewedOrderDate = (DateTime)ojb;
            }
            ojb = dataReader["SureReceiptDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SureReceiptDate = (DateTime)ojb;
            }
            ojb = dataReader["DelOrderDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.DelOrderDate = (DateTime)ojb;
            }

            ojb = dataReader["PanicBuyingId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PanicBuyingId = (int)ojb;
            }

            ojb = dataReader["UserBalance"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserBalance = (decimal)ojb;
            }
            ojb = dataReader["iCome"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iCome = (int)ojb;
            }
            return model;
        }

        #endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="dicArray">要更新的集合(如果value是字符串,需提前加上引号)</param>
        /// <param name="rid">要更新的ID</param>
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
        public bool AddOrder(Entity.Buy_Orders md, ICollection<Entity.Buy_CartItem> CartItems, ICollection<Entity.Buy_CreditCartItem> CreditCartItems, int CouponItemID, List<EbSite.Entity.OrderOptionValue> lstOov, Entity.GroupBuy GroupMd, Entity.CountDownBuy RushMd, decimal Prepayments)
        {
            //Buy_Orders_Add(Entity.Buy_Orders model, SqlTransaction Trans);

            bool isSuccessed = true;
            MySqlConnection cn = new MySqlConnection(DB.ConnectionString());
            cn.Open();
            MySqlTransaction tran = cn.BeginTransaction();  //创建事务

            try
            {

                Buy_Orders_Add(md, tran);
                StringBuilder sbids = new StringBuilder();
                StringBuilder creditsbids = new StringBuilder();
                int iReduced = 0;// 消耗积分
                //添加定单对应的商品
                foreach (Entity.Buy_CartItem carItem in CartItems)
                {
                    Entity.Buy_OrderItem orderItem = new Buy_OrderItem(carItem, md.OrderId);

                    orderItem.OrderItemKey = EbSite.Core.SqlDateTimeInt.NewOrderNumberLong();//关联 赠品用的
                    Buy_OrderItem_Add(orderItem, tran);

                    //添加赠品
                    List<Entity.giftcartproduct> gls = carItem.Gives;
                    foreach (var giftcartproduct in gls)
                    {
                        Entity.giftorderproduct gorder = new giftorderproduct();
                        //giftorder.OrderID= 不能完成此属性 因为 在事务中 订单还没有添加成功
                        gorder.OrderNumber = md.OrderId;
                        gorder.OrderItemID = orderItem.OrderItemKey;
                        gorder.BuyProductId = giftcartproduct.BuyProductId;
                        gorder.GiftProductId = giftcartproduct.GiftProductId;
                        gorder.Quantity = giftcartproduct.Quantity * giftcartproduct.BuyCount;
                        gorder.BuyCount = giftcartproduct.BuyCount;

                        giftorderproduct_Add(gorder, tran);


                        //赠品也有减去库存量
                        EbSite.Entity.NewsContent ZengPingModel = EbSite.Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(gorder.GiftProductId);
                        if (!Equals(ZengPingModel, null))
                        {
                            ZengPingModel.Annex21 += giftcartproduct.Quantity * giftcartproduct.BuyCount;
                            ZengPingModel.Annex12 -= giftcartproduct.Quantity * giftcartproduct.BuyCount; //库量  
                            EbSite.Base.AppStartInit.NewsContentInstDefault.Update(ZengPingModel, tran);


                            //添加 赠品商品的出库日志 2013-09-30 yhl

                            Entity.productlog productlog = new productlog();

                            productlog.Content = string.Format("【 {1} 做为赠品出库{0}个】",
                                                               giftcartproduct.Quantity * giftcartproduct.BuyCount,
                                                               md.OrderId);
                            productlog.UserID = EbSite.Base.Host.Instance.UserID;
                            productlog.UserName = EbSite.Base.Host.Instance.UserName;
                            productlog.AddDate = DateTime.Now;
                            productlog.Number = giftcartproduct.Quantity;
                            productlog.ProductId = orderItem.ProductId;
                            productlog.PNumber = ZengPingModel.Annex1; //货号
                            productlog_Add(productlog, tran);
                        }
                    }

                    //yhl 2013-09-3 减去库存量;
                    EbSite.Entity.NewsContent Model = EbSite.Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(orderItem.ProductId);
                    if (!Equals(Model, null))
                    {
                        Model.Annex21 += orderItem.RealQuantity;// (orderItem.Quantity + orderItem.GiveQuantity);//总销量  
                        if (Model.Annex1 == orderItem.SKU)//说明此商品 是价格最低的那一款。
                        {
                            Model.Annex12 -= (orderItem.RealQuantity);//库量
                        }
                        EbSite.Base.AppStartInit.NewsContentInstDefault.Update(Model, tran);
                        //规格
                        NormRelationProduct_Update(orderItem.SKU, orderItem.ProductId, orderItem.RealQuantity, tran);

                        //添加商品的出库日志 2013-09-09 yhl

                        Entity.productlog productlog = new productlog();

                        productlog.Content = string.Format("【 {1} 出库{0}个】", orderItem.RealQuantity, md.OrderId);
                        productlog.UserID = EbSite.Base.Host.Instance.UserID;
                        productlog.UserName = EbSite.Base.Host.Instance.UserName;
                        productlog.AddDate = DateTime.Now;
                        productlog.Number = orderItem.RealQuantity;
                        productlog.ProductId = orderItem.ProductId;
                        productlog.PNumber = orderItem.SKU;//货号
                        productlog_Add(productlog, tran);


                        //优惠券
                        EbSite.BLL.CouponItems.Instance.Delete(CouponItemID, tran);//优惠券使用后删除

                        foreach (var optionValue in lstOov)
                        {
                            optionValue.OrderId = md.OrderId.ToString();
                            EbSite.BLL.OrderOptionValue.Instance.Add(optionValue, tran);
                        }
                    }
                    sbids.Append(carItem.id);
                    sbids.Append(",");
                }
                if (sbids.Length > 0)
                {
                    sbids.Remove(sbids.Length - 1, 1);
                    string sqldelete = string.Format("delete from {0}Buy_CartItem where id in({1})", sPre, sbids);
                    DB.ExecuteNonQuery(tran, CommandType.Text, sqldelete);
                }
                //添加对应的积分兑换商品
                foreach (Entity.Buy_CreditCartItem creditItem in CreditCartItems)
                {
                    Entity.creditproductorder creditMd = new creditproductorder();

                    creditMd.OrderID = md.OrderId;
                    creditMd.CreditProductID = creditItem.CreditProductID;

                    creditMd.UserID = EbSite.Base.Host.Instance.UserID;
                    creditMd.Quantity = creditItem.Quantity;
                    creditMd.AddTime = DateTime.Now;
                    creditMd.Credit = creditItem.Credit;

                    creditproductorder_Add(creditMd, tran);

                    iReduced = Convert.ToInt32(creditItem.Credit * creditItem.Quantity);

                    //修改 积分商品的 库存量
                    Entity.creditproduct cproductModel =
                        ModuleCore.BLL.creditproduct.Instance.GetEntity(creditItem.CreditProductID);
                    cproductModel.Stock -= creditItem.Quantity;
                    cproductModel.ExchangeNum += 1;
                    creditproduct_Update(cproductModel, tran);


                    creditsbids.Append(creditItem.id);
                    creditsbids.Append(",");
                }
                if (creditsbids.Length > 0)
                {
                    creditsbids.Remove(creditsbids.Length - 1, 1);
                    string sqldelete = string.Format("delete from {0}Buy_CreditCartItem where id in({1})", sPre, creditsbids);
                    DB.ExecuteNonQuery(tran, CommandType.Text, sqldelete);
                }
                if (iReduced > 0) //消耗积分 大于0 说明 有积分兑换
                {

                    //减去 用户积分
                    Base.EntityAPI.MembershipUserEb useModel =
                        EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(EbSite.Base.Host.Instance.UserID);

                    if (useModel.Credits >= iReduced)
                    {
                        useModel.Credits -= iReduced;
                        EbSite.BLL.User.MembershipUserEb.Instance.Update(useModel, tran);

                        //添加 积分记录
                        ModuleCore.Entity.pointdetails pointModel = new pointdetails();

                        pointModel.UserId = EbSite.Base.Host.Instance.UserID;
                        pointModel.TradeType = Convert.ToInt32(SystemEnum.MyPointType.兑换礼品);
                        pointModel.Increased = 0;
                        pointModel.Reduced = iReduced;
                        pointModel.Points = useModel.Credits;
                        pointModel.TradeDate = DateTime.Now;
                        pointModel.OrderId = md.OrderId;
                        pointdetails_Add(pointModel, tran);

                    }
                    else
                    {
                        isSuccessed = false;
                        //出错回滚
                        tran.Rollback();
                       
                    }
                   
                }
                //yhl 2013-09-21 团 抢
                if (!Equals(GroupMd, null))
                {
                    GroupBuy_Update(GroupMd, tran);
                }
                if (!Equals(RushMd, null))
                {
                    CountDownBuy_Update(RushMd, tran);
                }
                //积分 加到总积分中
                if (md.OrderPoint > 0)
                {
                    //增加 用户积分
                    Base.EntityAPI.MembershipUserEb useModel =
                        EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(EbSite.Base.Host.Instance.UserID);
                    useModel.Credits += md.OrderPoint;
                    EbSite.BLL.User.MembershipUserEb.Instance.Update(useModel, tran);


                    //添加 积分记录
                    ModuleCore.Entity.pointdetails pointModel = new pointdetails();
                    pointModel.UserId = EbSite.Base.Host.Instance.UserID;
                    pointModel.TradeType = Convert.ToInt32(SystemEnum.MyPointType.购物奖励);
                    pointModel.Increased = md.OrderPoint;
                    pointModel.Reduced = 0;
                    pointModel.Points = useModel.Credits;
                    pointModel.TradeDate = DateTime.Now;
                    pointModel.OrderId = md.OrderId;
                    pointdetails_Add(pointModel, tran);
                }

                //使用预付款
                if (Prepayments > 0)
                {
                    EbSite.Entity.PayPass payModel =
                        EbSite.BLL.PayPass.Instance.GetEntity(EbSite.Base.Host.Instance.UserID);

                    payModel.Balance -= Prepayments;

                    EbSite.BLL.PayPass.Instance.Update(payModel, tran);


                    //AccountMoneyLog_Add 预付款收支流水写日志
                    EbSite.Entity.AccountMoneyLog AccountModel = new AccountMoneyLog();
                    AccountModel.UserId = EbSite.Base.Host.Instance.UserID;
                    AccountModel.UserName = EbSite.Base.Host.Instance.UserName;
                    AccountModel.TradeDate = DateTime.Now;
                    AccountModel.TradeType = (int)SystemEnum.AccountMoneyLogTradeType.消费;
                    AccountModel.Income = 0;
                    AccountModel.Expenses = Prepayments;
                    AccountModel.Balance = payModel.Balance;
                    AccountModel.Remark = md.OrderId + " 订单消费";

                    EbSite.BLL.AccountMoneyLog.Instance.Add(AccountModel, tran);


                }

                //提交事务
                tran.Commit();
            }
            catch
            {
                isSuccessed = false;
                //出错回滚
                tran.Rollback();

                throw;
            }
            finally  //关闭联接
            {
                if (cn != null && cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return isSuccessed;
        }
        public Entity.Buy_Orders Buy_Orders_GetEntity(long OrderNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select  " + sFieldBuy_Orders + "  from {0}Buy_Orders ", sPre);
            strSql.Append(" where OrderId=?OrderId limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderId", MySqlDbType.Int64,15)};
            parameters[0].Value = OrderNumber;
            Entity.Buy_Orders model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Buy_Orders_ReaderBind(dataReader);
                }
            }
            return model;
        }
        public void UpdateOrderPayed(string OrderID)
        {

            //StringBuilder strSql = new StringBuilder();
            //strSql.AppendFormat("update {0}Buy_Orders set ", sPre);
            //strSql.Append("OrderStatus=?OrderStatus");
            //strSql.Append(" where OrderId=?OrderId ");
            //MySqlParameter[] parameters = {
            //        new MySqlParameter("?OrderStatus", MySqlDbType.Int32,4),
            //        new MySqlParameter("?OrderId", MySqlDbType.VarChar,11)
            //        };
            //parameters[0].Value = 1;
            //parameters[1].Value = OrderID;
            //DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);


            //StringBuilder strSql2 = new StringBuilder();
            //strSql2.AppendFormat("update {0}normrelationproduct set ", sPre);
            //strSql2.Append("Stocks=Stocks-1");
            //strSql2.Append(" where PNumber=?PNumber and Stocks>0");
            //MySqlParameter[] parameters2 = {
            //        new MySqlParameter("?PNumber", MySqlDbType.VarChar,11)
            //        };
            //parameters[0].Value = 1;
            //DB.ExecuteNonQuery(CommandType.Text, strSql2.ToString(), parameters2);



        }

        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="rID">自增长id</param>
        /// <param name="CloseReason">关闭原因</param>
        /// <returns></returns>
        public bool Buy_Orders_CloseOrder(int rID, string CloseReason)
        {
            bool isSuccessed = true;
            MySqlConnection cn = new MySqlConnection(DB.ConnectionString());
            cn.Open();
            MySqlTransaction tran = cn.BeginTransaction();  //创建事务

            try
            {
                Entity.Buy_Orders BuyOrders = Buy_Orders_GetEntity(rID);
                if (!Equals(BuyOrders, null))
                {
                    //过滤 哪些订单符合关闭条件 0提交订单  1审核订单 2等待付款
                    if (BuyOrders.OrderStatus < 3)
                    {
                        //订单 主表
                        BuyOrders.OrderStatus =
                            ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.回收站);
                        BuyOrders.DelOrderDate = DateTime.Now;
                        BuyOrders.CloseReason = CloseReason;
                        Buy_Orders_Update(BuyOrders, tran);
                        //订单 从表

                        List<ModuleCore.Entity.Buy_OrderItem> OrderItemList = Buy_OrderItem_GetListArray(0,
                                                                                                         "OrderId=" +
                                                                                                         BuyOrders
                                                                                                             .OrderId,
                                                                                                         "");
                        if (!Equals(OrderItemList, null))
                        {
                            #region 订单从表

                            // SKU JY20740-1 货号
                            foreach (var buyOrderItem in OrderItemList)
                            {
                                //Annex22 1:开启规格 [Annex12]库存量
                                EbSite.Entity.NewsContent ProductMd =
                                    EbSite.Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(buyOrderItem.ProductId);
                                if (!Equals(ProductMd, null))
                                {
                                    if (ProductMd.Annex22 == 1) //开启规格
                                    {
                                        if (ProductMd.Annex1 == buyOrderItem.SKU) //正好是 默认的那一款 货号
                                        {

                                            ProductMd.Annex12 += buyOrderItem.Quantity; //库存
                                            ProductMd.Annex21 -= buyOrderItem.Quantity; //销量
                                            EbSite.Base.AppStartInit.NewsContentInstDefault.Update(ProductMd, tran);
                                        }
                                        //规格
                                        NormRelationProduct_Update(buyOrderItem.SKU, buyOrderItem.ProductId,
                                                                   -buyOrderItem.Quantity, tran);

                                    }
                                    else
                                    {
                                        ProductMd.Annex12 += buyOrderItem.Quantity;
                                        ProductMd.Annex21 -= buyOrderItem.Quantity; //销量
                                        EbSite.Base.AppStartInit.NewsContentInstDefault.Update(ProductMd, tran);
                                    }
                                    Entity.productlog productlog = new productlog();
                                    productlog.Content = string.Format("【 {1} 关闭订单，退库{0}个】", buyOrderItem.Quantity,
                                                                       BuyOrders.OrderId);
                                    productlog.UserID = EbSite.Base.Host.Instance.UserID;
                                    productlog.UserName = EbSite.Base.Host.Instance.UserName;
                                    productlog.AddDate = DateTime.Now;
                                    productlog.Number = buyOrderItem.Quantity;
                                    productlog.ProductId = buyOrderItem.ProductId;
                                    productlog.PNumber = buyOrderItem.SKU;
                                    productlog_Add(productlog, tran);

                                }
                            }

                            #endregion

                            #region  //赠品

                            List<ModuleCore.Entity.giftorderproduct> giftOrderList =
                                giftorderproduct_GetListArray("OrderNumber=" + BuyOrders.OrderId);
                            if (!Equals(giftOrderList, null))
                            {
                                foreach (var giftorderproduct in giftOrderList)
                                {
                                    EbSite.Entity.NewsContent GiftProductMd = EbSite.Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(giftorderproduct.GiftProductId);
                                    if (!Equals(GiftProductMd, null))
                                    {
                                        if (GiftProductMd.Annex22 == 1) //开启规格
                                        {

                                        }
                                        else
                                        {
                                            GiftProductMd.Annex12 +=
                                                EbSite.Core.Utils.StrToInt(giftorderproduct.Quantity.ToString(), 0);
                                            GiftProductMd.Annex21 -=
                                                EbSite.Core.Utils.StrToInt(giftorderproduct.Quantity.ToString(), 0);
                                            //销量
                                            EbSite.Base.AppStartInit.NewsContentInstDefault.Update(GiftProductMd, tran);
                                        }
                                        Entity.productlog productlog = new productlog();
                                        productlog.Content = string.Format("【 {1} 关闭订单，退库{0}个】",
                                                                           giftorderproduct.Quantity, BuyOrders.OrderId);
                                        productlog.UserID = EbSite.Base.Host.Instance.UserID;
                                        productlog.UserName = EbSite.Base.Host.Instance.UserName;
                                        productlog.AddDate = DateTime.Now;
                                        productlog.Number = giftorderproduct.Quantity;
                                        productlog.ProductId = giftorderproduct.GiftProductId;
                                        productlog.PNumber = GiftProductMd.Annex1; //货号
                                        productlog_Add(productlog, tran);

                                    }
                                }
                            }

                            #endregion

                            #region  总积分

                            //总积分 OrderPoint
                            if (BuyOrders.OrderPoint > 0)
                            {
                                //减去 用户积分
                                Base.EntityAPI.MembershipUserEb useModel =
                                    EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(EbSite.Base.Host.Instance.UserID);
                                useModel.Credits -= BuyOrders.OrderPoint;
                                EbSite.BLL.User.MembershipUserEb.Instance.Update(useModel, tran);

                                //添加 积分记录
                                ModuleCore.Entity.pointdetails pointModel = new pointdetails();
                                pointModel.UserId = EbSite.Base.Host.Instance.UserID;
                                pointModel.TradeType = Convert.ToInt32(SystemEnum.MyPointType.关闭订单扣除奖励积分);
                                pointModel.Increased = 0;
                                pointModel.Reduced = BuyOrders.OrderPoint;
                                pointModel.Points = useModel.Credits;
                                pointModel.TradeDate = DateTime.Now;
                                pointModel.OrderId = BuyOrders.OrderId;
                                pointdetails_Add(pointModel, tran);
                            }

                            #endregion

                            #region 积分商品

                            List<Entity.creditproductorder> scoreList = creditproductorder_GetListArray(0,
                                                                                                        "OrderID=" +
                                                                                                        BuyOrders
                                                                                                            .OrderId, "");
                            if (!Equals(scoreList, null))
                            {
                                foreach (var creditproductorder in scoreList)
                                {
                                    Entity.creditproduct creditMd =
                                        creditproduct_GetEntity(
                                            EbSite.Core.Utils.StrToInt(creditproductorder.CreditProductID.ToString()));
                                    if (!Equals(creditMd, null))
                                    {
                                        creditMd.Stock +=
                                            EbSite.Core.Utils.StrToInt(creditproductorder.Quantity.ToString(), 0);

                                        creditproduct_Update(creditMd, tran);

                                        int backScore =
                                            EbSite.Core.Utils.StrToInt(creditproductorder.Credit.ToString(), 0) *
                                            EbSite.Core.Utils.StrToInt(creditproductorder.Quantity.ToString());

                                        //返还 用户积分
                                        Base.EntityAPI.MembershipUserEb useModel =
                                            EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(
                                                EbSite.Base.Host.Instance.UserID);
                                        useModel.Credits += backScore;
                                        EbSite.BLL.User.MembershipUserEb.Instance.Update(useModel, tran);

                                        //添加 积分记录
                                        ModuleCore.Entity.pointdetails pointModel = new pointdetails();
                                        pointModel.UserId = EbSite.Base.Host.Instance.UserID;
                                        pointModel.TradeType = Convert.ToInt32(SystemEnum.MyPointType.关闭订单返还积分);
                                        pointModel.Increased = backScore;
                                        pointModel.Reduced = 0;
                                        pointModel.Points = useModel.Credits;
                                        pointModel.TradeDate = DateTime.Now;
                                        pointModel.OrderId = BuyOrders.OrderId;
                                        pointdetails_Add(pointModel, tran);
                                    }

                                }
                            }


                            #endregion

                            #region 团购

                            if (BuyOrders.GroupId > 0)
                            {
                                Entity.GroupBuy groupBuy =
                                    GroupBuy_GetEntity(EbSite.Core.Utils.StrToInt(BuyOrders.GroupId.ToString()));
                                if (!Equals(groupBuy, null))
                                {
                                    if (OrderItemList.Count > 0)
                                    {
                                        groupBuy.Buyed -= 1; //已经购买的人数
                                        groupBuy.BuySumOrder -= OrderItemList[0].Quantity; // 购买产品总数量
                                        GroupBuy_Update(groupBuy, tran);
                                    }
                                }
                            }

                            #endregion

                            #region 抢购

                            if (BuyOrders.PanicBuyingId > 0)
                            {
                                Entity.CountDownBuy countDownMd =
                                    CountDownBuy_GetEntity(EbSite.Core.Utils.StrToInt(BuyOrders.PanicBuyingId.ToString()));
                                if (OrderItemList.Count > 0)
                                {
                                    countDownMd.Buyed -= 1; //已经购买的人数
                                    CountDownBuy_Update(countDownMd, tran);
                                }
                            }

                            #endregion


                        }


                    }



                    //提交事务
                    tran.Commit();
                }
            }
            catch
            {
                isSuccessed = false;
                //出错回滚
                tran.Rollback();

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
        public DataTable Buy_Orders_GetOrderCount(string dateType, int dateVal, string fieldType, out int sumCount, out int maxCount)
        {
            sumCount = 0;
            maxCount = 0;

            MySqlParameter[] parameters = { 
                new MySqlParameter("?p_datetype",MySqlDbType.VarChar,50),
                new MySqlParameter("?p_yearormoth",MySqlDbType.Int32),
                new MySqlParameter("?p_field",MySqlDbType.VarChar,50),
                new MySqlParameter("?p_sumcount",MySqlDbType.Int32),
                new MySqlParameter("?p_maxcount",MySqlDbType.Int32)};
            parameters[0].Value = dateType;
            parameters[1].Value = dateVal;
            parameters[2].Value = fieldType;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;

            DataSet ds = DB.ExecuteDataset(CommandType.StoredProcedure, "ebshop_OrderCount", parameters);

            if (ds != null && ds.Tables.Count > 0)
            {
                if (parameters[3].Value != null && !string.IsNullOrEmpty(parameters[3].Value.ToString()))
                {
                    sumCount = int.Parse(parameters[3].Value.ToString());
                }
                if (parameters[4].Value != null && !string.IsNullOrEmpty(parameters[4].Value.ToString()))
                {
                    maxCount = int.Parse(parameters[4].Value.ToString());
                }
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取总金额
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="strTotalProfit">总利润</param>
        /// <returns></returns>
        public string Buy_Orders_GetTotalOrderPrice(string strWhere, out string strTotalProfit)
        {
            strTotalProfit = "0.00";
            string strSql = "select sum(OrderTotal) as 'totalprice',sum(OrderProfit) as 'profitprice' from ebshop_buy_orders";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql = strSql + " where " + strWhere;
            }
            using (IDataReader dr = DB.ExecuteReader(CommandType.Text, strSql))
            {
                if (dr.Read())
                {
                    strTotalProfit = dr["profitprice"].ToString();
                    return dr["totalprice"].ToString();
                }
                else
                {
                    return "0.00";
                }
            }
        }

        /// <summary>
        /// 获取订单转化率的信息
        /// </summary>
        /// <param name="p_OrderTotalPrice">订单总额</param>
        /// <param name="p_TotalMemberQuantity">总会员数</param>
        /// <param name="p_TotalViewTimes">总访问次数</param>
        /// <param name="p_TotalOrderQuantity">总订单数量</param>
        /// <param name="p_HaveOrderMemberQuantity">下过订单的会员数量</param>
        public void Buy_Orders_GetOrderConverRate(out decimal p_OrderTotalPrice, out int p_TotalMemberQuantity, out int p_TotalViewTimes, out int p_TotalOrderQuantity, out int p_HaveOrderMemberQuantity)
        {
            p_OrderTotalPrice = 0;
            p_TotalMemberQuantity = 0;
            p_TotalViewTimes = 0;
            p_TotalOrderQuantity = 0;
            p_HaveOrderMemberQuantity = 0;

            MySqlParameter[] parameters = { 
                new MySqlParameter("?p_OrderTotalPrice",MySqlDbType.Decimal),
                new MySqlParameter("?p_TotalMemberQuantity",MySqlDbType.Int32),
                new MySqlParameter("?p_TotalOrderQuantity",MySqlDbType.Int32),
                new MySqlParameter("?p_HaveOrderMemberQuantity",MySqlDbType.Int32)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Direction = ParameterDirection.Output;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Direction = ParameterDirection.Output;

            DataSet ds = DB.ExecuteDataset(CommandType.StoredProcedure, "ebshop_GetOrderConverRate", parameters);
            p_OrderTotalPrice = decimal.Parse(parameters[0].Value.ToString());
            p_TotalMemberQuantity = EbSite.Core.Utils.ObjectToInt(parameters[1].Value);
            p_TotalOrderQuantity = EbSite.Core.Utils.ObjectToInt(parameters[2].Value);
            p_HaveOrderMemberQuantity = EbSite.Core.Utils.ObjectToInt(parameters[3].Value);

        }

        /// <summary>
        /// 获取订单访问购买率
        /// </summary>
        /// <returns></returns>
        /// <param name="iTop">获取条数</param>
        public DataTable Buy_Orders_GetOrderViewRate(int iTop)
        {
            string strSql = "select productname,buytimes,viewtimes,ROUND((buytimes/viewtimes)*100,2) as buyrate from(select ProductName,count(ProductId) as 'buytimes',(select hits from eb_newscontent where id=ProductId) as 'viewtimes' from ebshop_buy_orderitem GROUP BY ProductId) as dd ORDER BY buyrate desc";
            if (iTop > 0)
            {
                strSql += " limit " + iTop;
            }

            DataSet ds = DB.ExecuteDataset(CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        #endregion 订单统计

        #region 更新要定时更新的订单

        /// <summary>
        /// 更新在超过规定的天数内需要关闭的订单
        /// </summary>
        /// <param name="closeDays">规定的天数</param>
        /// <returns></returns>
        public bool Buy_Orders_UpdateAutoCloseOrder(int closeDays)
        {
            string strSql = string.Format("update {0}Buy_Orders set OrderStatus=6,CloseReason='{1}' where OrderStatus<2 and DATEDIFF(NOW(),OrderAddDate)>{2}",sPre,"超时订单,系统自动关闭",closeDays);
            return DB.ExecuteNonQuery(CommandType.Text, strSql)>0?true:false;
        }
        /// <summary>
        /// 更新在超过规定的天数内自动完成的订单
        /// </summary>
        /// <param name="finishDays">规定的天数</param>
        /// <returns></returns>
        public bool Buy_Orders_UpdateAutoFinishOrder(int finishDays)
        {
            string strSql = string.Format("update {0}Buy_Orders set OrderStatus=5,finishdate=Now() where OrderStatus=3 and DATEDIFF(NOW(),SendDate)>{1}", sPre, finishDays);
            return DB.ExecuteNonQuery(CommandType.Text, strSql) > 0 ? true : false;
        }

        #endregion 更新要定时更新的订单
    }
}

