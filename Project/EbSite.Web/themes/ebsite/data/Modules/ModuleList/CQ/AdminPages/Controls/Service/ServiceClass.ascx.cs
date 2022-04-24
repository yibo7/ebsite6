using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages.Controls.Service
{
    public partial class ServiceClass : MPUCBaseList
    {
        protected override Guid MenuAddID
        {
            get
            {
                return new Guid("821e4073-9dfd-41df-9b53-358cae866a81");
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("cda6a96f-2903-4d3b-a402-133ef73d5220");
            }
        }
        public override string PageName
        {
            get
            {
                return "客服类别";
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
                return 11;
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
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
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
                return "t=3";
            }
        }


        override protected object LoadList(out int iCount)
        {
            iCount = 0;

            return ModuleCore.BLL.ServiceClass.Instance.FillList();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.ServiceClass.Instance.Delete(int.Parse(iID.ToString()));
        }
        override protected void CopyData(object iID)
        {
            ModuleCore.BLL.ServiceClass.Instance.CopyData(int.Parse(iID.ToString()));

        }
        
    }
}