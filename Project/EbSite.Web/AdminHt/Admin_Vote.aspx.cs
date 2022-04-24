using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Vote : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            base.SetContolsPath("Admin_Vote");

        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 1)  //插件配置
            {
                base.LoadAControl("VoteAdd.ascx");

            }
            else if (PageType == 2)
            {
                base.LoadAControl("ItemShow.ascx");
            }
            else if (PageType == 3)
            {
                base.LoadAControl("ItemAdd.ascx");
            }
            else
            {
                base.AddControl();
            }

        }
    }
}