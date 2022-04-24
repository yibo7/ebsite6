using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucene.Net.Documents;

namespace EbSite.Base.LuceneUtils
{
    public class FieldEntity
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 字段对应的值
        /// </summary>
        public string FieldValue { get; set; }
        /// <summary>
        /// 标记字段是否存储
        /// </summary>
        public Field.Store FieldStore { get; set; }
        /// <summary>
        /// 标记字段是否为索引
        /// </summary>
        public Field.Index FieldIndex { get; set; }
        
    }
}
