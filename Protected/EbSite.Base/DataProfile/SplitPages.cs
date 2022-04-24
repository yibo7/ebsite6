using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;

namespace EbSite.Base.DataProfile
{
    public class SplitPages
    {
        public static readonly string sPre =  EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;
        /// <summary>
        /// 通用(sqlserver access)，获取分页sql
        /// </summary>
        /// <param name="sTableName">表名称</param>
        /// <param name="PageSize">每页显示多少条数据</param>
        /// <param name="PageIndex">当前页码</param>
        /// <param name="strFields">查询字段</param>
        /// <param name="KeyField">主键字段名称</param>
        /// <param name="OrderBy">排序 如 id desc</param>
        /// <param name="strWhere">条件，如 id=10</param>
        /// <returns></returns>
        public static string GetSplitPagesSql(string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
                                       string OrderBy, string strWhere)
        {

            return GetSplitPagesSql(sTableName, PageSize, PageIndex, strFields, KeyField,
                                    OrderBy, strWhere, sPre);
        }
        public static string GetSplitPagesSql(string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
                                      string OrderBy, string strWhere, string TablePrefix)
        {
            return GetSplitPagesSqlPT( sTableName,  PageSize,  PageIndex,  strFields,  KeyField,
                                       OrderBy,  strWhere,  TablePrefix);
        }

        private static string GetSplitPagesSqlPT(string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
                                      string OrderBy, string strWhere, string TablePrefix)
        {
            sTableName = string.Concat(TablePrefix, sTableName);

            int iPage = ((PageIndex - 1) * PageSize);

            string sWhere1 = "";
            string sWhere2 = "";
            string sOrderBy = string.Format(" order by {0} desc", KeyField);
            string strSql = string.Empty;
            if (!string.IsNullOrEmpty(strWhere))
            {
                sWhere1 = string.Concat(" WHERE ", strWhere);
                sWhere2 = string.Concat(" AND ", strWhere);
            } 
            if (!string.IsNullOrEmpty(OrderBy))
            {
                sOrderBy = string.Concat(" ORDER BY ", OrderBy);
            }

            if (string.IsNullOrEmpty(strFields)) strFields = " * ";

            if (PageIndex <= 1)
            {
                strSql = string.Format("SELECT TOP {0} {1} FROM {2} {3} {4}", PageSize, strFields, sTableName, sWhere1, sOrderBy);
            }
            else
            {
                strSql = string.Format("select top {0} {1} from {2} where {3} not in(select top {4} {3} from {2} {5} {6} ) {7} {6} ",
                    PageSize, strFields, sTableName, KeyField, iPage, sWhere1, sOrderBy, sWhere2);
            }
            return strSql;
        }
        public static IDataReader GetListPages_SP(string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
                                       string OrderBy, string strWhere, out int totalRecords)
        {
            return GetListPages_SP(sTableName, PageSize, PageIndex, strFields, KeyField,
                                   OrderBy, strWhere, out totalRecords, sPre);
            ;
        }

        public static IDataReader GetListPagesSql2005(DbHelperBase DB, string sTableName, int PageSize, int PageIndex, string Fileds, string strWhere, string oderby, out int RecordCount)
        {
            string commandText = string.Format("select count(*)  from {0}  {1} ", sTableName, string.IsNullOrEmpty(strWhere) ? "" : (" Where " + strWhere));
            object objA = DB.ExecuteScalar(CommandType.Text, commandText);
            RecordCount = 1;
            if (!object.Equals(objA, null))
            {
                RecordCount = int.Parse(objA.ToString());
            }
            string str2 = GetListPagesSql2005(sTableName, PageIndex, PageSize, Fileds, strWhere, oderby);
            return DB.ExecuteReader(CommandType.Text, str2);
        }
        public static string GetListPagesSql2005(string sTableName, int PageIndex, int PageSize, string Fileds, string strWhere, string oderby)
        {
            if (PageIndex > 0)
            {
                PageIndex--;
            }
            int num = PageIndex * PageSize;
            int num2 = num + PageSize;
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("select {0},RankID ", Fileds);
            builder.Append(" FROM  ");
            builder.Append(string.Format(" (select {0},ROW_NUMBER() OVER(ORDER BY {1} ) AS RankID   ", Fileds, oderby));
            builder.Append(string.Format(" FROM {0}", sTableName));
            if (strWhere.Trim() != "")
            {
                builder.Append(" WHERE ");
                builder.Append(strWhere);
            }
            builder.Append(" ) AS NewRowNumber   WHERE RankID>");
            builder.Append(num);
            builder.Append(" AND RankID<=  ");
            builder.Append(num2);
            
            return builder.ToString();
        }

