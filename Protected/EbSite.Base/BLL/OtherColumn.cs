using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Base.BLL
{
    /// <summary>
    /// 用来辅佐控件添加附加字段
    /// </summary>
    public class OtherColumn
    {
        private string _ColumnName;
        private string _ColumnValue;
        /// <summary>
        /// 列名称
        /// </summary>
        public string ColumnName
        {
            get
            {
                return _ColumnName;
            }
            set
            {
                _ColumnName = value;
            }
        }
        /// <summary>
        /// 列的值
        /// </summary>
        public string ColumnValue
        {
            get
            {
                return _ColumnValue;
            }
            set
            {
                _ColumnValue = value;
            }
        }

        public OtherColumn(string sColumnName, string sColumnValue)
        {
            _ColumnValue = sColumnValue;
            _ColumnName = sColumnName;
        }
    }
}
