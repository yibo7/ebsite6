using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.CQ.ModuleCore.BLL;

namespace EbSite.Modules.CQ.AdminPages.Controls.UserOnline
{
    public partial class List : MPUCBaseList
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("b4cd6904-3576-451c-a79b-5917b4d32f0f");
            }
        }
        public override string PageName
        {
            get
            {
                return "在线用户";
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
                return 1;
            }
        }
        public override string Permission
        {
            get
            {
                return "20";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "20";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "20";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "20";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=2";
            }
        }

        protected string GetItemURL
        {
            get
            {
                return string.Concat(GetUrl, "&t=1");
            }
        }
        protected string GetServiceName(object sid)
        {
            return ModuleCore.BLL.Service.Instance.GetEntity(int.Parse(sid.ToString())).ServiceName;
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return ChatBll.Customers;
            //iCount = BLL.User.UserOnline.GetCountAllUser(); 
            //return EbSite.BLL.User.UserOnline.GetAllUser(pcPage.PageIndex, iPageSize, ""); 
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            //ModuleCore.BLL.Barcode.Instance.DeleteQR(new Guid(iID.ToString()));
        }
    }
}