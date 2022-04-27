
using System;
using EbSite.Base.Configs.ConfigsBase;
using EbSite.Base.Entity;

namespace EbSite.Base.Configs.ContentSet
{
   
    public class ConfigsInfo : IConfigInfo
    {
        #region 站点地图
        private int _MapPl = 24;
        private int _MapSl = 80;
        public int MapPl
        {
            get
            {
                return _MapPl;
            }
            set
            {
                _MapPl = value;
            }
        }
        public int MapSl
        {
            get
            {
                return _MapSl;
            }
            set
            {
                _MapSl = value;
            }
        }
        #endregion

        #region 分页PageSize

        private int _PageSizeIndex;
        /// <summary>
        /// 首页一页默认显示多少条
        /// </summary>
        public int PageSizeIndex
        {
            get
            {
                return _PageSizeIndex;
            }
            set
            {
                _PageSizeIndex = value;
            }
        }

        private int _PageSizeClass;
        /// <summary>
        /// 分类面页一页显示多少条
        /// </summary>
        public int PageSizeClass
        {
            get
            {
                return _PageSizeClass;
            }
            set
            {
                _PageSizeClass = value;
            }
        }

        private int _PageSizeSpecail;
        /// <summary>
        /// 专题列表，每页列出多少条
        /// </summary>
        public int PageSizeSpecail
        {
            get
            {
                return _PageSizeSpecail;
            }
            set
            {
                _PageSizeSpecail = value;
            }
        }
        private int _PageSizeTagList;
        /// <summary>
        /// 标签列表，每页列出多少条
        /// </summary>
        public int PageSizeTagList
        {
            get
            {
                return _PageSizeTagList;
            }
            set
            {
                _PageSizeTagList = value;
            }
        }
        private int _PageSizeTagValue;
        /// <summary>
        /// 标签搜索结果列表，每页列出多少条
        /// </summary>
        public int PageSizeTagValue
        {
            get
            {
                return _PageSizeTagValue;
            }
            set
            {
                _PageSizeTagValue = value;
            }
        }
        #endregion

        #region 样式

        //private string _AdminStyle = "default";
        //private string _PageStyle = "default";
        //private string _MobileStyle = "default";
        ///// <summary>
        ///// 手机版
        ///// </summary>
        //public string MobileStyle
        //{
        //    get
        //    {
        //        return _MobileStyle;
        //    }
        //    set
        //    {
        //        _MobileStyle = value;
        //    }
        //}
        ///// <summary>
        ///// 后台样式
        ///// </summary>
        //public string AdminStyle
        //{
        //    get
        //    {
        //        return _AdminStyle;
        //    }
        //    set
        //    {
        //        _AdminStyle = value;
        //    }
        //}
        ///// <summary>
        ///// 前台样式
        ///// </summary>
        //public string PageStyle
        //{
        //    get
        //    {
        //        return _PageStyle;
        //    }
        //    set
        //    {
        //        _PageStyle = value;
        //    }
        //}

        #endregion

        private Guid _DefaultClassID;


        //#region seo

        //private string _SeoClassTitle;
        //private string _SeoClassKeyWord;
        //private string _SeoClassDes;

        //private string _SeoSpecialTitle;
        //private string _SeoSpecialKeyWord;
        //private string _SeoSpecialDes;

        //private string _SeoContentTitle;
        //private string _SeoContentKeyWord;
        //private string _SeoContentDes;

        //private string _SeoTagIndexTitle;
        //private string _SeoTagIndexKeyWord;
        //private string _SeoTagIndexDes;

        //private string _SeoTagListTitle;
        //private string _SeoTagListKeyWord;
        //private string _SeoTagListDes;


        //private string _SeoSiteIndexTitle;
        //private string _SeoSiteIndexKeyWord;
        //private string _SeoSiteIndexDes;


