using System;
using EbSite.Pages; 

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Class : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Class");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 0)  //添加分类
            {
                //bool IsLongClass = base.CurrentSite.IsClassContent;
                //if (IsLongClass)
                //{
                    
                //    base.LoadAControl("AddClass.ascx");
                //}
                //else
                //{
                    
                //    base.LoadAControl("AddClassSimple.ascx");
                //}
                base.LoadAControl("AddClass.ascx");

            }
            else if (PageType == 1)
            {
                base.LoadAControl("ClassManage.ascx");
            }
            else if (PageType == 2)  
            {

                base.LoadAControl("AddClassSelClass.ascx");
            }
            else if (PageType == 3) //移动分类
            {
                base.LoadAControl("MoveClassMore.ascx");
            }
            else if (PageType == 4)//合并分类
            {

                base.LoadAControl("MergeClassMore.ascx");
            }
            else if (PageType == 5)//合并分类
            {

                base.LoadAControl("ClassConfigs.ascx");
            }
            else if (PageType == 6)//合并分类
            {
                base.LoadAControl("ClassConfigList.ascx");
            }
            else
            {
                base.AddControl();
            }

        }
    }
}
