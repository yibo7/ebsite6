using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.BLL;
using EbSite.Entity;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;
using System.Data.Common;//请先添加引用
namespace EbSite.Data.MySql
{
    /// <summary>
    /// 数据访问类NewsContent。
    /// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        private string sqlFileds = "ID,SmallPic,NewsTitle,TitleStyle,ClassID,hits,IsGood,ContentInfo,dayHits,weekHits,monthhits,lasthitstime,TagIDs,OrderID,HtmlName,ContentHtmlNameRule,MarkIsMakeHtml,IsComment,AddTime,IsAuditing,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex9,Annex10,Annex11,Annex12,Annex13,Annex14,Annex15,Annex16,Annex17,Annex18,Annex19,Annex20,Annex21,Annex22,Annex23,Annex24,Annex25,Advs,ClassName,CommentNum,FavorableNum,UserID,UserNiName,UserName,SiteID,RandNum,NumberTime,Keywords,Description";

        #region 读

        /// <summary>
        /// 随机同一分下，相关问题 。
        /// </summary>
        /// <param name="bid"></param>
        /// <param name="top"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Entity.NewsContent> NewsContent_Related(bool IsHaveImg, int top, int ClassId, int siteid,long NoInId, string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT * FROM {0}{1} AS t1 
JOIN(SELECT ROUND(RAND() * ((SELECT MAX(id) FROM {0}{1}) - (SELECT MIN(id) FROM {0}{1})) + (SELECT MIN(id) FROM {0}{1})) AS id) AS t2
WHERE t1.id >= t2.id and SiteID={2} ", sPre, TableName, siteid);

            if (IsHaveImg)
            {
                strSql.Append(" and SmallPic <> ''");
            }

            if (ClassId > 0)
            {
                strSql.AppendFormat(" and ClassId ={0}", ClassId);
            }

            if (NoInId > 0)
            {
                strSql.AppendFormat(" and t1.ID<>{0}", NoInId);
            }

            strSql.AppendFormat(" ORDER BY t1.id LIMIT {0}", top);

            //strSql.AppendFormat(" from {0}goods_visite a,{0}{2} b where  a.ContentID=b.ID and a.UserID={1} ORDER BY a.Count DESC", sPre, UserID, TableName);

