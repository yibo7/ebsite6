//using System;
//using System.Collections.Generic;
//using System.Data;
//using EbSite.Base;
//using EbSite.Base.DataProfile;
//using EbSite.Core;
//using EbSite.Data.Interface;
//using EbSite.Entity;
//using Quartz;

//namespace EbSite.Jobs
//{
//    /// <summary>
//    /// 商品solr任务
//    /// </summary>
//    /// <remarks>
//    /// 该Job有两个自定义声明，分明说明如下：
//    /// 1.PersistJobDataAfterExecution:支持多次执行数据持久化到该对象中，每次执行完毕之后，会把数据放入JobDataMap，以便下次使用。
//    /// 2.DisallowConcurrentExecution:不允许并发执行，如果服务开时执行时，上次执行还没有完成，则等待上次完成后，本次执行才开始；
//    /// </remarks>
//    [DisallowConcurrentExecution]
//    public class LuceneIndexUpdate : IJob
//    { 
//        /// <summary>
//        /// 定时更新Lucene索引
//        /// </summary>
//        /// <param name="context">The context.</param>
//        public void Execute(IJobExecutionContext context)
//        {
            

            

//        }


//    }
    


//}