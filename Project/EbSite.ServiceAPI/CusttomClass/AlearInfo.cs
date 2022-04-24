using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.ServiceAPI.CusttomClass
{
    public class TreeItem
    {
        public TreeItem()
        {
            
        }
        public TreeItem(int _id, string _Name, int _Lavel)
        {
            this.id = _id;
            this.Name = _Name;
            this.Level = _Lavel;
        }
        public int id { get; set; }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排序ID
        /// </summary>
        public int OrderID { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public int HeadID { get; set; }
        /// <summary>
        /// 深度
        /// </summary>
        public int Level { get; set; }
    }
}
