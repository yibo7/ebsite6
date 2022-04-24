using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;
namespace EbSite.Data.MySql
{
    public partial class DataProviderCms : Interface.IDataProviderCms
	{
		private string sFieldtool_chatlist = "id,SalerUserID,SalerName,SalerUserName,UserID,UserName,UserNiName,UserIP,Msg,DateTime,IsSalerSay";

        #region 读

        #region 自定义方法

        /// <summary>
        /// 获取聊天记录
        /// </summary>
        /// <param name="salerID">销售员ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public DataTable GetChatList(int salerID, int userID)
        {
            string strSql =string.Format("select * from eb_tool_chatlist where SalerUserID={0} and UserID={1} order by id",salerID,userID);
            using(DataSet ds=DbHelperCms.Instance.ExecuteDataset(CommandType.Text,strSql))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 获取聊天记录
        /// </summary>
        /// <param name="salerID">销售员ID</param>
        /// <returns></returns>
        public DataTable GetChatList(int salerID)
        {
            string strSql = string.Format("select * from eb_tool_chatlist where SalerUserID={0} order by id", salerID);
            using (DataSet ds = DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion 自定义方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int tool_chatlist_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}tool_chatList", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool tool_chatlist_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}tool_chatList", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Tool_ChatList tool_chatlist_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldtool_chatlist + "  from {0}tool_chatList ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", SqlDbType.BigInt)};
            parameters[0].Value = id;
            Entity.Tool_ChatList model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = tool_chatlist_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int tool_chatlist_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}tool_chatList ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            int iCount = 0;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
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
        public DataSet tool_chatlist_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldtool_chatlist);
            strSql.AppendFormat(" FROM {0}tool_chatList ", sPre);
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
            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.Tool_ChatList> tool_chatlist_GetListArray(string strWhere)
        {
            return tool_chatlist_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Tool_ChatList> tool_chatlist_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldtool_chatlist);
            strSql.AppendFormat(" FROM {0}tool_chatList ", sPre);
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
            List<Entity.Tool_ChatList> list = new List<Entity.Tool_ChatList>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(tool_chatlist_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Tool_ChatList> tool_chatlist_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.Tool_ChatList> list = new List<Entity.Tool_ChatList>();
            RecordCount = tool_chatlist_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "Tool_ChatList", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(tool_chatlist_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Tool_ChatList tool_chatlist_ReaderBind(IDataReader dataReader)
        {
            Entity.Tool_ChatList model = new Entity.Tool_ChatList();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = Convert.ToInt32(ojb.ToString());
            }
            ojb = dataReader["SalerUserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SalerUserID = int.Parse(ojb.ToString());
            }
            model.SalerName = dataReader["SalerName"].ToString();
            ojb = dataReader["SalerUserName"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SalerUserName = ojb.ToString();
            }
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = int.Parse(ojb.ToString());
            }
            model.UserName = dataReader["UserName"].ToString();
            model.UserNiName = dataReader["UserNiName"].ToString();
            model.UserIP = dataReader["UserIP"].ToString();
            model.Msg = dataReader["Msg"].ToString();
            ojb = dataReader["DateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.DateTime = (DateTime)ojb;
            }
            ojb = dataReader["IsSalerSay"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsSalerSay = int.Parse(ojb.ToString());
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int tool_chatlist_Add(Entity.Tool_ChatList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}tool_chatList(", sPre);
            strSql.Append("SalerUserID,SalerName,SalerUserName,UserID,UserName,UserNiName,UserIP,Msg,DateTime,IsSalerSay)");
            strSql.Append(" values (");
            strSql.Append("?SalerUserID,?SalerName,?SalerUserName,?UserID,?UserName,?UserNiName,?UserIP,?Msg,?DateTime,?IsSalerSay)");
            strSql.Append(";select @@session.identity;");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SalerUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?SalerName", MySqlDbType.VarChar,50),
					new MySqlParameter("?SalerUserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserIP", MySqlDbType.VarChar,50),
					new MySqlParameter("?Msg", MySqlDbType.Text),
					new MySqlParameter("?DateTime", MySqlDbType.DateTime),
					new MySqlParameter("?IsSalerSay", MySqlDbType.Bit)};
            parameters[0].Value = model.SalerUserID;
            parameters[1].Value = model.SalerName;
            parameters[2].Value = model.SalerUserName;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.UserName;
            parameters[5].Value = model.UserNiName;
            parameters[6].Value = model.UserIP;
            parameters[7].Value = model.Msg;
            parameters[8].Value = model.DateTime;
            parameters[9].Value = model.IsSalerSay;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
        public void tool_chatlist_Update(Entity.Tool_ChatList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}tool_chatList set ", sPre);
            strSql.Append("SalerUserID=?SalerUserID,");
            strSql.Append("SalerName=?SalerName,");
            strSql.Append("SalerUserName=?SalerUserName,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("UserNiName=?UserNiName,");
            strSql.Append("UserIP=?UserIP,");
            strSql.Append("Msg=?Msg,");
            strSql.Append("DateTime=?DateTime,");
            strSql.Append("IsSalerSay=?IsSalerSay");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32),
					new MySqlParameter("?SalerUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?SalerName", MySqlDbType.VarChar,50),
					new MySqlParameter("?SalerUserName",MySqlDbType.VarChar,50),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserIP", MySqlDbType.VarChar,50),
					new MySqlParameter("?Msg", MySqlDbType.Text),
					new MySqlParameter("?DateTime", MySqlDbType.DateTime),
					new MySqlParameter("?IsSalerSay",MySqlDbType.Bit)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.SalerUserID;
            parameters[2].Value = model.SalerName;
            parameters[3].Value = model.SalerUserName;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.UserName;
            parameters[6].Value = model.UserNiName;
            parameters[7].Value = model.UserIP;
            parameters[8].Value = model.Msg;
            parameters[9].Value = model.DateTime;
            parameters[10].Value = model.IsSalerSay;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void tool_chatlist_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}tool_chatList ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", SqlDbType.BigInt)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}

