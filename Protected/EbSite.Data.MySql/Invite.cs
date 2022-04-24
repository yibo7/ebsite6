using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;

namespace EbSite.Data.MySql
{
    /// <summary>
    /// 数据访问类a。
    /// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        private string sFieldInvite = "id,UserID,InviteUserID,InviteInviteNiName,AddDate";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int Invite_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}invite", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Invite_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}invite", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Invite Invite_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldInvite + "  from {0}invite ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.Invite model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Invite_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Invite_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}invite ", sPre);
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
        public DataSet Invite_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldInvite);
            strSql.AppendFormat(" FROM {0}invite ", sPre);
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
        public List<Entity.Invite> Invite_GetListArray(string strWhere)
        {
            return Invite_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Invite> Invite_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldInvite);
            strSql.AppendFormat(" FROM {0}Invite ", sPre);
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
            List<Entity.Invite> list = new List<Entity.Invite>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Invite_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Invite> Invite_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.Invite> list = new List<Entity.Invite>();
            RecordCount = Invite_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "invite", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Invite_ReaderBind(dataReader));
                }
            }

            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Invite Invite_ReaderBind(IDataReader dataReader)
        {
            Entity.Invite model = new Entity.Invite();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null)
            {
                model.id = (int)ojb;
            }
            model.UserID = dataReader["UserID"].ToString();
            ojb = dataReader["InviteUserID"];
            if (ojb != null)
            {
                model.InviteUserID = (int)ojb;
            }
            model.InviteInviteNiName = dataReader["InviteInviteNiName"].ToString();
            ojb = dataReader["AddDate"];
            if (ojb != null)
            {
                model.AddDate = (DateTime)ojb;
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Invite_Add(Entity.Invite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}invite(", sPre);
            strSql.Append("UserID,InviteUserID,InviteInviteNiName,AddDate)");
            strSql.Append(" values (");
            strSql.Append("?UserID,?InviteUserID,?InviteInviteNiName,?AddDate)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?UserID", MySqlDbType.VarChar,50),
					new MySqlParameter("?InviteUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?InviteInviteNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AddDate", MySqlDbType.Datetime)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.InviteUserID;
            parameters[2].Value = model.InviteInviteNiName;
            parameters[3].Value = model.AddDate;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
        public void Invite_Update(Entity.Invite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}invite set ", sPre);
            strSql.Append("UserID=?UserID,");
            strSql.Append("InviteUserID=?InviteUserID,");
            strSql.Append("InviteInviteNiName=?InviteInviteNiName,");
            strSql.Append("AddDate=?AddDate");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.VarChar,50),
					new MySqlParameter("?InviteUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?InviteInviteNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AddDate", MySqlDbType.Datetime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.InviteUserID;
            parameters[3].Value = model.InviteInviteNiName;
            parameters[4].Value = model.AddDate;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Invite_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}invite ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        #endregion 写

    }
}

