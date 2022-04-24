using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Menu
{
    public partial class FastMenu_Add : UserControlBaseSave
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
                Entity.FastMenu menu = BLL.FastMenu.Instance.GetEntity(int.Parse(SID));
                txtMenuName.Text = menu.Title;
                drpImg.SelectedValue = menu.ImageUrl; 
                txtUrl.Text = menu.Url;
                
            }

           
        }

        override protected void SaveModel()
        {
            //Entity.Menus menu;
           

            //Guid CurrentID = Guid.Empty;
            //if(!string.IsNullOrEmpty(SID))
            //    CurrentID = new Guid(SID);
            //if (CurrentID != Guid.Empty) //这样修改一条数据
            //{
            //    menu = BLL.Menus.Instance.GetEntity(CurrentID);

            //    BLL.Menus.Instance.Update(IniCurrentMenu(menu, ParentID));
            //}
            //else //这样添加一条新数据
            //{
            //    menu = new Menus();

            //    BLL.Menus.Instance.Add(IniCurrentMenu(menu, ParentID));
            //}
        }
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               
                BindImages();
                
            }
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