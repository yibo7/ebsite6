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
		private string sFieldexam_testresult = "id,ExamID,UserID,UserNiName,Score,ScoreLevel,Comment,AddDateTimeInt,AddDateTime";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int exam_testresult_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}exam_testresult", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool exam_testresult_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}exam_testresult", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.exam_testresult exam_testresult_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldexam_testresult + "  from {0}exam_testresult ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.exam_testresult model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = exam_testresult_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int exam_testresult_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}exam_testresult ", sPre);
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
        public DataSet exam_testresult_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldexam_testresult);
            strSql.AppendFormat(" FROM {0}exam_testresult ", sPre);
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
        public List<Entity.exam_testresult> exam_testresult_GetListArray(string strWhere)
        {
            return exam_testresult_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.exam_testresult> exam_testresult_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldexam_testresult);
            strSql.AppendFormat(" FROM {0}exam_testresult ", sPre);
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
            List<Entity.exam_testresult> list = new List<Entity.exam_testresult>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(exam_testresult_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.exam_testresult> exam_testresult_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.exam_testresult> list = new List<Entity.exam_testresult>();
            RecordCount = exam_testresult_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "exam_testresult", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(exam_testresult_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.exam_testresult exam_testresult_ReaderBind(IDataReader dataReader)
        {
            Entity.exam_testresult model = new Entity.exam_testresult();
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
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            model.UserNiName = dataReader["UserNiName"].ToString();
            ojb = dataReader["Score"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Score = (int)ojb;
            }
            ojb = dataReader["ScoreLevel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ScoreLevel = (int)ojb;
            }
            model.Comment = dataReader["Comment"].ToString();
            ojb = dataReader["AddDateTimeInt"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDateTimeInt = (int)ojb;
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
        public int exam_testresult_Add(Entity.exam_testresult model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}exam_testresult(", sPre);
            strSql.Append("ExamID,UserID,UserNiName,Score,ScoreLevel,Comment,AddDateTimeInt,AddDateTime)");
            strSql.Append(" values (");
            strSql.Append("?ExamID,?UserID,?UserNiName,?Score,?ScoreLevel,?Comment,?AddDateTimeInt,?AddDateTime)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ExamID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
					new MySqlParameter("?ScoreLevel", MySqlDbType.Int32,1),
					new MySqlParameter("?Comment", MySqlDbType.VarChar,500),
					new MySqlParameter("?AddDateTimeInt", MySqlDbType.Int32,11),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime)};
            parameters[0].Value = model.ExamID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserNiName;
            parameters[3].Value = model.Score;
            parameters[4].Value = model.ScoreLevel;
            parameters[5].Value = model.Comment;
            parameters[6].Value = model.AddDateTimeInt;
            parameters[7].Value = model.AddDateTime;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return exam_testresult_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void exam_testresult_Update(Entity.exam_testresult model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}exam_testresult set ", sPre);
            strSql.Append("ExamID=?ExamID,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("UserNiName=?UserNiName,");
            strSql.Append("Score=?Score,");
            strSql.Append("ScoreLevel=?ScoreLevel,");
            strSql.Append("Comment=?Comment,");
            strSql.Append("AddDateTimeInt=?AddDateTimeInt,");
            strSql.Append("AddDateTime=?AddDateTime");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?ExamID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
					new MySqlParameter("?ScoreLevel", MySqlDbType.Int32,1),
					new MySqlParameter("?Comment", MySqlDbType.VarChar,500),
					new MySqlParameter("?AddDateTimeInt", MySqlDbType.Int32,11),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.ExamID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserNiName;
            parameters[4].Value = model.Score;
            parameters[5].Value = model.ScoreLevel;
            parameters[6].Value = model.Comment;
            parameters[7].Value = model.AddDateTimeInt;
            parameters[8].Value = model.AddDateTime;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void exam_testresult_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}exam_testresult ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        #endregion 写

    }
}

