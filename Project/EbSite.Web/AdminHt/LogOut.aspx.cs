using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.BLL.User;

namespace EbSite.Web.AdminHt
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.User.UserIdentity.SignOutAdmin();
            Base.AppStartInit.RedirectToIndex();

        }
         
    }
}