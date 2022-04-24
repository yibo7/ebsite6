using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
 
    /// <summary>
    /// 运费模板
    /// </summary>
    [Serializable]
    public class Express : XmlEntityBase<int>
    {
        /// <summary>
        /// 快递名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 背景图片
        /// </summary>
        public string BackGround { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public int BackGroundWidth { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public int BackGroundHeight { get; set; }

        /// <summary>
        /// 内容 坐标
        /// </summary>
        public string ItemContent { get; set; }

        /// <summary>
        /// 是否 开启
        /// </summary>
        public bool IsAct { get; set; }
    }

    
}
