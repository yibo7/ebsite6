//using System;
//using EbSite.Base;
//using EbSite.Base.Plugin;
//using EbSite.Base.Plugin.Base;
//using tenpay;
//using System.Collections;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Web;
//namespace EbSite.Plugin.Payment.TenpayNew
//{
//    public class Payment : IPayment
//    {



//        public string Description
//        {
//            get
//            {
//                return "财付通网站 (www.tenpay.com) 作为功能强大的支付平台，是由中国最早、最大的互联网即时通信软件开发商腾讯公司创办，为最广大的QQ用户群提供安全、便捷、简单的在线支付服务。";

//            }
//        }

//        public string GetNowUrl()
//        {
//            string input = string.Empty;
//            string pattern = @"http://(?<domain>[^\/]*)";
//            input = HttpContext.Current.Request.Url.ToString();
//            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
//            return regex.Match(input).Groups["domain"].Value;
//        }

//        public string GetPayStr(string OrderName, string TotalPrice)
//        {
//            string virtualPath = HostApi.IISPath;
//            StringBuilder builder = new StringBuilder();
//            decimal num = decimal.Parse(TotalPrice) * 100M;
//            string parameterValue = num.ToString().Replace(".00", "");
//            string[] strArray = QueryArray.Split(new char[] { ',' });
//            if (strArray.Length != 3)
//            {
//                strArray = ",,".Split(new char[] { ',' });
//            }
//            string str3 = "1202530401";
//            string str4 = strArray[0];
//            string key = strArray[1];
//            string str7 = "" + DateTime.Now.ToString("HHmmss") + TenpayUtil.BuildRandomStr(4);
//            string str8 = "http://" + this.GetNowUrl() + virtualPath + "member/CallBack/ReturnPage_TenpayNewServer.aspx";
//            string str9 = "http://" + this.GetNowUrl() + virtualPath + "member/CallBack/ReturnPage_TenpayNew.aspx";
//            MediPayRequest request = new MediPayRequest(HttpContext.Current);
//            request.setKey(key);
//            request.init();
//            request.setParameter("chnid", str3);
//            request.setParameter("seller", str4);
//            request.setParameter("mch_vno", OrderName);
//            request.setParameter("mch_returl", str8);
//            request.setParameter("show_url", str9);
//            request.setParameter("mch_name", OrderName);
//            request.setParameter("mch_desc", "订单号：" + OrderName);
//            request.setParameter("mch_price", parameterValue);
//            request.setParameter("encode_type", "2");
//            request.setParameter("transport_desc", "");
//            request.setParameter("transport_fee", "0");
//            request.setParameter("need_buyerinfo", "1");
//            request.setParameter("mch_type", "1");
//            request.setParameter("attach", "");
//            request.getRequestURL();
//            builder.Append("<form method=\"post\" target='_blank' action=\"" + request.getGateUrl() + "\" >\n");
//            Hashtable hashtable = request.getAllParameters();
//            foreach (DictionaryEntry entry in hashtable)
//            {
//                builder.Append(string.Concat(new object[] { "<input type=\"hidden\" name=\"", entry.Key, "\" value=\"", entry.Value, "\" >\n" }));
//            }
//            builder.Append("<input type='image' src='" + virtualPath + strArray[2] + "'>\n</form>\n");
//            return builder.ToString();
//        }

//        public string QueryArray
//        {
//            get
//            {
//                return "支付图片,私钥,客户号";
//            }

//        }


//        #region 对插件底层接口的实现


//        /// <summary>
//        /// 设置插件信息
//        /// </summary>
//        private static readonly ProviderInfo info = new ProviderInfo("财付通在线支付(担保交易)", "小菜", "1.0.0.0", "http://www.ebsite.net", "http://www.ebsite.net/Plugin/EbSite.Plugin.Payment.dll");
//        private IHost HostApi;
//        private string ConfigString;
//        /// <summary>
//        /// 初始化插件。这是类调用的第一个方法。
//        /// </summary>
//        /// <param name="host">提供了访问主系统的api</param>
//        /// <param name="config">Configuration string for the plugin.</param>
//        public void Init(IHost host, string config)
//        {
//            this.HostApi = host;
//            ConfigString = config;
//        }

//        /// <summary>
//        /// 注销插件后将调用此办法
//        /// </summary>
//        public void Shutdown()
//        {

//        }

//        /// <summary>
//        /// 插件信息，如开发者，版本等
//        /// </summary>
//        public ProviderInfo Information
//        {
//            get
//            {
//                return info;
//            }
//        }

//        /// <summary>
//        /// HTML文本显示为插件的帮助配置信息
//        /// </summary>
//        public string ConfigHelpHtml
//        {
//            get
//            {
//                return @"财付通网站 (www.tenpay.com) 作为功能强大的支付平台，是由中国最早、最大的互联网即时通信软件开发商腾讯公司创办，为最广大的QQ用户群提供安全、便捷、简单的在线支付服务。<a href=""http://union.tenpay.com/mch/mch_register.shtml?sp_suggestuser=1202530401"" target=""_blank"" style=""font-weight:bold; color:#CC0000"">立即注册</a>";
//            }
//        }

//        #endregion
//    }
//}

