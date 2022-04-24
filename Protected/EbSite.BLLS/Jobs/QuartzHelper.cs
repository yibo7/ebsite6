using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using System.Collections.Specialized;
using Quartz.Impl;
using System.Data;
using Quartz.Impl.Triggers;
using System.Collections;
using System.IO;
using Quartz.Impl.Calendar;
using Quartz.Spi;
using System.Reflection; 
using System.Web;
using EbSite.Entity;
using Quartz.Impl.Matchers; 

namespace EbSite.BLL.Jobs
{
    
    /// <summary>
    /// 任务处理帮助类
    /// </summary>
    public class QuartzHelper
    {
        private QuartzHelper() { }

        private static object obj = new object();

        //private static string scheme = "tcp";

        //private static string server = SysConfig.QuartzServer;

        //private static string port = SysConfig.QuartzPort;
        /// <summary>
        /// 缓存任务所在程序集信息
        /// </summary>
        private static Dictionary<string, Assembly> AssemblyDict = new Dictionary<string, Assembly>();

        private static IScheduler scheduler = null;


        /// <summary>
        /// 初始化任务调度对象
        /// </summary>
        public static void InitScheduler()
        {
            try
            {
                lock (obj)
                {
                    if (scheduler == null)
                    {
                        #region quartz 实例配置
                        //NameValueCollection properties = new NameValueCollection();

                        //properties["quartz.scheduler.instanceName"] = "ExampleQuartzScheduler";

                        //properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";

                        //properties["quartz.threadPool.threadCount"] = "10";

                        //properties["quartz.threadPool.threadPriority"] = "Normal";

                        //properties["quartz.jobStore.misfireThreshold"] = "60000";

                        //properties["quartz.jobStore.type"] = "Quartz.Simpl.RAMJobStore, Quartz";

                        //properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz";

                        //properties["quartz.scheduler.exporter.port"] = "555";

                        //properties["quartz.scheduler.exporter.bindName"] = "QuartzScheduler";

                        //properties["quartz.scheduler.exporter.channelType"] = scheme;

                        //ISchedulerFactory factory = new StdSchedulerFactory(properties);

                        //scheduler = factory.GetScheduler();
                        #endregion
                        //// 配置文件的方式，配置quartz实例
                        ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
                        scheduler = schedulerFactory.GetScheduler();
                        EbSite.Log.Factory.GetInstance().InfoLog("Quartz正常启动");
                    }
                }
            }
            catch (Exception ex)
            {
                EbSite.Log.Factory.GetInstance().ErrorLog(string.Format("Quartz启动失败:{0}",ex.Message)); 
            }
        }

