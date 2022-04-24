using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    /// <summary>
    /// 支付方式分类
    /// </summary>
   [Serializable]
    public class PayTypeInfo:XmlEntityBase<int>
    {

        /// <summary>
        /// 父级站点ID
        /// </summary>
        private int _ParentID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        private string _Name { get; set; }
        public string Demo { get; set; }

        public int OrderID { get; set; }

        /// <summary>
        /// 父级站点ID
        /// </summary>
        public int ParentID
        {
            get
            {
                return _ParentID;
            }
            set
            {
                _ParentID = value;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

       
    }
}
