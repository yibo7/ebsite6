using EbSite.BLL.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for yzm
    /// </summary>
    public class appstart : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Log.Factory.GetInstance().InfoLog("开始在appstart.ashx中InitScheduler");
            QuartzHelper.InitScheduler();
            QuartzHelper.StartScheduler();
            context.Response.Write("重启成功");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
