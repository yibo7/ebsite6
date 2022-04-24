using System;

using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Index : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //sContolsPath = "Admin_Index";
            //base.phBody = phBodyControls;
            //AddControl();
            //if (!IsPostBack)
            //{

            //    BindTopTags();

            //}
            base.SetContolsPath("Admin_Index");
        }

        ///// <summary>
        ///// 添加控件
        ///// </summary>
        //protected void AddControl()
        //{
        //    if (phBody == null) return;
        //    switch (GetMat)
        //    {
        //        case 0:
        //            phBody.Controls.Add(LoadControl(GetControlsPath + "/MakeIndex.ascx"));
        //            break;
        //        case 1:
        //            phBody.Controls.Add(LoadControl(GetControlsPath + "/TimerSet.ascx"));
        //            break;
        //    }

        //}

        //protected override void BindTopTags()
        //{
        //    ucTopTags.Index = (int)CurrentAdtion;
        //    ucTopTags.Title = "首页生成管理";
        //    ucTopTags.Items = "生成首页,?mat=0|定时管理,?mat=1";
        //}
    }
}
