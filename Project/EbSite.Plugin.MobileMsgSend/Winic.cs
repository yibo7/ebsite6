using System;
using System.Collections.Generic;
using EbSite.Base;
using EbSite.Base.EntityAPI;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base; 
using System.Net;
using System.IO;

namespace EbSite.Plugin.MobileMsgSend
{
    [Extension("253.COM手机短信发送组件", "1.0", "<a href=\"http://www.ebsite.net\">亿博团队</a>")]
    public class Winic : IMobileSend
    {
        
        /// <summary>
        /// 向某个手机号码发送一条短信
        /// </summary>
        /// <param name="Msg">短信内容</param>
        /// <param name="MobiNumber">手机号码</param>
        /// <param name="UserName">用户帐号</param>
        public void SendMsg(string Msg, string MobiNumber, string UserName)
        {
     
            if (!string.IsNullOrEmpty(_sUserName)&&!string.IsNullOrEmpty(_sPass))
            {
                string sUser = _sUserName;
                string sPass = _sPass;

                string un = sUser;
                string pw = sPass;
                string phone = MobiNumber;

                string content = string.Format("【{0}】{1}", string.IsNullOrEmpty(_strcode)? "创蓝253": _strcode, WebUtility.UrlDecode(Msg.Trim()));// string.Concat("【ebsite】", WebUtility.UrlDecode(Msg.Trim()));


                string postJsonTpl = "\"account\":\"{0}\",\"password\":\"{1}\",\"phone\":\"{2}\",\"report\":\"false\",\"msg\":\"{3}\"";
                string jsonBody = string.Format(postJsonTpl, un, pw, phone, content);
                string result = doPostMethodToObj("http://vsms.253.com/msg/send/json", "{" + jsonBody + "}");
                if(_isopenlog)
                    HostApi.InsertLog("执行发送短信"+DateTime.Now, string.Concat("发送结果:", result, "--手机号:", MobiNumber, "--发送内容:", content));
            }
            else
            {
                
                throw new Exception("用户名称与密码没有配置正确:" + ConfigString);
            }
            
        }
        private  string doPostMethodToObj(string url, string jsonBody)
        {
            string result = String.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            // Create NetworkCredential Object 
            NetworkCredential admin_auth = new NetworkCredential("username", "password");


            // Set your HTTP credentials in your request header
            httpWebRequest.Credentials = admin_auth;

            // callback for handling server certificates
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonBody);
                streamWriter.Flush();
                streamWriter.Close();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            return result;
        }
        public int ExecutionPriority { 
            get
            {
                return 10;
            }
        }



        #region 对插件底层接口的实现

        public ExtensionSettings GetSettings()
        {

            string sSettingsName = this.GetType().FullName;



            ExtensionSettings settings = new ExtensionSettings(sSettingsName);


            settings.AddParameter("susername", "用户帐号", 100, true, true, ParameterType.String);
            settings.AddParameter("spass", "用户密码", 200, true, true, ParameterType.String);

            settings.AddParameter("strcode", "签名文字", 200, true, true, ParameterType.String);
            settings.AddParameter("isopenlog", "开启日志", 200, true, true, ParameterType.Boolean);
            settings.Help = ConfigHelpHtml;
            //是否单个
            settings.IsScalar = true;

            PluginManager.Instance.ImportSettings(settings);

            return PluginManager.Instance.GetSettings(sSettingsName);

        }
        private Host HostApi;
        private ExtensionSettings ConfigString;
        private string _sUserName;
        private string _sPass;
        private string _strcode;
        private bool _isopenlog = false;
        /// <summary>
        /// 初始化插件。这是类调用的第一个方法。
        /// </summary>
        /// <param name="host">提供了访问主系统的api</param>
        /// <param name="config">Configuration string for the plugin.</param>
        public void Init(Host host, ExtensionSettings config)
        {
            this.HostApi = host;
            ConfigString = config;

            _sUserName = ConfigString.GetSingleValue("susername");
            _sPass = ConfigString.GetSingleValue("spass");

            _strcode = ConfigString.GetSingleValue("strcode");
            bool isopenlog = false;
            bool.TryParse(ConfigString.GetSingleValue("isopenlog"),out isopenlog);
            _isopenlog = isopenlog;
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
                return @"
<div>
  <b>使用帮助:</b><br/>
  <ul>
    <li>签名可能要到短信平台申请通过才能发送成功，开启日志记录会将短信发送结果写入后台的综合日志。</li>
  </ul>
</div>
      ";
            }
        }

        #endregion
    }
}
