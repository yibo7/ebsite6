//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Text;
//using MySql.Data.MySqlClient;
//using EbSite.BLL.SearchCustom;
//using EbSite.Base.DataProfile;
//using EbSite.Entity.SearchCustom;

////请先添加引用
//namespace EbSite.Data.MySql
//{
//	/// <summary>
//	/// 数据访问类NewsClass。
//	/// </summary>
//    public partial class DataProviderCms : Interface.IDataProviderCms
//	{
//        #region 读

//        /// <summary>
//        /// 获取总记录条数
//        /// </summary>
//        /// <returns></returns>
//        private int SearchCustom_GetCount(string strWhere, string TableNames)
//        {
//            StringBuilder strSql = new StringBuilder();
//            strSql.Append("select count(*) ");
//            strSql.AppendFormat(" from  {0} ", TableNames);

//            if (strWhere.Trim() != "")
//            {

//                strSql.Append(" where " + strWhere);
//            }

//            int iCount = -1;
//            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
//            {
//                while (dataReader.Read())
//                {
//                    iCount = int.Parse(dataReader[0].ToString());
//                }
//            }
//            return iCount;
//        }

//        /// <summary>
//        /// 分页获取数据列表 
//        /// </summary>
//        public DataSet SearchCustom_GetListPages(int PageIndex, int PageSize, SearchModel sm, ref int ResultCount, string OrderBy)
//        {
//            string sOrder = "id desc";
//            if (!string.IsNullOrEmpty(OrderBy))
//            {
//                sOrder = OrderBy;
//            }
//            string strWhere = GetWhere(sm);
//            ResultCount = SearchCustom_GetCount(strWhere, sm.TableNames);
//            int RecordCount = 0;

//            string strSql = SplitPages.GetSplitPagesSql(sm.TableNames, PageSize, PageIndex, sm.SelectColumns, "id", sOrder, strWhere, "");

//            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql);


//        }

//        private string GetWhere(SearchModel sm)
//        {
//            List<ColumnModel> lst = sm.WhereColumns;
//            StringBuilder sb = new StringBuilder();
//            int colIndex = 0;
//            for (int i = 0; i < lst.Count; i++)
//            {
//                ColumnModel columnModel = lst[i];
//                if (string.IsNullOrEmpty(columnModel.ColumnValue.Trim())) continue;
//                if (colIndex > 0)
//                {
//                    if (columnModel.AndOr == 1)
//                    {
//                        sb.Append(" or  ");
//                    }
//                    else //=2 为 and 这里为空时默认and
//                    {
//                        sb.Append(" and ");
//                    }
//                }
//                colIndex++;
//                if (columnModel.sWhere == ESearhWhere.BH)
//                {
//                    sb.AppendFormat(" {0} like '%{1}%' ", columnModel.SearchColumn, columnModel.ColumnValue);
//                }
//                else if (columnModel.sWhere == ESearhWhere.DY)
//                {
//                    sb.AppendFormat(" {0} > {1} ", columnModel.SearchColumn, columnModel.ColumnValue);
//                }
//                else if (columnModel.sWhere == ESearhWhere.DANGY)
//                {
//                    if (columnModel.DataType == EColumnDataType.STRING)
//                    {
//                        sb.AppendFormat(" {0} = '{1}' ", columnModel.SearchColumn, columnModel.ColumnValue);
//                    }
//                    else
//                    {
//                        sb.AppendFormat(" {0} = {1} ", columnModel.SearchColumn, columnModel.ColumnValue);
//                    }

//                }
//                else if (columnModel.sWhere == ESearhWhere.XY)
//                {
//                    sb.AppendFormat(" {0} < {1} ", columnModel.SearchColumn, columnModel.ColumnValue);
//                }

//            }
//            return sb.ToString();
//        }


//        #endregion 读

//        #region 写



//        #endregion 写
//    }
//}

