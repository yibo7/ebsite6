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
        private string sFieldpointdetails = "id,UserId,TradeType,Increased,Reduced,Points,TradeDate,OrderId,Remark";
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int pointdetails_GetMaxId()
        {
            return DB.GetMaxID("id", string.Format("{0}pointdetails", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool pointdetails_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}pointdetails", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DB.Exists(strSql.ToString(), parameters);
        }
        public int pointdetails_Add(Entity.pointdetails model)
        {
            return pointdetails_Add(model, null);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int pointdetails_Add(Entity.pointdetails model, MySqlTransaction tran)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}pointdetails(", sPre);
            strSql.Append("UserId,TradeType,Increased,Reduced,Points,TradeDate,OrderId,Remark)");
            strSql.Append(" values (");
            strSql.Append("?UserId,?TradeType,?Increased,?Reduced,?Points,?TradeDate,?OrderId,?Remark)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserId", MySqlDbType.Int32,11),
					new MySqlParameter("?TradeType", MySqlDbType.Int32,11),
					new MySqlParameter("?Increased", MySqlDbType.Int32,11),
					new MySqlParameter("?Reduced", MySqlDbType.Int32,11),
					new MySqlParameter("?Points", MySqlDbType.Int32,11),
					new MySqlParameter("?TradeDate", MySqlDbType.DateTime),
					new MySqlParameter("?OrderId", MySqlDbType.Int64,12),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.TradeType;
            parameters[2].Value = model.Increased;
            parameters[3].Value = model.Reduced;
            parameters[4].Value = model.Points;
            parameters[5].Value = model.TradeDate;
            parameters[6].Value = model.OrderId;
            parameters[7].Value = model.Remark;
            object obj;
            if (tran != null)
            {
                obj = DB.ExecuteScalar(tran, CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            }

            if (obj == null)
            {
                return pointdetails_GetMaxId();
            }
            return 0;
        }

        public void pointdetails_Update(Entity.pointdetails model)
        {
            pointdetails_Update(model, null);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void pointdetails_Update(Entity.pointdetails model, MySqlTransaction tran)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}pointdetails set ", sPre);
            strSql.Append("UserId=?UserId,");
            strSql.Append("TradeType=?TradeType,");
            strSql.Append("Increased=?Increased,");
            strSql.Append("Reduced=?Reduced,");
            strSql.Append("Points=?Points,");
            strSql.Append("TradeDate=?TradeDate,");
            strSql.Append("OrderId=?OrderId,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?UserId", MySqlDbType.Int32,11),
					new MySqlParameter("?TradeType", MySqlDbType.Int32,11),
					new MySqlParameter("?Increased", MySqlDbType.Int32,11),
					new MySqlParameter("?Reduced", MySqlDbType.Int32,11),
					new MySqlParameter("?Points", MySqlDbType.Int32,11),
					new MySqlParameter("?TradeDate", MySqlDbType.DateTime),
					new MySqlParameter("?OrderId", MySqlDbType.Int64,12),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.TradeType;
            parameters[3].Value = model.Increased;
            parameters[4].Value = model.Reduced;
            parameters[5].Value = model.Points;
            parameters[6].Value = model.TradeDate;
            parameters[7].Value = model.OrderId;
            parameters[8].Value = model.Remark;

            if (tran != null)
            {
                DB.ExecuteNonQuery(tran, CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void pointdetails_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}pointdetails ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.pointdetails pointdetails_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldpointdetails + "  from {0}pointdetails ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.pointdetails model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = pointdetails_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int pointdetails_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}pointdetails ", sPre);
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
        public DataSet pointdetails_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldpointdetails);
            strSql.AppendFormat(" FROM {0}pointdetails ", sPre);
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
        public List<Entity.pointdetails> pointdetails_GetListArray(string strWhere)
        {
            return pointdetails_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.pointdetails> pointdetails_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldpointdetails);
            strSql.AppendFormat(" FROM {0}pointdetails ", sPre);
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
            List<Entity.pointdetails> list = new List<Entity.pointdetails>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(pointdetails_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.pointdetails> pointdetails_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.pointdetails> list = new List<Entity.pointdetails>();
            RecordCount = pointdetails_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "pointdetails", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(pointdetails_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.pointdetails pointdetails_ReaderBind(IDataReader dataReader)
        {
            Entity.pointdetails model = new Entity.pointdetails();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["UserId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserId = (int)ojb;
            }
            ojb = dataReader["TradeType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TradeType = (int)ojb;
            }
            ojb = dataReader["Increased"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Increased = (int)ojb;
            }
            ojb = dataReader["Reduced"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Reduced = (int)ojb;
            }
            ojb = dataReader["Points"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Points = (int)ojb;
            }
            ojb = dataReader["TradeDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TradeDate = (DateTime)ojb;
            }
            ojb = dataReader["OrderId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderId = (long)ojb;
            }
            model.Remark = dataReader["Remark"].ToString();
            return model;
        }

        #endregion  成员方法



    }
}

