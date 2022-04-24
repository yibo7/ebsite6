using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Security;
using Amib.Threading;
using EbSite.Base.EntityAPI;
using EbSite.Base.Modules;
using EbSite.BLL;
using EbSite.BLL.Email;
using EbSite.BLL.GetLink;
using EbSite.BLL.ModulesBll;
using EbSite.BLL.User;
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.Data.User.Interface;
using EbSite.Entity;
using EbSite.Entity.Module;
using Sites = EbSite.Entity.Sites;

namespace EbSite.Base
{
    /// <summary>
    /// 为插件提供系统常用的信息
    /// </summary>
    public partial class Host 
    {
        /// <summary>
        /// 获取文件上传代码，这个可以不用用户控件
        /// </summary>
        /// <param name="selfilebox">选择器</param>
        /// <param name="ext">上传文件后缀，如jpg,jpeg,gif,png</param>
        /// <param name="folder">上传目录，会在默认目录创建此目录</param>
        /// <param name="size">上传文件大小限制，单位K,默认1024k</param>
        /// <param name="width">上传图片的宽</param>
        /// <param name="height">上传图片的高</param>
        /// <returns></returns>
        public string GetUploadStr(string selfilebox, string ext, string folder, int size)
        {
            string Temp = @"
            var ImgSingleUploadObj = new ImgSingleUpload();
            ImgSingleUploadObj.ext = '{0}';
            ImgSingleUploadObj.folder = '{1}';
            ImgSingleUploadObj.userIdEncode = '{2}';
            
            ImgSingleUploadObj.valstr = '{3}';
            ImgSingleUploadObj.btnSelFiles = '{4}';          
            ImgSingleUploadObj.size = {5};
            ImgSingleUploadObj.Init();
            ";
            string folderendEncode = HttpContext.Current.Server.UrlEncode(EbSite.Base.Host.Instance.EncodeByKey(folder));
            int UserId = EbSite.Base.Host.Instance.UserID;
            string sUID = HttpContext.Current.Server.UrlEncode(
                EbSite.Base.Host.Instance.EncodeByKey(string.Concat(UserId, ",",
                    EbSite.Base.Host.Instance.OnlineID)));
            string ValStr =
                EbSite.Base.Host.Instance.EncodeByMD5(string.Concat(folder, size,
                    Base.Host.Instance.EncodeByKey(ext), EbSite.Base.Host.Instance.OnlineID, UserId));
            return String.Format(Temp, ext, folderendEncode, sUID, ValStr, selfilebox,  size);

        }
        public object Write404LogMsg(object msg)
        {
            string LogContent = msg as string;
            EbSite.BLL.Web040Log.InsertLogs("发生404页面，来源:人工404", LogContent);
            return 1;
        }
        public object Write404Log(object obj)
        {
            HttpContext _HttpContext = (HttpContext)obj;

            string hostIP = "";
            string path = "";
            string useragent = string.Empty;
            string fullurl = "";


