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
		private string sFieldexam_answer = "id,TestResultID,Answer,UserID,QuestionId";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int exam_answer_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}exam_answer", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool exam_answer_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}exam_answer", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.exam_answer exam_answer_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldexam_answer + "  from {0}exam_answer ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.exam_answer model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = exam_answer_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int exam_answer_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}exam_answer ", sPre);
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
        public DataSet exam_answer_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldexam_answer);
            strSql.AppendFormat(" FROM {0}exam_answer ", sPre);
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
        public List<Entity.exam_answer> exam_answer_GetListArray(string strWhere)
        {
            return exam_answer_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.exam_answer> exam_answer_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldexam_answer);
            strSql.AppendFormat(" FROM {0}exam_answer ", sPre);
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
            List<Entity.exam_answer> list = new List<Entity.exam_answer>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(exam_answer_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.exam_answer> exam_answer_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.exam_answer> list = new List<Entity.exam_answer>();
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = exam_answer_GetCount(sbSql.ToString());
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "exam_answer", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(exam_answer_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.exam_answer exam_answer_ReaderBind(IDataReader dataReader)
        {
            Entity.exam_answer model = new Entity.exam_answer();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["TestResultID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TestResultID = (int)ojb;
            }
            model.Answer = dataReader["Answer"].ToString();
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            ojb = dataReader["QuestionId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.QuestionId = (int)ojb;
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int exam_answer_Add(Entity.exam_answer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}exam_answer(", sPre);
            strSql.Append("TestResultID,Answer,UserID,QuestionId)");
            strSql.Append(" values (");
            strSql.Append("?TestResultID,?Answer,?UserID,?QuestionId)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TestResultID", MySqlDbType.Int32,11),
					new MySqlParameter("?Answer", MySqlDbType.VarChar,300),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?QuestionId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.TestResultID;
            parameters[1].Value = model.Answer;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.QuestionId;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return exam_answer_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void exam_answer_Update(Entity.exam_answer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}exam_answer set ", sPre);
            strSql.Append("TestResultID=?TestResultID,");
            strSql.Append("Answer=?Answer,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("QuestionId=?QuestionId");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?TestResultID", MySqlDbType.Int32,11),
					new MySqlParameter("?Answer", MySqlDbType.VarChar,300),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?QuestionId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.TestResultID;
            parameters[2].Value = model.Answer;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.QuestionId;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void exam_answer_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}exam_answer ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        #endregion 写

    }
}

