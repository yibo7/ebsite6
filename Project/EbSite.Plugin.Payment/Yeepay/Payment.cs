
using System.Text.RegularExpressions;
using System.Web;
using com.yeepay;
using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;

namespace EbSite.Plugin.Payment.Yeepay
{
    [Extension("小菜YeePay易宝支付接口系统", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class Payment : IPayment
    {
        public string addressFlag;
        public string amount;
        public string cur;
        public string frpId;
        public string htmlCodeGet;
        public string htmlCodePost;
        public static string keyValue;
        public string merchantCallbackURL;
        public static string merchantId;
        public string orderId;
        public string productCat;
        public string productDesc;
        public string productId;
        public string sMctProperties;

       

        public string Description
        {
            get
            {
                return "YeePay易宝（北京通融通信息技术有限公司）是专业从事多元化电子支付业务一站式服务的领跑者。在立足于网上支付的同时，YeePay易宝不断创新，将互联网、手机、固定电话整合在一个平台上，继短信支付、手机充值之后，首家推出了YeePay易宝电话支付业务，真正实现了离线支付，为更多传统行业搭建了电子支付的高速公路。";
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

            //ConfigString.GetSingleValue("CusID");
            //ConfigString.GetSingleValue("PrivateKey");
            //ConfigString.GetSingleValue("ImgUpload");
            string virtualPath = HostApi.IISPath;
            //string[] strArray = QueryArray.Split(new char[] { ',' });
            //if (strArray.Length != 3)
            //{
            //    strArray = ",,,".Split(new char[] { ',' });
            //}
            merchantId = ConfigString.GetSingleValue("CusID");// strArray[0];
            keyValue = ConfigString.GetSingleValue("PrivateKey");//strArray[1];
            this.orderId = OrderName;
            this.amount = TotalPrice;
            this.cur = "CNY";
            this.productId = "";
            this.productCat = "";
            this.productDesc = OrderName;
            this.merchantCallbackURL = "http://" + this.GetNowUrl() + "/member/CallBack/ReturnPage_Yeepay.aspx";
            this.addressFlag = "0";
            this.sMctProperties = "";
            this.frpId = "";
            string str4 = Buy.CreateForm(merchantId, keyValue, this.orderId, this.amount, this.cur, this.productId, this.productCat, this.productDesc, this.merchantCallbackURL, this.addressFlag, this.sMctProperties, this.frpId, "frmYeepay");
            return (str4 + "<img src='" + virtualPath + ConfigString.GetSingleValue("ImgUpload") + "' onclick='frmYeepay.submit()' border=0 style='cursor:pointer;'>");
        }

        public string QueryArray
        {
            get
            {
                return "支付图片,私钥,客户号";
            }
        }

        #region 对插件底层接口的实现


        /// <summary>
        /// 设置插件信息
        /// </summary>
       // private static readonly ProviderInfo info = new ProviderInfo("易宝在线支付", "小菜", "1.0.0.0", "http://www.ebsite.net", "http://www.ebsite.net/Plugin/EbSite.Plugin.Payment.dll");
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


            
            settings.AddParameter("CusID", "客户号", 300, true, true, ParameterType.String);
            settings.AddParameter("PrivateKey", "私钥", 300, true, true, ParameterType.String);
            settings.AddParameter("ImgUpload", "图片上传", 300, true, true, ParameterType.Upload);
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
                return @"YeePay易宝（北京通融通信息技术有限公司）是专业从事多元化电子支付业务一站式服务的领跑者。在立足于网上支付的同时，YeePay易宝不断创新，将互联网、手机、固定电话整合在一个平台上，继短信支付、手机充值之后，首家推出了YeePay易宝电话支付业务，真正实现了离线支付，为更多传统行业搭建了电子支付的高速公路。YeePay易宝融合世界先进的电子支付文化，聚合众多金融、电信、IT、互联网等领域内的巨擘，旨在通过创新的支付机制，推动中国电子商务新进程。YeePay易宝致力于成为世界一流的电子支付应用和服务提供商，专注于金融增值服务和移动增值服务两大领域，创新并推广多元化、低成本的、安全有效的支付服务。";
            }
        }

        #endregion
    }
}

