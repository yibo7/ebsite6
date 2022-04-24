using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.Entity
{
    [Serializable]
    public class BarcodeInfo : XmlEntityBase<Guid>
    {
        public string Title{ get; set;}
        public string BarcodeContent { get; set; }
        public int LenSize { get; set; }
        public string SavePath { get; set; }
    }
}