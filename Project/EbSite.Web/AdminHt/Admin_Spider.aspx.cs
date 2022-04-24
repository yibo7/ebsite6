using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Spider : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            base.SetContolsPath("Admin_Spider");

        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 1)  //插件配置
            {
                base.LoadAControl("SpiderAdd.ascx");

            }
            //else if (PageType == 2)
            //{
            //    // Tips("温馨提示","暂不提供此功能");
            //    base.LoadAControl("SpiderAdd.ascx");
            //}
            else
            {
                base.AddControl();
            }

        }
    }
}