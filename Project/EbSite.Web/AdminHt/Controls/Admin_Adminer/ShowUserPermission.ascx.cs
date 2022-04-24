using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.ControlPage;
using EbSite.BLL;

namespace EbSite.Web.AdminHt.Controls.Admin_Adminer
{
    public partial class ShowUserPermission : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AdminUser currentUser;
                int userid = int.Parse(Request["id"]);
                currentUser = new AdminUser(userid);
                lbUser.Text = currentUser.UserName;
                AdminPrincipal user = new AdminPrincipal(userid);
                
                BindRoles(user);
            }
        }
        private void BindRoles(AdminPrincipal user)
        {
            if (user.Permissions.Count > 0)
            {
                RoleList.Visible = true;
                ArrayList Permissions = user.Permissions;
               
                for (int i = 0; i < Permissions.Count; i++)
                {
                    RoleList.Text += "<br><br>" + (i + 1) + "." + Permissions[i];
                }
                
            }
        }
    }
}