using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for mobile
    /// </summary>
    public class mobile : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request.Form["reg_mobile"]))
            {
                string mobile = context.Request.Form["reg_mobile"];
                bool isok = Base.Host.Instance.EBMembershipInstance.ExistMobile(mobile);
                context.Session["MobileValCode"] = null;
                context.Response.Write(isok ? "false" : "true");
            }
            else
            {
                context.Response.Write("false");
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
