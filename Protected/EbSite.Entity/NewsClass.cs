using System;
using System.Collections.Specialized;
using EbSite.BLL.ModelBll;

namespace EbSite.Entity
{
    /// <summary>
    /// 实体类NewsClass 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class NewsClass : ModelEntityBase
    {
        public NewsClass()
        { }
        #region Model
        private int _id;
        private string _classname;
        private int _orderid;
        private int _parentid;
        private string _htmlname;
      
        private string _info;
        private string _titlestyle;

        //private string _contenthtmlname;
        //private string _classhtmlnamerule;

        private string _seotitle;
        private string _seokeyword;
        private string _seodescription;
        private string _outlike;
        //private bool _iscanaddcontent;
        private Guid _ContentModelID;
        private int _UserCanAddNum;

        private bool _isallowdelete;
        private bool _isallowmodify;
        private bool _isauditingcontent;

        private string _annex1;
        private string _annex2;
        private string _annex3;
        private string _annex4;
        private string _annex5;
        private string _annex6;
        private string _annex7;
        private string _annex8;
        private string _annex9;
        private string _annex10;


        private int _annex11;
        private int _annex12;
        private int _annex13;
        private int _annex14;
        private float _annex15;

        private int _annex16;
        private int _annex17;
        //private string _subclassaddname;
        //private Guid _subclasstemid;
        //private Guid _subclassmodelid;

        //private Guid _listtemid;

        private int _dayhits;
        private int _weekhits;
        private int _monthhits;
        private DateTime _lasthitstime = DateTime.Now;
        private int _hits;

        private int _commentnum;
        private int _favorablenum;

        //private Guid _subdefaultcontentmodelid;
        //private Guid _subdefaultcontenttemid;
        //private bool _subiscanaddsub;
        //private bool _subiscanaddcontent;
        //private bool _iscanaddsub;

        private int _userid;
        private string _username;
        private string _userniname;
        private DateTime? _addtime = DateTime.Now;
        //private int _pagesize;
        private int _siteid;
        public int SubClassNum { get; set; }
        //private Guid _contenttemid;
        //private Guid _classtemid;
        //private Guid _ClassModelID;

        private int _randnum;
        private string _parentids;
        /// <summary>
        /// 随机数
        /// </summary>
        public int RandNum
        {
            get { return _randnum; }
            set { _randnum = value; }
        }
        private int _numbertime=Core.SqlDateTimeInt.GetSecond(DateTime.Now);
        /// <summary>
        /// 时间
        /// </summary>
         public int NumberTime
        {
            get { return _numbertime; }
            set { _numbertime = value; }
        }
        
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
        /// 主要配合模块使用，让模块更加容易创建具有分类与内容的数据,选择了模块后将搜索模块下的分类模型与内容模型
        /// </summary>
        //public Guid ModuleID { get; set; }
        /// <summary>
        /// 主要配合个主网站使用，让内容引用发布人所属空间的皮肤
        /// </summary>
        public bool IsUserTheme { get; set; }

        public bool IsAuditing { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserNiName
        {
            set { _userniname = value; }
            get { return _userniname; }
        }

        ///// <summary>
        ///// 当前分类的分类模型
        ///// </summary>
        //public Guid ClassModelID
        //{
        //    set { _ClassModelID = value; }
        //    get { return _ClassModelID; }
        //}
        ///// <summary>
        ///// 子分类默认使用内容模型ID
        ///// </summary>
        //public Guid SubDefaultContentModelID
        //{
        //    set { _subdefaultcontentmodelid = value; }
        //    get { return _subdefaultcontentmodelid; }
        //}
        ///// <summary>
        ///// 子分类默认使用内容模板
        ///// </summary>
        //public Guid SubDefaultContentTemID
        //{
        //    set { _subdefaultcontenttemid = value; }
        //    get { return _subdefaultcontenttemid; }
        //}
        ///// <summary>
        ///// 子分类是否可以再添加子分类，主要是为了方便总体设置用
        ///// </summary>
        //public bool SubIsCanAddSub
        //{
        //    set { _subiscanaddsub = value; }
        //    get { return _subiscanaddsub; }
        //}
        ///// <summary>
        ///// 子类是否可以添加内容
        ///// </summary>
        //public bool SubIsCanAddContent
        //{
        //    set { _subiscanaddcontent = value; }
        //    get { return _subiscanaddcontent; }
        //}
        ///// <summary>
        ///// 当前分类是否可以添加内容
        ///// </summary>
        //public bool IsCanAddSub
        //{
        //    set { _iscanaddsub = value; }
        //    get { return _iscanaddsub; }
        //}

        /// <summary>
        /// 
        /// </summary>
        public int dayHits
        {
            set { _dayhits = value; }
            get { return _dayhits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int weekHits
        {
            set { _weekhits = value; }
            get { return _weekhits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int monthhits
        {
            set { _monthhits = value; }
            get { return _monthhits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime lasthitstime
        {
            set { _lasthitstime = value; }
            get { return _lasthitstime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int hits
        {
            set { _hits = value; }
            get { return _hits; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Annex4
        {
            set { _annex4 = value; }
            get { return _annex4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex5
        {
            set { _annex5 = value; }
            get { return _annex5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex6
        {
            set { _annex6 = value; }
            get { return _annex6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex7
        {
            set { _annex7 = value; }
            get { return _annex7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex8
        {
            set { _annex8 = value; }
            get { return _annex8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex9
        {
            set { _annex9 = value; }
            get { return _annex9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex10
        {
            set { _annex10 = value; }
            get { return _annex10; }
        }


        public int Annex11
        {
            set { _annex11 = value; }
            get { return _annex11; }

        }
        public int Annex12
        {
            set { _annex12 = value; }
            get { return _annex12; }

        }
        public int Annex13
        {
            set { _annex13 = value; }
            get { return _annex13; }

        }
        public int Annex14
        {
            set { _annex14 = value; }
            get { return _annex14; }

        }
        public float Annex15
        {
            set { _annex15 = value; }
            get { return _annex15; }

        }

        public int Annex16
        {
            set { _annex16 = value; }
            get { return _annex16; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Annex17
        {
            set { _annex17 = value; }
            get { return _annex17; }
        }


        ///// <summary>
        ///// 
        ///// </summary>
        //public string SubClassAddName
        //{
        //    set { _subclassaddname = value; }
        //    get { return _subclassaddname; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public Guid SubClassTemID
        //{
        //    set { _subclasstemid = value; }
        //    get { return _subclasstemid; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public Guid SubClassModelID
        //{
        //    set { _subclassmodelid = value; }
        //    get { return _subclassmodelid; }
        //}
        /// <summary>
        /// 当前组下，用户添加的内容是否要通过审核后才能显示出，只应用在用户组设置里
        /// </summary>
        public bool isauditingcontent
        {
            set
            {
                _isauditingcontent = value;
            }
            get { return _isauditingcontent; }
        }

        /// <summary>
        /// 是否允许删除内容，只应用在用户组设置里
        /// </summary>
        public bool IsAllowDelete
        {
            set
            {
                _isallowdelete = value;
            }
            get { return _isallowdelete; }
        }
        /// <summary>
        /// 是否允许修改内容，只应用在用户组设置里
        /// </summary>
        public bool IsAllowModify
        {
            set
            {
                _isallowmodify = value;
            }
            get { return _isallowmodify; }
        }
        /// <summary>
        /// 用户可以添加的数量，只应用在用户组设置里
        /// </summary>
        public int UserCanAddNum
        {
            set { _UserCanAddNum = value; }
            get { return _UserCanAddNum; }
        }
        ///// <summary>
        ///// 歌手分类ID
        ///// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 歌手分类名称
        /// </summary>
        public string ClassName
        {
            set { _classname = value; }
            get { return _classname; }
        }
        /// <summary>
        /// 歌手分类排序ID
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HtmlName
        {
            set { _htmlname = value; }
            get { return _htmlname; }
        }
        ///// <summary>
        ///// 
        ///// </summary>
        //public Guid ContentTemID
        //{
        //    set { _contenttemid = value; }
        //    get { return _contenttemid; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public Guid ClassTemID
        //{
        //    set { _classtemid = value; }
        //    get { return _classtemid; }
        //}
        /// <summary>
        /// 
        /// </summary>
        public string Info
        {
            set { _info = value; }
            get { return _info; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TitleStyle
        {
            set { _titlestyle = value; }
            get { return _titlestyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex1
        {
            set { _annex1 = value; }
            get { return _annex1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex2
        {
            set { _annex2 = value; }
            get { return _annex2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex3
        {
            set { _annex3 = value; }
            get { return _annex3; }
        }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string ContentHtmlName
        //{
        //    set { _contenthtmlname = value; }
        //    get { return _contenthtmlname; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string ClassHtmlNameRule
        //{
        //    set { _classhtmlnamerule = value; }
        //    get { return _classhtmlnamerule; }
        //}

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
        /// <summary>
        /// 
        /// </summary>
        public string OutLike
        {
            set { _outlike = value; }
            get { return _outlike; }
        }
        ///// <summary>
        ///// 
        ///// </summary>
        //public bool IsCanAddContent
        //{
        //    set { _iscanaddcontent = value; }
        //    get { return _iscanaddcontent; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public Guid ContentModelID
        //{
        //    set { _ContentModelID = value; }
        //    get { return _ContentModelID; }
        //}
        //public Guid ListTemID
        //{
        //    set { _listtemid = value; }
        //    get { return _listtemid; }
        //}
        /// <summary>
        /// 
        /// </summary>
        public int CommentNum
        {
            set { _commentnum = value; }
            get { return _commentnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FavorableNum
        {
            set { _favorablenum = value; }
            get { return _favorablenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime
        {
            set
            {
                _addtime = value;
            }
            get { return _addtime; }
        }
        ///// <summary>
        ///// 
        ///// </summary>
        //public int PageSize
        //{
        //    set
        //    {
        //        _pagesize = value;
        //    }
        //    get { return _pagesize; }
        //}
        /// <summary>
        /// 父级IDs
        /// </summary>
        public string ParentIDs
        {
            get { return _parentids; }
            set { _parentids = value; }
        }

        public bool IsHtmlNameReWrite { get; set; }

        public string ContentHtmlPath { get; set; }
        public bool IsHtmlNameReWriteContent { get; set; }
        #endregion Model



        private StringDictionary _CusttomFileds = new StringDictionary();
        public void AddCusttomFileds(string key, string Value)
        {
            _CusttomFileds.Add(key, Value);
        }
        public StringDictionary GetCusttomFileds()
        {
            return _CusttomFileds;
        }
        public StringDictionary Fileds
        {
            get
            {
                if (this.ID > 0)
                {
                    //这里以后用数据库实现
                    //CusttomFiledsBLL cfb = BLL.ModelBll.CusstomFileds.HrefFactory.GetInstance(this.ModuleID, ModelType.分类模型);

                    //CusttomFiledsBLL cfb = BLL.ModelBll.CusstomFileds.HrefFactory.GetInstance(Configs.ModuleID, ModelType.分类模型);
                    //_CusttomFileds = cfb.GetEntity(this.ID);
                    //_CusttomFileds = CusttomFiledsBLLClass.Instance.GetEntity(this.ID);
                }
                return _CusttomFileds;
            }
        }

        public Guid ClassTemID
        {
            get { return BLL.ClassConfigs.Instance.GetClassTemID(this.ID); }
        }
        public Guid ContentTemID
        {
            get { return BLL.ClassConfigs.Instance.GetContentTemID(this.ID); }
        }
        public Guid ClassTemIdMobile
        {
            get { return BLL.ClassConfigs.Instance.GetClassTemIDMobile(this.ID); }
        }
        public Guid ContentTemIdMobile
        {
            get { return BLL.ClassConfigs.Instance.GetContentTemIDMobile(this.ID); }
        }

        public Guid ClassModelID
        {
            get { return BLL.ClassConfigs.Instance.GetClassModelID(this.ID); }
        }
        public Guid ContentModelID
        {
            get { return BLL.ClassConfigs.Instance.GetContentModelID(this.ID); }
        }
        public string ContentHtmlName
        {
            get { return BLL.ClassConfigs.Instance.GetContentHtmlName(this.ID); }
        }
        public bool IsCanAddContent
        {
            get { return BLL.ClassConfigs.Instance.GetIsCanAddContent(this.ID); }
        }
        public Guid ModuleID
        {
            get { return BLL.ClassConfigs.Instance.GetModuleID(this.ID); }
        }
        public bool IsCanAddSub
        {
            get { return BLL.ClassConfigs.Instance.GetIsCanAddSub(this.ID); }
        }
        public Guid SubClassModelID
        {
            get { return BLL.ClassConfigs.Instance.GetSubClassModelID(this.ID); }
        }
        
        
        //public Entity.ClassConfigs Configs
        //{
        //    get
        //    {
        //        return BLL.ClassConfigs.Instance.GeClassConfigsByClassID(ID);
        //    }
        //}


    }
}

