using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.ConfigsBase;
using EbSite.Base.EntityAPI;

namespace EbSite.Base.Configs.SysConfigs
{
    public class ConfigsInfo : IConfigInfo
    {
        private string _sMapPath;//安装目录
        private string _DomainName;//虚拟路径
        //private Guid _IndexTemID;//首页模板ID
        private LinkType _enLinkType;   //是否启用html
        //private string _sSiteName;        //设置网站名称
        private string _Copyright;//底部版权
        //private string _IndexKeyWord;
        private string _UserPath = "user/";           // 用户系统的存放路径
        private string _AdminPath = "adminht/";      //后台系统的存放路径
        private string _IISPath ="/"; //目录
        private string _CookieDomain = "";
        private int _IsCookieOrSession = 0;
        //private string _Passwordkey = "P4F44N0D04"; //用户密码Key

        //private bool _AuditingLinks = false;
        private bool _AuditingContent = false;
        private bool _AuditingComment = false;
        private bool _IsOpenSafeCoder = false;

        private bool _IsOpenAdminLoginLog = true;

        private bool _IsOpenAppLog = true;

        private int _ErrLoginNum = 3;

        private int _HitsUpdateTimeLength = 30;

        private int _LoginExpires = 15;

        private PassWordType _PassType = PassWordType.MD5;
        private string _ContentFileds_Widget = "";      //默认部件查询内容字段
        public bool IsOpenFileServer { get; set; }
        public string FileServerUrl { get; set; }
        private string _Culture = "";
        /// <summary>
        /// 是否开启图片防盗
        /// </summary>
        public bool IsOpenPickproofLinkOfPic { get; set; }
        /// <summary>
        /// 图片防盗的后缀文件,逗号分开
        /// </summary>
        public string PickproofLinkPreOfPic { get; set; }
        
        /// <summary>
        /// 是否开启文件防盗
        /// </summary>
        public bool IsOpenPickproofLinkOfFile { get; set; }
        /// <summary>
        /// 文件防盗的后缀,逗号分开
        /// </summary>
        public string PickproofLinkPreOfFile { get; set; }

        private int _WebServiceRequestModel = 0;
        /// <summary>
        /// web服务的访问模式,0不限制，1允许同个域名下访问,2允许同个IP下访问,3允许访问的IP列表
        /// </summary>
        public int WebServiceRequestModel
        {
            get
            {
                return _WebServiceRequestModel;
            }
            set
            {
                _WebServiceRequestModel = value;
            }
        }

