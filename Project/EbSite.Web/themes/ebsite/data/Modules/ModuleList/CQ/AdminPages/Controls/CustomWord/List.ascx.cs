using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages.Controls.CustomWord
{
    public partial class List : MPUCBaseList
    {
        protected override Guid MenuAddID
        {
            get
            {
                return new Guid("41388e6b-f5df-4520-8a61-58f85978462c");
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("3894ce07-2d82-4dce-a4c0-34e794e48a5f");
            }
        }
        public override string PageName
        {
            get
            {
                return "常用语句";
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
                return 1;
            }
        }
        public override string Permission
        {
            get
            {
                return "9";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "10";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "10";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "10";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=2";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;

            List<ModuleCore.Entity.CustomWord> ls = ModuleCore.BLL.CustomWord.Instance.FillList();
            // List<ModuleCore.Entity.CustomWord> nls = (from i in ls where i.UserId == base.UserID select i).ToList();
            return ls;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.CustomWord.Instance.Delete(int.Parse(iID.ToString()));
        }
        #region 工具栏的初始化
        override protected void BindToolBar()
        {

            base.BindToolBar();
            ucToolBar.AddLine();

            ucToolBar.AddBnt("生成常用语句", string.Concat(IISPath, "images/Menus/ie.png"), "makehtml");



        }
        #endregion

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "makehtml":
                    ModuleCore.BLL.CustomWord.Instance.MarkHtml();
                    base.TipsAlert("生成成功！");
                    break;

            }
        }
    }
}