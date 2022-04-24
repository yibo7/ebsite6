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
    public partial class PcWebThemes : BasePage
    {

        protected string GetTempListUrl(string themename)
        {
            string tem =  "./Admin_Tem.aspx?t=11&tt=1&theme={0}";

            if (string.IsNullOrEmpty(themename))
            {
                return string.Format(tem, CurrentSite.PageTheme);
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
                return new ThemesPC();
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
                return new Guid("adc98e19-5e69-4f27-bc39-5bfa5f8d969a");
            }
           
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        override protected string MenuName
        {
            get
            {
                return "前台皮肤下载";
            }
           
        }
        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }
    }
}