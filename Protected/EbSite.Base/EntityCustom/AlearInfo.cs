using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Base.EntityCustom
{
    //[Serializable] 添加这个在web api里的json中会返回 __BackingField 类型
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
        public TreeItem(int _id, string _Name, int _Lavel, string _OrtherPram)
        {
            this.id = _id;
            this.Name = _Name;
            this.Level = _Lavel;
            this.OrtherPram = _OrtherPram;
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

        public string OrtherPram { get; set; }
    }
}
