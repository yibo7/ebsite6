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
    
    [Extension("第三方登录插件-支付宝登录", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class ALIPAY : IUserLoginApi
    {
        #region 变量

        private string appKey;
        private string appSecret;

        /// <summary>
        /// 
        /// </summary>
        public string ShowName
        {
            get
            {
                return "支付宝";
            }
        }

        /// <summary>
        /// 登录接口的名称,前方可能通过这个名称获取相应的实例
        /// </summary>
       public string ApiName 
        {  
            get
            {
                return "ALIPAY";
            } 
        }

        #endregion 变量

       #region 支付宝登录方法

       public void Login()
       {
           HttpContext.Current.Response.Redirect(GetRedirctUrl());
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

       #endregion 支付宝登录方法

       #region 支付宝操作方法

        /// <summary>
        /// 发送一条微薄信息
        /// </summary>
        /// <param name="sContent">微博内容(140字以内)</param>
        /// <param name="strTokenOpenID">授权码,OpenID(中间用逗号隔开)</param>
        public void SendMsg(string sContent, string strTokenOpenID)
        {
          
        }

        /// <summary>
        /// 关注一个用户
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <param name="fopenIds">用户ID</param>
        public void GuanZhu(string name, string fopenIds, string code)
        {
            
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
        public List<MembershipUserEb> GetFanslist(string strTokenOpenID, int pageCount, int pageSize, out int iCount)
        {
            iCount = 0;
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
            return null;
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
        /// <summary>
        /// 获取相关操作-由于各个网站接口的不确定性，所以采用itype来区分操作
        /// </summary>
        /// <param name="itype">操作类别，在客户端可以输入相关标记来执行相关操作</param>
        public void OrtherAction(int itype, string code)
        {

        }

       #endregion 支付宝操作方法

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

            appKey = ConfigString.GetSingleValue("appKey");
            appSecret = ConfigString.GetSingleValue("appSecret");
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
                return @"支付宝第三方登录接口。";

            }
        }
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetToken(string code)
        {
            return "";
        }

        #endregion

       #region 实现插件基本方法(flz_2012-10-11)

        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetUserIco(string code)
        {
             return "";
        }
        /// <summary>
        /// 获取用户昵称
        /// </summary>
        /// <returns></returns>
        public string GetUserNickName(string code)
        {
            return "";
        }

        #endregion 实现插件基本方法

        #region 支付宝登录辅助方法

        /// <summary>
        /// flz(2013-1-17)
        /// </summary>
        /// <returns></returns>
        private string GetRedirctUrl()
        {
            //支付宝网关地址（新）
            string getWay_New = "https://mapi.alipay.com/gateway.do?";
            string strCharset = "utf-8";
            string signType = "MD5";
            //添加参数
            Dictionary<string, string> dicPara = new Dictionary<string, string>();
            dicPara.Add("_input_charset", strCharset);
            dicPara.Add("partner", appKey);
            dicPara.Add("return_url", BackUrl);
            dicPara.Add("service", "alipay.auth.authorize");
            dicPara.Add("target_service", "user.auth.quick.login");
            //组合连接
            string concatParam = CreateLinkString(dicPara);
            //获取签名
            string mySign = Sign(concatParam, appSecret, strCharset);
            //返回URL
            string resultUrl=string.Format("{0}{1}&sign={2}&sign_type={3}",getWay_New,concatParam, mySign, signType);
            return resultUrl;
        }

        /// <summary>
        /// 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
        /// </summary>
        /// <param name="sArray">需要拼接的数组</param>
        /// <returns>拼接完成以后的字符串</returns>
        private string CreateLinkString(Dictionary<string, string> dicArray)
        {
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + temp.Value + "&");
            }
            //去掉最後一個&字符
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);
            return prestr.ToString();
        }

        /// <summary>
        /// 签名字符串
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="_input_charset">编码格式</param>
        /// <returns>签名结果</returns>
        private string Sign(string prestr, string key, string _input_charset)
        {
            StringBuilder sb = new StringBuilder(32);
            prestr = prestr + key;
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        #endregion 支付宝登录辅助方法
    }
}
