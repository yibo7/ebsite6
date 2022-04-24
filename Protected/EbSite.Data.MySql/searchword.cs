using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using EbSite.Base.DataProfile;

namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类a。
	/// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{
		private string sFieldsearchword = "id,keyword,searchcount,addtime";

        #region 读

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool searchword_Exists(Guid id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}searchword", sPre);
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.VarChar,36)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.searchword searchword_GetEntity(Guid id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldsearchword + "  from {0}searchword ", sPre);
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.VarChar,36)};
            parameters[0].Value = id;
            Entity.searchword model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = searchword_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int searchword_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(id)  from {0}searchword ", sPre);
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
        public DataSet searchword_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldsearchword);
            strSql.AppendFormat(" FROM {0}searchword ", sPre);
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
        public List<Entity.searchword> searchword_GetListArray(string strWhere)
        {
            return searchword_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.searchword> searchword_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldsearchword);
            strSql.AppendFormat(" FROM {0}searchword ", sPre);
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
            List<Entity.searchword> list = new List<Entity.searchword>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(searchword_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.searchword> searchword_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.searchword> list = new List<Entity.searchword>();
            RecordCount = searchword_GetCount(strWhere);
            if (!string.IsNullOrEmpty(oderby))
            {
                oderby = " searchcount desc";
            }
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "searchword", PageSize, PageIndex, "", "id", oderby, strWhere, sPre, false);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(searchword_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.searchword searchword_ReaderBind(IDataReader dataReader)
        {
            Entity.searchword model = new Entity.searchword();
            object ojb;
            model.id = new Guid(dataReader["id"].ToString());

            model.keyword = dataReader["keyword"].ToString();
            ojb = dataReader["searchcount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.searchcount = (int)ojb;
            }
            ojb = dataReader["addtime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.addtime = (DateTime)ojb;
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 删除 所有数据
        /// </summary>
        public void searchword_DeleteALL()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}searchword ", sPre);
           
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void searchword_Add(Entity.searchword model)
        {


            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}searchword(", sPre);
            strSql.Append("id,keyword,searchcount,addtime)");
            strSql.Append(" values (");
            strSql.Append("@id,@keyword,@searchcount,@addtime)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.VarChar,36),
                    new MySqlParameter("@keyword", MySqlDbType.VarChar,200),
                    new MySqlParameter("@searchcount", MySqlDbType.Int32,4),
                    new MySqlParameter("@addtime", MySqlDbType.DateTime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.keyword;
            parameters[2].Value = model.searchcount;
            parameters[3].Value = model.addtime;
            DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
        }


        public void searchword_Add(string KeyWord)
        {

            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_ID", MySqlDbType.VarChar, 36), new MySqlParameter("?p_KeyWord", MySqlDbType.VarChar, 200) };
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = KeyWord;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.StoredProcedure,
                                                 string.Format("{0}AddSearchWord", sPre), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void searchword_Update(Entity.searchword model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}searchword set ", sPre);
            strSql.Append("keyword=@keyword,");
            strSql.Append("searchcount=@searchcount,");
            strSql.Append("addtime=@addtime");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.VarChar,36),
					new MySqlParameter("@keyword", MySqlDbType.VarChar,200),
					new MySqlParameter("@searchcount", MySqlDbType.Int32,4),
					new MySqlParameter("@addtime", MySqlDbType.DateTime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.keyword;
            parameters[2].Value = model.searchcount;
            parameters[3].Value = model.addtime;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void searchword_Delete(Guid id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}searchword ", sPre);
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.VarChar,36)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }



        #endregion 写

    }
}

