using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Web;
using EbSite.Base;
using EbSite.Base.EntityAPI;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.Plugin.TimerTask
{
    /// <summary>
    /// 定时生成静态页面
    /// </summary>
    public class TimerTaskHTML : ITimerTask
    {


        /// <summary>
        /// 处理定时执行的任务
        /// </summary>
        public void CallTask()
        {
            foreach (HtmlInfo htmlInfo in HtmlInfos)
            {
                FObject.WriteFile(htmlInfo.SavePath, htmlInfo.GetHtml(), false);
            }
        }
        private string ReplacePram(string str)
        {
            string sClassID = "0";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["cid"]))
                sClassID =  HttpContext.Current.Request["cid"];

            str = str.Replace("#IISPATH#", HostApi.IISPath);
            str = str.Replace("#Domain#", HostApi.Domain);
            str = str.Replace("#ClassID#", sClassID);
            str = str.Replace("#UserID#", HostApi.UserID.ToString());
            return str;
        }

        private List<HtmlInfo> HtmlInfos;

        #region 对插件底层接口的实现
       
       
        /// <summary>
        /// 设置插件信息
        /// </summary>
        private static readonly ProviderInfo info = new ProviderInfo("定时生成静态页面", "小菜", "1.0.0.0", "http://www.ebsite.cn", "http://www.ebsite.cn/Plugin/TimerTaskHTML.dll");
        private IHost HostApi;
        private string ConfigString;
        /// <summary>
        /// 初始化插件。这是类调用的第一个方法。
        /// </summary>
        /// <param name="host">提供了访问主系统的api</param>
        /// <param name="config">Configuration string for the plugin.</param>
        public  void Init(IHost host, string config)
        {
            this.HostApi = host;
            ConfigString = config;
            
            if(!string.IsNullOrEmpty(ConfigString))
            {
                HtmlInfos = new List<HtmlInfo>();

                Regex re = new Regex("\r\n"); //回车正则

                string[] arr = re.Split(ConfigString);
                foreach (string s in arr)
                {
                    string[] aInfo = s.Split('|');
                    if(aInfo.Length==2)
                    {
                        HtmlInfo md = new HtmlInfo();
                        md.SoureUrl = ReplacePram(aInfo[0]);
                        md.SavePath = ReplacePram(aInfo[1]);
                        md.SavePath = string.Concat(HostApi.sMapPath, md.SavePath);

                        HtmlInfos.Add(md);
                    }
                }
            }
            
        }

        /// <summary>
        /// 注销插件后将调用此办法
        /// </summary>
        public  void Shutdown()
        {

        }

        /// <summary>
        /// 插件信息，如开发者，版本等
        /// </summary>
        public  ProviderInfo Information
        {
            get
            {
                return info;
            }
        }
        
        /// <summary>
        /// HTML文本显示为插件的帮助配置信息
        /// </summary>
        public  string ConfigHelpHtml
        {
            get
            {
                return @"
<div>
  <b>使用帮助:</b><br/>
  <div>格式为: <br>源地址1|相对目标存放地址1<br>源地址2|相对目标存放地址2<br>源地址3|相对目标存放地址3
<br>其中源地址为全网址，如http://www.163.com/index.aspx,如果是本站，也可以用#Domain#来替换，如#Domain##IISPATH#index.aspx
<br>相对目标存放地址注意是相对地址,如要将生成的文件存放在 相好目录的test文件夹里，这样写:#IISPATH#test/index.htm  
</div>
<div>
  <ul>
    <li>动态参数:#IISPATH#-代码当前安装网站的虚拟目录</li>
    <li>#Domain#-网站域名,如http://www.ebsite.cn</li>
    <li>#ClassID#-获取当前rul传来的分类ID</li>
    <li>#UserID#-获取当前登录用户的ID</li>
  </ul>
</div>
</div>
      ";
            }
        }

        #endregion
    }

    public class HtmlInfo
    {
        public HtmlInfo()
        {
        }

        public HtmlInfo(string _SoureUrl, string _SavePath)
        {
            SoureUrl = _SoureUrl;
            SavePath = _SavePath;
        }
        public string SoureUrl;
        public string SavePath;

        public string GetHtml()
        {
            return Utils.GetData(SoureUrl);
        }

    }

}
