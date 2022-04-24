using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.UI.WebControls;
using EbSite.Base.EntityAPI;
using EbSite.Base.Page;

namespace EbSite.Base.EBSiteEventArgs
{
    //本文件为EBSite所有的事件参数定义

    #region 业务层处理事件

    public class AddingEventEventArgs : EventArgs
    {
        private bool _StopContinue;
        /// <summary>
        /// 是否阻住进行操作
        /// </summary>
        public bool StopContinue
        {
            get
            {
                return _StopContinue;
            }
            set
            {
                _StopContinue = value;
            }
        }
        private string _KeyValue;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public string KeyValue
        {
            get
            {
                return _KeyValue;
            }
            set
            {
                _KeyValue = value;
            }
        }
        public AddingEventEventArgs(string sKeyValue)
        {
            _KeyValue = sKeyValue;
        }
        public AddingEventEventArgs()
        {
        }
    }

    public class AddedEventEventArgs : EventArgs
    {
        private string _KeyValue;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public string KeyValue
        {
            get
            {
                return _KeyValue;
            }
            set
            {
                _KeyValue = value;
            }
        }
        public AddedEventEventArgs(string sKeyValue)
        {
            _KeyValue = sKeyValue;
        }
        public AddedEventEventArgs()
        {
        }
    }

    public class DeleteingEntityEventEventArgs : EventArgs
    {
        private bool _StopContinue;
        /// <summary>
        /// 是否阻住进行操作
        /// </summary>
        public bool StopContinue
        {
            get
            {
                return _StopContinue;
            }
            set
            {
                _StopContinue = value;
            }
        }
        private string _KeyValue;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public string KeyValue
        {
            get
            {
                return _KeyValue;
            }
            set
            {
                _KeyValue = value;
            }
        }
        public DeleteingEntityEventEventArgs(string sKeyValue)
        {
            _KeyValue = sKeyValue;
        }
        public DeleteingEntityEventEventArgs()
        {
        }
    }

    public class DeletedEntityEventEventArgs : EventArgs
    {
        private string _KeyValue;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public string KeyValue
        {
            get
            {
                return _KeyValue;
            }
            set
            {
                _KeyValue = value;
            }
        }
        public DeletedEntityEventEventArgs(string sKeyValue)
        {
            _KeyValue = sKeyValue;
        }
        public DeletedEntityEventEventArgs()
        {
        }
    }

    public class SelectingEntityEventEventArgs : EventArgs
    {
        private bool _StopContinue;
        /// <summary>
        /// 是否阻住进行操作
        /// </summary>
        public bool StopContinue
        {
            get
            {
                return _StopContinue;
            }
            set
            {
                _StopContinue = value;
            }
        }
        private string _KeyValue;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public string KeyValue
        {
            get
            {
                return _KeyValue;
            }
            set
            {
                _KeyValue = value;
            }
        }
        public SelectingEntityEventEventArgs(string sKeyValue)
        {
            _KeyValue = sKeyValue;
        }
        public SelectingEntityEventEventArgs()
        {
        }
    }

    public class SelectedEntityEventEventArgs : EventArgs
    {
        private string _KeyValue;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public string KeyValue
        {
            get
            {
                return _KeyValue;
            }
            set
            {
                _KeyValue = value;
            }
        }
        public SelectedEntityEventEventArgs(string sKeyValue)
        {
            _KeyValue = sKeyValue;
        }
        public SelectedEntityEventEventArgs()
        {
        }
    }

    public class UpdateingEntityEventEventArgs : EventArgs
    {
        private bool _StopContinue;
        /// <summary>
        /// 是否阻住进行操作
        /// </summary>
        public bool StopContinue
        {
            get
            {
                return _StopContinue;
            }
            set
            {
                _StopContinue = value;
            }
        }
        private string _KeyValue;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public string KeyValue
        {
            get
            {
                return _KeyValue;
            }
            set
            {
                _KeyValue = value;
            }
        }
        public UpdateingEntityEventEventArgs(string sKeyValue)
        {
            _KeyValue = sKeyValue;
        }
        public UpdateingEntityEventEventArgs()
        {
        }
    }

