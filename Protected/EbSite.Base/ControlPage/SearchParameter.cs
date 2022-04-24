using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Base.ControlPage
{
    /// <summary>
    /// 要搜索的字段参数
    /// </summary>
    public class SearchParameter
    {
        /// <summary>
        /// 要搜索的列名称
        /// </summary>
        public string ColumnName { get; set; }
        public EmSearchWhere SearchWhere { get; set; }
        public EmSearchLink SearchLink { get; set; }
        public string ColumnValue { get; set; }
        public bool IsString { get; set; }

    }
    public enum EmSearchWhere
    {
        相等匹配 = 0,
        模糊匹配 = 1,
        大于 = 2,
        小于 = 3,
        其他 = 4

    }
    public enum EmSearchLink
    {
        或者or = 0,
        与连and = 1,
        不连用于最后一个 = 2

    }
}
