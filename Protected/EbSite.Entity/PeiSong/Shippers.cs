using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
 
    /// <summary>
    /// 发货人信息
    /// </summary>
    [Serializable]
    public class Shippers : XmlEntityBase<int>
    {
        /// <summary>
        /// 默认发货信息
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// 发货点
        /// </summary>
        public string ShipperTag { get; set; }
        /// <summary>
        /// 发货人姓名
        /// </summary>
        public string ShipperName { get; set; }
        /// <summary>
        /// 发货地区
        /// </summary>
        public int RegionId { get; set; }

        /// <summary>
        /// 发货详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string CellPhone { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string TelPhone { get; set; }

        /// <summary>
        /// 邮编 
        /// </summary>
        public string Zipcode { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 网店名称
        /// </summary>
        public string ShopName { get; set; }
    }

    
}
