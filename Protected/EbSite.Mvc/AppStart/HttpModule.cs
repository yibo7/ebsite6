using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace EbSite.Mvc.AppStart
{
    public class HttpModule : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            
            var action = requestContext.RouteData.Values["action"].ToString().ToLower();

            return null;
        }
    }
}
