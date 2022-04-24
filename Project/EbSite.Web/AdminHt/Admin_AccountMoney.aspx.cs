using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_AccountMoney : EbSite.Base.Page.ManagePage
    {
        protected override MasterType eMasterType
        {
            get
            {
                if (PageType == 2 || PageType == 1)
                    return MasterType.Mini;
                return MasterType.Custom;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_AccountMoney");
        }
        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 1)
            {
                base.LoadAControl("UserAccountAdd.ascx");
            }
            else if (PageType == 2)
            {
                base.LoadAControl("UpdatePass.ascx");
            }
            else if (PageType == 4)
            {
                base.LoadAControl("RequestedLog.ascx");
            }
            else
            {
                base.AddControl();
            }

        }
    }
}