using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.BLL.ModelBll;

namespace EbSite.Modules.CQ.AdminPages.Controls.Orders
{
    public partial class  OrderList : MPUCBaseList
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("cb80339b-3fe0-4f0d-81b0-fc1f431a465f");
            }
        }
        public override string PageName
        {
            get
            {
                return "订单列表";
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
                return 7;
            }
        }
        public override string Permission
        {
            get
            {
                return "8";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "8";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "8";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "8";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }

        override protected object LoadList(out int iCount)
        {
            if (!string.IsNullOrEmpty(Request["delid"]))
            {
                int id = Convert.ToInt32(Request["delid"]);
                ModuleCore.BLL.CustomOrder.Instance.DeleteStep(id);
            }
            return ModuleCore.BLL.CustomOrder.Instance.GetDataTable(this.gdList, pcPage.PageIndex, iPageSize, out iCount);
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
           
        }
        /// <summary>
        /// 获取表单模型ID
        /// </summary>
        private Guid ModelID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["mid"]))
                {
                    return new Guid(Request["mid"]);
                }
                return Guid.Empty;
            }
        }
        /// <summary>
        /// 获取模块ID
        /// </summary>
        private Guid ModuleID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["muid"]))
                {
                    return new Guid(Request["muid"]);
                }
                return Guid.Empty;
            }
        }
        protected string GetDelUrl(object id)
        {
            return string.Format("?delid={0}&muid={2}&mid={1}", id, ModelID,  ModuleID);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
    }
}