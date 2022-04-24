using System;
using System.Collections;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类EbSitePlace。
	/// </summary>
	public partial class DataProviderCms : Interface.IDataProviderCms
	{
        private string sFieldSpaceTabs = "id,TabName,Layout,OrderNum,ICOImg,UserID,ParentID,Mark";     

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int SpaceTabs_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}spacetabs", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool SpaceTabs_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}spacetabs", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.SpaceTabs SpaceTabs_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldSpaceTabs + "  from {0}spacetabs ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.SpaceTabs model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = SpaceTabs_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int SpaceTabs_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}spacetabs ", sPre);
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
        public DataSet SpaceTabs_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldSpaceTabs);
            strSql.AppendFormat(" FROM {0}spacetabs ", sPre);
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
        public List<Entity.SpaceTabs> SpaceTabs_GetListArray(string strWhere)
        {
            return SpaceTabs_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.SpaceTabs> SpaceTabs_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldSpaceTabs);
            strSql.AppendFormat(" FROM {0}spacetabs  ", sPre);
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
            List<Entity.SpaceTabs> list = new List<Entity.SpaceTabs>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(SpaceTabs_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.SpaceTabs> SpaceTabs_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.SpaceTabs> list = new List<Entity.SpaceTabs>();

            RecordCount = SpaceTabs_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "spacetabs", PageSize, PageIndex, "", "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(SpaceTabs_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.SpaceTabs SpaceTabs_ReaderBind(IDataReader dataReader)
        {
            Entity.SpaceTabs model = new Entity.SpaceTabs();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.TabName = dataReader["TabName"].ToString();
            model.Layout = dataReader["Layout"].ToString();
            ojb = dataReader["OrderNum"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderNum = (int)ojb;
            }
            model.ICOImg = dataReader["ICOImg"].ToString();
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            ojb = dataReader["ParentID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ParentID = (int)ojb;
            }
            model.Mark = dataReader["Mark"].ToString();
            return model;
        }
        public string SpaceTabs_GetLayoutName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select Layout  from {0}spacetabs ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            object oid = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (oid != null)
                return oid.ToString();
            return string.Empty;
        }
        public int SpaceTabs_GetMaxOrderID(int UserId)
        {
            string sSql = string.Concat("select Max(OrderNum)  from  ", sPre, "spacetabs where UserID=", UserId);
            object MaxID = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, sSql);
            if (MaxID != null && !string.IsNullOrEmpty(MaxID.ToString()))
            {
                return int.Parse(MaxID.ToString());
            }
            else
            {
                return 0;
            }
        }

        public int SpaceTabs_GetTabIDFormMark(int ParentID, string Mark)
        {
            string sSql = string.Concat("select id  from  ", sPre, "spacetabs where ParentID=?ParentID and Mark=?Mark ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?Mark",MySqlDbType.VarChar,30),                      
                                          };
            parameters[0].Value = ParentID;
            parameters[1].Value = Mark;


            object TabID = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, sSql, parameters);
            if (TabID != null && !string.IsNullOrEmpty(TabID.ToString()))
            {
                return int.Parse(TabID.ToString());
            }
            else
            {
                return 0;
            }
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int SpaceTabs_Add(Entity.SpaceTabs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}spacetabs(", sPre);
            strSql.Append("TabName,Layout,OrderNum,ICOImg,UserID,ParentID,Mark)");
            strSql.Append(" values (");
            strSql.Append("?TabName,?Layout,?OrderNum,?ICOImg,?UserID,?ParentID,?Mark)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TabName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Layout", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?ICOImg", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),     
                    new MySqlParameter("?Mark",MySqlDbType.VarChar,30),     
                                        };
            parameters[0].Value = model.TabName;
            parameters[1].Value = model.Layout;
            parameters[2].Value = model.OrderNum;
            parameters[3].Value = model.ICOImg;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.ParentID;
            parameters[6].Value = model.Mark;

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
        public void SpaceTabs_Update(Entity.SpaceTabs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}spacetabs set ", sPre);
            strSql.Append("TabName=?TabName,");
            strSql.Append("Layout=?Layout,");
            strSql.Append("OrderNum=?OrderNum,");
            strSql.Append("ICOImg=?ICOImg,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("ParentID=?ParentID,Mark=?Mark");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4),
					new MySqlParameter("?TabName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Layout", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?ICOImg", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?Mark",MySqlDbType.VarChar,30)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.TabName;
            parameters[2].Value = model.Layout;
            parameters[3].Value = model.OrderNum;
            parameters[4].Value = model.ICOImg;
            parameters[5].Value = model.UserID;
            parameters[6].Value = model.ParentID;
            parameters[7].Value = model.Mark;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void SpaceTabs_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}spacetabs ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public void SpaceTabs_UpdateOrders(int UserId, Hashtable ht)
        {
            StringBuilder strSql = new StringBuilder();

            foreach (DictionaryEntry entry in ht)
            {
                string tid = entry.Key.ToString();
                string OrderNumber = entry.Value.ToString();
                strSql.AppendFormat("update {0}spacetabs set ", sPre);
                strSql.AppendFormat("OrderNum={0}", OrderNumber);
                strSql.AppendFormat(" where id={0} and UserID={1}; ", tid, UserId);
            }

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        public void SpaceTabs_UpdateLayout(int UserID, int TabID, string LayoutName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}spacetabs set ", sPre);
            strSql.AppendFormat("Layout='{0}'", LayoutName);
            strSql.AppendFormat(" where id={0} and UserID={1} ", TabID, UserID);
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        #endregion 写

    }
}