        private static IDataReader GetListPages_SPPT(DbHelperBase DB,string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
                                       string OrderBy, string strWhere, out int totalRecords, string TablePrefix)
        {
            DbHelperBase DBInstance;
            if (DB==null)
            {
                DBInstance = DbHelperCms.Instance;
            }
            else
            {
                DBInstance = DB;
            }
            sTableName = string.Concat(TablePrefix, sTableName);

            if (string.IsNullOrEmpty(strFields)) strFields = "*";

            SqlParameter[] parameters = new SqlParameter[]
                                            {
                                                new SqlParameter("@Tables", SqlDbType.VarChar, 1000), //表名称
                                                new SqlParameter("@PrimaryKey", SqlDbType.VarChar, 10), //表主键
                                                new SqlParameter("@Sort", SqlDbType.VarChar, 200), //排序 如 id desc
                                                new SqlParameter("@CurrentPage", SqlDbType.Int, 4), //当前页码 如 1
                                                new SqlParameter("@PageSize", SqlDbType.Int, 4), //每页显示多少条记录
                                                new SqlParameter("@Fields", SqlDbType.VarChar, 1000), //要查询的字段，为空，默认全部
                                                new SqlParameter("@Filter", SqlDbType.VarChar, 1000),//条件，如果 id>10 不带Where     
                                                //new SqlParameter("@Group", SqlDbType.VarChar, 1000),//分组 Group语句,不带Group By   
                                                //new SqlParameter("@PageCount", SqlDbType.Int), //总页数
                                                //new SqlParameter("@RecordCount", SqlDbType.Int) //总记录 
                                            };
            parameters[0].Value = sTableName;
            parameters[1].Value = KeyField;
            parameters[2].Value = OrderBy.Trim();
            parameters[3].Value = PageIndex;
            parameters[4].Value = PageSize;
            parameters[5].Value = strFields;
            parameters[6].Value = strWhere.Trim();
            //parameters[7].Value = "";
            //parameters[8].Direction = ParameterDirection.Output;
            //parameters[9].Direction = ParameterDirection.Output;

            IDataReader idr = DBInstance.ExecuteReader(CommandType.StoredProcedure,
                                                      string.Format("{0}SplitPages", TablePrefix),
                                                 parameters);
            //当您将 Command 对象用于存储过程时，可以将 Command 对象的 CommandType 属性设置为 StoredProcedure。当 CommandType 为 StoredProcedure 时，可以使用 Command 的 Parameters 属性来访问输入及输出参数和返回值。无论调用哪一个 Execute 方法，都可以访问 Parameters 属性。但是，当调用 ExecuteReader 时，在 DataReader 关闭之前，将无法访问返回值和输出参数
            string sCountSql = string.Format("select count(*)  from {0}  {1} ", sTableName, string.IsNullOrEmpty(strWhere) ? "" : string.Concat(" Where ", strWhere));

            object obCount = DBInstance.ExecuteScalar(CommandType.Text, sCountSql);
            totalRecords = 1;//int.Parse(parameters[9].Value.ToString());
            if (!Equals(obCount, null))
            {
                totalRecords = int.Parse(obCount.ToString());
            }
            return idr;
        }
      
        public static IDataReader GetListPages_SP(DbHelperBase DB,string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
                                       string OrderBy, string strWhere, out int totalRecords, string TablePrefix)
        {
            return GetListPages_SPPT(DB,sTableName, PageSize, PageIndex, strFields, KeyField,
                                        OrderBy, strWhere, out  totalRecords, TablePrefix);
        }
        public static IDataReader GetListPages_SP(string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
                                       string OrderBy, string strWhere, out int totalRecords, string TablePrefix)
        {
            return GetListPages_SPPT( null,sTableName,  PageSize,  PageIndex,  strFields,  KeyField,
                                        OrderBy,  strWhere, out  totalRecords,  TablePrefix);
        }