        ///// <summary>
        ///// 网站首页Seo标题规则
        ///// </summary>
        //public string SeoSiteIndexTitle
        //{
        //    get
        //    {
        //        return _SeoSiteIndexTitle;
        //    }
        //    set
        //    {
        //        _SeoSiteIndexTitle = value;
        //    }
        //}
        ///// <summary>
        ///// 网站首页Seo关键词规则
        ///// </summary>
        //public string SeoSiteIndexKeyWord
        //{
        //    get
        //    {
        //        return _SeoSiteIndexKeyWord;
        //    }
        //    set
        //    {
        //        _SeoSiteIndexKeyWord = value;
        //    }
        //}
        ///// <summary>
        ///// 网站首页Seo描述规则
        ///// </summary>
        //public string SeoSiteIndexDes
        //{
        //    get
        //    {
        //        return _SeoSiteIndexDes;
        //    }
        //    set
        //    {
        //        _SeoSiteIndexDes = value;
        //    }
        //}




        ///// <summary>
        ///// 标签列表页Seo标题规则
        ///// </summary>
        //public string SeoTagListTitle
        //{
        //    get
        //    {
        //        return _SeoTagListTitle;
        //    }
        //    set
        //    {
        //        _SeoTagListTitle = value;
        //    }
        //}
        ///// <summary>
        ///// 标签列表页Seo关键词规则
        ///// </summary>
        //public string SeoTagListKeyWord
        //{
        //    get
        //    {
        //        return _SeoTagListKeyWord;
        //    }
        //    set
        //    {
        //        _SeoTagListKeyWord = value;
        //    }
        //}
        ///// <summary>
        ///// 标签列表页Seo描述规则
        ///// </summary>
        //public string SeoTagListDes
        //{
        //    get
        //    {
        //        return _SeoTagListDes;
        //    }
        //    set
        //    {
        //        _SeoTagListDes = value;
        //    }
        //}


        ///// <summary>
        ///// 标签主页Seo标题规则
        ///// </summary>
        //public string SeoTagIndexTitle
        //{
        //    get
        //    {
        //        return _SeoTagIndexTitle;
        //    }
        //    set
        //    {
        //        _SeoTagIndexTitle = value;
        //    }
        //}
        ///// <summary>
        ///// 标签主页Seo关键词规则
        ///// </summary>
        //public string SeoTagIndexKeyWord
        //{
        //    get
        //    {
        //        return _SeoTagIndexKeyWord;
        //    }
        //    set
        //    {
        //        _SeoTagIndexKeyWord = value;
        //    }
        //}
        ///// <summary>
        ///// 标签主页Seo描述规则
        ///// </summary>
        //public string SeoTagIndexDes
        //{
        //    get
        //    {
        //        return _SeoTagIndexDes;
        //    }
        //    set
        //    {
        //        _SeoTagIndexDes = value;
        //    }
        //}

        ///// <summary>
        ///// 分类Seo标题规则
        ///// </summary>
        //public string SeoClassTitle
        //{
        //    get
        //    {
        //        return _SeoClassTitle;
        //    }
        //    set
        //    {
        //        _SeoClassTitle = value;
        //    }
        //}
        ///// <summary>
        ///// 分类Seo关键词规则
        ///// </summary>
        //public string SeoClassKeyWord
        //{
        //    get
        //    {
        //        return _SeoClassKeyWord;
        //    }
        //    set
        //    {
        //        _SeoClassKeyWord = value;
        //    }
        //}
        ///// <summary>
        ///// 分类Seo描述规则
        ///// </summary>
        //public string SeoClassDes
        //{
        //    get
        //    {
        //        return _SeoClassDes;
        //    }
        //    set
        //    {
        //        _SeoClassDes = value;
        //    }
        //}
        ///// <summary>
        ///// 专题Seo标题规则
        ///// </summary>
        //public string SeoSpecialTitle
        //{
        //    get
        //    {
        //        return _SeoSpecialTitle;
        //    }
        //    set
        //    {
        //        _SeoSpecialTitle = value;
        //    }
        //}
        ///// <summary>
        ///// 专题Seo关键词规则
        ///// </summary>
        //public string SeoSpecialKeyWord
        //{
        //    get
        //    {
        //        return _SeoSpecialKeyWord;
        //    }
        //    set
        //    {
        //        _SeoSpecialKeyWord = value;
        //    }
        //}
        ///// <summary>
        ///// 专题Seo描述规则
        ///// </summary>
        //public string SeoSpecialDes
        //{
        //    get
        //    {
        //        return _SeoSpecialDes;
        //    }
        //    set
        //    {
        //        _SeoSpecialDes = value;
        //    }
        //}
        ///// <summary>
        ///// 内容Seo标题规则
        ///// </summary>
        //public string SeoContentTitle
        //{
        //    get
        //    {
        //        return _SeoContentTitle;
        //    }
        //    set
        //    {
        //        _SeoContentTitle = value;
        //    }
        //}
        ///// <summary>
        ///// 内容Seo关键词规则
        ///// </summary>
        //public string SeoContentKeyWord
        //{
        //    get
        //    {
        //        return _SeoContentKeyWord;
        //    }
        //    set
        //    {
        //        _SeoContentKeyWord = value;
        //    }
        //}
        ///// <summary>
        ///// 内容Seo描述规则
        ///// </summary>
        //public string SeoContentDes
        //{
        //    get
        //    {
        //        return _SeoContentDes;
        //    }
        //    set
        //    {
        //        _SeoContentDes = value;
        //    }
        //}
        //#endregion

     

