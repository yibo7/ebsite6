using System;
namespace EbSite.Entity
{
    /// <summary>
    /// 实体类SpecialClass 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SpecialClass
    {
        public SpecialClass()
        { }
        #region Model
        private int _id;
        private string _specialname;
        private int _orderid;
        private string _titletype;
        private string _outlink;
        private string _htmlname;
        private string _classhtmlnamerule;
        private Guid _specialtemid;
        private string _seotitle;
        private string _seokeyword;
        private string _seodescription;
        private int _ParentID= 0;
        private string _relateclassids;
        private int _siteid;
        private Guid _specialtemidmobile;
        public int SubClassNum { get; set; }
        /// <summary>
        /// 是否自定义重写地址
        /// </summary>
        public bool IsCusttomRw { get; set; }
        public int SiteID
        {
            get
            {
                return _siteid;
            }
            set
            {
                _siteid = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ParentID
        {
            set { _ParentID = value; }
            get { return _ParentID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SeoTitle
        {
            set { _seotitle = value; }
            get { return _seotitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SeoKeyWord
        {
            set { _seokeyword = value; }
            get { return _seokeyword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SeoDescription
        {
            set { _seodescription = value; }
            get { return _seodescription; }
        }
        public Guid SpecialTemID
        {
            set { _specialtemid = value; }
            get { return _specialtemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HtmlName
        {
            set { _htmlname = value; }
            get { return _htmlname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassHtmlNameRule
        {
            set { _classhtmlnamerule = value; }
            get { return _classhtmlnamerule; }
        }
        /// <summary>
        /// 家族分类ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 家族分类名称
        /// </summary>
        public string SpecialName
        {
            set { _specialname = value; }
            get { return _specialname; }
        }
        /// <summary>
        /// 家族排序ID
        /// </summary>
        public int Orderid
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 标题样式
        /// </summary>
        public string Titletype
        {
            set { _titletype = value; }
            get { return _titletype; }
        }
        /// <summary>
        /// 外部连接
        /// </summary>
        public string Outlink
        {
            set { _outlink = value; }
            get { return _outlink; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RelateClassIDs
        {
            set
            {
                _relateclassids = value;
            }
            get
            {
                return _relateclassids;
            }
        }
        /// <summary>
        /// 手机专题模板
        /// </summary>
        public Guid SpecialTemIDMobile
        {
            set { _specialtemidmobile = value; }
            get { return _specialtemidmobile; }
        }

        public string Info { get; set; }
        #endregion Model

    }
}

