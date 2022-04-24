using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Core;
using EbSite.Entity;

namespace EbSite.Plugin.EbSearch
{
    [Extension("从IP获取区域之新浪微薄API", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class SinaApi : IIPToArea
    {
        public ClientIpInfo Query(string strIP)
       {
           Entity.ClientIpInfo ipModel = new ClientIpInfo();
           ipModel = null;
           if (!string.IsNullOrEmpty(strIP))
           {
               try
               {
                   string strURL = string.Format("http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js&ip={0}", strIP);
                   string strJson = EbSite.Core.WebUtility.LoadURLStringUTF8(strURL).Replace("var", "").Replace("remote_ip_info", "").Replace("=", "").Replace(";", "").Trim();
                   ipModel =  JsonHelper.Deserialize<Entity.ClientIpInfo>(strJson);
                   // ipModel = ModuleCore.BLL.orderhelp.Instance.BeiMaiDeserialize<ModuleCore.Entity.ClientIpInfo>(strJson);
                   //信息返回成功
               }
               catch
               {
                   ipModel = null;
               }
           }
           return ipModel;
       } 
        
        #region 对插件底层接口的实现

        public ExtensionSettings GetSettings()
        {

            string sSettingsName = this.GetType().FullName;
            ExtensionSettings settings = new ExtensionSettings(sSettingsName);
            //settings.AddParameter("InsurancePrice", "保险金额", 100, true, true, ParameterType.String);

            //settings.AddParameter("MoreThanPrice", "满多少免运费", 100, true, true, ParameterType.String);

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
                return @"SQL内容搜索。";

            }
        }

        #endregion
    }
}
