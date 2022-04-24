using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Util;
using EbSite.Base;
using EbSite.Base.Plugin;
using EbSite.BLL.GetLink; 
using Quartz;

namespace EbSite.Jobs
{
    /// <summary>
    /// 商品solr任务
    /// </summary>
    /// <remarks>
    /// 该Job有两个自定义声明，分明说明如下：
    /// 1.PersistJobDataAfterExecution:支持多次执行数据持久化到该对象中，每次执行完毕之后，会把数据放入JobDataMap，以便下次使用。
    /// 2.DisallowConcurrentExecution:不允许并发执行，如果服务开时执行时，上次执行还没有完成，则等待上次完成后，本次执行才开始；
    /// </remarks>
    [DisallowConcurrentExecution]
    public class TimerTaskForPlugin : IJob
    {
        
        public void Execute(IJobExecutionContext context)
        {
            try
            {

                ITimerTask[] lst = Collectors.UseITimerTaskCollector.AllProviders;
                foreach (ITimerTask tt in lst)
                {
                    //tt. 在这里进行时间过期处理
                    tt.CallTask();
                }
            }
            catch (Exception e)
            {

                EbSite.Log.Factory.GetInstance().ErrorLog("在执行定时插件任务时发生错误："+e.Message);

            }

        }
    }
}