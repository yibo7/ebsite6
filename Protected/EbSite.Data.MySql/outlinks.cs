using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Data.MySql
{
    /// <summary>
    /// 数据访问类b。
    /// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        private string sFieldoutlinks = "id,SiteName,Url,LogoUrl,QQ,Email,Tel,Mobile,Demo,IsHaveLogo,OrderID,SiteID,IsAuditing,AddTime";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int outlinks_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}outlinks", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool outlinks_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}outlinks", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.outlinks outlinks_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldoutlinks + "  from {0}outlinks ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.outlinks model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = outlinks_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int outlinks_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}outlinks ", sPre);
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
        public DataSet outlinks_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(sFieldoutlinks);
            strSql.AppendFormat(" FROM {0}outlinks ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.outlinks> outlinks_GetListArray(string strWhere)
        {
            return outlinks_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.outlinks> outlinks_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldoutlinks);
            strSql.AppendFormat(" FROM {0}outlinks ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where IsAuditing=1 and " + strWhere);
            }
            else
            {
                strSql.Append(" where IsAuditing=1 ");
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            List<Entity.outlinks> list = new List<Entity.outlinks>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(outlinks_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.outlinks> outlinks_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.outlinks> list = new List<Entity.outlinks>();
            RecordCount = outlinks_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "outlinks", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(outlinks_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.outlinks outlinks_ReaderBind(IDataReader dataReader)
        {
            Entity.outlinks model = new Entity.outlinks();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.SiteName = dataReader["SiteName"].ToString();
            model.Url = dataReader["Url"].ToString();
            model.LogoUrl = dataReader["LogoUrl"].ToString();
            model.QQ = dataReader["QQ"].ToString();
            model.Email = dataReader["Email"].ToString();
            model.Tel = dataReader["Tel"].ToString();
            model.Mobile = dataReader["Mobile"].ToString();
            model.Demo = dataReader["Demo"].ToString();



            if (dataReader["IsHaveLogo"].ToString() != "")
            {
                if ((dataReader["IsHaveLogo"].ToString() == "1") || (dataReader["IsHaveLogo"].ToString().ToLower() == "true"))
                {
                    model.IsHaveLogo = true;
                }
                else
                {
                    model.IsHaveLogo = false;
                }
            }

            ojb = dataReader["OrderID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderID = (int)ojb;
            }
            ojb = dataReader["SiteID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SiteID = (int)ojb;
            }


            if (dataReader["IsAuditing"].ToString() != "")
            {
                if ((dataReader["IsAuditing"].ToString() == "1") || (dataReader["IsAuditing"].ToString().ToLower() == "true"))
                {
                    model.IsAuditing = true;
                }
                else
                {
                    model.IsAuditing = false;
                }
            }
            if (dataReader["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(dataReader["AddTime"].ToString());
            }


            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int outlinks_Add(Entity.outlinks model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}outlinks(", sPre);
            strSql.Append("SiteName,Url,LogoUrl,QQ,Email,Tel,Mobile,Demo,IsHaveLogo,OrderID,SiteID,IsAuditing,AddTime)");
            strSql.Append(" values (");
            strSql.Append("?SiteName,?Url,?LogoUrl,?QQ,?Email,?Tel,?Mobile,?Demo,?IsHaveLogo,?OrderID,?SiteID,?IsAuditing,?AddTime)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SiteName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Url", MySqlDbType.VarChar,255),
					new MySqlParameter("?LogoUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,20),
					new MySqlParameter("?Email", MySqlDbType.VarChar,40),
					new MySqlParameter("?Tel", MySqlDbType.VarChar,50),
					new MySqlParameter("?Mobile", MySqlDbType.VarChar,11),
					new MySqlParameter("?Demo", MySqlDbType.VarChar,300),
					new MySqlParameter("?IsHaveLogo", MySqlDbType.Int16,1),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,11),
					new MySqlParameter("?SiteID", MySqlDbType.Int32,11),
					new MySqlParameter("?IsAuditing", MySqlDbType.Int16,1),
                    new MySqlParameter("?AddTime", MySqlDbType.DateTime)
                                          
                                          };
            parameters[0].Value = model.SiteName;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.LogoUrl;
            parameters[3].Value = model.QQ;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.Tel;
            parameters[6].Value = model.Mobile;
            parameters[7].Value = model.Demo;
            parameters[8].Value = model.IsHaveLogo;
            parameters[9].Value = model.OrderID;
            parameters[10].Value = model.SiteID;
            parameters[11].Value = model.IsAuditing;
            parameters[12].Value = model.AddTime;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return outlinks_GetMaxId();
            }
            return 0;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void outlinks_Update(Entity.outlinks model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}outlinks set ", sPre);
            strSql.Append("SiteName=?SiteName,");
            strSql.Append("Url=?Url,");
            strSql.Append("LogoUrl=?LogoUrl,");
            strSql.Append("QQ=?QQ,");
            strSql.Append("Email=?Email,");
            strSql.Append("Tel=?Tel,");
            strSql.Append("Mobile=?Mobile,");
            strSql.Append("Demo=?Demo,");
            strSql.Append("IsHaveLogo=?IsHaveLogo,");
            strSql.Append("OrderID=?OrderID,");
            strSql.Append("SiteID=?SiteID,");
            strSql.Append("IsAuditing=?IsAuditing");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?SiteName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Url", MySqlDbType.VarChar,255),
					new MySqlParameter("?LogoUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,20),
					new MySqlParameter("?Email", MySqlDbType.VarChar,40),
					new MySqlParameter("?Tel", MySqlDbType.VarChar,50),
					new MySqlParameter("?Mobile", MySqlDbType.VarChar,11),
					new MySqlParameter("?Demo", MySqlDbType.VarChar,300),
					new MySqlParameter("?IsHaveLogo", MySqlDbType.Int16,1),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,11),
					new MySqlParameter("?SiteID", MySqlDbType.Int32,11),
					new MySqlParameter("?IsAuditing", MySqlDbType.Int16,1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.SiteName;
            parameters[2].Value = model.Url;
            parameters[3].Value = model.LogoUrl;
            parameters[4].Value = model.QQ;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.Tel;
            parameters[7].Value = model.Mobile;
            parameters[8].Value = model.Demo;
            parameters[9].Value = model.IsHaveLogo;
            parameters[10].Value = model.OrderID;
            parameters[11].Value = model.SiteID;
            parameters[12].Value = model.IsAuditing;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void outlinks_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}outlinks ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        #endregion 写

    }
}

