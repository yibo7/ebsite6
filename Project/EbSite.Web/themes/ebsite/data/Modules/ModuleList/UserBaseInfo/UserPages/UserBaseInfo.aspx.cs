using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages
{
    public partial class UserBaseInfo : MPageForUer
    {
        override public int OrderID
        {
            get
            {
                return 1;
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("bf371bdd-f674-4077-a9ed-e2896fb4c857");
            }
        }
    
        public override string PageName
        {
            get
            {
                return "基本资料管理";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override bool IsHideMenus
        {
            get
            {
                return true;
            }
        }

        protected override void AddControl()
        {
            if (PageType == 0) //
            {
                base.LoadAControl("Links_Add.ascx");

            }
            else if (PageType == 1) //
            {
                base.LoadAControl("Links_Show.ascx");
            }
            else if (PageType == 2) // 辅助一些删除等操作
            {
                base.LoadAControl("Links_ListRp.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}