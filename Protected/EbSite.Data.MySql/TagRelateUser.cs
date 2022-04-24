using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;//请先添加引用
namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类TagRelateUser。
	/// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{
        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int TagRelateUser_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", "tagrelateuser");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool TagRelateUser_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}tagrelateuser", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }
        private bool TagRelateUser_Exists(int tid, int iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}tagrelateuser", sPre);
            strSql.Append(" where TagID=?TagID and UserID=?UserID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TagID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4)};
            parameters[0].Value = tid;
            parameters[1].Value = iUserID;
            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EbSite.Entity.TagRelateUser TagRelateUser_GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select id,TagID,UserID,UserName,UserNiName from  {0}tagrelateuser ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            EbSite.Entity.TagRelateUser model = new EbSite.Entity.TagRelateUser();
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
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserNiName = ds.Tables[0].Rows[0]["UserNiName"].ToString();
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
        public List<EbSite.Entity.TagRelateUser> TagRelateUser_GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,TagID,UserID,UserName,UserNiName ");
            strSql.AppendFormat(" from  {0}tagrelateuser ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<EbSite.Entity.TagRelateUser> list = new List<EbSite.Entity.TagRelateUser>();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(TagRelateUser_ReaderBind(dataReader));
                }
            }
            return list;

        }

        public EbSite.Entity.TagRelateUser TagRelateUser_ReaderBind(IDataReader dataReader)
        {
            EbSite.Entity.TagRelateUser model = new EbSite.Entity.TagRelateUser();
            if (dataReader["id"].ToString() != "")
            {
                model.id = int.Parse(dataReader["id"].ToString());
            }
            if (dataReader["TagID"].ToString() != "")
            {
                model.TagID = int.Parse(dataReader["TagID"].ToString());
            }
            if (dataReader["UserID"].ToString() != "")
            {
                model.UserID = int.Parse(dataReader["UserID"].ToString());
            }
            model.UserName = dataReader["UserName"].ToString();
            model.UserNiName = dataReader["UserNiName"].ToString();
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int TagRelateUser_Add(EbSite.Entity.TagRelateUser model)
        {
            if (!TagRelateUser_Exists(model.TagID, model.UserID))
            {

                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("insert into {0}tagrelateuser(", sPre);
                strSql.Append("TagID,UserID,UserName,UserNiName)");
                strSql.Append(" values (");
                strSql.Append("?TagID,?UserID,?UserName,?UserNiName)");
                strSql.Append(";SELECT @@session.identity");
                MySqlParameter[] parameters = {
					new MySqlParameter("?TagID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50)};
                parameters[0].Value = model.TagID;
                parameters[1].Value = model.UserID;
                parameters[2].Value = model.UserName;
                parameters[3].Value = model.UserNiName;
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
            else
            {
                return 0;
            }

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void TagRelateUser_Update(EbSite.Entity.TagRelateUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}tagrelateuser set ", sPre);
            strSql.Append("TagID=?TagID,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("UserNiName=?UserNiName");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4),
					new MySqlParameter("?TagID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.TagID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.UserNiName;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void TagRelateUser_Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}tagrelateuser ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除与某条内容脱离关联的记录
        /// </summary>
        /// <param name="ReserveIDs">更新后当前的标签ID</param>
        /// <param name="ContentID">内容ID</param>
        public void TagRelateUser_DeleteByRemove(string ReserveIDs, int UserID)
        {

            string sWhere;

            if (!string.IsNullOrEmpty(ReserveIDs))
            {
                sWhere = string.Concat("TagID not in(", ReserveIDs, ") and UserID = ", UserID);
            }
            else  //用户更新时删除了所有标签
            {
                sWhere = string.Concat("UserID = ", UserID);
            }

            List<EbSite.Entity.TagRelateUser> lst = TagRelateUser_GetList(sWhere);

            foreach (EbSite.Entity.TagRelateUser news in lst)
            {
                TagRelateUser_Delete(news.id);

                //同时也要删除标签表里的对应关系,num=1时，直接删除tag,num>1是，可以 num-1
                //EbSite.BLL.TagKey.UpdateByDelete(news.TagID);
            }



        }

        #endregion 写
    }
}

