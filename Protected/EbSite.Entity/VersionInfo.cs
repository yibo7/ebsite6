using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Entity
{
    [Serializable]
    public class VersionInfo
    {
        public bool IsUpdate { get; set; }
        public string Version{ get; set;}
        public string WebUrl { get; set; }
        public string PathUrl { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
