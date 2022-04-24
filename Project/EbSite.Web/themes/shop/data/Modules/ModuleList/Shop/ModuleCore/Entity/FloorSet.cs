using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.Shop.ModuleCore.Entity
{
    #region 楼层设置
    [Serializable]
    public class FloorSet : XmlEntityBase<int>
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
    }
    #endregion

    #region 设置楼层分类
    /// <summary>
    /// 设置楼层分类 一对多
    /// </summary>
      [Serializable]
    public class FloorBigClass : XmlEntityBase<int>
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

        /// <summary>
        /// 大分类id
        /// </summary>
        public string BigClsssId { get; set; }

       
    }
    #endregion

    #region 设置楼层子分类
    /// <summary>
    /// 设置楼层子分类 一对多
    /// </summary>
      [Serializable]
    public class FloorSmallClass : XmlEntityBase<int>
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

        /// <summary>
        /// 子分类id
        /// </summary>
        public string SmallClsssId { get; set; }


    }
    #endregion

    #region 设置楼层左侧广告商品
    /// <summary>
    /// 设置楼层左侧广告商品 一对多
    /// </summary>
      [Serializable]
    public class FloorLeftAd : XmlEntityBase<int>
    {
        /// <summary>
        /// 楼层ID
        /// </summary>
        public int FloorSetId { get; set; }
        /// <summary>
        /// 广告标题
        /// </summary>
        public string AdTitle { get; set; }
        /// <summary>
        /// 广告链接路径
        /// </summary>
        public string AdUrl { get; set; }

        /// <summary>
        /// 广告图片路径
        /// </summary>
        public string AdPicUrl { get; set; }


    }
    #endregion

    #region 设置楼层商品列表
    /// <summary>
    /// 设置楼层商品列表 一对一 ，用逗号分开
    /// </summary>
      [Serializable]
    public class FloorProducts : XmlEntityBase<int>
    {
        /// <summary>
        /// 楼层ID
        /// </summary>
        public int FloorSetId { get; set; }
        /// <summary>
        /// 选择产品的ID
        /// </summary>
        public string ProductIds { get; set; }


    }
    #endregion

    #region 设置楼层品牌列表
   /// <summary>
    /// 设置楼层品牌列表  一对多
   /// </summary>
    [Serializable]
    public class FloorRightBrand : XmlEntityBase<int>
    {
        /// <summary>
        /// 楼层ID
        /// </summary>
        public int FloorSetId { get; set; }
        /// <summary>
        /// 品牌标题
        /// </summary>
        public string BrandTitle { get; set; }
        /// <summary>
        /// 品牌链接路径
        /// </summary>
        public string BrandUrl { get; set; }

        /// <summary>
        /// 品牌图片路径
        /// </summary>
        public string BrandPicUrl { get; set; }


    }
   

    #endregion

    #region 设置广告链接
    /// <summary>
    /// 设置右下角广告链接 一对多
    /// </summary>
      [Serializable]
    public class FloorRightAd : XmlEntityBase<int>
    {
        /// <summary>
        /// 楼层ID
        /// </summary>
        public int FloorSetId { get; set; }
        /// <summary>
        /// 品牌标题
        /// </summary>
        public string AdTitle { get; set; }
        /// <summary>
        /// 品牌链接路径
        /// </summary>
        public string AdUrl { get; set; }
    }
    #endregion



}