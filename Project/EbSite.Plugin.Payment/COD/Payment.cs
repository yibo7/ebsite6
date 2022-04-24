using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;

namespace EbSite.Plugin.Payment.COD
{
    [Extension("货到付款", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class Payment : IPayment
    {
        

        public string Description
        {
            get
            {
                return "货到付款";
            }
        }

        public string GetPayStr(string OrderName, string TotalPrice, string OrderNumber)
        {
            //ConfigString.GetSingleValue("InfoLink");

            //ConfigString.GetSingleValue("ImgUpload");
            string virtualPath = HostApi.IISPath;
            //string[] strArray = QueryArray.Split(new char[] { ',' });
            //if (strArray.Length != 2)
            //{
            //    strArray = (QueryArray + ",").Split(new char[] { ',' });
            //}
            return ("<a target='_blank' href='" + ConfigString.GetSingleValue("InfoLink") + "'><img src='" + virtualPath + ConfigString.GetSingleValue("ImgUpload") + "' border=0></a>");
        }

        public string QueryArray
        {
            get
            {
                return "按钮图片,说明信息链接";
            }
        }

       

        #region 对插件底层接口的实现


        /// <summary>
        /// 设置插件信息
        /// </summary>
       // private static readonly ProviderInfo info = new ProviderInfo("货到付款", "小菜", "1.0.0.0", "http://www.ebsite.net", "http://www.ebsite.net/Plugin/EbSite.Plugin.Payment.dll");
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

          
          
            settings.AddParameter("InfoLink", "说明信息链接", 100, true, true, ParameterType.String);
            settings.AddParameter("ImgUpload", "按钮图片", 300, true, true, ParameterType.Upload);
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
                return @"货到付款    ";
            }
        }

        #endregion
    }
}

