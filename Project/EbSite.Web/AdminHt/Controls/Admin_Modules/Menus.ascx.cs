using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Control;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace EbSite.Web.AdminHt.Controls.Admin_Modules
{
    public partial class Menus : BaseList
    {
        public override string Permission
        {
            get
            {
                return "237";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "?";
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
             
            //ucPageTags.Title = "菜单设置";
            //List<TagsItemInfo> list = new List<TagsItemInfo>();
            //TagsItemInfo li = new TagsItemInfo();
            //li.sText = "管理员菜单";
            //li.TagOrtherUrl = "?t=1";
            //li.TagUrl = string.Format("{1}{2}Admin_Modules.aspx?t=1&mid={0}", GetModuleID, IISPath, Base.Configs.SysConfigs.ConfigsControl.Instance.AdminPath);
            //list.Add(li);

            //li = new TagsItemInfo();
            //li.sText = "用户后台菜单";
            //li.TagOrtherUrl = "?t=22";
            //li.TagUrl = string.Format("{1}{2}Admin_Modules.aspx?t=22&mid={0}", GetModuleID, IISPath, Base.Configs.SysConfigs.ConfigsControl.Instance.AdminPath);
            //list.Add(li);

            //ucPageTags.Taglist = list;

            //if (!IsPostBack)
            //{


            //}

        }
        override protected object LoadList(out int iCount)
        {
          
            iCount = 0;
            return MenuBll.GetTree_pic();
            
        }
        
        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            string key = ucToolBar.GetItemVal(PageName).Trim();
            List<Entity.Module.ModulePageInfo> lsit = MenuBll.GetTree_pic();
            
            return lsit;
        }
        override protected void Delete(object iID)
        {
            //BLL.SystemLog.Instance.Delete(long.Parse(iID.ToString()));

        }
        //移出主菜单
        protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RemoveModel")
            {
                int saveID = 0;
                string id = e.CommandArgument.ToString();
                BLL.Menus.Instance.Delete(new Guid(id));
                //加一个提示
            }
        }

        #region  工具条的初使化
        protected System.Web.UI.WebControls.Label lb = new Label();
        protected System.Web.UI.WebControls.TextBox PageName = new TextBox();
      
        protected override void BindToolBar()
        {
            base.BindToolBar(true, true, true, true,false);
            lb.ID = "lb";
            lb.Text = "菜单名称";
            ucToolBar.AddCtr(lb);
            PageName.ID = "PageName";
            PageName.Attributes.Add("style", "width:120px");
            ucToolBar.AddCtr(PageName);

            base.ShowCustomSearch("查询");
            //ucToolBar.AddBnt("重新生成菜单", IISPath+ "images/menus/menuMake.png", "MakeMenu", true, "return confirm('是否重新生成菜单?');","如果开发的过程中有新加页面，需要重重新生成菜单");
            
          
        }
        #endregion

        #region 　工具条扩展事件
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "MakeMenu":
                    //MenuBll.ReMakeMenus(this.Page, GetModuleID);

                    Core.Strings.cJavascripts.RunClientJs(this.Page, "RefeshParent1();");
                     
                    break;
                //case "ResetMenu":
                //    //MenuBll.ResetMenu(Model.id);
                //    break;
              
                
            }
        }
        #endregion
    }
}