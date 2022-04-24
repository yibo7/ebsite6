using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Payment : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Payment");
        }
        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 1)
            {
                base.LoadAControl("PaymentAdd.ascx");
            }
            else if(PageType==2)
            {
                base.LoadAControl("PaymentTypeAdd.ascx");
            }
            else if (PageType == 54)
            {
                base.LoadAControl("OrderOptionAdd.ascx");
            }
            else if (PageType == 58)
            {
                base.LoadAControl("OptionItemList.ascx");
            }
            else if (PageType == 57)
            {
                base.LoadAControl("Add_Sec.ascx");
            }
            else
            {
                base.AddControl();
            }

        }
    }
}