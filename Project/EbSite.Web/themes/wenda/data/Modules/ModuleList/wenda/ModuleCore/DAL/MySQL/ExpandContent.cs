using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;

namespace EbSite.Modules.Wenda.ModuleCore.DAL.MySQL
{
    public partial class Ask
    {
        private string sFieldExpandContent = "id,cid,tdate,ctent,ClassId";
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int ExpandContent_GetMaxId()
        {
            return DB.GetMaxID("id", string.Format("{0}ExpandContent", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExpandContent_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}ExpandContent", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DB.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int ExpandContent_Add(Entity.ExpandContent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}ExpandContent(", sPre);
            strSql.Append("Cid,TDate,Ctent,ClassId)");
            strSql.Append(" values (");
            strSql.Append("?Cid,?TDate,?Ctent,?ClassId)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Cid", MySqlDbType.Int32,4),		
					new MySqlParameter("?TDate", MySqlDbType.Datetime),
                    new MySqlParameter("?Ctent", MySqlDbType.Text),
                    new MySqlParameter("?ClassId",MySqlDbType.Int32,4) 
					};

            parameters[0].Value = model.Cid;
            parameters[1].Value = model.TDate;
            parameters[2].Value = model.Ctent;
            parameters[3].Value = model.ClassID;
            

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
        public void ExpandContent_Update(Entity.ExpandContent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}ExpandContent set ", sPre);
            strSql.Append("Cid=?Cid,");
            strSql.Append("TDate=?TDate,");
            strSql.Append("Ctent=?Ctent,");
            strSql.Append("ClassId=?ClassId");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?Cid", MySqlDbType.Int32,4),
					new MySqlParameter("?Ctent", MySqlDbType.Text),
					new MySqlParameter("?TDate", MySqlDbType.Datetime),
                    new MySqlParameter("?ClassId",MySqlDbType.Int32,4) 
					 };
            parameters[0].Value = model.id;
            parameters[1].Value = model.Cid;
            parameters[2].Value = model.Ctent;
            parameters[3].Value = model.TDate;
            parameters[4].Value = model.ClassID;
           

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void ExpandContent_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}ExpandContent ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.ExpandContent ExpandContent_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldExpandContent + "  from {0}ExpandContent ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.ExpandContent model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = ExpandContent_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int ExpandContent_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}ExpandContent ", sPre);
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
        public DataSet ExpandContent_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldExpandContent);
            strSql.AppendFormat(" FROM {0}ExpandContent ", sPre);
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
        public List<Entity.ExpandContent> ExpandContent_GetListArray(string strWhere)
        {
            return ExpandContent_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.ExpandContent> ExpandContent_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldExpandContent);
            strSql.AppendFormat(" FROM {0}ExpandContent ", sPre);
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
            List<Entity.ExpandContent> list = new List<Entity.ExpandContent>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(ExpandContent_ReaderBind(dataReader));
                }
            }

            return list;
        }




        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.ExpandContent> ExpandContent_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.ExpandContent> list = new List<Entity.ExpandContent>();
            RecordCount = ExpandContent_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DB, "ExpandContent", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(ExpandContent_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.ExpandContent ExpandContent_ReaderBind(IDataReader dataReader)
        {
            Entity.ExpandContent model = new Entity.ExpandContent();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["Cid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Cid = (int)ojb;
            }
            model.Ctent = dataReader["Ctent"].ToString();

            ojb = dataReader["TDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TDate = (DateTime)ojb;
            }
            ojb = dataReader["ClassId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ClassID = (int) ojb;
            }
          

            return model;
        }

        #endregion  成员方法
    }
}