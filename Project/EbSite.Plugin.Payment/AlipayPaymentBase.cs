using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using EbSite.Base;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;

namespace EbSite.Plugin.Payment
{
    abstract public class AlipayPaymentBase : IPayment
    {
        /// <summary>
        /// 前台说明
        /// </summary>
        abstract public string aDescription{get;}
        /// <summary>
        /// 后台说明
        /// </summary>
        abstract public string aConfigHelpHtml { get; }

        /// <summary>
        /// 支付宝接口类型 create_direct_pay_by_user 为即时到账
        /// </summary>
        public abstract string aAlipayTypeName{ get;}
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
            //return ("<a target='_blank' href='" + pay.GetPayStr(agent, ConfigString.GetSingleValue("PayID"), ConfigString.GetSingleValue("ValCode"), ConfigString.GetSingleValue("PartnerID"), aAlipayTypeName, OrderName, TotalPrice, virtualPath, this.GetType().FullName, OrderNumber) + "'><img alt='用支付宝支付' align='absmiddle' src='" + ConfigString.GetSingleValue("PayPicUrl") + "' border=0></a>");

            return pay.GetPayStr(agent, ConfigString.GetSingleValue("PayID"), ConfigString.GetSingleValue("ValCode"),
                                 ConfigString.GetSingleValue("PartnerID"), aAlipayTypeName, OrderName, TotalPrice,
                                 virtualPath, this.GetType().FullName, OrderNumber);
        }

       
        public ExtensionSettings GetSettings()
        {
            string sSettingsName = this.GetType().FullName;

            ExtensionSettings settings = new ExtensionSettings(sSettingsName);
            settings.AddParameter("PayID", "支付宝帐号：", 100, true, true, ParameterType.String);
            settings.AddParameter("ValCode", "交易安全校验码", 100, true, true, ParameterType.String);
            settings.AddParameter("PartnerID", "合作者身份", 100, true, true, ParameterType.String);
            settings.AddParameter("PayPicUrl", "支付按钮图片", 100, true, true, ParameterType.Upload);
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
