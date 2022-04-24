

using System;
using EbSite.Base.Configs.ConfigsBase;

namespace EbSite.Base.Configs.UserSetConfigs
{
    public class ConfigsInfo : IConfigInfo
    {

        private string _UserGroup;   //会员注册默认会员组
        //private string _ContributeState; //投稿状态
        private string _AllowRegister;  //是否允许注册
        private string _IfCode;     //是否需要验证码
        //private string _Comment;     //评论是否需要审核
        //private string _Cryptonym;   //是否允许匿名评论
        //private string _FilterWord = "我日,法轮功,邪教,fuck you,妈妈的,麻仁,草,操"; //评论过滤字符
        //private string _IPRestrict = "127.0.1.*|127.2.0.*"; //会员IP登陆限制
        //private string _GUnit = "swordweb币"; //会员G币单位
        //private string _RegisterGetG = "10|10"; //会员注册获得的金币|积分
        //private string _GlamourUp = "2|2";  //魅力值增加
        //private string _VigorousUp = "2|2"; //活跃值增加
        //private string _RechargeableType;//会员冲值类型
        //private string _ErrorLockedup = "3|30";  //错误登陆次数|锁定时间

        private string _RegisterPact; //会员注册需知
        //private string _RegisterParameter; //选择需要注册的参数
        //private string _Parameter = "UserName,UserPassword,email"; //选择参数
        //private string _EmailVerification; //注册是否需要电子邮件验证
        //private string _CellPhoneApprove;//注册是否需要手机认证(需要ISP接口)
        private int _ErrLoginNumLock;//登录错误多少次将被锁定
        private int _LockTime;       //登录错误多少次将被锁定多长时间

        private string _NoAllowToRegInfo;

        private int _GroupType = 0;//用户组机制 0 为单用户组机制 1 为多用户组机制

        //private bool _IsAuditingNewUser = false;

        private int _DefaultCredits = 10;
        /// <summary>
        /// 默认注册积分
        /// </summary>
        public int DefaultCredits
        {
            get
            {
                return _DefaultCredits;
            }
            set
            {
                _DefaultCredits = value;
            }
        }

        private int _AllowUserType = 0;
        /// <summary>
        /// 注册用户激活方式，0为自动激活，1为手动激活，2为Email激活
        /// </summary>
        public int AllowUserType
        {
            get
            {
                return _AllowUserType;
            }
            set
            {
                _AllowUserType = value;
            }
        }

        //public bool IsAuditingNewUser
        //{
        //    get
        //    {
        //        return _IsAuditingNewUser;
        //    }
        //    set
        //    {
        //        _IsAuditingNewUser = value;
        //    }
        //}

        /// <summary>
        /// 用户组机制 0 为单用户组机制 1 为多用户组机制
        /// </summary>
        public int GroupType
        {
            get
            {
                return _GroupType;
            }
            set
            {
                _GroupType = value;
            }
        }

        /// <summary>
        /// 用户登录成功后定向到页面的相对Url
        /// </summary>
        public string NoAllowToRegInfo
        {
            get
            {
                return _NoAllowToRegInfo;
            }
            set
            {
                _NoAllowToRegInfo = value;
            }
        }

        /// <summary>
        /// 登录错误多少次将被锁定多长时间
        /// </summary>
        public int LockTime
        {
            get
            {
                return _LockTime;
            }
            set
            {
                _LockTime = value;
            }
        }
        /// <summary>
        /// 登录错误多少次将被锁定
        /// </summary>
        public int ErrLoginNumLock
        {
            get
            {
                return _ErrLoginNumLock;
            }
            set
            {
                _ErrLoginNumLock = value;
            }
        }
         public int UserGroupID { get; set; }
        ///// <summary>
        ///// 会员注册默认会员组
        ///// </summary>
        //public string UserGroup
        //{
        //    get
        //    {
        //        return _UserGroup;
        //    }
        //    set
        //    {
        //        _UserGroup = value;
        //    }
        //}

       
        /// <summary>
        /// 在线用户过期时间
        /// </summary>
        public int OnlineTimeSpan { get; set; }
        /// <summary>
        /// 过期方式,0.天，1小时,2分钟
        /// </summary>
        public int OnlineTimeSpanModel { get; set; }
        
