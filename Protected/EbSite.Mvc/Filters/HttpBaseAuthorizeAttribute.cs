using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Filters; 

namespace EbSite.Mvc.Filters
{
   
    public class HttpBaseAuthorizeAttribute : AuthorizationFilterAttribute
    {
        //[Inject]
        //public LearningRepository TheRepository { get; set; }
          
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //如果用户使用了forms authentication，就不必在做basic authentication了
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                return;
            }
             
            
            
            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null)
            {

                if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) &&
                    !String.IsNullOrWhiteSpace(authHeader.Parameter))
                {
                    var credArray = GetCredentials(authHeader);
                    var userName = credArray[0];
                    var password = credArray[1];

                    if (IsHaveUser(userName, password))
                    {
                        //var currentPrincipal = new BMPrincipal(userName); 
                         
                        //if (!Equals(HttpContext.Current, null))
                        //{
                        //    HttpContext.Current.User = currentPrincipal;
                        //    Thread.CurrentPrincipal = HttpContext.Current.User;
                        //}
                         
                        return;
                    }
                }
            }

            HandleUnauthorizedRequest(actionContext);
        }

        private bool IsHaveUser(string UserName, string Pass)
        {
            return true;
        }

        private string[] GetCredentials(System.Net.Http.Headers.AuthenticationHeaderValue authHeader)
        {

            //Base 64 encoded string
            var rawCred = authHeader.Parameter;
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var cred = encoding.GetString(Convert.FromBase64String(rawCred));

            var credArray = cred.Split(':');

            return credArray;
        }

        //private bool IsResourceOwner(string userName, System.Web.Http.Controllers.HttpActionContext actionContext)
        //{
        //    var routeData = actionContext.Request.GetRouteData();
        //    var resourceUserName = routeData.Values["userName"] as string;

        //    if (resourceUserName == userName)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        private void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

            actionContext.Response.Headers.Add("WWW-Authenticate",
            "Basic Scheme='eLearning' location='http://localhost:8323/account/login'");

        }
    }
}