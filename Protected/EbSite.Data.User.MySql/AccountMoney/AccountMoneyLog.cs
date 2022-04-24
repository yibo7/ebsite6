using System;
using System.Data;
using System.Data.Common;
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
		private string sFieldAccountMoneyLog = "id,UserId,UserName,TradeDate,TradeType,Income,Expenses,Balance,Remark";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int AccountMoneyLog_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}accountmoneyLog", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool AccountMoneyLog_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}accountmoneyLog", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.AccountMoneyLog AccountMoneyLog_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldAccountMoneyLog + "  from {0}accountmoneyLog ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.AccountMoneyLog model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = AccountMoneyLog_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int AccountMoneyLog_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}accountmoneyLog ", sPre);
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
        public DataSet AccountMoneyLog_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldAccountMoneyLog);
            strSql.AppendFormat(" FROM {0}accountmoneyLog ", sPre);
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
                strSql.Append(" top " + Top.ToString());
            }
            return DbHelperUser.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.AccountMoneyLog> AccountMoneyLog_GetListArray(string strWhere)
        {
            return AccountMoneyLog_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.AccountMoneyLog> AccountMoneyLog_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldAccountMoneyLog);
            strSql.AppendFormat(" FROM {0}accountmoneyLog ", sPre);
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
                strSql.Append(" top " + Top.ToString());
            }
            List<Entity.AccountMoneyLog> list = new List<Entity.AccountMoneyLog>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(AccountMoneyLog_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.AccountMoneyLog> AccountMoneyLog_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.AccountMoneyLog> list = new List<Entity.AccountMoneyLog>();
            RecordCount = AccountMoneyLog_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperUser.Instance, "AccountMoneyLog", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(AccountMoneyLog_ReaderBind(dataReader));
                }
            }
            return list;


        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.AccountMoneyLog AccountMoneyLog_ReaderBind(IDataReader dataReader)
        {
            Entity.AccountMoneyLog model = new Entity.AccountMoneyLog();
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
            model.UserName = dataReader["UserName"].ToString();
            ojb = dataReader["TradeDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TradeDate = (DateTime)ojb;
            }
            ojb = dataReader["TradeType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TradeType = (int)ojb;
            }
            ojb = dataReader["Income"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Income = (decimal)ojb;
            }
            ojb = dataReader["Expenses"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Expenses = (decimal)ojb;
            }
            ojb = dataReader["Balance"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Balance = (decimal)ojb;
            }
            model.Remark = dataReader["Remark"].ToString();
            return model;
        }

        #endregion 读

        #region 写

        public int AccountMoneyLog_Add(Entity.AccountMoneyLog model)
        {
            return AccountMoneyLog_Add(model, null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AccountMoneyLog_Add(Entity.AccountMoneyLog model, DbTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}accountmoneyLog(", sPre);
            strSql.Append("UserId,UserName,TradeDate,TradeType,Income,Expenses,Balance,Remark)");
            strSql.Append(" values (");
            strSql.Append("?UserId,?UserName,?TradeDate,?TradeType,?Income,?Expenses,?Balance,?Remark)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?TradeDate", MySqlDbType.DateTime),
					new MySqlParameter("?TradeType", MySqlDbType.Int32,4),
					new MySqlParameter("?Income", MySqlDbType.Decimal,9),
					new MySqlParameter("?Expenses", MySqlDbType.Decimal,9),
					new MySqlParameter("?Balance", MySqlDbType.Decimal,9),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500)};

            parameters[0].Value = model.UserId;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.TradeDate;
            parameters[3].Value = model.TradeType;
            parameters[4].Value = model.Income;
            parameters[5].Value = model.Expenses;
            parameters[6].Value = model.Balance;
            parameters[7].Value = model.Remark;
            object obj = null;
            if (Trans == null)
            {
                obj = DbHelperUserWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                obj = DbHelperUserWrite.Instance.ExecuteScalar(Trans, CommandType.Text, strSql.ToString(), parameters);
            }


            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void AccountMoneyLog_Update(Entity.AccountMoneyLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}accountmoneyLog set ", sPre);
            strSql.Append("UserId=?UserId,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("TradeDate=?TradeDate,");
            strSql.Append("TradeType=?TradeType,");
            strSql.Append("Income=?Income,");
            strSql.Append("Expenses=?Expenses,");
            strSql.Append("Balance=?Balance,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?TradeDate", MySqlDbType.Datetime),
					new MySqlParameter("?TradeType", MySqlDbType.Int32,4),
					new MySqlParameter("?Income", MySqlDbType.Decimal,9),
					new MySqlParameter("?Expenses", MySqlDbType.Decimal,9),
					new MySqlParameter("?Balance", MySqlDbType.Decimal,9),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.TradeDate;
            parameters[4].Value = model.TradeType;
            parameters[5].Value = model.Income;
            parameters[6].Value = model.Expenses;
            parameters[7].Value = model.Balance;
            parameters[8].Value = model.Remark;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void AccountMoneyLog_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}accountmoneyLog ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        ///  返给客户 预付款
        /// </summary>
        /// <returns></returns>
        public bool AccountMoney_Add(Entity.AccountMoneyLog accountMoneyMd, Entity.PayPass payModel)
        {
            bool isSuccessed = true;
            MySqlConnection cn = new MySqlConnection(DbHelperUserWrite.Instance.ConnectionString());
            cn.Open();
            MySqlTransaction tran = cn.BeginTransaction();  //创建事务
            try
            {
                AccountMoneyLog_Add(accountMoneyMd, tran);
                PayPass_Update(payModel, tran);
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

        #endregion 写

    }
}

