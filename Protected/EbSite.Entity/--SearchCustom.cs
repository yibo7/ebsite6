//using System;
//using System.Collections.Generic;
//using System.Text;
//using EbSite.BLL.SearchCustom;

//namespace EbSite.Entity.SearchCustom
//{
//    /// <summary>
//    /// 一个搜索对象
//    /// </summary>
//    [Serializable]
//    public class SearchModel
//    {
//        private string _TableNames;
//        private string _SelectColumns;
//        private List<ColumnModel> _WhereColumns;
//        private int _PageSize = 15;
//        private string _KeyWords = "";
//        private string _Tem;
//        /// <summary>
//        /// 展示控件的模板
//        /// </summary>
//        public string Tem
//        {
//            get
//            {
//                return _Tem;
//            }
//            set
//            {
//                _Tem = value;
//            }
//        }
//        /// <summary>
//        /// 搜索的关键词
//        /// </summary>
//        public string KeyWords
//        {
//            get
//            {
//                return _KeyWords;
//            }
//            set
//            {
//                _KeyWords = value;
//            }
//        }
//        /// <summary>
//        /// 每页显示多少条
//        /// </summary>
//        public int PageSize
//        {
//            get
//            {
//                return _PageSize;
//            }
//            set
//            {
//                _PageSize = value;
//            }
//        }
//        /// <summary>
//        /// 搜索字段所在表名称,多个表用逗号分开
//        /// </summary>
//        public string TableNames
//        {
//            get
//            {
//                return _TableNames;
//            }
//            set
//            {
//                _TableNames = value;
//            }
//        }
//        /// <summary>
//        /// 搜索字段列表，带表前缀
//        /// </summary>
//        public string SelectColumns
//        {
//            get
//            {
//                return _SelectColumns;
//            }
//            set
//            {
//                _SelectColumns = value;
//            }
//        }
//        /// <summary>
//        /// 搜索字段名称
//        /// </summary>
//        public List<ColumnModel> WhereColumns
//        {
//            get
//            {
//                return _WhereColumns;
//            }
//            set
//            {
//                _WhereColumns = value;
//            }
//        }
       
//    }
//    public class ColumnModel
//    {
//        private string _SearchTableName;
//        private string _ColumnValue;
//        private string _SearchColumn;
//        private ESearhWhere _sWhere;
//        private EColumnDataType _DataType;
//        private int _AndOr;
//        public int AndOr
//        {
//            get
//            {
//                return _AndOr;
//            }
//            set
//            {
//                _AndOr = value;
//            }
//        }
//        /// <summary>
//        /// 搜索字段所在表名称,用于以后制作联合搜索时用
//        /// </summary>
//        public string SearchTableName
//        {
//            get
//            {
//                return _SearchTableName;
//            }
//            set
//            {
//                _SearchTableName = value;
//            }
//        }
//        /// <summary>
//        /// 搜索字段对应的值
//        /// </summary>
//        public string ColumnValue
//        {
//            get
//            {
//                return _ColumnValue;
//            }
//            set
//            {
//                _ColumnValue = value;
//            }
//        }
//        /// <summary>
//        /// 搜索字段名称
//        /// </summary>
//        public string SearchColumn
//        {
//            get
//            {
//                return _SearchColumn;
//            }
//            set
//            {
//                _SearchColumn = value;
//            }
//        }
//        public ESearhWhere sWhere
//        {
//            get
//            {
//                return _sWhere;
//            }
//            set
//            {
//                _sWhere = value;
//            }
//        }
//        public EColumnDataType DataType
//        {
//            get
//            {
//                return _DataType;
//            }
//            set
//            {
//                _DataType = value;
//            }
//        }
//    }

//    /// <summary>
//    /// CustomSearch.edit.ascx-
//    /// </summary>
//    public class TableConfigsModel
//    {
//        private string _sTableEName;

//        public string sTableEName
//        {
//            get
//            {
//                return _sTableEName;
//            }
//            set
//            {
//                _sTableEName = value;
//            }
//        }
//        private string _sTableCName;

//        public string sTableCName
//        {
//            get
//            {
//                return _sTableCName;
//            }
//            set
//            {
//                _sTableCName = value;
//            }
//        }
//        private string _sTableColumns;
//        public string sTableColumns
//        {
//            get
//            {
//                return _sTableColumns;
//            }
//            set
//            {
//                _sTableColumns = value;
//            }
//        }
//        public string[] aTableColumns
//        {
//            get
//            {
//                return sTableColumns.Split(',');
//            }
//        }
//        public string sColumnsWithTableName
//        {
//            get
//            {
//                StringBuilder sb = new StringBuilder();

//                foreach (string column in aTableColumns)
//                {
//                    sb.Append(sTableEName);
//                    sb.Append(".");
//                    sb.Append(column);
//                    sb.Append(",");
//                }
//                if (sb.Length > 1) sb.Remove(sb.Length - 1, 1);
//                return sb.ToString();
//            }
//        }
//    }


//}
