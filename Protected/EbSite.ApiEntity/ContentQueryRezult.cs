using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbSite.ApiEntity
{
    [Serializable]
    public class ContentQueryRezult
    {
        private int _Count = 0;

        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }

        private List<ApiEntity.Content> _Data;
        public List<ApiEntity.Content> Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

    }
     
}
