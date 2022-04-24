using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;//请先添加引用
namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类TagKey。
	/// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{
        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int TagKey_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", "tagkey");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool TagKey_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}tagkey ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在符合某条件的记录
        /// </summary>
        public bool TagKey_Exists(string sWhere, int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}tagkey where  SiteID={1} and", sPre, SiteID);
            strSql.Append(sWhere);

            return DbHelperCms.Instance.Exists(strSql.ToString());

        }




        /// <summary>
        /// 获取总记录条数
        /// </summary>
        /// <returns></returns>
        public int TagKey_GetCount(string strWhere, int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.AppendFormat(" from  {0}tagkey where SiteID={1}", sPre, SiteID);

            if (strWhere.Trim() != "")
            {

                strSql.Append(" and " + strWhere);
            }
            //Database db = DatabaseFactory.CreateDatabase();
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
        /// 获取所有id列表
        /// </summary>
        /// <returns></returns>
        public List<int> TagKey_GetIDList(string sWhere, int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID ");
            strSql.AppendFormat(" from  {0}tagkey where SiteID={1}", sPre, SiteID);

            if (!string.IsNullOrEmpty(sWhere.Trim()))
            {
                strSql.Append(" and ");
                strSql.Append(sWhere);
            }

            List<int> IDs = new List<int>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    IDs.Add(int.Parse(dataReader[0].ToString()));
                }
            }
            return IDs;
        }



        public List<EbSite.Entity.TagKey> TagKey_GetTagByContentID(int ContentID, int ClassId,string OrderByCol,int Top, int SiteID, int Num)
        {
            //string sWhere = string.Concat(" id in(select TagID from ", sPre, "TagRelateNews where  ClassID=", ClassId, " AND NewsID=", ContentID, ")  AND SiteID=", SiteID, " ORDER BY ", OrderByCol, " desc LIMIT ", Top);

            string sWhere = string.Concat(" id in(select TagID from ", sPre, "TagRelateNews where  ClassID=", ClassId, "  AND NewsID=", ContentID, ")");
            return TagKey_GetListArr(sWhere, Top, string.Concat(OrderByCol," desc"), SiteID, Num);
        }

        /// <summary>
        /// 分页获取数据列表 只适用 sql 2005
        /// </summary>
        public List<EbSite.Entity.TagKey> TagKey_GetListPages(int PageIndex, int PageSize, string sWhere, string oderby, out int Count, int SiteID)
        {
            //int RecordCount = 0;

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat(" SiteID={0}", SiteID);

            if (!string.IsNullOrEmpty(sWhere.Trim()))
            {
                sbSql.Append(" and ");
                sbSql.AppendFormat(sWhere);
            }

            List<EbSite.Entity.TagKey> list = new List<EbSite.Entity.TagKey>();

            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "TagKey", PageSize, PageIndex, "", "id", oderby, sbSql.ToString(), sPre);
            Count = TagKey_GetCount(sbSql.ToString(), SiteID);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(TagKey_ReaderBind(dataReader));
                }
            }

            return list;
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EbSite.Entity.TagKey TagKey_GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from  {0}tagkey ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            EbSite.Entity.TagKey model = new EbSite.Entity.TagKey();
            DataSet ds = DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.TagName = ds.Tables[0].Rows[0]["TagName"].ToString();
                if (ds.Tables[0].Rows[0]["Num"].ToString() != "")
                {
                    model.Num = int.Parse(ds.Tables[0].Rows[0]["Num"].ToString());
                }
                model.RelateClassIDs = ds.Tables[0].Rows[0]["RelateClassIDs"].ToString();

                if (ds.Tables[0].Rows[0]["SiteID"].ToString() != "")
                {
                    model.SiteID = int.Parse(ds.Tables[0].Rows[0]["SiteID"].ToString());
                }
                model.HtmlName = ds.Tables[0].Rows[0]["HtmlName"].ToString();
                model.HtmlNameRule = ds.Tables[0].Rows[0]["HtmlNameRule"].ToString();
                model.SeoTitle = ds.Tables[0].Rows[0]["SeoTitle"].ToString();
                model.SeoKeyWord = ds.Tables[0].Rows[0]["SeoKeyWord"].ToString();
                model.SeoDescription = ds.Tables[0].Rows[0]["SeoDescription"].ToString();


                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public int TagKey_GetTagIDByName(string sTag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select  id from  {0}tagkey ", sPre);
            strSql.Append(" where TagName=?TagName limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TagName", MySqlDbType.VarChar,100)};
            parameters[0].Value = sTag;

            int iID = -1;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                while (dataReader.Read())
                {
                    iID = int.Parse(dataReader[0].ToString());
                }
            }
            return iID;

        }

        public List<EbSite.Entity.TagKey> TagKey_GetTagKeysByClassID(int Top, int ClassID, string OrderBy, int SiteID, int Num)
        {
            string sTableName = Base.AppStartInit.GetTableNameByClassID(ClassID);
            string strWhere = string.Format(" id in(SELECT DISTINCT tagid from {0}TagRelateNews where newsid in(SELECT  id From {0}{2} Where Classid={1}))", sPre, ClassID, sTableName);
            return TagKey_GetListArr(strWhere, Top, OrderBy, SiteID, Num);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EbSite.Entity.TagKey> TagKey_GetListArr(string strWhere, int Top, string OrderBy, int SiteID,int Num)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(" * ");
            strSql.AppendFormat(" from  {0}tagkey where SiteID={1}", sPre, SiteID);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }

            strSql.Append(" AND Num>=");
            strSql.Append(Num);

            if (!string.IsNullOrEmpty(OrderBy))
            {
                strSql.Append(" order by ");
                strSql.Append(OrderBy);
            }

           

            if (Top > 0)
            {
                strSql.Append(" limit ");
                strSql.Append(Top);
            }
            List<EbSite.Entity.TagKey> list = new List<EbSite.Entity.TagKey>();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(TagKey_ReaderBind(dataReader));
                }
            }
            return list;
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public EbSite.Entity.TagKey TagKey_ReaderBind(IDataReader dataReader)
        {
            EbSite.Entity.TagKey model = new EbSite.Entity.TagKey();

            if (!string.IsNullOrEmpty(dataReader["ID"].ToString()))
            {
                model.id = int.Parse(dataReader["ID"].ToString());
            }
            model.TagName = dataReader["TagName"].ToString();
            if (dataReader["Num"].ToString() != "")
            {
                model.Num = int.Parse(dataReader["Num"].ToString());
            }
            model.RelateClassIDs = dataReader["RelateClassIDs"].ToString();
            if (!string.IsNullOrEmpty(dataReader["SiteID"].ToString()))
            {
                model.SiteID = int.Parse(dataReader["SiteID"].ToString());
            }

            model.HtmlName = dataReader["HtmlName"].ToString();
            model.HtmlNameRule = dataReader["HtmlNameRule"].ToString();
            model.SeoTitle = dataReader["SeoTitle"].ToString();
            model.SeoKeyWord = dataReader["SeoKeyWord"].ToString();
            model.SeoDescription = dataReader["SeoDescription"].ToString();

            return model;
        }

        public DataSet TagKey_GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.AppendFormat(" from  {0}tagkey ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet TagKey_GetList(int top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select  id,TagName,Num,RelateClassIDs,SiteID,HtmlName,HtmlNameRule,SeoTitle,SeoKeyWord,SeoDescription ");
            strSql.AppendFormat(" from  {0}tagkey ", sPre);
            strSql.Append(" order by -Num");
            if (top > 0)
            {
                strSql.AppendFormat(" limit {0}", top);
            }
            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        #endregion 读

        #region 写
        public void TagKey_UpdateAllHtmlRule(string Rule)
        {

            string sql = string.Format("update {0}tagkey set HtmlNameRule=?HtmlNameRule", sPre);

            MySqlParameter[] parameters = {
                    new MySqlParameter("?HtmlNameRule",MySqlDbType.VarChar,300) 
                                        };
            parameters[0].Value = Rule;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sql, parameters);

        }

        public void TagKey_UpdateHtmlName(string HtmlName, int KeyID)
        {
            string sql = string.Format("update {0}tagkey set HtmlName=?HtmlName where id=?id ", sPre);

            MySqlParameter[] parameters = {
					
                    new MySqlParameter("?HtmlName",MySqlDbType.VarChar,300),
                    new MySqlParameter("?id",  MySqlDbType.Int32,4)
                                        };
            parameters[0].Value = HtmlName;
            parameters[1].Value = KeyID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sql, parameters);

        }
        private void UpdateTagID(string TagRelateTableName, int iSourID, int TargetID)
        {
            string sql = string.Format("update {0}{1} set TagID=?TargetID where TagID=?TagID ", sPre, TagRelateTableName);

            MySqlParameter[] parameters = {
					
                    new MySqlParameter("?TargetID", MySqlDbType.Int32,4),
                    new MySqlParameter("?TagID",  MySqlDbType.Int32,4)
                                        };
            parameters[0].Value = TargetID;
            parameters[1].Value = iSourID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sql, parameters);
        }
        public void TagKey_MergeLable(int iSourID, int TargetID)
        {
            Entity.TagKey mdSour = TagKey_GetModel(iSourID);
            Entity.TagKey mdTarget = TagKey_GetModel(TargetID);

            if (mdSour != null)
            {
                UpdateTagID("TagRelateNews", iSourID, TargetID);
                UpdateTagID("TagRelateClass", iSourID, TargetID);
                UpdateTagID("TagRelateUser", iSourID, TargetID);

                mdTarget.Num += mdSour.Num;

                TagKey_Update(mdTarget);

                TagKey_Delete(iSourID);

            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void TagKey_Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}tagkey ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查添加一个标签-递增型,如果已经有相同名称的标签将不做添加操作，中在num上加一
        /// </summary>
        /// <param name="tagname"></param>
        /// <param name="ContentID"></param>
        /// <returns></returns>
        public int TagKey_UpdateByAdd(string tagname, int SiteID)
        {
            return TagKey_UpdateByAdd(tagname, 0, SiteID);
        }

        /// <summary>
        /// 检查添加一个标签-递增型,如果已经有相同名称的标签将不做添加操作，中在num上加一
        /// </summary>
        /// <param name="tagname"></param>
        public int TagKey_UpdateByAdd(string tagname, long ContentID, int SiteID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select id from  {0}tagkey where SiteID={1} and ", sPre, SiteID);
            strSql.Append("TagName=?TagName");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TagName", MySqlDbType.VarChar,100)};
            parameters[0].Value = tagname;
            object oID = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            int iID = -1;
            if (!Equals(oID, null)) iID = int.Parse(oID.ToString());

            if (iID > 0)
            {
                if (ContentID > 0) //这种情况是修改记录的情况，ContentID大于0时先检测是否已经存在与此id关联的标签，如果有，就不做操作了
                {
                    string sSql = string.Concat("select id from ", sPre, "TagRelateNews where TagID=", iID, " and NewsID=", ContentID);
                    bool isEx = DbHelperCmsWrite.Instance.Exists(sSql);

                    if (isEx) return -1;
                }
                strSql.Length = 0;
                strSql.AppendFormat("update  {0}tagkey set ", sPre);
                strSql.Append("Num=Num+1");
                strSql.Append(" where id=");
                strSql.Append(iID);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }
            else
            {
                Entity.TagKey mt = new Entity.TagKey();

                mt.Num = 1;
                mt.TagName = tagname;
                mt.SiteID = SiteID;
                iID = TagKey_Add(mt);
            }

            return iID;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int TagKey_Add(EbSite.Entity.TagKey model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into  {0}tagkey(", sPre);
            strSql.Append("TagName,Num,RelateClassIDs,SiteID,HtmlName,HtmlNameRule,SeoTitle,SeoKeyWord,SeoDescription)");
            strSql.Append(" values (");
            strSql.Append("?TagName,?Num,?RelateClassIDs,?SiteID,?HtmlName,?HtmlNameRule,?SeoTitle,?SeoKeyWord,?SeoDescription)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TagName", MySqlDbType.VarChar,100),
					new MySqlParameter("?Num",  MySqlDbType.Int32,4),
                    new MySqlParameter("?RelateClassIDs", MySqlDbType.VarChar,500),
                    new MySqlParameter("?SiteID", MySqlDbType.Int32,4) ,

                    new MySqlParameter("?HtmlName",MySqlDbType.VarChar,300) ,
                    new MySqlParameter("?HtmlNameRule",MySqlDbType.VarChar,300) ,
                    new MySqlParameter("?SeoTitle",MySqlDbType.VarChar,300) ,
                    new MySqlParameter("?SeoKeyWord",MySqlDbType.VarChar,500) ,
                    new MySqlParameter("?SeoDescription",MySqlDbType.VarChar,500)
                                        
                                        };
            parameters[0].Value = model.TagName;
            parameters[1].Value = model.Num;
            parameters[2].Value = model.RelateClassIDs;
            parameters[3].Value = model.SiteID;

            parameters[4].Value = model.HtmlName;
            parameters[5].Value = model.HtmlNameRule;
            parameters[6].Value = model.SeoTitle;
            parameters[7].Value = model.SeoKeyWord;
            parameters[8].Value = model.SeoDescription;

            //HtmlName,HtmlNameRule,SeoTitle,SeoKeyWord,SeoDescription

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
        public void TagKey_Update(EbSite.Entity.TagKey model)
        {
            //HtmlName,HtmlNameRule,SeoTitle,SeoKeyWord,SeoDescription
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}tagkey set ", sPre);
            strSql.Append("TagName=?TagName,");
            strSql.Append("Num=?Num,");
            strSql.Append("RelateClassIDs=?RelateClassIDs,");
            strSql.Append("SiteID=?SiteID,");

            strSql.Append("HtmlName=?HtmlName,");
            strSql.Append("HtmlNameRule=?HtmlNameRule,");
            strSql.Append("SeoTitle=?SeoTitle,");
            strSql.Append("SeoKeyWord=?SeoKeyWord,");
            strSql.Append("SeoDescription=?SeoDescription");

            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4),
					new MySqlParameter("?TagName", MySqlDbType.VarChar,100),
					new MySqlParameter("?Num",  MySqlDbType.Int32,4),
                    new MySqlParameter("?RelateClassIDs", MySqlDbType.VarChar,500),
                    new MySqlParameter("?SiteID", MySqlDbType.Int32,4), 
                    
                    new MySqlParameter("?HtmlName",MySqlDbType.VarChar,300) ,
                    new MySqlParameter("?HtmlNameRule",MySqlDbType.VarChar,300) ,
                    new MySqlParameter("?SeoTitle",MySqlDbType.VarChar,300) ,
                    new MySqlParameter("?SeoKeyWord",MySqlDbType.VarChar,500) ,
                    new MySqlParameter("?SeoDescription",MySqlDbType.VarChar,500) 
                                        
                                        };
            parameters[0].Value = model.id;
            parameters[1].Value = model.TagName;
            parameters[2].Value = model.Num;
            parameters[3].Value = model.RelateClassIDs;
            parameters[4].Value = model.SiteID;

            parameters[5].Value = model.HtmlName;
            parameters[6].Value = model.HtmlNameRule;
            parameters[7].Value = model.SeoTitle;
            parameters[8].Value = model.SeoKeyWord;
            parameters[9].Value = model.SeoDescription;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 检查添加一个标签-递减型
        /// </summary>
        /// <param name="tagid"></param>
        public int TagKey_UpdateByDelete(int tagid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select Num from  {0}tagkey where ", sPre);
            strSql.Append("ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.VarChar,100)};
            parameters[0].Value = tagid;
            object oID = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            int iNum = -1;
            if (!Equals(oID, null)) iNum = int.Parse(oID.ToString());

            if (iNum > 1)
            {
                strSql.Length = 0;
                strSql.AppendFormat("update {0}tagkey set ", sPre);
                strSql.Append("Num=Num-1");
                strSql.Append(" where id=");
                strSql.Append(tagid);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }
            else
            {
                TagKey_Delete(tagid);
            }

            return tagid;
        }

        #endregion 写
    }
}

