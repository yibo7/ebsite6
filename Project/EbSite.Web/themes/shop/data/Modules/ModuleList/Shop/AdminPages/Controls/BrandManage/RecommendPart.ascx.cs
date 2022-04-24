using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.BrandManage
{
    public partial class RecommendPart : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "推荐配件";
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
                return new Guid("f85678b7-6350-447d-a4b7-3e941d8bf612");
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