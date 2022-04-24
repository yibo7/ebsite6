using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;

namespace QConnectSDK.Config
{
    /// <summary>
    /// QQ互联的配置数据
    /// </summary>
    [Serializable]
    public class QQConnectConfig
    {
        private string _appkey = "";
        private string _appsecret = "";
        private string _authorizeurl = "https://graph.qq.com/oauth2.0/authorize";
        private string _callbackurl = "";

        /// <summary>
        /// 申请QQ登录成功后，分配给应用的appid
        /// </summary>
        public string AppKey
        {
            get { return _appkey; }
            set { _appkey = value; }
        }
        /// <summary>
        /// 申请QQ登录成功后，分配给网站的appkey
        /// </summary>
        public string AppSecret
        {
            get { return _appsecret; }
            set { _appsecret = value; }
        }
        /// <summary>
        /// 获取Authorization Code的URL地址
        /// </summary>
        public string AuthorizeURL
        {
            get { return _authorizeurl; }
            set { _authorizeurl = value; }
        }
        /// <summary>
        /// 得到回调地址
        /// </summary>
        public string CallBackURL
        {
            get { return _callbackurl; }
            set { _callbackurl = value; }
        }



        /// <summary>
        /// 获取Authorization Code的URL地址
        /// </summary>
        /// <returns></returns>
        public string GetAuthorizeURL()
        {
            return AuthorizeURL;
        }
        /// <summary>
        /// 申请QQ登录成功后，分配给应用的appid
        /// </summary>
        /// <returns>string AppKey</returns>
        public string GetAppKey()
        {
            return AppKey;
        }

        /// <summary>
        /// 申请QQ登录成功后，分配给网站的appkey
        /// </summary>
        /// <returns>string AppSecret</returns>
        public string GetAppSecret()
        {
            return AppSecret;
        }

        /// <summary>
        /// 得到回调地址
        /// </summary>
        /// <returns></returns>
        public Uri GetCallBackURI()
        {
            string callbackUrl = CallBackURL;
            if (!Uri.IsWellFormedUriString(callbackUrl, UriKind.Absolute))
            {
                var current = HttpContext.Current;
                if(current != null)
                {
                    var currentUrl = current.Request.Url;
                    callbackUrl = string.Format("{0}://{1}:{2}{3}",currentUrl.Scheme,currentUrl.Host, currentUrl.Port, callbackUrl);
                }
            }
            return new Uri(callbackUrl);
        }
    }
}
