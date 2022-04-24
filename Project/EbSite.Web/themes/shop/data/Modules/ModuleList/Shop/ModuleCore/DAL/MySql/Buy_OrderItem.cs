using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;
namespace EbSite.Modules.Shop.ModuleCore.DAL.MySql
{
    /// <summary>
    /// 数据访问类Shop。
    /// </summary>
    public partial class Shop
    {
        private string sFieldBuy_OrderItem = "id,OrderId,WholesaleDiscountId,WholesaleDiscountName,IsGift,SKUContent,ThumbnailsUrl,SKU,Quantity,MemberPrice,ProductName,ClassName,MarketPrice,CategoryId,ProductId,BuyUserID,IsBuy,AddDateTime,Weight,NormIDs,CostPrice,Points,GiveQuantity,AdjustedPrice,PurchaseGiftId,PurchaseGiftName,ExpressCompanyID,OrderItemKey,SubmitQuantity,ServiceType,ApplyProof,QuestionDesc,returndate,ItemStatus,Reason";
        
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int Buy_OrderItem_GetMaxId()
        {
            return DB.GetMaxID("id", string.Format("{0}Buy_OrderItem", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Buy_OrderItem_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}Buy_OrderItem", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DB.Exists(strSql.ToString(), parameters);
        }

        public int Buy_OrderItem_Add(Entity.Buy_OrderItem model)
        {
            return Buy_OrderItem_Add(model, null);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Buy_OrderItem_Add(Entity.Buy_OrderItem model, MySqlTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}Buy_OrderItem(", sPre);
            strSql.Append("OrderId,WholesaleDiscountId,WholesaleDiscountName,IsGift,SKUContent,ThumbnailsUrl,SKU,Quantity,MemberPrice,ProductName,ClassName,MarketPrice,CategoryId,ProductId,BuyUserID,IsBuy,AddDateTime,Weight,NormIDs,CostPrice,Points,GiveQuantity,AdjustedPrice,PurchaseGiftId,PurchaseGiftName,ExpressCompanyID,OrderItemKey,ItemStatus)");
            strSql.Append(" values (");
            strSql.Append("?OrderId,?WholesaleDiscountId,?WholesaleDiscountName,?IsGift,?SKUContent,?ThumbnailsUrl,?SKU,?Quantity,?MemberPrice,?ProductName,?ClassName,?MarketPrice,?CategoryId,?ProductId,?BuyUserID,?IsBuy,?AddDateTime,?Weight,?NormIDs,?CostPrice,?Points,?GiveQuantity,?AdjustedPrice,?PurchaseGiftId,?PurchaseGiftName,?ExpressCompanyID,?OrderItemKey,?ItemStatus)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?OrderId", MySqlDbType.Int64,15),
					new MySqlParameter("?WholesaleDiscountId", MySqlDbType.Int32,4),
					new MySqlParameter("?WholesaleDiscountName", MySqlDbType.VarChar,50),
					new MySqlParameter("?IsGift", MySqlDbType.Bit,1),
					new MySqlParameter("?SKUContent", MySqlDbType.VarChar,50),
					new MySqlParameter("?ThumbnailsUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,4),
					new MySqlParameter("?MemberPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int32,4),
					new MySqlParameter("?BuyUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?IsBuy", MySqlDbType.Bit,1),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
                    new MySqlParameter("?Weight", MySqlDbType.Decimal,9),
                    new MySqlParameter("?NormIDs", MySqlDbType.VarChar,50),
                    new MySqlParameter("?CostPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?Points", MySqlDbType.Int32,4),
                    new MySqlParameter("?GiveQuantity", MySqlDbType.Int32,4),
                    new MySqlParameter("?AdjustedPrice", MySqlDbType.Decimal,4),
                    new MySqlParameter("?PurchaseGiftId", MySqlDbType.Int32,4),
                    new MySqlParameter("?PurchaseGiftName", MySqlDbType.VarChar,100),
                    new MySqlParameter("?ExpressCompanyID", MySqlDbType.Int32,4),
                    new MySqlParameter("?OrderItemKey",MySqlDbType.Int64,12),
                    new MySqlParameter("?ItemStatus", MySqlDbType.Int32,4)
                                        };

            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.WholesaleDiscountId;
            parameters[2].Value = model.WholesaleDiscountName;
            parameters[3].Value = model.IsGift;
            parameters[4].Value = model.SKUContent;
            parameters[5].Value = model.ThumbnailsUrl;
            parameters[6].Value = model.SKU;
            parameters[7].Value = model.Quantity;
            parameters[8].Value = model.MemberPrice;
            parameters[9].Value = model.ProductName;
            parameters[10].Value = model.ClassName;
            parameters[11].Value = model.MarketPrice;
            parameters[12].Value = model.CategoryId;
            parameters[13].Value = model.ProductId;
            parameters[14].Value = model.BuyUserID;
            parameters[15].Value = model.IsBuy;
            parameters[16].Value = model.AddDateTime;
            parameters[17].Value = model.Weight;
            parameters[18].Value = model.NormIDs;
            parameters[19].Value = model.CostPrice;
            parameters[20].Value = model.Points;
            parameters[21].Value = model.GiveQuantity;
            parameters[22].Value = model.AdjustedPrice;
            parameters[23].Value = model.PurchaseGiftId;
            parameters[24].Value = model.PurchaseGiftName;
            parameters[25].Value = model.ExpressCompanyID;
            parameters[26].Value = model.OrderItemKey;
            parameters[27].Value =0;
            //object obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            //if (obj == null)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return Convert.ToInt32(obj);
            //}

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Buy_OrderItem_Update(Entity.Buy_OrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}Buy_OrderItem set ", sPre);
            strSql.Append("OrderId=?OrderId,");
            strSql.Append("WholesaleDiscountId=?WholesaleDiscountId,");
            strSql.Append("WholesaleDiscountName=?WholesaleDiscountName,");
            strSql.Append("IsGift=?IsGift,");
            strSql.Append("SKUContent=?SKUContent,");
            strSql.Append("ThumbnailsUrl=?ThumbnailsUrl,");
            strSql.Append("SKU=?SKU,");
            strSql.Append("Quantity=?Quantity,");
            strSql.Append("MemberPrice=?MemberPrice,");
            strSql.Append("ProductName=?ProductName,");
            strSql.Append("ClassName=?ClassName,");
            strSql.Append("MarketPrice=?MarketPrice,");
            strSql.Append("CategoryId=?CategoryId,");
            strSql.Append("ProductId=?ProductId,");
            strSql.Append("BuyUserID=?BuyUserID,");
            strSql.Append("IsBuy=?IsBuy,");
            strSql.Append("Weight=?Weight,");
            strSql.Append("NormIDs=?NormIDs,");
            strSql.Append("AddDateTime=?AddDateTime,");
            strSql.Append("CostPrice=?CostPrice,");
            strSql.Append("Points=?Points,");
            strSql.Append("GiveQuantity=?GiveQuantity,");

            strSql.Append("AdjustedPrice=?AdjustedPrice,");
            strSql.Append("PurchaseGiftId=?PurchaseGiftId,");
            strSql.Append("PurchaseGiftName=?PurchaseGiftName,");
            strSql.Append("ExpressCompanyID=?ExpressCompanyID,");
            strSql.Append("OrderItemKey=?OrderItemKey");

            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderId", MySqlDbType.Int64,15),
					new MySqlParameter("?WholesaleDiscountId", MySqlDbType.Int32,4),
					new MySqlParameter("?WholesaleDiscountName", MySqlDbType.VarChar,50),
					new MySqlParameter("?IsGift", MySqlDbType.Bit,1),
					new MySqlParameter("?SKUContent", MySqlDbType.VarChar,50),
					new MySqlParameter("?ThumbnailsUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,4),
					new MySqlParameter("?MemberPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int32,4),
					new MySqlParameter("?BuyUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?IsBuy", MySqlDbType.Bit,1),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
                    new MySqlParameter("?Weight", MySqlDbType.Decimal,9),
                    new MySqlParameter("?NormIDs", MySqlDbType.VarChar,50),
                    new MySqlParameter("?CostPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?Points", MySqlDbType.Int32,4),
                    new MySqlParameter("?GiveQuantity", MySqlDbType.Int32,4),
                     new MySqlParameter("?AdjustedPrice", MySqlDbType.Decimal,4),
                    new MySqlParameter("?PurchaseGiftId", MySqlDbType.Int32,4),
                    new MySqlParameter("?PurchaseGiftName", MySqlDbType.VarChar,100),
                    new MySqlParameter("?ExpressCompanyID", MySqlDbType.Int32,4),
                    new MySqlParameter("?OrderItemKey", MySqlDbType.Int64, 12)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.OrderId;
            parameters[2].Value = model.WholesaleDiscountId;
            parameters[3].Value = model.WholesaleDiscountName;
            parameters[4].Value = model.IsGift;
            parameters[5].Value = model.SKUContent;
            parameters[6].Value = model.ThumbnailsUrl;
            parameters[7].Value = model.SKU;
            parameters[8].Value = model.Quantity;
            parameters[9].Value = model.MemberPrice;
            parameters[10].Value = model.ProductName;
            parameters[11].Value = model.ClassName;
            parameters[12].Value = model.MarketPrice;
            parameters[13].Value = model.CategoryId;
            parameters[14].Value = model.ProductId;
            parameters[15].Value = model.BuyUserID;
            parameters[16].Value = model.IsBuy;
            parameters[17].Value = model.AddDateTime;
            parameters[18].Value = model.Weight;
            parameters[19].Value = model.NormIDs;
            parameters[20].Value = model.CostPrice;
            parameters[21].Value = model.Points;
            parameters[22].Value = model.GiveQuantity;

            parameters[23].Value = model.AdjustedPrice;
            parameters[24].Value = model.PurchaseGiftId;
            parameters[25].Value = model.PurchaseGiftName;
            parameters[26].Value = model.ExpressCompanyID;
            parameters[27].Value = model.OrderItemKey;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Buy_OrderItem_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Buy_OrderItem ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Buy_OrderItem Buy_OrderItem_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldBuy_OrderItem + "  from {0}Buy_OrderItem ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.Buy_OrderItem model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Buy_OrderItem_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Buy_OrderItem_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}Buy_OrderItem ", sPre);
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
        public DataSet Buy_OrderItem_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldBuy_OrderItem);
            strSql.AppendFormat(" FROM {0}Buy_OrderItem ", sPre);
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
        public List<Entity.Buy_OrderItem> Buy_OrderItem_GetListArray(string strWhere)
        {
            return Buy_OrderItem_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Buy_OrderItem> Buy_OrderItem_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldBuy_OrderItem);
            strSql.AppendFormat(" FROM {0}Buy_OrderItem ", sPre);
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
            List<Entity.Buy_OrderItem> list = new List<Entity.Buy_OrderItem>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Buy_OrderItem_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Buy_OrderItem> Buy_OrderItem_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {

            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                //sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = Buy_OrderItem_GetCount(sbSql.ToString());
            List<Entity.Buy_OrderItem> list = new List<Entity.Buy_OrderItem>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "Buy_OrderItem", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Buy_OrderItem_ReaderBind(dataReader));
                }
            }
            return list;




        }

      
        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Buy_OrderItem Buy_OrderItem_ReaderBind(IDataReader dataReader)
        {
            Entity.Buy_OrderItem model = new Entity.Buy_OrderItem();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["OrderId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderId = (long)ojb;
            }
           
            ojb = dataReader["WholesaleDiscountId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.WholesaleDiscountId = (int)ojb;
            }
            model.WholesaleDiscountName = dataReader["WholesaleDiscountName"].ToString();
            ojb = dataReader["IsGift"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if (ojb.ToString().Equals("1") || ojb.ToString().Equals("true"))
                {
                    model.IsGift = true;
                }
                else
                {
                    model.IsGift = false;
                }
            }
            model.SKUContent = dataReader["SKUContent"].ToString();
            model.ThumbnailsUrl = dataReader["ThumbnailsUrl"].ToString();
            model.SKU = dataReader["SKU"].ToString();
            ojb = dataReader["Quantity"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Quantity = (int)ojb;
            }
            ojb = dataReader["MemberPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MemberPrice = (decimal)ojb;
            }
            ojb = dataReader["Weight"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Weight = (decimal)ojb;
            }
            model.NormIDs = dataReader["NormIDs"].ToString();
            model.ProductName = dataReader["ProductName"].ToString();
            model.ClassName = dataReader["ClassName"].ToString();
            ojb = dataReader["MarketPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MarketPrice = (decimal)ojb;
            }
            ojb = dataReader["CategoryId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CategoryId = (int)ojb;
            }
            ojb = dataReader["ProductId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProductId = (int)ojb;
            }
            ojb = dataReader["BuyUserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.BuyUserID = (int)ojb;
            }
            ojb = dataReader["IsBuy"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if (ojb.ToString().Equals("1") || ojb.ToString().Equals("true"))
                {
                    model.IsBuy = true;
                }
                else
                {
                    model.IsBuy = false;
                }
            }
            ojb = dataReader["AddDateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDateTime = (DateTime)ojb;
            }

            ojb = dataReader["CostPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CostPrice = (decimal)ojb;
            }
            ojb = dataReader["Points"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Points = (int)ojb;
            }
            ojb = dataReader["GiveQuantity"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.GiveQuantity = (int)ojb;
            }

            ojb = dataReader["AdjustedPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AdjustedPrice = (decimal)ojb;
            }
            ojb = dataReader["PurchaseGiftId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PurchaseGiftId = (int)ojb;
            }
            ojb = dataReader["ExpressCompanyID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ExpressCompanyID = (int)ojb;
            }
            ojb = dataReader["OrderItemKey"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderItemKey = (long)ojb;
            }
         
            model.PurchaseGiftName = dataReader["PurchaseGiftName"].ToString();
            ojb = dataReader["ItemStatus"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ItemStatus = (int)ojb;
            }
            ojb = dataReader["SubmitQuantity"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SubmitQuantity = (int)ojb;
            }
            ojb = dataReader["ServiceType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ServiceType = (int)ojb;
            }
            ojb = dataReader["ApplyProof"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ApplyProof = (int)ojb;
            }
            ojb = dataReader["returndate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ReturnDate = (DateTime)ojb;
            }
            model.QuestionDesc = dataReader["QuestionDesc"].ToString();
            model.Reason = dataReader["Reason"].ToString();
            return model;
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Buy_OrderItem Buy_OrderItem_ReaderBind2(IDataReader dataReader)
        {
           // b.OrderId,b.id, b.ProductId,b .ProductName,b.ReturnDate,b.ItemStatus 
            //  id,OrderId,sku,ProductId,ProductName,ServiceType,SubmitQuantity,ReturnDate,ItemStatus
            Entity.Buy_OrderItem model = new Entity.Buy_OrderItem();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["OrderId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderId = (long)ojb;
            }
            ojb = dataReader["SubmitQuantity"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SubmitQuantity = (int)ojb;
            }
            ojb = dataReader["ServiceType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ServiceType = (int)ojb;
            }
            model.SKU = dataReader["SKU"].ToString();
            model.ProductName = dataReader["ProductName"].ToString();
            ojb = dataReader["ProductId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProductId = (int)ojb;
            }

            ojb = dataReader["ItemStatus"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ItemStatus = (int)ojb;
            }
            ojb = dataReader["returndate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ReturnDate = (DateTime)ojb;
            }



            return model;
        }
        #endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="dicData">要更新的集合</param>
        /// <param name="rid">ID</param>
        public bool Buy_OrderItem_UpdateByDic(Dictionary<string, object> dicArray, int id)
        {
            if (dicArray != null && dicArray.Count > 0)
            {
                StringBuilder tmpSql = new StringBuilder();
                foreach (KeyValuePair<string, object> dic in dicArray)
                {
                    tmpSql.AppendFormat("{0}={1},", dic.Key, dic.Value);
                }
                if (tmpSql.Length > 0 && id > 0)
                {
                    string strSql = string.Format("update {0}Buy_OrderItem set {1} where id={2}", sPre, tmpSql.ToString().TrimEnd(','), id);
                    if (DB.ExecuteNonQuery(strSql) > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 获取指定用户的退换货列表
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        public DataTable Buy_OrderItem_GetTHOrderItemList(int uid)
        {
            string strSql = string.Format("select b.OrderId,b.id,b.ProductId,b.ProductName,b.ReturnDate,b.ItemStatus from ebshop_buy_orders a LEFT JOIN ebshop_buy_orderitem b on a.OrderId=b.OrderId where a.UserId={0} and b.ItemStatus>0", uid);
            DataSet ds=DB.ExecuteDataset(CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取 退换货列表
        /// </summary>
        /// <returns></returns>
        public DataTable Buy_OrderItem_GetTHOrderItemList()
        {
            string strSql ="select id,OrderId,sku,ProductId,ProductName,ServiceType,SubmitQuantity,ReturnDate,ItemStatus from ebshop_buy_orderitem where ItemStatus>0";
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

        /// <summary>
        /// 退货 分页数据
        /// </summary>
        public List<Entity.Buy_OrderItem> Buy_OrderItem_GetTHOrderItem_GetListPages(int PageIndex, int PageSize,  out int RecordCount,string orderid)
        {
            string strWhere = "ItemStatus>0";
            if (!string.IsNullOrEmpty(orderid.Trim()))
            {
                strWhere = string.Concat(strWhere, " and  OrderId=",orderid);
            }
            string  sbSql="select id,OrderId,sku,ProductId,ProductName,ServiceType,SubmitQuantity,ReturnDate,ItemStatus from ebshop_buy_orderitem  ";

            sbSql = string.Concat(sbSql," where ", strWhere);
            RecordCount = Buy_OrderItem_GetCount(strWhere);
            List<Entity.Buy_OrderItem> list = new List<Entity.Buy_OrderItem>();

            if (PageIndex > 0)
            {
                PageIndex--;
            } 
            int numStart = PageIndex * PageSize;
            sbSql=string.Concat(sbSql," limit ", numStart, ",", PageSize, "");
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, sbSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Buy_OrderItem_ReaderBind2(dataReader));
                }
            }
            return list; 
        }


        /// <summary>
        /// 获取指定用户的退换货列表 分页数据 
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        public List<Entity.Buy_OrderItem> Buy_OrderItem_GetTHOrderItem_GetListPages(int uid,int PageIndex, int PageSize,  out int RecordCount) 
        {
            string sbSql = string.Format("select b.id,b.OrderId,b.sku,b.ProductId,b.ProductName,b.ServiceType,b.SubmitQuantity,b.ReturnDate,b.ItemStatus from ebshop_buy_orders a LEFT JOIN ebshop_buy_orderitem b on a.OrderId=b.OrderId where a.UserId={0} and b.ItemStatus>0", uid);
            string isbSql = string.Format("select count(*) from ebshop_buy_orders a LEFT JOIN ebshop_buy_orderitem b on a.OrderId=b.OrderId where a.UserId={0} and b.ItemStatus>0", uid);

            int iCount = 0;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, isbSql))
            {
                while (dataReader.Read())
                {
                    iCount = int.Parse(dataReader[0].ToString());
                }
            }

            RecordCount = iCount;
           
            List<Entity.Buy_OrderItem> list = new List<Entity.Buy_OrderItem>();

            if (PageIndex > 0)
            {
                PageIndex--;
            }
            int numStart = PageIndex * PageSize;
            sbSql = string.Concat(sbSql," limit ", numStart, ",", PageSize, "");
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, sbSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Buy_OrderItem_ReaderBind2(dataReader));
                }
            }
            return list; 
            
            
          
        }

        /// <summary>
        /// 获取商品销售排行
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="itop">前几条</param>
        /// <returns></returns>
        public DataTable Buy_OrderItem_GetSaleTop(string strWhere,int itop)
        {
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = "where " + strWhere;
            }
            string strSql = string.Format("select ProductName, count(ProductId) as 'productcount',SUM(MemberPrice) as 'totalprice',SUM(MemberPrice-CostPrice) as 'totalprofit' from ebshop_buy_orderitem {0} GROUP BY ProductId ORDER BY count(productid) desc", strWhere);
            if (itop > 0)
            { 
                strSql=strSql+" limit "+itop;
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


        /// <summary>
        /// 修改订单商品价格
        /// </summary>
        /// <param name="dicArray">要修改的订单商品字段集合</param>
        /// <param name="dicArrayOrder">要修改的订单字段集合</param>
        /// <param name="tid">订单商品ID</param>
        /// <param name="rid">订单ID</param>
        /// <returns></returns>
        public bool UpdateByDic_OrderItems(Dictionary<string, object> dicArray, Dictionary<string, object> dicArrayOrder, int tid, int rid)
        {
            if (dicArray != null && dicArray.Count > 0 && dicArrayOrder != null && dicArrayOrder.Count > 0)
            {
                StringBuilder tmpSql = new StringBuilder();
                foreach (KeyValuePair<string, object> dic in dicArray)
                {
                    tmpSql.AppendFormat("{0}={1},", dic.Key, dic.Value);
                }
                StringBuilder tmpSqlOrder = new StringBuilder();
                foreach (KeyValuePair<string, object> dicex in dicArrayOrder)
                {
                    tmpSqlOrder.AppendFormat("{0}={1},", dicex.Key, dicex.Value);
                }
                if (tmpSql.Length > 0 && tid > 0 && tmpSqlOrder.Length > 0 && rid > 0)
                {
                    string strSql = string.Format("update {0}Buy_OrderItem set {1} where id={2};", sPre, tmpSql.ToString().TrimEnd(','), tid);
                    string strSql2 = string.Format("update {0}Buy_Orders set {1} where id={2};", sPre, tmpSqlOrder.ToString().TrimEnd(','), rid);
                    if (DB.ExecuteNonQuery(strSql + strSql2) > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion 自定义方法
    }
}

