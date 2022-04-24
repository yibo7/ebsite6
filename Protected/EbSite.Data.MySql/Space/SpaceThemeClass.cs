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
        private string sFieldSpaceThemeClass = "id,ClassName,AddTime,UserGroupID";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int SpaceThemeClass_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}spacethemeclass", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool SpaceThemeClass_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}spacethemeclass", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.SpaceThemeClass SpaceThemeClass_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldSpaceThemeClass + "  from {0}spacethemeclass ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.SpaceThemeClass model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = SpaceThemeClass_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int SpaceThemeClass_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}spacethemeclass ", sPre);
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
        public DataSet SpaceThemeClass_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldSpaceThemeClass);
            strSql.AppendFormat(" FROM {0}spacethemeclass ", sPre);
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
        public List<Entity.SpaceThemeClass> SpaceThemeClass_GetListArray(string strWhere)
        {
            return SpaceThemeClass_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.SpaceThemeClass> SpaceThemeClass_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldSpaceThemeClass);
            strSql.AppendFormat(" FROM {0}spacethemeclass ", sPre);
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
            List<Entity.SpaceThemeClass> list = new List<Entity.SpaceThemeClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(SpaceThemeClass_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.SpaceThemeClass> SpaceThemeClass_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.SpaceThemeClass> list = new List<Entity.SpaceThemeClass>();

            RecordCount = SpaceThemeClass_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "spacethemeclass", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(SpaceThemeClass_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.SpaceThemeClass SpaceThemeClass_ReaderBind(IDataReader dataReader)
        {
            Entity.SpaceThemeClass model = new Entity.SpaceThemeClass();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.ClassName = dataReader["ClassName"].ToString();
            ojb = dataReader["AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddTime = (DateTime)ojb;
            }
            ojb = dataReader["UserGroupID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserGroupID = (int)ojb;
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int SpaceThemeClass_Add(Entity.SpaceThemeClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}spacethemeclass(", sPre);
            strSql.Append("ClassName,AddTime,UserGroupID)");
            strSql.Append(" values (");
            strSql.Append("?ClassName,?AddTime,?UserGroupID)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AddTime", MySqlDbType.Datetime),
                    new MySqlParameter("?UserGroupID",MySqlDbType.Int32 )};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.AddTime;
            parameters[2].Value = model.UserGroupID;

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
        public void SpaceThemeClass_Update(Entity.SpaceThemeClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}spacethemeclass set ", sPre);
            strSql.Append("ClassName=?ClassName,");
            strSql.Append("AddTime=?AddTime,");
            strSql.Append("UserGroupID=?UserGroupID");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AddTime", MySqlDbType.Datetime),
                    new MySqlParameter("?UserGroupID",MySqlDbType.Int32 ) };
            parameters[0].Value = model.id;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.UserGroupID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void SpaceThemeClass_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}spacethemeclass ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}

