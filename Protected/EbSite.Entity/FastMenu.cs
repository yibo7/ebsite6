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
    public class FastMenu : XmlEntityBase<int>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
     
        public int Target { get; set; }
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public string ImageUrl { get; set; }

        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public int RoleId { get; set; }


    }

}
