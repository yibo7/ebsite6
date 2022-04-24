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
        private string sFieldexam_questions = "id,ExamID,ClassID,QuestionsType,Questions,AnswerInput,AnswerJudge,AnswerA,AnswerB,AnswerC,AnswerD,AnswerE,AnswerF,AnswerG,RightABC,Analysis,AddDateTimeInt,AddUserID,AddUserNiName,RightUserCount,ErrorUserCount,OrderID,Score";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int exam_questions_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}exam_questions", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool exam_questions_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}exam_questions", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.exam_questions exam_questions_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldexam_questions + "  from {0}exam_questions ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.exam_questions model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = exam_questions_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int exam_questions_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}exam_questions ", sPre);
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
        public DataSet exam_questions_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldexam_questions);
            strSql.AppendFormat(" FROM {0}exam_questions ", sPre);
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
        public List<Entity.exam_questions> exam_questions_GetListArray(string strWhere)
        {
            return exam_questions_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.exam_questions> exam_questions_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldexam_questions);
            strSql.AppendFormat(" FROM {0}exam_questions ", sPre);
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
            List<Entity.exam_questions> list = new List<Entity.exam_questions>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(exam_questions_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.exam_questions> exam_questions_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.exam_questions> list = new List<Entity.exam_questions>();
            RecordCount = exam_questions_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "exam_questions", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(exam_questions_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.exam_questions exam_questions_ReaderBind(IDataReader dataReader)
        {
            Entity.exam_questions model = new Entity.exam_questions();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["ExamID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ExamID = int.Parse(ojb.ToString());
            }
            ojb = dataReader["ClassID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ClassID = int.Parse(ojb.ToString());
            }
            ojb = dataReader["QuestionsType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.QuestionsType = int.Parse(ojb.ToString());
            }
            model.Questions = dataReader["Questions"].ToString();
            model.AnswerInput = dataReader["AnswerInput"].ToString();
            ojb = dataReader["AnswerJudge"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AnswerJudge = (bool)ojb;
            }
            model.AnswerA = dataReader["AnswerA"].ToString();
            model.AnswerB = dataReader["AnswerB"].ToString();
            model.AnswerC = dataReader["AnswerC"].ToString();
            model.AnswerD = dataReader["AnswerD"].ToString();
            model.AnswerE = dataReader["AnswerE"].ToString();
            model.AnswerF = dataReader["AnswerF"].ToString();
            model.AnswerG = dataReader["AnswerG"].ToString();
            model.RightABC = dataReader["RightABC"].ToString();
            model.Analysis = dataReader["Analysis"].ToString();
            ojb = dataReader["AddDateTimeInt"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDateTimeInt = int.Parse(ojb.ToString());
            }
            ojb = dataReader["AddUserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddUserID = int.Parse(ojb.ToString());
            }
            model.AddUserNiName = dataReader["AddUserNiName"].ToString();
            ojb = dataReader["RightUserCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RightUserCount = int.Parse(ojb.ToString());
            }
            ojb = dataReader["ErrorUserCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ErrorUserCount = int.Parse(ojb.ToString());
            }
            ojb = dataReader["OrderID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderID = int.Parse(ojb.ToString());
            }
            ojb = dataReader["Score"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Score = decimal.Parse(ojb.ToString());
            }
            
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int exam_questions_Add(Entity.exam_questions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}exam_questions(", sPre);
            strSql.Append("ExamID,ClassID,QuestionsType,Questions,AnswerInput,AnswerJudge,AnswerA,AnswerB,AnswerC,AnswerD,AnswerE,AnswerF,AnswerG,RightABC,Analysis,AddDateTimeInt,AddUserID,AddUserNiName,RightUserCount,ErrorUserCount,OrderID,Score)");
            strSql.Append(" values (");
            strSql.Append("?ExamID,?ClassID,?QuestionsType,?Questions,?AnswerInput,?AnswerJudge,?AnswerA,?AnswerB,?AnswerC,?AnswerD,?AnswerE,?AnswerF,?AnswerG,?RightABC,?Analysis,?AddDateTimeInt,?AddUserID,?AddUserNiName,?RightUserCount,?ErrorUserCount,?OrderID,?Score)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ExamID", MySqlDbType.Int32,11),
					new MySqlParameter("?ClassID", MySqlDbType.Int32,11),
					new MySqlParameter("?QuestionsType", MySqlDbType.Int32,1),
					new MySqlParameter("?Questions", MySqlDbType.VarChar,500),
					new MySqlParameter("?AnswerInput", MySqlDbType.VarChar,300),
					new MySqlParameter("?AnswerJudge", MySqlDbType.Int16,1),
					new MySqlParameter("?AnswerA", MySqlDbType.VarChar,200),
					new MySqlParameter("?AnswerB", MySqlDbType.VarChar,200),
					new MySqlParameter("?AnswerC", MySqlDbType.VarChar,200),
					new MySqlParameter("?AnswerD", MySqlDbType.VarChar,200),
					new MySqlParameter("?AnswerE", MySqlDbType.VarChar,200),
					new MySqlParameter("?AnswerF", MySqlDbType.VarChar,200),
					new MySqlParameter("?AnswerG", MySqlDbType.VarChar,200),
					new MySqlParameter("?RightABC", MySqlDbType.VarChar,7),
					new MySqlParameter("?Analysis", MySqlDbType.VarChar,500),
					new MySqlParameter("?AddDateTimeInt", MySqlDbType.Int32,11),
					new MySqlParameter("?AddUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?AddUserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?RightUserCount", MySqlDbType.Int32,11),
					new MySqlParameter("?ErrorUserCount", MySqlDbType.Int32,11),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,11),
                    new MySqlParameter("?Score", MySqlDbType.Decimal,11)
                                          };
            parameters[0].Value = model.ExamID;
            parameters[1].Value = model.ClassID;
            parameters[2].Value = model.QuestionsType;
            parameters[3].Value = model.Questions;
            parameters[4].Value = model.AnswerInput;
            parameters[5].Value = model.AnswerJudge;
            parameters[6].Value = model.AnswerA;
            parameters[7].Value = model.AnswerB;
            parameters[8].Value = model.AnswerC;
            parameters[9].Value = model.AnswerD;
            parameters[10].Value = model.AnswerE;
            parameters[11].Value = model.AnswerF;
            parameters[12].Value = model.AnswerG;
            parameters[13].Value = model.RightABC;
            parameters[14].Value = model.Analysis;
            parameters[15].Value = model.AddDateTimeInt;
            parameters[16].Value = model.AddUserID;
            parameters[17].Value = model.AddUserNiName;
            parameters[18].Value = model.RightUserCount;
            parameters[19].Value = model.ErrorUserCount;
            parameters[20].Value = model.OrderID;
            parameters[21].Value = model.Score;
            

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return exam_questions_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void exam_questions_Update(Entity.exam_questions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}exam_questions set ", sPre);
            strSql.Append("ExamID=?ExamID,");
            strSql.Append("ClassID=?ClassID,");
            strSql.Append("QuestionsType=?QuestionsType,");
            strSql.Append("Questions=?Questions,");
            strSql.Append("AnswerInput=?AnswerInput,");
            strSql.Append("AnswerJudge=?AnswerJudge,");
            strSql.Append("AnswerA=?AnswerA,");
            strSql.Append("AnswerB=?AnswerB,");
            strSql.Append("AnswerC=?AnswerC,");
            strSql.Append("AnswerD=?AnswerD,");
            strSql.Append("AnswerE=?AnswerE,");
            strSql.Append("AnswerF=?AnswerF,");
            strSql.Append("AnswerG=?AnswerG,");
            strSql.Append("RightABC=?RightABC,");
            strSql.Append("Analysis=?Analysis,");
            strSql.Append("AddDateTimeInt=?AddDateTimeInt,");
            strSql.Append("AddUserID=?AddUserID,");
            strSql.Append("AddUserNiName=?AddUserNiName,");
            strSql.Append("RightUserCount=?RightUserCount,");
            strSql.Append("ErrorUserCount=?ErrorUserCount,");
            strSql.Append("OrderID=?OrderID,");
            strSql.Append("Score=?Score");
            
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?ExamID", MySqlDbType.Int32,11),
					new MySqlParameter("?ClassID", MySqlDbType.Int32,11),
					new MySqlParameter("?QuestionsType", MySqlDbType.Int32,1),
					new MySqlParameter("?Questions", MySqlDbType.VarChar,500),
					new MySqlParameter("?AnswerInput", MySqlDbType.VarChar,300),
					new MySqlParameter("?AnswerJudge", MySqlDbType.Int16,1),
					new MySqlParameter("?AnswerA", MySqlDbType.VarChar,200),
					new MySqlParameter("?AnswerB", MySqlDbType.VarChar,200),
					new MySqlParameter("?AnswerC", MySqlDbType.VarChar,200),
					new MySqlParameter("?AnswerD", MySqlDbType.VarChar,200),
					new MySqlParameter("?AnswerE", MySqlDbType.VarChar,200),
					new MySqlParameter("?AnswerF", MySqlDbType.VarChar,200),
					new MySqlParameter("?AnswerG", MySqlDbType.VarChar,200),
					new MySqlParameter("?RightABC", MySqlDbType.VarChar,7),
					new MySqlParameter("?Analysis", MySqlDbType.VarChar,500),
					new MySqlParameter("?AddDateTimeInt", MySqlDbType.Int32,11),
					new MySqlParameter("?AddUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?AddUserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?RightUserCount", MySqlDbType.Int32,11),
					new MySqlParameter("?ErrorUserCount", MySqlDbType.Int32,11),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,11),
                    new MySqlParameter("?Score", MySqlDbType.Decimal,11)                
                                          };
            parameters[0].Value = model.id;
            parameters[1].Value = model.ExamID;
            parameters[2].Value = model.ClassID;
            parameters[3].Value = model.QuestionsType;
            parameters[4].Value = model.Questions;
            parameters[5].Value = model.AnswerInput;
            parameters[6].Value = model.AnswerJudge;
            parameters[7].Value = model.AnswerA;
            parameters[8].Value = model.AnswerB;
            parameters[9].Value = model.AnswerC;
            parameters[10].Value = model.AnswerD;
            parameters[11].Value = model.AnswerE;
            parameters[12].Value = model.AnswerF;
            parameters[13].Value = model.AnswerG;
            parameters[14].Value = model.RightABC;
            parameters[15].Value = model.Analysis;
            parameters[16].Value = model.AddDateTimeInt;
            parameters[17].Value = model.AddUserID;
            parameters[18].Value = model.AddUserNiName;
            parameters[19].Value = model.RightUserCount;
            parameters[20].Value = model.ErrorUserCount;
            parameters[21].Value = model.OrderID;
            parameters[22].Value = model.Score;
            

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void exam_questions_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}exam_questions ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        #endregion 写

    }
}

