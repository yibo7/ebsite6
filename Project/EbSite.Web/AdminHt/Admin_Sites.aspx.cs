using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Sites : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Sites");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 0)
           {
               base.LoadAControl("SiteList.ascx");
           }
           else if (PageType == 1)
            {
                base.LoadAControl("SiteAdd.ascx");
            }
            else
            {
                base.AddControl();
            }

        }
    }
}