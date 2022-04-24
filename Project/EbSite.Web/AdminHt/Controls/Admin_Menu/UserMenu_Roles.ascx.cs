using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.User;
using EbSite.Control;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace EbSite.Web.AdminHt.Controls.Admin_Menu
{
    public partial class UserMenu_Roles : UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "160";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

         

            if (!IsPostBack)
            {


            }

        }


        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return UserGroupProfile.UserGroupProfiles;

        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return UserGroupProfile.SearchUserGroups(ucToolBar.GetItemVal(RoleName));

        }
        override protected void Delete(object iID)
        {


        }

        #region  工具条的初使化
        protected System.Web.UI.WebControls.Label lb = new Label();
        protected System.Web.UI.WebControls.TextBox RoleName = new TextBox();

        protected override void BindToolBar()
        {
            base.BindToolBar(true, true, true, true, false);
            lb.ID = "lb";
            lb.Text = "用户组名称";
            ucToolBar.AddCtr(lb);
            RoleName.ID = "RoleName";
            RoleName.Attributes.Add("style", "width:120px");
            ucToolBar.AddCtr(RoleName);
            base.ShowCustomSearch("查询");
            //ucToolBar.AddBnt("生成权限", IISPath + "images/menus/key.png", "MakePomission", true, "return confirm('确认要重新生成权限吗。')", "如果你是模块的开发者，添加了新的页面才可以进行此操作");

        }
        #endregion

        #region 　工具条扩展事件
        //protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        //{
        //    base.ucToolBar_ItemClick(source, e);
        //    switch (e.ItemTag)
        //    {

        //        case "MakePomission":
        //            //MenuBll.MakePomission(this.Page, Model.ModuleName, Model.id);
        //            break;
        //        case "DelPomission":
        //            //MenuBll.DelPomission(Model.id);               
        //            break;

        //    }
        //}
        #endregion
    }
}