using System;
using EbSite.Base.Page;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Menu : EbSite.Base.Page.ManagePage
    {
        protected override MasterType eMasterType
        {
            get
            {
                if (PageType == 2 || PageType == 4 )
                    return MasterType.Mini;
                return MasterType.Custom;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            base.SetContolsPath("Admin_Menu");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 0)
            {

                base.LoadAControl("Menu_List.ascx");

            }
            else if (PageType == 1)
            {

                base.LoadAControl("Menu_Add.ascx");

            }
            else if (PageType == 2)
            {

                base.LoadAControl("MoveMenu.ascx");

            }
            else if (PageType == 3)
            {

                base.LoadAControl("UserMenu_Add.ascx");

            }
            else if (PageType == 4)
            {

                base.LoadAControl("UserMenu_Move.ascx");

            }  
             else if (PageType == 5)
            {

                base.LoadAControl("UserMenu_Roles.ascx");

            }
            else if (PageType == 6)
            {

                base.LoadAControl("UserMenu_MemuRoles.ascx");

            }
            else
            {
                base.AddControl();
            }



        }

    }
}
