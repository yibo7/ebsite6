using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.BLL.IISLOG
{
    public class IISLOGEntity : XmlEntityBase<int>
    {
        public string LogName { get; set; }
        public DateTime AddDateTime { get; set; }
        public string CountInfo { get; set; }
        public long Size { get; set; }//这里是mb
    }
}
