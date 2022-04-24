using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for email
    /// </summary>
    public class email : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request.Form["reg_email"]))
            {
                string email = context.Request.Form["reg_email"];
                bool isok = BLL.User.MembershipUserEb.Instance.ExistsEmail(email);

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
