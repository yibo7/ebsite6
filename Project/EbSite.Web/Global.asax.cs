using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Profile;
using System.Web.Routing;
//using System.Web.Security;
//using Bootstrap.Extensions.StartupTasks;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Modules;
using EbSite.BLL.Jobs;
using EbSite.Core;
using EbSite.Core.Resource;
using EbSite.Core.Strings;
using EbSite.Entity; 
using EbSite.Web.WebCore;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;

namespace EbSite.Web
{ 
    public class Global : System.Web.HttpApplication
    {

        
        
        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Lock();
             
            Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath = AppDomain.CurrentDomain.BaseDirectory;
            Base.Configs.SysConfigs.ConfigsControl.SaveConfig();
            AppStartInit.InitSites();
            AreaRegistration.RegisterAllAreas();

            # region 让系统支持MVC
            GlobalConfiguration.Configure(Mvc.AppStart.WebApiConfig.Register);
            Mvc.AppStart.FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            Mvc.AppStart.RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mvc.AppStart.BundleConfig.RegisterBundles(BundleTable.Bundles);

            EbSite.Base.EBSiteEvents.EbMvcRouteHandler += new EventHandler<MvcRouteHandlerEventArgs>(OnMvcRouteHandlerEventArgs);

            #endregion

            // 强制使api返回为json 而非xml
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //ModelBinders.Binders.Add(typeof(ObjectId), new ObjectIdModelBinder()); 对mongdb 的 ObjectId提供支持


            EbSite.Base.EBSiteEvents.OnApplicationStart(sender, e);
            
            ThreadPoolManager.Init(3);//默认开户3线程来处理事情，在进入request后可以根据配置来初始化，这里默认加载，以防回收未能执行request时出错
            
            //访问htm页面时将不请求Application_BeginRequest,导致dEbBaseLinks无法载入
            AppStartInit.LoadEbBaseLinksAndTemp();

            AppStartInit.LoadTemplatesToCache();
            AppStartInit.LoadUrlRuleToCache();

            //生成未完成的html静态任务
            //Core.Static.BatchCreatManager.MakeUtils.MakeUndone();

            // 2022-4-20 不想再支持mvc模块 
            //Bootstrap.Bootstrapper.With.StartupTasks().Start();
            
            
            Application.UnLock();
            

        }

        private void OnMvcRouteHandlerEventArgs(object sender, MvcRouteHandlerEventArgs e)
        {
            if (Equals(e.Action, "ueditor"))
            {
                e.CustomHandler = new EbSite.UEditor.UEditorHandler();
            }
        }
        protected void Application_End(object sender, EventArgs e)
        {
            Log.Factory.GetInstance().InfoLog(string.Format("系统发生一次回收或关闭事件,时间：{0}", DateTime.Now));
            EBSiteEvents.OnApplicationEnd(sender, e);

            try
            {
                if (!Equals(FirstRequestInit.scheduler, null))
                    FirstRequestInit.scheduler.Shutdown();
            }
            catch (Exception ex)
            {
                Log.Factory.GetInstance().ErrorLog(string.Format("系统发生一次回收或关闭事件关闭scheduler出错:Message:{0},StackTrace:{1},Source:{2},出错的方法名:{3}", ex.Message,
                            ex.StackTrace, ex.Source, ex.TargetSite.Name));
            }




            /*
             * 可以解决IIS回收出现的以下问题：
             1.保持定时器再次启用
             2.当模块里有重写时，并且重写后缀不是aspx,ashx等asp.net默认后缀时出现404的错误，如重写为.htm,.shtml,.html等。
             */
            Thread.Sleep(1000); //先停留10秒再关闭
            FirstRequestInit._initializedAlready = false;//发现有时虽然回收了，但此类还存在
            string url = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName, "/appstart.ashx");

            Thread threadCpuInfo = new Thread(() =>
            {
                //Thread.Sleep(10000);不能加这个，导致这个执行也被回收
                try
                {
                    HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    Stream receiveStream = myHttpWebResponse.GetResponseStream();
                    Log.Factory.GetInstance().InfoLog(string.Format("系统请求启动完成,时间：{0}", DateTime.Now));
                }
                catch (Exception ex)
                {
                    Log.Factory.GetInstance().ErrorLog(string.Format("Application_End请求地址{4}发生错误:Message:{0},StackTrace:{1},Source:{2},出错的方法名:{3}", ex.Message,
                                ex.StackTrace, ex.Source, ex.TargetSite.Name, url));
                }

            });

            threadCpuInfo.Start();

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                EBSiteEvents.OnApplicationError(sender, e);
                string info = "未知错误";
                
