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
        private string sFieldvoteitem = "id,ItemName,PostCount,VoteID";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int voteitem_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}voteitem", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool voteitem_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}voteitem", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.voteitem voteitem_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldvoteitem + "  from {0}voteitem ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.voteitem model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = voteitem_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int voteitem_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}voteitem ", sPre);
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
        public DataSet voteitem_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldvoteitem);
            strSql.AppendFormat(" FROM {0}voteitem ", sPre);
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
        public List<Entity.voteitem> voteitem_GetListArray(string strWhere)
        {
            return voteitem_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.voteitem> voteitem_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldvoteitem);
            strSql.AppendFormat(" FROM {0}voteitem ", sPre);
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
            List<Entity.voteitem> list = new List<Entity.voteitem>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(voteitem_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.voteitem> voteitem_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.voteitem> list = new List<Entity.voteitem>();
            RecordCount = voteitem_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "voteitem", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(voteitem_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.voteitem voteitem_ReaderBind(IDataReader dataReader)
        {
            Entity.voteitem model = new Entity.voteitem();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.ItemName = dataReader["ItemName"].ToString();
            ojb = dataReader["PostCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PostCount = (int)ojb;
            }
            ojb = dataReader["VoteID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.VoteID = (int)ojb;
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int voteitem_Add(Entity.voteitem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}voteitem(", sPre);
            strSql.Append("ItemName,PostCount,VoteID)");
            strSql.Append(" values (");
            strSql.Append("?ItemName,?PostCount,?VoteID)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?ItemName", MySqlDbType.VarChar,50),
					new MySqlParameter("?PostCount", MySqlDbType.Int32,11),
					new MySqlParameter("?VoteID", MySqlDbType.Int32,10)};

            parameters[0].Value = model.ItemName;
            parameters[1].Value = model.PostCount;
            parameters[2].Value = model.VoteID;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return voteitem_GetMaxId();
            }
            return 0;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void voteitem_Update(Entity.voteitem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}voteitem set ", sPre);
            strSql.Append("ItemName=?ItemName,");
            strSql.Append("PostCount=?PostCount,");
            strSql.Append("VoteID=?VoteID");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?ItemName", MySqlDbType.VarChar,50),
					new MySqlParameter("?PostCount", MySqlDbType.Int32,11),
					new MySqlParameter("?VoteID", MySqlDbType.Int32,10)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.ItemName;
            parameters[2].Value = model.PostCount;
            parameters[3].Value = model.VoteID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void voteitem_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}voteitem ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}

