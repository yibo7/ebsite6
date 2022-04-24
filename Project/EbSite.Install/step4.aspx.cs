using System;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Core.Strings;
using EbSite.Install;

namespace EbSite.Install
{
    public partial class step4 : SetupBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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

                    txtIISPath.Text = Utils.GetIISPath;
                    txtWebUrl.Text = GetString.GetSite();
                }
                #endregion
              

            }
        }

        protected void bntStarInstall_Click(object sender, EventArgs e)
        {
            //验证密码长度
            if (txtManagerPass.Text.Length < 6)
            {
                Core.Strings.cJavascripts.MessageShowBack("系统管理员密码长度不能少于6位");
                return;
            }


            //写入configs
            //EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.sSiteName = txtWebSiteName.Text.Trim();
            EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName = txtWebUrl.Text.Trim();
            EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.IISPath = txtIISPath.Text.Trim();
            EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath = AppDomain.CurrentDomain.BaseDirectory;
            EbSite.Base.Configs.SysConfigs.ConfigsControl.SaveConfig();

            EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.FounderuID = sponsercheck.Checked ? txtManagerName.Text.Trim() : "";
            EbSite.Base.Configs.BaseCinfigs.ConfigsControl.SaveConfig();

            Entity.Sites md =  EbSite.BLL.Sites.Instance.GetEntity(1);
            md.SiteName = txtWebSiteName.Text.Trim();
            EbSite.BLL.Sites.Instance.Update(md);

            Session["SystemAdminName"] = txtManagerName.Text;
            Session["SystemAdminPws"] = txtManagerPass.Text;
            Session["SystemAdminEmail"] = txtManagerEmail.Text;

               

            Response.Redirect(Utils.HtmlEncode("step5.aspx"),false);
        }
    }
}
