using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Menu
{
    public partial class Menu_List : UserControlListBase
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
                return "159";
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
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return BLL.Menus.Instance.GetTree_pic(0);
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<Menus> lsit = BLL.Menus.Instance.GetTree_pic(0);
            List<Menus> ls = new List<Menus>();
            foreach (Menus menuse in lsit)
            {
                if(menuse.MenuName.IndexOf(ucToolBar.GetItemVal(txtOne).Trim())!=-1)
                {
                    ls.Add(menuse);
                }
            }
               
            return ls;
        }
        override protected void Delete(object iID)
        {
            Guid id = new Guid(iID.ToString());
            BLL.Menus.Instance.Delete(id);

        }
        protected Label label = new Label(); protected Control.TextBox txtOne = new Control.TextBox();
        protected override void BindToolBar()
        {
            base.BindToolBar();

            label.ID = "lblOne";
            label.Text = " 菜单名称 ";
            ucToolBar.AddCtr(label);

            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);
            base.ShowCustomSearch("查询");

            ucToolBar.AddBnt(Resources.lang.EBRearSortId, string.Concat(IISPath, "images/Menus/20110509091336657_easyicon_cn_16.png"), "resetorderid", true, "return confirm('这将重新设置菜单的排序ID，确认要这样做吗？');", "重新设置排序ID");

            //ucToolBar.AddBnt(Resources.lang.Menu785b8c38, string.Concat(IISPath, "images/Menus/arrow-resize-090.png"), "movemenu");

            ucToolBar.AddDialog("?t=2", Resources.lang.Menu785b8c38, string.Concat(IISPath, "images/Menus/arrow-resize-090.png"),"", "确认移动菜单");

        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "resetorderid":
                    BLL.Menus.Instance.ResetOrderID_Start();
                    break;
                //case "movemenu":
                //    Response.Redirect("Admin_Menu.aspx?t=2");
                //    break;
            }
        }
        

    }
}