        #region 原始页-电脑版

     
        private string _login = "login.aspx";
        private string _lostpassword = "lostpassword.aspx";
        private string _Remark = "Remark.aspx";
        private string _reg = "reg.aspx";

        private string _uhome = "uhome.aspx";
        private string _ucc = "UccIndex.aspx";
        private string _Search = "Search.aspx";
        private string _IndexPath = "index.aspx";
        private string _ListPath = "list.aspx";
        private string _ContentPath = "content.aspx";
        private string _SpecialPath = "special.aspx";
        private string _Taglist = "tags.aspx";
        private string _TagSearch = "tagv.aspx";
        private string _CustomSearch = "customsearch.aspx";
        private string _UserAlbum = "album.aspx";
        private string _CustomForm = "form.aspx";
        private string _loginbind = "loginbind.aspx";
        private string _Payment = "payment.aspx";
        private string _Delivery = "delivery.aspx";


        //cqs 2013-7-11
        private string _Frdlink = "frdlink.aspx";
        private string _UserInfo = "userinfo.aspx";
        private string _FrdlinkPost = "frdlinkpost.aspx";
        private string _VotePost = "votepost.aspx";
        private string _VoteView = "voteview.aspx";
        //private string _Album = "album.aspx";
        private string _Top = "top.aspx";
        private string _UserOnline = "uonline.aspx";

        public string ManageIndexMaster = "UserPagesTem.Master";

        //private string _ListPathAll = "listall.aspx";
        ////所有分类页面
        //public string ListPathAll
        //{
        //    get
        //    {
        //        return _ListPathAll;
        //    }
        //    set
        //    {
        //        _ListPathAll = value;
        //    }
        //}

        public string Frdlink
        {
            get
            {
                return _Frdlink;
            }
            set
            {
                _Frdlink = value;
            }
        }


        /// <summary>
        /// 用户默认信息展示页
        /// </summary>
        public string UserInfo
        {
            get
            {
                return _UserInfo;
            }
            set
            {
                _UserInfo = value;
            }
        }

        public string FrdlinkPost
        {
            get
            {
                return _FrdlinkPost;
            }
            set
            {
                _FrdlinkPost = value;
            }
        }

        public string VotePost
        {
            get
            {
                return _VotePost;
            }
            set
            {
                _VotePost = value;
            }
        }

        public string VoteView
        {
            get
            {
                return _VoteView;
            }
            set
            {
                _VoteView = value;
            }
        }

        //public string Album
        //{
        //    get
        //    {
        //        return _Album;
        //    }
        //    set
        //    {
        //        _Album = value;
        //    }
        //}

        public string Top
        {
            get
            {
                return _Top;
            }
            set
            {
                _Top = value;
            }
        }

        public string UserOnline
        {
            get
            {
                return _UserOnline;
            }
            set
            {
                _UserOnline = value;
            }
        }


        //end

        