        public static IDataReader GetListPages_CusTomSearch(string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
                                       string OrderBy, string strWhere, out int totalRecords)
        {
            

            if (string.IsNullOrEmpty(strFields)) strFields = "*";

            SqlParameter[] parameters = new SqlParameter[]
                                            {
                                                new SqlParameter("@Tables", SqlDbType.VarChar, 1000), //表名称
                                                new SqlParameter("@PrimaryKey", SqlDbType.VarChar, 10), //表主键
                                                new SqlParameter("@Sort", SqlDbType.VarChar, 200), //排序 如 id desc
                                                new SqlParameter("@CurrentPage", SqlDbType.Int, 4), //当前页码 如 1
                                                new SqlParameter("@PageSize", SqlDbType.Int, 4), //每页显示多少条记录
                                                new SqlParameter("@Fields", SqlDbType.VarChar, 1000), //要查询的字段，为空，默认全部
                                                new SqlParameter("@Filter", SqlDbType.VarChar, 1000),//条件，如果 id>10 不带Where     
                                                //new SqlParameter("@Group", SqlDbType.VarChar, 1000),//分组 Group语句,不带Group By   
                                                //new SqlParameter("@PageCount", SqlDbType.Int), //总页数
                                                //new SqlParameter("@RecordCount", SqlDbType.Int) //总记录 
                                            };
            parameters[0].Value = sTableName;
            parameters[1].Value = KeyField;
            parameters[2].Value = OrderBy.Trim();
            parameters[3].Value = PageIndex;
            parameters[4].Value = PageSize;
            parameters[5].Value = strFields;
            parameters[6].Value = strWhere.Trim();
            //parameters[7].Value = "";
            //parameters[8].Direction = ParameterDirection.Output;
            //parameters[9].Direction = ParameterDirection.Output;

            IDataReader idr = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure,
                                                      string.Format("{0}SplitPages", sPre),
                                                 parameters);
            //当您将 Command 对象用于存储过程时，可以将 Command 对象的 CommandType 属性设置为 StoredProcedure。当 CommandType 为 StoredProcedure 时，可以使用 Command 的 Parameters 属性来访问输入及输出参数和返回值。无论调用哪一个 Execute 方法，都可以访问 Parameters 属性。但是，当调用 ExecuteReader 时，在 DataReader 关闭之前，将无法访问返回值和输出参数
            //totalRecords = 1;//int.Parse(parameters[9].Value.ToString());

            //当您将 Command 对象用于存储过程时，可以将 Command 对象的 CommandType 属性设置为 StoredProcedure。当 CommandType 为 StoredProcedure 时，可以使用 Command 的 Parameters 属性来访问输入及输出参数和返回值。无论调用哪一个 Execute 方法，都可以访问 Parameters 属性。但是，当调用 ExecuteReader 时，在 DataReader 关闭之前，将无法访问返回值和输出参数
            string sCountSql = string.Format("select count(*)  from {0}  {1} ", sTableName, string.IsNullOrEmpty(strWhere) ? "" : string.Concat(" Where ", strWhere));

            object obCount = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, sCountSql);
            totalRecords = 1;//int.Parse(parameters[9].Value.ToString());
            if (!Equals(obCount, null))
            {
                totalRecords = int.Parse(obCount.ToString());
            }

