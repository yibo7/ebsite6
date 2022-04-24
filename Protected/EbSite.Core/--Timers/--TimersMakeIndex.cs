//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Web;
//using Amib.Threading;
//using EbSite.Base;
//using EbSite.Base.Static.OneCreatManager;
//using EbSite.BLL.GetLink;
//using EbSite.Entity;

////using EbSite.Core.Static.OneCreatManager;

//namespace EbSite.Core.Timers
//{
//    //public class IndexHtmlInfo
//    //{
//    //    public string sUrl { get; set; }
//    //    public string sFilePath { get; set; }
//    //     public void MakeIndex()
//    //    {
           
//    //    }

//    //}
//    public class TimersMakeIndex 
//    {
//        private static Timer GetOrderTimer;
//        private static long OrderInterval = Base.Configs.SchedulTask.ConfigsControl.Instance.Index_TimerLength * 60000; //15分钟 
//        public delegate void WorkerThreadExceptionHandlerDelegate(Exception e, HttpContext context);
//        public static void InitTimer()
//        {

//            if (GetOrderTimer == null)
//            {
//                GetOrderTimer = new Timer(new TimerCallback(MakeIndex),
//                                             HttpContext.Current, OrderInterval,
//                                          OrderInterval);

//            }
//        }
//        private static void MakeIndex(object sender)
//        {
         


//            //注意这个转换确保一定不要发生错误,否则异常无法获取到
//            HttpContext mdHttp = (HttpContext)sender;
//            string RealUrl = string.Empty;
//            string CachePath = string.Empty;
//            try
//            {
//                List<Entity.Sites> lst =  BLL.Sites.Instance.FillList();
//                //IndexCreate Instance = new IndexCreate();
//                foreach (Entity.Sites md in lst)
//                {
//                    //Instance.MakeHtml(md.id);
//                    EbSite.Base.Static.HtmlMake htmlMake = new Base.Static.HtmlMake();
//                    htmlMake._HttpContext = HttpContext.Current;
//                     RealUrl = LinkOrther.Instance.GetAspxInstance(md.id).GetMainIndexHref();
//                     CachePath = LinkOrther.Instance.GetHtmlInstance(md.id).GetMainIndexHref();
//                    if (!string.IsNullOrEmpty(CachePath))
//                    {
//                        if (CachePath.StartsWith("/"))
//                        {
//                            CachePath = mdHttp.Server.MapPath(CachePath);
//                        }
//                        else
//                        {
//                            CachePath = mdHttp.Server.MapPath(string.Concat(EbSite.Base.Host.Instance.IISPath,CachePath));
//                        }

//                        htmlMake.Url = string.Concat("http://", mdHttp.Request.Url.Authority, RealUrl, RealUrl.IndexOf("?") > 1 ? "&" : "?", "$timermake$");
//                        htmlMake.SavePath = CachePath;
//                        htmlMake.IsUtf8 = true;
//                        //htmlMake.ToHtml(mdHttp);
//                        IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(htmlMake.ToHtml), null);
//                    }
                   
//                }
                
                
//            }
//            catch (Exception e)
//            {
//                string sUrl = string.Empty;

//                if (mdHttp != null)
//                {
//                    sUrl = mdHttp.Request.RawUrl;
//                }

//                EbSite.BLL.HTMLLog.InsertLogs(string.Format("自动生成首页发生错误,来源:{0}", sUrl), string.Format("真实页面{0}，写入地址{1},错误信息:{2}",RealUrl, CachePath, e.Message));
                
//                ///通过delegate转向工作线程的异常处理
//                new WorkerThreadExceptionHandlerDelegate(WorkerThreadExceptionHandler).BeginInvoke(e, mdHttp, null, null);

//            }
//        }
//        public static void Dispose()
//        {
//            GetOrderTimer = null;

//        } 
//        /// <summary>
//        /// 工作线程的异常处理
//        /// </summary>
//        /// <param name="e"></param>
//        public static void WorkerThreadExceptionHandler(Exception e, HttpContext context)
//        {
//            /**/
//            ///添加其他的处理代码

//            ///通知全局异常处理程序
//            MainUIThreadExceptionHandler(context, new System.Threading.ThreadExceptionEventArgs(e));
//        }
//        //// <summary>
//        /// 主线程全局异常信息的处理
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="t"></param>
//        public static void MainUIThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
//        {
//            HttpContext Context = (HttpContext)sender;

//            //SwordWeb.Common.AplicationGlobal.ExtLog.Write(e.Exception.Message, e.Exception.StackTrace, "", "", LogType.ApplicationError);

//        }

       
//    }
//}
