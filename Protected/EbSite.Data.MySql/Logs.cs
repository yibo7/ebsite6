using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;

namespace EbSite.Data.MySql
{
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        private string sFieldeb_logs = "id,Title,Description,LogType,AddDate,ip";

        #region  成员方法读  

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int Logs_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}logs", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Logs_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}logs", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }


        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Logs Logs_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldeb_logs + "  from {0}logs ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.Logs model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Logs_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Logs_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}logs ", sPre);
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
        public DataSet Logs_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldeb_logs);
            strSql.AppendFormat(" FROM {0}logs ", sPre);
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
        public List<Entity.Logs> Logs_GetListArray(string strWhere)
        {
            return Logs_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Logs> Logs_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldeb_logs);
            strSql.AppendFormat(" FROM {0}logs ", sPre);
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
            List<Entity.Logs> list = new List<Entity.Logs>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Logs_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Logs> Logs_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.Logs> list = new List<Entity.Logs>();
            RecordCount = Logs_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "logs", PageSize, PageIndex, "", "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Logs_ReaderBind(dataReader));
                }
            }
            return list;


        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Logs Logs_ReaderBind(IDataReader dataReader)
        {
            Entity.Logs model = new Entity.Logs();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.Title = dataReader["Title"].ToString();
            model.Description = dataReader["Description"].ToString();
            ojb = dataReader["LogType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LogType = Convert.ToInt16(ojb);
            }
            ojb = dataReader["AddDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDate = (DateTime)ojb;
            }
            model.IP = dataReader["ip"].ToString();
            return model;
        }

        #endregion  成员方法

        #region 写
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Logs_Add(Entity.Logs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}logs(", sPre);
            strSql.Append("Title,Description,LogType,AddDate,ip)");
            strSql.Append(" values (");
            strSql.Append("?Title,?Description,?LogType,?AddDate,?ip)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Title", MySqlDbType.VarChar,300),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?LogType", MySqlDbType.Int32,4),
					new MySqlParameter("?AddDate", MySqlDbType.DateTime),
                    new MySqlParameter("?ip",MySqlDbType.VarChar,15)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.LogType;
            parameters[3].Value = model.AddDate;
            parameters[4].Value = model.IP;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Logs_Update(Entity.Logs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}logs set ", sPre);
            strSql.Append("Title=?Title,");
            strSql.Append("Description=?Description,");
            strSql.Append("LogType=?LogType,");
            strSql.Append("AddDate=?AddDate,");
            strSql.Append("ip=?ip");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?Title", MySqlDbType.VarChar,255),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?LogType", MySqlDbType.UInt32 ,4),
					new MySqlParameter("?AddDate", MySqlDbType.DateTime),
                    new MySqlParameter("?ip",MySqlDbType.VarChar,15) };
            parameters[0].Value = model.id;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.LogType;
            parameters[4].Value = model.AddDate;
            parameters[5].Value = model.IP;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Logs_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}logs ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public void Logs_DeleteByType(int typeid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}logs ", sPre);
            strSql.Append(" where LogType=?LogType ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LogType", MySqlDbType.Int32,4)};
            parameters[0].Value = typeid;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        #endregion

    }
}

