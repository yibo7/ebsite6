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
    /// 数据访问类a。
    /// </summary>
    public partial class Ask
    {
        private string sFieldexpandanswers = "id,AnswerId,Ctent,TDate,Uid,TypeId,Eid";
      
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int expandanswers_GetMaxId()
        {
            return DB.GetMaxID("id", string.Format("{0}expandanswers", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool expandanswers_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}expandanswers", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DB.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int expandanswers_Add(Entity.expandanswers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}expandanswers(", sPre);
            strSql.Append("AnswerId,Ctent,TDate,Uid,TypeId,Eid)");
            strSql.Append(" values (");
            strSql.Append("?AnswerId,?Ctent,?TDate,?Uid,?TypeId,?Eid)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AnswerId", MySqlDbType.Int32,4),		
					new MySqlParameter("?Ctent", MySqlDbType.Text),
                    new MySqlParameter("?TDate", MySqlDbType.Datetime),
                    new MySqlParameter("?Uid", MySqlDbType.Int32,4),
                    new MySqlParameter("?TypeId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Eid", MySqlDbType.Int32,4)
					};

            parameters[0].Value = model.AnswerId;
            parameters[1].Value = model.Ctent;
            parameters[2].Value = model.TDate;
            parameters[3].Value = model.Uid;
            parameters[4].Value = model.TypeId;
            parameters[5].Value = model.Eid;



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
        public void expandanswers_Update(Entity.expandanswers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}expandanswers set ", sPre);

            strSql.Append("AnswerId=?AnswerId,");
            strSql.Append("Ctent=?Ctent,");
            strSql.Append("TDate=?TDate");
            strSql.Append("Uid=?Uid,");
            strSql.Append("TypeId=?TypeId,");
            strSql.Append("Eid=?Eid");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?AnswerId", MySqlDbType.Int32,4),
					new MySqlParameter("?Ctent", MySqlDbType.Text),
					new MySqlParameter("?TDate", MySqlDbType.Datetime),
                    new MySqlParameter("?Uid", MySqlDbType.Int32,4),
                    new MySqlParameter("?TypeId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Eid", MySqlDbType.Int32,4)
					 };
            parameters[0].Value = model.id;
            parameters[1].Value = model.AnswerId;
            parameters[2].Value = model.Ctent;
            parameters[3].Value = model.TDate;
            parameters[4].Value = model.Uid;
            parameters[5].Value = model.TypeId;
            parameters[6].Value = model.Eid;
            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void expandanswers_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}expandanswers ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.expandanswers expandanswers_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldexpandanswers + "  from {0}expandanswers ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.expandanswers model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = expandanswers_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int expandanswers_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}expandanswers ", sPre);
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
        public DataSet expandanswers_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldexpandanswers);
            strSql.AppendFormat(" FROM {0}expandanswers ", sPre);
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
        public List<Entity.expandanswers> expandanswers_GetListArray(string strWhere)
        {
            return expandanswers_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.expandanswers> expandanswers_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldexpandanswers);
            strSql.AppendFormat(" FROM {0}expandanswers ", sPre);
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
            List<Entity.expandanswers> list = new List<Entity.expandanswers>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(expandanswers_ReaderBind(dataReader));
                }
            }

            return list;
        }




        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.expandanswers> expandanswers_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.expandanswers> list = new List<Entity.expandanswers>();
            RecordCount = expandanswers_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DB, "expandanswers", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(expandanswers_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.expandanswers expandanswers_ReaderBind(IDataReader dataReader)
        {

           
            Entity.expandanswers model = new Entity.expandanswers();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["AnswerId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AnswerId = (int)ojb;
            }
            model.Ctent = dataReader["Ctent"].ToString();

            ojb = dataReader["TDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TDate = (DateTime)ojb;
            }
            ojb = dataReader["Uid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Uid = (int)ojb;
            }
            ojb = dataReader["TypeId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TypeId = (int)ojb;
            }
            ojb = dataReader["Eid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Eid = (int)ojb;
            }
            
            return model;
        }

        #endregion  成员方法
    }
}

