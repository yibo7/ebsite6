using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Page;
using EbSite.Control;

namespace EbSite.Web.Pages
{
    public partial class UserPagesTem : MasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                       
                BindMenus();

                
            }
        }
        private void BindMenus()
        {
            if (!Equals(rpMenus, null))
            {
                rpMenus.DataSource = BLL.MenusForUser.Instance.GetMenusByParentID(Guid.Empty, ThemeType.PC);
                rpMenus.DataBind();
            }
            
        }
    }
}