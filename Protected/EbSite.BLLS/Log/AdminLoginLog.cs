using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using EbSite.Entity;
using System.Linq;
namespace EbSite.BLL
{
	/// <summary>
    /// 0.综合日志，1.登录日志,2.静态页面错误生成日志,3.系统异常日志
	/// </summary>
    public class AdminLoginLog 
	{
        private AdminLoginLog()
		{
            
		}
        public static void DeleteAll()
        {
            EbSite.BLL.Logs.Instance.DeleteByType(1);
        }
        public static Entity.Logs SelectLogs(int id)
        {
           return EbSite.BLL.Logs.Instance.GetEntity(id);
        }

        public static void InsertLogs(EbSite.Entity.Logs AppLog)
        {
            AppLog.LogType = 1;
            AppLog.Title = string.Concat(AppLog.Title, " 昵称：",EbSite.Base.AppStartInit.UserNiName);
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
        public static List<Entity.Logs> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return EbSite.BLL.Logs.Instance.GetListPages(PageIndex, PageSize, "LogType=1", "", "id desc", out RecordCount);
        }
		
	}
}

