using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    /// <summary>
    /// 配件公司
    /// </summary>
   [Serializable]
    public class PsCompany : XmlEntityBase<int>
    {
        /// <summary>
        /// 配送公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 快递100Code
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// 物流公司网址
        /// </summary>
        public string CompanyUrl { get; set; }
        /// <summary>
        /// 订单查询网址
        /// </summary>
        public string OrderQueryUrl { get; set; }
    }
}
