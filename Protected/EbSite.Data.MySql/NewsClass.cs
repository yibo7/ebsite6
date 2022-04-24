using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EbSite.Base;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;
using EbSite.Entity;

//请先添加引用
namespace EbSite.Data.MySql
{
    /// <summary>
    /// 数据访问类NewsClass。
    /// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int NewsClass_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("ID", "newsclass");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool NewsClass_Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}newsclass", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }
        public Guid NewsClass_TemID(int ClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select ClassTemID from  {0}newsclass", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ClassID;
            string obj = DbHelperCms.Instance.ExecuteScalarToStr(CommandType.Text, strSql.ToString(), parameters);
            if (!string.IsNullOrEmpty(obj))
            {
                return new Guid(obj);
            }
            return Guid.Empty;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EbSite.Entity.NewsClass NewsClass_GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat("select * from  {0}newsclass ", sPre);
            strSql.Append(" where ID=?ID limit 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            Entity.NewsClass model = new Entity.NewsClass();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = NewsClass_ReaderBind(dataReader);

                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<EbSite.Entity.NewsClass> NewsClass_GetListArray(string strWhere, int SiteID)
        {
            return NewsClass_GetListArray(strWhere, 0, "", SiteID);
        }

        /// <summary>
        /// 获取总记录条数
        /// </summary>
        /// <returns></returns>
        public int NewsClass_GetCount(string strWhere, int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.AppendFormat(" from  {0}newsclass where SiteID={1}", sPre, SiteID);

            if (strWhere.Equals("d"))
            {
                strWhere = "datediff(AddTime,NOW())=0";
            }
            else if (strWhere.Equals("w"))
            {
                strWhere = "datediff(AddTime,NOW())=0";
            }
            else if (strWhere.Equals("m"))
            {
                strWhere = "datediff(AddTime,NOW())=0";
            }
            else if (strWhere.Equals("q"))
            {
                strWhere = "datediff(AddTime,NOW())=0";
            }
            else if (strWhere.Equals("y"))
            {
                strWhere = "datediff(AddTime,NOW())=0";
            }

            if (strWhere.Trim() != "")
            {

                strSql.Append(" and " + strWhere);
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
        /// 分页获取数据列表 
        /// </summary>
        public List<EbSite.Entity.NewsClass> NewsClass_GetListPages(int PageIndex, int PageSize, string sWhere, string oderby, int SiteID)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat(" SiteID={0}", SiteID);

            if (!string.IsNullOrEmpty(sWhere.Trim()))
            {
                sbSql.Append(" and ");
                sbSql.AppendFormat(sWhere);
            }

            int RecordCount = 0;

            List<EbSite.Entity.NewsClass> list = new List<EbSite.Entity.NewsClass>();


            RecordCount = NewsClass_GetCount(sbSql.ToString(), SiteID);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "NewsClass", PageSize, PageIndex, "", "id", oderby, sbSql.ToString(), sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {

                while (dataReader.Read())
                {
                    list.Add(NewsClass_ReaderBind(dataReader));
                }
            }

            return list;


        }

        public List<EbSite.Entity.NewsClass> NewsClass_GetListHtmlNameReWrite()
        {
          
         
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat("select *  from  {0}newsclass where IsHtmlNameReWrite=1 or IsHtmlNameReWriteContent=1 ", sPre);
           
            List<EbSite.Entity.NewsClass> list = new List<EbSite.Entity.NewsClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(NewsClass_ReaderBind(dataReader));
                }
            }
            return list;
        }
        
        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<EbSite.Entity.NewsClass> NewsClass_GetListArray(string strWhere, int iTop, string OrderBy, int SiteID)
        {
            string sTop = "";

            if (iTop > 0) sTop = string.Concat(" limit ", iTop);
            if (!string.IsNullOrEmpty(OrderBy)) OrderBy = string.Concat(" order by ", OrderBy);
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat("select * ");
            strSql.AppendFormat(" from  {0}newsclass where SiteID={1} ", sPre, SiteID);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and  " + strWhere);
            }
            strSql.Append(OrderBy);
            strSql.Append(" " + sTop);
            List<EbSite.Entity.NewsClass> list = new List<EbSite.Entity.NewsClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(NewsClass_ReaderBind(dataReader));
                }
            }
            return list;
        }

        #region 对象实体绑定数据

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public EbSite.Entity.NewsClass NewsClass_ReaderBind(IDataReader dataReader)
        {
            Entity.NewsClass model = new Entity.NewsClass();
            if (dataReader["ID"].ToString() != "")
            {
                model.ID = int.Parse(dataReader["ID"].ToString());
            }
            if (!Equals(dataReader["ClassName"], null))
            {
                model.ClassName = dataReader["ClassName"].ToString();
            }
            if (dataReader["OrderID"].ToString() != "")
            {
                model.OrderID = int.Parse(dataReader["OrderID"].ToString());
            }
            if (dataReader["ParentID"].ToString() != "")
            {
                model.ParentID = int.Parse(dataReader["ParentID"].ToString());
            }
            if (dataReader["HtmlName"].ToString() != "")
            {
                model.HtmlName = dataReader["HtmlName"].ToString();
            }

            if (dataReader["Info"].ToString() != "")
            {
                model.Info = dataReader["Info"].ToString();
            }
            if (dataReader["TitleStyle"].ToString() != "")
            {
                model.TitleStyle = dataReader["TitleStyle"].ToString();
            } 
            model.SeoTitle = dataReader["SeoTitle"].ToString();
            if (dataReader["dayHits"].ToString() != "")
            {
                model.dayHits = int.Parse(dataReader["dayHits"].ToString());
            }
            if (dataReader["weekHits"].ToString() != "")
            {
                model.weekHits = int.Parse(dataReader["weekHits"].ToString());
            }
            if (dataReader["monthhits"].ToString() != "")
            {
                model.monthhits = int.Parse(dataReader["monthhits"].ToString());
            }
            if (dataReader["lasthitstime"].ToString() != "")
            {
                model.lasthitstime = DateTime.Parse(dataReader["lasthitstime"].ToString());
            }
            if (dataReader["hits"].ToString() != "")
            {
                model.hits = int.Parse(dataReader["hits"].ToString());
            }
            model.SeoKeyWord = dataReader["SeoKeyWord"].ToString();
            model.SeoDescription = dataReader["SeoDescription"].ToString();
            model.OutLike = dataReader["OutLike"].ToString();

            model.Annex1 = dataReader["Annex1"].ToString();
            model.Annex2 = dataReader["Annex2"].ToString();
            model.Annex3 = dataReader["Annex3"].ToString();
            model.Annex4 = dataReader["Annex4"].ToString();
            model.Annex5 = dataReader["Annex5"].ToString();
            model.Annex6 = dataReader["Annex6"].ToString();
            model.Annex7 = dataReader["Annex7"].ToString();
            model.Annex8 = dataReader["Annex8"].ToString();
            model.Annex9 = dataReader["Annex9"].ToString();
            model.Annex10 = dataReader["Annex10"].ToString();


            if (dataReader["Annex16"].ToString() != "")
            {
                model.Annex16 = int.Parse(dataReader["Annex16"].ToString());
            }
            if (dataReader["Annex17"].ToString() != "")
            {
                model.Annex17 = int.Parse(dataReader["Annex17"].ToString());
            }



            if (dataReader["Annex11"].ToString() != "")
            {
                model.Annex11 = int.Parse(dataReader["Annex11"].ToString());
            }
            if (dataReader["Annex12"].ToString() != "")
            {
                model.Annex12 = int.Parse(dataReader["Annex12"].ToString());
            }
            if (dataReader["Annex13"].ToString() != "")
            {
                model.Annex13 = int.Parse(dataReader["Annex13"].ToString());
            }
            if (dataReader["Annex14"].ToString() != "")
            {
                model.Annex14 = int.Parse(dataReader["Annex14"].ToString());
            }
            if (dataReader["Annex15"].ToString() != "")
            {
                model.Annex15 = float.Parse(dataReader["Annex15"].ToString());
            }


            if (dataReader["CommentNum"].ToString() != "")
            {
                model.CommentNum = int.Parse(dataReader["CommentNum"].ToString());
            }
            if (dataReader["FavorableNum"].ToString() != "")
            {
                model.FavorableNum = int.Parse(dataReader["FavorableNum"].ToString());
            }
            if (dataReader["UserID"].ToString() != "")
            {
                model.UserID = int.Parse(dataReader["UserID"].ToString());
            }
            model.UserName = dataReader["UserName"].ToString();
            model.UserNiName = dataReader["UserNiName"].ToString();

            if (dataReader["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(dataReader["AddTime"].ToString());
            }



            if (dataReader["IsUserTheme"].ToString() != "")
            {

                model.IsUserTheme = Core.Utils.ConvertBool(dataReader["IsUserTheme"].ToString());
            }
            if (dataReader["IsAuditing"].ToString() != "")
            {
                model.IsAuditing = Core.Utils.ConvertBool(dataReader["IsAuditing"].ToString());
            }
            

            
            if (dataReader["SiteID"].ToString() != "")
            {
                model.SiteID = int.Parse(dataReader["SiteID"].ToString());
            }
            if (dataReader["RandNum"].ToString() != "")
            {
                model.RandNum = int.Parse(dataReader["RandNum"].ToString());
            }
            if (dataReader["NumberTime"].ToString() != "")
            {
                model.NumberTime = int.Parse(dataReader["NumberTime"].ToString());
            }
            if (dataReader["SubClassNum"].ToString() != "")
            {
                model.SubClassNum = int.Parse(dataReader["SubClassNum"].ToString());
            }
            model.ParentIDs = dataReader["ParentIDs"].ToString();
            if (dataReader["IsHtmlNameReWrite"].ToString() != "")
            {
                model.IsHtmlNameReWrite = Core.Utils.ConvertBool(dataReader["IsHtmlNameReWrite"].ToString());
            }
            if (dataReader["ContentHtmlPath"].ToString() != "")
            {
                model.ContentHtmlPath = dataReader["ContentHtmlPath"].ToString();
            }
            if (dataReader["IsHtmlNameReWriteContent"].ToString() != "")
            {
                model.IsHtmlNameReWriteContent = Core.Utils.ConvertBool(dataReader["IsHtmlNameReWriteContent"].ToString());
            }
            return model;
        }

        #endregion


        #region 分类上移下移操作


        /// <summary>
        /// 获取最大排序ID,主要用于添加分类是让排序编号递增
        /// </summary>
        /// <returns></returns>
        public int NewsClass_GetMaxOrderID(int iParentClassID, int SiteID)
        {
            string sSql = string.Concat("select Max(OrderID)  from  ", sPre, "NewsClass where SiteID=", SiteID, " and Parentid=", iParentClassID);
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

        #endregion






        public List<int> NewsClass_GetSubID(int iParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID ");
            strSql.AppendFormat(" from  {0}newsclass Where ParentID={1}", sPre, iParentID);
            List<int> iList = new List<int>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    int iID = int.Parse(dataReader[0].ToString());

                    iList.Add(iID);

                }
            }
            return iList;
        }


        public List<EbSite.Entity.NewsClass> GetClassInIDs(string IDs, int SiteID)
        {
            return NewsClass_GetListArray(string.Concat(" ID in(", IDs, ")"), 0, string.Format(" instr(',{0},',','&id&',')", IDs), SiteID);
            // return NewsClass_GetListArray(string.Concat(" ID in(", IDs, ")"), 0, string.Format("charindex(','+rtrim(cast(id as   varchar(10)))+',',',{0},')", IDs),SiteID);
        }


        public List<EbSite.Entity.NewsClass> GetParents(int cid, string OrderBy)
        {
            if (string.IsNullOrEmpty(OrderBy))
                OrderBy = "id desc";
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_ID", MySqlDbType.Int32, 4), new MySqlParameter("?p_Orderby", MySqlDbType.VarChar, 50) };
            parameters[0].Value = cid;
            parameters[1].Value = OrderBy;
            List<EbSite.Entity.NewsClass> list = new List<NewsClass>();


            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}ProcFoo", sPre), parameters))
            {
                while (dataReader.Read())
                {
                    EbSite.Entity.NewsClass md = new NewsClass();
                    md.ID = dataReader.GetInt32(0);
                    md.ClassName = dataReader.GetString(1);
                    md.ParentID = dataReader.GetInt32(2);
                    //md.IsCanAddContent = dataReader.GetBoolean(3);
                    list.Add(md);

                }
            }
            return list;


        }




        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用） 可以自定义查询字段
        /// </summary>
        public List<EbSite.Entity.NewsClass> NewsClass_GetListArray(string sField, string strWhere, int iTop, string OrderBy, int SiteID)
        {
            string sFieldNewClass = "";
            string sTop = "";

            if (iTop > 0) sTop = string.Concat(" limit ", iTop);
            if (!string.IsNullOrEmpty(OrderBy)) OrderBy = string.Concat(" order by ", OrderBy);
            StringBuilder strSql = new StringBuilder();

            if (!string.IsNullOrEmpty(sField))
            {
                sFieldNewClass = sField;
            }
            else
            {

                sFieldNewClass = " *";
            }

            strSql.AppendFormat("select {2} from  {0}newsclass where SiteID={1} ", sPre, SiteID, sFieldNewClass);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and  " + strWhere);
            }
            strSql.Append(OrderBy);
            strSql.Append(" " + sTop);
            List<EbSite.Entity.NewsClass> list = new List<EbSite.Entity.NewsClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                if (!string.IsNullOrEmpty(sField))
                {
                    list = Core.ReaderModel.ReaderToList<NewsClass>(dataReader);
                }
                else
                {
                    while (dataReader.Read())
                    {
                        list.Add(NewsClass_ReaderBind(dataReader));
                    }
                }

            }
            return list;
        }
        /// <summary>
        ///  得到一个对象实体
        /// </summary>
        /// <param name="sFieldPayment">要查询的字段</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public EbSite.Entity.NewsClass NewsClass_GetModel(string sField, string strWhere)
        {
            string sFieldNewClass = "";

            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(sField))
            {
                sFieldNewClass = sField;
            }
            else
            {

                sFieldNewClass = " * ";
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = "where " + strWhere;
            }

            strSql.AppendFormat("select  {1}  from  {0}newsclass {2} ", sPre, sFieldNewClass, strWhere);
            List<EbSite.Entity.NewsClass> list = new List<EbSite.Entity.NewsClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                if (!string.IsNullOrEmpty(sField))
                {
                    list = Core.ReaderModel.ReaderToList<NewsClass>(dataReader);
                }
                else
                {
                    while (dataReader.Read())
                    {
                        list.Add(NewsClass_ReaderBind(dataReader));
                    }
                }
            }
            if (list.Count > 0)
                return list[0];
            return null;
        }



        /// <summary>
        /// 获取某个分类下的所有子分类
        /// </summary>
        /// <param name="ParentID">分类id</param>
        /// <param name="SiteID">站点id</param>
        /// <param name="SubIDs">获取某个分类下的所有子分类ID,用逗号分开</param>
        /// <returns></returns>
        public List<EbSite.Entity.NewsClass> NewsClassGetSubIDs(int ParentID, int SiteID, out string SubIDs)
        {

            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_ParentID", MySqlDbType.Int32, 4), new MySqlParameter("?p_SiteID", MySqlDbType.Int32, 4) };
            parameters[0].Value = ParentID;
            parameters[1].Value = SiteID;
            List<EbSite.Entity.NewsClass> list = new List<NewsClass>();

            string isubids = "0";
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}ProcGetSubIDs", sPre), parameters))
            {
                while (dataReader.Read())
                {
                    EbSite.Entity.NewsClass md = new NewsClass();
                    md.ID = dataReader.GetInt32(0);
                    md.ClassName = dataReader.GetString(1);
                    md.ParentID = dataReader.GetInt32(2);
                    //md.IsCanAddContent = dataReader.GetBoolean(3);
                    isubids = string.Concat(isubids, ",", md.ID);
                    list.Add(md);

                }
            }
            SubIDs = isubids;
            return list;


        }


        /// <summary>
        /// 通过模型ID来查找 分页获取数据列表 
        /// </summary>
        public List<EbSite.Entity.NewsClass> NewsClass_ModelIDGetListPages(int PageIndex, int PageSize, string strWhere, string OrderBy, int SiteID, out int RecordCount, Guid ClassModelId)
        {
            string sOrderBy = string.Empty;
            if (PageIndex > 0)
            {
                PageIndex--;
            }
            if (!string.IsNullOrEmpty(OrderBy))
            {
                sOrderBy = string.Concat(" ORDER BY ", OrderBy);
            }
            else
            {
                
                    sOrderBy = "ORDER BY  orderid desc";
            }

            int numStart = PageIndex * PageSize;

            if (!string.IsNullOrEmpty(strWhere))
                strWhere = string.Concat(" AND ", strWhere);

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT a.* FROM {0}newsclass a 
LEFT JOIN (SELECT * FROM {0}classsetconfig) b on a.id=b.ClassId
LEFT JOIN (SELECT * FROM {0}classconfigs) c on b.ConfigId=c.id
WHERE a.SiteId={6} AND  c.ClassModelID = '{1}' {5}  {2} LIMIT {3},{4} ", sPre, ClassModelId, sOrderBy, numStart, PageSize, strWhere, SiteID);

            

            //Entity.ClassConfigs mConfigs = null;
            //mConfigs = EbSite.BLL.ClassConfigs.Instance.GetClassConfigs(EbSite.Base.Host.Instance.GetSiteID);
            //StringBuilder strSql = new StringBuilder();
            //StringBuilder strSqlCount = new StringBuilder();
            //strSql.AppendFormat("SELECT * from (select  IfNULL(b.ClassModelID,'{0}') as classmodelid , a.* from {1}NewsClass a LEFT JOIN {1}classconfigs b on a.id=b.ClassID where a.SiteID={2} and a.ParentID=0) as a ", mConfigs.ClassModelID, sPre, SiteID);
            //strSqlCount.AppendFormat("SELECT count(*) from (select  IfNULL(b.ClassModelID,'{0}') as classmodelid , a.* from {1}NewsClass a LEFT JOIN {1}classconfigs b on a.id=b.ClassID where a.SiteID={2} and a.ParentID=0) as a ", mConfigs.ClassModelID, sPre, SiteID);

            //if (!string.IsNullOrEmpty(sWhere))
            //{
            //    strSql.AppendFormat("where {0}  ", sWhere);
            //    strSqlCount.AppendFormat(" where {0}  ", sWhere);
            //}


            //int iCount = -1;
            //using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSqlCount.ToString()))
            //{
            //    while (dataReader.Read())
            //    {
            //        iCount = int.Parse(dataReader[0].ToString());
            //    }
            //}
            //RecordCount = iCount;
            //if (PageIndex > 0)
            //{
            //    PageIndex--;
            //}
            //int numStart = PageIndex * PageSize;

            //strSql.AppendFormat(" limit {0} ,{1}", numStart, PageSize);

            List<EbSite.Entity.NewsClass> list = new List<EbSite.Entity.NewsClass>();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(NewsClass_ReaderBind(dataReader));
                }
            }

            string sqlCount = string.Format(@"SELECT count(*) FROM {0}newsclass a 
LEFT JOIN (SELECT * FROM {0}classsetconfig) b on a.id=b.ClassId
LEFT JOIN (SELECT * FROM {0}classconfigs) c on b.ConfigId=c.id
WHERE  a.SiteId={2} AND c.ClassModelID = '{1}'", sPre, ClassModelId,SiteID);

            int iCount = 0;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sqlCount))
            {
                while (dataReader.Read())
                {
                    iCount = int.Parse(dataReader[0].ToString());
                }
            }
            RecordCount = iCount;

            return list;



        }
        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用） 可以自定义查询字段
        /// </summary>
        public List<EbSite.Entity.NewsClass> NewsClass_ModelIDGetListArray(string sField, string strWhere, int iTop, string OrderBy, int SiteID, Guid ClassModelId)
        {
            string sFieldNewClass = "";
            string sTop = "";

            if (iTop > 0) sTop = string.Concat(" limit ", iTop);
            if (!string.IsNullOrEmpty(OrderBy)) OrderBy = string.Concat(" order by ", OrderBy);
            StringBuilder strSql = new StringBuilder();



            //strSql.AppendFormat("SELECT * from (select  IfNULL(b.ClassModelID,'{0}') as classmodelid , a.* from {1}NewsClass a LEFT JOIN {1}classconfigs b on a.id=b.ClassID where a.SiteID={2} and a.parentid=0) as a ", ClassModelId, sPre, SiteID);
            //strSql.AppendFormat(" where  classmodelid='{0}'", ClassModelId);

            strSql.AppendFormat(@"SELECT * FROM {0}newsclass a 
LEFT JOIN (SELECT * FROM {0}classsetconfig) b on a.id=b.ClassId
LEFT JOIN (SELECT * FROM {0}classconfigs) c on b.ConfigId=c.id
WHERE a.SiteId={2} AND c.ClassModelID = '{1}'", sPre, ClassModelId,SiteID);

            if (strWhere.Trim() != "")
            {
                strSql.Append(" and  " + strWhere);
            }
            strSql.Append(OrderBy);
            strSql.Append(sTop);
            
            //EbSite.Log.Factory.GetInstance().InfoLog(string.Format("查询语句：{0}", strSql));

            List<EbSite.Entity.NewsClass> list = new List<EbSite.Entity.NewsClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                if (!string.IsNullOrEmpty(sField))
                {
                    list = Core.ReaderModel.ReaderToList<NewsClass>(dataReader);
                }
                else
                {
                    while (dataReader.Read())
                    {
                        list.Add(NewsClass_ReaderBind(dataReader));
                    }
                }

            }
            return list;
        }
        /// <summary>
        ///YHL 2014-8-29 查出 当前分类下的所有子类。
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public List<int> GetChildIDClass(int ParentID,int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT id from {0}newsclass where siteid={2} and  INSTR(CONCAT( ',',ParentIDs), ',{1},' ) > 0", sPre, ParentID,SiteID);
            List<int> iList = new List<int>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    int iID = int.Parse(dataReader[0].ToString());
                    iList.Add(iID);
                }
            }
            return iList;
        }
        public List<Entity.NewsClass> GetChildClass(int ParentID,int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT * from {0}newsclass where siteid={2} and  INSTR(CONCAT( ',',ParentIDs), ',{1},' ) > 0", sPre, ParentID,SiteID);
            List<Entity.NewsClass> iList = new List<Entity.NewsClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    iList.Add(NewsClass_ReaderBind(dataReader));
                }
            }
            return iList;
        }
        #endregion 读

        #region 写

        public int NewsClass_Add(EbSite.Entity.NewsClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}newsclass(", sPre);

            //parameters[6].Value = model.ContentHtmlName;
            //parameters[7].Value = model.ClassHtmlNameRule;
            //parameters[17].Value = model.IsCanAddContent;
            //parameters[18].Value = model.ContentModelID;
            //parameters[19].Value = model.ContentTemID;
            //parameters[20].Value = model.ClassTemID;
            //parameters[21].Value = model.ClassModelID;
            //parameters[37].Value = model.SubClassAddName;
            //parameters[38].Value = model.SubClassTemID;
            //parameters[39].Value = model.SubClassModelID;
            //parameters[40].Value = model.SubDefaultContentModelID;
            //parameters[41].Value = model.SubDefaultContentTemID;
            //parameters[42].Value = model.SubIsCanAddSub;
            //parameters[43].Value = model.SubIsCanAddContent;
            //parameters[44].Value = model.IsCanAddSub;
            //parameters[45].Value = model.ListTemID;
            //parameters[52].Value = model.PageSize;
            //parameters[53].Value = model.ModuleID;

            strSql.Append("ClassName,OrderID,ParentID,HtmlName,Info,TitleStyle,SeoTitle,dayHits,weekHits,monthhits,lasthitstime,hits,SeoKeyWord,SeoDescription,OutLike,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex9,Annex10,Annex11,Annex12,Annex13,Annex14,Annex15,Annex16,Annex17,CommentNum,FavorableNum,UserID,UserName,UserNiName,AddTime,IsUserTheme,IsAuditing,SiteID,RandNum,NumberTime,SubClassNum,ParentIDs,IsHtmlNameReWrite,ContentHtmlPath,IsHtmlNameReWriteContent)");
            strSql.Append(" values (");
            strSql.Append("?ClassName,?OrderID,?ParentID,?HtmlName,?Info,?TitleStyle,?SeoTitle,?dayHits,?weekHits,?monthhits,?lasthitstime,?hits,?SeoKeyWord,?SeoDescription,?OutLike,?Annex1,?Annex2,?Annex3,?Annex4,?Annex5,?Annex6,?Annex7,?Annex8,?Annex9,?Annex10,?Annex11,?Annex12,?Annex13,?Annex14,?Annex15,?Annex16,?Annex17,?CommentNum,?FavorableNum,?UserID,?UserName,?UserNiName,?AddTime,?IsUserTheme,?IsAuditing,?SiteID,?RandNum,?NumberTime,?SubClassNum,?ParentIDs,?IsHtmlNameReWrite,?ContentHtmlPath,?IsHtmlNameReWriteContent)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),
					new MySqlParameter("?HtmlName", MySqlDbType.VarChar,300),
					new MySqlParameter("?Info", MySqlDbType.Text),
					new MySqlParameter("?TitleStyle", MySqlDbType.VarChar,200), 
					new MySqlParameter("?SeoTitle", MySqlDbType.VarChar,300),
					new MySqlParameter("?dayHits",  MySqlDbType.Int32,4),
					new MySqlParameter("?weekHits",  MySqlDbType.Int32,4),
					new MySqlParameter("?monthhits",  MySqlDbType.Int32,4),
					new MySqlParameter("?lasthitstime", MySqlDbType.DateTime),
					new MySqlParameter("?hits",  MySqlDbType.Int32,4),
					new MySqlParameter("?SeoKeyWord", MySqlDbType.VarChar,500),
					new MySqlParameter("?SeoDescription", MySqlDbType.VarChar,500),
					new MySqlParameter("?OutLike", MySqlDbType.VarChar,300), 
					new MySqlParameter("?Annex1", MySqlDbType.VarChar,100),
					new MySqlParameter("?Annex2", MySqlDbType.VarChar,200),
					new MySqlParameter("?Annex3", MySqlDbType.VarChar,300),
					new MySqlParameter("?Annex4", MySqlDbType.VarChar,400),
					new MySqlParameter("?Annex5", MySqlDbType.VarChar,500),
					new MySqlParameter("?Annex6", MySqlDbType.VarChar,600),
					new MySqlParameter("?Annex7", MySqlDbType.VarChar,700),
					new MySqlParameter("?Annex8", MySqlDbType.VarChar,800),
                    new MySqlParameter("?Annex9", MySqlDbType.VarChar,900),
                    new MySqlParameter("?Annex10", MySqlDbType.VarChar,1000),

                     new MySqlParameter("?Annex11", MySqlDbType.Int32,10),
                      new MySqlParameter("?Annex12", MySqlDbType.Int32,10),
                       new MySqlParameter("?Annex13", MySqlDbType.Int32,10),
                        new MySqlParameter("?Annex14", MySqlDbType.Int32,10),
                         new MySqlParameter("?Annex15", MySqlDbType.Float),
                         new MySqlParameter("?Annex16", MySqlDbType.Int32,10),
                          new MySqlParameter("?Annex17", MySqlDbType.Int32,10),
                           
					new MySqlParameter("?CommentNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?FavorableNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?AddTime", MySqlDbType.DateTime), 
                    new MySqlParameter("?IsUserTheme", MySqlDbType.Int16,1),
					new MySqlParameter("?IsAuditing", MySqlDbType.Int16,1),
                    new MySqlParameter("?SiteID", MySqlDbType.Int32,4),
                    new MySqlParameter("?RandNum",MySqlDbType.Int32,4),
                    new MySqlParameter("?NumberTime",MySqlDbType.Int32,4),
                    new MySqlParameter("?SubClassNum",MySqlDbType.Int32,4),
                    new MySqlParameter("?ParentIDs",MySqlDbType.VarChar,100),
                    new MySqlParameter("?IsHtmlNameReWrite",MySqlDbType.Int16,1),

                    new MySqlParameter("?ContentHtmlPath",MySqlDbType.VarChar,100),
                    new MySqlParameter("?IsHtmlNameReWriteContent",MySqlDbType.Int16,1)

                    
                                        };
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.HtmlName;
            parameters[4].Value = model.Info;
            parameters[5].Value = model.TitleStyle;

            parameters[6].Value = model.SeoTitle;
            parameters[7].Value = model.dayHits;
            parameters[8].Value = model.weekHits;
            parameters[9].Value = model.monthhits;
            parameters[10].Value = model.lasthitstime;
            parameters[11].Value = model.hits;
            parameters[12].Value = model.SeoKeyWord;
            parameters[13].Value = model.SeoDescription;
            parameters[14].Value = model.OutLike;

            parameters[15].Value = model.Annex1;
            parameters[16].Value = model.Annex2;
            parameters[17].Value = model.Annex3;
            parameters[18].Value = model.Annex4;
            parameters[19].Value = model.Annex5;
            parameters[20].Value = model.Annex6;
            parameters[21].Value = model.Annex7;
            parameters[22].Value = model.Annex8;
            parameters[23].Value = model.Annex9;
            parameters[24].Value = model.Annex10;

            parameters[25].Value = model.Annex11;
            parameters[26].Value = model.Annex12;
            parameters[27].Value = model.Annex13;
            parameters[28].Value = model.Annex14;
            parameters[29].Value = model.Annex15;

            parameters[30].Value = model.Annex16;
            parameters[31].Value = model.Annex17;

            parameters[32].Value = model.CommentNum;
            parameters[33].Value = model.FavorableNum;
            parameters[34].Value = model.UserID;
            parameters[35].Value = model.UserName;
            parameters[36].Value = model.UserNiName;
            parameters[37].Value = model.AddTime;


            parameters[38].Value = model.IsUserTheme;
            parameters[39].Value = model.IsAuditing;
            parameters[40].Value = model.SiteID;

            parameters[41].Value = model.RandNum;
            parameters[42].Value = model.NumberTime;
            parameters[43].Value = model.SubClassNum;
            parameters[44].Value = model.ParentIDs;
            parameters[45].Value = model.IsHtmlNameReWrite;

            parameters[46].Value = model.ContentHtmlPath;
            parameters[47].Value = model.IsHtmlNameReWriteContent;

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
        public void NewsClass_Update(EbSite.Entity.NewsClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}newsclass set ", sPre);
            strSql.Append("ClassName=?ClassName,");
            strSql.Append("OrderID=?OrderID,");
            strSql.Append("ParentID=?ParentID,");
            strSql.Append("HtmlName=?HtmlName,");
            strSql.Append("Info=?Info,");
            strSql.Append("TitleStyle=?TitleStyle,");
            strSql.Append("SeoTitle=?SeoTitle,");
            strSql.Append("dayHits=?dayHits,");
            strSql.Append("weekHits=?weekHits,");
            strSql.Append("monthhits=?monthhits,");
            strSql.Append("lasthitstime=?lasthitstime,");
            strSql.Append("hits=?hits,");
            strSql.Append("SeoKeyWord=?SeoKeyWord,");
            strSql.Append("SeoDescription=?SeoDescription,");
            strSql.Append("OutLike=?OutLike,");
            strSql.Append("Annex1=?Annex1,");
            strSql.Append("Annex2=?Annex2,");
            strSql.Append("Annex3=?Annex3,");
            strSql.Append("Annex4=?Annex4,");
            strSql.Append("Annex5=?Annex5,");
            strSql.Append("Annex6=?Annex6,");
            strSql.Append("Annex7=?Annex7,");
            strSql.Append("Annex8=?Annex8,");
            strSql.Append("Annex9=?Annex9,");
            strSql.Append("Annex10=?Annex10,");

            strSql.Append("Annex11=?Annex11,");
            strSql.Append("Annex12=?Annex12,");
            strSql.Append("Annex13=?Annex13,");
            strSql.Append("Annex14=?Annex14,");
            strSql.Append("Annex15=?Annex15,");
            strSql.Append("Annex16=?Annex16,");
            strSql.Append("Annex17=?Annex17,");



            strSql.Append("CommentNum=?CommentNum,");
            strSql.Append("FavorableNum=?FavorableNum,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("UserNiName=?UserNiName,");
            strSql.Append("AddTime=?AddTime,");

            strSql.Append("IsUserTheme=?IsUserTheme,");
            strSql.Append("IsAuditing=?IsAuditing,");
            strSql.Append("SiteID=?SiteID,");
            strSql.Append("RandNum=?RandNum,");
            strSql.Append("NumberTime=?NumberTime,");
            strSql.Append("SubClassNum=?SubClassNum,");
            strSql.Append("ParentIDs=?ParentIDs,");
            strSql.Append("IsHtmlNameReWrite=?IsHtmlNameReWrite,");

            strSql.Append("ContentHtmlPath=?ContentHtmlPath,");
            strSql.Append("IsHtmlNameReWriteContent=?IsHtmlNameReWriteContent");

            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),
					new MySqlParameter("?HtmlName", MySqlDbType.VarChar,300),
					new MySqlParameter("?Info", MySqlDbType.Text),
					new MySqlParameter("?TitleStyle", MySqlDbType.VarChar,200),
					new MySqlParameter("?SeoTitle", MySqlDbType.VarChar,300),
					new MySqlParameter("?dayHits",  MySqlDbType.Int32,4),
					new MySqlParameter("?weekHits",  MySqlDbType.Int32,4),
					new MySqlParameter("?monthhits",  MySqlDbType.Int32,4),
					new MySqlParameter("?lasthitstime", MySqlDbType.DateTime),
					new MySqlParameter("?hits",  MySqlDbType.Int32,4),
					new MySqlParameter("?SeoKeyWord", MySqlDbType.VarChar,500),
					new MySqlParameter("?SeoDescription", MySqlDbType.VarChar,500),
					new MySqlParameter("?OutLike", MySqlDbType.VarChar,300),
					new MySqlParameter("?Annex1", MySqlDbType.VarChar,100),
					new MySqlParameter("?Annex2", MySqlDbType.VarChar,200),
					new MySqlParameter("?Annex3", MySqlDbType.VarChar,300),
					new MySqlParameter("?Annex4", MySqlDbType.VarChar,400),
					new MySqlParameter("?Annex5", MySqlDbType.VarChar,500),
					new MySqlParameter("?Annex6", MySqlDbType.VarChar,600),
					new MySqlParameter("?Annex7", MySqlDbType.VarChar,700),
					new MySqlParameter("?Annex8", MySqlDbType.VarChar,800),
                    new MySqlParameter("?Annex9", MySqlDbType.VarChar,900),
                    new MySqlParameter("?Annex10", MySqlDbType.VarChar,1000),

                    new MySqlParameter("?Annex11", MySqlDbType.Int32,10),
                     new MySqlParameter("?Annex12", MySqlDbType.Int32,10),
                      new MySqlParameter("?Annex13", MySqlDbType.Int32,10),
                       new MySqlParameter("?Annex14", MySqlDbType.Int32,10),
                        new MySqlParameter("?Annex15", MySqlDbType.Float),
                           new MySqlParameter("?Annex16", MySqlDbType.Int32,10),
                              new MySqlParameter("?Annex17", MySqlDbType.Int32,10),


                       

					new MySqlParameter("?CommentNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?FavorableNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
                    new MySqlParameter("?IsUserTheme", MySqlDbType.Int16,1),
					new MySqlParameter("?IsAuditing", MySqlDbType.Int16,1),
                    new MySqlParameter("?SiteID", MySqlDbType.Int32,4),
                   
                    new MySqlParameter("?RandNum",MySqlDbType.Int32,4),
                    new MySqlParameter("?NumberTime",MySqlDbType.Int32,4),
                    new MySqlParameter("?SubClassNum",MySqlDbType.Int32,4),
                    new MySqlParameter("?ParentIDs",MySqlDbType.VarChar,100),
                    new MySqlParameter("?IsHtmlNameReWrite",MySqlDbType.Int16,1),

                    new MySqlParameter("?ContentHtmlPath",MySqlDbType.VarChar,100),
                    new MySqlParameter("?IsHtmlNameReWriteContent",MySqlDbType.Int16,1)
                                        
                                        };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.OrderID;
            parameters[3].Value = model.ParentID;
            parameters[4].Value = model.HtmlName;
            parameters[5].Value = model.Info;
            parameters[6].Value = model.TitleStyle;
            parameters[7].Value = model.SeoTitle;
            parameters[8].Value = model.dayHits;
            parameters[9].Value = model.weekHits;
            parameters[10].Value = model.monthhits;
            parameters[11].Value = model.lasthitstime;
            parameters[12].Value = model.hits;
            parameters[13].Value = model.SeoKeyWord;
            parameters[14].Value = model.SeoDescription;
            parameters[15].Value = model.OutLike;
            parameters[16].Value = model.Annex1;
            parameters[17].Value = model.Annex2;
            parameters[18].Value = model.Annex3;
            parameters[19].Value = model.Annex4;
            parameters[20].Value = model.Annex5;
            parameters[21].Value = model.Annex6;
            parameters[22].Value = model.Annex7;
            parameters[23].Value = model.Annex8;
            parameters[24].Value = model.Annex9;
            parameters[25].Value = model.Annex10;

            parameters[26].Value = model.Annex11;
            parameters[27].Value = model.Annex12;
            parameters[28].Value = model.Annex13;
            parameters[29].Value = model.Annex14;
            parameters[30].Value = model.Annex15;

            parameters[31].Value = model.Annex16;
            parameters[32].Value = model.Annex17;


            parameters[33].Value = model.CommentNum;
            parameters[34].Value = model.FavorableNum;
            parameters[35].Value = model.UserID;
            parameters[36].Value = model.UserName;
            parameters[37].Value = model.UserNiName;
            parameters[38].Value = model.AddTime;
            parameters[39].Value = model.IsUserTheme;
            parameters[40].Value = model.IsAuditing;
            parameters[41].Value = model.SiteID;

            parameters[42].Value = model.RandNum;
            parameters[43].Value = model.NumberTime;
            parameters[44].Value = model.SubClassNum;
            parameters[45].Value = model.ParentIDs;
            parameters[46].Value = model.IsHtmlNameReWrite;

            parameters[47].Value = model.ContentHtmlPath;
            parameters[48].Value = model.IsHtmlNameReWriteContent;
            

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs">ID列表，用逗号分开</param>
        public void NewsClass_Delete(string IDs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}newsclass ", sPre);
            strSql.Append(" where ID in(" + IDs + ")");
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());

            //同时删除与此分类相关的内容

            strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}newscontent ", sPre);
            strSql.Append(" where ClassID in(" + IDs + ")");
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());

            //删除与分类相关的分类配置
             strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}classsetconfig ", sPre);
            strSql.Append(" where ID in(" + IDs + ")");
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());


        }
        /// <summary>
        /// 删除分类时要更新比当前分类排序ID大的orderid - 1
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public void NewsClass_DeleteClassUpdateOrderID(int OrderID, int ParentID, int SiteID)
        {
            string sSql = string.Format("UPDATE {0}newsclass SET OrderID = OrderID-1 Where SiteID={3} and OrderID>{1} and ParentID={2} ", sPre, OrderID, ParentID, SiteID);
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sSql);


        }
        #region 数据统计处理

        /// <summary>
        /// 更新内容的评论条数
        /// </summary>
        /// <param name="iMusicID"></param>
        public void NewsClass_UpdateCommentNum(int iID, int iNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Concat("update ", sPre, "NewsClass set CommentNum=CommentNum+", iNum));
            strSql.Append(" where ID=");
            strSql.Append(iID);

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 更新内容的收藏用户人数
        /// </summary>
        /// <param name="iMusicID"></param>
        public void NewsClass_UpdateFavorableNum(int iID, int iNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Concat("update ", sPre, "NewsClass set FavorableNum=FavorableNum+", iNum));
            strSql.Append(" where ID=");
            strSql.Append(iID);

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 添加点击,指定更新点击数
        /// </summary>
        /// <param name="iMusicID"></param>
        public void NewsClass_AddHits(int iID, int iNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Concat("update ", sPre, "NewsClass set hits=hits+", iNum, ",dayHits=dayHits+", iNum, ",weekHits=weekHits+", iNum, ",monthhits=monthhits+", iNum));
            strSql.Append(" where ID=");
            strSql.Append(iID);

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 对点击数清零
        /// </summary>
        public void NewsClass_ResetHits(string Interval)
        {
            string sType = "";

            switch (Interval)
            {
                case "d":
                    sType = "dayHits";
                    break;
                case "w":
                    sType = "weekHits";
                    break;
                case "m":
                    sType = "monthhits";
                    break;
            }

            if (string.IsNullOrEmpty(Interval)) return;

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}newsclass set ", sPre);
            strSql.Append(sType + "=?" + sType);
            strSql.Append(" where " + sType + ">0");
            MySqlParameter[] parameters = {
					new MySqlParameter("?"+sType, MySqlDbType.Int32 )
                                        };
            parameters[0].Value = 0;
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

        }


        #endregion
        public void NewsClass_InitNum(int itype)
        {
            string sUpdateFileds = "";
            if (itype == 0)
            {
                sUpdateFileds = "hits=0,dayhits=0,weekhits=0,monthhits=0";
            }
            else if (itype == 1)
            {
                sUpdateFileds = "hits=0";
            }
            else if (itype == 2)
            {
                sUpdateFileds = "dayhits=0";
            }
            else if (itype == 3)
            {
                sUpdateFileds = "weekhits=0";
            }
            else if (itype == 4)
            {
                sUpdateFileds = "monthhits=0";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}newsclass set ", sPre);

            strSql.Append(sUpdateFileds);

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="SoureClassID"></param>
        /// <param name="TargetClassID"></param>
        /// <param name="IsAsChildnode"></param>
        public void NewsClass_Move(int SoureClassID, int TargetClassID, bool IsAsChildnode, int SiteID)
        {

            string sqlStr;

            //将与源分类同级的分类，并且orderid大于源分类orderid的分类，-1补位

            // sqlStr = string.Format("UPDATE {0}newsclass SET orderid=orderid-1 WHERE SiteID={2} and ParentID=(select parentid from  {0}newsclass where id={1}) and orderid>(select orderid from  {0}newsclass where id={1})", sPre, SoureClassID, SiteID);

            sqlStr = string.Format(" create table tmp1 as select parentid  as col1 from {0}newsclass where id={1};", sPre, SoureClassID);
            sqlStr += string.Format(" create table tmp2 as select orderid as col1 from  {0}newsclass where id={1};", sPre, SoureClassID);
            sqlStr += string.Format(" UPDATE {0}newsclass SET orderid=orderid-1 WHERE SiteID={1} and ParentID=(select col1 from tmp1) and orderid>(select col1 from tmp2);", sPre, SiteID);
            sqlStr += string.Format("drop table tmp1;  drop table tmp2;");
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);

            if (IsAsChildnode) //作为目标分类的子分类
            {

                //让目标分类下子分类的ID都加1，让位
                sqlStr = string.Format("UPDATE {0}newsclass SET orderid=orderid+1 WHERE SiteID={2} and ParentID={1}", sPre, TargetClassID, SiteID);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);


                //先移到目标分类下并将orderid置为1
                sqlStr = string.Format("UPDATE {0}newsclass SET parentid={1} ,orderid=1 WHERE SiteID={3} and id={2}", sPre, TargetClassID, SoureClassID, SiteID);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);



            }
            else  //调整到某个分类前面
            {


                //首先将与目标分类同级，并且orderid大于目标分类orderid 增加1,给源分类让位

                // sqlStr = string.Format("UPDATE {0}newsclass SET orderid=orderid+1  WHERE SiteID={2}and parentid=(select Parentid from  {0}newsclass where id={1}) and orderid>=(select orderid from  {0}newsclass where id={1}) ", sPre, TargetClassID,SiteID);
                sqlStr = string.Format(" create table tmp1 as select parentid  as col1 from {0}newsclass where id={1};", sPre, TargetClassID);
                sqlStr += string.Format(" create table tmp2 as select orderid as col1 from  {0}newsclass where id={1};", sPre, TargetClassID);
                sqlStr += string.Format(" UPDATE {0}newsclass SET orderid=orderid+1 WHERE SiteID={1} and ParentID=(select col1 from tmp1) and orderid>=(select col1 from tmp2);", sPre, SiteID);
                sqlStr += string.Format("drop table tmp1;  drop table tmp2;");
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);




                //将源分类更新到与目标分类同一父级下的分类,并将其orderid置为当前目标分类的orderid ，由于上面已经将目标分类加1，所以这里要减去1

                //  sqlStr = string.Format("UPDATE {0}newsclass SET SiteID={3} , parentid=(select Parentid from  {0}newsclass where id={1}),orderid=(select orderid from  {0}newsclass where id={1})-1  WHERE id={2}", sPre, TargetClassID, SoureClassID,SiteID);
                sqlStr = string.Format(" create table tmp1 as select parentid  as col1 from {0}newsclass where id={1};", sPre, TargetClassID);
                sqlStr += string.Format(" create table tmp2 as select orderid as col1 from  {0}newsclass where id={1};", sPre, TargetClassID);
                sqlStr += string.Format(" UPDATE {0}newsclass SET SiteID={2}, parentid=(select col1 from tmp1 ) ,orderid=(select col1 from tmp2)-1 WHERE id={1};", sPre, SoureClassID, SiteID);
                sqlStr += string.Format("drop table tmp1;  drop table tmp2;");
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);


            }
        }

        public void NewsClass_UpdateOrderID(int iClassID, int iValue, int SiteID)
        {
            string strSql = string.Format("update {0}newsclass set OrderID={1} Where SiteID={3} and ID={2}", sPre, iValue, iClassID, SiteID);

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql);
        }
        public void NewsClass_Update(string Where, string Col, string sValue)
        {
            if (!string.IsNullOrEmpty(Where))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("update {0}newsclass set {1}={2} where {3}", sPre, Col, sValue, Where);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }

        }
        public void SetSubSiteToMainUpdateSiteID(int MainSiteID, int SubSiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}newsclass set siteid=-1  where siteid={1};update {0}newsclass set siteid={1}  where siteid={2};update {0}newsclass set siteid={2}  where siteid=-1;", sPre, MainSiteID, SubSiteID);
            strSql.AppendFormat("update {0}newscontent set siteid=-1  where siteid={1};update {0}newscontent set siteid={1}  where siteid={2};update {0}newscontent set siteid={2}  where siteid=-1;", sPre, MainSiteID, SubSiteID);
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        public void DeleteNewsClassOutSiteData(string siteids)
        {
            if (!string.IsNullOrEmpty(siteids))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("delete from {0}newsclass ", sPre);

                strSql.Append(" where siteid not in(" + siteids + ")");
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }
        }

        public List<EbSite.Entity.NewsClass> NewsClass_GetListArrayFormConfigId(int iConfigId)
        {
           
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"SELECT a.* FROM {0}newsclass a 
LEFT JOIN (SELECT * FROM {0}classsetconfig) b on a.id=b.ClassId
WHERE b.ConfigId = {1}", sPre, iConfigId); 
             
            List<EbSite.Entity.NewsClass> list = new List<EbSite.Entity.NewsClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(NewsClass_ReaderBind(dataReader));
                }
            }
            return list;
        }

        public List<EbSite.Entity.NewsClass> NewsClass_GetNotConfig(string sWhere)
        {
            string where = string.Empty;
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"SELECT * FROM {0}newsclass 
WHERE id not in(SELECT ClassId FROM {0}classsetconfig)", sPre);

            if (!string.IsNullOrEmpty(sWhere))
                where = string.Concat(" AND ", sWhere);
            strSql.Append(where);

            List<EbSite.Entity.NewsClass> list = new List<EbSite.Entity.NewsClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(NewsClass_ReaderBind(dataReader));
                }
            }
            return list;
        }
        #endregion 写

    }
}

