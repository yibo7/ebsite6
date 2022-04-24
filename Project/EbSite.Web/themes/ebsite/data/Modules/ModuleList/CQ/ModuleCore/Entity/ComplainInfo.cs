using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.Entity
{
    public class ComplainInfo : XmlEntityBase<int>
    {

        /// <summary>
        /// 客服名称
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 客服ID
        /// </summary>
        public int ServiceID { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OpDateTime { get; set; }

        /// <summary>
        /// 投诉或建意内容
        /// </summary>
        public string Ctent { get; set; }
        /// <summary>
        /// 投诉 1 建意 2
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 投诉 1 建意 2
        /// </summary>
        public string TypeName { get; set; }
    }
}