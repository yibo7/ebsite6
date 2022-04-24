using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages
{
    public partial class Vote : MPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

          //  base.SetContolsPath("Vote");

        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 1)  //添加用户
            {
                base.LoadAControl("VoteManage_add.ascx");

            }
            else if (PageType == 2) //部门添加
            {
                base.LoadAControl("VoteManage_XZGL.ascx");
            }
            else if (PageType == 3) //添加-修改角色
            {
                base.LoadAControl("VoteManage_XZGL_add.ascx");
            }
            else if (PageType == 4) //添加-修改角色
            {
                base.LoadAControl("VoteManage_XZGL_show.ascx");
            }
            else if (PageType == 5) //添加-修改角色
            {
                base.LoadAControl("Vote_CJTP.ascx");
            }
            else
            {
                base.AddControl();
            }

        }

    }
}