using System;
using System.Collections.Generic;

using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Modules
{
    public partial class SetupModelesZip : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bntSetup_Click(object sender, EventArgs e)
        {
            string sSetupPath = Request["s"];
            string sSetupFolder = Request["f"];

            if(!string.IsNullOrEmpty(sSetupPath)&&!string.IsNullOrEmpty(sSetupFolder))
            {
                Guid mid = BLL.ModulesBll.Modules.Instance.SetupModelZip(sSetupPath, sSetupFolder, this.Page,GetSiteID);

                Response.Redirect("Admin_Modules.aspx?t=25&mid=" + mid);
            }

            
            
        }
    }
}