using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Quartz : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Quartz");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 0)
           {
               base.LoadAControl("List.ascx");
           }
           else if (PageType == 1)
            {
                base.LoadAControl("Add.ascx");
            }
            else if (PageType == 2)
            {
                base.LoadAControl("ShowTime.ascx");
            }
            else
            {
                 
                base.AddControl();
            }

        }
    }
}