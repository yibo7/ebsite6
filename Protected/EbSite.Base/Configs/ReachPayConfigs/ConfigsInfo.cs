using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Base.Configs.ConfigsBase;

namespace EbSite.Base.Configs.ReachPayConfigs
{
    public class ConfigsInfo : IConfigInfo
    {
        /// <summary>
        /// 是否支持货到付款
        /// </summary>
        public bool IsCod { get; set; }
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
