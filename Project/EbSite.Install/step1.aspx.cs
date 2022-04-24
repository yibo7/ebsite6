using System;
using System.Text.RegularExpressions;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Install;

namespace EbSite.Install
{
    public partial class step1 : SetupBase
    {
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
                }
                #endregion
            }
        }

    }
}
