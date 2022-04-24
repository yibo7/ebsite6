using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Wenda.ModuleCore.DAL.MySQL
{
    /// <summary>
    /// 数据访问类Ask。
    /// </summary>
    public partial class Ask
    {
        private string sFieldAnswers = "id,QID,QUserID,AnswerUserID,AnswerContent,IsAdoption,AnswerTime,IsDel,AnswerIP,ReferBook,IsAnonymity,AnswerUpdateTime,Score,GoodAsk,IsApproved,ThanksInfo";
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int Answers_GetMaxId()
        {
            return DB.GetMaxID("id", string.Format("{0}Answers", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Answers_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}Answers", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DB.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Answers_Add(Entity.Answers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}Answers(", sPre);
            strSql.Append("QID,QUserID,AnswerUserID,AnswerContent,IsAdoption,AnswerTime,IsDel,AnswerIP,ReferBook,IsAnonymity,AnswerUpdateTime,Score,GoodAsk,IsApproved,ThanksInfo)");
            strSql.Append(" values (");
            strSql.Append("?QID,?QUserID,?AnswerUserID,?AnswerContent,?IsAdoption,?AnswerTime,?IsDel,?AnswerIP,?ReferBook,?IsAnonymity,?AnswerUpdateTime,?Score,?GoodAsk,?IsApproved,?ThanksInfo)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?QID", MySqlDbType.Int32,4),
					new MySqlParameter("?QUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?AnswerUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?AnswerContent", MySqlDbType.Text),
					new MySqlParameter("?IsAdoption", MySqlDbType.Bit,1),
					new MySqlParameter("?AnswerTime", MySqlDbType.Datetime),
					new MySqlParameter("?IsDel", MySqlDbType.Bit,1),
					new MySqlParameter("?AnswerIP", MySqlDbType.VarChar,100),
					new MySqlParameter("?ReferBook", MySqlDbType.VarChar,1000),
					new MySqlParameter("?IsAnonymity", MySqlDbType.Bit,1),
					new MySqlParameter("?AnswerUpdateTime", MySqlDbType.Datetime),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
                    new MySqlParameter("?GoodAsk",MySqlDbType.UInt32,4),
                    new MySqlParameter("?IsApproved",MySqlDbType.Int32,4),
                    new MySqlParameter("?ThanksInfo",MySqlDbType.Text) };

            parameters[0].Value = model.QID;
            parameters[1].Value = model.QUserID;
            parameters[2].Value = model.AnswerUserID;
            parameters[3].Value = model.AnswerContent;
            parameters[4].Value = model.IsAdoption;
            parameters[5].Value = model.AnswerTime;
            parameters[6].Value = model.IsDel;
            parameters[7].Value = model.AnswerIP;
            parameters[8].Value = model.ReferBook;
            parameters[9].Value = model.IsAnonymity;
            parameters[10].Value = model.AnswerUpdateTime;
            parameters[11].Value = model.Score;
            parameters[12].Value = model.GoodAsk;
            parameters[13].Value = model.IsApproved;
            parameters[14].Value = model.ThanksInfo;

            object obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Answers_Update(Entity.Answers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}Answers set ", sPre);
            strSql.Append("QID=?QID,");
            strSql.Append("QUserID=?QUserID,");
            strSql.Append("AnswerUserID=?AnswerUserID,");
            strSql.Append("AnswerContent=?AnswerContent,");
            strSql.Append("IsAdoption=?IsAdoption,");
            strSql.Append("AnswerTime=?AnswerTime,");
            strSql.Append("IsDel=?IsDel,");
            strSql.Append("AnswerIP=?AnswerIP,");
            strSql.Append("ReferBook=?ReferBook,");
            strSql.Append("IsAnonymity=?IsAnonymity,");
            strSql.Append("AnswerUpdateTime=?AnswerUpdateTime,");
            strSql.Append("Score=?Score,");
            strSql.Append("GoodAsk=?GoodAsk ,");
            strSql.Append("IsApproved=?IsApproved,");
            strSql.Append("ThanksInfo=?ThanksInfo");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?QID", MySqlDbType.Int32,4),
					new MySqlParameter("?QUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?AnswerUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?AnswerContent", MySqlDbType.Text),
					new MySqlParameter("?IsAdoption", MySqlDbType.Bit,1),
					new MySqlParameter("?AnswerTime", MySqlDbType.Datetime),
					new MySqlParameter("?IsDel", MySqlDbType.Bit,1),
					new MySqlParameter("?AnswerIP", MySqlDbType.VarChar,50),
					new MySqlParameter("?ReferBook", MySqlDbType.VarChar,1000),
					new MySqlParameter("?IsAnonymity", MySqlDbType.Bit,1),
					new MySqlParameter("?AnswerUpdateTime", MySqlDbType.Datetime),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
                    new MySqlParameter("?GoodAsk", MySqlDbType.Int32,4),
                    new MySqlParameter("?IsApproved",MySqlDbType.Int32,4),
                    new MySqlParameter("?ThanksInfo",MySqlDbType.Text) };
            parameters[0].Value = model.id;
            parameters[1].Value = model.QID;
            parameters[2].Value = model.QUserID;
            parameters[3].Value = model.AnswerUserID;
            parameters[4].Value = model.AnswerContent;
            parameters[5].Value = model.IsAdoption;
            parameters[6].Value = model.AnswerTime;
            parameters[7].Value = model.IsDel;
            parameters[8].Value = model.AnswerIP;
            parameters[9].Value = model.ReferBook;
            parameters[10].Value = model.IsAnonymity;
            parameters[11].Value = model.AnswerUpdateTime;
            parameters[12].Value = model.Score;
            parameters[13].Value = model.GoodAsk;
            parameters[14].Value = model.IsApproved;
            parameters[15].Value = model.ThanksInfo;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Answers_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Answers ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Answers Answers_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldAnswers + "  from {0}Answers ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.Answers model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Answers_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Answers_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}Answers ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            int iCount = 0;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    iCount = int.Parse(dataReader[0].ToString());
                }
            }
            return iCount;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Answers_GetCountEx(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}Answers a", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append("  " + strWhere);
            }
            int iCount = 0;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
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
        public DataSet Answers_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldAnswers);
            strSql.AppendFormat(" FROM {0}Answers ", sPre);
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
            return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.Answers> Answers_GetListArray(string strWhere)
        {
            return Answers_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Answers> Answers_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldAnswers);
            strSql.AppendFormat(" FROM {0}Answers ", sPre);
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
            List<Entity.Answers> list = new List<Entity.Answers>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Answers_ReaderBind(dataReader));
                }
            }

            return list;
        }




        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Answers> Answers_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            //List<Entity.Answers> list = new List<Entity.Answers>();
            //RecordCount = Answers_GetCount(strWhere);
            //string strSql = SplitPages.GetSplitPagesMySql(DB, "Answers", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            //using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            //{
            //    while (dataReader.Read())
            //    {
            //        list.Add(Answers_ReaderBind(dataReader));
            //    }
            //}
            //return list;
            string stwhere = strWhere;
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
                stwhere = string.Concat(" where ", stwhere);
            }
            RecordCount = Answers_GetCountEx(sbSql.ToString());

            string orderbyStr = "";
            if (!string.IsNullOrEmpty(oderby))
            {
                orderbyStr =" order by "+ oderby;
            }
            List<Entity.Answers> list = new List<Entity.Answers>();
            if (PageIndex > 0)
            {
                PageIndex--;
            }
             int numStart = PageIndex * PageSize;
            string strSql =
                string.Format(
                    "select a.id,a.qid,a.AnswerTime,a.IsAdoption,a.AnswerContent,a.IsApproved, b.NewsTitle,b.classid,b.SiteID  from ask_Answers  a left outer join eb_newscontent b on a.QID=b.ID    {2} {3} limit {0},{1}",
                    numStart, PageSize, stwhere, orderbyStr);
           // string strSql = SplitPages.GetSplitPagesMySql(DB, "ask_Answers", "eb_newscontent", PageSize, PageIndex, "{0}.id,{0}.qid,{0}.AnswerTime,{0}.IsAdoption,{0}.AnswerContent,{1}.NewsTitle", "qid", "id", oderby, sbSql.ToString(), "");
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(AnswersEX_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Answers Answers_ReaderBind(IDataReader dataReader)
        {
            Entity.Answers model = new Entity.Answers();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["QID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.QID = (int)ojb;
            }
            ojb = dataReader["QUserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.QUserID = (int)ojb;
            }
            ojb = dataReader["AnswerUserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AnswerUserID = (int)ojb;
            }

            model.ThanksInfo = dataReader["ThanksInfo"].ToString();
            model.AnswerContent = dataReader["AnswerContent"].ToString();
            ojb = dataReader["IsAdoption"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if ((dataReader["IsAdoption"].ToString() == "1") || (dataReader["IsAdoption"].ToString().ToLower() == "true"))
                {
                    model.IsAdoption = true;
                }
                else
                {
                    model.IsAdoption = false;
                }
                // model.IsAdoption = (bool)ojb;
            }
            ojb = dataReader["AnswerTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AnswerTime = (DateTime)ojb;
            }
            ojb = dataReader["IsDel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                //model.IsDel = (bool)ojb;
                if ((dataReader["IsDel"].ToString() == "1") || (dataReader["IsDel"].ToString().ToLower() == "true"))
                {
                    model.IsDel = true;
                }
                else
                {
                    model.IsDel = false;
                }
            }
            model.AnswerIP = dataReader["AnswerIP"].ToString();
            model.ReferBook = dataReader["ReferBook"].ToString();
            ojb = dataReader["IsAnonymity"];
            if (ojb != null && ojb != DBNull.Value)
            {
                // model.IsAnonymity = (bool)ojb;
                if ((dataReader["IsAnonymity"].ToString() == "1") || (dataReader["IsAnonymity"].ToString().ToLower() == "true"))
                {
                    model.IsAnonymity = true;
                }
                else
                {
                    model.IsAnonymity = false;
                }
            }
            ojb = dataReader["AnswerUpdateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AnswerUpdateTime = (DateTime)ojb;
            }
            ojb = dataReader["Score"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Score = (int)ojb;
            }
            ojb = dataReader["GoodAsk"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.GoodAsk = (int)ojb;
            }
            ojb = dataReader["IsApproved"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsApproved = (int)ojb;
            }

            return model;
        }

        #endregion  成员方法
        /// <summary>
        /// 统计 出 帮助人的总个数
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string HelpUserCount(int UserID)
        {

            //
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT count(*) from ( SELECT * from {0}answers where AnswerUserID=?UserID  GROUP BY QUserID ) as bb", sPre);
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters[0].Value = UserID;
            return DB.ExecuteScalarToStr(CommandType.Text, strSql.ToString(), parameters);

        }

        /// <summary>
        /// 自定义 问答分类
        /// </summary>
        public List<BNewsClass> DALBNews_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(" ID,ClassName,HtmlName,SiteID,(SELECT count(*)from eb_newscontent where ClassID=eb_newsclass.ID) as ContentCount ");
            strSql.AppendFormat(" from  eb_newsclass   ");//where eb_newsclass.ParentID=12597
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
            List<BNewsClass> list = new List<BNewsClass>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(BNewsClass_ReaderBind(dataReader));
                }
            }

            return list;
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public BNewsClass BNewsClass_ReaderBind(IDataReader dataReader)
        {
            BNewsClass model = new BNewsClass();
            object ojb;

            if (dataReader["ID"].ToString() != "")
            {
                model.ID = int.Parse(dataReader["ID"].ToString());
            }
            if (!Equals(dataReader["ClassName"], null))
            {
                model.ClassName = dataReader["ClassName"].ToString();
            }


            if (dataReader["HtmlName"].ToString() != "")
            {
                model.HtmlName = dataReader["HtmlName"].ToString();
            }
            if (dataReader["SiteID"].ToString() != "")
            {
                model.SiteID = int.Parse(dataReader["SiteID"].ToString());
            }
            if (dataReader["ContentCount"].ToString() != "")
            {
                model.ContentCount = int.Parse(dataReader["ContentCount"].ToString());
            }
            return model;
        }

        /// <summary>
        /// 对象实体绑定数据 a.id,a.qid,a.AnswerTime,a.IsAdoption,a.AnswerContent,b.NewsTitle 
        /// </summary>
        public Entity.Answers AnswersEX_ReaderBind(IDataReader dataReader)
        {
            Entity.Answers model = new Entity.Answers();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["QID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.QID = (int)ojb;
            }
          

           
            model.AnswerContent = dataReader["AnswerContent"].ToString();
            ojb = dataReader["IsAdoption"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if ((dataReader["IsAdoption"].ToString() == "1") || (dataReader["IsAdoption"].ToString().ToLower() == "true"))
                {
                    model.IsAdoption = true;
                }
                else
                {
                    model.IsAdoption = false;
                }
                // model.IsAdoption = (bool)ojb;
            }
            ojb = dataReader["IsApproved"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsApproved = (int)ojb;
            }
            ojb = dataReader["AnswerTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AnswerTime = (DateTime)ojb;
            }
           

            //扩展

            model.NewsTitle = dataReader["NewsTitle"].ToString();
            ojb = dataReader["classid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ClassID = (int)ojb;
            }

            ojb = dataReader["siteid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SiteID = Convert.ToInt32( ojb);
            }
            return model;
        }
        #region yhl 2013-09-16
        /// <summary>
        /// 获取随机问答
        /// </summary>
        /// <param name="bid">要关联的品牌ID</param>
        /// <param name="top">前几条</param>
        /// <returns></returns>
        public DataSet GetRandAskData(int bid, int top)
        {
            MySqlParameter[] parameters ={ 
                new MySqlParameter("?p_bid", MySqlDbType.Int32,4),
                new MySqlParameter("?p_top", MySqlDbType.Int32,4)};
            parameters[0].Value = bid;
            parameters[1].Value = top;
            using (DataSet ds = DB.ExecuteDataset(CommandType.StoredProcedure, "bm_ask_GetRandList", parameters))
            {
                return ds;
            }
        }
        #endregion
        /// <summary>
        /// 回答内容页面 数据集 从存储过程 一次调出来
        /// </summary>
        public DataSet GetDataArticle(long id)
        {
            MySqlParameter[] parameters ={ 
                new MySqlParameter("?p_id", MySqlDbType.Int32,4)
              };
            parameters[0].Value = id;

            using (DataSet ds = DB.ExecuteDataset(CommandType.StoredProcedure, "ask_ContentData", parameters))
            {
                return ds;
            }
        }
    }
    //  扩展类
    public class BNewsClass : EbSite.Entity.NewsClass
    {

        private int _contentcount;
        public int ContentCount
        {
            get
            {
                return _contentcount;
            }
            set
            {
                _contentcount = value;
            }
        }

        
       
    }
}

