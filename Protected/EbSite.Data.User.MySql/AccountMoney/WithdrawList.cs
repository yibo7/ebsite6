using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using EbSite.Entity;
using MySql.Data.MySqlClient;
namespace EbSite.Data.User.MySql
{
    /// <summary>
    /// 数据访问类FSDFSF。
    /// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
    {
        private string sFieldWithdrawList = "id,UserId,UserName,RequestTime,Amount,AccountName,BankName,CardNumber,Remark";
 
        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int WithdrawList_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}withdrawlist", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool WithdrawList_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}withdrawlist", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.WithdrawList WithdrawList_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldWithdrawList + "  from {0}withdrawlist ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.WithdrawList model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = WithdrawList_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int WithdrawList_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}withdrawlist ", sPre);
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
        public DataSet WithdrawList_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldWithdrawList);
            strSql.AppendFormat(" FROM {0}withdrawlist ", sPre);
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
        public List<Entity.WithdrawList> WithdrawList_GetListArray(string strWhere)
        {
            return WithdrawList_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.WithdrawList> WithdrawList_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldWithdrawList);
            strSql.AppendFormat(" FROM {0}withdrawlist ", sPre);
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
            List<Entity.WithdrawList> list = new List<Entity.WithdrawList>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(WithdrawList_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.WithdrawList> WithdrawList_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.WithdrawList> list = new List<Entity.WithdrawList>();
            RecordCount = WithdrawList_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperUser.Instance, "WithdrawList", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(WithdrawList_ReaderBind(dataReader));
                }
            }
            return list;


        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.WithdrawList WithdrawList_ReaderBind(IDataReader dataReader)
        {
            Entity.WithdrawList model = new Entity.WithdrawList();
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
            ojb = dataReader["RequestTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RequestTime = (DateTime)ojb;
            }
            ojb = dataReader["Amount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Amount = (decimal)ojb;
            }
            model.AccountName = dataReader["AccountName"].ToString();
            model.BankName = dataReader["BankName"].ToString();
            model.CardNumber = dataReader["CardNumber"].ToString();
            model.Remark = dataReader["Remark"].ToString();
            return model;
        }

        #endregion 读

        #region 写

        public int WithdrawList_Add(Entity.WithdrawList model)
        {
            return WithdrawList_Add(model, null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int WithdrawList_Add(Entity.WithdrawList model, MySqlTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}withdrawlist(", sPre);
            strSql.Append("UserId,UserName,RequestTime,Amount,AccountName,BankName,CardNumber,Remark)");
            strSql.Append(" values (");
            strSql.Append("?UserId,?UserName,?RequestTime,?Amount,?AccountName,?BankName,?CardNumber,?Remark)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?RequestTime", MySqlDbType.Datetime),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,9),
					new MySqlParameter("?AccountName", MySqlDbType.VarChar,50),
					new MySqlParameter("?BankName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CardNumber", MySqlDbType.VarChar,50),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500)};

            parameters[0].Value = model.UserId;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.RequestTime;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.AccountName;
            parameters[5].Value = model.BankName;
            parameters[6].Value = model.CardNumber;
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
        public void WithdrawList_Update(Entity.WithdrawList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}withdrawlist set ", sPre);
            strSql.Append("UserId=?UserId,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("RequestTime=?RequestTime,");
            strSql.Append("Amount=?Amount,");
            strSql.Append("AccountName=?AccountName,");
            strSql.Append("BankName=?BankName,");
            strSql.Append("CardNumber=?CardNumber,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?RequestTime", MySqlDbType.Datetime),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,9),
					new MySqlParameter("?AccountName", MySqlDbType.VarChar,50),
					new MySqlParameter("?BankName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CardNumber", MySqlDbType.VarChar,50),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.RequestTime;
            parameters[4].Value = model.Amount;
            parameters[5].Value = model.AccountName;
            parameters[6].Value = model.BankName;
            parameters[7].Value = model.CardNumber;
            parameters[8].Value = model.Remark;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void WithdrawList_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}withdrawlist ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据 通过用户id
        /// </summary>
        public void GetUid_WithdrawList_Delete(int uid, MySqlTransaction Trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}withdrawlist ", sPre);
            strSql.Append(" where userid=?userid ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?userid", MySqlDbType.Int32,4)};
            parameters[0].Value = uid;
            if (Trans == null)
            {
                DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                DbHelperUserWrite.Instance.ExecuteNonQuery(Trans, CommandType.Text, strSql.ToString(), parameters);
            }
        }

        /// <summary>
        /// 申请提现 申请
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Agree"></param>
        /// <returns></returns>
        public bool BalanceDrawRequest_Update(int UserID, bool Agree)
        {
            bool isSuccessed = true;
            MySqlConnection cn = new MySqlConnection(DbHelperUserWrite.Instance.ConnectionString());
            cn.Open();
            MySqlTransaction tran = cn.BeginTransaction();  //创建事务
            try
            {
                if (UserID > 0)
                {
                    GetUid_WithdrawList_Delete(UserID, tran);
                    //List<Entity.PayPass> lsPass = PayPass_GetListArray(1, "userid=" + UserID, ""); //查找 总金额
                    Entity.PayPass lsModel = PayPass_GetEntity(UserID);
                    if (Agree) //同意 添加到
                    {
                        List<Entity.WithdrawList> lsWith = WithdrawList_GetListArray(1, "userid=" + UserID, "");
                        //查找申请提现的金额

                        if (lsWith.Count > 0 && !Equals(lsModel, null))
                        {
                            Entity.AccountMoneyLog moneyLog = new AccountMoneyLog();
                            moneyLog.UserId = UserID;
                            moneyLog.UserName = EbSite.Base.Host.Instance.GetUserUserName(UserID);
                            moneyLog.TradeDate = DateTime.Now;
                            moneyLog.TradeType = Convert.ToInt32(BLL.EAccountMoneyType.TX); //提现
                            moneyLog.Income = 0;
                            moneyLog.Expenses = lsWith[0].Amount;
                            moneyLog.Balance = lsModel.Balance - lsWith[0].Amount;
                            moneyLog.Remark = "提现";
                            AccountMoneyLog_Add(moneyLog, tran);
                        }


                        lsModel.Balance -= lsWith[0].Amount;
                        lsModel.RequestBalance = 0;
                        PayPass_Update(lsModel, tran);
                    }
                    else
                    {
                        lsModel.RequestBalance = 0;
                        PayPass_Update(lsModel, tran);
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

        /// <summary>
        ///  申请提现
        /// </summary>
        /// <param name="withMd"></param>
        /// <param name="Amount"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool BalanceDrawRequest_Add(Entity.WithdrawList withMd, decimal Amount, int UserId)
        {
            bool isSuccessed = true;
            MySqlConnection cn = new MySqlConnection(DbHelperUserWrite.Instance.ConnectionString());
            cn.Open();
            MySqlTransaction tran = cn.BeginTransaction();  //创建事务
            try
            {
                WithdrawList_Add(withMd, tran);
                //更新用户 冻结资金
                //查找申请提现的金额
                // List<Entity.PayPass> lsPass = PayPass_GetListArray(1, "userid=" + UserId, ""); //查找 总金额
                Entity.PayPass lsModel = PayPass_GetEntity(UserId);
                if (!Equals(lsModel, null))
                {
                    lsModel.RequestBalance = Amount;
                    PayPass_Update(lsModel, tran);
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

        #endregion 写

    }
}

