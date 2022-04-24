using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;

namespace EbSite.Plugin.Payment.Alipay_Standard_YearNew
{
    [Extension("支付宝(双功单笔1.2%交易费)", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]//担保交易,单笔2%交易费
    public class Payment : AlipayPaymentBase
    {

        override public string aDescription
        {
            get
            {
                return "支付宝双功交易(担保与即时)，是支付宝公司针对网上交易而特别推出的安全付款服务，其运作的实质是以支付宝为信用中介，在买家确认收到商品前，由支付宝替买卖双方暂时保管货款的一种增值服务。";
            }
        }
        /// <summary> 
        /// HTML文本显示为插件的帮助配置信息
        /// </summary>
        override public string aConfigHelpHtml
        {
            get
            {
                return @"支付宝，是支付宝公司针对网上交易而特别推出的安全付款服务，其运作的实质是以支付宝为信用中介，在买家确认收到商品前，由支付宝替买卖双方暂时保管货款的一种增值服务。单笔2%交易费。";
            }
        }
        override public string aAlipayTypeName
        {
            get
            {
                return "trade_create_by_buyer";

            }
        }


       // public string Description
       // {
       //     get
       //     {
       //         return "支付宝，是支付宝公司针对网上交易而特别推出的安全付款服务，其运作的实质是以支付宝为信用中介，在买家确认收到商品前，由支付宝替买卖双方暂时保管货款的一种增值服务。";
       //     }
       // }
       // public string GetPayStr(string OrderName, string TotalPrice, string OrderNumber)
       // {
       //     //ConfigString.GetSingleValue("PayID");
       //     //ConfigString.GetSingleValue("ValCode");
       //     //ConfigString.GetSingleValue("PartnerID");
       //     //ConfigString.GetSingleValue("PayPicUrl");

       //     string virtualPath = HostApi.IISPath;

       //     string agent = "2088002651643944";
       //     AliPay pay = new AliPay();
       //     return ("<a target='_blank' href='" + pay.GetPayStr(agent, ConfigString.GetSingleValue("PayID"), ConfigString.GetSingleValue("ValCode"), ConfigString.GetSingleValue("PartnerID"), "trade_create_by_buyer", OrderName, TotalPrice, virtualPath, this.GetType().FullName, OrderNumber) + "'><img alt='用支付宝支付' align='absmiddle' src='" + virtualPath + ConfigString.GetSingleValue("PayPicUrl") + "' border=0></a>");
       // }

       // //public string QueryArray
       // //{
       // //    get
       // //    {
       // //        return "支付按钮图片,合作者身份,交易安全校验码,支付宝帐号";
       // //    }
       // //}
       // #region 对插件底层接口的实现


       // /// <summary>
       // /// 设置插件信息
       // /// </summary>
       //// private static readonly ProviderInfo info = new ProviderInfo("支付宝(担保交易,单笔2%交易费)", "小菜", "1.0.0.0", "http://www.ebsite.net", "http://www.ebsite.net/Plugin/EbSite.Plugin.Payment.dll");
       // private IHost HostApi;
       // private ExtensionSettings ConfigString;
       // /// <summary>
       // /// 初始化插件。这是类调用的第一个方法。
       // /// </summary>
       // /// <param name="host">提供了访问主系统的api</param>
       // /// <param name="config">Configuration string for the plugin.</param>
       // public void Init(IHost host, ExtensionSettings config)
       // {
       //     this.HostApi = host;
       //     ConfigString = config;
       // }

       // /// <summary>
       // /// 注销插件后将调用此办法
       // /// </summary>
       // public void Shutdown()
       // {

       // }



       // public ExtensionSettings GetSettings()
       // {
       //     string sSettingsName = this.GetType().FullName;

       //     ExtensionSettings settings = new ExtensionSettings(sSettingsName);


       //     settings.AddParameter("PayID", "支付宝帐号：", 100, true, true, ParameterType.String);
       //     settings.AddParameter("ValCode", "交易安全校验码", 100, true, true, ParameterType.String);
       //     settings.AddParameter("PartnerID", "合作者身份", 100, true, true, ParameterType.String);
       //     settings.AddParameter("PayPicUrl", "支付按钮图片", 100, true, true, ParameterType.Upload);
       //     settings.Help = ConfigHelpHtml;
       //     //是否单个
       //     settings.IsScalar = true;

       //     PluginManager.Instance.ImportSettings(settings);

       //     return PluginManager.Instance.GetSettings(sSettingsName);
       // }

       // /// <summary>
       // /// HTML文本显示为插件的帮助配置信息
       // /// </summary>
       // public string ConfigHelpHtml
       // {
       //     get
       //     {
       //         return @"支付宝，是支付宝公司针对网上交易而特别推出的安全付款服务，其运作的实质是以支付宝为信用中介，在买家确认收到商品前，由支付宝替买卖双方暂时保管货款的一种增值服务。单笔2%交易费。<a href=""https://www.alipay.com/himalayas/practicality_customer.htm?customer_external_id=C4335329993464066118&market_type=from_agent_contract&pro_codes=6AECD60F4D75A7FB"" target=""_blank""><font color=""#ff0000""><strong>立即申请</strong></font></a>      ";
       //     }
       // }

       // #endregion
    }
}

