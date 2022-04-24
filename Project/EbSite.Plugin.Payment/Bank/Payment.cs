using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;

namespace EbSite.Plugin.Payment.Bank
{
    [Extension("线下银行汇款", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class Payment : IPayment
    {
        

        public string Description
        {
            get
            {
                return "线下银行汇款";
            }

        }

        public string GetPayStr(string OrderName, string TotalPrice, string OrderNumber)
        {
            //ConfigString.GetSingleValue("BankInfoLink");
            //ConfigString.GetSingleValue("ImgUpload");

            string virtualPath = HostApi.IISPath;
            //string[] strArray = QueryArray.Split(new char[] { ',' });
            //if (strArray.Length != 2)
            //{
            //    strArray = (QueryArray + ",").Split(new char[] { ',' });
            //}
            return ("<a target='_blank' href='" + ConfigString.GetSingleValue("BankInfoLink") + "'><img src='" + virtualPath + ConfigString.GetSingleValue("ImgUpload") + "' border=0></a>");
        }

        public string QueryArray
        {
            get
            {
                return "支付按钮图片,银行帐号信息链接";
            }

        }

        #region 对插件底层接口的实现


        /// <summary>
        /// 设置插件信息
        /// </summary>
       // private static readonly ProviderInfo info = new ProviderInfo("线下银行汇款", "小菜", "1.0.0.0", "http://www.ebsite.net", "http://www.ebsite.net/Plugin/EbSite.Plugin.Payment.dll");
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



        public ExtensionSettings GetSettings()
        {
            string sSettingsName = this.GetType().FullName;

            ExtensionSettings settings = new ExtensionSettings(sSettingsName);

          
        
            settings.AddParameter("BankInfoLink", "银行帐号信息链接", 300, true, true, ParameterType.StringMax);
            settings.AddParameter("ImgUpload", "支付按钮图片", 300, true, true, ParameterType.Upload);
            settings.Help = ConfigHelpHtml;
            //是否单个
            settings.IsScalar = true;

            PluginManager.Instance.ImportSettings(settings);

            return PluginManager.Instance.GetSettings(sSettingsName);
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

