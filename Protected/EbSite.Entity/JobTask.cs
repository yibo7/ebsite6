using System;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
 //   /// <summary>
 ///// 任务状态枚举
 ///// </summary>
 //   public enum TaskStatus
 //   {
 //       /// <summary>
 //       /// 运行状态
 //       /// </summary>
 //       RUN = 1,

 //       /// <summary>
 //       /// 停止状态
 //       /// </summary>
 //       STOP = 0
 //   }
    public class JobTask : XmlEntityBase<Guid>
    {
        ///// <summary>
        ///// 任务ID
        ///// </summary>
        //public Guid TaskID { get; set; }
        public bool IsNoSys { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 任务执行参数
        /// </summary>
        public string TaskParam { get; set; }

        /// <summary>
        /// 运行频率设置
        /// </summary>
        public string CronExpressionString { get; set; }

        /// <summary>
        /// 任务运频率中文说明
        /// </summary>
        public string CronRemark { get; set; }

        /// <summary>
        /// 任务所在DLL对应的程序集名称
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// 任务所在类
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 执行类型，0为url,1为程序集
        /// </summary>
        /// <value>The type of the run.</value>
        public int RunType { get; set; }
        /// <summary>
        /// 1为运行状态，0为停止状态
        /// </summary>
        /// <value>The status.</value>
        public int Status { get; set; }

        /// <summary>
        /// 任务创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 任务修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 任务最近运行时间
        /// </summary>
        public DateTime RecentRunTime { get; set; }

        /// <summary>
        /// 任务下次运行时间
        /// </summary>
        public DateTime NextFireTime { get; set; }

        /// <summary>
        /// 任务备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDelete { get; set; }
        /// <summary>
        /// 给线程池辅助用，不用理会
        /// </summary>
        /// <value>The run URL.</value>
        public string RunUrl { get; set; }
        /// <summary>
        /// 最后执行结果
        /// </summary>
        /// <value>The last rezult.</value>
        public string LastRezult { get; set; }
    }
}
