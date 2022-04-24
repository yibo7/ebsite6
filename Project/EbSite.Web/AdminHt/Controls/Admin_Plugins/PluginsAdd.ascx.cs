using System;
using EbSite.Base.Plugin;
using EbSite.Core.FSO;

namespace EbSite.Web.AdminHt.Controls.Admin_Plugins
{
    public partial class PluginsAdd :Base.ControlPage.UserControlBase
    {
        public override string Permission
        {
            get
            {
                return "137";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtMdPath.SaveFolder = "Plugins"; 
        }
        protected void bntSetup_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtMdPath.ValOldName)) 
            {
                string fTemp = Server.MapPath(txtMdPath.ValSavePath);
                string fNew = Server.MapPath(IISPath + "/Plugins/" + txtMdPath.ValOldName);
                if (!FObject.IsExist(fNew, FsoMethod.File))
                {
                    Core.FSO.FObject.Move(fTemp, fNew, FsoMethod.File);
                   EbSite.Base.Host.CacheApp.Clear();// EbSite.Core.CacheManager.RemoveAllCache();
                    //int count = ProviderLoader.LoadFromAuto(txtMdPath.ValOldName);
                }
                else 
                {
                    TipsAlert("已经存在此插件！");
                }
            }
            
           
            
        }
    }
}