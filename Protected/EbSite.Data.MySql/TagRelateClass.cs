using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;//请先添加引用
using System.Collections.Generic;
namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类TagRelateClass。
	/// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{
        private string sFieldTagRelateClass = "id,TagID,TagName,ClassID,TableID";

        #region 读

        /// <summary>
        /// 获取统计
        /// </summary>
        public int TagRelateClass_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}tagrelateclass ", sPre);
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
        /// 是否存在该记录
        /// </summary>
        public bool TagRelateClass_Exists(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}tagrelateclass", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }

        private bool TagRelateClass_Exists(int tid, int iClasID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}tagrelateclass", sPre);
            strSql.Append(" where TagID=?TagID and ClassID=?ClassID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TagID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4)};
            parameters[0].Value = tid;
            parameters[1].Value = iClasID;
            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.TagRelateClass TagRelateClass_GetEntity(long id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldTagRelateClass + "  from {0}tagrelateclass ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)};
            parameters[0].Value = id;
            Entity.TagRelateClass model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = TagRelateClass_ReaderBind(dataReader);
                }
            }
            return model;
        }



        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet TagRelateClass_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldTagRelateClass);
            strSql.AppendFormat(" FROM {0}tagrelateclass ", sPre);
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
        public List<Entity.TagRelateClass> TagRelateClass_GetListArray(string strWhere)
        {
            return TagRelateClass_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.TagRelateClass> TagRelateClass_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldTagRelateClass);
            strSql.AppendFormat(" FROM {0}tagrelateclass ", sPre);
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
            List<Entity.TagRelateClass> list = new List<Entity.TagRelateClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(TagRelateClass_ReaderBind(dataReader));
                }
            }
            return list;
        }




        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.TagRelateClass TagRelateClass_ReaderBind(IDataReader dataReader)
        {
            Entity.TagRelateClass model = new Entity.TagRelateClass();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (long)ojb;
            }
            ojb = dataReader["TagID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TagID = (int)ojb;
            }
            model.TagName = dataReader["TagName"].ToString();
            ojb = dataReader["ClassID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ClassID = (int)ojb;
            }

            if (dataReader["TableID"].ToString() != "")
            {
                model.TableID = int.Parse(dataReader["TableID"].ToString());
            }

            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int TagRelateClass_Add(Entity.TagRelateClass model)
        {
            if (!TagRelateClass_Exists(model.TagID, model.ClassID))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("insert into {0}tagrelateclass(", sPre);
                strSql.Append("TagID,TagName,ClassID,TableID)");
                strSql.Append(" values (");
                strSql.Append("?TagID,?TagName,?ClassID,?TableID)");
                MySqlParameter[] parameters = {
					new MySqlParameter("?TagID",  MySqlDbType.Int32,4),
					new MySqlParameter("?TagName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?TableID",MySqlDbType.Int32,4)};
                parameters[0].Value = model.TagID;
                parameters[1].Value = model.TagName;
                parameters[2].Value = model.ClassID;

                parameters[3].Value = model.TableID;
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
        public void TagRelateClass_Update(Entity.TagRelateClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}tagrelateclass set ", sPre);
            strSql.Append("TagID=?TagID,");
            strSql.Append("TagName=?TagName,");
            strSql.Append("ClassID=?ClassID,");
            strSql.Append("TableID=?TableID");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64,8),
					new MySqlParameter("?TagID",  MySqlDbType.Int32,4),
					new MySqlParameter("?TagName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?TableID",MySqlDbType.Int32,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.TagID;
            parameters[2].Value = model.TagName;
            parameters[3].Value = model.ClassID;
            parameters[4].Value = model.TableID;
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void TagRelateClass_Delete(long id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}tagrelateclass ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
       public void TagRelateClass_DeleteByRemove(string ReserveIDs, int iClassID)
       {
           string sWhere;

           if (!string.IsNullOrEmpty(ReserveIDs))
           {
               sWhere = string.Concat("TagID not in(", ReserveIDs, ") and ClassID = ", iClassID);
           }
           else  //用户更新时删除了所有标签
           {
               sWhere = string.Concat("ClassID = ", iClassID);
           }

           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("delete from {0}tagrelateclass ", sPre);
           strSql.Append(" where ");
           strSql.Append(sWhere);

           DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());

       }

        #endregion 写
    }
}

