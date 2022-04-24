using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages.Controls.MsgHistorys
{
    public partial class ComplainList : MPUCBaseList
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("0bd1183b-8a0a-4e5c-b6ae-115e96243089");
            }
        }
        public override string PageName
        {
            get
            {
                return "客户投诉与建议";
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
                return "6";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "6";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "6";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "6";
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
            iCount = 0;

            return ModuleCore.BLL.Complaincs.Instance.FillList();
          
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.OrderBox.Instance.Delete(int.Parse(iID.ToString()));
        }
        override protected void CopyData(object iID)
        {
            ModuleCore.BLL.OrderBox.Instance.CopyData(int.Parse(iID.ToString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}