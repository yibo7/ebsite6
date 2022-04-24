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
		private string sFieldSpaceSetting = "id,UserID,Title,Description,ReWriteName,ThemeID,ThemePath,DefaultTabID,Status,AddTime,UpdatedateTime,VisitedTimes";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int SpaceSetting_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}spacesetting", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool SpaceSetting_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}spacesetting", sPre);
            strSql.Append(" where UserID=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.SpaceSetting SpaceSetting_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldSpaceSetting + "  from {0}spacesetting ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.SpaceSetting model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = SpaceSetting_ReaderBind(dataReader);
                }
            }
            return model;
        }
        public int SpaceSetting_GetSpaceIDByUserID(int Userid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select id  from {0}spacesetting ", sPre);
            strSql.Append(" where UserID=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = Userid;

            object oid = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);

            if (oid != null)
                return int.Parse(oid.ToString());

            return 0;

        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int SpaceSetting_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}spacesetting ", sPre);
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
        public DataSet SpaceSetting_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldSpaceSetting);
            strSql.AppendFormat(" FROM {0}spacesetting ", sPre);
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
        public List<Entity.SpaceSetting> SpaceSetting_GetListArray(string strWhere)
        {
            return SpaceSetting_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.SpaceSetting> SpaceSetting_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldSpaceSetting);
            strSql.AppendFormat(" FROM {0}spacesetting ", sPre);
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
            List<Entity.SpaceSetting> list = new List<Entity.SpaceSetting>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(SpaceSetting_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.SpaceSetting> SpaceSetting_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.SpaceSetting> list = new List<Entity.SpaceSetting>();

            RecordCount = SpaceSetting_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "spacesetting", PageSize, PageIndex, "", "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {


                while (dataReader.Read())
                {
                    list.Add(SpaceSetting_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.SpaceSetting SpaceSetting_ReaderBind(IDataReader dataReader)
        {
            Entity.SpaceSetting model = new Entity.SpaceSetting();
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
            model.Title = dataReader["Title"].ToString();
            model.Description = dataReader["Description"].ToString();
            model.ReWriteName = dataReader["ReWriteName"].ToString();
            ojb = dataReader["ThemeID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ThemeID = (int)ojb;
            }
            model.ThemePath = dataReader["ThemePath"].ToString();
            ojb = dataReader["DefaultTabID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.DefaultTabID = (int)ojb;
            }
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = (int)ojb;
            }
            ojb = dataReader["AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddTime = (DateTime)ojb;
            }
            ojb = dataReader["UpdatedateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UpdatedateTime = (DateTime)ojb;
            }
            ojb = dataReader["VisitedTimes"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.VisitedTimes = (int)ojb;
            }
            return model;
        }
        public string SpaceSetting_GetThemePath(int UserID)
        {


            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select ThemePath  from {0}spacesetting ", sPre);
            strSql.Append(" where UserID=?UserID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4)};
            parameters[0].Value = UserID;
            string ThemePath = string.Empty;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    ThemePath = dataReader[0].ToString();
                }
            }
            return ThemePath;
        }
        public int SpaceSetting_GetDefaultTabID(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select DefaultTabID from {0}spacesetting", sPre);
            strSql.Append(" where UserID=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = UserID;

            string ob =  DbHelperCms.Instance.ExecuteScalarToStr(CommandType.Text, strSql.ToString(),parameters);
           return Core.Utils.StrToInt(ob,0);
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int SpaceSetting_Add(Entity.SpaceSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}spacesetting(", sPre);
            strSql.Append("UserID,Title,Description,ReWriteName,ThemeID,ThemePath,DefaultTabID,Status,AddTime,UpdatedateTime,VisitedTimes)");
            strSql.Append(" values (");
            strSql.Append("?UserID,?Title,?Description,?ReWriteName,?ThemeID,?ThemePath,?DefaultTabID,?Status,?AddTime,?UpdatedateTime,?VisitedTimes)");
            strSql.Append(";SELECT @@session.identity");

            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Title", MySqlDbType.VarChar,100),
					new MySqlParameter("?Description", MySqlDbType.VarChar,200),
					new MySqlParameter("?ReWriteName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ThemeID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ThemePath", MySqlDbType.VarChar,50),
					new MySqlParameter("?DefaultTabID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Status",  MySqlDbType.Int32,4),
					new MySqlParameter("?AddTime", MySqlDbType.Datetime),
					new MySqlParameter("?UpdatedateTime", MySqlDbType.Datetime),
					new MySqlParameter("?VisitedTimes",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.ReWriteName;
            parameters[4].Value = model.ThemeID;
            parameters[5].Value = model.ThemePath;
            parameters[6].Value = model.DefaultTabID;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.AddTime;
            parameters[9].Value = model.UpdatedateTime;
            parameters[10].Value = model.VisitedTimes;

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
        public void SpaceSetting_Update(Entity.SpaceSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}spacesetting set ", sPre);
            strSql.Append("UserID=?UserID,");
            strSql.Append("Title=?Title,");
            strSql.Append("Description=?Description,");
            strSql.Append("ReWriteName=?ReWriteName,");
            strSql.Append("ThemeID=?ThemeID,");
            strSql.Append("ThemePath=?ThemePath,");
            strSql.Append("DefaultTabID=?DefaultTabID,");
            strSql.Append("Status=?Status,");
            strSql.Append("AddTime=?AddTime,");
            strSql.Append("UpdatedateTime=?UpdatedateTime,");
            strSql.Append("VisitedTimes=?VisitedTimes");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Title", MySqlDbType.VarChar,100),
					new MySqlParameter("?Description", MySqlDbType.VarChar,200),
					new MySqlParameter("?ReWriteName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ThemeID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ThemePath", MySqlDbType.VarChar,50),
					new MySqlParameter("?DefaultTabID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Status",  MySqlDbType.Int32,4),
					new MySqlParameter("?AddTime", MySqlDbType.Datetime),
					new MySqlParameter("?UpdatedateTime", MySqlDbType.Datetime),
					new MySqlParameter("?VisitedTimes",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.ReWriteName;
            parameters[5].Value = model.ThemeID;
            parameters[6].Value = model.ThemePath;
            parameters[7].Value = model.DefaultTabID;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.AddTime;
            parameters[10].Value = model.UpdatedateTime;
            parameters[11].Value = model.VisitedTimes;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void SpaceSetting_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}spacesetting ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public void SpaceSetting_UpdateTheme(int UserID, int ThemeID, string ThemePath)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}spacesetting set ", sPre);
            strSql.AppendFormat("ThemeID={0},ThemePath='{1}'", ThemeID, ThemePath);
            strSql.AppendFormat(" where  UserID={0} ", UserID);
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        #endregion 写

    }
}

