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
        private string sFieldBuy_OrderItem = "id,OrderId,WholesaleDiscountId,WholesaleDiscountName,IsGift,SKUContent,ThumbnailsUrl,SKU,Quantity,MemberPrice,ProductName,ClassName,MarketPrice,CategoryId,ProductId,BuyUserID,IsBuy,AddDateTime,Weight,NormIDs";
        
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
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DB.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Buy_OrderItem_Add(Entity.Buy_OrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}Buy_OrderItem(", sPre);
            strSql.Append("OrderId,WholesaleDiscountId,WholesaleDiscountName,IsGift,SKUContent,ThumbnailsUrl,SKU,Quantity,MemberPrice,ProductName,ClassName,MarketPrice,CategoryId,ProductId,BuyUserID,IsBuy,AddDateTime,Weight,NormIDs)");
            strSql.Append(" values (");
            strSql.Append("@OrderId,@WholesaleDiscountId,@WholesaleDiscountName,@IsGift,@SKUContent,@ThumbnailsUrl,@SKU,@Quantity,@MemberPrice,@ProductName,@ClassName,@MarketPrice,@CategoryId,@ProductId,@BuyUserID,@IsBuy,@AddDateTime,@Weight,@NormIDs)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderId", SqlDbType.NVarChar,20),
					new SqlParameter("@WholesaleDiscountId", SqlDbType.Int,4),
					new SqlParameter("@WholesaleDiscountName", SqlDbType.VarChar,50),
					new SqlParameter("@IsGift", SqlDbType.Bit,1),
					new SqlParameter("@SKUContent", SqlDbType.VarChar,50),
					new SqlParameter("@ThumbnailsUrl", SqlDbType.VarChar,200),
					new SqlParameter("@SKU", SqlDbType.VarChar,50),
					new SqlParameter("@Quantity", SqlDbType.Int,4),
					new SqlParameter("@MemberPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ProductName", SqlDbType.VarChar,50),
					new SqlParameter("@ClassName", SqlDbType.VarChar,50),
					new SqlParameter("@MarketPrice", SqlDbType.Decimal,9),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@BuyUserID", SqlDbType.Int,4),
					new SqlParameter("@IsBuy", SqlDbType.Bit,1),
					new SqlParameter("@AddDateTime", SqlDbType.DateTime),
                    new SqlParameter("@Weight", SqlDbType.Decimal,9),
					new SqlParameter("@NormIDs", SqlDbType.VarChar,50)};

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

            object obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
            strSql.Append("OrderId=@OrderId,");
            strSql.Append("WholesaleDiscountId=@WholesaleDiscountId,");
            strSql.Append("WholesaleDiscountName=@WholesaleDiscountName,");
            strSql.Append("IsGift=@IsGift,");
            strSql.Append("SKUContent=@SKUContent,");
            strSql.Append("ThumbnailsUrl=@ThumbnailsUrl,");
            strSql.Append("SKU=@SKU,");
            strSql.Append("Quantity=@Quantity,");
            strSql.Append("MemberPrice=@MemberPrice,");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("ClassName=@ClassName,");
            strSql.Append("MarketPrice=@MarketPrice,");
            strSql.Append("CategoryId=@CategoryId,");
            strSql.Append("ProductId=@ProductId,");
            strSql.Append("BuyUserID=@BuyUserID,");
            strSql.Append("IsBuy=@IsBuy,");
            strSql.Append("Weight=@Weight,");
            strSql.Append("NormIDs=@NormIDs,");
            strSql.Append("AddDateTime=@AddDateTime");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.NVarChar,20),
					new SqlParameter("@WholesaleDiscountId", SqlDbType.Int,4),
					new SqlParameter("@WholesaleDiscountName", SqlDbType.VarChar,50),
					new SqlParameter("@IsGift", SqlDbType.Bit,1),
					new SqlParameter("@SKUContent", SqlDbType.VarChar,50),
					new SqlParameter("@ThumbnailsUrl", SqlDbType.VarChar,200),
					new SqlParameter("@SKU", SqlDbType.VarChar,50),
					new SqlParameter("@Quantity", SqlDbType.Int,4),
					new SqlParameter("@MemberPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ProductName", SqlDbType.VarChar,50),
					new SqlParameter("@ClassName", SqlDbType.VarChar,50),
					new SqlParameter("@MarketPrice", SqlDbType.Decimal,9),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@BuyUserID", SqlDbType.Int,4),
					new SqlParameter("@IsBuy", SqlDbType.Bit,1),
					new SqlParameter("@AddDateTime", SqlDbType.DateTime),
                    new SqlParameter("@Weight", SqlDbType.Decimal,9),
					new SqlParameter("@NormIDs", SqlDbType.VarChar,50)};
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

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Buy_OrderItem_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Buy_OrderItem ", sPre);
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
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
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
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
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
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
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
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
            List<Entity.Buy_OrderItem> list = new List<Entity.Buy_OrderItem>();
            using (IDataReader dataReader = SplitPages.GetListPages_SP(DB, "Buy_OrderItem", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount, sPre))
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
            model.OrderId = dataReader["OrderId"].ToString();
            ojb = dataReader["WholesaleDiscountId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.WholesaleDiscountId = (int)ojb;
            }
            model.WholesaleDiscountName = dataReader["WholesaleDiscountName"].ToString();
            ojb = dataReader["IsGift"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsGift = (bool)ojb;
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
            model.ProductName = dataReader["ProductName"].ToString();
            model.ClassName = dataReader["ClassName"].ToString();
            ojb = dataReader["MarketPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MarketPrice = (decimal)ojb;
            }
            ojb = dataReader["Weight"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Weight = (decimal)ojb;
            }
            model.NormIDs = dataReader["NormIDs"].ToString();
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
                model.IsBuy = (bool)ojb;
            }
            ojb = dataReader["AddDateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDateTime = (DateTime)ojb;
            }
            return model;
        }

        #endregion  成员方法

        #region 自定义方法

        public void DeleteByUniqueID(int UniqueID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Buy_OrderItem ", sPre);
            strSql.Append(" where BuyUserID=@BuyUserID and IsBuy=0");
            SqlParameter[] parameters = {
					new SqlParameter("@BuyUserID", SqlDbType.Int,4)};
            parameters[0].Value = UniqueID;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public List<Entity.Buy_OrderItem> GetCartItems(int uniqueID, string applicationName)
        {
            return Buy_OrderItem_GetListArray(0, string.Concat("BuyUserID=", uniqueID, " and IsBuy=1"), "");
        }
        /// <summary>
        /// 修改订单商品信息
        /// </summary>
        /// <param name="dicArray">要修改的字段集合</param>
        /// <param name="tid">ID</param>
        /// <returns></returns>
        public bool UpdateByDic_OrderItems(Dictionary<string, object> dicArray, int tid)
        {
            if (dicArray != null && dicArray.Count > 0)
            {
                StringBuilder tmpSql = new StringBuilder();
                foreach (KeyValuePair<string, object> dic in dicArray)
                {
                    tmpSql.AppendFormat("{0}={1},", dic.Key, dic.Value);
                }
                if (tmpSql.Length > 0 && tid > 0)
                {
                    string strSql = string.Format("update {0}Buy_OrderItem set {1} where id={2}", sPre, tmpSql.ToString().TrimEnd(','), tid);
                    if (DB.ExecuteNonQuery(strSql) > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
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
                foreach (KeyValuePair<string, object> dic in dicArray)
                {
                    tmpSqlOrder.AppendFormat("{0}={1},", dic.Key, dic.Value);
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

        #endregion
    }
}

