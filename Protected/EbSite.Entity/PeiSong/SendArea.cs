using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    /// <summary>
    /// 发货区域
    /// </summary>
    [Serializable]
    public class SendArea : XmlEntityBase<int>
    {
        /// <summary>
        /// 区域名称,如 华东，华北，西北
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 区域包含的城市ID，多个用逗号分开
        /// </summary>
        public string CityIDs { get; set; }
        public string CityNames { get; set; }
    }
}
