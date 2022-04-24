using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;//请先添加引用
namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类SpecialNews。
	/// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{ 
        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int SpecialNews_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", "specialnews");
        }
        /// <summary>  
        /// 获取总记录条数
        /// </summary>
        /// <returns></returns>
        public int SpecialNews_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.AppendFormat(" from  {0}specialnews", sPre);

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
        public bool SpecialNews_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}specialnews", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在符合某条件的记录
        /// </summary>
        public bool SpecialNews_Exists(string sWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}specialnews where ", sPre);
            strSql.Append(sWhere);

            return DbHelperCms.Instance.Exists(strSql.ToString());

        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EbSite.Entity.SpecialNews SpecialNews_GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select   id,NewsID,SpecialClassID,orderid,ClassID,ModelID from  {0}specialnews ");
            strSql.Append(" where id=?id limit 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;


            //DataSet ds = DbHelperCms.Instance.ExecuteDataset(CommandType.Text,strSql.ToString(), parameters);

            Entity.SpecialNews model = new Entity.SpecialNews();


            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = SpecialNews_ReaderBind(dataReader);
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet SpecialNews_GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,NewsID,SpecialClassID,orderid,ClassID,ModelID ");
            strSql.AppendFormat(" from  {0}specialnews ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）-根据排序
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="iTop">大于0才有效,否则为全部</param>
        /// <param name="oderby"></param>
        /// <returns></returns>
        public List<EbSite.Entity.SpecialNews> SpecialNews_GetListArray(string strWhere, int iTop, string oderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");

            strSql.Append(" * ");
            strSql.AppendFormat(" from  {0}specialnews ", sPre);

            if (strWhere.Trim() != "")
            {
                strSql.Append(" Where  " + strWhere);
            }
            if (!string.IsNullOrEmpty(oderby.Trim()))
            {
                strSql.Append("  order by  ");
                strSql.Append(oderby);

            }
            else
            {
                strSql.Append("  order by  id desc ");

            }
            if (iTop > 0)
            {
                strSql.Append(" limit " + iTop.ToString());
            }
            List<EbSite.Entity.SpecialNews> list = new List<EbSite.Entity.SpecialNews>();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(SpecialNews_ReaderBind(dataReader));
                }
            }
            return list;
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public EbSite.Entity.SpecialNews SpecialNews_ReaderBind(IDataReader dataReader)
        {
            EbSite.Entity.SpecialNews model = new Entity.SpecialNews();
            if (dataReader["id"].ToString() != "")
            {
                model.id = int.Parse(dataReader["id"].ToString());
            }
            if (dataReader["NewsID"].ToString() != "")
            {
                model.NewsID = int.Parse(dataReader["NewsID"].ToString());
            }
            if (dataReader["SpecialClassID"].ToString() != "")
            {
                model.SpecialClassID = int.Parse(dataReader["SpecialClassID"].ToString());
            }
            if (dataReader["orderid"].ToString() != "")
            {
                model.orderid = int.Parse(dataReader["orderid"].ToString());
            }
            if (dataReader["ClassID"].ToString() != "")
            {
                model.ClassID = int.Parse(dataReader["ClassID"].ToString());
            }
            model.ModelID = new Guid(dataReader["ModelID"].ToString());



            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int SpecialNews_Add(EbSite.Entity.SpecialNews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}specialnews(", sPre);
            strSql.Append("NewsID,SpecialClassID,orderid,ClassID,ModelID)");
            strSql.Append(" values (");
            strSql.Append("?NewsID,?SpecialClassID,?orderid,?ClassID,?ModelID)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?NewsID",  MySqlDbType.Int64,4),
					new MySqlParameter("?SpecialClassID",  MySqlDbType.Int32,4),
					new MySqlParameter("?orderid",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?ModelID",MySqlDbType.VarChar,36)};
            parameters[0].Value = model.NewsID;
            parameters[1].Value = model.SpecialClassID;
            parameters[2].Value = model.orderid;
            parameters[3].Value = model.ClassID;
            parameters[4].Value = model.ModelID;

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
        public void SpecialNews_Update(EbSite.Entity.SpecialNews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  {0}specialnews set ", sPre);
            strSql.Append("NewsID=?NewsID,");
            strSql.Append("SpecialClassID=?SpecialClassID,");
            strSql.Append("orderid=?orderid,");
            strSql.Append("ClassID=?ClassID,");
            strSql.Append("ModelID=?ModelID");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4),
					new MySqlParameter("?NewsID",  MySqlDbType.Int64,4),
					new MySqlParameter("?SpecialClassID",  MySqlDbType.Int32,4),
					new MySqlParameter("?orderid",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?ModelID",MySqlDbType.VarChar,36)         
                                          };
            parameters[0].Value = model.id;
            parameters[1].Value = model.NewsID;
            parameters[2].Value = model.SpecialClassID;
            parameters[3].Value = model.orderid;
            parameters[4].Value = model.ClassID;
            parameters[5].Value = model.ModelID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

        }
        public void SpecialNews_MergeSpecail(string SIDs, int TID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  {0}specialnews set ", sPre);
            strSql.AppendFormat("SpecialClassID={0}", TID);
            strSql.AppendFormat(" where SpecialClassID in({0}) ", SIDs);
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void SpecialNews_Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}specialnews ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void SpecialNews_Delete(long newsid, int SpecialID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}specialnews ", sPre);
            strSql.Append(" where NewsID=?NewsID and SpecialClassID=?SpecialClassID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?NewsID",  MySqlDbType.Int64,4),
                    new MySqlParameter("?SpecialClassID",  MySqlDbType.Int32,4)
                                        };
            parameters[0].Value = newsid;
            parameters[1].Value = SpecialID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        

        #endregion 写
    }
}

