using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.Shop.ModuleCore.Entity
{
    #region 楼层设置
    [Serializable]
    public class MFloorSet : XmlEntityBase<int>
    {
        /// <summary>
        /// 楼层ID
        /// </summary>
        public int FloorId { get; set; }
        /// <summary>
        /// 楼层名字
        /// </summary>
        public string  FloorName { get; set; }
        /// <summary>
        /// 楼层颜色
        /// </summary>
        public string FloorColor { get; set; }

        /// <summary>
        /// 楼层超连接
        /// </summary>
        public string FloorUrl { get; set; }

        /// <summary>
        /// 广告图片
        /// </summary>
        public string AdUrl { get; set; }
        /// <summary>
        /// 广告标题
        /// </summary>
        public string AdName { get; set; }
        /// <summary>
        /// 广告超连接
        /// </summary>
        public string AdPicUrl { get; set; }
    }
    #endregion

    #region 设置楼层分类
    /// <summary>
    /// 设置楼层分类 一对3条
    /// </summary>
      [Serializable]
    public class MFloorBigClass : XmlEntityBase<int>
    {
        /// <summary>
        /// 楼层ID
        /// </summary>
        public int FloorSetId { get; set; }
        /// <summary>
        /// 大分类名字
        /// </summary>
        public string BigClassName { get; set; }
        /// <summary>
        /// 大分类链接路径
        /// </summary>
        public string BigClassUrl { get; set; }

       

       
    }
    #endregion

    #region 设置楼层子分类
    /// <summary>
    /// 设置楼层子分类 一对4
    /// </summary>
      [Serializable]
      public class MFloorSmallClass : XmlEntityBase<int>
    {
        /// <summary>
        /// 楼层ID
        /// </summary>
        public int FloorSetId { get; set; }
        /// <summary>
        /// 子分类名字
        /// </summary>
        public string SmallClassName { get; set; }
        /// <summary>
        /// 子分类链接路径
        /// </summary>
        public string SmallClassUrl { get; set; }

       


    }
    #endregion


    #region 手机版 切换图片
      /// <summary>
      /// 
      /// </summary>
      [Serializable]
      public class MFlash : XmlEntityBase<int>
      {
         
          public string PicUrl { get; set; }
          
          public string Name { get; set; }
         
          public string Url { get; set; }
      }
    #endregion

}