        /// <summary>
        /// 是否允许注册
        /// </summary>
        public string IsAllowRegister
        {
            get
            {
                return _AllowRegister;
            }
            set
            {
                _AllowRegister = value;
            }
        }
        /// <summary>
        /// 是否需要验证码
        /// </summary>
        public string IfCode
        {
            get
            {
                return _IfCode;
            }
            set
            {
                _IfCode = value;
            }
        }
        ///// <summary>
        ///// 会员IP登陆限制
        ///// </summary>
        //public string IPRestrict
        //{
        //    get
        //    {
        //        return _IPRestrict;
        //    }
        //    set
        //    {
        //        _IPRestrict = value;
        //    }
        //}
        /// <summary>
        /// 会员注册需知
        /// </summary>
        public string RegisterPact
        {
            get
            {
                return _RegisterPact;
            }
            set
            {
                _RegisterPact = value;
            }
        }
        ///// <summary>
        ///// 注册是否需要电子邮件验证
        ///// </summary>
        //public string EmailVerification
        //{
        //    get
        //    {
        //        return _EmailVerification;
        //    }
        //    set
        //    {
        //        _EmailVerification = value;
        //    }
        //}
        private string _StarIP = "127.0.0.11";

        /// <summary>
        /// 起始IP
        /// </summary>
        public string StarIP
        {
            get { return _StarIP; }
            set { _StarIP = value; }
        }

        private string _EndIP = "127.0.0.11";
        /// <summary>
        /// 结束IP
        /// </summary>
        public string EndIP
        {
            get { return _EndIP; }
            set { _EndIP = value; }
        }
        /// <summary>
        /// IP限制到期时间
        /// </summary>
        public DateTime IPSetDateTime { get; set; }

        /// <summary>
        /// 第一次修改头像可获得积分
        /// </summary>
        public int ModifyIcoInCredit { get; set; }
        /// <summary>
        /// 添加一条内容可获得积分
        /// </summary>
        public int AddContentInCredit { get; set; }
        /// <summary>
        /// 邀请一个用户注册获得积分
        /// </summary>
        public int InviteRegInCredit { get; set; }
        /// <summary>
        /// 一天内第一次登录获得积分
        /// </summary>
        public int LoginInCredit { get; set; }
        /// <summary>
        /// 发表一个评论可获得积分
        /// </summary>
        public int ToCommentInCredit { get; set; }
        public string UserCenter { get; set; }
        public int _DefaultLevel = 1;
        /// <summary>
        /// 默认用户级别
        /// </summary>
        public int DefaultLevel
        {
            get
            {
                return _DefaultLevel;
            }
            set
            {
                _DefaultLevel = value;
            }
        }
        #region 提示更新
        private bool _isheader;
        /// <summary>
        /// 是否选择头像
        /// </summary>
        public bool IsHeader
        {
            get { return _isheader; }
            set { _isheader = value; }
        }

        private string _headerhint;
        /// <summary>
        /// 头像 提示语
        /// </summary>
        public string HeaderHint
        {
            get { return _headerhint; }
            set { _headerhint = value; }
        }

        private int _orderheader;
        /// <summary>
        /// 头像 顺序
        /// </summary>
        public int OrderHeader
        {
            get { return _orderheader; }
            set { _orderheader = value; }
        }

       //////
        private bool _istel;
        /// <summary>
        /// 是否选择手机
        /// </summary>
        public bool IsTel
        {
            get { return _istel; }
            set { _istel = value; }
        }

        private string _telhint;
        /// <summary>
        /// 手机 提示语
        /// </summary>
        public string TelHint
        {
            get { return _telhint; }
            set { _telhint = value; }
        }

        private int _ordertel;
        /// <summary>
        /// 手机 顺序
        /// </summary>
        public int OrderTel
        {
            get { return _ordertel; }
            set { _ordertel = value; }
        }
        ///
       
        private bool _isemail;
        /// <summary>
        /// 是否选择email
        /// </summary>
        public bool IsEmail
        {
            get { return _isemail; }
            set { _isemail = value; }
        }

        private string _emailhint;
        /// <summary>
        /// Email 提示语
        /// </summary>
        public string EmailHint
        {
            get { return _emailhint; }
            set { _emailhint = value; }
        }

        private int _orderemail;
        /// <summary>
        /// Email 顺序
        /// </summary>
        public int OrderEmail
        {
            get { return _orderemail; }
            set { _orderemail = value; }
        }
        #endregion

    }
}
