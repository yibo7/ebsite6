using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    [Serializable]
    public class ContentTem : XmlEntityBase<Guid>
    {
        public string Title { get; set; }
        //public string ListTemPath { get; set; }
        //public string HeaderTemPath { get; set; }
        public DateTime AddDate { get; set; }
    }
}
