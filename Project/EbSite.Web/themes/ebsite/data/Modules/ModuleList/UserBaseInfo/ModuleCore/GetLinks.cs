using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.UserBaseInfo.ModuleCore
{
    public class GetLinks
    {
        public static string PayUrl(int siteid )
        {
            return string.Format("{0}pay-online-{1}.ashx", EbSite.Base.Host.Instance.IISPath, siteid);
        }
    }
}