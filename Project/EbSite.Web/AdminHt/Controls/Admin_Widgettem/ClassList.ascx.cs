using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Ctrtem
{
    public partial class ClassList : UserControlListBase
    {

        public override string Permission
        {
            get
            {
                return "115";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "116";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "218";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "217";
            }
        }
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
            return BLL.Ctrtem.TemClass.FillCtrTemClasss();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<Entity.CtrTemClass> lstRz = new List<Entity.CtrTemClass>();
            List<Entity.CtrTemClass> lst = BLL.Ctrtem.TemClass.FillCtrTemClasss();

            string sKeyTitle = ucToolBar.GetItemVal(txtOne).Trim();

            if (!string.IsNullOrEmpty(sKeyTitle))
            {
                foreach (Entity.CtrTemClass item in lst)
                {
                    if (item.Title.IndexOf(sKeyTitle) > -1)
                    {
                        lstRz.Add(item);
                    }
                }
            }
            else
            {
                lstRz = lst;
            }

            return lstRz;
        }
        override protected void Delete(object iID)
        {
            BLL.Ctrtem.TemClass.DeleteCtrTemClasss(new Guid(iID.ToString()));

        }

        protected bool IsSys(string id)
        {
            return
                !(Equals(id, "19482b0d-7207-4014-9802-ac4f98b8cc0c") ||
                  Equals(id, "22e3f215-0b2c-4f5b-b9dc-2aa08895e969") ||
                  Equals(id, "5f1ae5b4-440f-406f-ad13-54b9ba3378d0") ||
                  Equals(id, "650eeee5-cb1c-42c7-93f0-d90056af380f") ||
                  Equals(id, "e1251549-0410-4cc6-b239-f51914180ded")); 
        }

        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender,e);
            if (Equals(e.CommandName, "showtem"))
            {
                string iupsid = e.CommandArgument.ToString();
                Response.Redirect("Admin_WidgetsTem.aspx?t=2&cid=" + iupsid);

            }
            else if (Equals(e.CommandName, "addtem"))
            {
                string sID = e.CommandArgument.ToString();
                Response.Redirect("Admin_WidgetsTem.aspx?t=3&cid=" + sID);

            }
        }

        protected TextBox txtOne = new TextBox();
        protected Label lblClassName = new Label();
        protected override void BindToolBar()
        {
            base.BindToolBar();

        

            ucToolBar.AddLine();

            lblClassName.ID = "lblClassName";
            ucToolBar.AddCtr(lblClassName);
            lblClassName.Text = "分类名称：";

            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);

            base.ShowCustomSearch("查询");

        }
    }
}