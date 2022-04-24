using System;
using System.Collections.Generic; 
using System.Web.Mvc;
using System.Web.Routing; 
using EbSite.Mvc.Filters;
namespace EbSite.Mvc.Controllers
{
    /*
    编写api要注意：就算方法名一名，但参数变量的命名也不能一样，否则出错
    如ebtest(string msg)与tokentest(string msg),msg都一样，会出错，可能是mvc的bug
        */
    //[RoutePrefix("content")]
    public class siteqController : ApiBaseController
    {

        [Token]
        public Dictionary<int, string> getsites()
        {

            Dictionary<int,string> sites = new Dictionary<int, string>();

            List<EbSite.Entity.Sites> sList = EbSite.BLL.Sites.Instance.GetSitesTree(0);
            foreach (var s in sList)
            {
                sites.Add(s.id,s.SiteName);
            }
            return sites;

        }

        

    }  
}
