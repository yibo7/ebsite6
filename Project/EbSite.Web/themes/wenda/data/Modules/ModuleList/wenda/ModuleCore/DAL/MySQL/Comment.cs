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
        private string sFieldComment = "id,AnsewerID,ContentTxt,UserID,addTime,IsDel";
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int Comment_GetMaxId()
        {
            return DB.GetMaxID("id", string.Format("{0}Comment", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Comment_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}Comment", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DB.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Comment_Add(Entity.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}Comment(", sPre);
            strSql.Append("id,AnsewerID,ContentTxt,UserID,addTime,IsDel)");
            strSql.Append(" values (");
            strSql.Append("?id,?AnsewerID,?ContentTxt,?UserID,?addTime,?IsDel)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?AnsewerID", MySqlDbType.Int32,4),
					new MySqlParameter("?ContentTxt", MySqlDbType.Text),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?addTime", MySqlDbType.Datetime),
					new MySqlParameter("?IsDel", MySqlDbType.Bit,1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.AnsewerID;
            parameters[2].Value = model.ContentTxt;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.addTime;
            parameters[5].Value = model.IsDel;

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
        public void Comment_Update(Entity.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}Comment set ", sPre);
            strSql.Append("AnsewerID=?AnsewerID,");
            strSql.Append("ContentTxt=?ContentTxt,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("addTime=?addTime,");
            strSql.Append("IsDel=?IsDel");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?AnsewerID", MySqlDbType.Int32,4),
					new MySqlParameter("?ContentTxt", MySqlDbType.Text),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?addTime", MySqlDbType.Datetime),
					new MySqlParameter("?IsDel", MySqlDbType.Bit,1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.AnsewerID;
            parameters[2].Value = model.ContentTxt;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.addTime;
            parameters[5].Value = model.IsDel;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Comment_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Comment ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Comment Comment_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldComment + "  from {0}Comment ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.Comment model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Comment_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Comment_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}Comment ", sPre);
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
        public DataSet Comment_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(sFieldComment);
            strSql.AppendFormat(" FROM {0}Comment ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.Comment> Comment_GetListArray(string strWhere)
        {
            return Comment_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Comment> Comment_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(sFieldComment);
            strSql.AppendFormat(" FROM {0}Comment ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            List<Entity.Comment> list = new List<Entity.Comment>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Comment_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Comment> Comment_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.Comment> list = new List<Entity.Comment>();

            RecordCount = Comment_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DB, "Comment", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader =DB.ExecuteReader(CommandType.Text, strSql))
            {

                while (dataReader.Read())
                {
                    list.Add(Comment_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Comment Comment_ReaderBind(IDataReader dataReader)
        {
            Entity.Comment model = new Entity.Comment();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["AnsewerID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AnsewerID = (int)ojb;
            }
            model.ContentTxt = dataReader["ContentTxt"].ToString();
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            ojb = dataReader["addTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.addTime = (DateTime)ojb;
            }
            ojb = dataReader["IsDel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsDel = (bool)ojb;
            }
            return model;
        }

        #endregion  成员方法
    }
}

