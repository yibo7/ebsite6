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
    public class specialController : ApiBaseController
    {

        [Token]
        public Dictionary<int, string> Get(int site)
        {
             
            Dictionary<int,string> lst = new Dictionary<int, string>();

            List<EbSite.Entity.SpecialClass> sList = EbSite.BLL.SpecialClass.GetListArr(site);
            foreach (var s in sList)
            {
                lst.Add(s.id,s.SpecialName);
            }
            return lst;

        }
        


    }
}
