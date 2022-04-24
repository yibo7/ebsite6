using System;
using System.Collections.Generic;
using System.Web;

namespace EbSite.Modules.UserBaseInfo.Ajaxget
{
    /// <summary>
    /// Summary description for GetUserInfo
    /// </summary>
    public class GetUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("测试9999");
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