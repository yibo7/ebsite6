using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.ModuleCore.BLL.GRShow
{
    abstract public class IBase
    {
        public abstract void AutoSetGroupStaus();
        public abstract GRShowModel GetEntity(int id);
    }


    public class GRShowModel
    {
        public int id { get; set; }
        
        public string Title { get; set; }

        public int ProductID { get; set; }

        public DateTime EndDate { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal Price { get; set; }

        public int Status { get; set; }

        public int BuyCount { get; set; }
        /// <summary>
        /// 已经购买的人数
        /// </summary>
        public int Buyed { get; set; }

        public string Content { get; set; }

    }

}