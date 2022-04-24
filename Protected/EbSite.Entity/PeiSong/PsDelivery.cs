using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    /// <summary>
    /// 配送方式
    /// </summary>
    [Serializable]
    public class PsDelivery : XmlEntityBase<int>
    {
        /// <summary>
        /// 配送名称
        /// </summary>
        public string ModeName { get; set; }
        /// <summary>
        /// 配送公司
        /// </summary>
        public string PsCompanyIds { get; set; }
        /// <summary>
        /// 运费模板
        /// </summary>
        public int ShippingTemplatesId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否支持货到付款
        /// </summary>
        public bool IsCod { get; set; }
        /// <summary>
        /// 支持物流公司
        /// </summary>
        public string PsCompanys
        { 
            get
            {
                return EbSite.BLL.PsCompany.Instance.GetNamesByIDs(PsCompanyIds);
            } 
        }

        /// <summary>
        /// 是否百分比
        /// </summary>
        public bool IsPercent { get; set; }

        /// <summary>
		/// 支付手续费(正数)，或免除费用（负数）
		/// </summary>
        public decimal UseMoney { get; set; }
    }
}
