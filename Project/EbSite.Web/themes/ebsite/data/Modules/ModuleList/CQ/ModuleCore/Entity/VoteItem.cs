using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.Entity
{
    [Serializable]
    public class VoteItemInfo : XmlEntityBase<Guid>
    {
        /// <summary>
        /// 所属投票ID
        /// </summary>
        public Guid VoteID { get; set; }
        /// <summary>
        /// 选择名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 选择次数
        /// </summary>
        public int PostCount { get; set; }
    }
    /// <summary>
    /// 一个投票选项
    /// </summary>
    public class VoteItem : VoteItemInfo
    {
        /// <summary>
        /// 投票总数
        /// </summary>
        private int _iAllPostCount = 0;
        /// <summary>
        /// 进度基数
        /// </summary>
        private int _CSSWidthBase = 200;
        public VoteItem(int AllCount,int CSSWidthBase)
        {
            _iAllPostCount = AllCount;
            _CSSWidthBase = CSSWidthBase;
        }
        /// <summary>
        /// 得到相对进度基数对应的宽度
        /// </summary>
        public int ItemWidth 
        { 
            get
            {
                int width = _iAllPostCount != 0 ? (int)Math.Ceiling(_CSSWidthBase * Convert.ToDouble(PostCount) / Convert.ToDouble(_iAllPostCount)) : 0;
                return width;
            } 
        
        }
       /// <summary>
       /// 当前选项占所有选项的百分比
       /// </summary>
        public string Percent 
        { 
            get
            {
                string spc = "0%";
                if (_iAllPostCount > 0)
                {
                    spc = Convert.ToDouble(PostCount / Convert.ToDouble(_iAllPostCount)).ToString("##.##%");
                }
                return spc;
            }
        }
    }
}