using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    /// <summary>
    /// 实体类Website 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class UserLevel : XmlEntityBase<int>
    {
        /// <summary>
        /// 级别ID
        /// </summary>
        public int LevelId { get; set; }

        /// <summary>
        /// 等级名称
        /// </summary>
        public string LevelName { get; set; }
        /// <summary>
        /// 代表图片
        /// </summary>
        public string ImgPath { get; set; }
        /// <summary>
        /// 最小积分
        /// </summary>
        public int MinCredit { get; set; }
        /// <summary>
        /// 最高积分
        /// </summary>
        public int MaxCredit { get; set; }
      

    }

}
