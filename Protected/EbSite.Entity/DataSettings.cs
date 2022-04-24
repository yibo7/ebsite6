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
    public class DataSettingInfo 
    {
        /// <summary>
        /// 所属站点ID
        /// </summary>
        public int SiteID { get; set; }
        /// <summary>
        /// 前台搜索时查询的字段
        /// </summary>
        public string SearchFileds { get; set; }
        /// <summary>
        /// 后台搜索时查询的字段
        /// </summary>
        public string AdminSearchFileds { get; set; }

    }
    [Serializable]
    public class DataSettingInfoForContent : DataSettingInfo
    {
        /// <summary>
        /// 前台搜索时查询的字段应用于部件
        /// </summary>
        public string SearchFileds_Widget { get; set; }
        /// <summary>
        /// 后台搜索时查询的字段 应用于部件 于搜索
        /// </summary>
        public string SearchFileds_So { get; set; }
        /// <summary>
        /// 应用于标签
        /// </summary>
        public string SearchFileds_Tagv { get; set; }
        /// <summary>
        /// 择NewsContent以外的分表作为 搜索和排行的数据源
        /// </summary>
        public string ContentTables { get; set; }


    }
    [Serializable]
    public class DataSettingInfoForClass : DataSettingInfo
    {
        /// <summary>
        /// 添加一级分类时默认模型ID
        /// </summary>
        //public string DefaultModelID { get; set; }


    }
}
