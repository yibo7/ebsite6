using System;
using System.Collections.Generic;
using System.Web;
using Amib.Threading;
using EbSite.Base;
using EbSite.BLL.GetLink;
using Quartz;
using WorkItemCallback = System.Web.Util.WorkItemCallback;

namespace EbSite.Jobs
{
    /// <summary>
    /// 定时更新首页
    /// </summary>
    /// <remarks>
    /// 该Job有两个自定义声明，分明说明如下：
    /// 1.PersistJobDataAfterExecution:支持多次执行数据持久化到该对象中，每次执行完毕之后，会把数据放入JobDataMap，以便下次使用。
    /// 2.DisallowConcurrentExecution:不允许并发执行，如果服务开时执行时，上次执行还没有完成，则等待上次完成后，本次执行才开始；
    /// </remarks>
    [DisallowConcurrentExecution]
    public class RunUrl : IJob
    {

        public void Execute(IJobExecutionContext context)
        {

            var dataMap = context.JobDetail.JobDataMap;

            string sUrl = dataMap.GetString("Url");

            if (!string.IsNullOrEmpty(sUrl))
            {
                //当前任务的主键，可以通过这个获取任务实体,并操作任务实体
                string sJobKey = context.JobDetail.Key.Name;

                try
                {
                    Entity.JobTask model = BLL.JobTask.Instance.GetEntity(new Guid(sJobKey));

                    if (!sUrl.StartsWith("http://") && !sUrl.StartsWith("https://"))
                    {
                        sUrl = string.Concat(Base.Host.Instance.Domain, Base.Host.Instance.IISPath, sUrl);
                    }

                    if (sUrl.IndexOf("?") > -1)
                    {
                        sUrl = string.Concat(sUrl, "&");
                    }
                    else
                    {
                        sUrl = string.Concat(sUrl, "?");
                    }
                    sUrl = string.Concat(sUrl, "key=", sJobKey,"&tk=", Host.Instance.EncodeByMD5(Host.Instance.EncodeByKey(sJobKey)));

                    model.RunUrl = sUrl;

                    IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(LoadUrl, model);


                }
                catch (Exception e)
                {
                    Log.Factory.GetInstance()
                        .ErrorLog(string.Format("执行Url任务失败:{0},KEY:{1};执行URL:{2}", e.Message, sJobKey, sUrl));
                }

            }
            else
            {
                Log.Factory.GetInstance().ErrorLog("执行Url任务失败,KEY:" + context.JobDetail.Key.Name + ";执行URL:" + sUrl);
            }
        }

        public object LoadUrl(object model)
        {
            Entity.JobTask md = model as Entity.JobTask;

            if (!Equals(md, null))
            {
                try
                {
                    string sContent = Core.WebUtility.LoadURLString(md.RunUrl);
                    string sInfo = "远程返回状态未知";
                    if (!string.IsNullOrEmpty(sContent))
                    {
                        if (sContent.IndexOf("成功") > -1)
                        {
                            sInfo = "远程返回成功标记信息";
                        }
                        else if (sContent.IndexOf("失败") > -1)
                        {
                            sInfo = string.Format("执行Url任务失败:远程返回失败,KEY:{0};执行URL:{1},{2}", md.id, md.RunUrl, "远程返回失败标记信息,请分析远程程序日志");  
                            
                        }

                    }
                    md.LastRezult = string.Format("在{0}调用了远程地址{1},{2}", DateTime.Now, md.RunUrl, sInfo);

                }
                catch (Exception e)
                {
                    md.LastRezult = string.Format("执行Url任务失败:远程返回失败,KEY:{0};执行URL:{1}", md.id, md.RunUrl);
                    Log.Factory.GetInstance().ErrorLog(string.Format("执行Url任务失败:远程返回失败,KEY:{0};执行URL:{1}，错误:{2}", md.id, md.RunUrl, e.Message));
                     
                }
                BLL.JobTask.Instance.Update(md);
            }
            else
            {
                Log.Factory.GetInstance().ErrorLog("执行Url任务失败:,错误:在线程队列中无法将任务实体转换成功");
            }

            return 1;
        }
    }
}