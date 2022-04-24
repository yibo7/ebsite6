using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages.Controls.Options
{
    public partial class CustomItems : MPUCBaseList
    {
        protected override Guid MenuAddID
        {
            get
            {
                return new Guid("af348cbd-fe9e-4e69-9680-cf3f713c8cc1");
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("6170bfaf-f4d4-4163-bed1-ed1744292def");
            }
        }
        public override string PageName
        {
            get
            {
                return "自定义选项";
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
                return 13;
            }
        }
        public override string Permission
        {
            get
            {
                return "15";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "16";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "16";
            }
        }
      
        public override string PermissionDelID
        {
            get
            {
                return "16";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=7";
            }
        }

        private int iParentID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["pid"]))
                {
                    return int.Parse(Request["pid"]);
                }
                return 0;
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;

            return ModuleCore.BLL.CustomItems.Instance.GetListByParentID(iParentID);
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.CustomItems.Instance.Delete(int.Parse(iID.ToString()));
        }
        override protected void CopyData(object iID)
        {
            ModuleCore.BLL.CustomItems.Instance.CopyData(int.Parse(iID.ToString()));

        }
        
    }
}