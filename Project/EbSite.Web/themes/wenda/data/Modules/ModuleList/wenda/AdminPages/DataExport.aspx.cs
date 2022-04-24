using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.AdminPages
{
    public partial class DataExport : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("ce89eeaf-020a-4c0e-8124-9e290d956bac");
            }
        }
        public override string PageName
        {
            get
            {
                return "数据导入";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType ==0) //
            {
                base.LoadAControl("DataIndex.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}