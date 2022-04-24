using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Modules.Shop.AdminPages.Controls.ExportData
{
    public partial class paipaiout : ExportBase
    {
        public override string PageName
        {
            get
            {
                return "导出拍拍数据包";
            }
        }


        public override int OrderID
        {
            get
            {
                return 2;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("6f0716e9-1103-4059-af31-f4d21dc249c1");
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}