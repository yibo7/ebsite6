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
		private string sFieldexam_questionsclass = "id,ExamID,ClassName,AddUserID,AddDateTime";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int exam_questionsclass_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}exam_questionsclass", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool exam_questionsclass_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}exam_questionsclass", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.exam_questionsclass exam_questionsclass_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldexam_questionsclass + "  from {0}exam_questionsclass ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.exam_questionsclass model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = exam_questionsclass_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int exam_questionsclass_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}exam_questionsclass ", sPre);
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
        public DataSet exam_questionsclass_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldexam_questionsclass);
            strSql.AppendFormat(" FROM {0}exam_questionsclass ", sPre);
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
        public List<Entity.exam_questionsclass> exam_questionsclass_GetListArray(string strWhere)
        {
            return exam_questionsclass_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.exam_questionsclass> exam_questionsclass_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldexam_questionsclass);
            strSql.AppendFormat(" FROM {0}exam_questionsclass ", sPre);
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
            List<Entity.exam_questionsclass> list = new List<Entity.exam_questionsclass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(exam_questionsclass_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.exam_questionsclass> exam_questionsclass_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.exam_questionsclass> list = new List<Entity.exam_questionsclass>();
            RecordCount = exam_questionsclass_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "exam_questionsclass", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(exam_questionsclass_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.exam_questionsclass exam_questionsclass_ReaderBind(IDataReader dataReader)
        {
            Entity.exam_questionsclass model = new Entity.exam_questionsclass();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["ExamID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ExamID = (int)ojb;
            }
            model.ClassName = dataReader["ClassName"].ToString();
            ojb = dataReader["AddUserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddUserID = (int)ojb;
            }
            ojb = dataReader["AddDateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDateTime = (DateTime)ojb;
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int exam_questionsclass_Add(Entity.exam_questionsclass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}exam_questionsclass(", sPre);
            strSql.Append("ExamID,ClassName,AddUserID,AddDateTime)");
            strSql.Append(" values (");
            strSql.Append("?ExamID,?ClassName,?AddUserID,?AddDateTime)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ExamID", MySqlDbType.Int32,11),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AddUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime)};
            parameters[0].Value = model.ExamID;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.AddUserID;
            parameters[3].Value = model.AddDateTime;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return exam_questionsclass_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void exam_questionsclass_Update(Entity.exam_questionsclass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}exam_questionsclass set ", sPre);
            strSql.Append("ExamID=?ExamID,");
            strSql.Append("ClassName=?ClassName,");
            strSql.Append("AddUserID=?AddUserID,");
            strSql.Append("AddDateTime=?AddDateTime");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?ExamID", MySqlDbType.Int32,11),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AddUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.ExamID;
            parameters[2].Value = model.ClassName;
            parameters[3].Value = model.AddUserID;
            parameters[4].Value = model.AddDateTime;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void exam_questionsclass_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}exam_questionsclass ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}

