using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;

namespace EbSite.Plugin.Payment.ChinaBank
{
    
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Security;

    [Extension("网银在线", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class Payment : IPayment
    {
        
        public string Description
        {
            get
            {
                return "网银在线（北京）科技有限公司自成立以来，凭借强大的技术实力和良好的服务理念，以“电子支付专家”为发展定位，致力于为国内中小型企业提供完善的电子支付解决方案。";
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

            //string[] strArray = QueryArray.Split(new char[] { ',' });
            //if (strArray.Length != 3)
            //{
            //    strArray = ",,,".Split(new char[] { ',' });
            //}
            string str = ConfigString.GetSingleValue("CusID");// strArray[0];
            string str2 = "CNY";
            string str3 = "http://" + this.GetNowUrl() + "/member/CallBack/ReturnPage_ChinaBank.aspx";
            string str4 = ConfigString.GetSingleValue("PrivateKey");// strArray[1];
            string str6 = FormsAuthentication.HashPasswordForStoringInConfigFile(TotalPrice + str2 + OrderName + str + str3 + str4, "MD5");
            StringBuilder builder = new StringBuilder();
            builder.Append("<form method='post' action='https://pay3.chinabank.com.cn/PayGate' name='E_FORM' target=new>");
            builder.Append("<input type='hidden' name='v_md5info' size='100'  value='" + str6 + "'>");
            builder.Append("<input type='hidden' name='v_mid' value='" + str + "'>");
            builder.Append("<input type='hidden' name='v_oid' value='" + OrderName + "'>");
            builder.Append("<input type='hidden' name='v_amount' value='" + TotalPrice + "'>");
            builder.Append("<input type='hidden' name='v_moneytype'  value='" + str2 + "'>");
            builder.Append("<input type='hidden' name='v_url' value='" + str3 + "'>");
            builder.Append("<input type='hidden' name='style' value='0'>");
            builder.Append("<input type='hidden' name='remark1' value=''>");
            builder.Append("<input type='hidden' name='remark2' value=''>");
            builder.Append("<input type=submit name=v_action value='网银在线支付'>");
            builder.Append("</form>");
            return builder.ToString();
        }

        //public string QueryArray
        //{
        //    get
        //    {
        //        return "支付按钮图片,私钥,客户号";
        //    }
        //}


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




        public ExtensionSettings GetSettings()
        {
            string sSettingsName = this.GetType().FullName;

            ExtensionSettings settings = new ExtensionSettings(sSettingsName);

     

            settings.AddParameter("CusID", "客户号", 300, true, true, ParameterType.StringMax);
            settings.AddParameter("PrivateKey", "私钥", 300, true, true, ParameterType.StringMax);
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
                return @"网银在线（北京）科技有限公司是2003年6月在中关村注册的高新技术企业，注册资金1000万人民币。自成立以来，凭借强大的技术实力和良好的服务理念，以“电子支付专家”为发展定位，联合中国银行、中国工商银行、中国农业银行、中国建设银行、招商银行等国内各大银行，以及VISA、MasterCard、JCB等国际信用卡组织，致力于为国内中小型企业提供完善的电子支付解决方案。     ";
            }
        }

        #endregion

    }
}

