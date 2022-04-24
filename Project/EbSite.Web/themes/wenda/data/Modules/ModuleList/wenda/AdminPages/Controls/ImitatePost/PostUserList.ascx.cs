using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.AdminPages.Controls.ImitatePost
{
    public partial class PostUserList : MPUCBaseList
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("59bdd051-909c-407d-92e5-733eb665ed6d");
            }
        }
        public override string PageName
        {
            get
            {
                return "模拟发帖用户";
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
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "32";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "33";
            }
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "34";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return ModuleCore.BLL.PostUserControl.Instance.FillList();

        }
        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }


        override protected void Delete(object iID)
        {
            ModuleCore.BLL.PostUserControl.Instance.Delete(int.Parse(iID.ToString()));
        }
        
       
        
    }
}