using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.BrandManage
{
    public partial class BestGroup : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "最佳组合";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("007ec759-79e7-4234-a23e-5eba8e7d764c");
            }
        }
      
        override protected object LoadList(out int iCount)
        {
             iCount = 0;
            return null;
        }

        override protected object SearchList(out int iCount)
        {
           
                iCount = 0;
                return null;
            
        }

        override protected void Delete(object iID)
        {
            
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string GetTitle
        {
            get { return Request["title"]; }
        }
    }
}