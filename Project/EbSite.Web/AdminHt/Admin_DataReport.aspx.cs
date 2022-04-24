using System;

using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_DataReport : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_DataReport");
        }

        ///// <summary>
        ///// 添加控件
        ///// </summary>
        //protected override void AddControl()
        //{
        //    if(PageType==1)
        //    {

        //        base.LoadAControl("TemMethodAdd.ascx");
        //    }
        //    else if(PageType==2)
        //    {

        //        base.LoadAControl("HtmlErrLog.ascx");
        //    }
        //    else
        //    {
        //        base.AddControl();
        //    }


        //}

    }
}
