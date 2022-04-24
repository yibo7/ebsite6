using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Util;
using EbSite.Base;
using EbSite.BLL.GetLink;
using Quartz;

namespace EbSite.Jobs
{
    /// <summary>
    /// 更新站点地图
    /// </summary>
    /// <remarks>
    /// 该Job有两个自定义声明，分明说明如下：
    /// 1.PersistJobDataAfterExecution:支持多次执行数据持久化到该对象中，每次执行完毕之后，会把数据放入JobDataMap，以便下次使用。
    /// 2.DisallowConcurrentExecution:不允许并发执行，如果服务开时执行时，上次执行还没有完成，则等待上次完成后，本次执行才开始；
    /// </remarks>
    [DisallowConcurrentExecution]
    public class UpdateSiteMap : IJob
    {
        static private DateTime dtLastUpdate = DateTime.Now.AddDays(10);
        public void Execute(IJobExecutionContext context)
        {
            
            try
            { 
                int timeSpan = Base.Configs.ContentSet.ConfigsControl.Instance.MapPl;//单位小时
                long h = Core.Strings.cConvert.DateDiff("h", dtLastUpdate, DateTime.Now);
                if (h > timeSpan)
                {
                    EbSite.BLL.SiteMap sm = new BLL.SiteMap();
                    sm.Save();

                    dtLastUpdate = DateTime.Now;
                     
                }

                //EbSite.Log.Factory.GetInstance().InfoLog("更新网站地图成功");

            }
            catch (Exception e)
            {
                EbSite.Log.Factory.GetInstance().ErrorLog(string.Format("更新网站地图失败：{0}",e.Message));
            }
           
        }
    }
}