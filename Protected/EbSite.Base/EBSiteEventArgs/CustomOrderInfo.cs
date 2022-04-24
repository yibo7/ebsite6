using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Base.EBSiteEventArgs
{
    public class CustomOrderInfo : XmlEntityBase<int>
    {
        /// <summary>
        /// 步骤ID
        /// </summary>
        public string StepsID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int ClassID { get; set; }
        /// <summary>
        /// 客服名称
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 客服ID
        /// </summary>
        public int ServiceID { get; set; }
        /// <summary>
        ///分类标记
        /// </summary>
        public Guid TimeStamp { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OpDateTime { get; set; }
        /// <summary>
        /// 定单号
        /// </summary>
        public string OrderNum { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 对应主站 北迈模块Order表的字段 
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// IP 地址
        /// </summary>
        public string Ip { get; set; }

    }
}
