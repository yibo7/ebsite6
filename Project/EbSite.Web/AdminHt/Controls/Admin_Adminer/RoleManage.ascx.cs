using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.ControlPage;
using EbSite.BLL;

namespace EbSite.Web.AdminHt.Controls.Admin_Adminer
{
    public partial class RoleManager : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "84";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "90";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "197";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "196";
            }
        }

        #endregion

        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return AccountsTool.GetRoleList();
        }

        
        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            int iIndex = int.Parse(iID.ToString());

            AdminRole role = new AdminRole(iIndex);

            role.Delete();
        }

        #region 工具栏的初始化
        protected Control.TextBox txtRoleName = new Control.TextBox();
        protected Control.DropDownList drpUserGrou = new Control.DropDownList();
        protected Control.DropDownList drpType = new Control.DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar(true, false, true, false, false);

            ucToolBar.AddLine();

            txtRoleName.ID = "txtRoleName";
            txtRoleName.Attributes.Add("style", "width:90px");
            ucToolBar.AddCtr(txtRoleName);


            ucToolBar.AddBnt("添加角色", string.Concat(IISPath, "images/Menus/User-Ok.gif"), "addrole");
            ucToolBar.AddLine();

            if(!Equals(UserOfEdit,null))
            {
                
                ucToolBar.AddBnt("分配所选角色", string.Concat(IISPath, "images/Menus/User-Ok.gif"), "setrole");
            }
           

        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "addrole":
                    if (!string.IsNullOrEmpty(ucToolBar.GetItemVal(txtRoleName)))
                    {
                        AdminRole role = new AdminRole();
                        role.Description = ucToolBar.GetItemVal(txtRoleName);
                        try
                        {
                           
                            role.Create();
                            gdList_Bind();
                            base.TipsAlert("添加成功！");
                           
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        base.TipsAlert("角色名称请添写");
                    }

                    break;
                case "setrole":

                    foreach (GridViewRow row in gdList.Rows)
                    {

                        CheckBox cb = (CheckBox)row.FindControl("Selector");

                        if (cb != null && cb.Checked)
                        {
                            string RoleID = gdList.DataKeys[row.RowIndex].Value.ToString();

                            UserOfEdit.AddToRole(int.Parse(RoleID));

                        }
                        else if (cb != null)
                        {
                            string RoleID = gdList.DataKeys[row.RowIndex].Value.ToString();
                            UserOfEdit.RemoveRole(int.Parse(RoleID));

                        }

                    }
                    break;


            }
        }
        
        #endregion
        private void binduserole()
        {
            AdminPrincipal newUser = new AdminPrincipal(UserOfEdit.UserName);

            if (newUser.PermissionsID.Count > 0)
            {
                List<string> Roles = new List<string>();

                foreach (string roleid in newUser.Roles)
                {
                    Roles.Add(roleid);
                }
                //ArrayList roles = newUser.PermissionsID;
                foreach (GridViewRow item in gdList.Rows)
                {
                    Literal ll = (Literal)item.Cells[0].Controls[0].FindControl("llRoleName");
                    CheckBox cb = (CheckBox)item.FindControl("Selector");
                    if (Roles.Contains(ll.Text.Trim()))
                    {
                        cb.Checked = true;
                    }
                }
            }

            //AccountsPrincipal newUser = new AccountsPrincipal(UserOfEdit.UserName);

            //if (newUser.Roles.Count > 0)
            //{
            //    ArrayList roles = newUser.Roles;
                
            //    for (int i = 0; i < roles.Count; i++)
            //    {
            //        //int j = 0;
            //        foreach (GridViewRow item in gdList.Rows)
            //        {
            //            Literal ll = (Literal)item.Cells[0].Controls[0].FindControl("llRoleName");
            //            CheckBox cb = (CheckBox)item.FindControl("Selector");
            //            if (ll.Text.Trim() == roles[i].ToString().Trim())
            //            {
            //                cb.Checked = true;
            //            }
            //            //j++;
            //        }
            //    }
            //}
        }
        private AdminUser UserOfEdit
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["uid"]))
                {

                    AdminUser thisuser = new AdminUser(Request["uid"]);

                    return thisuser;

                }
                return null;
            }
        }
        protected void RoleList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdList.EditIndex = -1;
            gdList_Bind();

        }
        protected void RoleList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdList.EditIndex = e.NewEditIndex;
            gdList_Bind();
        }
        protected void RoleList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                GridViewRow row = gdList.Rows[e.RowIndex];

                int iRoleID = (int)gdList.DataKeys[e.RowIndex].Value;

                string TXB_FORUMNAME = ((TextBox)row.FindControl("txtRoleName")).Text.Trim().ToString();

                AdminRole role = new AdminRole(iRoleID);

                role.Description = TXB_FORUMNAME;

                role.Update();

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

            gdList.EditIndex = -1;
            gdList_Bind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!Equals(UserOfEdit, null))
                {
                    binduserole();
                }
            }

        }
        //private void binddata()
        //{
            
        //    RoleList.DataSource = AccountsTool.GetRoleList();
        //    RoleList.DataBind();
        //}

        //private void binduserole()
        //{
        //    AccountsPrincipal newUser = new AccountsPrincipal(UserOfEdit.UserName);

        //    if (newUser.Roles.Count > 0)
        //    {
        //        ArrayList roles = newUser.Roles;
        //        for (int i = 0; i < roles.Count; i++)
        //        {
        //            int j = 0;
        //            foreach (GridViewRow item in RoleList.Rows)
        //            {
        //                Literal ll = (Literal)item.Cells[0].Controls[0].FindControl("llRoleName");
        //                CheckBox cb = (CheckBox)item.FindControl("Selector");
        //                if (ll.Text.Trim() == roles[i].ToString().Trim())
        //                {
        //                    cb.Checked = true;
        //                }
        //                j++;
        //            }
        //        }
        //    }
        //}

        //protected void RoleList_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    RoleList.EditIndex = e.NewEditIndex;
        //    binddata();
        //}

        //protected void RoleList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    RoleList.EditIndex = -1;
        //    binddata();

        //}

        //protected void RoleList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    try
        //    {

        //        GridViewRow row = RoleList.Rows[e.RowIndex];

        //        int iRoleID = (int) RoleList.DataKeys[e.RowIndex].Value;
                
        //        string TXB_FORUMNAME = ((TextBox)row.FindControl("txtRoleName")).Text.Trim().ToString();

        //        AdminRole role = new AdminRole(iRoleID);

        //        role.Description = TXB_FORUMNAME;

        //        role.Update();

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex);
        //    }

        //    RoleList.EditIndex = -1;
        //   binddata();
        //}

        //protected void btnAddRole_Click(object sender, EventArgs e)
        //{
        //    AdminRole role = new AdminRole();
        //    role.Description = txtRoleName.Text.Trim();
        //    try
        //    {
        //        role.Create();
        //    }
        //    catch { }
        //    binddata();
        //}

        //protected void RoleList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (Equals(e.CommandName, "DeleteRole"))
        //    {
        //        int iIndex = int.Parse(e.CommandArgument.ToString());

        //        AdminRole role = new AdminRole(iIndex);

        //        role.Delete();
        //        binddata();
        //    }
        //    else if (Equals(e.CommandName, "AddPermissions"))
        //    {
        //        int iIndex = int.Parse(e.CommandArgument.ToString());
        //        Response.Redirect("Admin_Adminer.aspx?mat=5&id="+iIndex);
        //    }
           
        //}

        //protected void lbDelete_Click(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow row in RoleList.Rows)
        //    {
        //        // Access the CheckBox
        //        CheckBox cb = (CheckBox)row.FindControl("Selector");
        //        if (cb != null && cb.Checked)
        //        {
        //            string ID = RoleList.DataKeys[row.RowIndex].Value.ToString();

        //            AdminRole role = new AdminRole(int.Parse(ID));

        //            role.Delete();
                    
        //        }
        //    }
        //    binddata();
        //}
        //private AdminUser UserOfEdit
        //{
        //    get
        //    {
        //        if(!string.IsNullOrEmpty(Request["uid"]))
        //        {

        //            AdminUser thisuser = new AdminUser(Request["uid"]);

        //            return thisuser;

        //        }
        //        return null;
        //    }
        //}
        //protected void btnAddRoleToUser_Click(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow row in RoleList.Rows)
        //    {
                
        //        CheckBox cb = (CheckBox)row.FindControl("Selector");

        //        if (cb != null && cb.Checked)
        //        {
        //            string RoleID = RoleList.DataKeys[row.RowIndex].Value.ToString();

        //            UserOfEdit.AddToRole(int.Parse(RoleID));
                    
        //        }
        //        else if (cb != null)
        //        {
        //            string RoleID = RoleList.DataKeys[row.RowIndex].Value.ToString();
        //            UserOfEdit.RemoveRole(int.Parse(RoleID));

        //        }
               
        //    }
        //}

       
    }
}