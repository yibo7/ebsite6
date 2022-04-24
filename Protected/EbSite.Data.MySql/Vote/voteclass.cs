using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Data.MySql
{
    /// <summary>
    /// 数据访问类a。
    /// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{
		private string sFieldvoteclass = "id,ClassName,AddUserID,AddUserNiName,AddDateTime,AddDateTimeInt";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int voteclass_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}voteclass", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool voteclass_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}voteclass", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.voteclass voteclass_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldvoteclass + "  from {0}voteclass ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.voteclass model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = voteclass_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int voteclass_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}voteclass ", sPre);
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
        public DataSet voteclass_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldvoteclass);
            strSql.AppendFormat(" FROM {0}voteclass ", sPre);
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
        public List<Entity.voteclass> voteclass_GetListArray(string strWhere)
        {
            return voteclass_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.voteclass> voteclass_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldvoteclass);
            strSql.AppendFormat(" FROM {0}voteclass ", sPre);
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
            List<Entity.voteclass> list = new List<Entity.voteclass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(voteclass_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.voteclass> voteclass_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.voteclass> list = new List<Entity.voteclass>();
            RecordCount = voteclass_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "voteclass", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(voteclass_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.voteclass voteclass_ReaderBind(IDataReader dataReader)
        {
            Entity.voteclass model = new Entity.voteclass();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.ClassName = dataReader["ClassName"].ToString();
            ojb = dataReader["AddUserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddUserID = (int)ojb;
            }
            model.AddUserNiName = dataReader["AddUserNiName"].ToString();
            ojb = dataReader["AddDateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDateTime = (DateTime)ojb;
            }
            ojb = dataReader["AddDateTimeInt"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDateTimeInt = (int)ojb;
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int voteclass_Add(Entity.voteclass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}voteclass(", sPre);
            strSql.Append("ClassName,AddUserID,AddUserNiName,AddDateTime,AddDateTimeInt)");
            strSql.Append(" values (");
            strSql.Append("?ClassName,?AddUserID,?AddUserNiName,?AddDateTime,?AddDateTimeInt)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,255),
					new MySqlParameter("?AddUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?AddUserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
					new MySqlParameter("?AddDateTimeInt", MySqlDbType.Int32,11)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.AddUserID;
            parameters[2].Value = model.AddUserNiName;
            parameters[3].Value = model.AddDateTime;
            parameters[4].Value = model.AddDateTimeInt;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return voteclass_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void voteclass_Update(Entity.voteclass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}voteclass set ", sPre);
            strSql.Append("ClassName=?ClassName,");
            strSql.Append("AddUserID=?AddUserID,");
            strSql.Append("AddUserNiName=?AddUserNiName,");
            strSql.Append("AddDateTime=?AddDateTime,");
            strSql.Append("AddDateTimeInt=?AddDateTimeInt");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,255),
					new MySqlParameter("?AddUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?AddUserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
					new MySqlParameter("?AddDateTimeInt", MySqlDbType.Int32,11)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.AddUserID;
            parameters[3].Value = model.AddUserNiName;
            parameters[4].Value = model.AddDateTime;
            parameters[5].Value = model.AddDateTimeInt;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void voteclass_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}voteclass ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        #endregion 写

    }
}

