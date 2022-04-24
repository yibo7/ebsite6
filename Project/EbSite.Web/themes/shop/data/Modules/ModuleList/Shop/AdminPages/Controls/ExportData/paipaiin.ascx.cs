using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.ExportData
{
    public partial class paipaiin : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "导入拍拍数据包";
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("4ba6c018-0961-4254-b4f8-d800ba202492");
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
                return 4;
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