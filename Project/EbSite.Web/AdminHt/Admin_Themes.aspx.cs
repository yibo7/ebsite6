using System;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Themes : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Themes");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
             if(PageType==0)
             {
                 base.LoadAControl("PcWebThemesAdd.ascx");
             }
             else if(PageType==1)
             {
                 base.LoadAControl("MobileThemesAdd.ascx");
             }
             
            else
            {
                base.AddControl();
            }


        }

    }
}
