//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Web;
//using EbSite.Base.Plugin;
////using EbSite.Core.Static.OneCreatManager;

//namespace EbSite.Core.Timers
//{
//    public class TimerTask
//    {
//        private static Timer GetOrderTimer;
//        private static long OrderInterval = Base.Configs.SchedulTask.ConfigsControl.Instance.Index_TimerLength * 60000; //分钟
//        public delegate void WorkerThreadExceptionHandlerDelegate(Exception e, HttpContext context);
//        public static void InitTimer()
//        {

//            if (GetOrderTimer == null)
//            {
//                GetOrderTimer = new Timer(new TimerCallback(MakeHTML),
//                                             HttpContext.Current, OrderInterval,
//                                          OrderInterval);

//            }
//        }
//        private static void MakeHTML(object sender)
//        {
//            //注意这个转换确保一定不要发生错误,否则异常无法获取到
//            HttpContext mdHttp = (HttpContext)sender;
//            try
//            {

//                ITimerTask[] lst = Collectors.UseITimerTaskCollector.AllProviders;

//                foreach (ITimerTask tt in lst)
//                {
//                    tt.CallTask();
//                }
//            }
//            catch (Exception e)
//            {

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
