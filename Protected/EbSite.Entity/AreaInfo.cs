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
    public class AreaInfo : XmlEntityBase<int>
    {
        
        /// <summary>
        /// 地区名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排序ID
        /// </summary>
        public int OrderID { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public int HeadID { get; set; }
        /// <summary>
        /// 深度
        /// </summary>
        public int Level { get; set; }

    }
}
