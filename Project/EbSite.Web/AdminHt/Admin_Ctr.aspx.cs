using System;
using EbSite.Base.Page;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Ctr : EbSite.Base.Page.ManagePage
    {
        protected override MasterType eMasterType
        {
            get
            {
                if (PageType == 7)
                {
                    return MasterType.Mini;
                }
                return MasterType.Custom;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            //sContolsPath = "Admin_Ctr";
            //base.phBody = phBodyControls;
            //AddControl();
            //if (!IsPostBack)
            //{

            //    BindTopTags();

            //}
            base.SetContolsPath("Admin_Ctr");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType==7)
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/AddCtrls.ascx"));
                base.LoadAControl("AddCtrls.ascx");
            }
            else if (PageType == 8)
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/EditModelCtrlTem.ascx"));
                base.LoadAControl("EditModelCtrlTem.ascx");
            }
            else if (PageType == 9)
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/ModelCtrlPreview.ascx"));
                base.LoadAControl("ModelCtrlPreview.ascx");
            }
            else if (PageType == 6)
            {
                base.LoadAControl("ClassAdd.ascx");
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/ClassAdd.ascx"));
            }
            else
            {
                base.AddControl();
            }

            //if (phBody == null) return;
            //switch (GetMat)
            //{
            //    case 0:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/CtrlsTemList.ascx"));
            //        break;
            //    case 1:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/CtrlsList.ascx"));
            //        break;
            //    case 7:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AddCtrls.ascx"));
            //        break;
            //    case 8:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/EditModelCtrlTem.ascx"));
            //        break;
            //    case 9:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/ModelCtrlPreview.ascx"));
            //        break;
              

                    
            //}

        }

        //protected override void BindTopTags()
        //{
        //    ucTopTags.Index = (int)CurrentAdtion;
        //    ucTopTags.Title = "管理模型控件";
        //    ucTopTags.Items = "添加控件,?mat=0|管理控件,?mat=1";
        //}
    }
}
