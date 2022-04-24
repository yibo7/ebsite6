using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Model : EbSite.Base.Page.ManagePage
    {
        protected override MasterType eMasterType
        {
            get
            {
                if (PageType == 3)
                {
                    return MasterType.Mini;
                }
                return MasterType.Custom;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            //sContolsPath = "Admin_Model";
            //base.phBody = phBodyControls;
            //AddControl();
            //if (!IsPostBack)
            //{

            //    BindTopTags();

            //}
            base.SetContolsPath("Admin_Model");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 0)  //添加修改内容模型
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/AddModelForContent.ascx"));
                base.LoadAControl("AddModel.ascx");
            }
            else if (PageType == 3)  //添加修改用户模型
            {
                base.LoadAControl("OrderFileds.ascx");
            }
            else if (PageType == 4)  //添加修改用户模型
            {
                base.LoadAControl("EditFileds.ascx");
            }
            else if (PageType == 5)  
            {
                base.LoadAControl("EditFiledsForForm.ascx");
            }
            else if (PageType == 6)
            {
                base.LoadAControl("FormContent.ascx");
            }
            else if (PageType == 7)
            {
                base.LoadAControl("AddModelForm.ascx");
            }
            else if (PageType == 8)
            {
                base.LoadAControl("EditFormTem.ascx");
            }
            else if (PageType == 9)  //快捷菜单排 序
            {
                base.LoadAControl("OrderFastMenus.ascx");
            }
            else
            {
                base.AddControl();
            }

        }
        
    }
}