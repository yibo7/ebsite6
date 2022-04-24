using System;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_WidgetsTem : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Widgettem");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 1)
            {
                base.LoadAControl("AddClass.ascx");
            }
            else if (PageType == 2)
            {
                base.LoadAControl("TemList.ascx");
            }
            else if (PageType == 3)
            {
                base.LoadAControl("AddTem.ascx");
            }
            else if(PageType==10)
            {
                base.LoadAControl("EditTem.ascx");
            }
            else if (PageType == 11)
            {
                base.LoadAControl("contenttemadd.ascx");
            }
            else
            {
                base.AddControl();
            }

            //if (phBody == null) return;
            //switch (GetMat)
            //{
            //    case 0:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AddClass.ascx"));
            //        break;
            //    case 1:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/ClassList.ascx"));
            //        break;
            //    case 2:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AddTem.ascx"));
            //        break;
            //    case 3:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/TemList.ascx"));
            //        break;

            //    case 10:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/EditTem.ascx"));
            //        break;
               

               

                    
            //}

        }

    }
}
