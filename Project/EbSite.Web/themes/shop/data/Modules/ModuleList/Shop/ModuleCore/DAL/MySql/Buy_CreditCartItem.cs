using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Shop.ModuleCore.DAL.MySql
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
	public partial class Shop
	{
        private string sFieldBuy_CreditCartItem = "id,OrderID,CreditProductID,UserID,Quantity,AddTime,Credit,SmallPic,ProductName";
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int Buy_CreditCartItem_GetMaxId()
        {
            return DB.GetMaxID("id", string.Format("{0}Buy_CreditCartItem", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Buy_CreditCartItem_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}Buy_CreditCartItem", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DB.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Buy_CreditCartItem_Add(Entity.Buy_CreditCartItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}Buy_CreditCartItem(", sPre);
            strSql.Append("OrderID,CreditProductID,UserID,Quantity,AddTime,Credit,SmallPic,ProductName)");
            strSql.Append(" values (");
            strSql.Append("?OrderID,?CreditProductID,?UserID,?Quantity,?AddTime,?Credit,?SmallPic,?ProductName)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderID", MySqlDbType.Int64,15),
					new MySqlParameter("?CreditProductID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,11),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?Credit", MySqlDbType.Int32,11),
					new MySqlParameter("?SmallPic", MySqlDbType.VarChar,200),
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.CreditProductID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.Quantity;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.Credit;
            parameters[6].Value = model.SmallPic;
            parameters[7].Value = model.ProductName;

            object obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return Buy_CreditCartItem_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Buy_CreditCartItem_Update(Entity.Buy_CreditCartItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}Buy_CreditCartItem set ", sPre);
            strSql.Append("OrderID=?OrderID,");
            strSql.Append("CreditProductID=?CreditProductID,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("Quantity=?Quantity,");
            strSql.Append("AddTime=?AddTime,");
            strSql.Append("Credit=?Credit,");
            strSql.Append("SmallPic=?SmallPic,");
            strSql.Append("ProductName=?ProductName");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?OrderID", MySqlDbType.Int64,15),
					new MySqlParameter("?CreditProductID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,11),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?Credit", MySqlDbType.Int32,11),
					new MySqlParameter("?SmallPic", MySqlDbType.VarChar,200),
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.CreditProductID;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.Quantity;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.Credit;
            parameters[7].Value = model.SmallPic;
            parameters[8].Value = model.ProductName;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Buy_CreditCartItem_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Buy_CreditCartItem ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Buy_CreditCartItem Buy_CreditCartItem_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldBuy_CreditCartItem + "  from {0}Buy_CreditCartItem ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.Buy_CreditCartItem model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Buy_CreditCartItem_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Buy_CreditCartItem_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}Buy_CreditCartItem ", sPre);
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
        public DataSet Buy_CreditCartItem_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldBuy_CreditCartItem);
            strSql.AppendFormat(" FROM {0}Buy_CreditCartItem ", sPre);
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
        public List<Entity.Buy_CreditCartItem> Buy_CreditCartItem_GetListArray(string strWhere)
        {
            return Buy_CreditCartItem_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Buy_CreditCartItem> Buy_CreditCartItem_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldBuy_CreditCartItem);
            strSql.AppendFormat(" FROM {0}Buy_CreditCartItem ", sPre);
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
            List<Entity.Buy_CreditCartItem> list = new List<Entity.Buy_CreditCartItem>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Buy_CreditCartItem_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Buy_CreditCartItem> Buy_CreditCartItem_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.Buy_CreditCartItem> list = new List<Entity.Buy_CreditCartItem>();
            RecordCount = Buy_CreditCartItem_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "Buy_CreditCartItem", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Buy_CreditCartItem_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Buy_CreditCartItem Buy_CreditCartItem_ReaderBind(IDataReader dataReader)
        {
            Entity.Buy_CreditCartItem model = new Entity.Buy_CreditCartItem();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["OrderID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderID = (long)ojb;
            }
            ojb = dataReader["CreditProductID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreditProductID = (int)ojb;
            }
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            ojb = dataReader["Quantity"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Quantity = (int)ojb;
            }
            ojb = dataReader["AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddTime = (DateTime)ojb;
            }
            ojb = dataReader["Credit"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Credit = (int)ojb;
            }
            model.SmallPic = dataReader["SmallPic"].ToString();
            model.ProductName = dataReader["ProductName"].ToString();
            return model;
        }

        #endregion  成员方法

       
	}
}

