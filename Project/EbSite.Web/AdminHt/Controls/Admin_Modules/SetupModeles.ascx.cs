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
    public partial class SetupModeles : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSetupPath.Text = EbSite.Base.Host.Instance.CurrentSite.GetPathModulesModuleList(0);
        }

        protected void bntSetup_Click(object sender, EventArgs e)
        {

           // Guid mid = BLL.ModulesBll.Modules.Instance.SetupModel("\\EbSite.Modules.Auto.dll", txtSetupPath.Text, txtFolder.Text, cbRand.Checked, "\\EbSite.Modules.Auto.dll", this.Page, GetSiteID);

         Guid mid =   BLL.ModulesBll.Modules.Instance.SetupModel(txtMdPath.ValSavePath, txtSetupPath.Text, txtFolder.Text, cbRand.Checked, txtMdPath.ValOldName,this.Page,GetSiteID);

         // Response.Redirect("Admin_Modules.aspx?t=25&mid=" + mid);
            
        }
    }
}