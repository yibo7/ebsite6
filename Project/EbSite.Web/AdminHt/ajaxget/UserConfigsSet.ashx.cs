using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Configs.ContentSet;

namespace EbSite.Web.AdminHt.ajaxget
{
    /// <summary>
    /// Summary description for UserConfigsSet
    /// </summary>
    public class UserConfigsSet : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request["t"]))
            {
                //ConfigsControl.Instance.AdminStyle = context.Request["t"];
                //ConfigsControl.SaveConfig();

                //EbSite.Base.Host.Instance.CurrentSite.AdminTheme = context.Request["t"];
                //Base.Host.Instance.CurrentSite.Update();

              Entity.Sites md =   EbSite.Base.Host.Instance.CurrentSite;
              md.AdminTheme = context.Request["t"];
              md.Update();

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