        private string _WebServiceSafeCode = "ebsite";
        /// <summary>
        /// Web服务安全码，在客户端调用时要设置此码方可调用
        /// </summary>
        public string WebServiceSafeCode
        {
            get
            {
                return _WebServiceSafeCode;
            }
            set
            {
                _WebServiceSafeCode = value;
            }
        }
        #region SearchEngine 多站点存储处理
        private List<EbSite.Base.EntityAPI.ListItemSimple> _SearchEngine = new List<ListItemSimple>();
        public List<EbSite.Base.EntityAPI.ListItemSimple> SearchEngine
        {
            get { return _SearchEngine; }
            set { _SearchEngine = value; }
        }
        private int IsHaveSearchEngine(ListItemSimple md)
        {
            int index = 0;

            foreach (ListItemSimple li in _SearchEngine)
            {
                if (li.Value.Equals(md.Value))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }
        public void AddSearchEngine(ListItemSimple md)
        {
            int index = IsHaveSearchEngine(md);
            if (index > -1)
            {
                _SearchEngine.RemoveAt(index);
            }
            _SearchEngine.Add(md);
        }

        public string GetSearchEngineType(int SiteID)
        {
            string SearchEngine = string.Empty;
            foreach (ListItemSimple li in _SearchEngine)
            {
                if (li.Value.Equals(SiteID.ToString()))
                {
                    SearchEngine = li.Text;
                    break;
                }
               
            }
            return SearchEngine;
        }

        #endregion
        

        /// <summary>
        /// 当WebServiceRequestModel为3时起作用
        /// </summary>
        public string WebServiceIPS { get; set; }
        public List<string> WebServiceIPList { get; set; }
        public List<string> UserlevaNoCheck { get; set; }
        public List<string> UserlevaUpload { get; set; }

        public int PostTimeOut { get; set; }

        //private int _CurrentSiteID = 1;
        ///// <summary>
        ///// 在后台切换时，记录当前切换的后台所选站点ID，只适用于后台，前台要在url里传入
        ///// </summary>
        //public int CurrentSiteID
        //{
        //    get
        //    {
        //        return _CurrentSiteID;
        //    }
        //    set
        //    {
        //        _CurrentSiteID = value;
        //    }
        //}

        /// <summary>
        /// 本化设置
        /// </summary>
        public string Culture
        {
            get
            {
                return _Culture;
            }
            set
            {
                _Culture = value;
            }
        }

        private bool _IsOpenSql;
        /// <summary>
        /// 是否开户sql跟踪
        /// </summary>
        public bool IsOpenSql
        {
            get
            {
                return _IsOpenSql;
            }
            set
            {
                _IsOpenSql = value;
            }
        }

        private string _EncryptionKey = "ebsite";
        /// <summary>
        /// 本站加密密钥，用在需要加密的地方，如cookie等
        /// </summary>
        public string EncryptionKey
        {
            get
            {
                return _EncryptionKey;
            }
            set
            {
                _EncryptionKey = value;
            }
        }

        //private bool _IsLongClass = false;
        ///// <summary>
        ///// 是否大型分类，大型分类将分页,不采用树形列表，以达到快速访问
        ///// </summary>
        //public bool IsLongClass
        //{
        //    get
        //    {
        //        return _IsLongClass;
        //    }
        //    set
        //    {
        //        _IsLongClass = value;
        //    }
        //}
        //public string ContentFileds_Widget
        //{
        //    get
        //    {
        //        return _ContentFileds_Widget;
        //    }
        //    set
        //    {
        //        _ContentFileds_Widget = value;
        //    }
        //}

        private bool _DisableAutoUpdatePlugin;
        /// <summary>
        /// 是关闭插件自动升级插件
        /// </summary>
        public bool DisableAutoUpdatePlugin
        {
            get
            {
                return _DisableAutoUpdatePlugin;
            }
            set
            {
                _DisableAutoUpdatePlugin = value;
            }
        }
        //private string _ContentFileds_So = "";      //默认搜索查询内容字段

        //public string ContentFileds_So
        //{
        //    get
        //    {
        //        return _ContentFileds_So;
        //    }
        //    set
        //    {
        //        _ContentFileds_So = value;
        //    }
        //}

        //private string _ContentFileds_Tagv = "";      //默认标签搜索查询内容字段

        //public string ContentFileds_Tagv
        //{
        //    get
        //    {
        //        return _ContentFileds_Tagv;
        //    }
        //    set
        //    {
        //        _ContentFileds_Tagv = value;
        //    }
        //}

        //private string _ClassFileds = "";      //默认查询分类字段

        //public string ClassFileds
        //{
        //    get
        //    {
        //        return _ClassFileds;
        //    }
        //    set
        //    {
        //        _ClassFileds = value;
        //    }
        //}

        //private string _AdminSearchClassFileds = "";      
        ///// <summary>
        ///// 后台分类搜索字段 格式为 字段名称1|显示名称1,字段名称1|显示名称1
        ///// </summary>
        //public string AdminSearchClassFileds
        //{
        //    get
        //    {
        //        return _AdminSearchClassFileds;
        //    }
        //    set
        //    {
        //        _AdminSearchClassFileds = value;
        //    }
        //}
        //private string _AdminSearchContentFileds = "";
        ///// <summary>
        ///// 后台内容搜索字段 格式为 字段名称1|显示名称1,字段名称1|显示名称1
        ///// </summary>
        //public string AdminSearchContentFileds
        //{
        //    get
        //    {
        //        return _AdminSearchContentFileds;
        //    }
        //    set
        //    {
        //        _AdminSearchContentFileds = value;
        //    }
        //}

        /// <summary>
        /// 密码的加密模式
        /// </summary>
        public PassWordType PassType
        {
            get
            {
                return _PassType;
            }
            set
            {
                _PassType = value;
            }
        }

        /// <summary>
        /// 用户默认登录状态保存时长
        /// </summary>
        public int LoginExpires
        {
            get
            {
                return _LoginExpires;
            }
            set
            {
                _LoginExpires = value;
            }
        }
        /// <summary>
        /// 是否开启个人空间
        /// </summary>
        public bool IsOpenUserHome { get; set; }

        /// <summary>
        /// 是否开启系统异常友好提示
        /// </summary>
        public bool IsErrFriend { get; set; }
        /// <summary>
        /// 是否开启系统异常日志记录
        /// </summary>
        public bool IsOpenAppLog
        {
            get
            {
                return _IsOpenAppLog;
            }
            set
            {
                _IsOpenAppLog = value;
            }
        }

        /// <summary>
        /// 是否开启管理员登录日志
        /// </summary>
        public bool IsOpenAdminLoginLog
        {
            get
            {
                return _IsOpenAdminLoginLog;
            }
            set
            {
                _IsOpenAdminLoginLog = value;
            }
        }

        /// <summary>
        /// 限制错误登录次数上限,适用于管理员登录与用户登录
        /// </summary>
        public int ErrLoginNum
        {
            get
            {
                return _ErrLoginNum;
            }
            set
            {
                _ErrLoginNum = value;
            }
        }

        /// <summary>
        /// 是否开始验证码
        /// </summary>
        public bool IsOpenSafeCoder
        {
            get
            {
                return _IsOpenSafeCoder;
            }
            set
            {
                _IsOpenSafeCoder = value;
            }
        }

        private bool _IsOpenSafeCoder_PL;
        /// <summary>
        /// 是否开启评论验证码
        /// </summary>
        public bool IsOpenSafeCoder_PL
        {
            get
            {
                return _IsOpenSafeCoder_PL;
            }
            set
            {
                _IsOpenSafeCoder_PL = value;
            }
        }

        /// <summary>
        /// 是否审核评论
        /// </summary>
        public bool AuditingComment
        {
            get
            {
                return _AuditingComment;
            }
            set
            {
                _AuditingComment = value;
            }
        }

        /// <summary>
        /// 是否审核内容
        /// </summary>
        public bool AuditingContent
        {
            get
            {
                return _AuditingContent;
            }
            set
            {
                _AuditingContent = value;
            }
        }

        ///// <summary>
        ///// 是否审核友情连接
        ///// </summary>
        //public bool AuditingLinks
        //{
        //    get
        //    {
        //        return _AuditingLinks;
        //    }
        //    set
        //    {
        //        _AuditingLinks = value;
        //    }
        //}
        /// <summary>
        /// 访问统计(点击率)防作弊策略,0为cookie,1为session
        /// </summary>
        public int IsUpdateHisCookieOrSession
        {
            get
            {
                return _IsCookieOrSession;
            }
            set
            {
                _IsCookieOrSession = value;
            }
        }
        /// <summary>
        /// 访问统计(点击率)批量更新时长
        /// </summary>
        public int HitsUpdateTimeLength
        {
            get
            {
                return _HitsUpdateTimeLength;
            }
            set
            {
                _HitsUpdateTimeLength = value;
            }
        }
        ///// <summary>
        ///// 用户密码Key
        ///// </summary>
        //public string Passwordkey
        //{
        //    get
        //    {
        //        return _Passwordkey;
        //    }
        //    set
        //    {
        //        _Passwordkey = value;
        //    }
        //}
        /// <summary>
        /// Cookie的域
        /// </summary>
        public string CookieDomain
        {
            get
            {
                return _CookieDomain;
            }
            set
            {
                _CookieDomain = value;
            }
        }

        private bool _IsMobileRedirect = false;
        public bool IsMobileRedirect
        {
            get { return _IsMobileRedirect; }
            set { _IsMobileRedirect = value; }
        }
        /// <summary>
        /// 用户系统的存放路径
        /// </summary>
        public string UserPath
        {
            get
            {
                return _UserPath;
            }
            set
            {
                _UserPath = value;
            }
        }

        private int _MaxThreadForPool = 5;
        /// <summary>
        /// 线程池中的最大线程数
        /// </summary>
        public int MaxThreadForPool
        {
            get
            {
                return _MaxThreadForPool;
            }
            set
            {
                _MaxThreadForPool = value;
            }
        }

        /// <summary>
        /// 后台系统的存放路径
        /// </summary>
        public string AdminPath
        {
            get
            {
                return _AdminPath;
            }
            set
            {
                _AdminPath = value;
            }
        }
        /// <summary>
        /// cms系统的安装目录,如果网站为"/",如果说是虚拟目录为请填写虚拟目录路径
        /// </summary>
        public string IISPath
        {
            get
            {
                return _IISPath;
            }
            set
            {
                _IISPath = value;
            }
        }
        /// <summary>
        /// 是否加密数据库连接串
        /// </summary>
        public bool IsEndDataBaseStr { get; set; }
        private bool _IsOpen404Log = true;
        public bool IsOpen404Log
        {
            get
            {
                return _IsOpen404Log;
            }
            set
            {
                _IsOpen404Log = value;
            }
        }
        /// <summary>
        /// 底部版权
        /// </summary>
        public string  Copyright
        {
            get
            {
                return _Copyright;
            }
            set
            {
                _Copyright = value;
            }
        }
        ///// <summary>
        ///// 首页关键词
        ///// </summary>
        //public string IndexKeyWord
        //{
        //    get
        //    {
        //        return _IndexKeyWord;
        //    }
        //    set
        //    {
        //        _IndexKeyWord = value;
        //    }
        //}
        //private string _IndexDescription;
        ///// <summary>
        ///// 首页描述
        ///// </summary>
        //public string IndexDescription
        //{
        //    get
        //    {
        //        return _IndexDescription;
        //    }
        //    set
        //    {
        //        _IndexDescription = value;
        //    }
        //}
        //private string _IndexTitle;
        ///// <summary>
        ///// 首页标题
        ///// </summary>
        //public string IndexTitle
        //{
        //    get
        //    {
        //        return _IndexTitle;
        //    }
        //    set
        //    {
        //        _IndexTitle = value;
        //    }
        //}

        ///// <summary>
        ///// 设置网站名称
        ///// </summary>
        //public string sSiteName
        //{
        //    get
        //    {
        //        return _sSiteName;
        //    }
        //    set
        //    {
        //        _sSiteName = value;
        //    }
        //}

        ///// <summary>
        ///// 是否启用html,值为html表示是,为aspx表示动态页面
        ///// </summary>
        //public LinkType Linktype
        //{
        //    get
        //    {
        //        return _enLinkType;
        //    }
        //    set
        //    {
        //        _enLinkType = value;
        //    }
        //}
        /// <summary>
        /// 是否允许申请友情连接
        /// </summary>
        public bool IsAllowApplyFrdLink { get; set; }
        /// <summary>
        /// 友情连接简介
        /// </summary>
        public string FrdLinkDemo { get; set; }
        
        /// <summary>
        /// 安装目录
        /// </summary>
        public string sMapPath
        {
            get
            {
                return _sMapPath;
            }
            set
            {
                _sMapPath = value;
            }
        }
        /// <summary>
        /// 域名
        /// </summary>
        public string DomainName 
        {
            get
            {
                return _DomainName;
            }
            set
            {
                _DomainName = value;
            }
        }
        ///// <summary>
        ///// 首页模板ID
        ///// </summary>
        //public Guid IndexTemID
        //{
        //    get
        //    {
        //        return _IndexTemID;
        //    }
        //    set
        //    {
        //        _IndexTemID = value;
        //    }
        //}

        private string _UploadPath;
        /// <summary>
        /// 文件的上传目录
        /// </summary>
        public string UploadPath
        {
            get
            {
                return _UploadPath;
            }
            set
            {
                _UploadPath = value;
            }
          
        }

        public string EmailSendPlugin { get; set; }

        public string MobileMsgSendPlugin { get; set; }

        /// <summary>
        /// 缓存模式
        /// </summary>
        public string CacheBll { get; set; }

        private bool _IsAddSearchKeyword = true;
        /// <summary>
        /// 是否开户搜索关键词统计
        /// </summary>
        public bool IsAddSearchKeyword
        {
            get
            {
                return _IsAddSearchKeyword;
            }
            set
            {
                _IsAddSearchKeyword = value;
            }
        }

        /// <summary>
        /// 删除模块时是否同时删除项目文件
        /// </summary>
        public bool DelModuleAndFile { get; set; }
        ///// <summary>
        ///// 网站需要加密的地方所用的密钥
        ///// </summary>
        //public string PassKey { get; set; }

        private bool _IsCacheJsCss = true;
        /// <summary>
        /// 是否缓存JS与CSS
        /// </summary>
        public bool IsCacheJsCss
        {
            get
            {
                return _IsCacheJsCss;
            }
            set
            {
                _IsCacheJsCss = value;
            }
        }
        /// <summary>
        /// ip转换区域名的程序插件
        /// </summary>
        public string IpToAreaPluginName { get; set; }
        /// <summary>
        /// 快递查询插件名称
        /// </summary>
        public string KuaiDiPluginName { get; set; }

        private bool _EnableHttpCompression = false;
        /// <summary>
        /// 是否开启http压缩
        /// </summary>
        public bool EnableHttpCompression
        {
            get
            {
                return _EnableHttpCompression;
            }
            set
            {
                _EnableHttpCompression = value;
            }
        }

        private int _EnableCssCompression = 0;
        /// <summary>
        /// 是否开启JsCss合并与压缩
        /// </summary>
        public int EnableCssCompression
        {
            get
            {
                return _EnableCssCompression;
            }
            set
            {
                _EnableCssCompression = value;
            }
        }
        private int _EnableJsCompression = 0;
        /// <summary>
        /// 是否开启JsCss合并与压缩
        /// </summary>
        public int EnableJsCompression
        {
            get
            {
                return _EnableJsCompression;
            }
            set
            {
                _EnableJsCompression = value;
            }
        }


        private int _MEnableJsCompression = 1;
        /// <summary>
        /// 是否开启JsCss合并与压缩
        /// </summary>
        public int MEnableJsCompression
        {
            get
            {
                return _MEnableJsCompression;
            }
            set
            {
                _MEnableJsCompression = value;
            }
        }

        private bool _IsAutoUpdateDomain = true;
        /// <summary>
        /// 是否自动更新域名
        /// </summary>
        public bool IsAutoUpdateDomain
        {
            get
            {
                return _IsAutoUpdateDomain;
            }
            set
            {
                _IsAutoUpdateDomain = value;
            }
        } 


}

    public enum LinkType
    {
        /// <summary>
        /// 手动静态
        /// </summary>
        Html=0,
        /// <summary>
        /// 自动静态
        /// </summary>
        AutoHtml = 1,
        /// <summary>
        /// 动态面页
        /// </summary>
        Aspx=2,
        /// <summary>
        /// 自动静态
        /// </summary>
        AspxRewrite=3
        
    }
    /// <summary>
    /// 密码加密格式
    /// </summary>
    public enum PassWordType
    {
        /// <summary>
        /// 采用md5加密
        /// </summary>
        MD5 = 0,
        /// <summary>
        /// 采用哈希加密
        /// </summary>
        Hashed= 1,
        /// <summary>
        /// 采用两次md5加密
        /// </summary>
        MD5MD5 = 2,
        /// <summary>
        /// 使用一次md5加密后，加使用一次Hashed加密
        /// </summary>
        MD5Hashed = 3

    }
}
