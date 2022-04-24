using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for uploadcheck
    /// </summary>
    public class uploadcheck : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (EbSite.Base.Host.Instance.UserID > 0)
            {
                bool IsUpload = EbSite.Base.Host.Instance.IsAllowUpload(EbSite.Base.Host.Instance.UserLevel.ToString());
                if (IsUpload)
                {
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write("0");
                }
            }
            else
            {
                context.Response.Write("0");
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
