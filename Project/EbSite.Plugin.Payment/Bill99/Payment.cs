using System;
using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;

namespace EbSite.Plugin.Payment.Bill99
{
    
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Security;

    [Extension("快钱在线支付", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class Payment : IPayment
    {
        private string appendParam(string returnStr, string paramId, string paramValue)
        {
            if (returnStr != "")
            {
                if (paramValue != "")
                {
                    string str2 = returnStr;
                    returnStr = str2 + "&" + paramId + "=" + paramValue;
                }
                return returnStr;
            }
            if (paramValue != "")
            {
                returnStr = paramId + "=" + paramValue;
            }
            return returnStr;
        }

        public string Description
        {
            get
            {
                return "快钱在线支付";
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
            //ConfigString.GetSingleValue("Account");
            //ConfigString.GetSingleValue("PrivateKey");
            //ConfigString.GetSingleValue("ImgUpload");

            string virtualPath = HostApi.IISPath;
         
            string paramValue = ConfigString.GetSingleValue("Account");// strArray[0];
            string str3 = ConfigString.GetSingleValue("PrivateKey"); //strArray[1];
            string str4 = "1";
            string str5 = HttpContext.Current.Request.Url.ToString();
            string str6 = OrderName;
            string str7 = Math.Round((decimal) (decimal.Parse(TotalPrice) * 100M), 0).ToString();
            string str8 = DateTime.Now.ToString("yyyyMMddHHmmss");
            string str9 = "10015365633";
            string str10 = "00";
            string str11 = "0";
            string str12 = "v2.0";
            string str13 = "1";
            string str14 = "1";
            string str15 = "";
            string str16 = "";
            string returnStr = "";
            string str18 = "http://" + this.GetNowUrl() + "/member/CallBack/ReturnPage_Bill99.aspx";
            string str19 = "";
            string str20 = "1";
            string str21 = "";
            string str22 = OrderName;
            string str23 = "1";
            string str24 = "";
            string str25 = "";
            string str26 = "";
            returnStr = this.appendParam(returnStr, "inputCharset", str4);
            returnStr = this.appendParam(returnStr, "pageUrl", str18);
            returnStr = this.appendParam(returnStr, "bgUrl", str5);
            returnStr = this.appendParam(returnStr, "version", str12);
            returnStr = this.appendParam(returnStr, "language", str13);
            returnStr = this.appendParam(returnStr, "signType", str14);
            returnStr = this.appendParam(returnStr, "merchantAcctId", paramValue);
            returnStr = this.appendParam(returnStr, "payerName", str19);
            returnStr = this.appendParam(returnStr, "payerContactType", str20);
            returnStr = this.appendParam(returnStr, "payerContact", str21);
            returnStr = this.appendParam(returnStr, "orderId", str6);
            returnStr = this.appendParam(returnStr, "orderAmount", str7);
            returnStr = this.appendParam(returnStr, "orderTime", str8);
            returnStr = this.appendParam(returnStr, "productName", str22);
            returnStr = this.appendParam(returnStr, "productNum", str23);
            returnStr = this.appendParam(returnStr, "productId", str24);
            returnStr = this.appendParam(returnStr, "productDesc", str25);
            returnStr = this.appendParam(returnStr, "ext1", str15);
            returnStr = this.appendParam(returnStr, "ext2", str16);
            returnStr = this.appendParam(returnStr, "payType", str10);
            returnStr = this.appendParam(returnStr, "bankId", str26);
            returnStr = this.appendParam(returnStr, "redoFlag", str11);
            returnStr = this.appendParam(returnStr, "pid", str9);
            string str27 = FormsAuthentication.HashPasswordForStoringInConfigFile(this.appendParam(returnStr, "key", str3), "MD5").ToUpper();
            string str28 = "";
            str28 = ((((((((((((((((((((((((str28 + "<form name='kqPay' method='post' action='https://www.99bill.com/gateway/recvMerchantInfoAction.htm' target='_blank'>") + "<input type='hidden' name='inputCharset' value='" + str4 + "'>") + "<input type='hidden' name='bgUrl' value='" + str5 + "'>") + "<input type='hidden' name='pageUrl' value='" + str18 + "'>") + "<input type='hidden' name='version' value='" + str12 + "'>") + "<input type='hidden' name='language' value='" + str13 + "'>") + "<input type='hidden' name='signType' value='" + str14 + "'>") + "<input type='hidden' name='signMsg' value='" + str27 + "'>") + "<input type='hidden' name='merchantAcctId' value='" + paramValue + "'>") + "<input type='hidden' name='payerName' value='" + str19 + "'>") + "<input type='hidden' name='payerContactType' value='" + str20 + "'>") + "<input type='hidden' name='payerContact' value='" + str21 + "'>") + "<input type='hidden' name='orderId' value='" + str6 + "'>") + "<input type='hidden' name='orderAmount' value='" + str7 + "'>") + "<input type='hidden' name='orderTime' value='" + str8 + "'>") + "<input type='hidden' name='productName' value='" + str22 + "'>") + "<input type='hidden' name='productNum' value='" + str23 + "'>") + "<input type='hidden' name='productId' value='" + str24 + "'>") + "<input type='hidden' name='productDesc' value='" + str25 + "'>") + "<input type='hidden' name='ext1' value='" + str15 + "'>") + "<input type='hidden' name='ext2' value='" + str16 + "'>") + "<input type='hidden' name='payType' value='" + str10 + "'>") + "<input type='hidden' name='bankId' value='" + str26 + "'>") + "<input type='hidden' name='redoFlag' value='" + str11 + "'>") + "<input type='hidden' name='pid' value='" + str9 + "'>";
            return ((str28 + "<input type='image' src='" + virtualPath + ConfigString.GetSingleValue("ImgUpload") + "'>") + "</form>");
        }

        public string QueryArray
        {
            get
            {
                return "支付按钮图片,交易安全校验码,帐号";
            }
        }

        #region 对插件底层接口的实现


        /// <summary>
        /// 设置插件信息
        /// </summary>
       // private static readonly ProviderInfo info = new ProviderInfo("快钱在线支付", "小菜", "1.0.0.0", "http://www.ebsite.net", "http://www.ebsite.net/Plugin/EbSite.Plugin.Payment.dll");
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


            settings.AddParameter("Account", "帐号", 100, true, true, ParameterType.String);
            settings.AddParameter("PrivateKey", "交易安全校验码", 100, true, true, ParameterType.String);

            settings.AddParameter("ImgUpload", "支付按钮图片", 200, true, true, ParameterType.Upload);
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
                return @"上海快钱信息服务有限公司是国内第一家提供基于EMAIL和手机号码的网上收付款服务的互联网企业。快钱已同中国建设银行、中国银联、中国农业银行、中国银行、招商银行、交通银行、华夏银行、中国光大银行、中信银行、深圳发展银行、广东发展银行等结成战略合作并推出网上交易的收付款服务，服务覆盖国内外27亿张银行卡。（网址：http://www.99bill.com） <a href=""http://agent.99bill.com/agent/jsp/agent/onlineprotocol/agentProtocol.do?act=check&agentno=shwb01"" target=_blank><font color=""#ff0000""><strong>立即申请</strong></font></a> ";
            }
        }

        #endregion

    }
}

