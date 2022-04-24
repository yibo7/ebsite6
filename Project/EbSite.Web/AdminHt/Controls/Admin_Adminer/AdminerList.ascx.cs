using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;

namespace EbSite.Web.AdminHt.Controls.Admin_Adminer
{
    public partial class AdminerList : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "86";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "181";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "201";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "200";
            }
        }

        #endregion

        private int GetRoleID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["rid"]))
                {
                    return int.Parse(Request["rid"]);
                }
                return -1;
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            AdminUser userAdmin = new AdminUser();
            if (GetRoleID > 0)
            {
                return userAdmin.GetAllUsers(GetRoleID);
            }
            else
            {
                return userAdmin.GetAllUsers("");
            }
           
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            AdminUser userAdmin = new AdminUser();
            return userAdmin.GetAllUsers(ucToolBar.GetItemVal(txtKeyWord));
        }
        override protected void Delete(object iID)
        {
            
            AdminUser userAdmin = new AdminUser(iID.ToString());
            userAdmin.Delete();


        }

        #region 工具栏的初始化
        protected Control.TextBox txtKeyWord = new Control.TextBox();
        protected Control.DropDownList drpUserGrou = new Control.DropDownList();
        protected Control.DropDownList drpType = new Control.DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar(false, false, true, false, false);

            ucToolBar.AddLine();
            if (GetRoleID == -1)
            {
                txtKeyWord.ID = "txtKeyWord";
                ucToolBar.AddCtr(txtKeyWord);

                base.ShowCustomSearch("搜索");
                ucToolBar.AddLine();
            }

            ucToolBar.AddBnt("锁定管理员", string.Concat(IISPath, "images/Menus/User-Lock.gif"), "lockadmin");
            ucToolBar.AddBnt("解锁管理员", string.Concat(IISPath, "images/Menus/Key-Add.gif"), "unlockadmin");


        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "lockadmin":
                    foreach (string key in GetSelKeys)
                    {
                        AdminUser au = new AdminUser(key);
                        au.IsLock = true;
                        au.Update();
                    }
                    gdList_Bind();
                    break;
                case "unlockadmin":
                    foreach (string key in GetSelKeys)
                    {
                        AdminUser au = new AdminUser(key);
                        au.IsLock = false;
                        au.Update();
                    }
                    gdList_Bind();
                    break;


            }
        }
        #endregion

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if(!IsPostBack)
        //    {
                 
        //    }
        //    AdminUser userAdmin = new AdminUser();

        //    AdminList.DataSource = userAdmin.GetAllUsers(txtAdminer.Text.Trim());
        //    AdminList.DataBind();    
            
        //}

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    AdminUser userAdmin = new AdminUser();
            
        //    AdminList.DataSource = userAdmin.GetAllUsers(txtAdminer.Text.Trim());
        //    AdminList.DataBind();
        //}

        //protected void AdminList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (Equals(e.CommandName, "setadminrole"))
        //    {
        //        string userid = e.CommandArgument.ToString();
        //        Response.Redirect("Admin_Adminer.aspx?mpid=fd115a02-6a71-4133-8c04-a4a812fa16c1&msid=1faeedfe-1e13-4300-92e4-e7d1b110deec&uid=" + userid);

        //    }
        //    else if (Equals(e.CommandName, "deleteadmin"))
        //    {
        //        string userid = e.CommandArgument.ToString();
        //        AdminUser userAdmin = new AdminUser(userid);
        //        userAdmin.Delete();

        //        Response.Redirect(Request.RawUrl);
                
        //    }
        //    else if (Equals(e.CommandName, "ShowPermissions"))
        //    {
        //        string userid = e.CommandArgument.ToString();
        //        Response.Redirect("Admin_Adminer.aspx?mat=6&id=" + userid);

        //    }

        //}
    }
}