            return idr;
        }

        //#region MySql 存储过程 以后启用


        //public static IDataReader GetSplitPagesMySql(string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
        //                             string OrderBy, string strWhere, out int totalRecords)
        //{
        //    return GetSplitPagesMySql(null, sTableName, PageSize, PageIndex, strFields, KeyField,
        //                           OrderBy, strWhere, out totalRecords, sPre);

        //}
        //public static IDataReader GetSplitPagesMySql(DbHelperBase DB, string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
        //                              string OrderBy, string strWhere, out int totalRecords, string TablePrefix)
        //{
        //    return GetSplitPagesMySqlPT(DB, sTableName, PageSize, PageIndex, strFields, KeyField,
        //                                OrderBy, strWhere, out  totalRecords, TablePrefix);
        //}
        //public static IDataReader GetSplitPagesMySql(string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
        //                               string OrderBy, string strWhere, out int totalRecords, string TablePrefix)
        //{
        //    return GetSplitPagesMySqlPT(null, sTableName, PageSize, PageIndex, strFields, KeyField,
        //                                OrderBy, strWhere, out  totalRecords, TablePrefix);
        //}

        //private static IDataReader GetSplitPagesMySqlPT(DbHelperBase DB, string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
        //                            string OrderBy, string strWhere, out int totalRecords, string TablePrefix)
        //{
        //    DbHelperBase DBInstance;
        //    if (DB == null)
        //    {
        //        DBInstance = DbHelperCms.Instance;
        //    }
        //    else
        //    {
        //        DBInstance = DB;
        //    }
        //    sTableName = string.Concat(TablePrefix, sTableName);

        //    if (string.IsNullOrEmpty(strFields)) strFields = "*";
        //    MySqlParameter[] parameters = new MySqlParameter[]
        //                                    {
        //                                        new MySqlParameter("$TableName", MySqlDbType.VarChar, 200), //表名称
        //                                        new MySqlParameter("$FieldList", MySqlDbType.VarChar, 2000), //显示列名
        //                                        new MySqlParameter("$PrimaryKey", MySqlDbType.VarChar, 1000), //主键
        //                                        new MySqlParameter("$Where", MySqlDbType.VarChar,1000), //查询条件 不含'where'字符 
        //                                        new MySqlParameter("$Order", MySqlDbType.VarChar, 1000), //排序 不含'order by'字符，如id asc,userid desc，当@SortType=3时生效 
        //                                        new MySqlParameter("$SortType", MySqlDbType.Int32, 4), //排序规则 1:正序asc 2:倒序desc 3:多列排序
        //                                        new MySqlParameter("$RecorderCount", MySqlDbType.Int32, 4),//记录总数 0:会返回总记录   
        //                                        new MySqlParameter("$PageSize", MySqlDbType.Int32, 4),// 分页大小
        //                                        new MySqlParameter("$PageIndex", MySqlDbType.Int32, 4)// 页索引
                                              
                                               
        //                                    };
        //    parameters[0].Value = sTableName;
        //    parameters[1].Value = strFields;
        //    parameters[2].Value = KeyField;
        //    parameters[3].Value = strWhere;
        //    parameters[4].Value = OrderBy;
        //    parameters[5].Value = 2;
        //    parameters[6].Value = 0;
        //    parameters[7].Value = PageSize;
        //    parameters[8].Value = PageIndex;


        //    IDataReader idr = DBInstance.ExecuteReader(CommandType.StoredProcedure,
        //                                              string.Format("{0}SplitPages", TablePrefix),
        //                                         parameters);
        //    //当您将 Command 对象用于存储过程时，可以将 Command 对象的 CommandType 属性设置为 StoredProcedure。当 CommandType 为 StoredProcedure 时，可以使用 Command 的 Parameters 属性来访问输入及输出参数和返回值。无论调用哪一个 Execute 方法，都可以访问 Parameters 属性。但是，当调用 ExecuteReader 时，在 DataReader 关闭之前，将无法访问返回值和输出参数
        //    string sCountSql = string.Format("select count(*)  from {0}  {1} ", sTableName, string.IsNullOrEmpty(strWhere) ? "" : string.Concat(" Where ", strWhere));

        //    object obCount = DBInstance.ExecuteScalar(CommandType.Text, sCountSql);
        //    totalRecords = 1;//int.Parse(parameters[9].Value.ToString());
        //    if (!Equals(obCount, null))
        //    {
        //        totalRecords = int.Parse(obCount.ToString());
        //    }
        //    return idr;
        //}
        //#endregion

        #region MySql
        //public static string GetSplitPagesMySql(string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
        //                              string OrderBy, string strWhere)
        //{

        //    return GetSplitPagesMySql(sTableName, PageSize, PageIndex, strFields, KeyField,
        //                            OrderBy, strWhere, sPre);
        //}
        //public static string GetSplitPagesMySql(DbHelperBase DB, string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
        //                              string OrderBy, string strWhere, string TablePrefix)
        //{
        //    return GetSplitPagesMySqlPT(sTableName, PageSize, PageIndex, strFields, KeyField,
        //                               OrderBy, strWhere, TablePrefix);
        //}
        /// <summary>
        /// 两个表的联合查询分页sql
        /// </summary>
        /// <param name="DB"></param>
        /// <param name="sTableName1"></param>
        /// <param name="sTableName2"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strFields"></param>
        /// <param name="sTable1Key"></param>
        /// <param name="sTable2Key"></param>
        /// <param name="OrderBy"></param>
        /// <param name="strWhere"></param>
        /// <param name="TablePrefix"></param>
        /// <returns></returns>
        public static string GetSplitPagesMySql(DbHelperBase DB, string sTableName1, string sTableName2, int PageSize, int PageIndex, string strFields, string sTable1Key, string sTable2Key,
                                      string OrderBy, string strWhere, string TablePrefix)
        {
            sTableName1 = string.Concat(TablePrefix, sTableName1);
            sTableName2 = string.Concat(TablePrefix, sTableName2);
            string strSql = string.Empty;
            string sOrderBy = string.Empty;
            if (PageIndex > 0)
            {
                PageIndex--;
            }
            if (!string.IsNullOrEmpty(OrderBy))
            {
                sOrderBy = string.Concat(" ORDER BY ", OrderBy);
            }
            int numStart = PageIndex * PageSize;
            string WhereTem = string.Format(" where {0}.{1}={2}.{3}", sTableName1, sTable1Key, sTableName2, sTable2Key);
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = string.Concat(WhereTem, " and ", strWhere);
            }
            else
            {
                strWhere = WhereTem;
            }

            strSql = string.Concat("select ",sTableName1,".", sTable1Key, " from ", sTableName1, ",", sTableName2," ", strWhere, sOrderBy, " limit ", numStart, ",", PageSize, ";");
            StringBuilder sbIDs = new StringBuilder();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    sbIDs.Append(dataReader.GetString(0));
                    sbIDs.Append(",");
                }
            }
            if (sbIDs.Length > 1)
            {
                sbIDs.Remove(sbIDs.Length - 1, 1);
            }
            else
            {
                sbIDs.Append("0");
            }

            if (string.IsNullOrEmpty(strFields))
            {
                strFields = "*";
            }
            else
            {
                strFields = string.Format(strFields, sTableName1, sTableName2);
            }

            strSql = string.Concat("select ", strFields, " from ", sTableName1, ",", sTableName2, " where ", sTableName1, ".", sTable1Key, "=", sTableName2, ".", sTable2Key," and ", sTableName1, ".", sTable1Key, " in (", sbIDs, ")", sOrderBy);

            return strSql;
        }

        public static string GetSplitPagesMySql(DbHelperBase DB, string sTableName, int PageSize, int PageIndex,
                                                string strFields, string KeyField,
                                                string OrderBy, string strWhere, string TablePrefix)
        {
            return GetSplitPagesMySql(DB, sTableName, PageSize, PageIndex,
                                      strFields, KeyField,
                                      OrderBy, strWhere, TablePrefix, true);
        }

        public static string GetSplitPagesMySql(DbHelperBase DB, string sTableName, int PageSize, int PageIndex, string strFields, string KeyField,
                                      string OrderBy, string strWhere, string TablePrefix,bool isint)
        {
            sTableName = string.Concat(TablePrefix, sTableName);
            string strSql = string.Empty;
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
                if (!string.IsNullOrEmpty(KeyField))
                    sOrderBy = string.Concat(" ORDER BY ", KeyField, " desc"); 
            }

            int numStart = PageIndex * PageSize;

            if (!string.IsNullOrEmpty(strWhere))
                strWhere = string.Concat(" where ", strWhere);
            strSql = string.Concat("select ", KeyField, " from ", sTableName, " ", strWhere,sOrderBy, " limit ", numStart, ",", PageSize, ";");
            StringBuilder sbIDs = new StringBuilder();
            if (isint)
            {
                using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
                {
                    while (dataReader.Read())
                    {
                        sbIDs.Append(dataReader.GetString(0));
                        sbIDs.Append(",");
                    }
                }
            }
            else
            {
                using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
                {
                    while (dataReader.Read())
                    {
                        sbIDs.Append("'");
                        sbIDs.Append(dataReader.GetString(0));
                        sbIDs.Append("'");
                        sbIDs.Append(",");
                    }
                }
            }
            
            if (sbIDs.Length>1)
            {
                sbIDs.Remove(sbIDs.Length - 1, 1);
            }
            else
            {
                sbIDs.Append("0");
            }
            
            if (string.IsNullOrEmpty(strFields))
                strFields = "*";
            strSql = string.Concat("select ", strFields, " from ", sTableName, " where ", KeyField, " in (", sbIDs, ")", sOrderBy);

            
            //int iPage = ((PageIndex - 1) * PageSize);

            //string sWhere1 = "";
            //string sWhere2 = "";
            //string sOrderBy = string.Format(" order by {0} desc", KeyField);
            
            //if (!string.IsNullOrEmpty(strWhere))
            //{
            //    sWhere1 = string.Concat(" WHERE ", strWhere);
            //    sWhere2 = string.Concat(" AND ", strWhere);
            //}
            //if (!string.IsNullOrEmpty(OrderBy))
            //{
            //    sOrderBy = string.Concat(" ORDER BY ", OrderBy);
            //}

            //if (string.IsNullOrEmpty(strFields)) strFields = " * ";

            //if (PageIndex <= 1)
            //{
            //    strSql = string.Format("SELECT  {1} FROM {2} {3} {4} limit {0}", PageSize, strFields, sTableName, sWhere1, sOrderBy);
            //}
            //else
            //{
            //    strSql = string.Format("select {1} from {2} where {3} not in(select  {3} from {2} {5} {6} limit {4}) {7} {6}  limit {0}",
            //        PageSize, strFields, sTableName, KeyField, iPage, sWhere1, sOrderBy, sWhere2);
            //})
            return strSql;
        }
        #endregion
    }
}
