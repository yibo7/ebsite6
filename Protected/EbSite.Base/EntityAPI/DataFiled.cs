using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Entity;

namespace EbSite.Base.EntityAPI
{
    [Serializable]
    public class DataFiled 
    {

        public DataFiled(string _ColumName, string _Value, ColumFiledConfigs _DataType)
        {
            this.CFiledConfigs = _DataType;
            this.ColumName = _ColumName;
            this.Value = _Value;
        }

        
        public ColumFiledConfigs CFiledConfigs { get; set; }

        public string ColumName { get; set; }

        public string Value { get; set; }

        public static List<ListItemSimple> GetEDataFiledTypes()
        {
            List<ListItemSimple> lst = new List<ListItemSimple>();

            lst.Add(new ListItemSimple("文本(varchar)","0"));
            lst.Add(new ListItemSimple("内容(longtext)", "1"));
            lst.Add(new ListItemSimple("字符(char)", "2"));
            lst.Add(new ListItemSimple("数字(int)", "3"));
            lst.Add(new ListItemSimple("小数两位(decimal)", "4"));
            lst.Add(new ListItemSimple("时间(datetime)", "5"));
            lst.Add(new ListItemSimple("是否(bit)", "6"));

            return lst;
        }
    }
    /// <summary>
    /// 字段数据类型 文本(varchar) 内容(longtext) 字符(char) 数字(int) 小数两位(decimal) 时间(datetime) 是否(bit)
    /// </summary>
    public enum EDataFiledType:int
    {
        /// <summary>
        /// 文本varchar
        /// </summary>
        varcharE = 0,
        /// <summary>
        /// 内容longtext
        /// </summary>
        longtextE = 1,
        /// <summary>
        /// 字符char
        /// </summary>
        charE = 2,
        /// <summary>
        /// 数字int
        /// </summary>
        intE = 3,
        /// <summary>
        /// 小数两位decimal
        /// </summary>
        decimalE = 4,
        /// <summary>
        /// 时间datetime
        /// </summary>
        datetimeE = 5,
        /// <summary>
        /// 是否bit
        /// </summary>
        bitE = 6

    }
}
