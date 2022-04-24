//using System;
//using System.Data;
//using System.Text;
//using System.Data.SqlClient;
//using MySql.Data.MySqlClient;
//using System.Collections.Generic;
//using EbSite.Base.DataProfile;
//namespace EbSite.Modules.Wenda.ModuleCore.DAL.MySQL
//{
//    /// <summary>
//    /// 数据访问类Ask。
//    /// </summary>
//    public partial class Ask
//    {
//        //  private string sFieldclass_article = "id,classname,newstitle,userid,contentinfo,htmlname,addtime,classid,annex14,askid,askaddtime";

//        #region  成员方法
//        /// <summary>
//        /// 获取统计
//        /// </summary>
//        public int class_article_GetCount(string strWhere)
//        {
//            StringBuilder strSql = new StringBuilder();
//            strSql.AppendFormat("select count(*)  from {0}class_article ", sPre);
//            if (strWhere.Trim() != "")
//            {
//                strSql.Append(" where " + strWhere);
//            }
//            int iCount = 0;
//            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
//            {
//                while (dataReader.Read())
//                {
//                    iCount = int.Parse(dataReader[0].ToString());
//                }
//            }
//            return iCount;
//        }
//        /// <summary>
//        /// 获得分页数据
//        /// </summary>
//        public List<Entity.class_article> class_article_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
//        {
//            List<Entity.class_article> list = new List<Entity.class_article>();
//            RecordCount = class_article_GetCount(strWhere);


//            string strSql = SplitPages.GetSplitPagesMySql(DB, "class_article", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);


//            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
//            {
//                while (dataReader.Read())
//                {
//                    list.Add(class_article_ReaderBind(dataReader));
//                }
//            }
//            return list;

//        }

//        public List<Entity.class_article> GetListArray(int Top, string strWhere, string filedOrder)
//        {
//            StringBuilder strSql = new StringBuilder();
//            strSql.Append("select ");

//            strSql.Append("*");
//            strSql.AppendFormat(" FROM {0}class_article ", sPre);
//            if (strWhere.Trim() != "")
//            {
//                strSql.Append(" where " + strWhere);
//            }
//            if (filedOrder.Trim() != "")
//            {
//                strSql.Append(" order by  " + filedOrder);
//            }
//            if (Top > 0)
//            {
//                strSql.Append(" limit " + Top.ToString());
//            }
//            List<Entity.class_article> list = new List<Entity.class_article>();
//            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
//            {
//                while (dataReader.Read())
//                {
//                    list.Add(class_article_ReaderBind(dataReader));
//                }
//            }

//            return list;
//        }


//        /// <summary>
//        /// 增加一条数据
//        /// </summary>
//        public int class_article_Add(Entity.class_article model)
//        {
//            StringBuilder strSql = new StringBuilder();
//            strSql.AppendFormat("insert into {0}class_article(", sPre);
//            strSql.Append("classname,newstitle,userid,contentinfo,htmlname,addtime,classid,annex14,askid,askaddtime,RandNum)");
//            strSql.Append(" values (");
//            strSql.Append("?classname,?newstitle,?userid,?contentinfo,?htmlname,?addtime,?classid,?annex14,?askid,?askaddtime,?RandNum)");
//            strSql.Append(";SELECT @@session.identity");
//            MySqlParameter[] parameters = {
//                    new MySqlParameter("?classname", MySqlDbType.VarChar,200),
//                    new MySqlParameter("?newstitle", MySqlDbType.VarChar,500),
//                    new MySqlParameter("?userid", MySqlDbType.Int32,11),
//                    new MySqlParameter("?contentinfo", MySqlDbType.Text),
//                    new MySqlParameter("?htmlname", MySqlDbType.VarChar,200),
//                    new MySqlParameter("?addtime", MySqlDbType.DateTime),
//                    new MySqlParameter("?classid", MySqlDbType.Int32,11),
//                    new MySqlParameter("?annex14", MySqlDbType.Int32,11),
//                    new MySqlParameter("?askid", MySqlDbType.Int64,20),
//                    new MySqlParameter("?askaddtime", MySqlDbType.DateTime),
//                    new MySqlParameter("?RandNum",MySqlDbType.Int32)
//                                          };
//            parameters[0].Value = model.ClassName;
//            parameters[1].Value = model.NewsTitle;
//            parameters[2].Value = model.UserID;
//            parameters[3].Value = "";// model.ContentInfo;
//            parameters[4].Value = "";
//            parameters[5].Value = model.AddTime;
//            parameters[6].Value = model.Classid;
//            parameters[7].Value = model.Annex14;
//            parameters[8].Value = model.AskId;
//            parameters[9].Value = model.AskAddTime;
//            parameters[10].Value = model.RandNum;

//            object obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
//            if (obj == null)
//            {
//                return 1;
//            }
//            return Convert.ToInt32(obj);
//        }


