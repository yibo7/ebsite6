using System;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Base.Static.OneCreatManager
{
    public abstract class HtmlBase
    {
        
        public abstract string MakeHtml(int SiteID);
        //public static event EventHandler<EventArgs> Erred;
        ///// <summary>
        ///// 生成页面发生错误调用
        ///// </summary>
        ///// <param name="log"></param>
        ///// <param name="arg"></param>
        //public static void OnErr(Entity.Logs log, EventArgs arg)
        //{
        //    if (Erred != null)
        //    {
        //        Erred(log, arg);
        //    }
        //}

     
        

        private string _sFilePath;
        /// <summary>
        /// 文件的生成目录(相对路径)
        /// </summary>
        public string sFilePath
        {
            get
            {
                return _sFilePath;
            }
            set
            {
                _sFilePath = value;
            }
        }
        private string _sUrl;
        /// <summary>
        /// 网页地址
        /// </summary>
        public string sUrl
        {
            get
            {
                return _sUrl;
            }
            set
            {
                _sUrl = value;
            }
        }
        /// <summary>
        /// 生成内容
        /// </summary>
        private string sHtmlContent
        {
            get
            {
                string strHtml = string.Empty;

                //在用户将系统设置成自动静态的时候生成静态时要做个标志


                if (sUrl.IndexOf(".aspx?") > 0)
                {
                    sUrl = string.Concat(sUrl, "&$html$");
                }
                else
                {
                    sUrl = string.Concat(sUrl, "?$html$");
                }

                strHtml = EbSite.Core.Utils.GetData(sUrl);
                return strHtml;
            }
        }
        /// <summary>
        /// 获取生成文件绝对路径包括文件名称
        /// </summary>
        private string GetSavePath
        {
            get
            {

                return string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, sFilePath);
            }
        }
        /// <summary>
        /// 生成静态页面
        /// </summary>
        /// <returns></returns>
        public string CreatHtmls(ref string shtmlContent)
        {
            string strReturn = string.Empty;
            EbSite.Entity.Logs mdLogs = null;
            if (!string.IsNullOrEmpty(sFilePath))
            {
                
                string sHtml = sHtmlContent;
                shtmlContent = sHtml;
                if (sHtml.IndexOf(Base.Configs.HtmlConfigs.ConfigsControl.Instance.GetHtmlErr) == -1)
                {
                    try
                    {
                        MakeingEventArgs ea = new MakeingEventArgs(sHtml);
                        //在生成前对html进行事件处理
                        EbSite.Base.EBSiteEvents.OnHTMLMakeing(null, ea);

                        FObject.WriteFileUtf8(GetSavePath, ea.Html);
                        strReturn = "生成成功:" + sUrl;
                    }
                    catch (Exception exc)
                    {
                        strReturn = exc.Message;
                        mdLogs = new Logs();
                        //mdLogs.id = Guid.NewGuid();
                        mdLogs.Title = string.Concat("生成错误:", sUrl);
                        mdLogs.Description = exc.Message;
                        mdLogs.AddDate = DateTime.Now;

                    }

                }
                else
                {
                    mdLogs = new Logs();
                    //mdLogs.ID = Guid.NewGuid();
                    mdLogs.Title = string.Concat("生成错误:", sUrl);
                    mdLogs.Description = sHtml;
                    mdLogs.AddDate = DateTime.Now;
                    strReturn = sHtml;
                }

                
            }
            else
            {
                strReturn = "生成路径为空:sFilePath值没有取到";
                mdLogs = new Logs();
                mdLogs.Title = string.Concat("生成错误:", sUrl);
                mdLogs.Description = strReturn;
                mdLogs.AddDate = DateTime.Now;
                
            }
            if (!Equals(mdLogs, null))
            {
                EventArgs eag = new EventArgs();
                EbSite.Base.EBSiteEvents.OnMakeHtmlErred(mdLogs, eag);
            }
            return strReturn;
        }


    }

}
