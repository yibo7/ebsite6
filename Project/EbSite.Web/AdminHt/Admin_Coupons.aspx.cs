using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Coupons : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Coupons");
        }
        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 1)
            {
                base.LoadAControl("CouponsAdd.ascx");
            }
            else if(PageType==2)
            {
                base.LoadAControl("CouponsShow.ascx");
            }
            else if(PageType==3)
            {
                base.LoadAControl("SendMember.ascx");
            }
            else
            {
                base.AddControl();
            }

        }
    }
    
}