            //string lLog = string.Empty;
            if (!Equals(_HttpContext, null))
            {
                try
                {
                    path = _HttpContext.Request.RawUrl;
                    hostIP = _HttpContext.Request.ServerVariables["REMOTE_ADDR"];
                    useragent = _HttpContext.Request.ServerVariables["http_user_agent"];

                    fullurl = _HttpContext.Request.Url.AbsoluteUri;
                }
                catch (Exception e)
                {


                }

                EbSite.BLL.Web040Log.InsertLogs(string.Concat("发生404页面，来源:", path), string.Format("IP{0}\n来源:{1}\nUserAgent:{2}", hostIP, fullurl, useragent));

            }
            else
            {
                EbSite.BLL.Web040Log.InsertLogs("errhttp.aspx发生错误", "HttpContext 为null");
            }
            return 1;
        }
        public string GetMobileContent(string PCContent)
        {
            //-ebbaseimg.jpg
            //return  Regex.Replace(PCContent, "-ebbaseimg.png", "-ebmiddleimg.png", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //return PCContent.Replace("-ebbaseimg", "-ebmiddleimg");
            //不替换gif,所以要分开来替换
            PCContent = Regex.Replace(PCContent, "-ebbaseimg.png", "-ebmiddleimg.png", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            PCContent = Regex.Replace(PCContent, "-ebbaseimg.jpg", "-ebmiddleimg.jpg", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            PCContent = Regex.Replace(PCContent, "-ebbaseimg.jpeg", "-ebmiddleimg.jpeg", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            PCContent = Regex.Replace(PCContent, "-ebbaseimg.jpeg", "-ebmiddleimg.bmp", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            return PCContent;
        }
        /// <summary>
        /// 将一个文件按回车分割成数组
        /// </summary>
        /// <param name="str">源字符</param>
        /// <returns></returns>
        public string[] HuiCheSplit(string str)
        {
            return Core.Strings.GetString.SplitString(str, "\r\n");//\r\n
        }
        /// <summary>
        /// 获取当前站点ID，要求当前页面的url有参数site,没有参数site将获取后台默认站点
        /// </summary>
        public int GetSiteID
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    if (!string.IsNullOrEmpty(HttpContext.Current.Request["site"]))
                    {
                        
                        return int.Parse(HttpContext.Current.Request["site"]);
                    }
                   
                    //Configs.SysConfigs.ConfigsControl.Instance.AdminPath
                    if (HttpContext.Current.Request.Path.ToLower().IndexOf(Configs.SysConfigs.ConfigsControl.Instance.AdminPath.ToLower()) > 0)
                    {
                        string sSiteId = Core.Utils.GetCookie("adminsiteid");// HttpContext.Current.Session["adminsiteid"] as string;
                        if (!string.IsNullOrEmpty(sSiteId))
                            return Core.Utils.StrToInt(sSiteId, 1);

                        //if (this.UserID > 0)
                        //{
                        //  return  EbSite.BLL.AdminUser.GetCurrentSiteID(this.UserID);
                        //}
                        //else
                        //{
                        //    return 1;
                        //}

                    }
                    //else
                    //{
                    //    return 1;
                    //}
                }
                //else
                //{
                //    return 1;
                //}
               return 1;
                //return EbSite.BLL.Sites.Instance.GetFirstEntity.id;
            }
        }
        /// <summary>
        /// 获取来路
        /// </summary>
        public  string GetReurl
        {
            get
            {
                return HttpContext.Current.Request["ru"];
            }
        }
        /// <summary>
        /// 获取当前站点对象
        /// </summary>
        public EbSite.Entity.Sites CurrentSite
        {
            get
            {

                

               return  EbSite.BLL.Sites.Instance.GetEntity(GetSiteID);
              
            }
        }
        /// <summary>
        /// 获取某个站点对象
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <returns></returns>
        public EbSite.Entity.Sites GetSite(int siteid)
        {
            return EbSite.BLL.Sites.Instance.GetEntity(siteid);
        }
        /// <summary>
        /// 获取当前站点的PC版皮肤相对路径
        /// </summary>
        public string ThemePath
        {
            get
            {

                return CurrentSite.ThemesPath("");

            }
        }
        /// <summary>
        /// 获取当前站点的移动版皮肤相对路径
        /// </summary>
        public string MThemesPath
        {
            get
            {

                return CurrentSite.MGetCurrentThemesPath();

            }
        }
        
        /// <summary>
        /// 获取主站点对象
        /// </summary>
        public EbSite.Entity.Sites MainSite
        {
            get
            {
                return EbSite.BLL.Sites.Instance.GetEntity(1);

            }
        }
        /// <summary>
        /// 对字符进行md5加密
        /// </summary>
        /// <param name="str">在加密的字符串</param>
        /// <returns></returns>
        public string EncodeByMD5(string str)
        {
            return Utils.MD5(str);
        }
        /// <summary>
        /// 使用ebsite设置的密钥加密
        /// </summary>
        /// <param name="str">要加密的字符</param>
        /// <returns></returns>
        public string EncodeByKey(string str)
        {
            return DES.Encode(str, Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);
        }
        /// <summary>
        /// 使用ebsite设置的密钥解密
        /// </summary>
        /// <param name="str">要解密的字符</param>
        /// <returns></returns>
        public string DecodeByKey(string str)
        {
            return DES.Decode(str, Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);
        }
        /// <summary>
        /// 获取网站安装的虚拟目录
        /// </summary>
        public string IISPath
        {
            get
            {
                return Base.AppStartInit.IISPath;
            }
        }
        /// <summary>
        /// 获取当前网站域名
        /// </summary>
        public string Domain
        {
            get
            {
                return EbSite.Base.AppStartInit.DomainName;
            }
        }
        /// <summary>
        /// 获取网站安装的绝对目录
        /// </summary>
        public string sMapPath
        {
            get
            {
                return Configs.SysConfigs.ConfigsControl.Instance.sMapPath;
            }
        }
     

        /// <summary>
        /// 获取CMS数据库提供程序名称
        /// </summary>
        public string GetCMSDbType
        {
            get
            {
                return Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType;
            }
        }
        /// <summary>
        /// 获取用户数据库提供程序名称
        /// </summary>
        public string GetUserDbType
        {
            get
            {
                return Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerTypeUser;
            }
        }
        /// <summary>
        /// 定向到一个提示页面
        /// </summary>
        /// <param name="Title">提示标题</param>
        /// <param name="Info">提示内容</param>
        public void Tips(string Title, string Info)
        {
            Tips(Title, Info, "");
        }
       
        /// <summary>
        /// 检测一个游客是否在线
        /// </summary>
        /// <param name="OnlineID"></param>
        /// <returns></returns>
        public bool IsOnlineVisitor(int OnlineID)
        {
            return DbProviderUser.GetInstance().UserOnline_ExistsUser(OnlineID);
        }

        public void Tips(string Title, string Info, string sUrl)
        {
            AppStartInit.TipsPageRender(Title, Info, sUrl);
        }
        /// <summary>
        /// 发送一条站内信息
        /// </summary>
        /// <param name="Title">信息标题</param>
        /// <param name="Msg">信息内容</param>
        /// <param name="RecUserID">接收人ID</param>
       /// <param name="IsHtml">是否html,如果是对外开放，一定要设置为fase,让系统自动过滤html,否则会有脚本注入情况</param>
        public void SendSysMsg(string Title,string Msg,int RecUserID,bool IsHtml)
        {
            EbSite.BLL.Msg md = new Msg();
            md.SendDate = DateTime.Now;
            md.IsNewMsg = true;
            md.Sender = string.IsNullOrEmpty(UserName) ? "游客" : UserName;
            md.SenderNiName = UserNiName;
            md.SenderUserID = UserID;
            md.RecipientUserID = RecUserID;
            md.FolderType = 1;
            if (IsHtml)
            {
              
                md.MsgContent = Msg;

                
            }
            else
            {
                md.MsgContent = Core.Utils.EncodeHtml(Msg);
                
            }
            if (!string.IsNullOrEmpty(Title))
            {
                md.Title = Core.Strings.GetString.NoHtml(Title);
            }
            else
            {
                md.Title = Core.Strings.GetString.CutLen(GetString.NoHtml(md.MsgContent), 50);
            }
            
           
            md.Save();

        }
        /// <summary>
        /// 发送一条站内信息
        /// </summary>
        /// <param name="Msg">短消息内容</param>
        /// <param name="RecUserID">接收用户ID</param>
        /// <param name="IsHtml">是否HTML格式</param>
        public void SendSysMsg( string Msg, int RecUserID, bool IsHtml)
        {
            SendSysMsg("", Msg, RecUserID, IsHtml);
        }

        /// <summary>
        /// 当前线程发送email
        /// </summary>
        /// <param name="md">邮件内容实体</param>
        /// <param name="Atta">附件地址</param>
        public void SendEmail(EmailModel md, string Atta)
        {
          EbSite.Base.Plugin.Factory.SendEmail(md, Atta);
           
        }

        /// <summary>
        /// 在线程池中发送email
        /// </summary>
        /// <param name="email">要接收EMAIL的地址</param>
        /// <param name="title">email标题</param>
        /// <param name="body">email内容</param>
        public void SendEmailPool(string email, string title, string body)
        {
            EmailBLL.SendEmail(email, title, body);
        }
        /// <summary>
        /// 给指定的用户ID发送Email,前提是这个用户注册时填写了email
        /// </summary>
        /// <param name="UserID">要发送的用户ID</param>
        /// <param name="title">email标题</param>
        /// <param name="body">email内容</param>
        public void SendEmailPoolByUserID(int UserID, string title, string body)
        {
            Thread th = new Thread(() =>
                {
                    string email =  this.EBMembershipInstance.Users_GetEmail(UserID);
                    if (!string.IsNullOrEmpty(email))
                    {
                        SendEmailPool(email, title, body);
                    }
                    

                });
            th.Start();
        }


        /// <summary>
        /// 发送一条手机短信
        /// </summary>
        /// <param name="Msg">短信内容</param>
        /// <param name="MobiNumber">手机号码</param>
        /// <param name="UserName">发送人帐号</param>
        public void SendMobileMsg(string Msg, string MobiNumber, string UserName)
        {
            Plugin.Factory.SendMobile(Msg, MobiNumber, UserName);
        }
        public void SendMobileMsgToPool(string MobiNumber,string Msg)
        {
            KeyValuePair<string, string> kv = new KeyValuePair<string, string>(MobiNumber, Msg); 
            IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(OnSendMobileMsgToPool), kv);
             
        }

        private  object OnSendMobileMsgToPool(object model)
        {
            KeyValuePair<string, string> kv = (KeyValuePair < string, string>) model;
            SendMobileMsg(kv.Value, kv.Key,"");
            return 1;
        }

        /// <summary>
            /// 加密一个密码
            /// </summary>
            /// <param name="sPass"></param>
            /// <returns></returns>
            public string PassWordEncode(string sPass)
        {
            return EbSite.BLL.User.UserIdentity.PassWordEncode(sPass);
        }
        /// <summary>
        /// 添加一个扩展日志
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Msg">日志内容</param>
        public void InsertLog(string Title, string Msg)
        {
            EbSite.Entity.Logs md = new EbSite.Entity.Logs();

            md.Title = Title;
            md.Description = Msg;
            md.AddDate = DateTime.Now;
            md.IP = Core.Utils.GetClientIP();
            EbSite.BLL.CusttomLog.InsertLogs(md);
        }
        /// <summary>
        /// 获取一个提示页面的url
        /// </summary>
        /// <param name="Tips">要提示的内容</param>
        /// <returns></returns>
        public string GetTips(string Tips)
        {
            return string.Concat(IISPath, "ebtips.aspx?info=", Tips);
        }


    }
}
