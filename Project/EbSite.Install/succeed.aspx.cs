using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Core.FSO;
using EbSite.Install;

namespace EbSite.Install
{
    public partial class succeed : SetupBase
    {
       // protected CheckBoxList cblModules;
        protected global::System.Web.UI.WebControls.Panel PanelErr;

        protected global::System.Web.UI.WebControls.Panel PanelOK;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region  安装前验证，是否存在ebsite.lock文件，如果存在提示用户，系统已经安装，如果想重新安装系统请删除install目录下的ebsite.lock文件

               
                if (Core.FSO.FObject.IsExist(Server.MapPath(lockfile), FsoMethod.File))
                {
                    this.PanelErr.Visible = true;
                    this.PanelOK.Visible = false;
                }
                else
                {
                    this.PanelErr.Visible = false;
                    this.PanelOK.Visible = true;
                   
                    EbSite.Core.FSO.FObject.Create(Server.MapPath(lockfile), FsoMethod.File); 
                }
                #endregion
               
            }
        }
    }
}