            List<EbSite.Entity.NewsContent> list = new List<EbSite.Entity.NewsContent>();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(NewsContent_ReaderBind(dataReader, TableName, siteid));
                }
            }
            return list;

            //MySqlParameter[] parameters ={ 
            //    new MySqlParameter("?p_bid", MySqlDbType.Int32,4),
            //    new MySqlParameter("?p_top", MySqlDbType.Int32,4),
            //    new MySqlParameter("?p_count",MySqlDbType.Int32,4),
            //    new MySqlParameter("?p_siteid",MySqlDbType.Int32,4),
            //    new MySqlParameter("?p_tablename",MySqlDbType.VarChar,20) 
            //                             };
            //parameters[0].Value = bid;
            //parameters[1].Value = top;
            //parameters[2].Value = count;
            //parameters[3].Value = siteid;
            //parameters[4].Value = sPre + TableName;
            //using (DataSet ds = DbHelperCms.Instance.ExecuteDataset(CommandType.StoredProcedure, string.Concat(sPre, "GetRelatedList"), parameters))
            //{
            //    return ds;
            //}
        }



        public List<Entity.NewsContent> GetVisiteByUserID(int UserID, string TableName, int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  b.ID,b.SmallPic,b.NewsTitle,b.TitleStyle,b.ClassID,b.hits,b.IsGood,b.ContentInfo,b.dayHits,b.weekHits,b.monthhits,b.lasthitstime,b.TagIDs," +
                          "b.OrderID,b.HtmlName,b.ContentHtmlNameRule,b.MarkIsMakeHtml,b.IsComment,b.AddTime,b.IsAuditing,b.Annex1,b.Annex2,b.Annex3,b.Annex4,b.Annex5,b.Annex6,b.Annex7,b.Annex8,b.Annex9," +
                          "b.Annex10,b.Annex11,b.Annex12,b.Annex13,b.Annex14,b.Annex15,b.Annex16,b.Annex17,b.Annex18,b.Annex19,b.Annex20,b.Annex21,b.Annex22,b.Annex23,b.Annex24,b.Annex25," + //b.ContentTemID,
                          "b.Advs,b.ClassName,b.CommentNum,b.FavorableNum,b.UserID,b.UserNiName,b.UserName,b.SiteID,b.RandNum,b.NumberTime");

            strSql.AppendFormat(" from {0}goods_visite a,{0}{2} b where  a.ContentID=b.ID and a.UserID={1} ORDER BY a.Count DESC", sPre, UserID, TableName);

            List<EbSite.Entity.NewsContent> list = new List<EbSite.Entity.NewsContent>();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(NewsContent_ReaderBind(dataReader, TableName, SiteID));
                }
            }
            return list;
        }


        /// <summary>
        /// 是否存在 表 存在 返回 true
        /// </summary>
        public bool NewTb_Exists(string sTbName)
        {
            StringBuilder strSql = new StringBuilder();
            // strSql.AppendFormat("select count(*) from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='{0}' and TABLE_NAME='{1}' ","ebsite",sTbName);
            strSql.AppendFormat(" SHOW TABLES LIKE '{0}';", sPre + sTbName);
            List<string> list = new List<string>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(dataReader[0].ToString());
                }
            }
            if (list.Count > 0)
                return true;
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取总记录条数
        /// </summary>
        /// <returns></returns>
        //public int NewsContentUn_GetCount(string strWhere, int SiteID, string TableName)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(*) ");
        //    strSql.AppendFormat(" from  {0}{2} where SiteID={1} ", sPre, SiteID, TableName);

        //    if (strWhere.Trim() != "")
        //    {

        //        strSql.Append(" and " + strWhere);
        //    }

        //    int iCount = -1;
        //    using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
        //    {
        //        while (dataReader.Read())
        //        {
        //            iCount = int.Parse(dataReader[0].ToString());
        //        }
        //    }
        //    return iCount;
        //}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<EbSite.Entity.NewsContent> NewsContentUn_GetListPages(int PageIndex, int PageSize, string strWhere,
                                                                           string Fileds, bool IsAuditing,
                                                                           bool IsGood, out int Count, int SiteID,
                                                                           string TableNames, string OrderBy)
        {

            if (!string.IsNullOrEmpty(TableNames))
            {
                string[] arry = TableNames.Split(',');
                if (arry.Length > 1)
                {
                    StringBuilder strSql = new StringBuilder();
                    StringBuilder strSqlChildCount = new StringBuilder();
                    StringBuilder strSqlCount = new StringBuilder();
                    if (string.IsNullOrEmpty(Fileds))
                        Fileds = sqlFileds;

                    int Cursor = PageIndex * PageSize;
                    int limitBegin = 0;
                    int limitEnd = 1000;
                    int tempCount = 0;//临时总数合计
                    #region 检测limit 长度

                    for (int i = 1; i < 1000000; i++)//从1 开始 
                    {
                       
                        strSqlChildCount.AppendFormat("SELECT count(*) from (");
                        foreach (var st in arry)
                        {
                            strSqlChildCount.AppendFormat(
                                " SELECT * from ( SELECT {3} from {1}{2} where  SiteID={0} ORDER BY id desc LIMIT  {4},{5}) {2} UNION all",
                                SiteID, sPre, st, Fileds, limitBegin, limitEnd);
                        }
                        strSqlChildCount = strSqlChildCount.Remove(strSqlChildCount.Length - 9, 9);
                        strSqlChildCount.AppendFormat(") as aa  ");
                        if (string.IsNullOrEmpty(strWhere))
                        {
                            if (IsGood)
                                strWhere = " IsGood=1";
                        }
                        else
                        {
                            if (IsGood)
                                strWhere = string.Concat(" IsGood=1  and ", strWhere);
                        }

                        if (string.IsNullOrEmpty(strWhere))
                        {
                            strSqlChildCount.AppendFormat(" where siteid ={0} and IsAuditing={1}   ", SiteID, IsAuditing);
                        }
                        else
                        {
                            strSqlChildCount.AppendFormat(" where siteid={0} and IsAuditing={2} and {1}  ", SiteID,
                                                          strWhere, IsAuditing);
                        }

                        int iChildCount = -1;
                        using (
                            IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text,
                                                                                        strSqlChildCount.ToString()))
                        {
                            while (dataReader.Read())
                            {
                                iChildCount = int.Parse(dataReader[0].ToString());
                            }
                        }
                      
                        if (iChildCount == 0)//不太好理解 2014-7-12
                        {
                         
                            limitBegin = (i-2) * 1000;
                            break;

                        }
                        else
                        {
                            tempCount += iChildCount;
                            if (tempCount < Cursor)
                            {
                               

                                limitBegin = i*1000;
                                strSqlChildCount.Clear();
                            }
                            else
                            {
                                int ipageindex = (tempCount - iChildCount)/PageSize;
                                if (PageIndex > ipageindex)
                                    PageIndex -= ipageindex; //减去节取的分页码
                                break;
                            }
                        }
                    }

                    #endregion

                    //                    SELECT sum( (SELECT count(id) from EB_newscontent where SiteID=1) +
                    //(SELECT count(id) from eb_newscontent1 where SiteID=1) +
                    //(SELECT count(id) from eb_newscontent2 where SiteID=1 )) as icount
                    if (string.IsNullOrEmpty(strWhere))
                    {
                        if (IsGood)
                            strWhere = " IsGood=1";
                    }
                    else
                    {
                        if (IsGood)
                            strWhere = string.Concat(" IsGood=1  and ", strWhere);
                    }

                    strSql.AppendFormat("SELECT * from (");
                    strSqlCount.AppendFormat("SELECT sum(");
                    foreach (var st in arry)
                    {
                        strSql.AppendFormat(" SELECT * from ( SELECT {3} from {1}{2} where  SiteID={0} ORDER BY id desc LIMIT {4},{5}) {2} UNION all", SiteID, sPre, st, Fileds, limitBegin, limitEnd);
                        if (string.IsNullOrEmpty(strWhere))
                        {
                            strSqlCount.AppendFormat(" (SELECT count(id) from {1}{2}  where siteid={0} and IsAuditing={3}  ) +", SiteID, sPre, st, IsAuditing);
                        }
                        else
                        {
                            strSqlCount.AppendFormat(" (SELECT count(id) from {1}{2}  where siteid={0} and IsAuditing={4} and {3} ) +", SiteID, sPre, st, strWhere, IsAuditing);
                        }

                    }

                    strSql = strSql.Remove(strSql.Length - 9, 9);

                    strSqlCount = strSqlCount.Remove(strSqlCount.Length - 1, 1);

                    strSql.AppendFormat(") as aa  ");

                    strSqlCount.AppendFormat(") as icount  ");

                    if (string.IsNullOrEmpty(OrderBy))
                    {
                        OrderBy = "NumberTime desc";
                    }


                    if (string.IsNullOrEmpty(strWhere))
                    {
                        strSql.AppendFormat(" where siteid={0} and IsAuditing={2} ORDER BY {1}  ", SiteID, OrderBy, IsAuditing);
                        // strSqlCount.AppendFormat(" where siteid	={0} and IsAuditing={1}   ", SiteID, IsAuditing);
                    }
                    else
                    {
                        strSql.AppendFormat(" where siteid={0} and IsAuditing={3} and {1} ORDER BY {2}  ", SiteID, strWhere, OrderBy, IsAuditing);
                        //  strSqlCount.AppendFormat(" where siteid	={0} and IsAuditing={2} and {1}  ", SiteID, strWhere, IsAuditing);

                    }
                    //2014-5-30 yhl
                    string cachekey = string.Concat("GetListPagesUn", strWhere, SiteID);
                    string cachCount = EbSite.Base.Host.CacheRawApp.GetCacheItem<string>(cachekey, "dalNewsContentGetUn");// as string;
                    int iCount = -1;
                 
                    if (!string.IsNullOrEmpty(cachCount)&& int.Parse(cachCount) > 0)
                    {
                        Count = int.Parse(cachCount);
                    }
                    else
                    {
                        using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSqlCount.ToString()))
                        {
                            while (dataReader.Read())
                            {
                                iCount = int.Parse(dataReader[0].ToString());//缓存起来
                            }
                        }
                        Count = iCount;
                        EbSite.Base.Host.CacheRawApp.AddCacheItem(cachekey, Count, 10, ETimeSpanModel.FZ, "dalNewsContentGetUn");
                    }

                    if (PageIndex > 0)
                    {
                        PageIndex--;
                    }
                    int numStart = PageIndex * PageSize;

                    strSql.AppendFormat(" limit {0} ,{1}", numStart, PageSize);
                    List<EbSite.Entity.NewsContent> list = new List<EbSite.Entity.NewsContent>();

                    using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
                    {
                        while (dataReader.Read())
                        {
                            list.Add(NewsContent_ReaderBind(dataReader, string.Empty, SiteID));
                        }
                    }
                    return list;

                }
                else
                {
                    return NewsContent_GetListPages(PageIndex, PageSize, strWhere, Fileds, OrderBy, IsAuditing, IsGood, out  Count, SiteID, arry[0]);
                }

            }
            else
            {
                Count = 0;
                return null;
            }
        }




        public List<EbSite.Entity.NewsContent> NewsContentUn_GetListArray(string strWhere, int iTop, string oderby, string Fileds, int SiteID, string TableNames)
        {
            if (!string.IsNullOrEmpty(TableNames))
            {
                string[] arry = TableNames.Split(',');

                if (arry.Length > 1)
                {

                    if (iTop > 1000)
                        iTop = 1000;
                    StringBuilder strSql = new StringBuilder();

                    if (string.IsNullOrEmpty(Fileds))
                        Fileds = sqlFileds;

                    strSql.AppendFormat("SELECT * from (");

                    foreach (var TableName in arry)
                    {
                        strSql.AppendFormat(" SELECT * from (SELECT {3} from {1}{2} where SiteID={0} ORDER BY id desc limit {4}) as {2} UNION all", SiteID, sPre,
                                            TableName, Fileds, iTop);

                    }
                    strSql = strSql.Remove(strSql.Length - 9, 9);
                    strSql.AppendFormat(") as aa  ");

                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        strSql.AppendFormat(" where siteid	={0} and {2} ORDER BY {1}  ", SiteID, oderby, strWhere);
                    }
                    else
                    {
                        strSql.AppendFormat(" where siteid	={0}  ORDER BY {1}  ", SiteID, oderby);
                    }

                    if (iTop > 0)
                    {
                        strSql.Append(" limit " + iTop.ToString());
                    }
                    List<EbSite.Entity.NewsContent> list = new List<EbSite.Entity.NewsContent>();

                    using (
                        IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString())
                        )
                    {
                        while (dataReader.Read())
                        {
                            list.Add(NewsContent_ReaderBind(dataReader, string.Empty, SiteID));
                        }
                    }
                    return list;
                }
                else
                {
                    return NewsContent_GetListArray(strWhere, iTop, oderby, Fileds, SiteID, TableNames);
                }
            }
            else
            {
                return null;
            }

        }



        /// <summary>
        /// 在增加列前进行判断该列是否存在 true 存在
        /// </summary>
        /// <param name="sTbName">表名</param>
        /// <param name="ColumnName">字段名</param>
        /// <returns></returns>
        private bool NewColumnName_Exists(string sTbName, string ColumnName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select column_name from information_schema.columns where table_name = '{0}' and column_name = '{1}' ;", sPre + sTbName, ColumnName);
            List<string> list = new List<string>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(dataReader[0].ToString());
                }
            }
            if (list.Count > 0)
                return true;
            else
            {
                return false;
            }
        }

        
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public long NewsContent_GetMaxId(string TableName)
        {
            return DbHelperCms.Instance.GetMaxLongID("ID", TableName);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool NewsContent_Exists(string sWhere, string TableName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}{1}", sPre, TableName);
            strSql.Append(" where  " + sWhere);

            return DbHelperCms.Instance.Exists(strSql.ToString());
        }


        public List<EbSite.Entity.NewsContent> NewsContent_GetTagRelate(int top, long ContentId, string ContentFields, int SiteID, string TableName)
        {
            string ssql = string.Format("select tagid from {0}tagrelatenews where NewsID={1} ", sPre, ContentId);

            StringBuilder sbIDs = new StringBuilder();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, ssql))
            {
                while (dataReader.Read())
                {
                    sbIDs.Append(dataReader["tagid"].ToString());
                    sbIDs.Append(",");
                }
            }
            if (sbIDs.Length > 1)
            {
                sbIDs.Remove(sbIDs.Length - 1, 1);
            }
            else
            {
                return null;
            }
            ssql = string.Format("select distinct  newsid from {1}tagrelatenews where TagID in({2}) and newsid<>{3} limit {0}", top, sPre, sbIDs, ContentId);

            sbIDs.Length = 0;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, ssql))
            {
                while (dataReader.Read())
                {
                    sbIDs.Append(dataReader["newsid"].ToString());
                    sbIDs.Append(",");
                }
            }
            if (sbIDs.Length > 1)
            {
                sbIDs.Remove(sbIDs.Length - 1, 1);
            }
            else
            {
                return null;
            }

            return NewsContent_GetListArray(string.Format("id in({0})", sbIDs), -1, "hits", ContentFields, SiteID, TableName);


        }

        public EbSite.Entity.NewsContent NewsContent_GetModel(long ID, string TableName, int ClassId, int SiteID)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select * ");
            strSql.AppendFormat(" from  {0}{1} ", sPre, TableName);
            strSql.Append(" where ID=?ID  and  SiteID=?SiteID and ClassId=?ClassId limit 1 ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID",  MySqlDbType.Int64,4),
                    new MySqlParameter("?SiteID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?ClassId",  MySqlDbType.Int32,4)
                    
            };

            parameters[0].Value = ID;
            parameters[1].Value = SiteID;
            parameters[2].Value = ClassId;

            Entity.NewsContent model =null;


            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = NewsContent_ReaderBind(dataReader, TableName, SiteID);
                }
            }
            return model;
        }

        

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EbSite.Entity.NewsContent NewsContent_GetModel(long ID, string TableName, int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            
            strSql.Append("select * ");
            strSql.AppendFormat(" from  {0}{1} ", sPre, TableName);
            strSql.Append(" where ID=?ID limit 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int64,4)};
            parameters[0].Value = ID;

            Entity.NewsContent model = new Entity.NewsContent();


            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = NewsContent_ReaderBind(dataReader, TableName, SiteID);
                }
            }
            return model;

        }

        /// <summary>
        /// 获取最后一条记录
        /// </summary>
        public EbSite.Entity.NewsContent NewsContent_GetLastModel(string TableName, int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.AppendFormat("select  ID,SmallPic,NewsTitle,TitleStyle,ClassID,hits,IsGood,ContentInfo,dayHits,weekHits,monthhits,lasthitstime,TagIDs,OrderID,HtmlName,ContentHtmlNameRule,MarkIsMakeHtml,IsComment,AddTime,IsAuditing,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex9,Annex10,Annex11,Annex12,Annex13,Annex14,Annex15,Annex16,Annex17,Annex18,Annex19,Annex20,Annex21,Annex22,Annex23,Annex24,Annex25,ContentTemID,Advs,ClassName,CommentNum,FavorableNum,UserID,UserNiName,UserName,SiteID,RandNum,NumberTime from  {0}NewsContent ", sPre);

            strSql.AppendFormat("select * from  {0}{1} ", sPre, TableName);
            strSql.Append(" order by ID desc limit 1");

            Entity.NewsContent model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                if (dataReader.Read())
                {
                    model = NewsContent_ReaderBind(dataReader, TableName, SiteID);
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EbSite.Entity.NewsContent> NewsContent_GetGoodList(int itop, string classids, int SiteID, string TableName)
        {


            string sWhere = "IsGood=1";

            if (!string.IsNullOrEmpty(classids)) sWhere = string.Concat(sWhere, " and classid in(", classids, ")");

            return NewsContent_GetListArray(sWhere, itop, "-orderid", "", SiteID, TableName);

        }

        public List<EbSite.Entity.NewsContent> NewsContent_GetListArray(string strWhere, int iTop, string oderby,
            string Fields, int SiteID, string TableName)
        {
            return NewsContent_GetListArray(strWhere, iTop, oderby, Fields, SiteID, TableName,true);
        }

        public List<EbSite.Entity.NewsContent> NewsContent_GetListArray(string strWhere, int iTop, string oderby, string Fields, int SiteID, string TableName, bool? IsAuditing)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");


            if (!string.IsNullOrEmpty(Fields))
            {
                strSql.AppendFormat(" {0} ", Fields);
            }
            else
            {
                strSql.Append(" * ");
            }


            strSql.AppendFormat(" from  {0}{1} where SiteID", sPre, TableName);
            if (SiteID > 0)
            {
                strSql.AppendFormat("={0}", SiteID);
            }
            else //所有数据
            {
                strSql.Append(">0");
            }
            if (!Equals(IsAuditing, null))
            {
                if ((bool) IsAuditing)
                {
                    strSql.Append(" and IsAuditing=1 ");
                }
                else
                {
                    strSql.Append(" and IsAuditing=0 ");
                }
            }
               
            

            if (strWhere.Trim() != "")
            {
                strSql.AppendFormat(" and  {0}", strWhere);
            }
            if (!string.IsNullOrEmpty(oderby))
            {
                strSql.Append("  order by  ");
                strSql.Append(oderby);

            }
            else
            {
                strSql.Append("  order by  OrderID,id ");

            }
            if (iTop > 0)
            {
                strSql.Append(" limit " + iTop.ToString());
            }
            List<EbSite.Entity.NewsContent> list = new List<EbSite.Entity.NewsContent>();
            //Log.Factory.GetInstance().InfoLog("3333333333333333");
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(NewsContent_ReaderBind(dataReader, TableName, SiteID));
                }
            }
            return list;
        }

        public DataSet NewsContent_GetListDataSet(string strWhere, int iTop, string oderby, int SiteID, string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");

            strSql.Append(" * ");
            strSql.AppendFormat(" from  {0}{2} where SiteID={1} ", sPre, SiteID, TableName);

            if (strWhere.Trim() != "")
            {
                strSql.AppendFormat(" and  {0}", strWhere);
            }
            if (!string.IsNullOrEmpty(oderby.Trim()))
            {
                strSql.Append("  order by  ");
                strSql.Append(oderby);

            }
            else
            {
                strSql.Append("  order by  OrderID,id ");

            }
            if (iTop > 0)
            {
                strSql.Append(" limit " + iTop.ToString());
            }
            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }



        public List<EbSite.Entity.NewsContent> NewsContent_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool? IsAuditing, bool IsGood, out int Count, int SiteID, string TableName)
        {
            return NewsContent_GetListPages(PageIndex, PageSize, strWhere, "", oderby, IsAuditing, IsGood, out Count, SiteID, TableName);
        }

        public List<EbSite.Entity.NewsContent> NewsContent_GetListPages(int PageIndex, int PageSize, string strWhere,
            string Fileds, string oderby, bool? IsAuditing, bool IsGood, out int Count, int SiteID, string TableName)
        {
            return NewsContent_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, IsAuditing, IsGood, out Count,
                SiteID, TableName, 0);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<EbSite.Entity.NewsContent> NewsContent_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, bool? IsAuditing, bool IsGood, out int Count, int SiteID, string TableName,int AddSpecialId)
        {

            string sIsAuditing = string.Empty;// (IsAuditing) ? "1" : "0";
            

            if (!Equals(IsAuditing, null))
            {
                sIsAuditing = ((bool)IsAuditing) ? "IsAuditing=1 and " : "IsAuditing=0 and ";
            }

            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = string.Concat(sIsAuditing, "SiteID=", SiteID);
            }
            else
            {
                strWhere = string.Concat(sIsAuditing, "SiteID=", SiteID, " and ", strWhere);
            }

            if (string.IsNullOrEmpty(strWhere))
            {
                if (IsGood)
                    strWhere = "IsGood=1";
            }
            else
            {
                if (IsGood)
                    strWhere = string.Concat(" IsGood=1  and ", strWhere);
            }

            if (AddSpecialId > 0)
            {
                strWhere =string.Format("{0} AND id not in(SELECT NewsID FROM {1}specialnews WHERE SpecialClassID = {2})", strWhere, sPre, AddSpecialId) ;
            }

            //yhl 2013-04-22

            string cachekey = string.Concat("GetListPagesFromSpecialID", strWhere, SiteID);
            string iCount = EbSite.Base.Host.CacheRawApp.GetCacheItem<string>(cachekey, "dalNewsContentGetListPages");// as string;

            if (string.IsNullOrEmpty(iCount))
            {

                Count = NewsContent_GetCount(strWhere, SiteID, TableName);
                EbSite.Base.Host.CacheRawApp.AddCacheItem(cachekey, Count, 10, ETimeSpanModel.FZ, "dalNewsContentGetListPages");
            }
            else
            {
                Count = int.Parse(iCount);
            }

            string sOrderBy = "id desc";
            if(!string.IsNullOrEmpty(oderby))
                sOrderBy = oderby;

            //  Count = NewsContent_GetCount(strWhere, SiteID);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, TableName, PageSize, PageIndex, Fileds, "id", sOrderBy, strWhere, sPre);
            List<EbSite.Entity.NewsContent> list = new List<EbSite.Entity.NewsContent>();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(NewsContent_ReaderBind(dataReader, TableName, SiteID));
                }
            }
            return list;

        }
        /// <summary>
        /// 获取总记录条数
        /// </summary>
        /// <returns></returns>
        public int NewsContent_GetCount(string strWhere, int SiteID, string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.AppendFormat(" from  {0}{2} where SiteID={1} ", sPre, SiteID, TableName);

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
        public string GetContentsFromSpecialIDSqlWhere(int SpecialClassID, string TableName)
        {


            if (SpecialClassID > 0)
            {
                return string.Concat("ID in (select NewsID from ", sPre, "specialnews where  SpecialClassID=", SpecialClassID, ")");
            }
            else
            {
                return string.Concat("ID in (select NewsID from ", sPre, "specialnews ");
            }

        }

        /// <summary>
        /// 已经改好 2014-2-12 YHL 获取某个专题的数据-分页
        /// </summary>
        public List<EbSite.Entity.NewsContent> NewsContent_GetListPagesFromSpecialID(int PageIndex, int PageSize, int SpecialClassID, out int Count, int SiteID)
        {
            List<Entity.SpecialNews> list = new List<Entity.SpecialNews>();
            string sWhere = string.Concat("SpecialClassID=", SpecialClassID);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "specialnews", PageSize, PageIndex, "", "id", "id desc", sWhere, sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(SpecialNews_ReaderBind(dataReader));
                }
            }
            Count = SpecialNews_GetCount(sWhere);
            return GetSpecialNewsList(list, SiteID);

        }
        /// <summary>
        /// 已经改好 2014-2-12  获取某个专题的数据-分页
        /// </summary>
        /// <param name="SpecialClassID"></param>
        /// <returns></returns>
        public List<EbSite.Entity.NewsContent> NewsContent_GetListFromSpecialID(int SpecialClassID, int top, bool IsGetSub, int SiteID)
        {
            if (SpecialClassID > 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat(" select * from  {0}specialnews where SpecialClassID={1}", sPre, SpecialClassID);
                if (top > 0)
                {
                    strSql.Append(" limit " + top.ToString());
                }
                if (IsGetSub)
                {
                    strSql.Clear();
                    string sIDs = BLL.SpecialClass.GetSubIDs(SpecialClassID, SiteID);
                    if (!string.IsNullOrEmpty(sIDs))
                    {
                        sIDs = string.Concat(sIDs, ",", SpecialClassID);
                        strSql.AppendFormat("select * from  {0}specialnews where SpecialClassID in ({1})", sPre, sIDs);
                        if (top > 0)
                        {
                            strSql.Append(" limit " + top.ToString());
                        }
                    }
                }

                List<EbSite.Entity.SpecialNews> list = new List<EbSite.Entity.SpecialNews>();
                using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
                {
                    while (dataReader.Read())
                    {
                        list.Add(SpecialNews_ReaderBind(dataReader));
                    }
                }
                return GetSpecialNewsList(list, SiteID);
            }
            return null;

        }
        //已经改好 2014-2-12 YHL
        public List<EbSite.Entity.NewsContent> NewsContent_GetListPagesFromTagID(int PageIndex, int PageSize, int TagID, out int Count, int SiteID)
        {
            List<Entity.TagRelateNews> list = new List<Entity.TagRelateNews>();
            string sWhere = string.Concat("TagID=", TagID);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "tagrelatenews", PageSize, PageIndex, "", "id", "", sWhere, sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(TagRelateNews_ReaderBind(dataReader));

                }
            }
            Count = TagRelateNews_GetCount(sWhere);
            return GetTagNewsList(list, SiteID);


        }
        public int NewsContent_GetCountByTagID(int tid, int SiteID, string TableName)
        {
            //  int tableid = EbSite.Base.AppStartInit.TableIDByName(TableName);
            string sWhere = string.Concat("ID in (select NewsID from ", sPre, "tagrelatenews where TagID=", tid, ")");

            return NewsContent_GetCount(sWhere, 1, SiteID, TableName);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere">条件,支持输入d(天),w(本周),m{本月},q(本季),y(本年)</param>
        /// <param name="IsAuditing">-1获取全部，0获取未审核，1获取已经通过审核的</param>
        /// <returns></returns>
        public int NewsContent_GetCount(string strWhere, int IsAuditing, int SiteID, string TableName)
        {
            string sIsAuditing = string.Empty;

            if (IsAuditing == 1)
            {
                sIsAuditing = "IsAuditing=1";
            }
            else if (IsAuditing == 0)
            {
                sIsAuditing = "IsAuditing=0";
            }

            if (strWhere.Equals("d"))
            {
                strWhere = "datediff(AddTime,NOW())=0";
            }
            else if (strWhere.Equals("w"))
            {
                strWhere = "datediff(AddTime,NOW())<8";
            }
            else if (strWhere.Equals("m"))
            {
                strWhere = "datediff(AddTime,NOW())<31";
            }
            else if (strWhere.Equals("q"))
            {
                strWhere = "datediff(AddTime,NOW())<91";
            }
            else if (strWhere.Equals("y"))
            {
                strWhere = "datediff(AddTime,NOW())<366";
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.AppendFormat(" from  {0}{1}  ", sPre, TableName);

            if (strWhere.Trim() != "")
            {
                if (!string.IsNullOrEmpty(sIsAuditing)) sIsAuditing = string.Concat(" and ", sIsAuditing);
                strSql.AppendFormat(" where SiteID={2} and {0}  {1}", strWhere, sIsAuditing, SiteID);
            }
            else
            {
                if (!string.IsNullOrEmpty(sIsAuditing))
                {
                    strSql.AppendFormat(" where SiteID={1} and {0} ", sIsAuditing, SiteID);
                }
                else
                {
                    strSql.AppendFormat(" where SiteID={0} ", SiteID);
                }

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
        /// 对象实体绑定数据
        /// </summary>
        public EbSite.Entity.NewsContent NewsContent_ReaderBind(IDataReader dataReader, string TableName, int SiteID)
        {
            EbSite.Entity.NewsContent model = new EbSite.Entity.NewsContent();
            List<ColumFiledConfigs> lstCFC = null;
            if (!string.IsNullOrEmpty(TableName)&& SiteID>0)
            {
                ModelClass mc = AppStartInit.GetModelClassByTableName(TableName, SiteID);
                if (!object.Equals(mc, null))
                { 
                    lstCFC = mc.GetCustomFileds();
                }
                    
            }

            StringDictionary sd = new StringDictionary();

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                string sCName = dataReader.GetName(i).ToLower();

                #region 自带字段
                sCName = sCName.ToLower();
                if (Equals(sCName, "id"))
                {
                    if (dataReader["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dataReader["ID"].ToString());
                    }
                }
                else if (Equals(sCName, "classname"))
                {
                    model.ClassName = dataReader["ClassName"].ToString();
                }

                else if (Equals(sCName, "smallpic"))
                {
                    model.SmallPic = dataReader["SmallPic"].ToString();
                }
                else if (Equals(sCName, "newstitle"))
                {
                    model.NewsTitle = dataReader["NewsTitle"].ToString();
                }
                else if (Equals(sCName, "tagids"))
                {
                    model.TagIDs = dataReader["TagIDs"].ToString();
                }
                else if (Equals(sCName, "titlestyle"))
                {
                    model.TitleStyle = dataReader["TitleStyle"].ToString();
                }

                else if (Equals(sCName, "classid") && dataReader["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(dataReader["ClassID"].ToString());
                }
                else if (Equals(sCName, "hits") && dataReader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(dataReader["hits"].ToString());
                }
                else if (Equals(sCName, "isgood") && dataReader["IsGood"].ToString() != "")
                {
                    if ((dataReader["IsGood"].ToString() == "1") || (dataReader["IsGood"].ToString().ToLower() == "true"))
                    {
                        model.IsGood = true;
                    }
                    else
                    {
                        model.IsGood = false;
                    }
                }
                else if (Equals(sCName, "contentinfo"))
                {
                    model.ContentInfo = dataReader["ContentInfo"].ToString();
                }

                else if (Equals(sCName, "dayhits") && dataReader["dayHits"].ToString() != "")
                {
                    model.dayHits = int.Parse(dataReader["dayHits"].ToString());
                }
                else if (Equals(sCName, "weekhits") && dataReader["weekHits"].ToString() != "")
                {
                    model.weekHits = int.Parse(dataReader["weekHits"].ToString());
                }
                else if (Equals(sCName, "monthhits") && dataReader["monthhits"].ToString() != "")
                {
                    model.monthhits = int.Parse(dataReader["monthhits"].ToString());
                }
                else if (Equals(sCName, "lasthitstime") && dataReader["lasthitstime"].ToString() != "")
                {
                    model.lasthitstime = DateTime.Parse(dataReader["lasthitstime"].ToString());
                }
                else if (Equals(sCName, "lasthitstime"))
                {
                    model.lasthitstime = DateTime.Parse(dataReader["lasthitstime"].ToString());
                }

                else if (Equals(sCName, "orderid") && dataReader["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(dataReader["OrderID"].ToString());
                }
                else if (Equals(sCName, "htmlname"))
                {
                    model.HtmlName = dataReader["HtmlName"].ToString();
                }
                else if (Equals(sCName, "contenthtmlnamerule"))
                {
                    model.ContentHtmlNameRule = dataReader["ContentHtmlNameRule"].ToString();
                }

                else if (Equals(sCName, "markismakehtml") && dataReader["MarkIsMakeHtml"].ToString() != "")
                {
                    if ((dataReader["MarkIsMakeHtml"].ToString() == "1") || (dataReader["MarkIsMakeHtml"].ToString().ToLower() == "true"))
                    {
                        model.MarkIsMakeHtml = true;
                    }
                    else
                    {
                        model.MarkIsMakeHtml = false;
                    }
                }
                else if (Equals(sCName, "iscomment") && dataReader["IsComment"].ToString() != "")
                {
                    if ((dataReader["IsComment"].ToString() == "1") || (dataReader["IsComment"].ToString().ToLower() == "true"))
                    {
                        model.IsComment = true;
                    }
                    else
                    {
                        model.IsComment = false;
                    }
                }
                else if (Equals(sCName, "addtime") && dataReader["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(dataReader["AddTime"].ToString());
                }
                else if (Equals(sCName, "isauditing") && dataReader["IsAuditing"].ToString() != "")
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
                else if (Equals(sCName, "annex1"))
                {
                    model.Annex1 = dataReader["Annex1"].ToString();
                }
                else if (Equals(sCName, "annex2"))
                {
                    model.Annex2 = dataReader["Annex2"].ToString();
                }
                else if (Equals(sCName, "annex3"))
                {
                    model.Annex3 = dataReader["Annex3"].ToString();
                }
                else if (Equals(sCName, "annex4"))
                {
                    model.Annex4 = dataReader["Annex4"].ToString();
                }
                else if (Equals(sCName, "annex5"))
                {
                    model.Annex5 = dataReader["Annex5"].ToString();
                }
                else if (Equals(sCName, "annex6"))
                {
                    model.Annex6 = dataReader["Annex6"].ToString();
                }
                else if (Equals(sCName, "annex7"))
                {
                    model.Annex7 = dataReader["Annex7"].ToString();
                }
                else if (Equals(sCName, "annex8"))
                {
                    model.Annex8 = dataReader["Annex8"].ToString();
                }
                else if (Equals(sCName, "annex9"))
                {
                    model.Annex9 = dataReader["Annex9"].ToString();
                }
                else if (Equals(sCName, "annex10"))
                {
                    model.Annex10 = dataReader["Annex10"].ToString();
                }


                else if (Equals(sCName, "annex11"))
                {
                    model.Annex11 = Core.Utils.StrToInt(dataReader["Annex11"].ToString(), 0);
                }
                else if (Equals(sCName, "annex12"))
                {
                    model.Annex12 = Core.Utils.StrToInt(dataReader["Annex12"].ToString(), 0);
                }
                else if (Equals(sCName, "annex13"))
                {
                    model.Annex13 = Core.Utils.StrToInt(dataReader["Annex13"].ToString(), 0);
                }
                else if (Equals(sCName, "annex14"))
                {
                    model.Annex14 = Core.Utils.StrToInt(dataReader["Annex14"].ToString(), 0);
                }
                else if (Equals(sCName, "annex15"))
                {
                    model.Annex15 = Core.Utils.StrToInt(dataReader["Annex15"].ToString(), 0);
                }
                else if (Equals(sCName, "annex16"))
                {
                    if (!string.IsNullOrEmpty(dataReader["Annex16"].ToString()))
                        model.Annex16 = decimal.Parse(dataReader["Annex16"].ToString());
                }
                else if (Equals(sCName, "annex17"))
                {
                    if (!string.IsNullOrEmpty(dataReader["Annex17"].ToString()))
                        model.Annex17 = decimal.Parse(dataReader["Annex17"].ToString());
                }
                else if (Equals(sCName, "annex18"))
                {
                    if (!string.IsNullOrEmpty(dataReader["Annex18"].ToString()))
                        model.Annex18 = decimal.Parse(dataReader["Annex18"].ToString());
                }


                else if (Equals(sCName, "annex19"))
                {
                    if (!string.IsNullOrEmpty(dataReader["Annex19"].ToString()))
                        model.Annex19 = float.Parse(dataReader["Annex19"].ToString());
                }
                else if (Equals(sCName, "annex20"))
                {
                    if (!string.IsNullOrEmpty(dataReader["Annex20"].ToString()))
                        model.Annex20 = float.Parse(dataReader["Annex20"].ToString());
                }

                else if (Equals(sCName, "annex21"))
                {
                    model.Annex21 = Core.Utils.StrToLong(dataReader["Annex21"].ToString(), 0);
                }
                else if (Equals(sCName, "annex22"))
                {
                    model.Annex22 = Core.Utils.StrToLong(dataReader["Annex22"].ToString(), 0);
                }
                else if (Equals(sCName, "annex23"))
                {
                    model.Annex23 = Core.Utils.StrToLong(dataReader["Annex23"].ToString(), 0);
                }
                else if (Equals(sCName, "annex24"))
                {
                    model.Annex24 = Core.Utils.StrToLong(dataReader["Annex24"].ToString(), 0);
                }
                else if (Equals(sCName, "annex25"))
                {
                    model.Annex25 = Core.Utils.StrToLong(dataReader["Annex25"].ToString(), 0);
                }

                else if (Equals(sCName, "advs") && dataReader["Advs"].ToString() != "")
                {
                    model.Advs = int.Parse(dataReader["Advs"].ToString());
                }
                else if (Equals(sCName, "classname"))
                {
                    model.ClassName = dataReader["ClassName"].ToString();
                }

                else if (Equals(sCName, "commentnum") && dataReader["CommentNum"].ToString() != "")
                {
                    model.CommentNum = int.Parse(dataReader["CommentNum"].ToString());
                }
                else if (Equals(sCName, "favorablenum") && dataReader["FavorableNum"].ToString() != "")
                {
                    model.FavorableNum = int.Parse(dataReader["FavorableNum"].ToString());
                }
                else if (Equals(sCName, "userid") && dataReader["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(dataReader["UserID"].ToString());
                }
                else if (Equals(sCName, "userniname"))
                {
                    model.UserNiName = dataReader["UserNiName"].ToString();
                }
                else if (Equals(sCName, "username"))
                {
                    model.UserName = dataReader["UserName"].ToString();
                }
                else if (Equals(sCName, "siteid") && dataReader["SiteID"].ToString() != "")
                {
                    model.SiteID = int.Parse(dataReader["SiteID"].ToString());
                }
                else if (Equals(sCName, "randnum") && dataReader["RandNum"].ToString() != "")
                {
                    model.RandNum = int.Parse(dataReader["RandNum"].ToString());
                }

                else if (Equals(sCName, "numbertime") && dataReader["NumberTime"].ToString() != "")
                {
                    model.NumberTime = int.Parse(dataReader["NumberTime"].ToString());
                }

                else if (Equals(sCName, "keywords")) //keywords 必须小写
                {
                    
                    model.Keywords = dataReader["Keywords"].ToString();
                }
                else if (Equals(sCName, "description"))
                { 
                    model.Description = dataReader["Description"].ToString();
                }
                else if (Equals(sCName, "lastupdatetime") && dataReader["LastUpdateTime"].ToString() != "")
                { 
                    model.LastUpdateTime = DateTime.Parse(dataReader["LastUpdateTime"].ToString());
                }
                #endregion

                else
                {
                    if (!Equals(lstCFC, null) && lstCFC.Count > 0)
                    {
                        foreach (ColumFiledConfigs cf in lstCFC)
                        {
                            //Log.Factory.GetInstance().InfoLog(sCName+"==="+ cf.ColumFiledName);
                            if (Equals(sCName, cf.ColumFiledName))
                            {

                                string v = dataReader[cf.ColumFiledName].ToString();
                                if (!string.IsNullOrEmpty(v))
                                {
                                    sd.Add(cf.ColumFiledName, v);
                                }
                            }

                        }
                    }

                }

            }

            model.Fileds = sd;

            return model;
        }

        public List<EbSite.Entity.NewsContent> GetListGood(int iTop, int iClassid, bool IsGetSub, bool IsImg, string Fields, int SiteID, string TableName)
        {
            string sWhere = " IsGood=1 and SiteID=" + SiteID;

            if (iClassid > 0)
            {
                if (!IsGetSub)
                {
                    sWhere = string.Concat(sWhere, " and ClassID =", iClassid);
                }
                else
                {
                    //很占用内存，有等优化
                    string SubIds = EbSite.BLL.NewsClass.GetSubIDs(iClassid, SiteID);
                    if (!string.IsNullOrEmpty(SubIds)) SubIds = string.Concat(",", SubIds);

                    sWhere = string.Concat(sWhere, " and ClassID in(", iClassid, SubIds, ")");
                }
            }
            if (IsImg) sWhere = string.Concat(sWhere, " and  smallpic<>'' ");

            return NewsContent_GetListArray(sWhere, iTop, "orderid desc", Fields, SiteID, TableName);

        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EbSite.Entity.NewsContent NewsContent_GetModel(string sField, string strWhere, string TableName, int SiteID)
        {
            string sFieldNewContent = "";

            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(sField))
            {
                sFieldNewContent = sField;
            }
            else
            {
                //sFieldNewContent = "ID,SmallPic,NewsTitle,TitleStyle,ClassID,hits,IsGood,ContentInfo,dayHits,weekHits,monthhits,lasthitstime,TagIDs,OrderID,HtmlName,ContentHtmlNameRule,MarkIsMakeHtml,IsComment,AddTime,IsAuditing,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex9,Annex10,Annex11,Annex12,Annex13,Annex14,Annex15,Annex16,Annex17,Annex18,Annex19,Annex20,Annex21,Annex22,Annex23,Annex24,Annex25,ContentTemID,Advs,ClassName,CommentNum,FavorableNum,UserID,UserNiName,UserName,SiteID,RandNum,NumberTime";

                sFieldNewContent = "*";
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = string.Concat("where ", strWhere);
            }

            strSql.AppendFormat("select  {1}  from  {0}{3} {2} ", sPre, sFieldNewContent, strWhere, TableName);
            List<EbSite.Entity.NewsContent> list = new List<EbSite.Entity.NewsContent>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                if (!string.IsNullOrEmpty(sField))
                {
                    list = Core.ReaderModel.ReaderToList<Entity.NewsContent>(dataReader);
                }
                else
                {
                    while (dataReader.Read())
                    {
                        list.Add(NewsContent_ReaderBind(dataReader, TableName, SiteID));
                    }
                }

            }
            if (list.Count > 0)
                return list[0];
            return null;
        }
        //public List<EbSite.Entity.NewsContent> NewsContentUn_GetListPagesFromSpecialID(int PageIndex, int PageSize,
        //                                                                  int SpecialClassID,
        //                                                                  out int Count, int SiteID, string TableNames)
        //{
        //    if (!string.IsNullOrEmpty(TableNames))
        //    {
        //        string[] arry = TableNames.Split(',');
        //        if (arry.Length > 1)
        //        {
        //            #region 多表处理

        //            StringBuilder strSql = new StringBuilder();
        //            StringBuilder strSqlCount = new StringBuilder();

        //            string Fileds = sqlFileds;

        //            strSql.AppendFormat("SELECT * from (");
        //            strSqlCount.AppendFormat("SELECT count(*) from (");
        //            foreach (var st in arry)
        //            {
        //                strSql.AppendFormat(" SELECT {3} from {1}{2} where SiteID={0} UNION all", SiteID, sPre, st, Fileds);
        //                strSqlCount.AppendFormat(" SELECT {3} from {1}{2} where SiteID={0} UNION all", SiteID, sPre, st, Fileds);
        //            }
        //            strSql = strSql.Remove(strSql.Length - 9, 9);
        //            strSqlCount = strSqlCount.Remove(strSqlCount.Length - 9, 9);
        //            strSql.AppendFormat(") as aa  ");
        //            strSqlCount.AppendFormat(") as aa  ");
        //            //if (string.IsNullOrEmpty(OrderBy))
        //            //{
        //            //    OrderBy = "addtime desc";
        //            //}
        //            //if (string.IsNullOrEmpty(strWhere))
        //            //{
        //            //    if (IsGood)
        //            //        strWhere = " IsGood=1";
        //            //}
        //            //else
        //            //{
        //            //    if (IsGood)
        //            //        strWhere = string.Concat(" IsGood=1  and ", strWhere);
        //            //}

        //            //if (string.IsNullOrEmpty(strWhere))
        //            //{
        //            //    strSql.AppendFormat(" where siteid	={0} and IsAuditing={2} ORDER BY {1}  ", SiteID, OrderBy, IsAuditing);
        //            //    strSqlCount.AppendFormat(" where siteid	={0} and IsAuditing={1}   ", SiteID, IsAuditing);
        //            //}
        //            //else
        //            //{
        //            //    strSql.AppendFormat(" where siteid	={0} and IsAuditing={3} and {1} ORDER BY {2}  ", SiteID, strWhere, OrderBy, IsAuditing);
        //            //    strSqlCount.AppendFormat(" where siteid	={0} and IsAuditing={2} and {1}  ", SiteID, strWhere, IsAuditing);

        //            //}
        //            int iCount = -1;
        //            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSqlCount.ToString()))
        //            {
        //                while (dataReader.Read())
        //                {
        //                    iCount = int.Parse(dataReader[0].ToString());
        //                }
        //            }
        //            Count = iCount;
        //            if (PageIndex > 0)
        //            {
        //                PageIndex--;
        //            }
        //            int numStart = PageIndex * PageSize;

        //            strSql.AppendFormat(" limit {0} ,{1}", numStart, PageSize);
        //            List<EbSite.Entity.NewsContent> list = new List<EbSite.Entity.NewsContent>();

        //            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
        //            {
        //                while (dataReader.Read())
        //                {
        //                    list.Add(NewsContent_ReaderBind(dataReader, string.Empty, SiteID));
        //                }
        //            }
        //            return list;
        //            #endregion
        //        }
        //        else
        //        {
        //            return NewsContent_GetListPagesFromSpecialID(PageIndex,PageSize,SpecialClassID, out Count, SiteID);
        //        }


        //    }
        //    else
        //    {
        //        Count = 0;
        //        return null;
        //    }
        //}

        //把标签对象 转成 NewsContent
        private List<Entity.NewsContent> GetTagNewsList(List<Entity.TagRelateNews> lsTagNews, int SiteID)
        {
            List<ContentTbName> lsTb = new List<ContentTbName>();
            //用最原始的 20条 记录 转成 Newsid+TbName
            foreach (var tag in lsTagNews)
            {
                ContentTbName md = new ContentTbName();
                md.Newsid = tag.NewsID.ToString();
                md.TbName = EbSite.Base.AppStartInit.GetTableNameByClassID(tag.ClassID);
                lsTb.Add(md);
            }

             

            return ChangeNewsContent(GetTableData(lsTb), SiteID);

        }

        //把专题 对象 转成 NewsContent
        private List<Entity.NewsContent> GetSpecialNewsList(List<Entity.SpecialNews> lsSpecialNews, int SiteID)
        {
            List<ContentTbName> lsTb = new List<ContentTbName>();
            //用最原始的 20条 记录 转成 Newsid+TbName
            foreach (var sp in lsSpecialNews)
            {
                ContentTbName md = new ContentTbName();
                md.Newsid = sp.NewsID.ToString();
                md.TbName = EbSite.Base.AppStartInit.GetTableNameByClassID(sp.ClassID);
                lsTb.Add(md);
            }
            return ChangeNewsContent(GetTableData(lsTb), SiteID);

        }
        //过滤 相同表 
        private List<ContentTbName> GetTableData(List<ContentTbName> lsTb)
        {
            //过滤 相同的表
            var TbNames = (from i in lsTb select i.TbName).Distinct();
            List<ContentTbName> lsTb2 = new List<ContentTbName>();
            //得到 最终的数据 表名-NewIds
            foreach (var tbName in TbNames)
            {
                string t = tbName.ToString();
                List<ContentTbName> Gdu = (from i in lsTb where i.TbName == t  select i  ).ToList();//from i in lsTb where i.TbName == t orderby i.Newsid  select i 
                ContentTbName md = new ContentTbName();
                string ids = "";
                foreach (var id in Gdu)
                {
                    ids += id.Newsid + ",";
                }
                if (ids.Length > 0)
                    ids = ids.Remove(ids.Length - 1, 1);
                md.TbName = t;
                md.Newsid = ids;
                lsTb2.Add(md);
            }
            return lsTb2;

        }
        //公用 标签，专题
        private List<Entity.NewsContent> ChangeNewsContent(List<ContentTbName> lsTb2, int SiteID)
        {
            List<EbSite.Entity.NewsContent> list = new List<EbSite.Entity.NewsContent>();
            if (lsTb2.Count > 0)
            {
                //重要代码 开始
                StringBuilder strSql = new StringBuilder();
                string Fileds = "";
                if (string.IsNullOrEmpty(Fileds))
                    Fileds = sqlFileds;
                if (lsTb2.Count > 1)
                {
                    strSql.AppendFormat("SELECT * from (");
                    foreach (var contentTbName in lsTb2)
                    {
                        strSql.AppendFormat(" SELECT {3} from {1}{2} where id in ({0}) UNION all", contentTbName.Newsid,
                                            sPre, contentTbName.TbName, Fileds);
                    }
                    strSql = strSql.Remove(strSql.Length - 9, 9);
                    strSql.AppendFormat(") as aa  ");

                }
                else//一个表
                {
                    strSql.AppendFormat(" SELECT {3} from {1}{2} where id in ({0}) ORDER BY id DESC ", lsTb2[0].Newsid,
                                         sPre, lsTb2[0].TbName, Fileds);

                }
                using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
                {
                    while (dataReader.Read())
                    {
                        list.Add(NewsContent_ReaderBind(dataReader, string.Empty, SiteID));
                    }
                }
            }
            return list;
        }

        public long NewsContent_GetMinId(string TableName)
        {
            string sql = string.Format("SELECT MIN(id) FROM {0}{1}", sPre, TableName);

            object obj = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, sql);
            if (obj == null || string.IsNullOrEmpty(obj.ToString()))
            {
                return 1;
            }
            else
            {
                return long.Parse(obj.ToString());
            }
        }

        public EbSite.Entity.NewsContent NewsContent_GetNext(string TableName, long Id)
        {
            string ssql = string.Format("SELECT * FROM {0}{1} WHERE ID>{2} ORDER BY id ASC LIMIT 1 ", sPre, TableName, Id);
            Entity.NewsContent model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, ssql))
            {
                if (dataReader.Read())
                {
                    model = NewsContent_ReaderBind(dataReader, TableName, 0);
                }
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 动态添加 列
        /// </summary>
        /// <param name="sTbName"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public bool NewColumnName_Add(string sTbName, string ColumnName, EbSite.Base.EntityAPI.EDataFiledType ColumnType, int iLength)
        {
            bool key = false;
            if (!NewColumnName_Exists(sTbName, ColumnName))
            {
                //可以添加

                //-- ALTER TABLE xxx ADD nc_ajx VARCHAR(200) ;
                //-- ALTER TABLE xxx ADD nc_ajxTime datetime ;
                //-- ALTER TABLE xxx ADD nc_ajxInt INT(5) unsigned default 0;
                //-- ALTER TABLE xxx ADD nc_ajxDecimal decimal(19,2) unsigned default 0;
                //-- ALTER TABLE xxx ADD nc_ajxFloat float(11,2) unsigned default 0;


                //字段数据类型 文本(varchar)0| 内容(longtext)1| 字符(char) 2|数字(int) 3|小数两位(decimal) 4| 时间(datetime)5|是否(bit)6
                string str = "";
                switch (ColumnType)
                {
                    case Base.EntityAPI.EDataFiledType.varcharE:
                        str = string.Concat("ALTER TABLE ", sPre + sTbName, " ADD ", ColumnName, " VARCHAR(", iLength, ") ;");
                        break;
                    case Base.EntityAPI.EDataFiledType.longtextE:
                        str = string.Concat("ALTER TABLE ", sPre + sTbName, " ADD ", ColumnName, "  LONGTEXT;");
                        break;
                    case Base.EntityAPI.EDataFiledType.charE:
                        str = string.Concat("ALTER TABLE ", sPre + sTbName, " ADD ", ColumnName, "  char(", iLength, ");");
                        break;
                    case Base.EntityAPI.EDataFiledType.intE:
                        str = string.Concat("ALTER TABLE ", sPre + sTbName, " ADD ", ColumnName, " INT(", iLength, ") unsigned default 0;");
                        break;
                    case Base.EntityAPI.EDataFiledType.decimalE:
                        str = string.Concat("ALTER TABLE ", sPre + sTbName, " ADD ", ColumnName, " decimal(", iLength, ",2) unsigned default 0;");
                        break;
                    case Base.EntityAPI.EDataFiledType.datetimeE:
                        str = string.Concat("ALTER TABLE ", sPre + sTbName, " ADD ", ColumnName, " datetime ;");
                        break;
                    case Base.EntityAPI.EDataFiledType.bitE:
                        str = string.Concat("ALTER TABLE ", sPre + sTbName, " ADD ", ColumnName, "  bit(1);");
                        break;
                }
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, str);
                if (NewColumnName_Exists(sTbName, ColumnName))
                {
                    key = true;
                }


            }

            return key;
        }

        /// <summary>
        /// 动态删除 列
        /// </summary>
        /// <param name="sTbName"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public bool NewColumnName_Del(string sTbName, string ColumnName)
        {
            bool ikey = false;
            //-- ALTER TABLE xxx DROP COLUMN nc_ajxFloat 删除
            if (NewColumnName_Exists(sTbName, ColumnName))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("  ALTER TABLE {0} DROP COLUMN {1};", sPre + sTbName, ColumnName);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                if (!NewColumnName_Exists(sTbName, ColumnName))
                {
                    ikey = true;
                }
            }
            return ikey;
        }

        /// <summary>
        /// 返回 复制的表名称
        /// </summary>
        /// <param name="TbName"></param>
        /// <returns></returns>
        public string NewTbName(string TbName)
        {
            string sName = "";
            if (NewTb_Exists(TbName))
            {
                string InitTbName = string.Concat(TbName, "_copy");
                TbName = string.Concat(TbName, "_copy");
                for (int i = 0; i < 100; i++)
                {
                    if (NewTb_Exists(TbName))
                    {
                        TbName = string.Concat(InitTbName, i);
                    }
                    else
                    {
                        sName = TbName;
                        break;
                    }
                }
                if (!NewTb_Create(sName))
                {
                    sName = "";
                }
            }
            return sName;
        }
        /// <summary>
        /// 创建 表 true 创建成功
        /// </summary>
        /// <param name="sTbName"></param>
        /// <returns></returns>
        public bool NewTb_Create(string sTbName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" CREATE TABLE {0}  LIKE {1} ;", sPre + sTbName, sPre + "newscontent");
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            return NewTb_Exists(sTbName);
        }
        public void NewsContent_Update(string Where, string Col, string sValue, string TableName)
        {
            if (!string.IsNullOrEmpty(Where))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("update {0}{4} set {1}={2} where {3} ", sPre, Col, sValue, Where, TableName);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }

        }

        public void DeleteNewsContentOutSiteData(string siteids, string TableName)
        {
            if (!string.IsNullOrEmpty(siteids))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("delete from {0}{1} ", sPre, TableName);
                strSql.Append(" where siteid not in(" + siteids + ")");

                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }

        }
        public void NewsContent_UpdateAllRule(string sRule, string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}{1} set ", sPre, TableName);
            strSql.Append("ContentHtmlNameRule=?HtmlRule ");

            MySqlParameter[] parameters = {
					new MySqlParameter("?HtmlRule", MySqlDbType.VarChar,300)
                                        };
            parameters[0].Value = sRule;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public void NewsContent_Update(long id, string Col, string sValue, string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}{4} set {1}={2} where id={3}", sPre, Col, sValue, id, TableName);
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int NewsContent_Add(EbSite.Entity.NewsContent model, string TableName)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.AppendFormat("insert into {0}NewsContent(", sPre);
            //strSql.Append("SmallPic,NewsTitle,TitleStyle,ClassID,hits,IsGood,ContentInfo,dayHits,weekHits,monthhits,lasthitstime,TagIDs,OrderID,HtmlName,ContentHtmlNameRule,MarkIsMakeHtml,IsComment,AddTime,IsAuditing,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex9,Annex10,Annex11,Annex12,Annex13,Annex14,Annex15,Annex16,Annex17,Annex18,Annex19,Annex20,Annex21,Annex22,Annex23,Annex24,Annex25,ContentTemID,Advs,ClassName,CommentNum,FavorableNum,UserID,UserNiName,UserName,SiteID,RandNum,NumberTime)");
            //strSql.Append(" values (");
            //strSql.Append("?SmallPic,?NewsTitle,?TitleStyle,?ClassID,?hits,?IsGood,?ContentInfo,?dayHits,?weekHits,?monthhits,?lasthitstime,?TagIDs,?OrderID,?HtmlName,?ContentHtmlNameRule,?MarkIsMakeHtml,?IsComment,?AddTime,?IsAuditing,?Annex1,?Annex2,?Annex3,?Annex4,?Annex5,?Annex6,?Annex7,?Annex8,?Annex9,?Annex10,?Annex11,?Annex12,?Annex13,?Annex14,?Annex15,?Annex16,?Annex17,?Annex18,?Annex19,?Annex20,?Annex21,?Annex22,?Annex23,?Annex24,?Annex25,?ContentTemID,?Advs,?ClassName,?CommentNum,?FavorableNum,?UserID,?UserNiName,?UserName,?SiteID,?RandNum,?NumberTime)");
            //strSql.Append(";SELECT @@session.identity");
           

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}{1}(", sPre, TableName);
            strSql.Append("SmallPic,NewsTitle,TitleStyle,ClassID,hits,IsGood,ContentInfo,dayHits,weekHits,monthhits,lasthitstime,TagIDs,OrderID,HtmlName,ContentHtmlNameRule,MarkIsMakeHtml,IsComment,AddTime,IsAuditing,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex9,Annex10,Annex11,Annex12,Annex13,Annex14,Annex15,Annex16,Annex17,Annex18,Annex19,Annex20,Annex21,Annex22,Annex23,Annex24,Annex25,Advs,ClassName,CommentNum,FavorableNum,UserID,UserNiName,UserName,SiteID,RandNum,NumberTime,Keywords,Description)");
            strSql.Append(" values (");
            strSql.Append("?SmallPic,?NewsTitle,?TitleStyle,?ClassID,?hits,?IsGood,?ContentInfo,?dayHits,?weekHits,?monthhits,?lasthitstime,?TagIDs,?OrderID,?HtmlName,?ContentHtmlNameRule,?MarkIsMakeHtml,?IsComment,?AddTime,?IsAuditing,?Annex1,?Annex2,?Annex3,?Annex4,?Annex5,?Annex6,?Annex7,?Annex8,?Annex9,?Annex10,?Annex11,?Annex12,?Annex13,?Annex14,?Annex15,?Annex16,?Annex17,?Annex18,?Annex19,?Annex20,?Annex21,?Annex22,?Annex23,?Annex24,?Annex25,?Advs,?ClassName,?CommentNum,?FavorableNum,?UserID,?UserNiName,?UserName,?SiteID,?RandNum,?NumberTime,?Keywords,?Description)");
            strSql.Append(";SELECT @@session.identity");

            MySqlParameter[] parameters = {
					new MySqlParameter("?SmallPic", MySqlDbType.VarChar,255),
					new MySqlParameter("?NewsTitle", MySqlDbType.VarChar,150),
					new MySqlParameter("?TitleStyle", MySqlDbType.VarChar,100),
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4),
					new MySqlParameter("?hits",  MySqlDbType.Int32,4),
					new MySqlParameter("?IsGood", MySqlDbType.Int16,1),
					new MySqlParameter("?ContentInfo", MySqlDbType.VarChar),
					new MySqlParameter("?dayHits",  MySqlDbType.Int32,4),
					new MySqlParameter("?weekHits",  MySqlDbType.Int32,4),
					new MySqlParameter("?monthhits",  MySqlDbType.Int32,4),
					new MySqlParameter("?lasthitstime", MySqlDbType.DateTime),
					new MySqlParameter("?TagIDs", MySqlDbType.VarChar,255),
					new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
					new MySqlParameter("?HtmlName", MySqlDbType.VarChar,300),
					new MySqlParameter("?ContentHtmlNameRule", MySqlDbType.VarChar,300),
					new MySqlParameter("?MarkIsMakeHtml", MySqlDbType.Int16,1),
					new MySqlParameter("?IsComment", MySqlDbType.Int16,1),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?IsAuditing", MySqlDbType.Int16,1),
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

                    new MySqlParameter("?Annex11",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex12",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex13",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex14",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex15",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex16", MySqlDbType.Decimal,9),
					new MySqlParameter("?Annex17",  MySqlDbType.Decimal,9),
					new MySqlParameter("?Annex18",  MySqlDbType.Decimal,9),


                    new MySqlParameter("?Annex19",  MySqlDbType.Float),
					new MySqlParameter("?Annex20",  MySqlDbType.Float),

                    new MySqlParameter("?Annex21",   MySqlDbType.Int64),
					new MySqlParameter("?Annex22",   MySqlDbType.Int64),
					new MySqlParameter("?Annex23",   MySqlDbType.Int64),
					new MySqlParameter("?Annex24",   MySqlDbType.Int64),
					new MySqlParameter("?Annex25",   MySqlDbType.Int64),

                    //new MySqlParameter("?ContentTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?Advs",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CommentNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?FavorableNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100),
                    new MySqlParameter("?SiteID", MySqlDbType.Int32,4),
                       new MySqlParameter("?RandNum",MySqlDbType.Int32,4),
                       new MySqlParameter("?NumberTime",MySqlDbType.Int32,4),

                       new MySqlParameter("?Keywords", MySqlDbType.VarChar,300),
                       new MySqlParameter("?Description", MySqlDbType.VarChar,500)

                                          };
            
            parameters[0].Value = model.SmallPic;
            parameters[1].Value = model.NewsTitle;
            parameters[2].Value = model.TitleStyle;
            parameters[3].Value = model.ClassID;
            parameters[4].Value = model.hits;
            parameters[5].Value = model.IsGood;
            parameters[6].Value = model.ContentInfo;
            parameters[7].Value = model.dayHits;
            parameters[8].Value = model.weekHits;
            parameters[9].Value = model.monthhits;
            parameters[10].Value = model.lasthitstime;
            parameters[11].Value = model.TagIDs;
            parameters[12].Value = model.OrderID;
            parameters[13].Value = model.HtmlName;
            parameters[14].Value = model.ContentHtmlNameRule;
            parameters[15].Value = model.MarkIsMakeHtml;
            parameters[16].Value = model.IsComment;
            parameters[17].Value = model.AddTime;
            parameters[18].Value = model.IsAuditing;
            parameters[19].Value = model.Annex1;
            parameters[20].Value = model.Annex2;
            parameters[21].Value = model.Annex3;
            parameters[22].Value = model.Annex4;
            parameters[23].Value = model.Annex5;
            parameters[24].Value = model.Annex6;
            parameters[25].Value = model.Annex7;
            parameters[26].Value = model.Annex8;
            parameters[27].Value = model.Annex9;
            parameters[28].Value = model.Annex10;

            parameters[29].Value = model.Annex11;
            parameters[30].Value = model.Annex12;
            parameters[31].Value = model.Annex13;
            parameters[32].Value = model.Annex14;
            parameters[33].Value = model.Annex15;
            parameters[34].Value = model.Annex16;
            parameters[35].Value = model.Annex17;
            parameters[36].Value = model.Annex18;

            parameters[37].Value = model.Annex19;
            parameters[38].Value = model.Annex20;

            parameters[39].Value = model.Annex21;
            parameters[40].Value = model.Annex22;
            parameters[41].Value = model.Annex23;
            parameters[42].Value = model.Annex24;
            parameters[43].Value = model.Annex25;


            //parameters[44].Value = model.ContentTemID;
            parameters[44].Value = model.Advs;
            parameters[45].Value = model.ClassName;
            parameters[46].Value = model.CommentNum;
            parameters[47].Value = model.FavorableNum;
            parameters[48].Value = model.UserID;
            parameters[49].Value = model.UserNiName;
            parameters[50].Value = model.UserName;
            parameters[51].Value = model.SiteID;
            parameters[52].Value = model.RandNum;
            parameters[53].Value = model.NumberTime;

            parameters[54].Value = model.Keywords;
            parameters[55].Value = model.Description;






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
        public void NewsContent_Update(EbSite.Entity.NewsContent model, string TableName)
        {
            NewsContent_Update(model, null, TableName);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void NewsContent_Update(EbSite.Entity.NewsContent model, DbTransaction Trans, string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}{1} set ", sPre, TableName);
            strSql.Append("SmallPic=?SmallPic,");
            strSql.Append("NewsTitle=?NewsTitle,");
            strSql.Append("TitleStyle=?TitleStyle,");
            strSql.Append("ClassID=?ClassID,");
            strSql.Append("hits=?hits,");
            strSql.Append("IsGood=?IsGood,");
            strSql.Append("ContentInfo=?ContentInfo,");
            strSql.Append("dayHits=?dayHits,");
            strSql.Append("weekHits=?weekHits,");
            strSql.Append("monthhits=?monthhits,");
            strSql.Append("lasthitstime=?lasthitstime,");
            strSql.Append("TagIDs=?TagIDs,");
            strSql.Append("OrderID=?OrderID,");
            strSql.Append("HtmlName=?HtmlName,");
            strSql.Append("ContentHtmlNameRule=?ContentHtmlNameRule,");
            strSql.Append("MarkIsMakeHtml=?MarkIsMakeHtml,");
            strSql.Append("IsComment=?IsComment,");
            strSql.Append("AddTime=?AddTime,");
            strSql.Append("IsAuditing=?IsAuditing,");
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
            strSql.Append("Annex18=?Annex18,");

            strSql.Append("Annex19=?Annex19,");
            strSql.Append("Annex20=?Annex20,");

            strSql.Append("Annex21=?Annex21,");
            strSql.Append("Annex22=?Annex22,");
            strSql.Append("Annex23=?Annex23,");
            strSql.Append("Annex24=?Annex24,");
            strSql.Append("Annex25=?Annex25,");

            //strSql.Append("ContentTemID=?ContentTemID,");
            strSql.Append("Advs=?Advs,");
            strSql.Append("ClassName=?ClassName,");
            strSql.Append("CommentNum=?CommentNum,");
            strSql.Append("FavorableNum=?FavorableNum,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("UserNiName=?UserNiName,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("SiteID=?SiteID,");

            strSql.Append("RandNum=?RandNum,");

            strSql.Append("NumberTime=?NumberTime,");

            strSql.Append("Keywords=?Keywords,");
            strSql.Append("Description=?Description");

            

            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int64,4),
					new MySqlParameter("?SmallPic", MySqlDbType.VarChar,255),
					new MySqlParameter("?NewsTitle", MySqlDbType.VarChar,150),
					new MySqlParameter("?TitleStyle", MySqlDbType.VarChar,100),
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4),
					new MySqlParameter("?hits",  MySqlDbType.Int32,4),
					new MySqlParameter("?IsGood", MySqlDbType.Int16,1),
					new MySqlParameter("?ContentInfo", MySqlDbType.VarChar),
					new MySqlParameter("?dayHits",  MySqlDbType.Int32,4),
					new MySqlParameter("?weekHits",  MySqlDbType.Int32,4),
					new MySqlParameter("?monthhits",  MySqlDbType.Int32,4),
					new MySqlParameter("?lasthitstime", MySqlDbType.DateTime),
					new MySqlParameter("?TagIDs", MySqlDbType.VarChar,255),
					new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
					new MySqlParameter("?HtmlName", MySqlDbType.VarChar,300),
					new MySqlParameter("?ContentHtmlNameRule", MySqlDbType.VarChar,300),
					new MySqlParameter("?MarkIsMakeHtml", MySqlDbType.Int16,1),
					new MySqlParameter("?IsComment", MySqlDbType.Int16,1),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?IsAuditing", MySqlDbType.Int16,1),
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

                    
                    new MySqlParameter("?Annex11",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex12",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex13",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex14",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex15",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex16", MySqlDbType.Decimal,9),
					new MySqlParameter("?Annex17", MySqlDbType.Decimal,9),
					new MySqlParameter("?Annex18", MySqlDbType.Decimal,9),

                    new MySqlParameter("?Annex19", MySqlDbType.Float),
                    new MySqlParameter("?Annex20", MySqlDbType.Float),

                    new MySqlParameter("?Annex21",   MySqlDbType.Int64),
					new MySqlParameter("?Annex22",   MySqlDbType.Int64),
					new MySqlParameter("?Annex23",   MySqlDbType.Int64),
					new MySqlParameter("?Annex24",   MySqlDbType.Int64),
					new MySqlParameter("?Annex25",   MySqlDbType.Int64),

                    //new MySqlParameter("?ContentTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?Advs",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CommentNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?FavorableNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100),
                    new MySqlParameter("?SiteID", MySqlDbType.Int32,4),
                          
                      new MySqlParameter("?RandNum",MySqlDbType.Int32,4),
                       new MySqlParameter("?NumberTime",MySqlDbType.Int32,4),

                       new MySqlParameter("?Keywords", MySqlDbType.VarChar,300),
                       new MySqlParameter("?Description", MySqlDbType.VarChar,500)

                                          };
            
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SmallPic;
            parameters[2].Value = model.NewsTitle;
            parameters[3].Value = model.TitleStyle;
            parameters[4].Value = model.ClassID;
            parameters[5].Value = model.hits;
            parameters[6].Value = model.IsGood;
            parameters[7].Value = model.ContentInfo;
            parameters[8].Value = model.dayHits;
            parameters[9].Value = model.weekHits;
            parameters[10].Value = model.monthhits;
            parameters[11].Value = model.lasthitstime;
            parameters[12].Value = model.TagIDs;
            parameters[13].Value = model.OrderID;
            parameters[14].Value = model.HtmlName;
            parameters[15].Value = model.ContentHtmlNameRule;
            parameters[16].Value = model.MarkIsMakeHtml;
            parameters[17].Value = model.IsComment;
            parameters[18].Value = model.AddTime;
            parameters[19].Value = model.IsAuditing;
            parameters[20].Value = model.Annex1;
            parameters[21].Value = model.Annex2;
            parameters[22].Value = model.Annex3;
            parameters[23].Value = model.Annex4;
            parameters[24].Value = model.Annex5;
            parameters[25].Value = model.Annex6;
            parameters[26].Value = model.Annex7;
            parameters[27].Value = model.Annex8;
            parameters[28].Value = model.Annex9;
            parameters[29].Value = model.Annex10;

            parameters[30].Value = model.Annex11;
            parameters[31].Value = model.Annex12;
            parameters[32].Value = model.Annex13;
            parameters[33].Value = model.Annex14;
            parameters[34].Value = model.Annex15;
            parameters[35].Value = model.Annex16;
            parameters[36].Value = model.Annex17;
            parameters[37].Value = model.Annex18;


            parameters[38].Value = model.Annex19;
            parameters[39].Value = model.Annex20;

            parameters[40].Value = model.Annex21;
            parameters[41].Value = model.Annex22;
            parameters[42].Value = model.Annex23;
            parameters[43].Value = model.Annex24;
            parameters[44].Value = model.Annex25;

            //parameters[45].Value = model.ContentTemID;
            parameters[45].Value = model.Advs;
            parameters[46].Value = model.ClassName;
            parameters[47].Value = model.CommentNum;
            parameters[48].Value = model.FavorableNum;
            parameters[49].Value = model.UserID;
            parameters[50].Value = model.UserNiName;
            parameters[51].Value = model.UserName;
            parameters[52].Value = model.SiteID;

            parameters[53].Value = model.RandNum;
            parameters[54].Value = model.NumberTime;

            parameters[55].Value = model.Keywords;
            parameters[56].Value = model.Description;

            

            if (Trans == null)
            {
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                DbHelperCmsWrite.Instance.ExecuteNonQuery(Trans, CommandType.Text, strSql.ToString(), parameters);
            }
        }
        /// <summary>
        /// 更新内容的评论条数
        /// </summary>
        /// <param name="iMusicID"></param>
        public void NewsContent_UpdateCommentNum(long iID, int iNum, string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Concat("update ", sPre, TableName, " set CommentNum=CommentNum+", iNum));
            strSql.Append(" where ID=");
            strSql.Append(iID);

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 更新内容的收藏用户人数
        /// </summary>
        /// <param name="iMusicID"></param>
        public void NewsContent_UpdateFavorableNum(long iID, int iNum, string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Concat("update ", sPre, TableName, " set FavorableNum=FavorableNum+", iNum));
            strSql.Append(" where ID=");
            strSql.Append(iID);

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 添加点击,指定更新点击数
        /// </summary>
        /// <param name="iMusicID"></param>
        public void NewsContent_AddHits(int iID, int iNum, string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Concat("update ", sPre, TableName, " set hits=hits+", iNum, ",dayHits=dayHits+", iNum, ",weekHits=weekHits+", iNum, ",monthhits=monthhits+", iNum));
            strSql.Append(" where ID=");
            strSql.Append(iID);

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 对点击数清零
        /// </summary>
        public void NewsContent_ResetHits(string Interval, string TableName)
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
            strSql.AppendFormat("update {0}{1} set ", sPre, TableName);
            strSql.Append(sType + "=?" + sType);
            strSql.Append(" where " + sType + ">0");
            MySqlParameter[] parameters = {
					new MySqlParameter("?"+sType, MySqlDbType.Int32 )
                                        };
            parameters[0].Value = 0;
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

        }
        /// <summary>
        /// 推荐新闻或取消推荐新闻
        /// </summary>
        /// <param name="iID"></param>
        public void NewsContent_UploadIsGood(long iID, string TableName)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("?p_ID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?p_tablename",  MySqlDbType.VarChar,20)
                                          };
            parameters[0].Value = iID;
            parameters[1].Value = sPre + TableName;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}UploadIsGood", sPre), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void NewsContent_Delete(long ID, string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}{1} ", sPre, TableName);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int64,4)};
            parameters[0].Value = ID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public void NewsContent_Delete(string IDs, string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}{1} ", sPre, TableName);

            strSql.Append(" where ID in(" + IDs + ")");
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());

        }
        /// <summary>
        /// 合并分类，及数据
        /// </summary>
        /// <param name="iSID">源分类ID</param>
        /// <param name="iTID">目标分类ID</param>
        public void NewsContent_MergeClass(string SIDs, int TID, string TClassName, string TableName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  {0}{1} set ", sPre, TableName);
            strSql.AppendFormat("ClassID={0},", TID);
            strSql.AppendFormat("ClassName='{0}' ", TClassName);
            strSql.AppendFormat(" where ClassID in({0}) ", SIDs);
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());

            //    StringBuilder strSql = new StringBuilder();
            //    strSql.AppendFormat("update {0}NewsContent set ", sPre);

            //    strSql.Append("ClassID=?ClassID,");
            //    strSql.Append("ClassName=?ClassName ");
            //    strSql.Append(" where ClassID=?OldID ");
            //    MySqlParameter[] parameters = {

            //            new MySqlParameter("?ClassID",  MySqlDbType.Int32,4),
            //            new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
            //            new MySqlParameter("?OldID",  MySqlDbType.Int32,4)};
            //    parameters[0].Value = TID;
            //    parameters[1].Value = TClassName;
            //    parameters[2].Value = SID;

            //    DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public void NewsContent_ToDefault(EbSite.Entity.NewsContent model, string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}{1} set ", sPre, TableName);

            strSql.Append("IsGood=?IsGood,");
            strSql.Append("TagIDs=?TagIDs,");
            strSql.Append("IsComment=?IsComment,");
            strSql.Append("IsAuditing=?IsAuditing,");
            //strSql.Append("ContentTemID=?ContentTemID,");
            strSql.Append("Advs=?Advs,");
            strSql.Append("CommentNum=?CommentNum,");
            strSql.Append("FavorableNum=?FavorableNum,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("UserNiName=?UserNiName,");
            strSql.Append("UserName=?UserName");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?IsGood", MySqlDbType.Int16,1),
					new MySqlParameter("?TagIDs", MySqlDbType.VarChar,255),
					new MySqlParameter("?IsComment", MySqlDbType.Int16,1),
					new MySqlParameter("?IsAuditing", MySqlDbType.Int16,1),
                    //new MySqlParameter("?ContentTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?Advs",  MySqlDbType.Int32,4),
					new MySqlParameter("?CommentNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?FavorableNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100)};
            parameters[0].Value = model.IsGood;
            parameters[1].Value = model.TagIDs;
            parameters[2].Value = model.IsComment;
            parameters[3].Value = model.IsAuditing;
            //parameters[4].Value = model.ContentTemID;
            parameters[4].Value = model.Advs;
            parameters[5].Value = model.CommentNum;
            parameters[6].Value = model.FavorableNum;
            parameters[7].Value = model.UserID;
            parameters[8].Value = model.UserNiName;
            parameters[9].Value = model.UserName;
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public void NewsContent_InitNum(int itype, int SiteID, string TableName)
        {
            string sUpdateFileds = "";
            if (itype == 0)
            {
                sUpdateFileds = "hits=0,dayhits=0,weekhits=0,monthhits=0,OrderID=0";
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
            else if (itype == 5)
            {
                sUpdateFileds = "OrderID=0";
            }
            else if (itype == 100)
            {
                sUpdateFileds = "IsGood=0";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}{1} set ", sPre, TableName);

            strSql.Append(sUpdateFileds);

            strSql.AppendFormat("where SiteID={0}", SiteID);

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        public void NewsContent_InitClassName(int SiteID, string TableName)
        {
            string sSql =
                string.Format("UPDATE {0}{2} a ,{0}newsClass b  SET a.ClassName = b.ClassName where a.SiteID={1} and b.ID = a.ClassID", sPre, SiteID, TableName);

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sSql);
        }



        /// <summary>
        /// 喜欢一条记录或不喜欢一条记录
        /// </summary>
        /// <param name="contentid">内容ID</param>
        /// <param name="itype">0,为不喜欢，1为喜欢</param>
        public void NewsContent_LikeOrNo(int contentid, int itype, string TableName)
        {
            string strSql = string.Format("update {0}{2} set FavorableNum=FavorableNum+1 where id={1}", sPre, contentid, TableName);
            if (itype == 0)
                strSql = string.Format("update {0}{2} set FavorableNum=FavorableNum-1 where id={1}", sPre, contentid, TableName);
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql);
        }

        //public List<EbSite.Entity.NewsContent> NewsContent_GetListHtmlNameReWrite(string sTableName,int SiteId)
        //{
        //    StringBuilder strSql = new StringBuilder();

        //    strSql.AppendFormat("select *  from  {0}{1} where HtmlReName<>'' ", sPre, sTableName);

        //    List<EbSite.Entity.NewsContent> list = new List<EbSite.Entity.NewsContent>();
        //    using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
        //    {
        //        while (dataReader.Read())
        //        {
        //            list.Add(NewsContent_ReaderBind(dataReader, sTableName, SiteId));
        //        }
        //    }
        //    return list;
        //}

        #endregion 写

    }
}