        /// <summary>
        /// 选择配送方式
        /// </summary>
        public string Delivery
        {
            get
            {
                return _Delivery;
            }
            set
            {
                _Delivery = value;
            }
        }
        /// <summary>
        /// 选择支付方式
        /// </summary>
        public string Payment
        {
            get
            {
                return _Payment;
            }
            set
            {
                _Payment = value;
            }
        }

        /// <summary>
        /// 第三方登录回调地址
        /// </summary>
        public string LoginBind
        {
            get
            {
                return _loginbind;
            }
            set
            {
                _loginbind = value;
            }
        }
        public string CustomForm
        {
            get
            {
                return _CustomForm;
            }
            set
            {
                _CustomForm = value;
            }
        }
        public string UserAlbum
        {
            get
            {
                return _UserAlbum;
            }
            set
            {
                _UserAlbum = value;
            }
        }

        public string CustomSearch
        {
            get
            {
                return _CustomSearch;
            }
            set
            {
                _CustomSearch = value;
            }
        }

        
        public string UccIndex
        {
            get
            {
                return _ucc;
            }
            set
            {
                _ucc = value;
            }
        }

        public string Uhome
        {
            get
            {
                return _uhome;
            }
            set
            {
                _uhome = value;
            }
        }

        public string Reg
        {
            get
            {
                return _reg;
            }
            set
            {
                _reg = value;
            }
        }

        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }

