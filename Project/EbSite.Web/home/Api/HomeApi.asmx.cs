using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using EbSite.Base;
using EbSite.Base.Json;
using EbSite.Base.Page;

namespace EbSite.Web.home.Api
{
    /// <summary>
    /// Summary description for HomeApi
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class HomeApi : WebServiceBase
    {

        [WebMethod]
        public string SaveTabWidgets(int TabID, string WidgetIDs)
        {

            return "ok";

            //return new JsonResponse() { Message = "ok" };
        }
        [WebMethod]
        public JsonResponse DDDTEXT()
        {
            return new JsonResponse() { Message = "ok" };
        }
    }
}