//        /// <summary>
//        /// 更新一条数据
//        /// </summary>
//        public void class_article_Update(Entity.class_article model)
//        {
//            StringBuilder strSql = new StringBuilder();
//            strSql.AppendFormat("update {0}class_article set ", sPre);
//            strSql.Append("classname=?classname,");
//            strSql.Append("newstitle=?newstitle,");
//            strSql.Append("userid=?userid,");
//            strSql.Append("contentinfo=?contentinfo,");
//            strSql.Append("htmlname=?htmlname,");
//            strSql.Append("addtime=?addtime,");
//            strSql.Append("classid=?classid,");
//            strSql.Append("annex14=?annex14,");
//            strSql.Append("askid=?askid,");
//            strSql.Append("askaddtime=?askaddtime,");
//            strSql.Append("randnum=?randnum");
//            strSql.Append(" where id=?id ");
//            MySqlParameter[] parameters = {
//                    new MySqlParameter("?id", MySqlDbType.Int64,20),
//                    new MySqlParameter("?classname", MySqlDbType.VarChar,200),
//                    new MySqlParameter("?newstitle", MySqlDbType.VarChar,500),
//                    new MySqlParameter("?userid", MySqlDbType.Int32,11),
//                    new MySqlParameter("?contentinfo", MySqlDbType.Text),
//                    new MySqlParameter("?htmlname", MySqlDbType.VarChar,200),
//                    new MySqlParameter("?addtime", MySqlDbType.DateTime),
//                    new MySqlParameter("?classid", MySqlDbType.Int32,11),
//                    new MySqlParameter("?annex14", MySqlDbType.Int32,11),
//                    new MySqlParameter("?askid", MySqlDbType.Int64,20),
//                    new MySqlParameter("?askaddtime", MySqlDbType.DateTime),
//                    new MySqlParameter("?randnum",MySqlDbType.Int32)};
//            parameters[0].Value = model.id;
//            parameters[1].Value = model.ClassName;
//            parameters[2].Value = model.NewsTitle;
//            parameters[3].Value = model.UserID;
//            parameters[4].Value = model.ContentInfo;
//            parameters[5].Value = model.HtmlName;
//            parameters[6].Value = model.AddTime;
//            parameters[7].Value = model.Classid;
//            parameters[8].Value = model.Annex14;
//            parameters[9].Value = model.AskId;
//            parameters[10].Value = model.AskAddTime;
//            parameters[11].Value = model.RandNum;

//            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
//        }
//        /// <summary>
//        /// 对象实体绑定数据
//        /// </summary>
//        public Entity.class_article class_article_ReaderBind(IDataReader dataReader)
//        {
//            // id,classname,newstitle,userid,contentinfo,htmlname,addtime,classid)
//            Entity.class_article model = new Entity.class_article();
//            object ojb;
//            ojb = dataReader["id"];
//            if (ojb != null && ojb != DBNull.Value)
//            {
//                model.id = (long)ojb;
//            }
//            model.ClassName = dataReader["classname"].ToString();

//            model.NewsTitle = dataReader["newstitle"].ToString();

//            ojb = dataReader["userid"];
//            if (ojb != null && ojb != DBNull.Value)
//            {
//                model.UserID = (int)ojb;
//            }

//            model.ContentInfo = dataReader["contentinfo"].ToString();
//            model.HtmlName = dataReader["htmlname"].ToString();

//            ojb = dataReader["addtime"];
//            if (ojb != null && ojb != DBNull.Value)
//            {
//                model.AddTime = (DateTime)ojb;
//            }
//            ojb = dataReader["AskAddTime"];
//            if (ojb != null && ojb != DBNull.Value)
//            {
//                model.AskAddTime = (DateTime)ojb;
//            }


//            ojb = dataReader["classid"];
//            if (ojb != null && ojb != DBNull.Value)
//            {
//                model.Classid = (int)ojb;
//            }
//            ojb = dataReader["Annex14"];
//            if (ojb != null && ojb != DBNull.Value)
//            {
//                model.Annex14 = (int)ojb;
//            }
//            ojb = dataReader["AskId"];
//            if (ojb != null && ojb != DBNull.Value)
//            {
//                model.AskId = (long)ojb;
//            }
//            ojb = dataReader["RandNum"];
//            if (ojb != null && ojb != DBNull.Value)
//            {
//                model.RandNum = (int)ojb;
//            }

//            return model;
//        }

//        #endregion  成员方法

//        public DataSet GetClassArticleRandomContentIDS(int Top, string swhere, string ids)
//        {
//            DataSet ds = new DataSet();


//            string strSql = string.Format("SELECT * from  {0}class_article where randnum in({1}) ", sPre, ids);

//            if (!string.IsNullOrEmpty(swhere))
//            {
//                strSql += " and " + swhere;
//            }

//            if (Top > 0)
//            {
//                strSql += " limit " + Top.ToString();
//            }
//            if (!string.IsNullOrEmpty(strSql))
//            {
//                using (ds = DB.ExecuteDataset(strSql))
//                {
//                    return ds;
//                }
//            }
//            else
//            {
//                ds = null;
//            }

//            return ds;
//        }
//        public DataSet GetNewsClassArticleContent(int PageIndex, int PageSize)
//        {
//            if (PageIndex > 0)
//            {
//                PageIndex--;
//            }
//            int numStart = PageIndex * PageSize;
//            DataSet ds = new DataSet();

//            string strSql = string.Format("SELECT * from  {0}class_article  ORDER BY id desc limit {1} ,{2}", sPre, numStart, PageSize);




//            if (!string.IsNullOrEmpty(strSql))
//            {
//                using (ds = DB.ExecuteDataset(strSql))
//                {
//                    return ds;
//                }
//            }
//            else
//            {
//                ds = null;
//            }

//            return ds;
//        }

//    }
//}

