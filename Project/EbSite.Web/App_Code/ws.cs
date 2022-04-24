using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web;
using System.Web.Services.Protocols;
using EbSite.Base;
using EbSite.Base.EntityCustom;
using EbSite.Base.Json;
using EbSite.BLL.ModulesBll;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.EntityAPI;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Core.Strings;
using RemarkSublist = EbSite.Entity.RemarkSublist;

namespace App_Code
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Script.Services;
    using System.Web.Services;
    /// <summary>
    /// The comments.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class ws : EbSite.Base.MainWebServiceBase
    {
        /*您可以在这里扩展您的web服务*/

        [WebMethod] 
        public JsonResponse HelloString(string msg)
        {
            return new JsonResponse() { Data = "您请求了HelloString:" + msg, Message ="请求成功" , Success = true };
        }
         
        
    }
}
