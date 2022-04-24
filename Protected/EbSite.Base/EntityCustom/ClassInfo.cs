
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Base.EntityCustom
{
    [Serializable]
    public class ClassInfo
    {
        public ClassInfo()
        {

        }
        public ClassInfo(int _id, string _Name)
        {
            this.id = _id;
            this.Name = _Name;

        }
        public int id { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

    }
}
