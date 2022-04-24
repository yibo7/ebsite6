using System;
using System.Collections.Generic;
using EbSite.Base.EntityAPI;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Configs : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            base.SetContolsPath("Admin_Configs");

            
        }
        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 2)
            {

                base.LoadAControl("DataReport.ascx");
            }

            else if (PageType == 3)
            {
                base.LoadAControl("ServerInfo.ascx");
            }
            else if (PageType == 4)
            {
                base.LoadAControl("ServerPlugin.ascx");
            }
            else if (PageType == 5)
            {
                base.LoadAControl("cnzz.ascx");
            }
            else
            {
                base.AddControl();
            }

        }
        
    }
}
