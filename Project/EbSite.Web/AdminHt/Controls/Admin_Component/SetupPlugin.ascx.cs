using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Core.FSO;

namespace EbSite.Web.AdminHt.Controls.Admin_Component
{
    public partial class SetupPlugin : Base.ControlPage.UserControlBase
    {
        public override string Permission
        {
            get
            {
                return "143";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //txtMdPath.SaveFolder = "Plugins"; 
        }
        protected void bntSetup_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtMdPath.ValOldName))
            //{
            //    string fTemp = Server.MapPath(txtMdPath.ValSavePath);
            //    string fNew = Server.MapPath(IISPath + "/App_Code/Plugins/" + txtMdPath.ValOldName);
            //    if (!FObject.IsExist(fNew, FsoMethod.File))
            //    {
            //        Core.FSO.FObject.Move(fTemp, fNew, FsoMethod.File);


            //    }
            //    else
            //    {
            //        TipsAlert("已经存在相同名字组件！");
            //    }
            //}
        }
    }
}