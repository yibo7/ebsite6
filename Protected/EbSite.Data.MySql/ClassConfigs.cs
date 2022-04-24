using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EbSite.Entity;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;//请先添加引用

namespace EbSite.Data.MySql
{
    /// <summary>
    /// 数据访问类ebsite。
    /// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        private string sFieldClassConfigs = "id,ContentHtmlName,ClassHtmlNameRule,IsCanAddContent,ContentModelID,ContentTemID,ClassTemID,ClassModelID,SubClassAddName,SubClassTemID,SubClassModelID,SubDefaultContentModelID,SubDefaultContentTemID,SubIsCanAddSub,SubIsCanAddContent,IsCanAddSub,ListTemID,PageSize,ModuleID,AddTime,ClassTemIdMobile,ContentTemIdMobile,SiteID";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int ClassConfigs_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0} classconfigs", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ClassConfigs_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0} classconfigs", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }


        public List<Entity.ClassConfigs> GeClassConfigsByModuleId(Guid mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select *  from {0}classconfigs ", sPre);
            strSql.Append(" where ClassModelID=?ClassModelID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ClassModelID", MySqlDbType.VarChar,36)};
            parameters[0].Value = mid;
            List<Entity.ClassConfigs> list = new List<Entity.ClassConfigs>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                while (dataReader.Read())
                {
                    list.Add(ClassConfigs_ReaderBind(dataReader));
                }
            }
            return list;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.ClassConfigs ClassConfigs_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldClassConfigs + "  from {0}classconfigs ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.ClassConfigs model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = ClassConfigs_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int ClassConfigs_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}classconfigs ", sPre);
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
        public DataSet ClassConfigs_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldClassConfigs);
            strSql.AppendFormat(" FROM {0}classconfigs ", sPre);
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
        public List<Entity.ClassConfigs> ClassConfigs_GetListArray(string strWhere)
        {
            return ClassConfigs_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.ClassConfigs> ClassConfigs_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldClassConfigs);
            strSql.AppendFormat(" FROM {0}classconfigs ", sPre);
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
            List<Entity.ClassConfigs> list = new List<Entity.ClassConfigs>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(ClassConfigs_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.ClassConfigs> ClassConfigs_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.ClassConfigs> list = new List<Entity.ClassConfigs>();
            RecordCount = ClassConfigs_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, " classconfigs", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(ClassConfigs_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.ClassConfigs ClassConfigs_ReaderBind(IDataReader dataReader)
        {
            Entity.ClassConfigs model = new Entity.ClassConfigs();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.ContentHtmlName = dataReader["ContentHtmlName"].ToString();
            model.ClassHtmlNameRule = dataReader["ClassHtmlNameRule"].ToString();
            ojb = dataReader["IsCanAddContent"];
            if (ojb != null && ojb != DBNull.Value)
            {

                if ((dataReader["IsCanAddContent"].ToString() == "1") || (dataReader["IsCanAddContent"].ToString().ToLower() == "true"))
                {
                    model.IsCanAddContent = true;
                }
                else
                {
                    model.IsCanAddContent = false;
                }
            }
            model.ContentModelID = new Guid(dataReader["ContentModelID"].ToString());
            model.ContentTemID = new Guid(dataReader["ContentTemID"].ToString());
            model.ClassTemID = new Guid(dataReader["ClassTemID"].ToString());
            model.ClassModelID = new Guid(dataReader["ClassModelID"].ToString());
            model.SubClassAddName = dataReader["SubClassAddName"].ToString();
            model.SubClassTemID = new Guid(dataReader["SubClassTemID"].ToString());
            model.SubClassModelID = new Guid(dataReader["SubClassModelID"].ToString());
            model.SubDefaultContentModelID = new Guid(dataReader["SubDefaultContentModelID"].ToString());
            model.SubDefaultContentTemID = new Guid(dataReader["SubDefaultContentTemID"].ToString());
            ojb = dataReader["SubIsCanAddSub"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if ((dataReader["SubIsCanAddSub"].ToString() == "1") || (dataReader["SubIsCanAddSub"].ToString().ToLower() == "true"))
                {
                    model.SubIsCanAddSub = true;
                }
                else
                {
                    model.SubIsCanAddSub = false;
                }
            }
            ojb = dataReader["SubIsCanAddContent"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if ((dataReader["SubIsCanAddContent"].ToString() == "1") || (dataReader["SubIsCanAddContent"].ToString().ToLower() == "true"))
                {
                    model.SubIsCanAddContent = true;
                }
                else
                {
                    model.SubIsCanAddContent = false;
                }
            }
            ojb = dataReader["IsCanAddSub"];
            if (ojb != null && ojb != DBNull.Value)
            {

                if ((dataReader["IsCanAddSub"].ToString() == "1") || (dataReader["IsCanAddSub"].ToString().ToLower() == "true"))
                {
                    model.IsCanAddSub = true;
                }
                else
                {
                    model.IsCanAddSub = false;
                }
            }
            model.ListTemID = new Guid(dataReader["ListTemID"].ToString());
            ojb = dataReader["PageSize"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PageSize = int.Parse(ojb.ToString());
            }
            model.ModuleID = new Guid(dataReader["ModuleID"].ToString());
            //ojb = dataReader["ClassID"];
            //if (ojb != null && ojb != DBNull.Value)
            //{
            //    model.ClassID = ojb.ToString();// int.Parse(ojb.ToString());
            //}
            ojb = dataReader["AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddTime = (DateTime)ojb;
            }
            model.ClassTemIdMobile = new Guid(dataReader["ClassTemIdMobile"].ToString());
            model.ContentTemIdMobile = new Guid(dataReader["ContentTemIdMobile"].ToString());
            ojb = dataReader["SiteID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SiteID = int.Parse(ojb.ToString());
            }
            //ojb = dataReader["IsDefault"];
            //if (ojb != null && ojb != DBNull.Value)
            //{
            //    if ((dataReader["IsDefault"].ToString() == "1") || (dataReader["IsDefault"].ToString().ToLower() == "true"))
            //    {
            //        model.IsDefault = true;
            //    }
            //    else
            //    {
            //        model.IsDefault = false;
            //    }
            //}
            return model;
        }

        public bool IsHaveClassConfigs(int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}classconfigs", sPre);
            strSql.Append(" where siteid=?siteid ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?siteid", MySqlDbType.Int32)};
            parameters[0].Value = SiteID;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }

     //   public bool IsHaveClassConfigsByClassID(int ClassID)
     //   {
     //       StringBuilder strSql = new StringBuilder();
     //       strSql.AppendFormat("select count(1) from {0}classconfigs", sPre);
     //       strSql.Append(" where ClassID=?ClassID ");
     //       MySqlParameter[] parameters = {
					//new MySqlParameter("?ClassID", MySqlDbType.Int32)};
     //       parameters[0].Value = ClassID;

     //       return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
     //   }

        public Entity.ClassConfigs GeClassConfigs(int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldClassConfigs + "  from {0}classconfigs ", sPre);
            strSql.Append(" where siteid=?siteid ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?siteid", MySqlDbType.Int32)};
            parameters[0].Value = SiteID;
            Entity.ClassConfigs model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = ClassConfigs_ReaderBind(dataReader);
                }
            }
            return model;
        }
        public Entity.ClassConfigs GeClassConfigsByClassID(int ClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT * FROM {0}classconfigs a LEFT JOIN(SELECT * FROM {0}classsetconfig) b on a.id = b.ConfigId WHERE b.ClassId = {1}", sPre, ClassID);
           
            Entity.ClassConfigs model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                if (dataReader.Read())
                {
                    model = ClassConfigs_ReaderBind(dataReader);
                }
            }
            return model;


            //       StringBuilder strSql = new StringBuilder();
            //       strSql.AppendFormat("select " + sFieldClassConfigs + "  from {0}classconfigs ", sPre);
            //       strSql.Append(" where ClassID=?ClassID ");
            //       MySqlParameter[] parameters = {
            //new MySqlParameter("?ClassID", MySqlDbType.Int32)};
            //       parameters[0].Value = ClassID;
            //       Entity.ClassConfigs model = null;
            //       using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            //       {
            //           if (dataReader.Read())
            //           {
            //               model = ClassConfigs_ReaderBind(dataReader);
            //           }
            //       }
            //       return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int ClassConfigs_Add(Entity.ClassConfigs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}classconfigs(", sPre);
            strSql.Append("ContentHtmlName,ClassHtmlNameRule,IsCanAddContent,ContentModelID,ContentTemID,ClassTemID,ClassModelID,SubClassAddName,SubClassTemID,SubClassModelID,SubDefaultContentModelID,SubDefaultContentTemID,SubIsCanAddSub,SubIsCanAddContent,IsCanAddSub,ListTemID,PageSize,ModuleID,AddTime,ClassTemIdMobile,ContentTemIdMobile,SiteID)");
            strSql.Append(" values (");
            strSql.Append("?ContentHtmlName,?ClassHtmlNameRule,?IsCanAddContent,?ContentModelID,?ContentTemID,?ClassTemID,?ClassModelID,?SubClassAddName,?SubClassTemID,?SubClassModelID,?SubDefaultContentModelID,?SubDefaultContentTemID,?SubIsCanAddSub,?SubIsCanAddContent,?IsCanAddSub,?ListTemID,?PageSize,?ModuleID,?AddTime,?ClassTemIdMobile,?ContentTemIdMobile,?SiteID)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ContentHtmlName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ClassHtmlNameRule", MySqlDbType.VarChar,100),
					new MySqlParameter("?IsCanAddContent", MySqlDbType.Int16,4),
					new MySqlParameter("?ContentModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?ContentTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?ClassTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?ClassModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubClassAddName", MySqlDbType.VarChar,50),
					new MySqlParameter("?SubClassTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubClassModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubDefaultContentModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubDefaultContentTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubIsCanAddSub", MySqlDbType.Int16,2),
					new MySqlParameter("?SubIsCanAddContent", MySqlDbType.Int16,2),
					new MySqlParameter("?IsCanAddSub", MySqlDbType.Int16,2),
					new MySqlParameter("?ListTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?PageSize", MySqlDbType.Int16,3),
					new MySqlParameter("?ModuleID", MySqlDbType.VarChar,36),
					//new MySqlParameter("?ClassID", MySqlDbType.Int32,11),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?ClassTemIdMobile", MySqlDbType.VarChar,36),
					new MySqlParameter("?ContentTemIdMobile", MySqlDbType.VarChar,36),
					new MySqlParameter("?SiteID", MySqlDbType.Int32,11)
					//new MySqlParameter("?IsDefault", MySqlDbType.Int16,4)
            };
            parameters[0].Value = model.ContentHtmlName;
            parameters[1].Value = model.ClassHtmlNameRule;
            parameters[2].Value = model.IsCanAddContent;
            parameters[3].Value = model.ContentModelID;
            parameters[4].Value = model.ContentTemID;
            parameters[5].Value = model.ClassTemID;
            parameters[6].Value = model.ClassModelID;
            parameters[7].Value = model.SubClassAddName;
            parameters[8].Value = model.SubClassTemID;
            parameters[9].Value = model.SubClassModelID;
            parameters[10].Value = model.SubDefaultContentModelID;
            parameters[11].Value = model.SubDefaultContentTemID;
            parameters[12].Value = model.SubIsCanAddSub;
            parameters[13].Value = model.SubIsCanAddContent;
            parameters[14].Value = model.IsCanAddSub;
            parameters[15].Value = model.ListTemID;
            parameters[16].Value = model.PageSize;
            parameters[17].Value = model.ModuleID;
            //parameters[18].Value = model.ClassID;
            parameters[18].Value = model.AddTime;
            parameters[19].Value = model.ClassTemIdMobile;
            parameters[20].Value = model.ContentTemIdMobile;
            parameters[21].Value = model.SiteID;
            //parameters[22].Value = model.IsDefault;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据  注意，以分类ID为条件更新
        /// </summary>
        public void ClassConfigs_Update(Entity.ClassConfigs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}classconfigs set ", sPre);
            strSql.Append("ContentHtmlName=?ContentHtmlName,");
            strSql.Append("ClassHtmlNameRule=?ClassHtmlNameRule,");
            strSql.Append("IsCanAddContent=?IsCanAddContent,");
            strSql.Append("ContentModelID=?ContentModelID,");
            strSql.Append("ContentTemID=?ContentTemID,");
            strSql.Append("ClassTemID=?ClassTemID,");
            strSql.Append("ClassModelID=?ClassModelID,");
            strSql.Append("SubClassAddName=?SubClassAddName,");
            strSql.Append("SubClassTemID=?SubClassTemID,");
            strSql.Append("SubClassModelID=?SubClassModelID,");
            strSql.Append("SubDefaultContentModelID=?SubDefaultContentModelID,");
            strSql.Append("SubDefaultContentTemID=?SubDefaultContentTemID,");
            strSql.Append("SubIsCanAddSub=?SubIsCanAddSub,");
            strSql.Append("SubIsCanAddContent=?SubIsCanAddContent,");
            strSql.Append("IsCanAddSub=?IsCanAddSub,");
            strSql.Append("ListTemID=?ListTemID,");
            strSql.Append("PageSize=?PageSize,");
            strSql.Append("ModuleID=?ModuleID,");
            
            strSql.Append("AddTime=?AddTime,");
            strSql.Append("ClassTemIdMobile=?ClassTemIdMobile,");
            strSql.Append("ContentTemIdMobile=?ContentTemIdMobile,");
            strSql.Append("SiteID=?SiteID");
            //strSql.Append("IsDefault=?IsDefault,");
            //strSql.Append("ClassID=?ClassID");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
                   
					new MySqlParameter("?ContentHtmlName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ClassHtmlNameRule", MySqlDbType.VarChar,100),
					new MySqlParameter("?IsCanAddContent", MySqlDbType.Int16,4),
					new MySqlParameter("?ContentModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?ContentTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?ClassTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?ClassModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubClassAddName", MySqlDbType.VarChar,50),
					new MySqlParameter("?SubClassTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubClassModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubDefaultContentModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubDefaultContentTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubIsCanAddSub", MySqlDbType.Int16,2),
					new MySqlParameter("?SubIsCanAddContent", MySqlDbType.Int16,2),
					new MySqlParameter("?IsCanAddSub", MySqlDbType.Int16,2),
					new MySqlParameter("?ListTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?PageSize", MySqlDbType.Int16,3),
					new MySqlParameter("?ModuleID", MySqlDbType.VarChar,36), 
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?ClassTemIdMobile", MySqlDbType.VarChar,36),
					new MySqlParameter("?ContentTemIdMobile", MySqlDbType.VarChar,36),
					new MySqlParameter("?SiteID", MySqlDbType.Int32,11),
					//new MySqlParameter("?IsDefault", MySqlDbType.Int16,4),
                    //new MySqlParameter("?ClassID", MySqlDbType.VarChar,225),
                     new MySqlParameter("?id", MySqlDbType.Int32,11)
                                          };
           
            parameters[0].Value = model.ContentHtmlName;
            parameters[1].Value = model.ClassHtmlNameRule;
            parameters[2].Value = model.IsCanAddContent;
            parameters[3].Value = model.ContentModelID;
            parameters[4].Value = model.ContentTemID;
            parameters[5].Value = model.ClassTemID;
            parameters[6].Value = model.ClassModelID;
            parameters[7].Value = model.SubClassAddName;
            parameters[8].Value = model.SubClassTemID;
            parameters[9].Value = model.SubClassModelID;
            parameters[10].Value = model.SubDefaultContentModelID;
            parameters[11].Value = model.SubDefaultContentTemID;
            parameters[12].Value = model.SubIsCanAddSub;
            parameters[13].Value = model.SubIsCanAddContent;
            parameters[14].Value = model.IsCanAddSub;
            parameters[15].Value = model.ListTemID;
            parameters[16].Value = model.PageSize;
            parameters[17].Value = model.ModuleID;
            parameters[18].Value = model.AddTime;
            parameters[19].Value = model.ClassTemIdMobile;
            parameters[20].Value = model.ContentTemIdMobile;
            parameters[21].Value = model.SiteID;
            //parameters[22].Value = model.IsDefault;
            //parameters[23].Value = model.ClassID;
            parameters[22].Value = model.id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void ClassConfigs_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}classconfigs ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public void DeleteByClassID(int ClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}classconfigs ", sPre);
            strSql.Append(" where ClassID=?ClassID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassID", MySqlDbType.Int32)};
            parameters[0].Value = ClassID;
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public void UpdateDefaultClassConfigs(Entity.ClassConfigs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}classconfigs set ", sPre);
            strSql.Append("ContentHtmlName=?ContentHtmlName,");
            strSql.Append("ClassHtmlNameRule=?ClassHtmlNameRule,");
            strSql.Append("IsCanAddContent=?IsCanAddContent,");
            strSql.Append("ContentModelID=?ContentModelID,");
            strSql.Append("ContentTemID=?ContentTemID,");
            strSql.Append("ClassTemID=?ClassTemID,");
            strSql.Append("ClassModelID=?ClassModelID,");
            strSql.Append("SubClassAddName=?SubClassAddName,");
            strSql.Append("SubClassTemID=?SubClassTemID,");
            strSql.Append("SubClassModelID=?SubClassModelID,");
            strSql.Append("SubDefaultContentModelID=?SubDefaultContentModelID,");
            strSql.Append("SubDefaultContentTemID=?SubDefaultContentTemID,");
            strSql.Append("SubIsCanAddSub=?SubIsCanAddSub,");
            strSql.Append("SubIsCanAddContent=?SubIsCanAddContent,");
            strSql.Append("IsCanAddSub=?IsCanAddSub,");
            strSql.Append("ListTemID=?ListTemID,");
            strSql.Append("PageSize=?PageSize,");
            strSql.Append("ModuleID=?ModuleID,");
            //strSql.Append("ClassID=?ClassID,");
            strSql.Append("AddTime=?AddTime,");
            strSql.Append("ClassTemIdMobile=?ClassTemIdMobile,");
            strSql.Append("ContentTemIdMobile=?ContentTemIdMobile,");
            //strSql.Append("IsDefault=?IsDefault");
            strSql.Append(" where SiteID=?SiteID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ContentHtmlName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ClassHtmlNameRule", MySqlDbType.VarChar,100),
					new MySqlParameter("?IsCanAddContent", MySqlDbType.Int16,4),
					new MySqlParameter("?ContentModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?ContentTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?ClassTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?ClassModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubClassAddName", MySqlDbType.VarChar,50),
					new MySqlParameter("?SubClassTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubClassModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubDefaultContentModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubDefaultContentTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SubIsCanAddSub", MySqlDbType.Int16,2),
					new MySqlParameter("?SubIsCanAddContent", MySqlDbType.Int16,2),
					new MySqlParameter("?IsCanAddSub", MySqlDbType.Int16,2),
					new MySqlParameter("?ListTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?PageSize", MySqlDbType.Int16,3),
					new MySqlParameter("?ModuleID", MySqlDbType.VarChar,36),
					//new MySqlParameter("?ClassID", MySqlDbType.Int32,11),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?ClassTemIdMobile", MySqlDbType.VarChar,36),
					new MySqlParameter("?ContentTemIdMobile", MySqlDbType.VarChar,36),
					//new MySqlParameter("?IsDefault", MySqlDbType.Int16,4),
                    new MySqlParameter("?SiteID", MySqlDbType.Int32,11)
                                         
                                         };
            parameters[0].Value = model.ContentHtmlName;
            parameters[1].Value = model.ClassHtmlNameRule;
            parameters[2].Value = model.IsCanAddContent;
            parameters[3].Value = model.ContentModelID;
            parameters[4].Value = model.ContentTemID;
            parameters[5].Value = model.ClassTemID;
            parameters[6].Value = model.ClassModelID;
            parameters[7].Value = model.SubClassAddName;
            parameters[8].Value = model.SubClassTemID;
            parameters[9].Value = model.SubClassModelID;
            parameters[10].Value = model.SubDefaultContentModelID;
            parameters[11].Value = model.SubDefaultContentTemID;
            parameters[12].Value = model.SubIsCanAddSub;
            parameters[13].Value = model.SubIsCanAddContent;
            parameters[14].Value = model.IsCanAddSub;
            parameters[15].Value = model.ListTemID;
            parameters[16].Value = model.PageSize;
            parameters[17].Value = model.ModuleID;
            //parameters[18].Value = model.ClassID;
            parameters[18].Value = model.AddTime;
            parameters[19].Value = model.ClassTemIdMobile;
            parameters[20].Value = model.ContentTemIdMobile;
            //parameters[21].Value = model.IsDefault;
            parameters[21].Value = model.SiteID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}


