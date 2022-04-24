using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages
{
    public partial class HomeSet : MPageForUer
    {
        override public int OrderID
        {
            get
            {
                return 3;
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("fd7ba88c-ee87-4865-8ff5-6f9c871a9cbb");
            }
        }
        public override string PageName
        {
            get
            {
                return "站点管理";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void AddControl()
        {
            if (PageType == 0) //
            {
                base.LoadAControl("Links_Add.ascx");

            }
            //else if (PageType == 1) //
            //{
            //    base.LoadAControl("Links_Show.ascx");
            //}
            //else if (PageType == 2) // 辅助一些删除等操作
            //{
            //    base.LoadAControl("Links_ListRp.ascx");
            //}
            else
            {
                base.AddControl();
            }
        }
    }
}