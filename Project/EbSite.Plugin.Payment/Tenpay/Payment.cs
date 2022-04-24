using System;
using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
namespace EbSite.Plugin.Payment.Tenpay
{

    [Extension("财付通", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class Payment : IPayment
    {


        public string Description
        {
            get
            {
                return "财付通网站 (www.tenpay.com) 作为功能强大的支付平台，是由中国最早、最大的互联网即时通信软件开发商腾讯公司创办，为最广大的QQ用户群提供安全、便捷、简单的在线支付服务。";
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
            //    strArray = ",,".Split(new char[] { ',' });
            //}
            string str2 = "1202530401";
            string str3 = OrderName;
            string str4 = ConfigString.GetSingleValue("PrivateKey");// strArray[1];
            string str5 = DateTime.Now.ToString("yyyyMMdd");
            string str6 = "1";
            string str7 = ConfigString.GetSingleValue("CusID");// strArray[0];
            string str8 = ConfigString.GetSingleValue("CusID");// strArray[0];
            string str9 = OrderName;
            string str10 = str7 + str5 + str9.Substring(0, 10);
            decimal num = decimal.Parse(TotalPrice) * 100M;
            string str11 = num.ToString().Replace(".00", "");
            string str12 = "1";
            string str13 = "http://" + this.GetNowUrl() + "/member/CallBack/ReturnPage_Tenpay.aspx";
            string str16 = FormsAuthentication.HashPasswordForStoringInConfigFile("agentid=" + str2 + "&attach=my_magic_string&bank_type=0&bargainor_id=" + str8 + "&cmdno=" + str6 + "&date=" + str5 + "&desc=" + str3 + "&fee_type=" + str12 + "&key_index=2&return_url=" + str13 + "&sp_billno=" + str9 + "&total_fee=" + str11 + "&transaction_id=" + str10 + "&ver=3&verify_relation_flag=1&key=" + str4, "MD5");
            StringBuilder builder = new StringBuilder();
            builder.Append("<form action='https://www.tenpay.com/cgi-bin/v1.0/pay_gate.cgi' target='_blank' method='get'>");
            builder.Append("<input type=hidden name='agentid'\tvalue='" + str2 + "'>");
            builder.Append("<input type=hidden name='attach'\tvalue='my_magic_string'>");
            builder.Append("<input type=hidden name='bank_type'\tvalue='0'>");
            builder.Append("<input type=hidden name='bargainor_id'\tvalue='" + str8 + "'>");
            builder.Append("<input type=hidden name='cmdno'\tvalue='" + str6 + "'>");
            builder.Append("<input type=hidden name='date'\tvalue='" + str5 + "'>");
            builder.Append("<input type=hidden name='desc'\tvalue='" + str3 + "'>");
            builder.Append("<input type=hidden name='fee_type'\tvalue='" + str12 + "'>");
            builder.Append("<input type=hidden name='key_index'\tvalue='2'>");
            builder.Append("<input type=hidden name='return_url'\tvalue='" + str13 + "'>");
            builder.Append("<input type=hidden name='sp_billno'\tvalue='" + str9 + "'>");
            builder.Append("<input type=hidden name='total_fee'\tvalue='" + str11 + "'>");
            builder.Append("<input type=hidden name='transaction_id'\tvalue='" + str10 + "'>");
            builder.Append("<input type=hidden name='ver'\tvalue='3'>");
            builder.Append("<input type=hidden name='verify_relation_flag'\tvalue='1'>");
            builder.Append("<input type=hidden name='key'\tvalue='" + str4 + "'>");
            builder.Append("<input type=hidden name='sign'\tvalue='" + str16 + "'>");
            builder.Append("<input type='image' src='" + virtualPath + ConfigString.GetSingleValue("ImgUpload") + "'>");
            builder.Append("</form>");
            return builder.ToString();
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
        // private static readonly ProviderInfo info = new ProviderInfo("财付通在线支付", "小菜", "1.0.0.0", "http://www.ebsite.net", "http://www.ebsite.net/Plugin/EbSite.Plugin.Payment.dll");
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

           
            settings.AddParameter("CusID", " 客户号", 100, true, true, ParameterType.String);
            settings.AddParameter("PrivateKey", " 私钥", 100, true, true, ParameterType.String);
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
                return @"财付通网站 (www.tenpay.com) 作为功能强大的支付平台，是由中国最早、最大的互联网即时通信软件开发商腾讯公司创办，为最广大的QQ用户群提供安全、便捷、简单的在线支付服务。<a href=""http://union.tenpay.com/mch/mch_register.shtml?sp_suggestuser=1202530401"" target=""_blank"" style=""font-weight:bold; color:#CC0000"">立即注册</a> ";
            }
        }

        #endregion
    }
}

