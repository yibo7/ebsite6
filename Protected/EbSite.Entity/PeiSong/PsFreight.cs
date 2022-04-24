using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
 
    /// <summary>
    /// 运费模板
    /// </summary>
    [Serializable]
    public class PsFreight : XmlEntityBase<int>
    {
        /// <summary>
        /// 运费模板名称
        /// </summary>
        public string TemplateName { get; set; }
        /// <summary>
        /// 起步重量
        /// </summary>
        public int StartWeight { get; set; }
        /// <summary>
        /// 加价重量
        /// </summary>
        public int AddWeight { get; set; }
        /// <summary>
        /// 默认起步价
        /// </summary>
        public decimal StartPrice { get; set; }

        /// <summary>
        /// 默认加价
        /// </summary>
        public decimal AddPrice { get; set; }

       
    }

    [Serializable]
    public class PsAreaPrice : XmlEntityBase<int>
    {
        public PsAreaPrice()
        { }
        /// <summary>
        /// 目的地
        /// </summary>
       
        public string Region { get; set; }
        /// <summary>
        /// 起步价
        /// </summary>
        public decimal RegionPrice { get; set; }
        /// <summary>
        /// 加价
        /// </summary>
        public decimal AddRegionPrice { get; set; }

        /// <summary>
        /// 父类ID
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 满多少免运费
        /// </summary>
        public decimal FullMoney { get; set; }
        /// <summary>
        /// 目的地ID
        /// </summary>
        public string RegionIDS { get; set; }
    }
}