        public string Lostpassword
        {
            get
            {
                return _lostpassword;
            }
            set
            {
                _lostpassword = value;
            }
        }
        
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }

        public string Search
        {
            get
            {
                return _Search;
            }
            set
            {
                _Search = value;
            }
        }

        /// <summary>
        /// 标签搜索页
        /// </summary>
        public string TagSearch
        {
            get
            {
                return _TagSearch;
            }
            set
            {
                _TagSearch = value;
            }
        }

        private bool _IsStopCnzz = true;
        public bool IsStopCnzz
        {
            get
            {
                return _IsStopCnzz;
            }
            set
            {
                _IsStopCnzz = value;
            }
        }

        /// <summary>
        /// 首页连接地址相对
        /// </summary>
        public string IndexPath
        {
            get
            {
                return _IndexPath;
            }
            set
            {
                _IndexPath = value;
            }
        }
        /// <summary>
        /// 分类列表页连接地址相对
        /// </summary>
        public string ListPath
        {
            get
            {
                return _ListPath;
            }
            set
            {
                _ListPath = value;
            }
        }
        /// <summary>
        /// 内容显示连接地址相对
        /// </summary>
        public string ContentPath
        {
            get
            {
                return _ContentPath;
            }
            set
            {
                _ContentPath = value;
            }
        }
        /// <summary>
        /// 专题页连接地址相对
        /// </summary>
        public string SpecialPath
        {
            get
            {
                return _SpecialPath;
            }
            set
            {
                _SpecialPath = value;
            }
        }
        /// <summary>
        /// 标签列表页连接地址相对
        /// </summary>
        public string Taglist
        {
            get
            {
                return _Taglist;
            }
            set
            {
                _Taglist = value;
            }
        }
        #endregion


        #region 原始->手机页面，目前不支持户后台页面
        private string _Mlogin = "login.aspx";
        private string _Mlostpassword = "lostpassword.aspx";
        private string _MRemark = "Remark.aspx";
        private string _Mreg = "reg.aspx";

        private string _Muhome = "uhome.aspx";
        private string _Mucc = "UccIndex.aspx";

        private string _MSearch = "Search.aspx";
        private string _MIndexPath = "indexmobile.aspx";
        private string _MListPath = "listmobile.aspx";
        private string _MContentPath = "contentmobile.aspx";
        private string _MSpecialPath = "specialmobile.aspx";
        private string _MTaglist = "tags.aspx";
        private string _MTagSearch = "tagv.aspx";

        private string _MPath = "m";

        public string MUccUserInfo = "uccuserinfo.aspx";

        //手机版访问目录
        public string MPath
        {
            get
            {
                return _MPath;
            } 
            set
            {
                _MPath = value;
            }
        }
        //public string MPathUrl
        //{
        //    get
        //    {
        //        return string.Concat(EbSite.Base.AppStartInit.IISPath, MPath,"/");
        //    }
        //}
        ////不处理移动版url,开启后所有移动访问url将为404
        //public bool IsNoMobile { get; set; }

        /// <summary>
        /// 站点模式,0为PC与移动站点并存,1为单独PC站点，2为单独移动站点
        /// </summary>
        public int SiteModule { get; set; }

        public string MUccIndex
        {
            get
            {
                return _Mucc;
            }
            set
            {
                _Mucc = value;
            }
        }

        public string MUhome
        {
            get
            {
                return _Muhome;
            }
            set
            {
                _Muhome = value;
            }
        }



        public string MReg
        {
            get
            {
                return _Mreg;
            }
            set
            {
                _Mreg = value;
            }
        }

        public string MRemark
        {
            get
            {
                return _MRemark;
            }
            set
            {
                _MRemark = value;
            }
        }

        public string MLostpassword
        {
            get
            {
                return _Mlostpassword;
            }
            set
            {
                _Mlostpassword = value;
            }
        }

        public string MLogin
        {
            get
            {
                return _Mlogin;
            }
            set
            {
                _Mlogin = value;
            }
        }


        public string MSearch
        {
            get
            {
                return _MSearch;
            }
            set
            {
                _MSearch = value;
            }
        }

        /// <summary>
        /// 标签搜索页
        /// </summary>
        public string MTagSearch
        {
            get
            {
                return _MTagSearch;
            }
            set
            {
                _MTagSearch = value;
            }
        }


        /// <summary>
        /// 首页连接地址相对
        /// </summary>
        public string MIndexPath
        {
            get
            {
                return _MIndexPath;
            }
            set
            {
                _MIndexPath = value;
            }
        }
        /// <summary>
        /// 分类列表页连接地址相对
        /// </summary>
        public string MListPath
        {
            get
            {
                return _MListPath;
            }
            set
            {
                _MListPath = value;
            }
        }
        /// <summary>
        /// 内容显示连接地址相对
        /// </summary>
        public string MContentPath
        {
            get
            {
                return _MContentPath;
            }
            set
            {
                _MContentPath = value;
            }
        }
        /// <summary>
        /// 专题页连接地址相对
        /// </summary>
        public string MSpecialPath
        {
            get
            {
                return _MSpecialPath;
            }
            set
            {
                _MSpecialPath = value;
            }
        }
        /// <summary>
        /// 标签列表页连接地址相对
        /// </summary>
        public string MTaglist
        {
            get
            {
                return _MTaglist;
            }
            set
            {
                _MTaglist = value;
            }
        }
        #endregion



        #region 电脑版重写

        private string _loginRw = "login.ashx";
        private string _lostpasswordRw = "lostpassword.ashx";
        private string _regRw = "reg.ashx";
        private string _uhomeRw = "uhome.ashx";
        private string _UccIndexRw = "UccIndex.ashx";
        private string _IndexPathRw = "index.ashx";
        private string _ListPathRw = "list.ashx";
        private string _ContentPathRw = "content.ashx";
        private string _SpecialPathRw = "special.ashx";
        private string _TaglistRw = "tags.ashx";
        private string _TagSearchRw = "tagv.ashx";
        private string _SearchRw = "Search.ashx";
        private string _CustomFormRw = "form.ashx";
        private string _CustomSearchRw = "customsearch.ashx";
        private string _loginbindRw = "loginbind.ashx";
        private string _PaymentRw = "payment.ashx";
        private string _DeliveryRw = "delivery.ashx";




        //cqs 2013-7-11
        private string _FrdlinkRw = "frdlink.ashx";
        private string _UserInfoRw = "uinfo.ashx";
        private string _FrdlinkPostRw = "frdlinkpost.ashx";
        
        private string _VotePostRw = "votepost.ashx";
        private string _VoteViewRw = "voteview.ashx";
        //private string _AlbumRw = "album.ashx";
        private string _TopRw = "top.ashx";
        private string _UserOnlineRw = "uonline.ashx";


        private string _ListPathAllRw = "listall.ashx";
        public string ListPathAllRw
        {
            get
            {
                return _ListPathAllRw;
            }
            set
            {
                _ListPathAllRw = value;
            }
        }

        /// <summary>
        /// 用户默认信息展示页
        /// </summary>
        public string FrdlinkRw
        {
            get
            {
                return _FrdlinkRw;
            }
            set
            {
                _FrdlinkRw = value;
            }
        }
        /// <summary>
        /// 用户默认信息展示页
        /// </summary>
        public string UserInfoRw
        {
            get
            {
                return _UserInfoRw;
            }
            set
            {
                _UserInfoRw = value;
            }
        }

        public string FrdlinkPostRw
        {
            get
            {
                return _FrdlinkPostRw;
            }
            set
            {
                _FrdlinkPostRw = value;
            }
        }

        public string VotePostRw
        {
            get
            {
                return _VotePostRw;
            }
            set
            {
                _VotePostRw = value;
            }
        }

        public string VoteViewRw
        {
            get
            {
                return _VoteViewRw;
            }
            set
            {
                _VoteViewRw = value;
            }
        }

        //public string AlbumRw
        //{
        //    get
        //    {
        //        return _AlbumRw;
        //    }
        //    set
        //    {
        //        _AlbumRw = value;
        //    }
        //}

        public string TopRw
        {
            get
            {
                return _TopRw;
            }
            set
            {
                _TopRw = value;
            }
        }

        public string UserOnlineRw
        {
            get
            {
                return _UserOnlineRw;
            }
            set
            {
                _UserOnlineRw = value;
            }
        }


        //end





        /// <summary>
        /// 选择配送方式
        /// </summary>
        public string DeliveryRw
        {
            get
            {
                return _DeliveryRw;
            }
            set
            {
                _DeliveryRw = value;
            }
        }
        /// <summary>
        /// 选择支付方式
        /// </summary>
        public string PaymentRw
        {
            get
            {
                return _PaymentRw;
            }
            set
            {
                _PaymentRw = value;
            }
        }
        /// <summary>
        /// 第三方登录回调地址
        /// </summary>
        public string LoginbindRw
        {
            get
            {
                return _loginbindRw;
            }
            set
            {
                _loginbindRw = value;
            }
        }
        public string CustomFormRw
        {
            get
            {
                return _CustomFormRw;
            }
            set
            {
                _CustomFormRw = value;
            }
        }
        public string CustomSearchRw
        {
            get
            {
                return _CustomSearchRw;
            }
            set
            {
                _CustomSearchRw = value;
            }
        }
        private string _UserAlbumRw = "album.ashx";
        public string UserAlbumRw
        {
            get
            {
                return _UserAlbumRw;
            }
            set
            {
                _UserAlbumRw = value;
            }
        }
        public string UccIndexRw
        {
            get
            {
                return _UccIndexRw;
            }
            set
            {
                _UccIndexRw = value;
            }
        }

        public string UhomeRw
        {
            get
            {
                return _uhomeRw;
            }
            set
            {
                _uhomeRw = value;
            }
        }

       

        public string RegRw
        {
            get
            {
                return _regRw;
            }
            set
            {
                _regRw = value;
            }
        }

        public string LostpasswordRw
        {
            get
            {
                return _lostpasswordRw;
            }
            set
            {
                _lostpasswordRw = value;
            }
        }

        public string LoginRw
        {
            get
            {
                return _loginRw;
            }
            set
            {
                _loginRw = value;
            }
        }

        public string SearchRw
        {
            get
            {
                return _SearchRw;
            }
            set
            {
                _SearchRw = value;
            }
        }
        /// <summary>
        /// 标签搜索页
        /// </summary>
        public string TagSearchRw
        {
            get
            {
                return _TagSearchRw;
            }
            set
            {
                _TagSearchRw = value;
            }
        }


        /// <summary>
        /// 首页连接地址相对
        /// </summary>
        public string IndexPathRw
        {
            get
            {
                return _IndexPathRw;
            }
            set
            {
                _IndexPathRw = value;
            }
        }
        /// <summary>
        /// 分类列表页连接地址相对
        /// </summary>
        public string ListPathRw
        {
            get
            {
                return _ListPathRw;
            }
            set
            {
                _ListPathRw = value;
            }
        }
        /// <summary>
        /// 内容显示连接地址相对
        /// </summary>
        public string ContentPathRw
        {
            get
            {
                return _ContentPathRw;
            }
            set
            {
                _ContentPathRw = value;
            }
        }
        /// <summary>
        /// 专题页连接地址相对
        /// </summary>
        public string SpecialPathRw
        {
            get
            {
                return _SpecialPathRw;
            }
            set
            {
                _SpecialPathRw = value;
            }
        }
        /// <summary>
        /// 标签列表页连接地址相对
        /// </summary>
        public string TaglistRw
        {
            get
            {
                return _TaglistRw;
            }
            set
            {
                _TaglistRw = value;
            }
        }
         
        public string ContentPathRw2 { get; set; }

        #endregion

        #region 手机版重写
        private string _MloginRw = "login.ashx";
        private string _MlostpasswordRw = "lostpassword.ashx";
        private string _MregRw = "reg.ashx";
        private string _MuhomeRw = "uhome.ashx";
        private string _MUccIndexRw = "UccIndex.ashx";

        private string _MIndexPathRw = "index.ashx";
        private string _MListPathRw = "list.ashx";
        private string _MContentPathRw = "content.ashx";
        private string _MSpecialPathRw = "special.ashx";
        private string _MTaglistRw = "tags.ashx";
        private string _MTagSearchRw = "tagv.ashx";
        private string _MSearchRw = "Search.ashx";

        public string MUccUserInfoRw = "uccuserinfo.ashx";

        public string MUccIndexRw
        {
            get
            {
                return  _MUccIndexRw;
            }
            set
            {
                _MUccIndexRw = value;
            }
        }

        public string MUhomeRw
        {
            get
            {
                return _MuhomeRw;
            }
            set
            {
                _MuhomeRw = value;
            }
        }



        public string MRegRw
        {
            get
            {
                return _MregRw;
            }
            set
            {
                _MregRw = value;
            }
        }

        public string MLostpasswordRw
        {
            get
            {
                return _MlostpasswordRw;
            }
            set
            {
                _MlostpasswordRw = value;
            }
        }

        public string MLoginRw
        {
            get
            {
                return _MloginRw;
            }
            set
            {
                _MloginRw = value;
            }
        }

        public string MSearchRw
        {
            get
            {
                return _MSearchRw;
            }
            set
            {
                _MSearchRw = value;
            }
        }
        /// <summary>
        /// 标签搜索页
        /// </summary>
        public string MTagSearchRw
        {
            get
            {
                return _MTagSearchRw;
            }
            set
            {
                _MTagSearchRw = value;
            }
        }


        /// <summary>
        /// 首页连接地址相对
        /// </summary>
        public string MIndexPathRw
        {
            get
            {
                return _MIndexPathRw;
            }
            set
            {
                _MIndexPathRw = value;
            }
        }
        /// <summary>
        /// 分类列表页连接地址相对
        /// </summary>
        public string MListPathRw
        {
            get
            {
                return _MListPathRw;
            }
            set
            {
                _MListPathRw = value;
            }
        }
        /// <summary>
        /// 内容显示连接地址相对
        /// </summary>
        public string MContentPathRw
        {
            get
            {
                return _MContentPathRw;
            }
            set
            {
                _MContentPathRw = value;
            }
        }
        /// <summary>
        /// 专题页连接地址相对
        /// </summary>
        public string MSpecialPathRw
        {
            get
            {
                return _MSpecialPathRw;
            }
            set
            {
                _MSpecialPathRw = value;
            }
        }
        /// <summary>
        /// 标签列表页连接地址相对
        /// </summary>
        public string MTaglistRw
        {
            get
            {
                return _MTaglistRw;
            }
            set
            {
                _MTaglistRw = value;
            }
        }
        #endregion



        

        ///// <summary>
        ///// 默认一级分类的模型ID
        ///// </summary>
        //public Guid DefaultClassID
        //{
        //    get
        //    {
        //        return _DefaultClassID;
        //    }
        //    set
        //    {
        //        _DefaultClassID = value;
        //    }
        //}

        

        
        
    }

  
}
