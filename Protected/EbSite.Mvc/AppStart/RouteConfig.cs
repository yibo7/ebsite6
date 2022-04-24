using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EbSite.Mvc.AppStart
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
          
             
            routes.MapMvcAttributeRoutes();

            //兼容非MVC版之前的一些路径
            routes.Add(new Route("ajaxget/{action}.ashx", new RouteHandler()));
            routes.Add(new Route("{action}.ashx", new RouteHandler()));
              
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}
