using System;
using System.Collections;
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
    public partial class PermissionList : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "85";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                if (GetRoleID > 0)
                {
                    return "-1";
                }
                return "87";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                if (GetRoleID > 0)
                {
                    return "-1";
                }
                return "199";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                if (GetRoleID>0)
                {
                    return "-1";
                }
                return "198";
            }
        }

        #endregion
         
        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return Permissions.GetTree_pic();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            string sPermissionName = ucToolBar.GetItemVal(txtOne);
            if(!string.IsNullOrEmpty(sPermissionName))
            {
                
                return Permissions.GetPermissionsListByName(sPermissionName);
            }
            else
            {
                return Permissions.GetTree_pic();
            }
            
        }
        override protected void Delete(object iID)
        {
            Permissions.Delete(int.Parse(iID.ToString()));

        }
        protected Label label = new Label(); 
        protected Control.TextBox txtOne = new Control.TextBox();
        protected override void BindToolBar()
        {
            base.BindToolBar();

            label.ID = "lblOne";
            label.Text = " 权限名称 ";
            ucToolBar.AddCtr(label);

            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);
            base.ShowCustomSearch("查询");

            ucToolBar.AddLine();
            if (!string.IsNullOrEmpty(Request["rid"]))
            {
                ucToolBar.AddBnt("保存权限", string.Concat(IISPath, "images/Menus/User-Lock.gif"), "addpermission");
            }
            

        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "addpermission":
                   
                    foreach (GridViewRow row in gdList.Rows)
                    {
                        // Access the CheckBox
                        System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
                        string PermissionID = gdList.DataKeys[row.RowIndex].Value.ToString();
                        if (cb != null && cb.Checked)
                        {
                            if (!currentRole.PermissionsIDList.Contains(PermissionID))
                                currentRole.AddPermission(int.Parse(PermissionID));

                        }
                        else
                        {
                            if (currentRole.PermissionsIDList.Contains(PermissionID))
                                currentRole.RemovePermission(int.Parse(PermissionID));
                        }
                    }
                    //AdminRole.ClearCache();
                    EbSite.Base.Host.CacheApp.Clear();// EbSite.Core.CacheManager.RemoveAllCache();

                    break;
            

            }
        }
        private AdminRole currentRole
        {
            get
            {

                if (GetRoleID>0)
                {
                    return AdminRole.AdminRoleInstace(GetRoleID);
                }
                return null;
            }
        }
        private void BindRolePermission()
        {
            AdminRole thisRole = currentRole;
            if (thisRole.PermissionsIDList.Count > 0)
            {

                foreach (GridViewRow item in gdList.Rows)
                {
                    string PermissionID = gdList.DataKeys[item.RowIndex].Value.ToString();
                    CheckBox cb = (CheckBox)item.FindControl("Selector");
                    if (thisRole.PermissionsIDList.Contains(PermissionID))
                    {
                        cb.Checked = true;
                    }
                }
            }
        }
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetRoleID>0)
                {
                    BindRolePermission();
                }
                

            }
           
        }
        
    }
}