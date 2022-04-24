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
    public class web404 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.StatusCode = 404;
            context.Response.End();
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
