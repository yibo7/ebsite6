using System;
using System.Collections.Generic;
using EbSite.Base;

using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;

using EbSite.Plugin.MobileMsgSendBeiMai.cn.entinfo.sdk2;

namespace EbSite.Plugin.MobileMsgSendBeiMai
{
    [Extension("北迈手机短信发送组件", "1.0", "<a href=\"http://www.ebsite.net\">亿博团队</a>")]
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
            //throw new Exception("手机号:" + MobiNumber + " 短信:" + Msg + " 用户名:" + UserName);
            cn.entinfo.sdk2.WebService msm = new WebService();
            if (!string.IsNullOrEmpty(_sUserName)&&!string.IsNullOrEmpty(_sPass))
            {
                string sUser = _sUserName;
                string sPass = _sPass;
                string state = msm.SendSMSEx(sUser, sPass, MobiNumber, Msg, "");
                #region 状态
                
                if (state.IndexOf("成功") > -1)
                {
                    HostApi.InsertLog("发送一个短信", string.Concat("短信内容:", Msg, "--手机号:", MobiNumber));
                }
               
                #endregion
            }
            else
            {
                throw new Exception("用户名称与密码没有配置正确:" + ConfigString);
            }
            
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
    <li>在后台安装后，可以在系统的配置里选择。</li>
  </ul>
</div>
      ";
            }
        }

        #endregion
    }
}
