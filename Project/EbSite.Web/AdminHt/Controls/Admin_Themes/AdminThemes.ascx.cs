using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;

namespace EbSite.Web.AdminHt.Controls.Admin_Themes
{
    public partial class AdminThemes : BasePage
    {
        override public ThemesBase ThemeBll
        {
            get
            {
                return new ThemesAdmin();
            }
        }
        protected override void BindToolBar()
        {
            base.BindToolBar(true, true, true, true, false);
            //ucToolBar.AddBnt("保存设置", IISPath + "images/menus/Save.gif", "save", "如果您好更改了是否启用选择，需要点这里进行保存才算真正启用!");

            ucToolBar.AddBnt("刷新皮肤数据", IISPath + "images/menus/Doc-Next.gif", "refesh", "如果上传了新皮肤，那么要点这里刷新皮肤数据才会加载到这里来!");

        }
       
    }
}