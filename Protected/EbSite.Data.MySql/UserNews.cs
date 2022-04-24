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
        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int UserNews_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("ID", string.Format("{0}usernews",0));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool UserNews_Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}usernews", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.UserNews UserNews_GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select   ID,UserName,NewsInfo,AddDateTime from {0}usernews ", sPre);
            strSql.Append(" where ID=?ID  limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;


            Entity.UserNews model = new Entity.UserNews();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = UserNews_ReaderBind(dataReader);

                }
            }
            return model;

        }



        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.UserNews> UserNews_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(" ID,UserName,NewsInfo,AddDateTime ");
            strSql.AppendFormat(" FROM {0}usernews ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }

            List<EbSite.Entity.UserNews> list = new List<EbSite.Entity.UserNews>();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(UserNews_ReaderBind(dataReader));
                }
            }
            return list;

        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.UserNews UserNews_ReaderBind(IDataReader dataReader)
        {
            Entity.UserNews model = new Entity.UserNews();

            if (dataReader["ID"].ToString() != "")
            {
                model.ID = int.Parse(dataReader["ID"].ToString());
            }
            model.UserName = dataReader["UserName"].ToString();
            model.NewsInfo = dataReader["NewsInfo"].ToString();
            if (dataReader["AddDateTime"].ToString() != "")
            {
                model.AddDateTime = DateTime.Parse(dataReader["AddDateTime"].ToString());
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int UserNews_Add(Entity.UserNews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}usernews(", sPre);
            strSql.Append("UserName,NewsInfo,AddDateTime)");
            strSql.Append(" values (");
            strSql.Append("?UserName,?NewsInfo,?AddDateTime)");

            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?NewsInfo", MySqlDbType.VarChar,500),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.NewsInfo;
            parameters[2].Value = model.AddDateTime;

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
        public void UserNews_Update(Entity.UserNews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}usernews set ", sPre);
            strSql.Append("UserName=?UserName,");
            strSql.Append("NewsInfo=?NewsInfo,");
            strSql.Append("AddDateTime=?AddDateTime");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?NewsInfo", MySqlDbType.VarChar,500),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.NewsInfo;
            parameters[3].Value = model.AddDateTime;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void UserNews_Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}usernews ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写
	}
}