    public class UpdatedEntityEventEventArgs : EventArgs
    {
        private string _KeyValue;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public string KeyValue
        {
            get
            {
                return _KeyValue;
            }
            set
            {
                _KeyValue = value;
            }
        }
        public UpdatedEntityEventEventArgs(string sKeyValue)
        {
            _KeyValue = sKeyValue;
        }
        public UpdatedEntityEventEventArgs()
        {
        }
    }

    public class SelectingEntityListEventEventArgs : EventArgs
    {
        private bool _StopContinue;
        /// <summary>
        /// 是否阻住进行操作
        /// </summary>
        public bool StopContinue
        {
            get
            {
                return _StopContinue;
            }
            set
            {
                _StopContinue = value;
            }
        }

        public SelectingEntityListEventEventArgs()
        {

        }
    }

    public class SelectedEntityListEventEventArgs : EventArgs
    {
        private int _Count;
        /// <summary>
        ///记录条数
        /// </summary>
        public int Count
        {
            get
            {
                return _Count;
            }
            set
            {
                _Count = value;
            }
        }
        public SelectedEntityListEventEventArgs(int Count)
        {
            _Count = Count;
        }
    }

    #endregion


    #region 分类业务事件参数


    public class AddingClassEventArgs : EventArgs
    {
        private bool _StopAdd;
        /// <summary>
        /// 是否阻住添加
        /// </summary>
        public bool StopAdd
        {
            get
            {
                return _StopAdd;
            }
            set
            {
                _StopAdd = value;
            }
        }
        private int _ID;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public AddingClassEventArgs(int ID)
        {
            _ID = ID;
        }


    }
    public class UpdatedClassEventArgs : AddedClassEventArgs
    {

        public UpdatedClassEventArgs(int ID, EbSite.Entity.NewsClass entity)
            : base(ID, entity)
        {

        }
    }
    public class AddedClassEventArgs : EventArgs
    {

        private int _ID;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        private EbSite.Entity.NewsClass _Entity;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public EbSite.Entity.NewsClass Entity
        {
            get
            {
                return _Entity;
            }
            set
            {
                _Entity = value;
            }
        }

        public AddedClassEventArgs(int ID, EbSite.Entity.NewsClass entity)
        {
            _ID = ID;
            _Entity = entity;
        }


    }
    public class DeletedClassEventArgs : ClassEventArgs
    {
        public DeletedClassEventArgs(int ID)
            : base(ID)
        {

        }

    }


    public class ClassEventArgs : EventArgs
    {

        private int _ID;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public ClassEventArgs(int ID)
        {
            _ID = ID;
        }


    }

    public class DeleteingClassEventArgs : EventArgs
    {
        private bool _StopDelete;
        /// <summary>
        /// 是否阻住添加
        /// </summary>
        public bool StopDelete
        {
            get
            {
                return _StopDelete;
            }
            set
            {
                _StopDelete = value;
            }
        }
        private int _ID;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public DeleteingClassEventArgs(int ID)
        {
            _ID = ID;
        }
    }
    /// <summary>
    /// 获取一个实体触发
    /// </summary>
    public class GetClassEntityEventArgs : EventArgs
    {
        public EbSite.Entity.NewsClass Model { get; set; }
        public GetClassEntityEventArgs(EbSite.Entity.NewsClass model)
        {
            Model = model;
        }
    }

    #endregion


    #region 内容业务事件参数
    public class AddedContentEventArgs : EventArgs
    {

