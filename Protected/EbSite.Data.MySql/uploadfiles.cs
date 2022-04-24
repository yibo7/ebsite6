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
		private string sFielduploadfiles = "id,IsSave,AddDate,FileNewName,FileOldName";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int uploadfiles_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}uploadfiles", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool uploadfiles_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}uploadfiles", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.UploadFileInfo uploadfiles_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFielduploadfiles + "  from {0}uploadfiles ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.UploadFileInfo model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = uploadfiles_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int uploadfiles_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}uploadfiles ", sPre);
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
        public DataSet uploadfiles_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFielduploadfiles);
            strSql.AppendFormat(" FROM {0}uploadfiles ", sPre);
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
        public List<Entity.UploadFileInfo> uploadfiles_GetListArray(string strWhere)
        {
            return uploadfiles_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.UploadFileInfo> uploadfiles_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFielduploadfiles);
            strSql.AppendFormat(" FROM {0}uploadfiles ", sPre);
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
            List<Entity.UploadFileInfo> list = new List<Entity.UploadFileInfo>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(uploadfiles_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.UploadFileInfo> uploadfiles_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.UploadFileInfo> list = new List<Entity.UploadFileInfo>();
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = uploadfiles_GetCount(sbSql.ToString());
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "uploadfiles", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(uploadfiles_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.UploadFileInfo uploadfiles_ReaderBind(IDataReader dataReader)
        {
            Entity.UploadFileInfo model = new Entity.UploadFileInfo();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["IsSave"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if ((dataReader["IsSave"].ToString() == "1") || (dataReader["IsSave"].ToString().ToLower() == "true"))
                {
                    model.IsSave = true;
                }
                else
                {
                    model.IsSave = false;
                }
            }
            ojb = dataReader["AddDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDate = (DateTime)ojb;
            }
            model.FileNewName = dataReader["FileNewName"].ToString();
            model.FileOldName = dataReader["FileOldName"].ToString();
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int uploadfiles_Add(Entity.UploadFileInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}uploadfiles(", sPre);
            strSql.Append("IsSave,AddDate,FileNewName,FileOldName)");
            strSql.Append(" values (");
            strSql.Append("?IsSave,?AddDate,?FileNewName,?FileOldName)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?IsSave", MySqlDbType.Int16,2),
					new MySqlParameter("?AddDate", MySqlDbType.DateTime),
					new MySqlParameter("?FileNewName", MySqlDbType.VarChar,200),
					new MySqlParameter("?FileOldName", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.IsSave;
            parameters[1].Value = model.AddDate;
            parameters[2].Value = model.FileNewName;
            parameters[3].Value = model.FileOldName;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return uploadfiles_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void uploadfiles_Update(Entity.UploadFileInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}uploadfiles set ", sPre);
            strSql.Append("IsSave=?IsSave,");
            strSql.Append("AddDate=?AddDate,");
            strSql.Append("FileNewName=?FileNewName,");
            strSql.Append("FileOldName=?FileOldName");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?IsSave", MySqlDbType.Int16,2),
					new MySqlParameter("?AddDate", MySqlDbType.DateTime),
					new MySqlParameter("?FileNewName", MySqlDbType.VarChar,200),
					new MySqlParameter("?FileOldName", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.IsSave;
            parameters[2].Value = model.AddDate;
            parameters[3].Value = model.FileNewName;
            parameters[4].Value = model.FileOldName;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void uploadfiles_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}uploadfiles ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

	}
}

