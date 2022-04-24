using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.Ajaxget.AjaxHelp
{
    public class NormPriceInfo
    {
        /// <summary>
        /// 货号
        /// </summary>
        public string PNumber{set; get;}
        /// <summary>
        /// 库存量
        /// </summary>
        public int Stocks { set; get; }
        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal SalePrice { set; get; }
        /// <summary>
        /// 成本价格
        /// </summary>
        public decimal CostPrice { set; get; }
        /// <summary>
        /// 市场价格
        /// </summary>
        public decimal MarketPrice { set; get; }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal Weight { set; get; }
    }
}