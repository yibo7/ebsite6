using System.Text.RegularExpressions;
using System.Web;
using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;

namespace EbSite.Plugin.Payment.AlipayBankPay_SPABANK
{
    [Extension("支付宝即时到帐网银支付-平安银行", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class Payment : IPayment
    {
       public string aDescription
        {
            get
            {
                return "无需登录支付宝，直接进入网银支付-平安银行。";
            }
        }
        /// <summary>
        /// HTML文本显示为插件的帮助配置信息
        /// </summary>
        public string aConfigHelpHtml
        {
            get
            {
                return @"无需登录支付宝，直接进入网银支付。";
            }
        }
       public string aAlipayTypeName
       {
           get
           {
               return "create_direct_pay_by_user";
           }
       }

       public string Description
       {
           get
           {
               return aDescription;
           }
       }

       public string GetNowUrl()
       {
           string input = string.Empty;
           string pattern = @"http://(?<domain>[^\/]*)";
           input = HttpContext.Current.Request.Url.ToString();
           Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
           return regex.Match(input).Groups["domain"].Value;
       }

       public string GetPayStr(string OrderName, string TotalPrice, string OrderNumber)
       {

           string virtualPath = HostApi.IISPath;

           string agent = "2088002651643944";
           AliPay pay = new AliPay();
           
           return pay.GetPayStr(agent, ConfigString.GetSingleValue("PayID"), ConfigString.GetSingleValue("ValCode"),
                                ConfigString.GetSingleValue("PartnerID"), aAlipayTypeName, OrderName, TotalPrice,
                                virtualPath, this.GetType().FullName, OrderNumber, "SPABANK", AliPayPayType.网银支付);
       }


       public ExtensionSettings GetSettings()
       {
           string sSettingsName = this.GetType().FullName;

           ExtensionSettings settings = new ExtensionSettings(sSettingsName);
           settings.AddParameter("PayID", "支付宝帐号：", 100, true, true, ParameterType.String);
           settings.AddParameter("ValCode", "交易安全校验码", 100, true, true, ParameterType.String);
           settings.AddParameter("PartnerID", "合作者身份", 100, true, true, ParameterType.String);
           //settings.AddParameter("PayPicUrl", "支付按钮图片", 100, true, true, ParameterType.Upload);
           settings.Help = ConfigHelpHtml;
           //是否单个
           settings.IsScalar = true;
           PluginManager.Instance.ImportSettings(settings);

           return PluginManager.Instance.GetSettings(sSettingsName);
       }

       #region 对插件底层接口的实现
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
               return aConfigHelpHtml;
           }
       }

       #endregion
    }
}

