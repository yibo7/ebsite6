using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for username
    /// </summary>
    public class username : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request.Form["reg_username"]))
            {
                string usernamse = context.Request.Form["reg_username"];
                bool isok = BLL.User.MembershipUserEb.Instance.ExistsUserName(usernamse);
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
