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
using EbSite.Base.Json;

namespace EbSite.Modules.UserBaseInfo.Ajaxget
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class api : WebServiceBase
    {
        [WebMethod]
        public string DeleteAddress(int id)
        {
            if (IsAllow(true))
            {
                EbSite.BLL.Address.Instance.Delete(id);
                return "1";
            }
            else
            {
                return base.NoAllowTips;
            }
           
        }
    }
}
