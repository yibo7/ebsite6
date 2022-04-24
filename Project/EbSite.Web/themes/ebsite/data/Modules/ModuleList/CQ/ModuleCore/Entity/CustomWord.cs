using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.Entity
{
    public class CustomWord : XmlEntityBase<int>
    {
        /// <summary>
        /// 常用语
        /// </summary>
        public string CommonlyInfo { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
      //  public int  UserId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OpDate { get; set; }
        /// <summary>
        /// 排序ID
        /// </summary>
        public int OrderID { get; set; }
      
    }
}