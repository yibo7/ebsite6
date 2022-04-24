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
using NetDimension.Weibo;

namespace EbSite.Plugin.UserLoginApi
{
    [Extension("第三方登录插件新浪微薄", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class SINA : IUserLoginApi
    {
        private string appKey;
        private string appSecret;
       
        /// <summary>
        /// 登录接口的名称,前方可能通过这个名称获取相应的实例
        /// </summary>
       public string ApiName 
        {  
            get
            {
                return "SINA";
            } 
        }
       public string ShowName
       {
           get
           {
               return "新浪微博";
           }
       }

        /// <summary>
        /// 发送一条微薄信息
        /// </summary>
        /// <param name="sContent"></param>
       public void SendMsg(string sContent,string strToken)
        {
            Client sina = GetClient(strToken);
            NetDimension.Weibo.Entities.status.Entity result=sina.API.Statuses.Update(sContent, 0, 0, "");
        }

       /// <summary>
       /// 关注一个用户
       /// </summary>
       /// <param name="name">用户名称</param>
       /// <param name="fopenIds">用户ID</param>
       /// <param name="strToken"></param>
       public void GuanZhu(string name, string fopenIds, string strToken)
        {
            //QOpenClient qzone = new QOpenClient(qqConfig, code, "");
            //qzone.AddIdol(name, fopenIds);
        }

        /// <summary>
        /// 获取一个用户的信息
        /// </summary>
        /// <returns></returns>
       public MembershipUserEb GetUserInfo(string strToken)
        {
            return null;
        }
        /// <summary>
        /// 获取我的粉丝列表
        /// </summary>
        /// <param name="strToken">授权标示码</param>
        /// <param name="pageCount">每一页显示个数</param>
        /// <param name="pageIndex">页码索引</param>
        /// <param name="iCount">总数量</param>
        /// <returns></returns>
       public List<MembershipUserEb> GetFanslist(string strToken, int pageCount, int pageIndex, out int iCount)
       {
           iCount = 0;
           Client sina = GetClient(strToken);
           string UserID = sina.API.Account.GetUID();
           NetDimension.Weibo.Entities.user.Entity dynamic_userInfo = sina.API.Users.Show(UserID);
           iCount = dynamic_userInfo.FollowersCount;
           //获取总关注用户数量
           NetDimension.Weibo.Entities.user.Collection ucollection = sina.API.Friendships.Followers(UserID, dynamic_userInfo.ScreenName, pageCount, pageCount*pageIndex);
           if (ucollection != null && ucollection.Users != null)
           {
               List<NetDimension.Weibo.Entities.user.Entity> fansList = ucollection.Users.ToList();
               return ObjPriseObj(fansList);

           }
           return null;
       }
        /// <summary>
        /// 获取我关注人的列表
        /// </summary>
       /// <param name="strToken">授权标示码</param>
       /// <param name="pageCount">每一页显示个数</param>
       /// <param name="pageIndex">页码索引</param>
       /// <param name="iCount">总数量</param>
        /// <returns></returns>
       public List<MembershipUserEb> GetIdollist(string strToken, int pageCount, int pageIndex, out int iCount)
       {
           iCount =0;
           Client sina = GetClient(strToken);
           string UserID = sina.API.Account.GetUID();
           var dynamic_userInfo = sina.API.Users.Show(UserID);
           //获取总关注用户数量
           iCount = dynamic_userInfo.FriendsCount;
           NetDimension.Weibo.Entities.user.Collection ucollection = sina.API.Friendships.Friends(UserID, dynamic_userInfo.ScreenName,pageCount, pageIndex*pageCount);
           if (ucollection != null && ucollection.Users != null)
           {
               List<NetDimension.Weibo.Entities.user.Entity> fansList = ucollection.Users.ToList();
               return ObjPriseObj(fansList);

           }
           return null;
       }

       /// <summary>
       /// 对象转换
       /// </summary>
       /// <param name="fanList">列表</param>
       /// <returns></returns>
       private List<MembershipUserEb> ObjPriseObj(List<NetDimension.Weibo.Entities.user.Entity> fanList)
       {
           if (fanList != null)
           {
               List<MembershipUserEb> resultList = new List<MembershipUserEb>();
               MembershipUserEb model;
               foreach (NetDimension.Weibo.Entities.user.Entity f in fanList)
               {
                   if (f != null)
                   {
                       model = new MembershipUserEb();
                       model.NiName = f.ScreenName;
                       model.UserName = f.Name;
                       model.Sign = f.ID;
                       model.emailAddress = f.ProfileImageUrl;
                       resultList.Add(model);
                   }
               }
               return resultList;
           }
           return null;
       }
        public void Login()
        {
           //GetOAuth()
            string url = GetOAuth().GetAuthorizeURL();
            HttpContext.Current.Response.Redirect(url);
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
                return @"新浪微薄第三方登录接口。";

            }
        }

        #endregion

        private Client GetClient(string strToken)
        {
            return new Client(GetOAuth(strToken));
        }

        #region 实现插件基本方法(flz_2012-10-11)

        private OAuth GetOAuth()
        {
            return new OAuth(appKey, appSecret, BackUrl);
            
        }

        private OAuth GetOAuth(string strToken)
        {
            return new OAuth(appKey, appSecret, strToken,null);

        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="strToken">strToken</param>
        /// <returns></returns>
        public string GetToken(string strCode)
        {
            NetDimension.Weibo.OAuth oauth = GetOAuth();
            
            if (string.IsNullOrEmpty(oauth.AccessToken))
            {
                NetDimension.Weibo.AccessToken sinaToken = oauth.GetAccessTokenByAuthorizationCode(strCode);
                if (sinaToken != null)
                {
                    return sinaToken.Token;
                }
                return "";
            }
            
            return oauth.AccessToken;
        }
        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetUserIco(string strToken)
        {
            Client sina = new Client(GetOAuth(strToken));
            string strUid = sina.API.Account.GetUID();
            NetDimension.Weibo.Entities.user.Entity sUser=sina.API.Users.Show(strUid);
            if (sUser != null)
            {  
                return sUser.ProfileImageUrl;
            }
            return "";
        }
        /// <summary>
        /// 获取用户昵称
        /// </summary>
        /// <returns></returns>
        public string GetUserNickName(string strToken)
        {
            Client sina = new Client(GetOAuth(strToken));
            string strUid = sina.API.Account.GetUID();
            NetDimension.Weibo.Entities.user.Entity sUser = sina.API.Users.Show(strUid);
            if (sUser != null)
            {
                return sUser.ScreenName;
            }
            return "";
        }

        #endregion 实现插件基本方法
    }
}
