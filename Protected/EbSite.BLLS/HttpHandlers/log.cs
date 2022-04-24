using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for log
    /// </summary>
    public class log : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request.Form["l"]))
            {
                string log = context.Request.Form["l"];
                string title = context.Request.Form["t"];
                string key = context.Request.Form["key"];
                string pkey = EbSite.Base.Host.Instance.EncodeByMD5(Base.Host.Instance.EncodeByKey(string.Concat(title, log)));
                if (key.Equals(pkey))
                    EbSite.BLL.HTMLLog.InsertLogs(string.IsNullOrEmpty(title) ? "title为null的日志" : title, log);
            }
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
