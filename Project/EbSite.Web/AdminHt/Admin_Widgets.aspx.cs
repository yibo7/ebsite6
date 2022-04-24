using System;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Widgets : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //sContolsPath = "Admin_Widget";
            //base.phBody = phBodyControls;
            //AddControl();
            //if (!IsPostBack)
            //{

            //    BindTopTags();

            //}
            base.SetContolsPath("Admin_Widget");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 1)
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/AddWidget.ascx"));
                base.LoadAControl("AddWidget.ascx");
            }
            else if (PageType == 2)
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/AddWidget.ascx"));
                base.LoadAControl("AddWidget.ascx");
            }
            else if (PageType == 3)
            {
                 //phBody.Controls.Add(LoadControl(GetControlsPath + "/EditWidgetsTem.ascx"));
                base.LoadAControl("EditWidgetsTem.ascx");
            }
            //else if (PageType == 4)
            //{
            //    //phBody.Controls.Add(LoadControl(GetControlsPath + "/Preview.ascx"));
            //    base.LoadAControl("Preview.ascx");
            //}
            else if (PageType == 5)
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/ClassAdd.ascx"));
                base.LoadAControl("ClassAdd.ascx");
            }
            else
            {
                base.AddControl(); 
            }

            //if (phBody == null) return;
            //switch (GetMat)
            //{
            //    case 0:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/WidgetsTemList.ascx"));
            //        break;
            //    case 1:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/WidgetsList.ascx"));
            //        break;
            //    case 2:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AddWidget.ascx"));
            //        break;
            //    case 3:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/EditWidgetsTem.ascx"));
            //        break;
            //    case 4:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/Preview.ascx"));
            //        break;


            //}

        }

        //protected override void BindTopTags()
        //{
        //    ucTopTags.Index = (int)CurrentAdtion;
        //    ucTopTags.Title = "部件管理";
        //    ucTopTags.Items = "添加部件,?mat=0|部件列表,?mat=1";
        //}
    }
}
