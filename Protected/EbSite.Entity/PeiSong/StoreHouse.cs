using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    [Serializable]
    public class StoreHouse : XmlEntityBase<Guid>
    {
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string StoreHouseName { get; set; }
        /// <summary>
        /// 发货区域的ID，多个用逗号分开 华东，华北，西北
        /// </summary>
        public string SendAreaIDs { get; set; }
    }
}
