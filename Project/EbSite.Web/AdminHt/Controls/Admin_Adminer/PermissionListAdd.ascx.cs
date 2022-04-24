using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Adminer
{
    public partial class PermissionListAdd : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "87";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
            if(!string.IsNullOrEmpty(SID))
            {
                BLL.Permissions permissions = BLL.Permissions.GetPermissionsByID(int.Parse(SID));
                txtPermissionName.Text = permissions.PermissionName;
                drpPatentID.SelectedValue = permissions.ParentID.ToString();

            }

           
        }

        override protected void SaveModel()
        {
            
            int ParentID = int.Parse(drpPatentID.SelectedValue);

            if(string.IsNullOrEmpty(SID))
            {
                BLL.Permissions.Create(ParentID,txtPermissionName.Text);
            }
            else
            {
                BLL.Permissions.Update(int.Parse(SID), ParentID, txtPermissionName.Text);
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                binddata();
            }
        }
        /// <summary>
        /// 绑定父菜单
        /// </summary>
        private void binddata()
        {
            drpPatentID.DataTextField = "PermissionName";
            drpPatentID.DataValueField = "PermissionID";
            drpPatentID.DataSource = BLL.Permissions.GetTree();
            drpPatentID.DataBind();

        }
        
    }
}