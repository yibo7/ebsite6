using System;
using Quartz;

namespace EbSite.BLL.Jobs
{
    /// <summary>
    /// 自定义触发器监听
    /// </summary>
    public class JobTriggerListener : ITriggerListener
    {
        public string Name
        {
            get { return "All_TriggerListener"; }
        }

        /// <summary>
        /// Job执行时调用
        /// </summary>
        /// <param name="trigger">触发器</param>
        /// <param name="context">上下文</param>
        public void TriggerFired(ITrigger trigger, IJobExecutionContext context)
        {

        }


        /// <summary>
        ///  //Trigger触发后，job执行时调用本方法。true即否决，job后面不执行。
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
        {
            string sKey = trigger.JobKey.Name;
            //Log.Factory.GetInstance().InfoLog("VetoJobExecution:" + sKey);
            try
            {
                var model = BLL.JobTask.Instance.GetEntity(new Guid(sKey));

                model.RecentRunTime = TimeZoneInfo.ConvertTimeFromUtc(context.FireTimeUtc.Value.DateTime, TimeZoneInfo.Local);

                BLL.JobTask.Instance.Update(model);
            }
            catch (Exception e)
            {
                 Log.Factory.GetInstance().ErrorLog(string.Format("在VetoJobExecution更新任务运行时间出错,{0},任务Id:{1}",e.Message, sKey));
            } 
            return false;
        }

        /// <summary>
        /// Job完成时调用
        /// </summary>
        /// <param name="trigger">触发器</param>
        /// <param name="context">上下文</param>
        /// <param name="triggerInstructionCode"></param>
        public void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode)
        {
            
            string sKey = context.JobDetail.Key.Name;
            //Log.Factory.GetInstance().InfoLog("TriggerComplete:"+ sKey);
            try
            {
                var model = BLL.JobTask.Instance.GetEntity(new Guid(sKey));

                model.NextFireTime =  TimeZoneInfo.ConvertTimeFromUtc(context.NextFireTimeUtc.Value.DateTime, TimeZoneInfo.Local);
                model.LastRezult = string.Format("任务最后一次执行完成于:{0}",DateTime.Now);
                BLL.JobTask.Instance.Update(model);
            }
            catch (Exception e)
            {
                Log.Factory.GetInstance().ErrorLog(string.Format("在TriggerComplete更新任务下次运行时间出错,{0},任务Id:{1}", e.Message, sKey));
            }
            //TaskHelper.UpdateNextFireTime(trigger.JobKey.Name, TimeZoneInfo.ConvertTimeFromUtc(context.NextFireTimeUtc.Value.DateTime, TimeZoneInfo.Local));
        }

        /// <summary>
        /// 错过触发时调用
        /// </summary>
        /// <param name="trigger">触发器</param>
        public void TriggerMisfired(ITrigger trigger)
        {
            Log.Factory.GetInstance().ErrorLog(string.Format("Jobs任务错过触发调用,任务Id:{0}", trigger.JobKey.Name));
        }
    }
    
}