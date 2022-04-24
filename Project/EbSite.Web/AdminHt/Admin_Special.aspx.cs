using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Special : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Special");
        }

            /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
            {
                if (PageType == 0)
                {
                    base.LoadAControl("AddSpecial.ascx");
                }
                else if (PageType == 1)
                {
                    base.LoadAControl("SpecialList.ascx");
                }
                else if (PageType == 2)
                {
                    base.LoadAControl("AddSpecialSel.ascx");
                }
                else
                {
                    base.AddControl();
                }
            }

    
    }
}