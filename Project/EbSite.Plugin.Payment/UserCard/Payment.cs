using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;

namespace EbSite.Plugin.Payment.UserCard
{
    [Extension("会员卡支付", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class Payment : IPayment
    {
        

        public string Description
        {
            get
            {
                return "会员卡支付";
            }

        }

        public string GetPayStr(string OrderName, string TotalPrice, string OrderNumber)
        {
            //ConfigString.GetSingleValue("CusID");
            //ConfigString.GetSingleValue("PrivateKey");
            string str = QueryArray;
            string virtualPath = HostApi.IISPath;
            return ("<a href='" + virtualPath + "member/User_UserCard_Payment.aspx?number=" + OrderName + "&price=" + TotalPrice + "'><img alt='用会员卡支付' align='absmiddle' src='" + virtualPath + "member/Images/pay.gif' border=0></a>");
        }

        public string QueryArray
        {
            get
            {
                return "私钥,客户号";
            }

        }

        #region 对插件底层接口的实现


        /// <summary>
        /// 设置插件信息
        /// </summary>
        //private static readonly ProviderInfo info = new ProviderInfo("会员卡支付", "小菜", "1.0.0.0", "http://www.ebsite.net", "http://www.ebsite.net/Plugin/EbSite.Plugin.Payment.dll");
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


           

            settings.AddParameter("PrivateKey", "私钥", 100, true, true, ParameterType.String);
            settings.AddParameter("CusID", "客户号", 100, true, true, ParameterType.String);
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
                return @"会员卡支付";
            }
        }

        #endregion
    }
}

