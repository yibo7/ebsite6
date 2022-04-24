using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages
{
    /// <summary>
    /// 供应商
    /// </summary>
    public partial class Supplier : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("2f68985a-d70b-4eb4-8e61-974f6532f8ee");
            }
        }
        public override string PageName
        {
            get
            {
                return "供应商";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("SuppliersEdit.ascx");
            }
            else if (PageType == 1) //显示
            {
                base.LoadAControl("SuppliersShow.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}