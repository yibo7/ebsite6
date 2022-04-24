using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Configs.ContentSet;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Menu
{
    public partial class UserMenu_List : UserControlListBase
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
        protected string GetThemeType(object themetype)
        {
            ThemeType type = (ThemeType)themetype;
            if (type == ThemeType.PC)
            {
                return "<font color='#005AA5'>PC版</font>";
            }
            else
            {
                return "<font color='#4EAF04'>移动版</font>";
            }
            
        }
        override protected string AddUrl
        {
            get
            {
                return "t=3";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return BLL.MenusForUser.Instance.GetListArray("");
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<MenusForUser> lsit = BLL.MenusForUser.Instance.GetTree_pic(0);
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
            Guid id = new Guid(iID.ToString());
            BLL.MenusForUser.Instance.Delete(id);

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

            ucToolBar.AddDialog("?t=4", Resources.lang.Menu785b8c38, string.Concat(IISPath, "images/Menus/arrow-resize-090.png"), "", "确认移动菜单");

            ucToolBar.AddBnt("显示权限", string.Concat(IISPath, "images/Menus/20110509103255173_easyicon_cn_16.png"),"setpermison");

            //ucToolBar.AddDialog("?t=5", "显示权限", string.Concat(IISPath, "images/Menus/20110509103255173_easyicon_cn_16.png"),"这只是用来设置在哪个用户组下显示在用户控制面板功能导航菜单,真正的访问权限设置要到相应的模块里设置!","确认移动菜单");

        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "resetorderid":
                    BLL.MenusForUser.Instance.ResetOrderID_Start();
                    break;
                case "setpermison":
                    Response.Redirect(string.Concat(GetUrl, "&t=5"));
                    break;
            }
        }

        //protected virtual void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    base.gdList_RowCommand(sender,e);
        //    if (object.Equals(e.CommandName, "SetToUcc"))
        //    {
        //        string iD = e.CommandArgument.ToString();

        //        EbSite.Entity.MenusForUser md = BLL.MenusForUser.Instance.GetEntity(new Guid(iD));

        //        ConfigsControl.Instance.UccIndex = md.Url;
        //        ConfigsControl.SaveConfig();
               
        //    }
        //}
        
    }
}