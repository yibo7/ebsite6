using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.Entity
{
    [Serializable]
    public class OrderBoxInfo : XmlEntityBase<int>
    {
        /// <summary>
        /// 步骤名称
        /// </summary>
        public string Title{ get; set;}
        /// <summary>
        /// 提示语
        /// </summary>
        public string Tips { get; set; }
        /// <summary>
        /// 选项列表,如果DefaultParentClassID大于0将不使用设置
        /// </summary>
        public string Items { get; set; }
        /// <summary>
        /// 这个可以与ebsite的分类关联，设计此大于0,那么，将此值为父id请求其下的子分类，如果不是每一步，值可以源与上级选择项值
        /// </summary>
        public string DefaultParentClassID { get; set; }
        /// <summary>
        /// 排序ID
        /// </summary>
        public int OrderID { get; set; }
         /// <summary>
        /// 步骤类型
        /// </summary>
        public int StepType { get; set; }

        /// <summary>
        /// 选择提示
        /// </summary>
        public string Seltip { get; set; }
        /// <summary>
        /// 用户话语
        /// </summary>
        public string Utem { get; set; }

        /// <summary>
        /// 验证规则  0：不验证 1：手机验证
        /// </summary>
        public int ValidationRule{ get; set;}

        /// <summary>
        /// 文本输入是否允许为空  0：不允许 1：允许
        /// </summary>
        public int IsNullText { get; set; }
        /// <summary>
        /// 下拉数据表
        /// </summary>
        public int SoureTable { get; set; }
        /// <summary>
        /// 对应主站 北迈模块Order表的字段 
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 在此步骤的跳出率
        /// </summary>
        public int CloseNum { get; set; }
    }
}