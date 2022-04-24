using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages
{
    public partial class StockAlarm : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("10dd48c8-d4f9-46c7-83c1-1c80d0dfe214");
            }
        }
        public override string PageName
        {
            get
            {
                return "库存";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("Add.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}