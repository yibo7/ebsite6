using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Entity;
using EbSite.Entity.Module;

namespace EbSite.Web.AdminHt.Controls.Admin_Menu
{
    public partial class UserMenu_MemuRoles : UserControlListBase
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
                return "-1";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "230";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "229";
            }
        }

        #endregion

        override protected string AddUrl
        {
            get
            {
                return "t=3";
            }
        }
        override protected object LoadList(out int iCount)
        {
            ntInfo.Text = string.Format("请为[{0}]用户组选择以下权限,然后点保存权限。", Request["name"]);

            iCount = 0;
            return BLL.MenusForUser.Instance.GetListArray("");
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<MenusForUser> lsit = BLL.MenusForUser.Instance.GetListArray("");
            List<MenusForUser> ls = new List<MenusForUser>();
            foreach (MenusForUser menuse in lsit)
            {
                if (menuse.MenuName.IndexOf(ucToolBar.GetItemVal(txtOne).Trim()) != -1)
                {
                    ls.Add(menuse);
                }
            }

            return ls;
        }
        override protected void Delete(object iID)
        {
            //Guid id = new Guid(iID.ToString());
            //BLL.MenusForUser.Instance.Delete(id);

        }
        protected Label label = new Label(); protected Control.TextBox txtOne = new Control.TextBox();
        protected override void BindToolBar()
        {
            base.BindToolBar(true, true, true, true, true);
            
            label.ID = "lblOne";
            label.Text = " 菜单名称 ";
            ucToolBar.AddCtr(label);

            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);
            base.ShowCustomSearch("查询");

           
        }
        private BLL.ModulesBll.LimitRole<Guid> bllLimitRole
        {
            get
            {
                return new BLL.MenusForUserRole();
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
                return 0;
            }
        }
        protected override void gdList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            base.gdList_RowCreated(sender, e);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row;
                CheckBox wbShow = (CheckBox)row.FindControl("Selector");
                if (!object.Equals(wbShow, null))
                {
                    string sID = gdList.DataKeys[e.Row.RowIndex].Value.ToString();

                    if (bllLimitRole.IsHave(GetRoleID, new Guid(sID)))
                    {
                        wbShow.Checked = true;
                    }
                }


            }
        }
        protected void bntSave_Click(object sender, EventArgs e)
        {
            List<EbSite.Entity.Module.LimitRoleInfo<Guid>> lst = new List<LimitRoleInfo<Guid>>();
            foreach (GridViewRow row in this.gdList.Rows)
            {
                System.Web.UI.WebControls.CheckBox box = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
                if ((box != null) && box.Checked)
                {
                    string sLimitID = this.gdList.DataKeys[row.RowIndex].Value.ToString();
                    LimitRoleInfo<Guid> md = new LimitRoleInfo<Guid>();
                    md.LimitID = new Guid(sLimitID);
                    md.RoleID = GetRoleID;
                    lst.Add(md);
                }
            }

            bllLimitRole.AddList(lst, GetRoleID);
            base.CloseWinBox();
        }
        
    }
}