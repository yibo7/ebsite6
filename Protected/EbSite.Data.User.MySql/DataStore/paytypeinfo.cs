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
		private string sFieldpaytypeinfo = "id,ParentID,Name,Demo,OrderID";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int paytypeinfo_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}paytypeinfo", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool paytypeinfo_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}paytypeinfo", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.PayTypeInfo paytypeinfo_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldpaytypeinfo + "  from {0}paytypeinfo ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.PayTypeInfo model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = paytypeinfo_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int paytypeinfo_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}paytypeinfo ", sPre);
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
        public DataSet paytypeinfo_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldpaytypeinfo);
            strSql.AppendFormat(" FROM {0}paytypeinfo ", sPre);
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
        public List<Entity.PayTypeInfo> paytypeinfo_GetListArray(string strWhere)
        {
            return paytypeinfo_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.PayTypeInfo> paytypeinfo_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldpaytypeinfo);
            strSql.AppendFormat(" FROM {0}paytypeinfo ", sPre);
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
            List<Entity.PayTypeInfo> list = new List<Entity.PayTypeInfo>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(paytypeinfo_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.PayTypeInfo> paytypeinfo_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.PayTypeInfo> list = new List<Entity.PayTypeInfo>();
            RecordCount = paytypeinfo_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "PayTypeInfo", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(paytypeinfo_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.PayTypeInfo paytypeinfo_ReaderBind(IDataReader dataReader)
        {
            Entity.PayTypeInfo model = new Entity.PayTypeInfo();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["ParentID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ParentID = (int)ojb;
            }
            model.Name = dataReader["Name"].ToString();
            model.Demo = dataReader["Demo"].ToString();
            ojb = dataReader["OrderID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderID = (int)ojb;
            }

            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int paytypeinfo_Add(Entity.PayTypeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}paytypeinfo(", sPre);
            strSql.Append("ParentID,Name,Demo,OrderID)");
            strSql.Append(" values (");
            strSql.Append("?ParentID,?Name,?Demo,?OrderID)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ParentID", MySqlDbType.Int32,11),
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?Demo", MySqlDbType.VarChar,200),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,11)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Demo;
            parameters[3].Value = model.OrderID;

            object obj = DbHelperUserWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return paytypeinfo_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void paytypeinfo_Update(Entity.PayTypeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}paytypeinfo set ", sPre);
            strSql.Append("ParentID=?ParentID,");
            strSql.Append("Name=?Name,");
            strSql.Append("Demo=?Demo,");
            strSql.Append("OrderID=?OrderID");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?ParentID", MySqlDbType.Int32,11),
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?Demo", MySqlDbType.VarChar,200),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,11)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Demo;
            parameters[4].Value = model.OrderID;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void paytypeinfo_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}paytypeinfo ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        #endregion 写

    }
}

