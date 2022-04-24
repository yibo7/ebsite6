using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.ModulesGenerate.Core
{
    public class FieldInfo
    {
        
        /// <summary>
        /// 字段名
        /// </summary>
        private string _fieldname;
        public string FieldName
        {
            set { _fieldname = value; }
            get { return _fieldname; }
        }
        /// <summary>
        /// 类别ID List Add Show Search
        /// </summary>
        private int _typeid;
        public int TypeId
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 控件 ID
        /// </summary>
        private string _controlid;
        public string ControlId
        {
            set { _controlid = value; }
            get { return _controlid; }
        }

        /// <summary>
        /// 表的名称
        /// </summary>
        private string _tablename;
        public string TableName
        {
            set { _tablename = value; }
            get { return _tablename; }
        }

        /// <summary>
        /// 匹配模式
        /// </summary>
        private string _matching;
        public string Matching 
        {
            set { _matching = value; }
            get { return _matching; }
        }

        /// <summary>
        /// 关联模式
        /// </summary>
        private string _relevance;
        public string Relevance
        {
            set { _relevance = value; }
            get { return _relevance; }
        }
    }
}