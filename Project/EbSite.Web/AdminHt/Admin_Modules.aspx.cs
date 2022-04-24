using System;
using EbSite.Base.Page;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Modules  : EbSite.Base.Page.ManagePage
    {
        protected override MasterType eMasterType
        {
            get
            {
                if (PageType == 7 || PageType == 14 || PageType == 21 || PageType == 24)
                    return MasterType.Mini;
                if (PageType == 1 || PageType == 2 || PageType == 18 || PageType == 20 || PageType == 22 || PageType == 23)
                    return MasterType.Modules;
                return MasterType.Custom;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Modules");
        }
        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            //if (PageType == 0)
            //{

            //    base.LoadAControl("Menu_List.ascx");

            //}
            //else if (PageType == 1)
            if (PageType == 1)
            {

                base.LoadAControl("Menus.ascx");

            }
            else if (PageType == 2)
            {

                base.LoadAControl("ModuleConfigs.ascx");

            }
            else if (PageType == 3)
            {

                base.LoadAControl("Pages.ascx");

            }
            else if (PageType == 4)
            {

                base.LoadAControl("GetDataBaseTables.ascx");

            }
            //else if (PageType == 6)
            //{

            //    base.LoadAControl("Main.ascx");

            //}
            else if (PageType == 7)
            {

                base.LoadAControl("OutPutModule.ascx");

            }
            //选择字段 --添加页面
            else if (PageType == 10)
            {

                base.LoadAControl("EbOA.ModulesGenerate/FieldAdd.ascx");

            }
            //选择字段 --列表页面
            else if (PageType == 11)
            {

                base.LoadAControl("EbOA.ModulesGenerate/FieldList.ascx");

            }
            //选择字段 --显示页面
            else if (PageType == 12)
            {

                base.LoadAControl("EbOA.ModulesGenerate/FieldShow.ascx");

            }
            //选择字段--高级搜索页面
            else if (PageType == 13)
            {

                base.LoadAControl("EbOA.ModulesGenerate/FieldSearchAdv.ascx");

            }

            //菜单的位置定位。
            else if (PageType == 14)
            {
                base.LoadAControl("MenusManage.ascx");

            }
            //else if (PageType == 15)
            //{

            //    base.LoadAControl("HelpShow.ascx");

            //}
            //else if (PageType == 16)
            //{
            //    base.LoadAControl("HelpAdd.ascx");
            //}
            else if (PageType == 18)
            {
                base.LoadAControl("Upgrade.ascx");
            }
            //选择字段--搜索页面
            else if (PageType == 19)
            {

                base.LoadAControl("EbSite.ModulesGenerate/FieldSearch.ascx");

            }
            else if (PageType == 20)
            {

                base.LoadAControl("LimitList.ascx");

            }
            else if (PageType == 21)
            {

                base.LoadAControl("LimitRole.ascx");

            }
            else if (PageType == 22)
            {

                base.LoadAControl("MenuForUser.ascx");

            }
            else if (PageType == 23)
            {

                base.LoadAControl("LimitListForUser.ascx");

            }
            else if (PageType == 24)
            {

                base.LoadAControl("LimitRoleForUser.ascx");

            }
             else if (PageType == 25)
            {

                base.LoadAControl("SetupModeles2.ascx");

            }
            else if (PageType == 26)
            {

                base.LoadAControl("SetupModeles2SqlServer.ascx");

            }
            else if (PageType == 27)
            {

                base.LoadAControl("SetupModeles2Access.ascx");

            }
            else if (PageType == 28)
            {

                base.LoadAControl("SetupModelesZip.ascx");

            }
            else
            {
                base.AddControl();
            }


        }

    }
}