using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;
namespace EbSite.Data.User.MySql
{
    /// <summary>
    /// 数据访问类FSDFSF。
    /// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
		private string sFieldpaylog = "id,UserID,UserName,Income,Free,AddDateTime,TimeNumber";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int paylog_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}paylog", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool paylog_Exists(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}paylog", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64,12)};
            parameters[0].Value = id;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.PayLog paylog_GetEntity(long id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldpaylog + "  from {0}paylog ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64,12)};
            parameters[0].Value = id;
            Entity.PayLog model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = paylog_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int paylog_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}paylog ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            int iCount = 0;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
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
        public DataSet paylog_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldpaylog);
            strSql.AppendFormat(" FROM {0}paylog ", sPre);
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
            return DbHelperUser.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.PayLog> paylog_GetListArray(string strWhere)
        {
            return paylog_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.PayLog> paylog_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldpaylog);
            strSql.AppendFormat(" FROM {0}paylog ", sPre);
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
            List<Entity.PayLog> list = new List<Entity.PayLog>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(paylog_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.PayLog> paylog_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.PayLog> list = new List<Entity.PayLog>();
            RecordCount = paylog_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "PayLog", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(paylog_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.PayLog paylog_ReaderBind(IDataReader dataReader)
        {
            Entity.PayLog model = new Entity.PayLog();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (long)ojb;
            }
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            model.UserName = dataReader["UserName"].ToString();
            ojb = dataReader["Income"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Income = (decimal)ojb;
            }
            ojb = dataReader["Free"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Free = (decimal)ojb;
            }
            ojb = dataReader["AddDateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDateTime = (DateTime)ojb;
            }
            ojb = dataReader["TimeNumber"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TimeNumber = (int)ojb;
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int paylog_Add(Entity.PayLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}paylog(", sPre);
            strSql.Append("UserID,UserName,Income,Free,AddDateTime,TimeNumber)");
            strSql.Append(" values (");
            strSql.Append("?UserID,?UserName,?Income,?Free,?AddDateTime,?TimeNumber)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100),
					new MySqlParameter("?Income", MySqlDbType.Decimal,11),
					new MySqlParameter("?Free", MySqlDbType.Decimal,11),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
					new MySqlParameter("?TimeNumber", MySqlDbType.Int32,11)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Income;
            parameters[3].Value = model.Free;
            parameters[4].Value = model.AddDateTime;
            parameters[5].Value = model.TimeNumber;

            object obj = DbHelperUserWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return paylog_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void paylog_Update(Entity.PayLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}paylog set ", sPre);
            strSql.Append("UserID=?UserID,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("Income=?Income,");
            strSql.Append("Free=?Free,");
            strSql.Append("AddDateTime=?AddDateTime,");
            strSql.Append("TimeNumber=?TimeNumber");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64,12),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100),
					new MySqlParameter("?Income", MySqlDbType.Decimal,11),
					new MySqlParameter("?Free", MySqlDbType.Decimal,11),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
					new MySqlParameter("?TimeNumber", MySqlDbType.Int32,11)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.Income;
            parameters[4].Value = model.Free;
            parameters[5].Value = model.AddDateTime;
            parameters[6].Value = model.TimeNumber;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void paylog_Delete(long id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}paylog ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64,12)};
            parameters[0].Value = id;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}

