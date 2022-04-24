using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.Entity
{
    [Serializable]
    public class VoteInfo : XmlEntityBase<Guid>
    {
        public string Title{ get; set;}
        public int MaxSelNum { get; set; }
        public bool IsMoreSel { get; set; }
    }
}