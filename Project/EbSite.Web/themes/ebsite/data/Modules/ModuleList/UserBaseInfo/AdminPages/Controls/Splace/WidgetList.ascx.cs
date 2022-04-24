using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using EbSite.Entity;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class WidgetList : MPUCBaseList
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("f677da10-127b-4d2c-8857-5688fdf3d086");
            }
        }
        public override string PageName
        {
            get
            {
                return "空间部件";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        public override int OrderID
        {
            get
            {
                return 3;
            }
        }
        public override string Permission
        {
            get
            {
                return "7";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "8";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "8";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "8";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=6";
            }
        }
        //override protected string ShowUrl
        //{
        //    get
        //    {
        //        return "?&t=1&mid=" + ModuleID;
        //    }
        //}

        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return BLL.HomeWidget.Instance.FillList();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<Entity.HomeWidgetInfo> ls = BLL.HomeWidget.Instance.FillList();
            List<Entity.HomeWidgetInfo> nls = new List<HomeWidgetInfo>();
            string tkey = ucToolBar.GetItemVal(txtKeyWord);

            nls = (from li in ls
                   where ("" == tkey || (li.WidgetName == tkey)) &&
                         (li.ThemeClassID ==
                          int.Parse(ucToolBar.GetItemVal(ThemeClassID)))
                   select li).ToList();

            return nls;

        }
        override protected void Delete(object iID)
        {
            BLL.HomeWidget.Instance.Delete(new Guid(iID.ToString()));
        }

        private void BindBankId()
        {
            ThemeClassID.DataTextField = "classname";
            ThemeClassID.DataValueField = "id";
            ThemeClassID.DataSource = EbSite.BLL.SpaceThemeClass.Instance.GetListArray("");
            ThemeClassID.DataBind();
        }

        #region 工具栏的初始化
        protected System.Web.UI.WebControls.Label LbKey = new Label();
        protected System.Web.UI.WebControls.TextBox txtKeyWord = new System.Web.UI.WebControls.TextBox();
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.DropDownList ThemeClassID = new DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar();
            ucToolBar.AddLine();

            LbKey.ID = "LbKey";
            LbKey.Text = "部件名称";
            ucToolBar.AddCtr(LbKey);
            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);
            LbName.ID = "LbName";
            LbName.Text = "皮肤分类";
            ucToolBar.AddCtr(LbName);
            ThemeClassID.ID = "ThemeClassID";
            BindBankId();
            ucToolBar.AddCtr(ThemeClassID);
            base.ShowCustomSearch("查询");

            //ucToolBar.AddBnt("高级", "images/MenuImg/Search-Add.gif", "", false, "OpenDialog_Save('divSearh',OnSearch)");



        }
        #endregion

        #region 工具栏事件扩展

        //protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        //{
        //    base.ucToolBar_ItemClick(source, e);
        //    switch (e.ItemTag)
        //    {
        //        case "good":
        //            break;
        //    }
        //}

        #endregion
    }
}