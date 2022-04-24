using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    /// <summary>
    /// 实体类Website 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class FastMenuClass : XmlEntityBase<int>
    {
       
        public string ClassName { get; set; }
      
        public string AddTime { get; set; }
      


    }

}
