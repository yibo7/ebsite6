using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    [Serializable]
    public class TagColorInfo : XmlEntityBase<Guid>
    {
        /// <summary>
        /// 颜色名称
        /// </summary>
        public string ColorName { get; set; }
        /// <summary>
        /// 最多允许出现次数
        /// </summary>
        public int MaxShowNum { get; set; }

    }
}
