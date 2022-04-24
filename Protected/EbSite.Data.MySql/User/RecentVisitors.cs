using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;

namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类Favorite。
	/// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int RecentVisitors_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("ID", string.Format("{0}recentvisitors", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool RecentVisitors_Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}recentvisitors", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }
        public bool RecentVisitors_Exists(Entity.RecentVisitors model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}recentvisitors", sPre);
            strSql.Append(" where UserID=?UserID and VisitorID=?VisitorID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
                    new MySqlParameter("?VisitorID", MySqlDbType.Int32,4)
                                        
                                        };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.VisitorID;
            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int RecentVisitors_Add(Entity.RecentVisitors model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}recentvisitors(", sPre);
            strSql.Append("UserID,UserName,AddDateTime,VisitorID,VisitorName,VisitorNiName,LastDateTimeInt)");
            strSql.Append(" values (");
            strSql.Append("?UserID,?UserName,?AddDateTime,?VisitorID,?VisitorName,?VisitorNiName,?LastDateTimeInt)");
             strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AddDateTime", MySqlDbType.Datetime),
					new MySqlParameter("?VisitorID",  MySqlDbType.Int32,4),
					new MySqlParameter("?VisitorName", MySqlDbType.VarChar,50),
					new MySqlParameter("?VisitorNiName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?LastDateTimeInt", MySqlDbType.Int32,12)
                                          
                                          
                                          };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.AddDateTime;
            parameters[3].Value = model.VisitorID;
            parameters[4].Value = model.VisitorName;
            parameters[5].Value = model.VisitorNiName;
            parameters[6].Value = model.LastDateTimeInt;

            object obj = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public void RecentVisitors_Update(Entity.RecentVisitors model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}recentvisitors set ", sPre);
        
            strSql.Append("LastDateTimeInt=?LastDateTimeInt");
            strSql.Append(" where UserID=?UserID and  VisitorID=?VisitorID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?VisitorID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?LastDateTimeInt", MySqlDbType.Int32,12)
                                          
                                          };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.VisitorID;
            parameters[2].Value = model.LastDateTimeInt;

            DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public void RecentVisitors_Update(Entity.RecentVisitors model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.AppendFormat("update {0}RecentVisitors set ", sPre);
        //    strSql.Append("UserID=?UserID,");
        //    strSql.Append("UserName=?UserName,");
        //    strSql.Append("AddDateTime=?AddDateTime,");
        //    strSql.Append("VisitorID=?VisitorID,");
        //    strSql.Append("VisitorName=?VisitorName,");
        //    strSql.Append("VisitorNiName=?VisitorNiName,LastDateTimeInt=?LastDateTimeInt");
        //    strSql.Append(" where UserID=?UserID and  VisitorID=?VisitorID");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
        //            new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
        //            new MySqlParameter("?AddDateTime", MySqlDbType.Datetime),
        //            new MySqlParameter("?VisitorID",  MySqlDbType.Int32,4),
        //            new MySqlParameter("?VisitorName", MySqlDbType.VarChar,50),
        //            new MySqlParameter("?VisitorNiName", MySqlDbType.VarChar,50),
        //            new MySqlParameter("?LastDateTimeInt", MySqlDbType.Int32,12)
                                          
        //                                  };
        //    parameters[1].Value = model.UserID;
        //    parameters[2].Value = model.UserName;
        //    parameters[3].Value = model.AddDateTime;
        //    parameters[4].Value = model.VisitorID;
        //    parameters[5].Value = model.VisitorName;
        //    parameters[6].Value = model.VisitorNiName;
        //    parameters[7].Value = model.LastDateTimeInt;

        //    DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        //}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void RecentVisitors_Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}recentvisitors ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.RecentVisitors> RecentVisitors_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(" ID,UserID,UserName,AddDateTime,VisitorID,VisitorName,VisitorNiName,LastDateTimeInt ");
            strSql.AppendFormat(" FROM {0}recentvisitors   ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder.Trim());
            }
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            List<EbSite.Entity.RecentVisitors> list = new List<EbSite.Entity.RecentVisitors>();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(RecentVisitors_ReaderBind(dataReader));
                }
            }
            return list;

        }
         /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.RecentVisitors RecentVisitors_ReaderBind(IDataReader dataReader)
         {
             Entity.RecentVisitors model = new Entity.RecentVisitors();

             if (dataReader["ID"].ToString() != "")
             {
                 model.ID = int.Parse(dataReader["ID"].ToString());
             }
             if (dataReader["UserID"].ToString() != "")
             {
                 model.UserID = int.Parse(dataReader["UserID"].ToString());
             }
             model.UserName = dataReader["UserName"].ToString();
             if (dataReader["AddDateTime"].ToString() != "")
             {
                 model.AddDateTime = DateTime.Parse(dataReader["AddDateTime"].ToString());
             }
             if (dataReader["VisitorID"].ToString() != "")
             {
                 model.VisitorID = int.Parse(dataReader["VisitorID"].ToString());
             }
             model.VisitorName = dataReader["VisitorName"].ToString();
             model.VisitorNiName = dataReader["VisitorNiName"].ToString();
             if (dataReader["LastDateTimeInt"].ToString() != "")
             {
                 model.LastDateTimeInt = int.Parse(dataReader["LastDateTimeInt"].ToString());
             }
            
             return model;
         }

	}
}

