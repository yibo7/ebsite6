using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类EbSitePlace。
	/// </summary>
	public partial class DataProviderCms : Interface.IDataProviderCms
	{
        private string sFieldSpaceThemes = "id,ThemeName,ThemePath,Author,UserID,AddTime,ThemeClassID,UserGroupID";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int SpaceThemes_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}spacethemes", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool SpaceThemes_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}spacethemes", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.SpaceThemes SpaceThemes_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldSpaceThemes + "  from {0}spacethemes ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.SpaceThemes model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = SpaceThemes_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int SpaceThemes_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}spacethemes ", sPre);
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
        public DataSet SpaceThemes_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldSpaceThemes);
            strSql.AppendFormat(" FROM {0}spacethemes ", sPre);
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
        public List<Entity.SpaceThemes> SpaceThemes_GetListArray(string strWhere)
        {
            return SpaceThemes_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.SpaceThemes> SpaceThemes_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldSpaceThemes);
            strSql.AppendFormat(" FROM {0}spacethemes  ", sPre);
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
            List<Entity.SpaceThemes> list = new List<Entity.SpaceThemes>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(SpaceThemes_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.SpaceThemes> SpaceThemes_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.SpaceThemes> list = new List<Entity.SpaceThemes>();
            RecordCount = SpaceThemes_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "spacethemes", PageSize, PageIndex, "", "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(SpaceThemes_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.SpaceThemes SpaceThemes_ReaderBind(IDataReader dataReader)
        {
            Entity.SpaceThemes model = new Entity.SpaceThemes();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.ThemeName = dataReader["ThemeName"].ToString();
            model.ThemePath = dataReader["ThemePath"].ToString();
            model.Author = dataReader["Author"].ToString();
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            ojb = dataReader["AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddTime = (DateTime)ojb;
            }

            ojb = dataReader["ThemeClassID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ThemeClassID = (int)ojb;
            }

            ojb = dataReader["UserGroupID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserGroupID = (int)ojb;
            }
            return model;
        }

        public string SpaceThemes_GetPathByID(int themeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select ThemePath  from {0}spacethemes ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = themeid;

            object oid = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (oid != null)
                return oid.ToString();
            return string.Empty;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int SpaceThemes_Add(Entity.SpaceThemes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}spacethemes(", sPre);
            strSql.Append("ThemeName,ThemePath,Author,UserID,AddTime)");
            strSql.Append(" values (");
            strSql.Append("?ThemeName,?ThemePath,?Author,?UserID,?AddTime)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ThemeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ThemePath", MySqlDbType.VarChar,50),
					new MySqlParameter("?Author", MySqlDbType.VarChar,10),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?AddTime", MySqlDbType.Datetime),
                    new MySqlParameter("?ThemeClassID", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserGroupID", MySqlDbType.Int32,4) };
            parameters[0].Value = model.ThemeName;
            parameters[1].Value = model.ThemePath;
            parameters[2].Value = model.Author;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.ThemeClassID;
            parameters[6].Value = model.UserGroupID;
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
        public void SpaceThemes_Update(Entity.SpaceThemes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}spacethemes set ", sPre);
            strSql.Append("ThemeName=?ThemeName,");
            strSql.Append("ThemePath=?ThemePath,");
            strSql.Append("Author=?Author,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("AddTime=?AddTime,");
            strSql.Append("ThemeClassID=?ThemeClassID,");
            strSql.Append("UserGroupID=?UserGroupID");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4),
					new MySqlParameter("?ThemeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ThemePath", MySqlDbType.VarChar,50),
					new MySqlParameter("?Author", MySqlDbType.VarChar,10),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?AddTime", MySqlDbType.Datetime),
                    new MySqlParameter("?ThemeClassID", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserGroupID", MySqlDbType.Int32,4) };
            parameters[0].Value = model.id;
            parameters[1].Value = model.ThemeName;
            parameters[2].Value = model.ThemePath;
            parameters[3].Value = model.Author;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.ThemeClassID;
            parameters[7].Value = model.UserGroupID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void SpaceThemes_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}spacethemes ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}

