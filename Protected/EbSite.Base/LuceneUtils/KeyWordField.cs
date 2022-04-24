using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Base.LuceneUtils
{
    public class KeyWordField
    {
        public KeyWordField(string fieldname,string keyword)
        {
            WordValue = keyword;
            FieldName = fieldname;
        }
        public string WordValue { get; set; }
        public string FieldName { get; set; }
        //public bool IsSplitWord { get; set; }
    }
}
