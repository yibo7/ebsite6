using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Web;
using EbSite.Base;
using EbSite.Base.EntityAPI;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.Plugin.TimerTask
{

    [Extension("定时定单处理业务", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class TimerTask : ITimerTask
    {

         /// <summary>
        /// 处理定时执行的任务
        /// </summary>
        public void CallTask()
        {
            //EbSite.Base.Plugin.Factory.SendEmail();
        }


        #region 对插件底层接口的实现

        public ExtensionSettings GetSettings()
        {

            string sSettingsName = this.GetType().FullName;



            ExtensionSettings settings = new ExtensionSettings(sSettingsName);


            //settings.AddParameter("Description", "条款", 300, true, true, ParameterType.StringMax);
            //settings.AddParameter("ImgUpload", "图片上传", 300, true, true, ParameterType.Upload);
            settings.Help = ConfigHelpHtml;
            ////是否单个
            //settings.IsScalar = true;

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

            //ConfigString.GetSingleValue("Description");
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
