using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EbSite.Entity;
namespace EbSite.BLL
{
	/// <summary>
    /// 0.综合日志，1.登录日志,2.静态页面错误生成日志,3.系统异常日志
	/// </summary>
    public class HTMLLog 
	{
        public HTMLLog()
		{
            
		}
        public static void DeleteAll()
        {
            EbSite.BLL.Logs.Instance.DeleteByType(2);
        }
        public static Entity.Logs SelectLogs(int id)
        {
            return EbSite.BLL.Logs.Instance.GetEntity(id);
        }
        public static void InsertLogs(string Title,string Info)
        {
            EbSite.Entity.Logs AppLog = new Entity.Logs();
            AppLog.Title = Title;
            AppLog.Description = Info;
            AppLog.AddDate = DateTime.Now;
            InsertLogs(AppLog);
        }
        public static void InsertLogs(EbSite.Entity.Logs AppLog)
        {
            AppLog.LogType = 2;
            EbSite.BLL.Logs.Instance.Add(AppLog);
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
        public static List<Entity.Logs> GetListPages(int PageIndex, int PageSize,  out int RecordCount)
        {
            return EbSite.BLL.Logs.Instance.GetListPages(PageIndex, PageSize, "LogType=2", "", "-id", out RecordCount);
        }

        //public static EbSite.Entity.Logs SelectLogs(Guid id)
        //{
        //    return Log.Provider.Factory.HTMLLog().SelectLogs(id);
        //}

        //public static void InsertLogs(EbSite.Entity.Logs AppLog)
        //{
        //    Log.Provider.Factory.HTMLLog().InsertLogs(AppLog);
        //}

        //public static void UpdateLogs(Logs AppLog)
        //{
        //    Log.Provider.Factory.HTMLLog().UpdateLogs(AppLog);
        //}
        //public static void DeleteLogs(Logs AppLog)
        //{
        //    Log.Provider.Factory.HTMLLog().DeleteLogs(AppLog);
        //}

        //public static List<Logs> FillLogs()
        //{

        //    List<Logs> lst = Log.Provider.Factory.HTMLLog().FillLogs();

        //    return lst.OrderByDescending(d => d.AddDate).ToList();
        //}
		
	}
}

