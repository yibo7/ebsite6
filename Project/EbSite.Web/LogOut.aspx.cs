using System;
using System.Web.UI;

namespace EbSite.Web
{
    public partial class LogOut : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //FormsAuthentication.SignOut();
            EbSite.BLL.User.UserIdentity.SignOutUser();

            Base.AppStartInit.RedirectToIndex();
        }
    }
}
