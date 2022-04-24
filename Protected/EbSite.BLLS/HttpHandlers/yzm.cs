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
    public class yzm : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string t = context.Request["t"];
            if (!string.IsNullOrEmpty(t))
            {
                if (t.Equals("0"))
                {
                    if (!string.IsNullOrEmpty(context.Request.Form["reg_yzm"]))
                    {
                        string yzm = context.Request.Form["reg_yzm"];
                        bool isok = BLL.User.UserIdentity.ValidateSafeCode(yzm, false);
                        context.Response.Write(isok ? "true" : "false");
                    }
                    else
                    {
                        context.Response.Write("false");
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(context.Request.Form["reg_yzmmobile"]))
                    {
                        string yzm = context.Request.Form["reg_yzmmobile"];
                        bool isok = BLL.User.UserIdentity.ValidateSafeCodeMobile(yzm, false);
                        context.Response.Write(isok ? "true" : "false");
                    }
                    else
                    {
                        context.Response.Write("false");
                    }
                }
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
