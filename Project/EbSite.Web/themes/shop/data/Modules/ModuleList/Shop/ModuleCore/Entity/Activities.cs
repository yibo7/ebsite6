using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.ModuleCore.Entity
{
    public class Activities
    {
        
       public int ID{ get; set;}
       public string NewsTitle{ get; set;}
       public string SmallPic { get; set; }
       public decimal MarketPrice { get; set; }
       public decimal Price { get; set; }
       public string ActName { get; set; }
       public int ActID{ get; set;}
       public int ClassID { get; set; }
    }
}