using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.Entity
{
    [Serializable]
    public class ServiceClass : XmlEntityBase<int>
    {
        public string Title{ get; set;}
        public string Info { get; set; }
        public int OrderID{get;set;}
        
    }
}