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

    [Extension("适用于商城站点,定时处理团购,抢购状态处理业务", "1.0", "<a href=\"http://www.ebsite.net\">小乐乐</a>")]
    public class ebShopTimer : ITimerTask
    {

        /// <summary>
        /// 处理定时执行的任务
        /// </summary>
        public void CallTask()
        {
            //抢购
            EbSite.Modules.Shop.ModuleCore.BLL.CountDownBuy.Instance.UpdateStatus();
            //团购
            EbSite.Modules.Shop.ModuleCore.BLL.GroupBuy.Instance.UpdateStatus();
        }


        #region 对插件底层接口的实现

        public ExtensionSettings GetSettings()
        {

            string sSettingsName = this.GetType().FullName;
            ExtensionSettings settings = new ExtensionSettings(sSettingsName);



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