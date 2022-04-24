using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Modules.Shop.AdminPages.Controls.ExportData
{
    public partial class taobaoout : ExportBase
    {
        public override string PageName
        {
            get
            {
                return "导出淘宝数据包";
            }
        }


        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("618d91c2-53ef-47f1-8ddb-40ba783a4048");
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {

          
 
     
 

        //Configs.Instance.Model.IsSaveShopCar = SettingInfo.Instance.IsSaveShopCar;
         

        //    Configs.Instance.Save();
        }
    }
}