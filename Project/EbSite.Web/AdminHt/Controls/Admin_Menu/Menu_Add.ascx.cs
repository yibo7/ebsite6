using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Menu
{
    public partial class Menu_Add : UserControlBaseSave
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
            if(!string.IsNullOrEmpty(SID))
            {
                Entity.Menus menu = BLL.Menus.Instance.GetEntity(new Guid(SID));
                txtMenuName.Text = menu.MenuName;
                drpImg.SelectedValue = menu.ImageUrl;
                txtTarget.Text = menu.Target;
                txtUrl.Text = menu.PageUrl;
                string sParentID = menu.ParentID.ToString();
                if (!string.IsNullOrEmpty(sParentID))
                    drpPatentID.SelectedValue = sParentID;

                txtPermissionID.Text = menu.PermissionID.ToString();
                txtCtrPath.Text = menu.CtrPath;
            }

           
        }

        override protected void SaveModel()
        {
            Entity.Menus menu;
            Guid ParentID = Guid.Empty;
            if (!string.IsNullOrEmpty(drpPatentID.SelectedValue))
                ParentID = new Guid(drpPatentID.SelectedValue);

            Guid CurrentID = Guid.Empty;
            if(!string.IsNullOrEmpty(SID))
                CurrentID = new Guid(SID);
            if (CurrentID != Guid.Empty) //这样修改一条数据
            {
                menu = BLL.Menus.Instance.GetEntity(CurrentID);

                BLL.Menus.Instance.Update(IniCurrentMenu(menu, ParentID));
            }
            else //这样添加一条新数据
            {
                menu = new Menus();

                BLL.Menus.Instance.Add(IniCurrentMenu(menu, ParentID));
            }
        }
        /// <summary>
        /// 构造当前菜单实体
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        private Entity.Menus IniCurrentMenu(Entity.Menus menu, Guid ParentID)
        {
            menu.Target = txtTarget.Text;


            menu.ParentID = ParentID;
            menu.MenuName = txtMenuName.Text;
            menu.CtrPath = txtCtrPath.Text;

            menu.PermissionID = txtPermissionID.Text;

            menu.PageUrl = txtUrl.Text;
            menu.ImageUrl = drpImg.SelectedValue;
            menu.AddTime = DateTime.Now;
            

            return menu;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                binddata();
                BindImages();
                //BindModifyData();
            }
        }
        /// <summary>
        /// 绑定父菜单
        /// </summary>
        private void binddata()
        {
            drpPatentID.DataTextField = "MenuName";
            drpPatentID.DataValueField = "Id";
            drpPatentID.DataSource = BLL.Menus.Instance.GetTree(0);
            drpPatentID.DataBind();

        }
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