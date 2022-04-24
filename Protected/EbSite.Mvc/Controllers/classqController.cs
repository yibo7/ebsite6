using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using EbSite.ApiEntity;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Entity;
using EbSite.Mvc.Filters;
namespace EbSite.Mvc.Controllers
{
    /*
    编写api要注意：就算方法名一名，但参数变量的命名也不能一样，否则出错
    如ebtest(string msg)与tokentest(string msg),msg都一样，会出错，可能是mvc的bug
        */
    //[RoutePrefix("content")]
    public class classqController : ApiBaseController
    {
       
        [Token]
        public Dictionary<int, string> gettree(int site)
        {
             
            Dictionary<int,string> lst = new Dictionary<int, string>();

            List<EbSite.Entity.NewsClass> sList = EbSite.BLL.NewsClass.GetContentClassesTree(5000, site);
            foreach (var s in sList)
            {
                lst.Add(s.ID,s.ClassName);
            }
            return lst;

        }
        [Token]
        public Dictionary<int, string> getsublist(int site,int pid)
        {

            Dictionary<int, string> lst = new Dictionary<int, string>();

            List<EbSite.Entity.NewsClass> sList = EbSite.BLL.NewsClass.GetSubClass(pid,0, site);
            foreach (var s in sList)
            {
                lst.Add(s.ID, s.ClassName);
            }
            return lst;

        }




    }
}
