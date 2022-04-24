using System;
using System.Web.UI;
using EbSite.Base.Extension.Manager;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Component : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Component");
        }
        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 1)
            {
                string xName = Request.QueryString["ext"].ToString();
                UserControl uc = null;
                foreach (ManagedExtension x in ExtensionManager.Instance.Extensions)
                {
                    if (x.Name == xName)
                    {
                        foreach (ExtensionSettings setting in x.Settings)
                        {
                            if (!string.IsNullOrEmpty(setting.Name) && !setting.Hidden)
                            {
                                uc = (UserControl)Page.LoadControl(GetControlsPath + "/Settings.ascx");
                                uc.ID = setting.Name;
                                //phBody.Controls.Add(uc);
                                this.phBodyControls.Controls.Add(uc);
                            }
                        }
                    }
                }
            }
            else if (PageType == 2)
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/Coder.ascx"));
                base.LoadAControl("Coder.ascx");
            }
            else if (PageType == 4) //插件的安装或删除
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/SetupPlugin.ascx"));
                base.LoadAControl("SetupPlugin.ascx");
            }
            else if (PageType == 0) //插件的安装或删除
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/SetupPlugin.ascx"));
                base.LoadAControl("PluginList.ascx");
            }
            else
            {
                base.AddControl();
            }

        }

    }
}
