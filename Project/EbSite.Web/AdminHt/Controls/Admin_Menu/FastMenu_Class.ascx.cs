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
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Menu
{
    public partial class FastMenu_Class : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "160";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "160";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "160";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "160";
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
            BLL.FastMenuClass.Instance.Delete(iIndex); 
        }

        #region 工具栏的初始化
        protected TextBox txtClassName = new TextBox(); 
        override protected void BindToolBar()
        {

            base.BindToolBar(true, false, true, false, false);

            ucToolBar.AddLine();

            txtClassName.ID = "txtClass";
            txtClassName.Attributes.Add("style", "width:90px");
            ucToolBar.AddCtr(txtClassName);


            ucToolBar.AddBnt("添加分类", string.Concat(IISPath, "images/Menus/User-Ok.gif"), "add");
             
           

        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "add":
                    if (!string.IsNullOrEmpty(ucToolBar.GetItemVal(txtClassName)))
                    {
                       EbSite.Entity.FastMenuClass c = new EbSite.Entity.FastMenuClass();
                        c.ClassName = ucToolBar.GetItemVal(txtClassName);
                        try
                        {

                            BLL.FastMenuClass.Instance.Add(c);
                            gdList_Bind();
                            base.TipsAlert("添加成功！");
                           
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        base.TipsAlert("请填写分类名称");
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
                    Literal ll = (Literal)item.Cells[0].Controls[0].FindControl("llClassName");
                    CheckBox cb = (CheckBox)item.FindControl("Selector");
                    if (Roles.Contains(ll.Text.Trim()))
                    {
                        cb.Checked = true;
                    }
                }
            }
             
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

                string TXB_FORUMNAME = ((TextBox)row.FindControl("txtClassName")).Text.Trim().ToString();

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

       
    }
}