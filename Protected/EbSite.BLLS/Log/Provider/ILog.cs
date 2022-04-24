using System;
using System.Collections.Generic;
using System.Data;
namespace EbSite.BLL.Log.Provider
{
	/// <summary>
	/// 业务逻辑类CountData 的摘要说明。
	/// </summary>
    public abstract class ILog
	{
	    protected string LogsFolder
	    {
	        get
	        {
                string p = "logs";
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, p);
	        }
	    }
        /// <summary>
        ///查询一个日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract EbSite.Entity.Logs SelectLogs(Guid id);
        /// <summary>
        /// 写入一个日志
        /// </summary>
        /// <param name="Logs"></param>
        public abstract void InsertLogs(EbSite.Entity.Logs Logs);
        /// <summary>
        /// 更新一个日志
        /// </summary>
        /// <param name="Logs"></param>
        public abstract void UpdateLogs(EbSite.Entity.Logs Logs);
        /// <summary>
        /// 删除一个日志
        /// </summary>
        /// <param name="Logs"></param>
        public abstract void DeleteLogs(EbSite.Entity.Logs Logs);
        /// <summary>
        /// 获取日志列表
        /// </summary>
        /// <returns></returns>
        public abstract List<Entity.Logs> FillLogs();
		
	}
}

