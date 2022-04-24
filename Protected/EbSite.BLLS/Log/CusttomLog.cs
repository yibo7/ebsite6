using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using EbSite.Entity;
namespace EbSite.BLL
{
	/// <summary>
    /// 0.综合日志，1.登录日志,2.静态页面错误生成日志,3.系统异常日志
	/// </summary>
    public class CusttomLog 
	{
        public CusttomLog()
		{
            
		}
        public static void DeleteAll()
        {
            EbSite.BLL.Logs.Instance.DeleteByType(0);
        }
        public static Entity.Logs SelectLogs(int id)
        {
            return EbSite.BLL.Logs.Instance.GetEntity(id);
        }
        /// <summary>
        /// 适合在线程池中调用，因为在线程中直接调用数据会有异常
        /// </summary>
        /// <param name="log">日志,要在外面用 HttpContext.Server.UrlEncode编码，否则会乱乱</param>
        /// <param name="httpContext">由HttpContext.Request.Url.Authority获取的当前网站域名，如www.ebsite.net:8088</param>
       /// <param name="Key">网站的密钥,防止在面访问这个地址写入</param>
        public static void InsertLogs(string title,string log, HttpContext httpContext, string Key)
        {
            if (!Equals(httpContext,null))
            {
                string userkey = EbSite.Base.Host.Instance.EncodeByMD5(Base.Host.Instance.EncodeByKey(string.Concat(title, log)));

                Core.WebUtility.LoadPageContent(string.Concat("http://", httpContext.Request.Url.Authority, "/ajaxget/log.ashx"), string.Format("l={0}&t={1}&key={2}", httpContext.Server.UrlEncode(log), httpContext.Server.UrlEncode(title), userkey));
                
            }
            
        }

	    public static void InsertLogs(EbSite.Entity.Logs AppLog)
        {
            AppLog.LogType = 0;
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
            return EbSite.BLL.Logs.Instance.GetListPages(PageIndex, PageSize, "LogType=0", "", "-id", out RecordCount);
        }

        //public static EbSite.Entity.Logs SelectLogs(Guid id)
        //{
        //    return Log.Provider.Factory.CusttomLog().SelectLogs(id);
        //}

        //public static void InsertLogs(EbSite.Entity.Logs AppLog)
        //{
        //    Log.Provider.Factory.CusttomLog().InsertLogs(AppLog);
        //}

        //public static void UpdateLogs(Logs AppLog)
        //{
        //    Log.Provider.Factory.CusttomLog().UpdateLogs(AppLog);
        //}
        //public static void DeleteLogs(Logs AppLog)
        //{
        //    Log.Provider.Factory.CusttomLog().DeleteLogs(AppLog);
        //}

        //public static List<Logs> FillLogs()
        //{
        //    //return Log.Provider.Factory.CusttomLog().FillLogs();
        //    List<Logs> lst = Log.Provider.Factory.CusttomLog().FillLogs();

        //    return lst.OrderByDescending(d => d.AddDate).ToList();
        //}
		
	}
}

