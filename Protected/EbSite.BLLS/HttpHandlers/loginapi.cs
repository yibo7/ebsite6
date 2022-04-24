using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.Plugin;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for loginapi
    /// </summary>
    public class loginapi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string loginapitype = context.Request["t"];
            if (!string.IsNullOrEmpty(loginapitype))
            {
                //添加后触发的事件
                //LoginApiBackEventArgs Argsed = new LoginApiBackEventArgs(loginapitype);
                //Base.EBSiteEvents.OnLoginApiBacked(HttpContext.Current,Argsed);
                //context.Session["loginapi"] = Guid.NewGuid();
                EbSite.Core.Utils.WriteCookie("loginapi", EbSite.Base.Host.Instance.EncodeByKey(loginapitype));
                IUserLoginApi api = EbSite.Base.Plugin.Factory.GetLoginApi(loginapitype);
                if (!Equals(api, null))
                    api.Login();
                else
                {
                    context.Response.Redirect(EbSite.Base.Host.Instance.GetErrPageRw("8"));
                }

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
