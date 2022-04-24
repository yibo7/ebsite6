using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    /// <summary>
    /// 一些调用调用OpenIframe的模式弹出窗
    /// </summary>
    public partial class Admin_ModalDlg : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            base.SetContolsPath("Admin_ModalDlg");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
             if (PageType == 0)  
            {
                base.LoadAControl("OrderFastMenus.ascx");
            }
            else
            {
                base.AddControl();
            }

        }
        override protected void LoadMaster()
        {
            MasterPageFile = string.Concat(AdminPath, "PagesCustomMini.Master");
           
        }

    }
}