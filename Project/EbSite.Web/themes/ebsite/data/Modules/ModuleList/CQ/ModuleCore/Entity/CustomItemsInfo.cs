using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.Entity
{
    public class CustomItemsInfo : XmlEntityBase<int>
    {
        /// <summary>
        /// 客服名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 客服ID
        /// </summary>
        public int ParentID { get; set; }

        public int OrderID { get; set; }
        
    }
}