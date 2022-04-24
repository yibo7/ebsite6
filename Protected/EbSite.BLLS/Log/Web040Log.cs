using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EbSite.Entity;
namespace EbSite.BLL
{
	/// <summary>
    /// 0.综合日志，1.登录日志,2.静态页面错误生成日志,3.系统异常日志,4.404页面访问日志
	/// </summary>
    public class Web040Log 
	{
        public Web040Log()
		{
            
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
            AppLog.LogType = 4;
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
        public static void DeleteAll()
        {
            EbSite.BLL.Logs.Instance.DeleteByType(4);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<Entity.Logs> GetListPages(int PageIndex, int PageSize,  out int RecordCount)
        {
            return EbSite.BLL.Logs.Instance.GetListPages(PageIndex, PageSize, "LogType=4", "", "-id", out RecordCount);
        }

		
	}
}

