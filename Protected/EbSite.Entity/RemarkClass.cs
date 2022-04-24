using System;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
	/// <summary>
	/// 实体类RemarkClass 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public class RemarkClass : XmlEntityBase<int>
	{
		public RemarkClass()
		{}
        #region Model
        private int _itype=1;
        private int _ipage = 0;
        private string _classname;
        //private string _themes;
        private bool _issystem;
        //public string Themes
        //{
        //    set { _themes = value; }
        //    get { return _themes; }
        //}
        ///// <summary>
        ///// 评论类别，1为盖楼式评论,2为评价系统,3. 一问一答
        ///// </summary>
        public int Itype
        {
            set { _itype = value; }
            get { return _itype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassName
        {
            set { _classname = value; }
            get { return _classname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSystem
        {
            set { _issystem = value; }
            get { return _issystem; }
        }

        ///// <summary>
        ///// 页面 0：一问一答 （不用管）。1：代表分类页面 2 :代表内容页面 
        ///// 2014-3-5 目的 是 实现 分类 或 内容 的评价 总数 
        ///// </summary>
        public int IPage
        {
            set { _ipage = value; }
            get { return _ipage; }
        }
        #endregion Model

	}
}

