using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base;
using EbSite.Base.EntityAPI;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;

namespace EbSite.Plugin.Delivery
{
    [Extension("快递100查询插件", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class KuaiDi100 : IDelivery
    {
        /// <summary>
        /// 查询快递返回状态
        /// </summary>
        /// <param name="com">要查询的快递公司代码，不支持中文，对应的公司代码见</param>
        /// <param name="number">要查询的快递单号，请勿带特殊符号，不支持中文（大小写不敏感）</param>
        /// <param name="datatype">返回类型：0：返回json字符串， 1：返回xml对象， 2：返回html对象， 3：返回text文本。 </param>
        /// <param name="muti">返回信息数量：1:返回多行完整的信息， 0:只返回一行信息。 不填默认返回多行。</param>
        /// <param name="orderby">排序方式:0 按时间由新到旧排列 desc，1 按时间由旧到新排列 asc</param>
        /// <returns></returns>
        public  string GetStatusStr(string com, string number, int datatype, int muti, int orderby)
        {
            //排序： desc：按时间由新到旧排列， asc：按时间由旧到新排列。 不填默认返回倒序（大小写不敏感）
            string apikey  = ConfigString.GetSingleValue("apikey");
            if (!string.IsNullOrEmpty(apikey))
            {
                   
                string sOrderBy = "desc";
                if (orderby == 1)
                {
                    sOrderBy = "asc";
                }
                string url =
                string.Format(
                    "http://api.kuaidi100.com/api?id={0}&com={1}&nu={2}&show={3}&muti={4}&order={5}", apikey, com, number, datatype, muti, sOrderBy);
                string c = EbSite.Core.WebUtility.LoadURLStringUTF8(url);

                return c;
            }
            else
            {
                throw new Exception("没有设置快递100的身份验证key,如果没有申请，请到快递100先申请此key");
            }
            
        }
        /// <summary>
        /// 快递单当前的状态,0：在途中, 1：已发货， 2：疑难件， 3：已签收， 4：已退货。 
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        private string GetState(int st)
        {
            string s = "未知";
            switch (st)
            {
                case 0:
                    s = "在途中";
                    break;
                case 1:
                    s = "已发货";
                    break;
                case 2:
                    s = "疑难件";
                    break;

                case 3:
                    s = "已签收";
                    break;
                case 4:
                    s = "已退货";
                    break;
            }
            return s;
        }
        public KuaiDi GetStatusList(string com, string number,  int orderby)
        {
            string rz = GetStatusStr(com, number, 0, 1, orderby);

            KuaiDi100JsonModel md = EbSite.Core.JsonHelper.DataContractJsonDeserialize<KuaiDi100JsonModel>(rz);
            //List<KuaiDi> lst = new List<KuaiDi>();
            KuaiDi mdKuaiDi = new KuaiDi();
            if (!md.status.Equals("2"))
            {
                if (!Equals(md.data, null))
                {
                    mdKuaiDi.Com = md.com;
                    mdKuaiDi.Number = md.nu;
                    mdKuaiDi.QStatus = md.status;
                    int state = 100;
                    int.TryParse(md.state, out state);
                    mdKuaiDi.State = GetState(state);
                    foreach (KuaiDi100JsonModelState st in md.data)
                    {
                        mdKuaiDi.Data.Add(new KuaiDiData(){Time = st.time,Context = st.context});

                    }
                }
                
            }
            else
            {
                string msg = string.Format("第三方快递查询发生错误，请检查{0}{1}", com, number);
                EbSite.Base.Host.Instance.InsertLog(msg, msg);
            }
            return mdKuaiDi;

        }

        /// <summary>
        /// 配送公司的网址
        /// </summary>
        public string Url
        {
            get
            {
                return "http://www.kuaidi100.com";
            }

        }
        #region 对插件底层接口的实现

        public ExtensionSettings GetSettings()
        {

            string sSettingsName = this.GetType().FullName;
            ExtensionSettings settings = new ExtensionSettings(sSettingsName);
            settings.AddParameter("apikey", "身份授权key", 100, true, true, ParameterType.String);

            settings.Help = ConfigHelpHtml;
            //是否单个
            settings.IsScalar = true;

            PluginManager.Instance.ImportSettings(settings);

            return PluginManager.Instance.GetSettings(sSettingsName);

        }
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
                return @"快递100查询插件。";

            }
        }

        #endregion
    }

    public class KuaiDi100JsonModel
    {
        public string message { get; set; }
        public string nu { get; set; }
        public string ischeck { get; set; }
        public string com { get; set; }
        public string condition { get; set; }
        public string status { get; set; }
        public string state { get; set; }
        public List<KuaiDi100JsonModelState> data;
        
    }

    public class KuaiDi100JsonModelState
    {
        public string context { get; set; }
        public string time { get; set; }
    }

}
