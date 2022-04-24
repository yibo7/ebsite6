using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.EntityAPI;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using QConnectSDK;
using QConnectSDK.Context;
using QConnectSDK.Models;

namespace EbSite.Plugin.UserLoginApi
{
    public class UserInfo : QConnectSDK.Models.Fan
    {

    }
    [Extension("第三方登录插件QQ", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class QQ : IUserLoginApi
    {
        #region 变量

        private string appKey;
        private string appSecret;
        private QConnectSDK.Config.QQConnectConfig qqConfig = new QConnectSDK.Config.QQConnectConfig();

        /// <summary>
        /// 
        /// </summary>
        public string ShowName
        {
            get
            {
                return "QQ微博";
            }
        }

        /// <summary>
        /// 登录接口的名称,前方可能通过这个名称获取相应的实例
        /// </summary>
       public string ApiName 
        {  
            get
            {
                return "QQ";
            } 
        }

        #endregion 变量

        #region 微博操作方法

       /// <summary>
        /// 发送一条微薄信息
        /// </summary>
        /// <param name="sContent">微博内容(140字以内)</param>
       /// <param name="strTokenOpenID">授权码,OpenID(中间用逗号隔开)</param>
       public void SendMsg(string sContent, string strTokenOpenID)
        {
            QOpenClient qqAPI = GetClient(strTokenOpenID);
            QzoneBase qzResult = qqAPI.AddWeibo(sContent, HttpContext.Current.Request.UserHostAddress, "");
        }

       /// <summary>
       /// 关注一个用户
       /// </summary>
       /// <param name="name">用户名称</param>
       /// <param name="fopenIds">用户ID</param>
       public void GuanZhu(string name, string fopenIds, string code)
        {
            QOpenClient qzone = new QOpenClient(qqConfig, code, "");
            qzone.AddIdol(name, fopenIds);
        }

        /// <summary>
        /// 获取一个用户的信息
        /// </summary>
        /// <returns></returns>
       public MembershipUserEb GetUserInfo(string code)
        {
            return null;
        }
        /// <summary>
        /// 获取我的粉丝
        /// </summary>
       /// <param name="strTokenOpenID">授权码,OpenID(中间用逗号隔开)</param>
        /// <returns></returns>
       public List<MembershipUserEb> GetFanslist(string strTokenOpenID, int pageCount, int pageSize,out int iCount)
       {
           iCount = 0;
           QOpenClient qqAPI = GetClient(strTokenOpenID);

           if (qqAPI == null)
           {
               return null;
           }
           //获取我收听的人数
           //User user=qqAPI.GetCurrentUser();
           WeiboUser weioUser = qqAPI.GetWeiboUserInfo();
           if (weioUser != null && weioUser.Data != null)
           {
               iCount = weioUser.Data.Fansnum;
           }

           WeiboFan idoData = qqAPI.GetFansList(pageCount, pageCount * pageSize);

           if (idoData != null && idoData.Data != null && idoData.Data.Info != null)
           {
               List<Fan> fanList = idoData.Data.Info;
               return ObjPriseObj(fanList);
           }
           return null;
       }
        /// <summary>
        /// 获取我收听人的列表
        /// </summary>
       /// <param name="strTokenOpenID">授权码,OpenID(中间用逗号隔开)</param>
        /// <returns></returns>
       public List<MembershipUserEb> GetIdollist(string strTokenOpenID, int pageCount, int pageSize, out int iCount)
       {
           iCount = 0;
           return GetFanslist(strTokenOpenID, pageCount, pageSize, out iCount);
           //iCount =0;
           //QOpenClient qqAPI = GetClient(strTokenOpenID);
           //if (qqAPI == null)
           //{
           //    return null;
           //}
           ////获取我收听的人数
           ////User user=qqAPI.GetCurrentUser();
           //WeiboUser weioUser=qqAPI.GetWeiboUserInfo();
           //if (weioUser != null&&weioUser.Data!=null)
           //{
           //    iCount = weioUser.Data.Idolnum;
           //}

           //WeiboIdol idoData = qqAPI.GetIdolList(pageCount, pageCount*pageSize);
           //if (idoData != null&&idoData.Data!=null&&idoData.Data.Info!=null)
           //{
           //    List<Fan> fanList = idoData.Data.Info;
           //    return ObjPriseObj(fanList);
           //}
           //return null;
       }


        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="fanList">列表</param>
        /// <returns></returns>
       private List<MembershipUserEb> ObjPriseObj(List<Fan> fanList)
       {
           if (fanList != null)
           {
               List<MembershipUserEb> resultList = new List<MembershipUserEb>();
               MembershipUserEb model;
               foreach (Fan f in fanList)
               {
                   if (f != null)
                   {
                       model = new MembershipUserEb();
                       model.NiName = f.Nick;
                       model.UserName = f.Name;
                       model.Sign = f.Openid;
                       model.emailAddress = f.Head;
                       resultList.Add(model);
                   }
               }
               return resultList;
           }
           return null;
       }

        public void Login()
        {
            QzoneContext qContent = new QzoneContext(appKey, appSecret, BackUrl);
            string state = Guid.NewGuid().ToString().Replace("-", "");
            //权限
            string scope = "get_user_info,add_share,list_album,upload_pic,check_page_fans,add_t,add_pic_t,del_t,get_repost_list,get_info,get_other_info,get_fanslist,get_idolist,add_idol,del_idol,add_one_blog,add_topic,get_tenpay_addr";
            var authenticationUrl = qContent.GetAuthorizationUrl(state, scope);
            HttpContext.Current.Response.Redirect(authenticationUrl); 
        }

        /// <summary>
        /// 登录成功后的返回地址
        /// </summary>
        public string BackUrl 
        { 
            get
            {
                return HostApi.LoginApiBindUrl(ApiName);
            } 
        }

        /// <summary>
        /// 获取相关操作-由于各个网站接口的不确定性，所以采用itype来区分操作
        /// </summary>
        /// <param name="itype">操作类别，在客户端可以输入相关标记来执行相关操作</param>
        public void OrtherAction(int itype, string code)
        {
            
        }
        /// <summary>
        /// 获取其他对象-由于各个网站接口的不确定性，所以采用itype来区分操作
        /// </summary>
        /// <param name="itype">操作类别，在客户端可以输入相关标记来执行相关操作</param>
        /// <returns></returns>
        public object GetOrther(int itype, string code)
        {
            return null;
        }
        /// <summary>
        /// 获取其他对象列表-由于各个网站接口的不确定性，所以采用itype来区分操作
        /// </summary>
        /// <param name="itype">操作类别，在客户端可以输入相关标记来执行相关操作</param>
        /// <returns></returns>
        public List<object> GetOrtherList(int itype, string code)
        {
            return null;
        }

       #endregion 微博操作方法

        #region 对插件底层接口的实现

        public ExtensionSettings GetSettings()
        {

            string sSettingsName = this.GetType().FullName;
            ExtensionSettings settings = new ExtensionSettings(sSettingsName);
            settings.AddParameter("appKey", "AppKey-详见帮助", 100, true, true, ParameterType.String);

            settings.AddParameter("appSecret", "密文-详见帮助", 150, true, true, ParameterType.String);

            settings.Help = ConfigHelpHtml;
            //是否单个
            settings.IsScalar = true;

            PluginManager.Instance.ImportSettings(settings);

            return PluginManager.Instance.GetSettings(sSettingsName);

        }
        private Host HostApi;
        private ExtensionSettings ConfigString;
        /// <summary>
        /// 初始化插件。这是类调用的第一个方法。
        /// </summary>
        /// <param name="host">提供了访问主系统的api</param>
        /// <param name="config">Configuration string for the plugin.</param>
        public void Init(Host host, ExtensionSettings config)
        {
            this.HostApi = host;
            ConfigString = config;

            appKey = ConfigString.GetSingleValue("appKey");//"100309177"
            appSecret = ConfigString.GetSingleValue("appSecret");//"1d05467254dbaea5ed7ba0cf37d47289"
            qqConfig.AppKey = appKey;
            qqConfig.AppSecret = appSecret;
        }

        /// <summary>
        /// 注销插件后将调用此办法
        /// </summary>
        public void Shutdown()
        {

        }

        /// <summary>
        /// HTML文本显示为插件的帮助配置信息
        /// </summary>
        public string ConfigHelpHtml
        {
            get
            {
                return @"QQ第三方登录接口。";

            }
        }

        #endregion

        #region 实现插件基本方法(flz_2012-10-11)

        private OAuthToken GetOAuthToken(string code)
        {
            string[] ac = code.Split(',');
            OAuthToken at = new OAuthToken();
            if(ac.Length>1)
            {
                at.AccessToken = ac[0];
                at.OpenId = ac[1];
            }
           
            
            return at;
        }
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetToken(string code)
        {
           QOpenClient  qqClient = new QOpenClient(qqConfig, code, "");
           QConnectSDK.Models.OAuthToken oauthToken = qqClient.OAuthToken;

            return string.Concat(oauthToken.AccessToken,",", oauthToken.OpenId);
        }
        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetUserIco(string code)
        {
            QConnectSDK.Models.User qzone = GetClient(code).GetCurrentUser();
             if (qzone != null)
             {
                 string strFigureurl = qzone.Figureurl;
                 strFigureurl = strFigureurl.Substring(0, strFigureurl.Length -2) + "100";
                 return strFigureurl;
             }
             return "";
        }
        /// <summary>
        /// 获取用户昵称
        /// </summary>
        /// <returns></returns>
        public string GetUserNickName(string code)
        {

            QConnectSDK.Models.User qzone = GetClient(code).GetCurrentUser();
            if (qzone != null)
            {
                return qzone.Nickname;
            }
            return "";
        }
        private QOpenClient GetClient(string code)
        {
            QConnectSDK.Config.QQConnectConfig qqConfig = new QConnectSDK.Config.QQConnectConfig();
            qqConfig.AppKey = appKey;
            qqConfig.AppSecret = appSecret;
            QOpenClient qqClient = new QOpenClient(GetOAuthToken(code),qqConfig);
            return qqClient;
        }
        #endregion 实现插件基本方法
    }
}
