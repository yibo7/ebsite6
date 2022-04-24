using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace EbSite.Mvc.Filters
{

    /// <summary>
    /// 这是强制使用https来请求我们的资源，可以在路由里设置整合请求，也可以在控制器或Action里注入 [ForceHttps()]
    /// </summary>
  public class ForceHttpsAttribute : AuthorizationFilterAttribute
{
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var request = actionContext.Request;

            if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                var html = "<p>这是一个Https请求，请使用Https来请求此资源</p>";
 
                    if (request.Method.Method == "GET")
                    {
                        actionContext.Response = request.CreateResponse(HttpStatusCode.Found);
                        actionContext.Response.Content = new StringContent(html, Encoding.UTF8, "text/html");
 
                        UriBuilder httpsNewUri = new UriBuilder(request.RequestUri);
                        httpsNewUri.Scheme = Uri.UriSchemeHttps;
                        httpsNewUri.Port = 443;
 
                        actionContext.Response.Headers.Location = httpsNewUri.Uri;
                    }
                    else
                    {
                        actionContext.Response = request.CreateResponse(HttpStatusCode.NotFound);
                        actionContext.Response.Content = new StringContent(html, Encoding.UTF8, "text/html");
                    }
 
             }
         }


    }
}