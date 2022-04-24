using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;

namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类a。
	/// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{
        private string sFieldgoods_visite = "id,UserID,ContentID,Count,Ip,NumTime,ClassID";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int goods_visite_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}goods_visite", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool goods_visite_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}goods_visite", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.goods_visite goods_visite_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldgoods_visite + "  from {0}goods_visite ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.goods_visite model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = goods_visite_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int goods_visite_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}goods_visite ", sPre);
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
        public DataSet goods_visite_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldgoods_visite);
            strSql.AppendFormat(" FROM {0}goods_visite ", sPre);
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
        public List<Entity.goods_visite> goods_visite_GetListArray(string strWhere)
        {
            return goods_visite_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.goods_visite> goods_visite_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldgoods_visite);
            strSql.AppendFormat(" FROM {0}goods_visite ", sPre);
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
            List<Entity.goods_visite> list = new List<Entity.goods_visite>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(goods_visite_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.goods_visite> goods_visite_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.goods_visite> list = new List<Entity.goods_visite>();
            RecordCount = goods_visite_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "goods_visite", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(goods_visite_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.goods_visite goods_visite_ReaderBind(IDataReader dataReader)
        {
            Entity.goods_visite model = new Entity.goods_visite();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            ojb = dataReader["ContentID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ContentID = (int)ojb;
            }
            ojb = dataReader["Count"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Count = (int)ojb;
            }
            ojb = dataReader["Ip"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Ip = (long)ojb;
            }
            ojb = dataReader["NumTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.NumTime = (int)ojb;
            }
            ojb = dataReader["ClassID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ClassID = (int)ojb;
            }

            return model;
        }
        public Entity.goods_visite goods_visite_GetEntity(int ContentID, int UserID, long IP)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldgoods_visite + "  from {0}goods_visite ", sPre);
            strSql.Append(" where ContentID=?ContentID and UserID=?UserID and Ip=?Ip ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ContentID", MySqlDbType.Int32),
                    new MySqlParameter("?UserID", MySqlDbType.Int32),
                    new MySqlParameter("?Ip", MySqlDbType.Int64) 
                                         };
            parameters[0].Value = ContentID;
            parameters[1].Value = UserID;
            parameters[2].Value = IP;

            Entity.goods_visite model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = goods_visite_ReaderBind(dataReader);
                }
            }
            return model;


            //StringBuilder strSql = new StringBuilder();
            //strSql.AppendFormat("select count(1) from {0}goods_visite", sPre);
            //strSql.Append(" where ContentID=?ContentID and UserID=?UserID and Ip=?Ip ");
            //MySqlParameter[] parameters = {
            //         new MySqlParameter("?ContentID", MySqlDbType.Int32),
            //         new MySqlParameter("?UserID", MySqlDbType.Int32),
            //         new MySqlParameter("?Ip", MySqlDbType.Int64) 
            //                              };
            //parameters[0].Value = ContentID;
            //parameters[1].Value = UserID;
            //parameters[2].Value = IP;

            //return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }
        public List<Entity.goods_visite> goods_visite_ListByProductID(int Top, string strWhere, string filedOrder, int ClassID)
        {
            string TbName = EbSite.Base.AppStartInit.GetTableNameByClassID(ClassID);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT a.ContentID  ,a.NewsTitle,a.smallpic,a.classid from (");


            strSql.Append("select a.ContentID,a.id,a.UserID,a.Count,a.Ip,a.NumTime,b.smallpic,b.NewsTitle,a.ClassID ");
            strSql.AppendFormat(" FROM {0}goods_visite a,{1}{2} b ", sPre, EbSite.Base.Host.Instance.GetSysTablePrefix, TbName);
            strSql.Append(" where  a.ContentID = b.ID ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            strSql.Append(") a");
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            List<Entity.goods_visite> list = new List<Entity.goods_visite>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(goods_visite_ReaderBind2(dataReader));
                }
            }
            return list;
        }
        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.goods_visite goods_visite_ReaderBind2(IDataReader dataReader)
        {
            Entity.goods_visite model = new Entity.goods_visite();
            object ojb;

            ojb = dataReader["ContentID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ContentID = (int)ojb;
            }

            model.Smallpic = dataReader["SmallPic"].ToString();
            model.NewsTitle = dataReader["NewsTitle"].ToString();

            ojb = dataReader["ClassID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ClassID = (int)ojb;
            }


            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int goods_visite_Add(Entity.goods_visite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}goods_visite(", sPre);
            strSql.Append("UserID,ContentID,Count,Ip,NumTime,ClassID)");
            strSql.Append(" values (");
            strSql.Append("?UserID,?ContentID,?Count,?Ip,?NumTime,?ClassID)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?ContentID", MySqlDbType.Int32,11),
					new MySqlParameter("?Count", MySqlDbType.Int32,11),
					new MySqlParameter("?Ip", MySqlDbType.Int64,11),
					new MySqlParameter("?NumTime", MySqlDbType.Int32,11),
                    new MySqlParameter("?ClassID",MySqlDbType.Int32,11) };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ContentID;
            parameters[2].Value = model.Count;
            parameters[3].Value = model.Ip;
            parameters[4].Value = model.NumTime;
            parameters[5].Value = model.ClassID;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return goods_visite_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void goods_visite_Update(Entity.goods_visite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}goods_visite set ", sPre);
            strSql.Append("UserID=?UserID,");
            strSql.Append("ContentID=?ContentID,");
            strSql.Append("Count=?Count,");
            strSql.Append("Ip=?Ip,");
            strSql.Append("NumTime=?NumTime,");
            strSql.Append("ClassID=?ClassID");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?ContentID", MySqlDbType.Int32,11),
					new MySqlParameter("?Count", MySqlDbType.Int32,11),
					new MySqlParameter("?Ip", MySqlDbType.Int64,11),
					new MySqlParameter("?NumTime", MySqlDbType.Int32,11),
                    new MySqlParameter("?ClassID",MySqlDbType.Int32,11) };
            parameters[0].Value = model.id;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.ContentID;
            parameters[3].Value = model.Count;
            parameters[4].Value = model.Ip;
            parameters[5].Value = model.NumTime;
            parameters[6].Value = model.ClassID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void goods_visite_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}goods_visite ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}

