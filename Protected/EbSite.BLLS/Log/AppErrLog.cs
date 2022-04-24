using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Amib.Threading;
using EbSite.Base;
using EbSite.Entity;
namespace EbSite.BLL
{
	/// <summary>
    /// 0.综合日志，1.登录日志,2.静态页面错误生成日志,3.系统异常日志
	/// </summary>
    public class AppErrLog 
	{
        public AppErrLog()
		{
            
		}
        public static void DeleteAll()
        {
            EbSite.BLL.Logs.Instance.DeleteByType(3);
        }
        public static Entity.Logs SelectLogs(int id)
        {
            return EbSite.BLL.Logs.Instance.GetEntity(id);
        }

        public static void InsertLogs(EbSite.Entity.Logs AppLog)
        {
            AppLog.LogType = 3;
            IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(WriteLog), AppLog);
           
        }

        static private object WriteLog(object obj)
        {
            EbSite.Entity.Logs md = obj as EbSite.Entity.Logs;
            EbSite.BLL.Logs.Instance.Add(md);
            return 1;
        }

        public static void UpdateLogs(EbSite.Entity.Logs AppLog)
        {
            EbSite.BLL.Logs.Instance.Update(AppLog);
        }
        public static void DeleteLogs(int id)
        {
            EbSite.BLL.Logs.Instance.Delete(id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<Entity.Logs> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return EbSite.BLL.Logs.Instance.GetListPages(PageIndex, PageSize, "LogType=3", "", "-id", out RecordCount);
        }
        //public static EbSite.Entity.Logs SelectLogs(Guid id)
        //{
        //    return Log.Provider.Factory.AppErrLog().SelectLogs(id);
        //}

        //public static void InsertLogs(EbSite.Entity.Logs AppLog)
        //{
        //    Log.Provider.Factory.AppErrLog().InsertLogs(AppLog);
        //}

        //public static void UpdateLogs(Logs AppLog)
        //{
        //    Log.Provider.Factory.AppErrLog().UpdateLogs(AppLog);
        //}
        //public static void DeleteLogs(Logs AppLog)
        //{
        //    Log.Provider.Factory.AppErrLog().DeleteLogs(AppLog);
        //}

        //public static List<Logs> FillLogs()
        //{
        //    //return Log.Provider.Factory.AppErrLog().FillLogs();
        //    List<Logs> lst = Log.Provider.Factory.AppErrLog().FillLogs();

        //    return lst.OrderByDescending(d => d.AddDate).ToList();
        //}
		
	}
}

