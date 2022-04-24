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
        private string sFieldBuy_CartItem = "id,CartNumber,WholesaleDiscountId,WholesaleDiscountName,IsGift,SKUContent,ThumbnailsUrl,SKU,Quantity,MemberPrice,ProductName,ClassName,MarketPrice,CategoryId,ProductId,BuyUserID,IsBuy,AddDateTime,Weight,NormIDs,CostPrice,Points,GiveQuantity,AdjustedPrice,PurchaseGiftId,PurchaseGiftName,IsGroup,IsRobBuy";
        
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int Buy_CartItem_GetMaxId()
        {
            return DB.GetMaxID("id", string.Format("{0}Buy_CartItem", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Buy_CartItem_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}Buy_CartItem", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DB.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Buy_CartItem_Add(Entity.Buy_CartItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}Buy_CartItem(", sPre);
            strSql.Append("CartNumber,WholesaleDiscountId,WholesaleDiscountName,IsGift,SKUContent,ThumbnailsUrl,SKU,Quantity,MemberPrice,ProductName,ClassName,MarketPrice,CategoryId,ProductId,BuyUserID,IsBuy,AddDateTime,Weight,NormIDs,CostPrice,Points,GiveQuantity,AdjustedPrice,PurchaseGiftId,PurchaseGiftName,IsGroup,IsRobBuy)");
            strSql.Append(" values (");
            strSql.Append("?CartNumber,?WholesaleDiscountId,?WholesaleDiscountName,?IsGift,?SKUContent,?ThumbnailsUrl,?SKU,?Quantity,?MemberPrice,?ProductName,?ClassName,?MarketPrice,?CategoryId,?ProductId,?BuyUserID,?IsBuy,?AddDateTime,?Weight,?NormIDs,?CostPrice,?Points,?GiveQuantity,?AdjustedPrice,?PurchaseGiftId,?PurchaseGiftName,?IsGroup,?IsRobBuy)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?CartNumber", MySqlDbType.Int64,12),
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
                    new MySqlParameter("?IsGroup",MySqlDbType.Bit,1),
                    new MySqlParameter("?IsRobBuy",MySqlDbType.Bit,1)
                                          };
           
            parameters[0].Value = model.CartNumber;
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
            parameters[25].Value = model.IsGroup;
            parameters[26].Value = model.IsRobBuy;


            MySqlConnection cn = new MySqlConnection(DB.ConnectionString());
            cn.Open();
            MySqlTransaction tran = cn.BeginTransaction();  //创建事务

            int DataID = 0;

            try
            {
                object obj = DB.ExecuteScalar(tran, CommandType.Text, strSql.ToString(), parameters);
                if (obj == null)
                {
                    DataID = 1;
                }
                else
                {
                    DataID = Convert.ToInt32(obj);
                }

                if (!Equals(model.SelOptionItems, null))
                {
                    if (model.SelOptionItems.Count > 0)
                    {
                        foreach (Entity.cartproductoptionvalue opt in model.SelOptionItems)
                        {
                            opt.BuyUserID = model.BuyUserID;
                            DAL.DataProfile.DalFactory.DalProvider.cartproductoptionvalue_Add(opt, tran);
                        }
                    }
                }
                if (!Equals(model.Gives, null))
                {
                    if (model.Gives.Count > 0)
                    {
                        foreach (Entity.giftcartproduct opt in model.Gives)
                        {
                            opt.BuyUserID = model.BuyUserID;
                            DAL.DataProfile.DalFactory.DalProvider.giftcartproduct_Add(opt, tran);
                        }
                    }
                }

                //提交事务
                tran.Commit();
            }
            catch
            {
                //出错回滚
                tran.Rollback();
                throw new Exception("添加商品到购车时发生错误，数据已经回滚，本次操作不成功！");
            }
            finally  //关闭联接
            {
                if (cn != null && cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return DataID;

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Buy_CartItem_Update(Entity.Buy_CartItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}Buy_CartItem set ", sPre);
            strSql.Append("CartNumber=?CartNumber,");
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

            strSql.Append("IsGroup=?IsGroup,");
            strSql.Append("IsRobBuy=?IsRobBuy");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?CartNumber", MySqlDbType.Int64,12),
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
                    new MySqlParameter("?IsGroup",MySqlDbType.Bit,1),
                    new MySqlParameter("?IsRobBuy",MySqlDbType.Bit,1)

                                          };
            parameters[0].Value = model.id;
            parameters[1].Value = model.CartNumber;
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
            parameters[26].Value = model.IsGroup;
            parameters[27].Value = model.IsRobBuy;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Buy_CartItem_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Buy_CartItem ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Buy_CartItem Buy_CartItem_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldBuy_CartItem + "  from {0}Buy_CartItem ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.Buy_CartItem model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Buy_CartItem_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Buy_CartItem_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}Buy_CartItem ", sPre);
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
        public DataSet Buy_CartItem_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
           
            strSql.Append(sFieldBuy_CartItem);
            strSql.AppendFormat(" FROM {0}Buy_CartItem ", sPre);
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
        public List<Entity.Buy_CartItem> Buy_CartItem_GetListArray(string strWhere)
        {
            return Buy_CartItem_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Buy_CartItem> Buy_CartItem_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            
            strSql.Append(sFieldBuy_CartItem);
            strSql.AppendFormat(" FROM {0}Buy_CartItem ", sPre);
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
            List<Entity.Buy_CartItem> list = new List<Entity.Buy_CartItem>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Buy_CartItem_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Buy_CartItem> Buy_CartItem_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {

            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = Buy_CartItem_GetCount(sbSql.ToString());
            List<Entity.Buy_CartItem> list = new List<Entity.Buy_CartItem>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "Buy_CartItem", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Buy_CartItem_ReaderBind(dataReader));
                }
            }
            return list;

          

           
        }

       
        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Buy_CartItem Buy_CartItem_ReaderBind(IDataReader dataReader)
        {
            Entity.Buy_CartItem model = new Entity.Buy_CartItem();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["CartNumber"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CartNumber = (long)ojb;
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
            model.PurchaseGiftName = dataReader["PurchaseGiftName"].ToString();

            ojb = dataReader["IsGroup"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if (ojb.ToString().Equals("1") || ojb.ToString().Equals("true"))
                {
                    model.IsGroup = true;
                }
                else
                {
                    model.IsGroup = false;
                }
            }
            ojb = dataReader["IsRobBuy"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if (ojb.ToString().Equals("1") || ojb.ToString().Equals("true"))
                {
                    model.IsRobBuy = true;
                }
                else
                {
                    model.IsRobBuy = false;
                }
            }
            
            return model;
        }

        #endregion  成员方法

        #region 自定义方法

        public void DeleteByUniqueID(int UniqueID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Buy_CartItem ", sPre);
            strSql.Append(" where BuyUserID=?BuyUserID; ");


            strSql.AppendFormat("delete from {0}cartproductoptionvalue ", sPre);
            strSql.Append(" where BuyUserID=?BuyUserID; ");

            strSql.AppendFormat("delete from {0}giftcartproduct ", sPre);
            strSql.Append(" where BuyUserID=?BuyUserID; ");

            //礼品
            strSql.AppendFormat("delete from {0}buy_creditcartitem ", sPre);
            strSql.Append(" where UserID=?BuyUserID; ");

            MySqlParameter[] parameters = {
					new MySqlParameter("?BuyUserID", MySqlDbType.Int32,4)};
            parameters[0].Value = UniqueID;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);




        }
        public List<Entity.Buy_CartItem> GetCartItems(int uniqueID, string applicationName)
        {
            return Buy_CartItem_GetListArray(0, string.Concat("BuyUserID=", uniqueID), "");
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
                    string strSql = string.Format("update {0}Buy_CartItem set {1} where id={2}", sPre, tmpSql.ToString().TrimEnd(','), tid);
                    if (DB.ExecuteNonQuery(strSql) > 0)
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

