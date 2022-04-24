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
    public class ErrInfo : XmlEntityBase<int>
    {
        /// <summary>
        /// 错误标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }
        /// <summary>
        /// 发生错误的次数
        /// </summary>
        public int ErrCount { get; set; }
        /// <summary>
        /// 是否可以删除
        /// </summary>
        public bool IsSys { get; set; }

    }

}
