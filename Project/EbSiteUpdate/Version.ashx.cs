using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using EbSite.Core.FSO;

namespace EbSiteUpdate
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Version : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if(!string.IsNullOrEmpty(context.Request.Form["ip"])&&!string.IsNullOrEmpty(context.Request.Form["dm"]))
            {
                string sPath = context.Server.MapPath("sites.txt");
                string sInfo = string.Format("IP:{0};域名:{1}", context.Request["ip"], context.Request["dm"]);
                FObject.WriteFile(sPath, sInfo, true);
                string sPathVersion = context.Server.MapPath("Version.txt");
                string sVersion = FObject.ReadFile(sPathVersion);
                context.Response.Write(sVersion);
            }
            else
            {
                context.Response.Write("1.0.0");
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
