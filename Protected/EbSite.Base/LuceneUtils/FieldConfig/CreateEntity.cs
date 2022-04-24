using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Base.LuceneUtils.FieldConfig
{
    public class CreateEntity : XmlEntityBase<int>
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public int SearchType { get; set; }
        public string SearchTypeName { get; set; }
    }
}
