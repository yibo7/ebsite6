using System;
using System.Web.UI;
using EbSite.Base.Page;
using EbSite.Base.Extension.Manager;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Plugins : ManagePage
    {
        protected override MasterType eMasterType
        {
            get
            {
                if (PageType == 1)
                    return MasterType.Mini;
                return MasterType.Custom;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            base.SetContolsPath("Admin_Plugins");

        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 1)  //插件配置
            {
                base.LoadAControl("PluginSetting.ascx");

            }
            else if (PageType == 2)
            {
               // Tips("温馨提示","暂不提供此功能");
                base.LoadAControl("OutPutPlugins.ascx");
            }
            else
            {
                base.AddControl();
            }

        }

    }
}
