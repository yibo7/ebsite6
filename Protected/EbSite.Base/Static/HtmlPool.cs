using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using Amib.Threading;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Page;
using EbSite.Core.FSO;

namespace EbSite.Base.Static
{
    public class HtmlMake
    {
        
        public string Url { get; set; }
        public string SavePath { get; set; }
        public HttpContext _HttpContext { get; set; }
        public bool IsUtf8 { get; set; }
        public object ToHtml(object sender)
        {
            //这里会出问题 要处理异常
            try
            {
                string shtml = Core.WebUtility.LoadURLString(Url);
                MakeingEventArgs ea = new MakeingEventArgs(shtml);
                
                //在生成前对html进行事件处理
                EbSite.Base.EBSiteEvents.OnHTMLMakeing(null, ea);

                if (!IsUtf8)
                    Core.FSO.FObject.WriteFile(SavePath, ea.Html);
                else
                {
                    Core.FSO.FObject.WriteFileUtf8(SavePath, ea.Html);
                }
            }
            catch (Exception e)
            {
                //
                string sREFERER = "";
                if (!Equals(_HttpContext, null))
                {
                      sREFERER =Core.Utils.GetReferer(_HttpContext);
                    //sREFERER = _HttpContext.Request.ServerVariables["HTTP_REFERER"];
                }
                Log.Factory.GetInstance().ErrorLog(string.Format("来路页面:{4};在线程池中生成静态页面发生错误原因:1.可能请求的地址无法打开，请检查，2.可能写入文件出错，检查是否有写入权限！，请求静态页的源地址:{0},异常信息:{1}，{2}，{3}", Url, e.Message, e.Source, e.StackTrace, sREFERER));
                EbSite.BLL.CusttomLog.InsertLogs("在线程池中生成静态页面发生错误(通用)", string.Format("来路页面:{4};在线程池中生成静态页面发生错误原因:1.可能请求的地址无法打开，请检查，2.可能写入文件出错，检查是否有写入权限！，请求静态页的源地址:{0},异常信息:{1}，{2}，{3}", Url, e.Message,e.Source,e.StackTrace, sREFERER), _HttpContext, "");
                

            }

            return 1;
        }
    }
    public enum ETimeSpanModel:int
    {
        /// <summary>
        /// 天
        /// </summary>
        T = 0,
        /// <summary>
        /// 小时
        /// </summary>
        XS = 1,
        /// <summary>
        /// 分钟
        /// </summary>
        FZ = 2,
        /// <summary>
        /// 秒
        /// </summary>
        M = 3
    }
    public class HtmlPool
    {
        static public bool IsHtmlOverdue(string HtmlPath, int timeSpan, int timeSpanModel)
        {
            DateTime dt = System.IO.File.GetLastWriteTime(HtmlPath);
         
            //(（静态页面的生成时间 + 时间差） - 当前时间 <= 0)，生成与之对应的静态页面
            if (timeSpanModel==0)//天
            {
                return (DateTime.Compare(dt.AddDays(timeSpan), DateTime.Now) <= 0);
            }
            else if (timeSpanModel == 1)//小时
            {
                return (DateTime.Compare(dt.AddHours(timeSpan), DateTime.Now) <= 0);
            }
            else //分钟
            {
                return (DateTime.Compare(dt.AddMinutes(timeSpan), DateTime.Now) <= 0);
            }
            

        }
        static public bool IsHtmlOverdue(string HtmlPath)
        {
            int timeSpan = Configs.HtmlConfigs.ConfigsControl.Instance.HtmlTimeSpan;
            int timeSpanModel = Configs.HtmlConfigs.ConfigsControl.Instance.HtmlTimeSpanModel;
            return IsHtmlOverdue(HtmlPath, timeSpan, timeSpanModel);
        }

        #region 通用
        /// <summary>
        /// 在线程池生成一个缓存页面,如果缓存页面已经存在并且没有过期，直接返回缓存文件
        /// </summary>
        /// <param name="CacheFile">缓存文件相对路径，如 /AllCacheFile/Class/1.htm</param>
        /// <param name="RealUrl">相对真实访问路径,如 /class/news1-2.ashx</param>
        /// <param name="TimeSpan">时间间隔</param>
        /// <param name="TimeSpanModel">时间间隔类型，过期方式,0.天，1小时,2分钟</param>
        /// <returns></returns>
        static public string GetCacheUrl(string CacheFile, string RealUrl, int TimeSpan, int TimeSpanModel)
        {
            if(RealUrl.LastIndexOf("$ebcacherequest$")==-1) //防止重复处理
            {
                //真实保存目录
                string thissavepath = HttpContext.Current.Server.MapPath(CacheFile);
                //如果缓存文件不存在，要生成一个，比如第一访问就不会存在
                if (!Core.FSO.FObject.IsExist(thissavepath, FsoMethod.File))
                {
                    GetCacheUrl_M(thissavepath, RealUrl);
                    return RealUrl;
                }
                else //如果缓存文件存在，将有两种情况，一种是没有过期，直接返回缓存文件url,一种，已经过期
                {
                    if (IsHtmlOverdue(thissavepath, TimeSpan, TimeSpanModel)) //判断缓存文件是否已经过期
                    {
                        GetCacheUrl_M(thissavepath, RealUrl);
                    }
                    return CacheFile;
                }
            }
            else
            {
                return RealUrl;
            }
        }

        /// <summary>
        /// 在线程池生成一个缓存页面,如果缓存页面已经存在并且没有过期，直接返回缓存文件
        /// </summary>
        /// <param name="CacheFile">缓存文件相对路径，如 /AllCacheFile/Class/1.htm</param>
        /// <param name="RealUrl">相对真实访问路径,如 /class/news1-2.ashx</param>
        /// <returns></returns>
        static public string GetCacheUrl(string CacheFile, string RealUrl)
        {
            int timeSpan = Configs.HtmlConfigs.ConfigsControl.Instance.HtmlTimeSpan;  
            int timeSpanModel = Configs.HtmlConfigs.ConfigsControl.Instance.HtmlTimeSpanModel;
            return GetCacheUrl(CacheFile, RealUrl, timeSpan, timeSpanModel);
        }
        static public void GetCacheUrl_M(string CachePath, string RealUrl)
        {
            GetCacheUrl_M(CachePath, RealUrl,true);
        
        }

        //生成一个文件并返回真实地址
        static public void GetCacheUrl_M(string CachePath, string RealUrl,bool IsUtf8)
        {
            HtmlMake html = new HtmlMake();
            html._HttpContext = HttpContext.Current;
            html.Url = string.Concat(Host.Instance.Domain, RealUrl, RealUrl.IndexOf("?") > 1 ? "&" : "?", "$ebcacherequest$"); //string.Concat("http://", HttpContext.Current.Request.Url.Authority, RealUrl, RealUrl.IndexOf("?")>1?"&":"?", "$ebcacherequest$");
            html.SavePath = CachePath;
            html.IsUtf8 = IsUtf8;
            //ThreadPool.QueueUserWorkItem(new WaitCallback(html.ToHtml));

            IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(html.ToHtml), null);

        }

        #endregion

        

    }
}
