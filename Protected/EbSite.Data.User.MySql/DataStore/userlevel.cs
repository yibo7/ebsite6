using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;

namespace EbSite.Data.User.MySql
{
    /// <summary>
    /// 数据访问类。
    /// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
		private string sFielduserlevel = "id,LevelName,LevelId,ImgPath,MinCredit,MaxCredit";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int userlevel_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}userLevel", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool userlevel_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}userLevel", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.UserLevel userlevel_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFielduserlevel + "  from {0}userLevel ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.UserLevel model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = userlevel_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int userlevel_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}userLevel ", sPre);
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
        public DataSet userlevel_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFielduserlevel);
            strSql.AppendFormat(" FROM {0}userLevel ", sPre);
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
        public List<Entity.UserLevel> userlevel_GetListArray(string strWhere)
        {
            return userlevel_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.UserLevel> userlevel_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFielduserlevel);
            strSql.AppendFormat(" FROM {0}userLevel ", sPre);
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
            List<Entity.UserLevel> list = new List<Entity.UserLevel>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(userlevel_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.UserLevel> userlevel_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.UserLevel> list = new List<Entity.UserLevel>();
            RecordCount = userlevel_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "UserLevel", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(userlevel_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.UserLevel userlevel_ReaderBind(IDataReader dataReader)
        {
            Entity.UserLevel model = new Entity.UserLevel();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.LevelName = dataReader["LevelName"].ToString();
            ojb = dataReader["LevelId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LevelId = (int)ojb;
            }
            model.ImgPath = dataReader["ImgPath"].ToString();
            ojb = dataReader["MinCredit"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MinCredit = (int)ojb;
            }
            ojb = dataReader["MaxCredit"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MaxCredit = (int)ojb;
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int userlevel_Add(Entity.UserLevel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}userLevel(", sPre);
            strSql.Append("LevelName,LevelId,ImgPath,MinCredit,MaxCredit)");
            strSql.Append(" values (");
            strSql.Append("?LevelName,?LevelId,?ImgPath,?MinCredit,?MaxCredit)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LevelName", MySqlDbType.VarChar,50),
					new MySqlParameter("?LevelId", MySqlDbType.Int32,11),
					new MySqlParameter("?ImgPath", MySqlDbType.VarChar,200),
					new MySqlParameter("?MinCredit", MySqlDbType.Int32,11),
					new MySqlParameter("?MaxCredit", MySqlDbType.Int32,11)};
            parameters[0].Value = model.LevelName;
            parameters[1].Value = model.LevelId;
            parameters[2].Value = model.ImgPath;
            parameters[3].Value = model.MinCredit;
            parameters[4].Value = model.MaxCredit;

            object obj = DbHelperUserWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return userlevel_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void userlevel_Update(Entity.UserLevel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}userLevel set ", sPre);
            strSql.Append("LevelName=?LevelName,");
            strSql.Append("LevelId=?LevelId,");
            strSql.Append("ImgPath=?ImgPath,");
            strSql.Append("MinCredit=?MinCredit,");
            strSql.Append("MaxCredit=?MaxCredit");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?LevelName", MySqlDbType.VarChar,50),
					new MySqlParameter("?LevelId", MySqlDbType.Int32,11),
					new MySqlParameter("?ImgPath", MySqlDbType.VarChar,200),
					new MySqlParameter("?MinCredit", MySqlDbType.Int32,11),
					new MySqlParameter("?MaxCredit", MySqlDbType.Int32,11)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.LevelName;
            parameters[2].Value = model.LevelId;
            parameters[3].Value = model.ImgPath;
            parameters[4].Value = model.MinCredit;
            parameters[5].Value = model.MaxCredit;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void userlevel_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}userLevel ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}

