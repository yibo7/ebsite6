using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Entity
{
    [Serializable]
    public class ContentPageInfo
    {
        public string Title { get; set; }
        public string Href { get; set; }
        /// <summary>
        /// 只供分页模式用，描点模式不用不使用,是否当前页
        /// </summary>
        /// <value><c>true</c> if this instance is current; otherwise, <c>false</c>.</value>
        public bool IsCurrent { get; set; }
        //public string Content { get; set; }
    }
}
