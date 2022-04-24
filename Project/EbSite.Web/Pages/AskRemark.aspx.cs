using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.BLL.User;
using EbSite.Core;
using EbSite.Core.Strings;

namespace EbSite.Web.Pages
{
    public partial class AskRemark : Remark
    {

        protected string GetRepStr(object rep)
        {
            if (Equals(rep, string.Empty))
            {
                return "等待回答...";
            }
            else
            {
                return string.Concat("答：", rep);
            }
        }

         
    }

}