using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;

namespace EbSite.Data.User.MySql
{
    /// <summary>
    /// 数据访问类。
    /// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
		private string sFielderrinfo = "id,Title,ErrMsg,ErrCount,IsSys";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int errinfo_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}errinfo", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool errinfo_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}errinfo", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.ErrInfo errinfo_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFielderrinfo + "  from {0}errinfo ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.ErrInfo model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = errinfo_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int errinfo_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}errinfo ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            int iCount = 0;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
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
        public DataSet errinfo_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFielderrinfo);
            strSql.AppendFormat(" FROM {0}errinfo ", sPre);
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
            return DbHelperUser.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.ErrInfo> errinfo_GetListArray(string strWhere)
        {
            return errinfo_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.ErrInfo> errinfo_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFielderrinfo);
            strSql.AppendFormat(" FROM {0}errinfo ", sPre);
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
            List<Entity.ErrInfo> list = new List<Entity.ErrInfo>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(errinfo_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.ErrInfo> errinfo_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.ErrInfo> list = new List<Entity.ErrInfo>();
            RecordCount = errinfo_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "ErrInfo", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(errinfo_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.ErrInfo errinfo_ReaderBind(IDataReader dataReader)
        {
            Entity.ErrInfo model = new Entity.ErrInfo();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.Title = dataReader["Title"].ToString();
            model.ErrMsg = dataReader["ErrMsg"].ToString();
            ojb = dataReader["ErrCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ErrCount = (int)ojb;
            }
            ojb = dataReader["IsSys"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsSys = (bool)ojb;
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int errinfo_Add(Entity.ErrInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}errinfo(", sPre);
            strSql.Append("Title,ErrMsg,ErrCount,IsSys)");
            strSql.Append(" values (");
            strSql.Append("?Title,?ErrMsg,?ErrCount,?IsSys)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Title", MySqlDbType.VarChar,200),
					new MySqlParameter("?ErrMsg", MySqlDbType.VarChar,500),
					new MySqlParameter("?ErrCount", MySqlDbType.Int32,11),
					new MySqlParameter("?IsSys", MySqlDbType.Int16,1)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.ErrMsg;
            parameters[2].Value = model.ErrCount;
            parameters[3].Value = model.IsSys;

            object obj = DbHelperUserWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return errinfo_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void errinfo_Update(Entity.ErrInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}errinfo set ", sPre);
            strSql.Append("Title=?Title,");
            strSql.Append("ErrMsg=?ErrMsg,");
            strSql.Append("ErrCount=?ErrCount,");
            strSql.Append("IsSys=?IsSys");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?Title", MySqlDbType.VarChar,200),
					new MySqlParameter("?ErrMsg", MySqlDbType.VarChar,500),
					new MySqlParameter("?ErrCount", MySqlDbType.Int32,11),
					new MySqlParameter("?IsSys", MySqlDbType.Int16,1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.ErrMsg;
            parameters[3].Value = model.ErrCount;
            parameters[4].Value = model.IsSys;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void errinfo_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}errinfo ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        #endregion 写

    }
}

