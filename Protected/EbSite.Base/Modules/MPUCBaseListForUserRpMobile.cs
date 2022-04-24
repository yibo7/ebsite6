using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Control;

namespace EbSite.Base.Modules
{
    public abstract class MPUCBaseListForUserRpMobile : MPUCBaseListForUserRpBase
    {
        protected ToolBarMobile ucToolBar;
        public MPUCBaseListForUserRpMobile()
        {
            base.Load += new EventHandler(this.BasePage_Load);
        }

        private void BasePage_Load(object sender, EventArgs e)
        {
           
            if (!object.Equals(this.ucToolBar, null))
            {
                this.ucToolBar.ItemClick += new EventToolBarItemClick(this.ucToolBar_ItemClick);
                this.BindToolBar();
            }
        }

        protected string SearchKey
        {
            get { return Request["mkey"]; }
        }
        protected override void BindToolBar(bool IsCloseAdd, bool IsCloseDel)
        {
            ucToolBar.AddBnt("搜索", "/images/search.png", "search", false, "onopenmdsearch()", "");
            ucToolBar.AddBnt("选择", "/images/check.png", "sel", false, "onselmdcheckbox()", "");
            ucToolBar.AddBnt("添加", "/images/add.png", "add", false, string.Format("onmdadd('{0}')", AddUrl), "");
            ucToolBar.AddBnt("编辑", "/images/edit.png", "edit", false, string.Format("onmdedit('{0}&id=')", AddUrl), "");
            ucToolBar.AddBnt("删除", "/images/delete.png", "del", true, "return onmddelete()", "");

            //ToolBarItem lb = new ToolBarItem();
            //if (!IsCloseAdd)
            //{
            //    this.ucToolBar.AddDialog(this.AddUrlBox, "添加", base.IISPath + "images/menus/add.gif", 800, 500, true, false);

            //}
            //if (!IsCloseDel)
            //{
            //    lb = new ToolBarItem();
            //    lb.Text = "删除";
            //    lb.OnClientClick = "return confirm('确认要删除所选项吗？');";
            //    lb.Img = string.Concat(IISPath, "images/menus/Delete.gif");
            //    lb.EventTag = "del";
            //    ucToolBar.Items.Add(lb);

            //}
            


        }

        protected override void CheckCurrentUserIsLogin()
        {
            if (!CurrentUserIsLogin)
            {
                EbSite.Base.AppStartInit.MUserLoginReurl();
            }
        }
    }
}