        private long _ID;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public long ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        private string _Title;
        /// <summary>
        ///内容标题
        /// </summary>
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }
        public int ClassID { get; set; }
        public AddedContentEventArgs(long ID, string title, int _ClassID)
        {
            _ID = ID;
            _Title = title;
            ClassID = _ClassID;
        }


    }

    public class AddingContentEventArgs : EventArgs
    {
        private bool _StopAdd;
        /// <summary>
        /// 是否阻住添加
        /// </summary>
        public bool StopAdd
        {
            get
            {
                return _StopAdd;
            }
            set
            {
                _StopAdd = value;
            }
        }
        private long _ID;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public long ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public int ClassID { get; set; }
        public AddingContentEventArgs(long ID, int _ClassID)
        {
            _ID = ID;
            ClassID = _ClassID;
        }


    }
    public class DeleteingContentEventArgs : EventArgs
    {
        private bool _StopDelete;
        /// <summary>
        /// 是否阻住添加
        /// </summary>
        public bool StopDelete
        {
            get
            {
                return _StopDelete;
            }
            set
            {
                _StopDelete = value;
            }
        }
        private long _ID;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public long ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public string TableName { get; set; }
        public int SiteID { get; set; }
        public DeleteingContentEventArgs(long _ID, string _TableName, int _SiteID)
        {
            ID = _ID;
            TableName = _TableName;
            SiteID = _SiteID;

        }
    }
    /// <summary>
    /// 获取一个实体触发
    /// </summary>
    public class GetContentEntityEventArgs : EventArgs
    {
        public EbSite.Entity.NewsContent Model { get; set; }
        public GetContentEntityEventArgs(EbSite.Entity.NewsContent model)
        {
            Model = model;
        }
    }

    public class UpdateingContentEventArgs : EventArgs
    {
        private bool _StopAdd;
        /// <summary>
        /// 是否阻住添加
        /// </summary>
        public bool StopAdd
        {
            get
            {
                return _StopAdd;
            }
            set
            {
                _StopAdd = value;
            }
        }
        private long _ID;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public long ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public int ClassID { get; set; }
        public UpdateingContentEventArgs(long ID, int _ClassID)
        {
            _ID = ID;
            ClassID = _ClassID;
        }


    }

    #endregion

    #region Profile


    public class DeleteProfilesArgs : EventArgs
    {
        private string _UserName;
        /// <summary>
        /// SettingsContext
        /// </summary>
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }

        public DeleteProfilesArgs(string username)
        {
            _UserName = username;
        }
        public DeleteProfilesArgs()
        {
        }
    }

    #endregion

    #region wcf 业务处理

    ///// <summary>
    ///// 访问Version,主要应用EbSite官方升级用,为了方便直接写到这来了
    ///// </summary>
    //public class GetVersionEventArgs : EventArgs
    //{
    //    public string Version { get; set; }
    //    public string WebUrl { get; set; }
    //    public string PathUrl { get; set; }
    //    public DateTime UpdateTime { get; set; }
    //    public GetVersionEventArgs(string _Version, string _WebUrl, string _PathUrl, DateTime _UpdateTime)
    //    {
    //        Version = _Version;
    //        WebUrl = _WebUrl;
    //        PathUrl = _PathUrl;
    //        UpdateTime = _UpdateTime;
    //    }
    //}

    #endregion

    #region 静态页生成

    public class MakeingEventArgs : EventArgs
    {
        private string _Html;
        public string Html
        {
            get
            {
                return _Html;
            }
            set
            {
                _Html = value;
            }
        }
        private int _ID;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public MakeingEventArgs(string HtmlContent)
        {
            _Html = HtmlContent;
        }
    }

    public class MakedEventArgs : EventArgs
    {
        public string Html { get; set; }
        public int ClassID { get; set; }
        private long _ID;
        /// <summary>
        ///如果当前生成带有id的，此处代表当前数据的唯一ID
        /// </summary>
        public long ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public MakedEventArgs(long id, string sHtml,int _ClassID)
        {
            _ID = id;
            Html = sHtml;
            ClassID = _ClassID;
        }
    }

    /// <summary>
    /// 支付完成触发事件
    /// </summary>
    public class PayedEventArgs : EventArgs
    {
        /// <summary>
        /// 商家帐号
        /// </summary>
        public string TradeNo { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public string TotalFee { get; set; }
        /// <summary>
        /// 订单的标题说明
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 买家帐号
        /// </summary>
        public string BuyerNo { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string TradeStatus { get; set; }
        /// <summary>
        /// 订单描述
        /// </summary>
        public string Body { get; set; }


        public PayedEventArgs(string _TradeNo, string _OrderNo, string _TotalFee, string _Subject,
            string _BuyerNo, string _TradeStatus, string _Body)
        {
            TradeNo = _TradeNo;
            OrderNo = _OrderNo;
            TotalFee = _TotalFee;
            Subject = _Subject;
            BuyerNo = _BuyerNo;
            TradeStatus = _TradeStatus;
            Body = _Body;


        }
    }




    public class SearchEventArgs : EventArgs
    {
        /// <summary>
        /// 搜索输入的关键词
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Where { get; set; }
        /// <summary>
        /// 当前页面上下文
        /// </summary>
        public HttpContext Context { get; set; }
        /// <summary>
        /// 当前站点ID
        /// </summary>
        public int SiteID { get; set; }

        public SearchEventArgs(string _KeyWord, string _Where, HttpContext _context, int _SiteID)
        {
            KeyWord = _KeyWord;
            Where = _Where;
            Context = _context;
            SiteID = _SiteID;

        }
    }
    /// <summary>
    /// 文章 审核通的扩展
    /// </summary>
    public class AllowContentEventArgs : EventArgs
    {

        public int ID { get; set; }
        public int ClassID { get; set; }//目的 扩展中 知道操作哪个表
        public int SiteID { get; set; }//目的 区分 哪个站点下的扩展
        //public HttpContext Context { get; set; }
        public AllowContentEventArgs(int _ID,int _ClassID,int _SiteID)
        {
            ID = _ID;
            ClassID = _ClassID;
            SiteID = _SiteID;
        }
    }
    public class ClassListLaodingEventArgs : EventArgs
    {
        /// <summary>
        /// 搜索输入的关键词
        /// </summary>
        public int ClassID { get; set; }
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Where { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string OrderBy { get; set; }

        public HttpContext Context { get; set; }
        /// <summary>
        /// 站点ID
        /// </summary>
        public int SiteID { get; set; }
        public ClassListLaodingEventArgs(int _ClassID, string _Where, HttpContext _context, int _siteID, string _orderBy)
        {
            ClassID = _ClassID;
            Where = _Where;
            Context = _context;
            SiteID = _siteID;
            OrderBy = _orderBy;


        }
    }
    /// <summary>
    /// 用户个人后台 扩展事件
    /// </summary>
    public class UserInfoEventArgs : EventArgs
    {

        /// <summary>
        /// 数据源
        /// </summary>
        public object ObDataSource { get; set; }

        private bool _StopLoad;
        /// <summary>
        /// 是否阻住
        /// </summary>
        public bool StopLoad
        {
            get
            {
                return _StopLoad;
            }
            set
            {
                _StopLoad = value;
            }
        }

        /// <summary>
        /// 上下文
        /// </summary>
        public HttpContext Context { get; set; }
        /// <summary>
        /// 模板路径
        /// </summary>
        public string GetTemPath { get; set; }
        /// <summary>
        /// 站点ID
        /// </summary>
        public int SiteID { get; set; }
        /// <summary>
        /// 当前用户对象
        /// </summary>
        public MembershipUserEb Model { get; set; }
        public System.Web.UI.Page Page { get; set; }
        public UserInfoEventArgs(object _ObDataSource, HttpContext _context, int _siteID, string _GetTemPath, MembershipUserEb _Model, System.Web.UI.Page _Page)
        {
            ObDataSource = _ObDataSource;
            Model = _Model;
            Context = _context;
            SiteID = _siteID;
            GetTemPath = _GetTemPath;
            Page = _Page;

        }
    }


    /// <summary>
    /// 用户审核通过触发事件
    /// </summary>
    public class UserActivatedEventArgs : EventArgs
    {
        /// <summary>
        /// 用户帐号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码 已经加过密码
        /// </summary>
        public string Pass { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 用户组ID
        /// </summary>
        //public int GroupID { get; set; }
        /// <summary>
        /// 邀请用户ID
        /// </summary>
        public int VUserID { get; set; }

        public string ReturnUrl { get; set; }

        public int RoleID { get; set; }

        public UserActivatedEventArgs(int _UserID, string _UserName, string _Email,  int _VUserID, string _Pass,int _RoleID)
        {
            UserID = _UserID;
            UserName = _UserName;
            Email = _Email;
            //GroupID = _GroupID;
            VUserID = _VUserID;
            Pass = _Pass;

            RoleID = _RoleID;

        }
    }


    /// <summary>
    /// 用户登录成功后触发
    /// </summary>
    public class UserLoginedEventArgs : EventArgs
    {
        /// <summary>
        /// 用户帐号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码 已经加过密码
        /// </summary>
        public string Pass { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }


        public string ReturnUrl { get; set; }

        public UserLoginedEventArgs(int _UserID, string _UserName, string _Email, string _Pass, string _Mobile)
        {
            UserID = _UserID;
            UserName = _UserName;
            Email = _Email;
            Pass = _Pass;
            Mobile = _Mobile;

        }
    }


    #endregion

    #region HttpModule扩展
    public class HttpModuleRuningEventArgs : EventArgs
    {
        //public static readonly HttpModuleRuningEventArgs Instance = new HttpModuleRuningEventArgs();
        private string requestedPath;
        /// <summary>
        /// 当前请求的Url
        /// </summary>
        public string RequestedPath
        {
            get
            {
                return requestedPath;
            }
            set
            {
                requestedPath = value;
            }
        }
        private string realUrl;
        /// <summary>
        /// 真实地址，如果在事件里将 IsStop 设置为true,并且RealUrl不为空，将定向到RealUrl
        /// </summary>
        public string RealUrl
        {
            get
            {
                return realUrl;
            }
            set
            {
                realUrl = value;
            }
        }

        private System.Web.HttpApplication app;

        public System.Web.HttpApplication App
        {
            get
            {
                return app;
            }
            set
            {
                app = value;
            }
        }
        private bool isstop;
        /// <summary>
        ///是否阻住当前程序执行下去
        /// </summary>
        public bool IsStop
        {
            get
            {
                return isstop;
            }
            set
            {
                isstop = value;
            }
        }
        //public HttpModuleRuningEventArgs()
        //{
        //}

        public HttpModuleRuningEventArgs(string _RequestedPath, System.Web.HttpApplication _App)
        {
            requestedPath = _RequestedPath;
            app = _App;
        }
    }
    #endregion

    #region 第三方登录插件登录后返回事件扩展
    public class LoginApiBackEventArgs : EventArgs
    {

        private string loginapitype;
        /// <summary>
        /// 标记各个登录接口，用来区分
        /// </summary>
        public string LoginApiType
        {
            get
            {
                return loginapitype;
            }
            set
            {
                loginapitype = value;
            }
        }


        public LoginApiBackEventArgs(string stype)
        {
            loginapitype = stype;
        }
    }
    #endregion


    #region 评价系统数据绑定前事件
    public class RemarkEventArgs : EventArgs
    {
        public string Where { get; set; }
        private string _Mark;
        /// <summary>
        /// Mark标记
        /// </summary>
        public string Mark
        {
            get
            {
                return _Mark;
            }
            set
            {
                _Mark = value;
            }
        }


        public RemarkEventArgs(string mark)
        {
            _Mark = mark;
        }
    }
    #endregion


    #region 订单宝提交事件,订单宝集成在站长工具模块，要使用请先安装站长工具模块
    public class OrderBoxEventArgs : EventArgs
    {
        ///// <summary>
        ///// 对应流程ID与值
        ///// </summary>
        //public Hashtable Datas { get; set; }
        //public int UserID { get; set; }
        //public string UserName { get; set; }
        //public int ServicerID { get; set; }
        //public int ServicerName { get; set; }
        //public int ServicerUserID { get; set; }
        //public string UserIP { get; set; }

        public List<CustomOrderInfo> Order { get; set; }

        public OrderBoxEventArgs(List<CustomOrderInfo> _Order)
        {
            Order = _Order;
        }
    }
    #endregion

    #region Wcf中的Rss调用前事件触发
    public class RssArgs : EventArgs
    {
        public int GetTop { get; set; }
        public int Gettype { get; set; }
        public int Classid { get; set; }
        public int SiteID { get; set; }
        public string Key { get; set; }

        public SyndicationFeed Feed { get; set; }

        public RssArgs(int _GetTop, int _Gettype, int _Classid, int _SiteID, SyndicationFeed _Feed, string _key)
        {
            GetTop = _GetTop;
            Gettype = _Gettype;
            Classid = _Classid;
            SiteID = _SiteID;
            Feed = _Feed;
            Key = _key;
        }
    }
    #endregion


    #region 分类头部 Title keywords description
    public class ClassMetaEventArgs : EventArgs
    {

        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
        public string SeoDes { get; set; }
        public int ClassID { get; set; }
        public int SiteID { get; set; }
        private bool _StopSytemMeta;
        /// <summary>
        /// 是否阻住系统的Meta
        /// </summary>
        public bool StopSytemMeta
        {
            get
            {
                return _StopSytemMeta;
            }
            set
            {
                _StopSytemMeta = value;
            }
        }
        private HttpContext _context;

        public HttpContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }
        public ClassMetaEventArgs(string _seotitle, string _seokeyword, string _seodes, int _classid, int _siteid, HttpContext _context)
        {
            SeoTitle = _seotitle;
            SeoKeyWord = _seokeyword;
            SeoDes = _seodes;
            ClassID = _classid;
            SiteID = _siteid;
            Context = _context;
        }
    }
    #endregion


    public class GotoPayEventArgs : EventArgs
    {

        //public string OrderNamber { get; set; }
        public long OrderNamber { get; set; }
        public decimal Money { get; set; }
        public string PayInfo { get; set; }
        public EbSite.Entity.Payment Payment { get; set; }
        public string PayKey { get; set; }
        public bool IsStop { get; set; }
        private HttpContext _context;

        public HttpContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }
        public GotoPayEventArgs(long _OrderNamber, decimal _Money, string _PayInfo, EbSite.Entity.Payment _Payment, string _PayKey, HttpContext _context)
        {
            OrderNamber = _OrderNamber;
            Money = _Money;
            PayInfo = _PayInfo;
            Payment = _Payment;
            PayKey = _PayKey;
            Context = _context;
        }
    }

    /// <summary>
    /// 在首页面载入之后
    /// </summary>
    public class IndexPageLoadEventArgs : EventArgs
    {   
        public int SiteID { get; set; }
        public System.Web.UI.Page Page { get; set; }
        public IndexPageLoadEventArgs( int _SiteID,System.Web.UI.Page _Page)
        {
            SiteID = _SiteID;   
            Page = _Page;
        }
    }

    /// <summary>
    /// 在个人后台面 载入之后
    /// </summary>
    public class UccIndexPageLoadEventArgs : EventArgs
    {

        public int UserID { get; set; }
        public System.Web.UI.Page Page { get; set; }
        public UccIndexPageLoadEventArgs(int _userid, System.Web.UI.Page _Page)
        {
            UserID = _userid;
            Page = _Page;
        }
    }

    public class ContentPageLoadEventArgs : EventArgs
    {

        public EbSite.Entity.NewsContent ContentModel { get; set; }
        public System.Web.UI.Page Page { get; set; }
        private HttpContext _context;
        public int SiteID { get; set; }
        public int ContentID { get; set; }
        public int ClassID { get; set; }
        public HttpContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }
        public ContentPageLoadEventArgs(EbSite.Entity.NewsContent _ContentModel, HttpContext _context, System.Web.UI.Page _Page, int _SiteID, int _ContentID, int _ClassID)
        {
            ContentModel = _ContentModel;
            Context = _context;
            Page = _Page;
            SiteID = _SiteID;
            ContentID = _ContentID;
            ClassID = _ClassID;
        }
    }

    public class ContentPageLoadingEventArgs : EventArgs
    {

        public System.Web.UI.Page Page { get; set; }
        private HttpContext _context;
        public int SiteID { get; set; }
        public int ContentID { get; set; }
        public int ClassID { get; set; }
        public HttpContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }
        public ContentPageLoadingEventArgs(HttpContext _context, System.Web.UI.Page _Page, int _SiteID, int _ContentID, int _ClassID)
        {
            Context = _context;
            Page = _Page;
            SiteID = _SiteID;
            ContentID = _ContentID;
            ClassID = _ClassID;
        }
    }

    public class ContentShowEventArgs : EventArgs
    {

        public System.Web.UI.Page Page { get; set; }
        private HttpContext _context;
        public int SiteID { get; set; }
        public int ContentID { get; set; }
        public int ClassID { get; set; }
        public string ShowInfo { get; set; }
        public ThemeType PageType { get; set; }
        public HttpContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }
        public ContentShowEventArgs(HttpContext _context, System.Web.UI.Page _Page, int _SiteID, int _ContentID, int _ClassID, string _ShowInfo, ThemeType _PageType)
        {
            Context = _context;
            Page = _Page;
            SiteID = _SiteID;
            ContentID = _ContentID;
            ClassID = _ClassID;
            ShowInfo = _ShowInfo;
            PageType = _PageType;
        }
    }

    /// <summary>
    /// 在分类页面载入之后
    /// </summary>
    public class ClassPageLoadEventArgs : EventArgs
    {

        public EbSite.Entity.NewsClass ClassModel { get; set; }
        public System.Web.UI.Page Page { get; set; }
        private HttpContext _context;
        public int SiteID { get; set; }
        public int ClassID { get; set; }
        public HttpContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }
        public ClassPageLoadEventArgs(EbSite.Entity.NewsClass _Model, HttpContext _context, System.Web.UI.Page _Page, int _SiteID, int _ClassID)
        {
            ClassModel = _Model;
            Context = _context;
            Page = _Page;
            SiteID = _SiteID;
            ClassID = _ClassID;
        }
    }
    /// <summary>
    /// 在分类页面载入之前
    /// </summary>
    public class ClassPageLoadingEventArgs : EventArgs
    {
        public System.Web.UI.Page Page { get; set; }
        private HttpContext _context;
        public int SiteID { get; set; }
        public int ClassID { get; set; }
        public HttpContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }
        public ClassPageLoadingEventArgs(HttpContext _context, System.Web.UI.Page _Page, int _SiteID, int _ClassID)
        {

            Context = _context;
            Page = _Page;
            SiteID = _SiteID;
            ClassID = _ClassID;
        }
    }


    #region 分类模板绑定rpGetSubClassList时触发,可以更改查询条件与排放
    /// <summary>
    /// 与ClassListLaodingEventArgs的区别在于，此为分类，SubClassBindingEventArgs为内容
    /// </summary>
    public class SubClassBindingEventArgs : EventArgs
    {
        /// <summary>
        /// 搜索输入的关键词
        /// </summary>
        public int ClassID { get; set; }
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Where { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string OrderBy { get; set; }
        /// <summary>
        /// 是否阻止系统绑定
        /// </summary>
        public bool IsStopBind { get; set; }

        public HttpContext Context { get; set; }
        /// <summary>
        /// 站点ID
        /// </summary>
        public int SiteID { get; set; }
        public SubClassBindingEventArgs(int _ClassID, string _Where, HttpContext _context, int _siteID, string _orderBy)
        {
            ClassID = _ClassID;
            Where = _Where;
            Context = _context;
            SiteID = _siteID;
            OrderBy = _orderBy;


        }
    }
    #endregion


    public class ClassRepeaterItemEventArgs : EventArgs
    {
        public HttpContext Context;
        public int SiteID { get; set; }
        public int ClassID { get; set; }
        public bool IsStop { get; set; }
        public RepeaterItemEventArgs CurrentRepeaterItemEventArgs;
        public ClassRepeaterItemEventArgs(RepeaterItemEventArgs _CurrentRepeaterItemEventArgs, HttpContext _Context, int _ClassID, int _SiteID)
            
        {
            Context = _Context;
            ClassID = _ClassID;
            SiteID = _SiteID;
            CurrentRepeaterItemEventArgs = _CurrentRepeaterItemEventArgs;

        }
    }


    public class MvcRouteHandlerEventArgs : EventArgs
    {
       
        /// <summary>
        /// 传进来的动作
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 自定义一个IHttpHandler，如果不为空，将请求此IHttpHandler
        /// </summary>
        /// <value>The custom handler.</value>
        public IHttpHandler CustomHandler { get; set; }
        public MvcRouteHandlerEventArgs(string _Action)
        {
            Action = _Action;

        }
    }

    public class TemCacheingEventArgs : EventArgs
    {

        //public int UserID { get; set; }
        public bool IsStop { get; set; }
        public TemPage.HtmlInfo HtmlInfo { get; set; }
        public HttpContext Context;
        public TemCacheingEventArgs(TemPage.HtmlInfo htmlInfo, HttpContext context)
        { 
            HtmlInfo = htmlInfo;
            Context = context;


        }
    }

}
