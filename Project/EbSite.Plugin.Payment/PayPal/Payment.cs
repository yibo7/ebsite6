using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;
using System.Text;
namespace EbSite.Plugin.Payment.PayPal
{
    [Extension("PayPal", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class Payment : IPayment
    {
        

        public string Description
        {
            get
            {
                return "PayPal";
            }
        }
        public string GetPayStr(string OrderName, string TotalPrice, string OrderNumber)
        {
            //ConfigString.GetSingleValue("CusID");
            //ConfigString.GetSingleValue("PrivateKey");
            //ConfigString.GetSingleValue("ImgUpload");

            //string[] strArray = QueryArray.Split(new char[] { ',' });
            //if (strArray.Length != 4)
            //{
            //    strArray = (QueryArray + ",,,").Split(new char[] { ',' });
            //}
            string virtualPath = HostApi.IISPath;
            StringBuilder builder = new StringBuilder();
            builder.Append("<form id=\"payment\" action=\"https://www.paypal.com/cgi-bin/webscr\" method=\"post\">");
            builder.Append("<input name=\"cmd\" type=\"hidden\" value=\"_xclick\" />");
            builder.Append("<input name=\"business\" type=\"hidden\" value=\"" + ConfigString.GetSingleValue("CusID") + "\" />");
            builder.Append("<input name=\"item_name\" type=\"hidden\" value=\"" + OrderName + "\" />");
            builder.Append("<input name=\"item_number\" type=\"hidden\" value=\"" + OrderName + "\" />");
            builder.Append("<input name=\"amount\" type=\"hidden\" value=\"" + TotalPrice + "\" />");
            builder.Append("<input name=\"currency_code\" type=\"hidden\" value=\"USD\" />");
            builder.Append("<input name=\"return\" type=\"hidden\" value=\"" + virtualPath + "member/CallBack/ReturnPage_PayPal.aspx\" />");
            builder.Append("<input name=\"notify_url\" type=\"hidden\" value=\"" + virtualPath + "member/CallBack/ReturnPage_PayPal.aspx\" />");
            builder.Append("<input name=\"lc\" type=\"hidden\" value=\"US\" />");
            builder.Append("<input type=\"image\" src=\"" + virtualPath + ConfigString.GetSingleValue("ImgUpload") + "\" />");
            builder.Append("</form>");
            return builder.ToString();
        }

        public string QueryArray
        {
            get
            {
                return "支付按钮图片,私钥,客户号";
            }
        }



        #region 对插件底层接口的实现


        /// <summary>
        /// 设置插件信息
        /// </summary>
       // private static readonly ProviderInfo info = new ProviderInfo("PayPal", "小菜", "1.0.0.0", "http://www.ebsite.net", "http://www.ebsite.net/Plugin/EbSite.Plugin.Payment.dll");
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
          

            settings.AddParameter("CusID", "客户号", 100, true, true, ParameterType.String);
            settings.AddParameter("PrivateKey", "私钥", 100, true, true, ParameterType.String);

            settings.AddParameter("ImgUpload", "图片上传", 200, true, true, ParameterType.Upload);
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
                return @"PayPal      ";
            }
        }

        #endregion
    }
}

