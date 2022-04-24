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
using EbSite.Mvc.Token;

namespace EbSite.Mvc.Filters
{

    public class TokenAttribute : AuthorizationFilterAttribute
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

             
            
            var authHeader = actionContext.Request.Headers;

            if (!Equals(authHeader,null))
            {
                if (authHeader.Contains("Token"))
                {
                    var sToken = authHeader.GetValues("Token").FirstOrDefault();
                    TokenInfo tkUser = EbToken.GetTokenModel(sToken);
                    if (!Equals(tkUser, null))
                    {
                        if (!Equals(HttpContext.Current, null))
                        {
                            var currentPrincipal = new EbPrincipal(tkUser);
                            HttpContext.Current.User = currentPrincipal;
                            Thread.CurrentPrincipal = HttpContext.Current.User;
                        }
                        return;
                    }
                }

                //if (authHeader.Contains("BMSessionId"))
                //{

                //var BMSessionId = authHeader.GetValues("BMSessionId").FirstOrDefault();


                //if (authHeader.Contains("Token"))
                //{
                //    var sToken = authHeader.GetValues("Token").FirstOrDefault();
                //    TokenInfo tkUser = EbToken.GetTokenModel(sToken);
                //    if (!Equals(tkUser, null))
                //    {
                //        if (!Equals(HttpContext.Current, null))
                //        {
                //            var currentPrincipal = new EbPrincipal(tkUser);
                //            HttpContext.Current.User = currentPrincipal;
                //            Thread.CurrentPrincipal = HttpContext.Current.User;
                //        }
                //        return;
                //    } 
                //}
                //else
                //{
                //    if (!Equals(HttpContext.Current, null))
                //    {
                //        var currentPrincipal = new EbPrincipal();
                //        HttpContext.Current.User = currentPrincipal;
                //        Thread.CurrentPrincipal = HttpContext.Current.User;
                //    }
                //    return;
                //}

                //}

            }
            HandleUnauthorizedRequest(actionContext);
            
        }

        private bool IsHaveUser(string UserName, string Pass)
        {
            return true;
        }
         

        private void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound);
            actionContext.Response.Content = new StringContent("<b>需要添加Token值才能访问或Token已经过期</b>", Encoding.UTF8, "text/html");

        }
    }
}