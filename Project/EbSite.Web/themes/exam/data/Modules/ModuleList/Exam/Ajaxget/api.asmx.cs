using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.EntityAPI;
using EbSite.Base.EntityCustom;
using EbSite.Base.Json;
using EbSite.BLL;
using EbSite.Modules.Exam.ModuleCore;
using EbSite.Modules.Exam.ModuleCore.BLL;
using System.Text.RegularExpressions;
using System.IO;

namespace EbSite.Modules.Exam.Ajaxget
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class api : WebServiceBase
    {

        [WebMethod]
        public string HelloString(string username)
        {
            return "调用了HelloString这是传来参数值" + username;
        }
        [WebMethod]
        public string cha( string Exshitiname, string da) {
            List<EbSite.Entity.exam_questions> ls = EbSite.BLL.exam_questions.Instance.GetListArray(" Questions=" + Exshitiname + "and" + "RightABC");
            
            return "222";
        }
        
    }
}
