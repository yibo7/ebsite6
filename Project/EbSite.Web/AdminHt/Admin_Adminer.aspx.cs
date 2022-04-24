using System;
using EbSite.Pages;
using EbSite.Base.Page;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Adminer : EbSite.Base.Page.ManagePage
    {
        protected override MasterType eMasterType
        {
            get
            {
                if (PageType == 6|| PageType == 2)
                {
                    return MasterType.Mini;
                }
                return MasterType.Custom;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Adminer");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
             if(PageType==0)
             {
                 base.LoadAControl("AddAdminer.ascx");
             }
             else if(PageType==1)
             {
                 base.LoadAControl("PermissionListAdd.ascx");
             }
             else if (PageType == 2)
             {
                 base.LoadAControl("RoleManage.ascx");
             }
             else if(PageType==4)
            {
                base.LoadAControl("PermissionList.ascx");
            }
            else if (PageType == 5)
            {
                base.LoadAControl("RolePermission.ascx");
            }
            else if (PageType == 6)
            {
                base.LoadAControl("ShowUserPermission.ascx");
            }
            else if (PageType == 7)
             {
                 base.LoadAControl("AdminerList.ascx");
             }
            else
            {
                base.AddControl();
            }

            //if (phBody == null) return;
            //switch (GetMat)
            //{
            //    case 0:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AdminerList.ascx"));
            //        break;
            //    case 1:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AddAdminer.ascx"));
            //        break;
            //    case 2:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/RoleManage.ascx"));
            //        break;
            //    case 3:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/PermissionClass.ascx"));
            //        break;

            //    case 4:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/PermissionList.ascx"));
            //        break;
            //    case 5:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/RolePermission.ascx"));
            //        break;
            //    case 6:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/ShowUserPermission.ascx"));
            //        break;
            //}

        }

        //protected override void BindTopTags()
        //{
        //    ucTopTags.Index = (int)CurrentAdtion;
        //    ucTopTags.Title = "管理员管理";
        //    ucTopTags.Items = "管理员列表,?mat=0|添加管理员,?mat=1|角色管理,?mat=2|权限管理,?mat=3";
        //}
    }
}