                if (Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpenAppLog)
                {
                     

                    Exception ex = Server.GetLastError().GetBaseException();
                    //如果发生的是404将不处理，交给404页面处理
                    if (ex.GetType() == typeof(HttpException))
                    {
                        HttpException httpEx = (HttpException)ex;
                        if (httpEx.GetHttpCode() == 404)
                        {
                            return;
                        }
                    }

                    info = string.Format("Message:{0},StackTrace:{1},Source:{2},出错的方法名:{3}", ex.Message,
                        ex.StackTrace, ex.Source, ex.TargetSite.Name);


                    string hostIP = "";
                    string path = "";
                    string referer = "";
                    string sUserAgent = "";
                    string sStatusCode = "不能获取";
                    if (HttpContext.Current != null)
                    {
                        if (!string.IsNullOrEmpty(HttpContext.Current.Request.RawUrl))
                            path = HttpContext.Current.Request.Url.AbsoluteUri; 
                        if (!string.IsNullOrEmpty(HttpContext.Current.Request.UserHostAddress))
                            hostIP = HttpContext.Current.Request.UserHostAddress;
                         referer = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
                        sUserAgent = HttpContext.Current.Request.UserAgent;

                        if (ex.GetType() == typeof(HttpCompileException))
                        {
                            HttpCompileException httpEx = (HttpCompileException)ex;
                            HttpContext.Current.Response.StatusCode = httpEx.GetHttpCode();
                            sStatusCode = HttpContext.Current.Response.StatusCode.ToString();
                             
                        }

                        //HttpContext.Current.Response.StatusCode = 503;
                    }

                    Entity.Logs mdLogs = new Entity.Logs();
                    mdLogs.Title = string.Concat("来自Application_Error异常处理:", path, " \n来路:", referer);
                    mdLogs.Description = string.Concat("\n来路:", referer,"\n状态:", sStatusCode, " \n请求地址:", path, " \nUserAgent参数:\n", sUserAgent, "\n详细:\n", info);
                    mdLogs.IP = hostIP;
                    mdLogs.AddDate = DateTime.Now;
                    BLL.AppErrLog.InsertLogs(mdLogs);
                    
                    //Server.Transfer("~/errapp.aspx");
                    Server.ClearError();
                }
                else
                {

                }



            }
            catch (Exception ex)
            {
                AppStartInit.LastErr = string.Format("来自Application_Error无法处理的错误，请注意，{0},源:{1},过程:{2}", ex.Message, ex.Source, ex.StackTrace);

                //Server.ClearError();
            }
             

        }
        protected void Session_Start(object sender, EventArgs e)
        {

            //可以在配置里设置是否开启session共享，如果你将session存在类似redis这样的第三方平台，并且ebsite站点为分布式，这时请开启以下代码，并且设置相同的cookie域
            //Response.Cookies["ASP.NET_SessionId"].Value = Session.SessionID;
            //string cookieDomain = EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
            //if (!string.IsNullOrEmpty(cookieDomain))
            //{
            //    Response.Cookies["ASP.NET_SessionId"].Domain = cookieDomain;

                 
            //}

            EbSite.BLL.TimeOutPost.Instance.Init();//在每个用户第一次访问网站写入cookie

            EBSiteEvents.OnSessionStart(sender,e);
        }
        protected void Session_End(object sender, EventArgs e)
        {
            EBSiteEvents.OnSessionEnd(sender, e);
        }
        /// <summary>
        /// Sets the culture based on the language selection in the settings.
        /// </summary>
        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            EBSiteEvents.OnApplicationEnd(sender, e);
            string culture = Base.Configs.SysConfigs.ConfigsControl.Instance.Culture;
            if (!string.IsNullOrEmpty(culture) && !culture.Equals("Auto"))
            {
                CultureInfo defaultCulture = Utils.GetDefaultCulture(culture);
                Thread.CurrentThread.CurrentUICulture = defaultCulture;
                Thread.CurrentThread.CurrentCulture = defaultCulture;
            }
        }

        //private static bool _initializedAlready = false;
        //private readonly static object _SyncRoot = new Object();

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
            #region 过滤恶意提交
            //   //遍历Post参数，隐藏域除外 
            // foreach (string i in Request.Form)
            //{
            //     if (i == "__VIEWSTATE") continue;
            //     this.goErr(this.Request.Form[i]);
            // }
            // //遍历Get参数。 
            //foreach (string i in Request.QueryString)
            //{
            //    this.goErr(Request.QueryString[i]);
            //}
            #endregion
           
            HttpApplication app = (HttpApplication)sender;
            HttpContext context = app.Context;
            //在Application_Start无法获取上下文，所以要在这里执行
            FirstRequestInit.Initialize(context);

            EBSiteEvents.OnApplicationBeginRequest(sender, e);
            


        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        
        ///// <summary>
        ///// 找到导致异常的最初错误
        ///// </summary>
        //private void GetLastError(Exception e, ref string title, ref string info)
        //{
        //    if (e.InnerException != null)
        //        GetLastError(e.InnerException, ref title, ref info);
        //    else
        //    {
        //        title = e.Message;
        //        info = e.StackTrace;
        //    }
        //}
        

       

        // Carry over profile property values from an anonymous to an authenticated state 
        protected void Profile_MigrateAnonymous(Object sender, ProfileMigrateEventArgs e)
        {

            EBSiteEvents.OnProfile_MigrateAnonymousStarting(sender, e);

            
        }

    }


     class FirstRequestInit
    {
        public static bool _initializedAlready = false;
        private readonly static object _SyncRoot = new Object();
       static public IScheduler scheduler;
        // 在第一次请求时执行
        public static void Initialize(HttpContext context)
        {
            
            if (_initializedAlready) { return; }

            lock (_SyncRoot)
            {
                if (_initializedAlready) { return; }

                //网站启动时招行一些数据初始化操作,需要预先缓存的全局数据可以在这里载入
                AppStartInit.ApplicationStartInitData();
                Exchanger.ResourceExchanger = new ResourceExchanger();
                //启用插件
                EbSite.Base.AppStartInit.LoadPlugins();

                Base.Host.Instance.Init();//为了保持在插件里也可以使用Host对象，而缓存又在插件里运行，所以在插件载入后再初始缓存对象，不能在构造方法里实现
                //执行webform模块启动方法
                ModuleStartInitBll.ModuleStart(context);
                //启用动态组件
                Base.Extension.Manager.ExtensionManager.Instance.LoadAppCode();
 

                QuartzHelper.InitScheduler();
                QuartzHelper.StartScheduler();
                 

                _initializedAlready = true;
            }
        }

       

    }
}