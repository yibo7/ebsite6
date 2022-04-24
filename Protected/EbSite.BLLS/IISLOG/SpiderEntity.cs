using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.BLL.IISLOG
{
    public class SpiderEntity : XmlEntityBase<int>
    {
        public string SpiderCnName { get; set; }
        public string SpiderEnName { get; set; }
        public int SpiderCount { get; set; }
    }
}
