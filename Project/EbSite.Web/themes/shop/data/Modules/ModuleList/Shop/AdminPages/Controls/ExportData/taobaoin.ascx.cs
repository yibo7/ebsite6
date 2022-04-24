using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.ExportData
{
    public partial class taobaoin : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "导入淘宝数据包";
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
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("f305c674-5d7f-43fc-8e45-e450fa481e2c");
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
                return "63";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }


        override protected void InitModifyCtr()
        {

        }
        override protected void SaveModel()
        {
        }
    }
}