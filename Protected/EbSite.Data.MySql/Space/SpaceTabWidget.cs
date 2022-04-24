using System;
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
		private string sFieldSpaceTabWidget = "id,TabID,WidgetID,LayoutPane,UserID,OrderNum";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int SpaceTabWidget_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}spacetabwidget", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool SpaceTabWidget_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}spacetabwidget", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.SpaceTabWidget SpaceTabWidget_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldSpaceTabWidget + "  from {0}spacetabwidget ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.SpaceTabWidget model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = SpaceTabWidget_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int SpaceTabWidget_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}spacetabwidget ", sPre);
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
        public DataSet SpaceTabWidget_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldSpaceTabWidget);
            strSql.AppendFormat(" FROM {0}spacetabwidget ", sPre);
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
        public List<Entity.SpaceTabWidget> SpaceTabWidget_GetListArray(string strWhere)
        {
            return SpaceTabWidget_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.SpaceTabWidget> SpaceTabWidget_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldSpaceTabWidget);
            strSql.AppendFormat(" FROM {0}spacetabwidget  ", sPre);
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
            List<Entity.SpaceTabWidget> list = new List<Entity.SpaceTabWidget>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(SpaceTabWidget_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.SpaceTabWidget> SpaceTabWidget_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.SpaceTabWidget> list = new List<Entity.SpaceTabWidget>();
            RecordCount = SpaceThemeClass_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "spacetabwidget", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {

                while (dataReader.Read())
                {
                    list.Add(SpaceTabWidget_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.SpaceTabWidget SpaceTabWidget_ReaderBind(IDataReader dataReader)
        {
            Entity.SpaceTabWidget model = new Entity.SpaceTabWidget();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["TabID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TabID = (int)ojb;
            }
            ojb = dataReader["WidgetID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.WidgetID = new Guid(ojb.ToString());
            }
            model.LayoutPane = dataReader["LayoutPane"].ToString();
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            ojb = dataReader["OrderNum"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderNum = (int)ojb;
            }
            return model;
        }
        public bool SpaceTabWidget_Exists(int UserID, int TabID, Guid WidgetsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}spacetabwidget", sPre);
            strSql.Append(" where UserID=?UserID and  TabID=?TabID and  WidgetID=?WidgetID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?TabID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?WidgetID", MySqlDbType.VarChar,36)
                                          
                                          };
            parameters[0].Value = UserID;
            parameters[1].Value = TabID;
            parameters[2].Value = WidgetsID;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int SpaceTabWidget_Add(Entity.SpaceTabWidget model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}spacetabwidget(", sPre);
            strSql.Append("TabID,WidgetID,LayoutPane,UserID,OrderNum)");
            strSql.Append(" values (");
            strSql.Append("?TabID,?WidgetID,?LayoutPane,?UserID,?OrderNum)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TabID",  MySqlDbType.Int32,4),
					new MySqlParameter("?WidgetID", MySqlDbType.VarChar,36),
					new MySqlParameter("?LayoutPane", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?OrderNum",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.TabID;
            parameters[1].Value = model.WidgetID;
            parameters[2].Value = model.LayoutPane;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.OrderNum;

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
        public void SpaceTabWidget_Update(Entity.SpaceTabWidget model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}spacetabwidget set ", sPre);
            strSql.Append("TabID=?TabID,");
            strSql.Append("WidgetID=?WidgetID,");
            strSql.Append("LayoutPane=?LayoutPane,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("OrderNum=?OrderNum");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4),
					new MySqlParameter("?TabID",  MySqlDbType.Int32,4),
					new MySqlParameter("?WidgetID", MySqlDbType.VarChar,36),
					new MySqlParameter("?LayoutPane", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?OrderNum",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.TabID;
            parameters[2].Value = model.WidgetID;
            parameters[3].Value = model.LayoutPane;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.OrderNum;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void SpaceTabWidget_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}spacetabwidget ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public void SpaceTabWidget_UpdateChange(int id, string Layout, Guid WidgetID, int OrderNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}spacetabwidget set ", sPre);
            strSql.Append("WidgetID=?WidgetID,");
            strSql.Append("LayoutPane=?LayoutPane,");
            strSql.Append("OrderNum=?OrderNum");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?WidgetID", MySqlDbType.VarChar,36),
					new MySqlParameter("?LayoutPane", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderNum",  MySqlDbType.Int32,4),
                    new MySqlParameter("?id",  MySqlDbType.Int32,4)
                                          };

            parameters[0].Value = WidgetID;
            parameters[1].Value = Layout;
            parameters[2].Value = OrderNum;
            parameters[3].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public void SpaceTabWidget_Dels(int UserID, int TabID, string WidgetsIDs)
        {
            string[] aWidgetsIDs = WidgetsIDs.Split(',');
            foreach (string aWidgetsID in aWidgetsIDs)
            {
                if (!string.IsNullOrEmpty(aWidgetsID))
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.AppendFormat("delete from {0}spacetabwidget ", sPre);
                    strSql.Append(" where UserID=?UserID and TabID=?TabID and  WidgetID=?WidgetID");
                    MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?TabID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?WidgetID", MySqlDbType.VarChar,36)
                                          };
                    parameters[0].Value = UserID;
                    parameters[1].Value = TabID;
                    parameters[2].Value = new Guid(aWidgetsID);

                    DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
                }

            }


            //StringBuilder strSql = new StringBuilder();
            //strSql.AppendFormat("delete from {0}SpaceTabWidget ", sPre);
            //string[] aWidgetsIDs = WidgetsIDs.Split(',');
            //StringBuilder sb = new StringBuilder();
            //foreach (string sWidgetsID in aWidgetsIDs)
            //{
            //    sb.AppendFormat("'{0}',", sWidgetsID);

            //}
            //if (sb.Length > 0)
            //    sb.Remove(sb.Length - 1, 1);
            //strSql.AppendFormat(" where UserID={0} and TabID={1} and WidgetID in({2}) ", UserID, TabID, sb.ToString());


            //DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        #endregion 写

    }
}

