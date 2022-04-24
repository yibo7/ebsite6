using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;

namespace EbSite.Modules.Wenda.ModuleCore.DAL.MySQL
{
    /// <summary>
    /// 数据访问类Ask。
    /// </summary>
    public partial class Ask
    {
        private string sFieldUserHelp = "id,UserID,QCount,ACount,AdoptionCount,LikeAskClass,TotalScore";
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int UserHelp_GetMaxId()
        {
            return DB.GetMaxID("id", string.Format("{0}UserHelp", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool UserHelp_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}UserHelp", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DB.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int UserHelp_Add(Entity.UserHelp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}UserHelp(", sPre);
            strSql.Append("UserID,QCount,ACount,AdoptionCount,LikeAskClass,TotalScore)");
            strSql.Append(" values (");
            strSql.Append("?UserID,?QCount,?ACount,?AdoptionCount,?LikeAskClass,?TotalScore)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?QCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ACount", MySqlDbType.Int32,4),
					new MySqlParameter("?AdoptionCount", MySqlDbType.Int32,4),
					new MySqlParameter("?LikeAskClass", MySqlDbType.VarChar,1000),
					new MySqlParameter("?TotalScore", MySqlDbType.Int64,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.QCount;
            parameters[2].Value = model.ACount;
            parameters[3].Value = model.AdoptionCount;
            parameters[4].Value = model.LikeAskClass;
            parameters[5].Value = model.TotalScore;

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
        public void UserHelp_Update(Entity.UserHelp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}UserHelp set ", sPre);
            strSql.Append("UserID=?UserID,");
            strSql.Append("QCount=?QCount,");
            strSql.Append("ACount=?ACount,");
            strSql.Append("AdoptionCount=?AdoptionCount,");
            strSql.Append("LikeAskClass=?LikeAskClass,");
            strSql.Append("TotalScore=?TotalScore");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?QCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ACount", MySqlDbType.Int32,4),
					new MySqlParameter("?AdoptionCount", MySqlDbType.Int32,4),
					new MySqlParameter("?LikeAskClass", MySqlDbType.VarChar,1000),
					new MySqlParameter("?TotalScore", MySqlDbType.Int64,8)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.QCount;
            parameters[3].Value = model.ACount;
            parameters[4].Value = model.AdoptionCount;
            parameters[5].Value = model.LikeAskClass;
            parameters[6].Value = model.TotalScore;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void UserHelp_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}UserHelp ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.UserHelp UserHelp_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldUserHelp + "  from {0}UserHelp ", sPre);
            strSql.Append(" where userid=?id  limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.UserHelp model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = UserHelp_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int UserHelp_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}UserHelp ", sPre);
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
        /// 获得前几行数据
        /// </summary>
        public DataSet UserHelp_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldUserHelp);
            strSql.AppendFormat(" FROM {0}UserHelp ", sPre);
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
        public List<Entity.UserHelp> UserHelp_GetListArray(string strWhere)
        {
            return UserHelp_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.UserHelp> UserHelp_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldUserHelp);
            strSql.AppendFormat(" FROM {0}UserHelp ", sPre);
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
            List<Entity.UserHelp> list = new List<Entity.UserHelp>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(UserHelp_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.UserHelp> UserHelp_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.UserHelp> list = new List<Entity.UserHelp>();

            RecordCount = UserHelp_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DB, "UserHelp", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(UserHelp_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.UserHelp UserHelp_ReaderBind(IDataReader dataReader)
        {
            Entity.UserHelp model = new Entity.UserHelp();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            ojb = dataReader["QCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.QCount = (int)ojb;
            }
            ojb = dataReader["ACount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ACount = (int)ojb;
            }
            ojb = dataReader["AdoptionCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AdoptionCount = (int)ojb;
            }
            model.LikeAskClass = dataReader["LikeAskClass"].ToString();
            ojb = dataReader["TotalScore"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TotalScore = (long)ojb;
            }
            return model;
        }

        #endregion  成员方法




        public Entity.UserHelp UserHelp_GetEntityByUserID(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldUserHelp + "  from {0}UserHelp ", sPre);
            strSql.Append(" where UserID=?UserID limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters[0].Value = UserID;
            Entity.UserHelp model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = UserHelp_ReaderBind(dataReader);
                }
            }



            return model;
        }

        /// <summary>
        /// 共回答问题数
        /// </summary>
        public int SumAskNum()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT sum(ACount) from {0}userhelp ", sPre);

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
        /// 获取随机数据=YHL 2013-04-07 从分类发起 选择配件 网友们在问什么？
        /// </summary>
        /// <param name="top">前几条数据</param>
        /// <returns></returns>
        public DataSet GetRandomContent(int top)
        {
            DataSet ds = new DataSet();

            //string strSql = string.Format("SELECT * from  {0}RandContent ORDER BY rand()  ", sPre);
            string strSql = string.Format("SELECT * from  {0}class_article where id >= (SELECT floor(RAND() * (SELECT MAX(id) FROM {0}class_article )))    ", sPre);

            if (top <= 0)
            {
                top = 10;
            }
            strSql += " limit " + top + ";";



            if (!string.IsNullOrEmpty(strSql))
            {
                using (ds = DB.ExecuteDataset(strSql))
                {
                    return ds;
                }
            }
            else
            {
                ds = null;
            }

            return ds;
        }

        public DataSet GetRandomContentIDS( string ids)
        {
            return GetRandomContentIDS(10, ids);

        }
        public DataSet GetRandomContentIDS(int Top,string ids)
        {
            DataSet ds = new DataSet();

            
            string strSql = string.Format("SELECT * from  {0}class_article where randnum in({1}) ", sPre,ids);

            if (Top <= 0)
            {
                Top = 10;
            }
            strSql += " limit " + Top + ";";

            if (!string.IsNullOrEmpty(strSql))
            {
                using (ds = DB.ExecuteDataset(strSql))
                {
                    return ds;
                }
            }
            else
            {
                ds = null;
            }

            return ds;
        }
        /// <summary>
        /// 获取随机数据=YHL 2013-04-07 从分类发起 选择配件 网友们在问什么？
        /// </summary>
        /// <param name="top">前几条数据</param>
        /// <returns></returns>
       
        /// <summary>
        /// 给首页 最新问答提供数据源 每天更新5000条
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public DataSet GetNewsContent5000(int top)
        {
            DataSet ds = new DataSet();

            string strSql = string.Format("SELECT * from  {0}RandContent where askcount>0 ORDER BY id desc  ", sPre);

            if (top <= 0)
            {
                top = 10;
            }
            strSql += " limit " + top + ";";



            if (!string.IsNullOrEmpty(strSql))
            {
                using (ds = DB.ExecuteDataset(strSql))
                {
                    return ds;
                }
            }
            else
            {
                ds = null;
            }

            return ds;
        }


        public DataSet GetNewsPageContent(int PageIndex, int PageSize)
        {
            if (PageIndex > 0)
            {
                PageIndex--;
            }
            int numStart = PageIndex * PageSize;
            DataSet ds = new DataSet();

            string strSql = string.Format("SELECT * from  {0}RandContent  ORDER BY id desc limit {1} ,{2}", sPre, numStart, PageSize);

           


            if (!string.IsNullOrEmpty(strSql))
            {
                using (ds = DB.ExecuteDataset(strSql))
                {
                    return ds;
                }
            }
            else
            {
                ds = null;
            }

            return ds;
        }
    }
}

