using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;

namespace EbSite.Data.User.MySql
{
	/// <summary>
	/// 数据访问类aaa。
	/// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
		private string sFieldemailsendpool = "id,Title,MsgBody,SendToUserID,SendToEmail,AttaUrl,AddDateTime,AddDateTimeInc,AddUserID,AddUserNiName,IsSended";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int emailsendpool_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}emailsendpool", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool emailsendpool_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}emailsendpool", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.emailsendpool emailsendpool_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldemailsendpool + "  from {0}emailsendpool ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.emailsendpool model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = emailsendpool_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int emailsendpool_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}emailsendpool ", sPre);
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
        public DataSet emailsendpool_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldemailsendpool);
            strSql.AppendFormat(" FROM {0}emailsendpool ", sPre);
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
        public List<Entity.emailsendpool> emailsendpool_GetListArray(string strWhere)
        {
            return emailsendpool_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.emailsendpool> emailsendpool_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldemailsendpool);
            strSql.AppendFormat(" FROM {0}emailsendpool ", sPre);
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
            List<Entity.emailsendpool> list = new List<Entity.emailsendpool>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(emailsendpool_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.emailsendpool> emailsendpool_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.emailsendpool> list = new List<Entity.emailsendpool>();
            RecordCount = emailsendpool_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "emailsendpool", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(emailsendpool_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.emailsendpool emailsendpool_ReaderBind(IDataReader dataReader)
        {
            Entity.emailsendpool model = new Entity.emailsendpool();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.Title = dataReader["Title"].ToString();
            model.MsgBody = dataReader["MsgBody"].ToString();
            ojb = dataReader["SendToUserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SendToUserID = (int)ojb;
            }
            model.SendToEmail = dataReader["SendToEmail"].ToString();
            model.AttaUrl = dataReader["AttaUrl"].ToString();
            ojb = dataReader["AddDateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDateTime = (DateTime)ojb;
            }
            ojb = dataReader["AddDateTimeInc"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDateTimeInc = (int)ojb;
            }
            ojb = dataReader["AddUserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddUserID = (int)ojb;
            }
            model.AddUserNiName = dataReader["AddUserNiName"].ToString();
            ojb = dataReader["IsSended"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsSended = (int)ojb;
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int emailsendpool_Add(Entity.emailsendpool model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}emailsendpool(", sPre);
            strSql.Append("Title,MsgBody,SendToUserID,SendToEmail,AttaUrl,AddDateTime,AddDateTimeInc,AddUserID,AddUserNiName,IsSended)");
            strSql.Append(" values (");
            strSql.Append("?Title,?MsgBody,?SendToUserID,?SendToEmail,?AttaUrl,?AddDateTime,?AddDateTimeInc,?AddUserID,?AddUserNiName,?IsSended)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Title", MySqlDbType.VarChar,300),
					new MySqlParameter("?MsgBody", MySqlDbType.Text),
					new MySqlParameter("?SendToUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?SendToEmail", MySqlDbType.VarChar,40),
					new MySqlParameter("?AttaUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
					new MySqlParameter("?AddDateTimeInc", MySqlDbType.Int32,11),
					new MySqlParameter("?AddUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?AddUserNiName", MySqlDbType.VarChar,30),
					new MySqlParameter("?IsSended", MySqlDbType.Int32,1)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.MsgBody;
            parameters[2].Value = model.SendToUserID;
            parameters[3].Value = model.SendToEmail;
            parameters[4].Value = model.AttaUrl;
            parameters[5].Value = model.AddDateTime;
            parameters[6].Value = model.AddDateTimeInc;
            parameters[7].Value = model.AddUserID;
            parameters[8].Value = model.AddUserNiName;
            parameters[9].Value = model.IsSended;

            object obj = DbHelperUserWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return emailsendpool_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void emailsendpool_Update(Entity.emailsendpool model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}emailsendpool set ", sPre);
            strSql.Append("Title=?Title,");
            strSql.Append("MsgBody=?MsgBody,");
            strSql.Append("SendToUserID=?SendToUserID,");
            strSql.Append("SendToEmail=?SendToEmail,");
            strSql.Append("AttaUrl=?AttaUrl,");
            strSql.Append("AddDateTime=?AddDateTime,");
            strSql.Append("AddDateTimeInc=?AddDateTimeInc,");
            strSql.Append("AddUserID=?AddUserID,");
            strSql.Append("AddUserNiName=?AddUserNiName,");
            strSql.Append("IsSended=?IsSended");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?Title", MySqlDbType.VarChar,300),
					new MySqlParameter("?MsgBody", MySqlDbType.Text),
					new MySqlParameter("?SendToUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?SendToEmail", MySqlDbType.VarChar,40),
					new MySqlParameter("?AttaUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
					new MySqlParameter("?AddDateTimeInc", MySqlDbType.Int32,11),
					new MySqlParameter("?AddUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?AddUserNiName", MySqlDbType.VarChar,30),
					new MySqlParameter("?IsSended", MySqlDbType.Int32,1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.MsgBody;
            parameters[3].Value = model.SendToUserID;
            parameters[4].Value = model.SendToEmail;
            parameters[5].Value = model.AttaUrl;
            parameters[6].Value = model.AddDateTime;
            parameters[7].Value = model.AddDateTimeInc;
            parameters[8].Value = model.AddUserID;
            parameters[9].Value = model.AddUserNiName;
            parameters[10].Value = model.IsSended;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void emailsendpool_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}emailsendpool ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}

