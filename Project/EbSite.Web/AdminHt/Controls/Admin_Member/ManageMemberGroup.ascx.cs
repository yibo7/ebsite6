using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.User;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class ManageMemberGroup : UserControlListBase
    {

        public override string Permission
        {
            get
            {
                return "73";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "74";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "183";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "187";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }
        ///// <summary>
        ///// 自定义模板页，目前只能应用于路由,不能应用于单独页面
        ///// </summary>
        //protected override string MasterPagePath
        //{
        //    get
        //    {
        //        return "Ask.Master";
        //    }
        //}
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return UserGroupProfile.UserGroupProfiles;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return UserGroupProfile.SearchUserGroups(ucToolBar.GetItemVal(txtKeyWord));
        }
        override protected void Delete(object iID)
        {
            int id = int.Parse(iID.ToString());

            UserGroupProfile ugp = UserGroupProfile.GetUserGroupProfile(id);

            ugp.Delete();
            ugp.Save();

        }



        #region 工具栏的初始化
        protected Label label = new Label();
        protected TextBox txtKeyWord = new TextBox();
        protected override void BindToolBar()
        {
            base.BindToolBar();

            label.ID = "lblOne";
            label.Text = " 会员组名称 ";
            ucToolBar.AddCtr(label);

            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);
            base.ShowCustomSearch("查询");
            ucToolBar.AddLine();


            if (!string.IsNullOrEmpty(sUserName))
            {
                //if (IsMoreGroup) BindUserGroup();/2014-3-19 YHL/
                ucToolBar.AddBnt("添加用户到所选用户组", string.Concat(IISPath, "images/Menus/User-Ok.gif"), "addto");
            }




        }
        protected string[] UserGroups
        {
            get
            {
                return Roles.GetRolesForUser(sUserName);
            }
        }
        /// <summary>
        /// 工具栏事件扩展
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {

            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "addto":

                    //if (UserGroups.Length > 0)
                    //{
                    //    //去重，修复bug http://www.ebsite.net/873content.ashx
                    //    IEnumerable<string> ling = (from b in UserGroups select b).Distinct();

                    //    Roles.RemoveUserFromRoles(sUserName, ling.ToArray());
                    //}
                    //2014-3-19 YHL/
                    //if (IsMoreGroup)//多用户组机制
                    //{
                    //    //添加用户到用户组前先清空当前用户的用户组

                    //    List<string> AddGroups = new List<string>();

                    //    foreach (GridViewRow row in gdList.Rows)
                    //    {

                    //        CheckBox cb = (CheckBox)row.FindControl("SelectorGp");

                    //        if (cb != null && cb.Checked)
                    //        {
                    //            string GroupName = gdList.DataKeys[row.RowIndex].Value.ToString();
                    //            AddGroups.Add(GroupName);

                    //        }

                    //    }
                    //    if (AddGroups.Count > 0)
                    //    {

                    //        Roles.AddUserToRoles(sUserName, AddGroups.ToArray());
                    //    }
                    //}

                    //单用户组机制

                    string GroupId = gdList.DataKeys[SuppliersSelectedIndex].Value.ToString();
                    //Core.Utils.TestDebug(GroupName);
                    if (!string.IsNullOrEmpty(GroupId))
                    {
                       // Roles.AddUserToRole(sUserName, GroupName);
                       // int groupid = BLL.User.UserGroupProfile.GetRoleIDByUserName(GroupName);
                        EbSite.BLL.User.MembershipUserEb.Instance.UpdateUserGroupId(sUserName, Core.Utils.StrToInt(GroupId,1) );
                    }

                   EbSite.Base.Host.CacheApp.Clear();// EbSite.Core.CacheManager.RemoveAllCache();
                    Response.Redirect(Request.RawUrl);

                    break;
            }
        }

        #endregion



        //自定义方法
        /*2014-3-19 YHL 前台用户 没有分多个用户组的。为了优化查询，固改为 固定的单选*/
        //private bool IsMoreGroup
        //{
        //    get
        //    {
        //        return (Base.Configs.UserSetConfigs.ConfigsControl.Instance.GroupType == 1);
        //    }
        //}
        //2014-3-19 YHL/
        //private void BindUserGroup()
        //{
        //    string[] Groups = Roles.GetRolesForUser(sUserName);
        //    if (Groups.Length > 0)
        //    {

        //        for (int i = 0; i < Groups.Length; i++)
        //        {
        //            int j = 0;
        //            foreach (GridViewRow item in gdList.Rows)
        //            {
        //                string GroupName = gdList.DataKeys[item.RowIndex].Value.ToString();
        //                CheckBox cb = (CheckBox)item.FindControl("SelectorGp");
        //                if (GroupName.Trim() == Groups[i].Trim())
        //                {
        //                    cb.Checked = true;
        //                }
        //                j++;
        //            }
        //        }
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {



        }

        private string GetUserGroupID;
        override protected void gdList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            base.gdList_RowCreated(sender,e);
            if (!string.IsNullOrEmpty(sUserName))
            {
                if (string.IsNullOrEmpty(GetUserGroupID))
                {
                    GetUserGroupID = BLL.User.MembershipUserEb.Instance.GetUserGroupId(sUserName).ToString();
                }
               
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (!string.IsNullOrEmpty(sUserName))
                    {
                        Literal output = (Literal) e.Row.FindControl("RadioButtonMarkup");
                        output.Text =
                            string.Format(
                                @"<input type=""radio"" name=""GroupID"" id=""RowSelector{0}"" value=""{0}""",
                                e.Row.RowIndex);
                        if (!string.IsNullOrEmpty(GetUserGroupID))
                        {
                            if (GetUserGroupID == gdList.DataKeys[e.Row.RowIndex].Value.ToString())
                                output.Text += @" checked=""checked""";
                        }
                        output.Text += " />";
                    }
                    else
                    {
                        gdList.HeaderRow.Cells[5].Visible = false;
                        e.Row.Cells[5].Visible = false;
                    }

                }
            }
        }
        private int SuppliersSelectedIndex
        {
            get
            {
                if (string.IsNullOrEmpty(Request.Form["GroupID"]))
                    return -1;
                else
                    return Convert.ToInt32(Request.Form["GroupID"]);
            }
        }


        private string sUserName
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["u"]))
                {
                    return Request["u"];
                }
                return string.Empty;
            }
        }
    }
}