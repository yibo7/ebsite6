using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;//请先添加引用
namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类TagRelateNews。 
	/// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{
        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int TagRelateNews_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", "tagrelatenews");
        }
        /// <summary>
        /// 获取总记录条数
        /// </summary>
        /// <returns></returns>
        public int TagRelateNews_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.AppendFormat(" from  {0}tagrelatenews  ", sPre);

            if (strWhere.Trim() != "")
            {

                strSql.Append(" where " + strWhere);
            }

            int iCount = -1;
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
        /// 是否存在该记录
        /// </summary>
        public bool TagRelateNews_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}tagrelatenews", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }






        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EbSite.Entity.TagRelateNews TagRelateNews_GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select   id,TagID,NewsID,ClassID from  {0}tagrelatenews ", sPre);
            strSql.Append(" where id=?id  limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            Entity.TagRelateNews model = new Entity.TagRelateNews();
            DataSet ds = DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TagID"].ToString() != "")
                {
                    model.TagID = int.Parse(ds.Tables[0].Rows[0]["TagID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NewsID"].ToString() != "")
                {
                    model.NewsID = int.Parse(ds.Tables[0].Rows[0]["NewsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet TagRelateNews_GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,TagID,NewsID,ClassID ");
            strSql.AppendFormat(" from  {0}tagrelatenews ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        public string TagRelateNews_GetTagsByContentID(long ContentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tk.ID,tk.TagName,tr.NewsID,tr.ClassID ");
            strSql.AppendFormat(" from  {0}tagrelatenews as tr,{0}TagKey as tk", sPre);
            strSql.Append(" where tk.ID=tr.tagID And tr.NewsID=?NewsID");

            MySqlParameter[] parameters = {
					new MySqlParameter("?NewsID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ContentID;

            StringBuilder sb = new StringBuilder();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                while (dataReader.Read())
                {
                    sb.Append(dataReader["TagName"]);
                    sb.Append(",");
                }
            }

            if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);

            return sb.ToString();

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EbSite.Entity.TagRelateNews> TagRelateNews_GetModelList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,TagID,NewsID ,ClassID");
            strSql.AppendFormat(" from  {0}tagrelatenews ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<EbSite.Entity.TagRelateNews> list = new List<EbSite.Entity.TagRelateNews>();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(TagRelateNews_ReaderBind(dataReader));
                }
            }
            return list;
        }
        public EbSite.Entity.TagRelateNews TagRelateNews_ReaderBind(IDataReader dataReader)
        {
            EbSite.Entity.TagRelateNews model = new EbSite.Entity.TagRelateNews();
            if (dataReader["id"].ToString() != "")
            {
                model.id = int.Parse(dataReader["id"].ToString());
            }
            if (dataReader["TagID"].ToString() != "")
            {
                model.TagID = int.Parse(dataReader["TagID"].ToString());
            }
            if (dataReader["NewsID"].ToString() != "")
            {
                model.NewsID = int.Parse(dataReader["NewsID"].ToString());
            }
            if (dataReader["ClassID"].ToString() != "")
            {
                model.ClassID = int.Parse(dataReader["ClassID"].ToString());
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int TagRelateNews_Add(EbSite.Entity.TagRelateNews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}tagrelatenews(", sPre);
            strSql.Append("TagID,NewsID,ClassID)");
            strSql.Append(" values (");
            strSql.Append("?TagID,?NewsID,?ClassID)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TagID",  MySqlDbType.Int32,4),
					new MySqlParameter("?NewsID",  MySqlDbType.Int64,4),
                    new MySqlParameter("?ClassID",MySqlDbType.Int32,4)};
            parameters[0].Value = model.TagID;
            parameters[1].Value = model.NewsID;
            parameters[2].Value = model.ClassID;

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
        public void TagRelateNews_Update(EbSite.Entity.TagRelateNews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  {0}tagrelatenews set ", sPre);
            strSql.Append("TagID=?TagID,");
            strSql.Append("NewsID=?NewsID,");
            strSql.Append("ClassID=?ClassID");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4),
					new MySqlParameter("?TagID",  MySqlDbType.Int32,4),
					new MySqlParameter("?NewsID",  MySqlDbType.Int64,4),
                    new MySqlParameter("?ClassID",MySqlDbType.Int32,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.TagID;
            parameters[2].Value = model.NewsID;

            parameters[3].Value = model.ClassID;
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void TagRelateNews_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from  {0}tagrelatenews ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 当删除某个标签时同时删除与其关联的数据
        /// </summary>
        /// <param name="tagid"></param>
        public void TagRelateNews_DeleteByTagDelete(int tagid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}tagrelatenews ", sPre);
            strSql.Append(" where TagID=?TagID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TagID",  MySqlDbType.Int32,4)};
            parameters[0].Value = tagid;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除与某条内容脱离关联的记录
        /// </summary>
        /// <param name="ReserveIDs">更新后当前的标签ID</param>
        /// <param name="ContentID">内容ID</param>
        public void TagRelateNews_DeleteByRemove(string ReserveIDs, long ContentID)
        {

            string sWhere;

            if (!string.IsNullOrEmpty(ReserveIDs))
            {
                sWhere = string.Concat("TagID not in(", ReserveIDs, ") and NewsID = ", ContentID);
            }
            else  //用户更新时删除了所有标签
            {
                sWhere = string.Concat("NewsID = ", ContentID);
            }

            List<EbSite.Entity.TagRelateNews> lst = TagRelateNews_GetModelList(sWhere);

            foreach (EbSite.Entity.TagRelateNews news in lst)
            {
                TagRelateNews_Delete(news.id);

                //同时也要删除标签表里的对应关系,num=1时，直接删除tag,num>1是，可以 num-1
                EbSite.BLL.TagKey.UpdateByDelete(news.TagID);
            }



        }

        #endregion 写
    }
}

