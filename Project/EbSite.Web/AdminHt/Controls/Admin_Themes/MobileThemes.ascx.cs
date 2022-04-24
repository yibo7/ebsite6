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
    public partial class MobileThemes : BasePage
    {
        protected string GetTempListUrl(string themename)
        {
            string tem = "./Admin_Tem.aspx?t=11&tt=2&theme={0}";

            if (string.IsNullOrEmpty(themename))
            {
                return string.Format(tem, CurrentSite.MobileTheme);
            }
            else
            {
                return string.Format(tem, themename);
            }
        }
        override public ThemesBase ThemeBll
        {
            get
            {
                return new ThemesMobile();
            }
        }
        override protected Guid ModuleID
        {
            get
            {
                return new Guid("03fc411f-eed0-4afe-a5c2-b5c80d196b70");
            }

        }
        /// <summary>
        /// 菜单 ID
        /// </summary>
        override protected Guid MenuID
        {
            get
            {
                return new Guid("f29978f7-10fd-4493-8bc2-d84453ac0f98");
            }

        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        override protected string MenuName
        {
            get
            {
                return "手机皮肤下载";
            }

        }
        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
    }
}