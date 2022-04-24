using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Menu
{
    public partial class UserMenu_Add : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "159";
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
            if (!string.IsNullOrEmpty(SID))
            {
                Entity.MenusForUser menu = BLL.MenusForUser.Instance.GetEntity(new Guid(SID));
                txtMenuName.Text = menu.MenuName;
                if (!string.IsNullOrEmpty(menu.ImageUrl))
                    drpImg.SelectedValue = menu.ImageUrl;
                txtTarget.Text = menu.Target;
                txtUrl.Text = menu.PageUrl;

                //if (menu.ParentID != Guid.Empty)
                //    drpPatentID.SelectedValue = menu.ParentID.ToString();

                txtCtrPath.Text = menu.ModuleMenuID.ToString();
            }


        }

        override protected void SaveModel()
        {
            Entity.MenusForUser menu;
            Guid ParentID = Guid.Empty;
            //if (!string.IsNullOrEmpty(drpPatentID.SelectedValue))
            //    ParentID = new Guid(drpPatentID.SelectedValue);

            Guid CurrentID = Guid.Empty;
            if (!string.IsNullOrEmpty(SID))
                CurrentID = new Guid(SID);
            if (CurrentID != Guid.Empty) //这样修改一条数据
            {
                menu = BLL.MenusForUser.Instance.GetEntity(CurrentID);

                BLL.MenusForUser.Instance.Update(IniCurrentMenu(menu, ParentID));
            }
            else //这样添加一条新数据
            {
                menu = new MenusForUser();

                BLL.MenusForUser.Instance.Add(IniCurrentMenu(menu, ParentID));
            }
        }
        /// <summary>
        /// 构造当前菜单实体
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        private Entity.MenusForUser IniCurrentMenu(Entity.MenusForUser menu, Guid ParentID)
        {
            menu.Target = txtTarget.Text.Trim();


            menu.ParentID = ParentID;
            menu.MenuName = txtMenuName.Text;
            menu.ModuleMenuID = new Guid(txtCtrPath.Text);

            //menu.PermissionID = txtPermissionID.Text;

            menu.PageUrl = txtUrl.Text;
            menu.ImageUrl = drpImg.SelectedValue;
            menu.AddTime = DateTime.Now;


            return menu;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //binddata();
                BindImages();
                //BindModifyData();
            }
        }
        ///// <summary>
        ///// 绑定父菜单
        ///// </summary>
        //private void binddata()
        //{
        //    drpPatentID.DataTextField = "MenuName";
        //    drpPatentID.DataValueField = "Id";
        //    drpPatentID.DataSource = BLL.MenusForUser.Instance.GetTree(0);
        //    drpPatentID.DataBind();

        //}
        /// <summary>
        /// 绑定菜单图标列表
        /// </summary>
        private void BindImages()
        {

            string[] st = { "gif", "jpg", "png" };
            List<FileInfo> lst = Core.FSO.FObject.GetFileListByTypes("~/images/Menus", st);
            foreach (FileInfo fileInfo in lst)
            {
                ListItem item = new ListItem(fileInfo.Name, Base.AppStartInit.IISPath + "images/Menus/" + fileInfo.Name);
                this.drpImg.Items.Add(item);
            }

            ListItem itemDefault = new ListItem("默认图标", Base.AppStartInit.IISPath + "images/Menus/folder16.gif");

            this.drpImg.Items.Insert(0, itemDefault);
            this.drpImg.DataBind();
        }
    }
}