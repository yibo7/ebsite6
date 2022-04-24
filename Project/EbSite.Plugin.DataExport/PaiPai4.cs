using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;

namespace EbSite.Plugin.DataExport
{
    [Extension("导出拍拍数据包-适用拍拍助理4.0", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class PaiPai4 : IDataExport
    {
        /// <summary>
        /// 执行一个导出操作
        /// </summary>
        /// <param name="lstData">要导出的数据源</param>
        /// <returns>返回生成的数据包相对路径</returns>
        public string Export(object lstData)
        {
            List<EbSite.Modules.Shop.ModuleCore.Entity.Buy_Order> ls = lstData as List<EbSite.Modules.Shop.ModuleCore.Entity.Buy_Order>;

            return "";
        }
        public string Description
        {
            get
            {
                return "EbSite.Plugin.DataExport.PaiPai4";
            }
        }

        #region 对插件底层接口的实现

        /// <summary>
        /// 注销插件后将调用此办法
        /// </summary>
        public void Shutdown()
        {

        }
        private Host HostApi;
        private ExtensionSettings ConfigString;
        public void Init(Host host, ExtensionSettings config)
        {
            this.HostApi = host;
            ConfigString = config;

            ConfigString.GetSingleValue("Description");
        }
        public ExtensionSettings GetSettings()
        {
            string sSettingsName = this.GetType().FullName;
            ExtensionSettings settings = new ExtensionSettings(sSettingsName);


            //settings.AddParameter("Description", "条款", 300, true, true, ParameterType.StringMax);
            //settings.AddParameter("ImgUpload", "图片上传", 300, true, true, ParameterType.Upload);
            //settings.Help = ConfigHelpHtml;
            ////是否单个
            //settings.IsScalar = true;

            PluginManager.Instance.ImportSettings(settings);

            return PluginManager.Instance.GetSettings(sSettingsName);
        }

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
