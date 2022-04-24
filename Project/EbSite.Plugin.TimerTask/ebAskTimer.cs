//using System;
//using System.Collections.Generic;
//using System.Net.Mail;
//using System.Net.Mime;
//using System.Text.RegularExpressions;
//using System.Web;
//using EbSite.Base;
//using EbSite.Base.EntityAPI;
//using EbSite.Base.Extension;
//using EbSite.Base.Extension.Manager;
//using EbSite.Base.Plugin;
//using EbSite.Base.Plugin.Base;
//using EbSite.Core;
//using EbSite.Core.FSO;

//namespace EbSite.Plugin.TimerTask
//{

//    [Extension("适用于问答站点,定时过期问题处理业务", "1.0", "<a href=\"http://www.ebsite.net\">小乐乐</a>")]
//    public class ebAskTimer : ITimerTask
//    {

//        /// <summary>
//        /// 处理定时执行的任务
//        /// </summary>
//        public void CallTask()
//        {
//            if (_SiteID > 0)
//            {
//                string strsql = "annex21=1 and  now()> annex9";
//                List<Entity.NewsContent> slst = EbSite.Base.AppStartInit.NewsContentInstDefault.GetListArray(strsql, 0, "",
//                                                                                                             "",
//                                                                                                             _SiteID);
//                foreach (var newsContent in slst)
//                {
//                    newsContent.Annex21 = 3;//不满意 关闭
//                    newsContent.Annex10 = DateTime.Now.ToString();
//                    Base.AppStartInit.NewsContentInstDefault.Update(newsContent);
//                    //扣分
//                    if (_Score > 0)
//                    {
//                        EbSite.Base.Host.Instance.MinusUserCreditsByID(newsContent.UserID, _Score);
//                    }
//                }
//            }

//        }


//        #region 对插件底层接口的实现

//        public ExtensionSettings GetSettings()
//        {

//            string sSettingsName = this.GetType().FullName;
//            ExtensionSettings settings = new ExtensionSettings(sSettingsName);

//            settings.AddParameter("txtSiteID", " 问答站点ID", 100, true, true, ParameterType.String);

//            settings.AddParameter("txtScore", " 过期扣除的分数，请和问题配置中一致", 100, true, true, ParameterType.String);
            
//            settings.IsScalar = true;

//            PluginManager.Instance.ImportSettings(settings);

//            return PluginManager.Instance.GetSettings(sSettingsName);

//        }
//        private Host HostApi;
//        private ExtensionSettings ConfigString;
//        private int _SiteID;
//        private int _Score;
//        /// <summary>
//        /// 初始化插件。这是类调用的第一个方法。
//        /// </summary>
//        /// <param name="host">提供了访问主系统的api</param>
//        /// <param name="config">Configuration string for the plugin.</param>
//        public void Init(Host host, ExtensionSettings config)
//        {
//            this.HostApi = host;
//            ConfigString = config;
//            _SiteID = EbSite.Core.Utils.StrToInt(ConfigString.GetSingleValue("txtSiteID"), 10);//站点id
//            _Score = EbSite.Core.Utils.StrToInt(ConfigString.GetSingleValue("txtScore"), 1);//过期扣除的分数 
//        }

//        /// <summary>
//        /// 注销插件后将调用此办法
//        /// </summary>
//        public void Shutdown()
//        {

//        }

//        /// <summary>
//        /// HTML文本显示为插件的帮助配置信息
//        /// </summary>
//        public string ConfigHelpHtml
//        {
//            get
//            {
//                return @"
//<div>
//  <b>使用帮助:</b><br/>
//  <ul>
//    <li>在后台安装后，可以在系统的配置里选择。</li>
//  </ul>
//</div>
//      ";
//            }
//        }

//        #endregion
        
//    }



//}
