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
        private string sFieldPayment = "id,PaymentApi,PaymentName,UseMoney,IsPercent,IsUseInpour,IsOpend,OrderNumber,Demo,ShowImg,ClassID,ShortName";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int Payment_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}payment", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Payment_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}payment", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Payment Payment_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldPayment + "  from {0}payment ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.Payment model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Payment_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Payment_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}payment ", sPre);
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
        public DataSet Payment_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldPayment);
            strSql.AppendFormat(" FROM {0}payment ", sPre);
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
        public List<Entity.Payment> Payment_GetListArray(string strWhere)
        {
            return Payment_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Payment> Payment_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldPayment);
            strSql.AppendFormat(" FROM {0}payment ", sPre);
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
            List<Entity.Payment> list = new List<Entity.Payment>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Payment_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Payment> Payment_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.Payment> list = new List<Entity.Payment>();
            RecordCount = Payment_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperUser.Instance, "Payment", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Payment_ReaderBind(dataReader));
                }
            }
            return list;


        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Payment Payment_ReaderBind(IDataReader dataReader)
        {
            Entity.Payment model = new Entity.Payment();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.PaymentApi = dataReader["PaymentApi"].ToString();
            model.PaymentName = dataReader["PaymentName"].ToString();
            ojb = dataReader["UseMoney"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UseMoney = (decimal)ojb;
            }
            ojb = dataReader["IsPercent"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if (ojb.ToString().Equals("1"))
                {
                    model.IsPercent = true;
                }
                else
                {
                    model.IsPercent = false;
                }


            }
            ojb = dataReader["IsUseInpour"];
            if (ojb != null && ojb != DBNull.Value)
            {
                //model.IsUseInpour=(bool)ojb;
                if (ojb.ToString().Equals("1"))
                {
                    model.IsUseInpour = true;
                }
                else
                {
                    model.IsUseInpour = false;
                }
            }
            ojb = dataReader["IsOpend"];
            if (ojb != null && ojb != DBNull.Value)
            {
                //model.IsOpend=(bool)ojb;
                if (ojb.ToString().Equals("1"))
                {
                    model.IsOpend = true;
                }
                else
                {
                    model.IsOpend = false;
                }
            }
            ojb = dataReader["OrderNumber"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderNumber = (int)ojb;
            }
            model.Demo = dataReader["Demo"].ToString();
            model.ShowImg = dataReader["ShowImg"].ToString();
            ojb = dataReader["ClassID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ClassID = (int)ojb;
            }

            model.ShortName = dataReader["ShortName"].ToString();
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Payment_Add(Entity.Payment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}payment(", sPre);
            strSql.Append("PaymentApi,PaymentName,UseMoney,IsPercent,IsUseInpour,IsOpend,OrderNumber,Demo,ShowImg,ClassID,ShortName)");
            strSql.Append(" values (");
            strSql.Append("?PaymentApi,?PaymentName,?UseMoney,?IsPercent,?IsUseInpour,?IsOpend,?OrderNumber,?Demo,?ShowImg,?ClassID,?ShortName)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?PaymentApi", MySqlDbType.VarChar,255),
					new MySqlParameter("?PaymentName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UseMoney", MySqlDbType.Decimal,9),
					new MySqlParameter("?IsPercent",MySqlDbType.Bit,1),
					new MySqlParameter("?IsUseInpour",MySqlDbType.Bit,1),
					new MySqlParameter("?IsOpend",MySqlDbType.Bit,1),
					new MySqlParameter("?OrderNumber", MySqlDbType.Int32,4),
					new MySqlParameter("?Demo", MySqlDbType.VarChar),
                    new MySqlParameter("?ShowImg", MySqlDbType.VarChar),
                    new MySqlParameter("?ClassID",MySqlDbType.Int32,4), 
                    new MySqlParameter("?ShortName",MySqlDbType.VarChar,50)
                                          };

            parameters[0].Value = model.PaymentApi;
            parameters[1].Value = model.PaymentName;
            parameters[2].Value = model.UseMoney;
            parameters[3].Value = model.IsPercent;
            parameters[4].Value = model.IsUseInpour;
            parameters[5].Value = model.IsOpend;
            parameters[6].Value = model.OrderNumber;
            parameters[7].Value = model.Demo;
            parameters[8].Value = model.ShowImg;
            parameters[9].Value = model.ClassID;
            parameters[10].Value = model.ShortName;

            object obj = DbHelperUserWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
        public void Payment_Update(Entity.Payment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}payment set ", sPre);
            strSql.Append("PaymentApi=?PaymentApi,");
            strSql.Append("PaymentName=?PaymentName,");
            strSql.Append("UseMoney=?UseMoney,");
            strSql.Append("IsPercent=?IsPercent,");
            strSql.Append("IsUseInpour=?IsUseInpour,");
            strSql.Append("IsOpend=?IsOpend,");
            strSql.Append("OrderNumber=?OrderNumber,");
            strSql.Append("Demo=?Demo,");
            strSql.Append("ShowImg=?ShowImg,");
            strSql.Append("ClassID=?ClassID,");
            strSql.Append("ShortName=?ShortName");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?PaymentApi", MySqlDbType.VarChar,255),
					new MySqlParameter("?PaymentName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UseMoney", MySqlDbType.Decimal,9),
					new MySqlParameter("?IsPercent",MySqlDbType.Bit,1),
					new MySqlParameter("?IsUseInpour",MySqlDbType.Bit,1),
					new MySqlParameter("?IsOpend",MySqlDbType.Bit,1),
					new MySqlParameter("?OrderNumber", MySqlDbType.Int32,4),
					new MySqlParameter("?Demo", MySqlDbType.VarChar),
                    new MySqlParameter("?ShowImg", MySqlDbType.VarChar),
                    new MySqlParameter("?ClassID",MySqlDbType.Int32,4),
                    new MySqlParameter("?ShortName",MySqlDbType.VarChar,50)
                                          };
            parameters[0].Value = model.id;
            parameters[1].Value = model.PaymentApi;
            parameters[2].Value = model.PaymentName;
            parameters[3].Value = model.UseMoney;
            parameters[4].Value = model.IsPercent;
            parameters[5].Value = model.IsUseInpour;
            parameters[6].Value = model.IsOpend;
            parameters[7].Value = model.OrderNumber;
            parameters[8].Value = model.Demo;
            parameters[9].Value = model.ShowImg;
            parameters[10].Value = model.ClassID;
            parameters[11].Value = model.ShortName;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Payment_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}payment ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        #endregion 写

    }
}