        /// <summary>
        /// 启用任务调度
        /// 启动调度时会把任务表中状态为“执行中”的任务加入到任务调度队列中
        /// </summary>
        public static void StartScheduler()
        {
            try
            {
                if (!Equals(scheduler,null)&& !scheduler.IsStarted)
                {
                    //添加全局监听
                    scheduler.ListenerManager.AddTriggerListener(new JobTriggerListener());
                    scheduler.Start();

                    //获取所有执行中的任务
                    List<Entity.JobTask> listTask = BLL.JobTask.Instance.FillList();

                    if (listTask != null && listTask.Count > 0)
                    {
                        foreach (Entity.JobTask taskUtil in listTask)
                        {
                            

                            try
                            {
                                ScheduleJob(taskUtil);

                            }
                            catch (Exception e)
                            {
                                EbSite.Log.Factory.GetInstance().ErrorLog(string.Format("任务“{0}”启动失败！{1}", taskUtil.TaskName, e.Message));
                            }
                        }
                    }
                    EbSite.Log.Factory.GetInstance().InfoLog("任务调度启动完成");
                }
            }
            catch (Exception ex)
            {
                EbSite.Log.Factory.GetInstance().ErrorLog("任务调度启动失败:" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化 远程Quartz服务器中的，各个Scheduler实例。
        /// 提供给远程管理端的后台，用户获取Scheduler实例的信息。
        /// </summary>
        //public static void InitRemoteScheduler()
        //{
        //    try
        //    {
        //        NameValueCollection properties = new NameValueCollection();

        //        properties["quartz.scheduler.instanceName"] = "ExampleQuartzScheduler";

        //        properties["quartz.scheduler.proxy"] = "true";

        //        properties["quartz.scheduler.proxy.address"] = string.Format("{0}://{1}:{2}/QuartzScheduler", scheme, server, port);

        //        ISchedulerFactory sf = new StdSchedulerFactory(properties);

        //        scheduler = sf.GetScheduler();
        //    }
        //    catch (Exception ex)
        //    {
        //        EbSite.Log.Factory.GetInstance().ErrorLog("初始化远程任务管理器失败:" + ex.Message);
        //        //LogHelper.WriteLog("初始化远程任务管理器失败" + ex.StackTrace);
        //    }
        //}

        /// <summary>
        /// 删除现有任务
        /// </summary>
        /// <param name="JobKey"></param>
        public static void DeleteJob(string JobKey)
        {
            try
            {
                JobKey jk = new JobKey(JobKey);
                if (scheduler.CheckExists(jk))
                {
                    //任务已经存在则删除
                    scheduler.DeleteJob(jk);
                    EbSite.Log.Factory.GetInstance().InfoLog(string.Format("任务“{0}”已经删除", JobKey));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 启用任务
        /// <param name="task">任务信息</param>
        /// <param name="isDeleteOldTask">是否删除原有任务</param>
        /// <returns>返回任务trigger</returns>
        /// </summary>
        public static void ScheduleJob(Entity.JobTask task, bool isDeleteOldTask = false)
        {
            if (isDeleteOldTask)
            {
                //先删除现有已存在任务
                DeleteJob(task.id.ToString());
            }
            //验证是否正确的Cron表达式
            if (ValidExpression(task.CronExpressionString))
            {
                IJobDetail job;

                if (task.RunType == 1)//程序集模式
                {
                    job = new JobDetailImpl(task.id.ToString(), GetClassInfo(task.AssemblyName, task.ClassName));
                }
                else //url执行模式
                {
                    job = new JobDetailImpl(task.id.ToString(), GetClassInfo("EbSite.Jobs", "EbSite.Jobs.RunUrl"));
                    if (!string.IsNullOrEmpty(task.AssemblyName))
                    {
                        //添加任务执行参数
                        job.JobDataMap.Add("Url", task.AssemblyName);
                    }
                }

                if (!string.IsNullOrEmpty(task.TaskParam))
                {
                    //添加任务执行参数
                    job.JobDataMap.Add("TaskParam", task.TaskParam);
                }
                

                CronTriggerImpl trigger = new CronTriggerImpl();
                trigger.CronExpressionString = task.CronExpressionString;
                trigger.Name = task.id.ToString();
                trigger.Description = task.TaskName;
                scheduler.ScheduleJob(job, trigger);

                //EbSite.Log.Factory.GetInstance().InfoLog(string.Format("任务“{0}”启动成功,未来5次运行时间如下:", task.TaskName));
                
                if (task.Status == 0)//停止状态，将任务置于暂停状态，可在后台开启
                {
                    JobKey jk = new JobKey(task.id.ToString());
                    scheduler.PauseJob(jk);
                }
                task.LastRezult = string.Format("任务启动于:{0}{1}", DateTime.Now, task.Status == 0?"但任务处于暂停状态":"并且成功进入排期队列");
            }
            else
            {
                string err = string.Format("{0}不是正确的Cron表达式,无法启动该任务!任务Id:{1},任务名称:{2}", task.CronExpressionString,
                    task.id, task.TaskName);
                EbSite.Log.Factory.GetInstance().ErrorLog(err);
                task.LastRezult = string.Format("不是正确的Cron表达式,无法启动该任务,运行于:{0}", DateTime.Now);
            }

            BLL.JobTask.Instance.Update(task);
        }

        /// <summary>
        /// 暂停任务
        /// </summary>
        /// <param name="JobKey"></param>
        public static void PauseJob(string JobKey)
        {
            try
            {
                JobKey jk = new JobKey(JobKey);
                if (scheduler.CheckExists(jk))
                {
                    //任务已经存在则暂停任务
                    scheduler.PauseJob(jk);
                    EbSite.Log.Factory.GetInstance().InfoLog(string.Format("任务“{0}”已经暂停", JobKey));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 恢复运行暂停的任务
        /// </summary>
        /// <param name="JobKey">任务key</param>
        public static void ResumeJob(string JobKey)
        {
            try
            {
                JobKey jk = new JobKey(JobKey);
                if (scheduler.CheckExists(jk))
                {
                    //任务已经存在则暂停任务
                    scheduler.ResumeJob(jk);
                    EbSite.Log.Factory.GetInstance().InfoLog(string.Format("任务“{0}”恢复运行", JobKey));
                }
            }
            catch (Exception ex)
            {
                EbSite.Log.Factory.GetInstance().ErrorLog(string.Format("恢复任务失败！{0}", ex));
            }
        }

        /// 获取类的属性、方法  
        /// </summary>  
        /// <param name="assemblyName">程序集</param>  
        /// <param name="className">类名</param>  
        private static Type GetClassInfo(string assemblyName, string className)
        {
            try
            {

                assemblyName = GetAbsolutePath(string.Concat("Jobs/", assemblyName , ".dll"));
                Assembly assembly = null;
                if (!AssemblyDict.TryGetValue(assemblyName, out assembly))
                {
                    assembly = Assembly.LoadFrom(assemblyName);
                    AssemblyDict[assemblyName] = assembly;
                }
                Type type = assembly.GetType(className, true, true);
                return type;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取文件的绝对路径,针对window程序和web程序都可使用
        /// </summary>
        /// <param name="relativePath">相对路径地址</param>
        /// <returns>绝对路径地址</returns>
        public static string GetAbsolutePath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                throw new ArgumentNullException("参数relativePath空异常！");
            }
            relativePath = relativePath.Replace("/", "\\");
            if (relativePath[0] == '\\')
            {
                relativePath = relativePath.Remove(0, 1);
            }
            //判断是Web程序还是window程序
            if (HttpContext.Current != null)
            {
                return Path.Combine(HttpRuntime.AppDomainAppPath, relativePath);
            }
            else
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            }

        }

        /// <summary>
        /// 停止任务调度
        /// </summary>
        public static void StopSchedule()
        {
            try
            {
                //判断调度是否已经关闭
                if (!scheduler.IsShutdown)
                {
                    //等待任务运行完成
                    scheduler.Shutdown(true);
                    EbSite.Log.Factory.GetInstance().InfoLog("任务调度停止");
                    //LogHelper.WriteLog("任务调度停止！");
                }
            }
            catch (Exception ex)
            {
                EbSite.Log.Factory.GetInstance().ErrorLog(string.Format("任务调度停止失败！{0}", ex));
                 
            }
        }

        /// <summary>
        /// 校验字符串是否为正确的Cron表达式
        /// </summary>
        /// <param name="cronExpression">带校验表达式</param>
        /// <returns></returns>
        public static bool ValidExpression(string cronExpression)
        {
            return CronExpression.IsValidExpression(cronExpression);
        }

        /// <summary>
        /// 获取任务在未来周期内哪些时间会运行
        /// </summary>
        /// <param name="CronExpressionString">Cron表达式</param>
        /// <param name="numTimes">运行次数</param>
        /// <returns>运行时间段</returns>
        public static List<DateTime> GetNextFireTime(string CronExpressionString, int numTimes)
        {


            if (numTimes < 0)
            {
                throw new Exception("参数numTimes值大于等于0");
            }
            //时间表达式
            ITrigger trigger = TriggerBuilder.Create().WithCronSchedule(CronExpressionString).Build();
            IList<DateTimeOffset> dates = TriggerUtils.ComputeFireTimes(trigger as IOperableTrigger, null, numTimes);
            List<DateTime> list = new List<DateTime>();
            foreach (DateTimeOffset dtf in dates)
            {
                list.Add(TimeZoneInfo.ConvertTimeFromUtc(dtf.DateTime, TimeZoneInfo.Local));
            }
            return list;
        }


        public static object CurrentTaskList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取当前执行的Task 对象
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Entity.JobTask GetTaskDetail(IJobExecutionContext context)
        {
            Entity.JobTask task = new Entity.JobTask();

            if (context != null)
            {

                task.id = Guid.Parse(context.Trigger.Key.Name);
                task.TaskName = context.Trigger.Description;
                task.RecentRunTime = DateTime.Now;
                task.TaskParam = context.JobDetail.JobDataMap.Get("TaskParam") != null ? context.JobDetail.JobDataMap.Get("TaskParam").ToString() : "";
            }
            return task;
        }
    }
}