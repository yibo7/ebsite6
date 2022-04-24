using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_KuaiDi
{
    /// <summary>
    /// 快递单打印模板
    /// </summary>
    public partial class PrinterManage : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "301";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "301";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "301";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "301";
            }
        }

        #endregion

        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return EbSite.BLL.Express.Instance.FillList();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

            BLL.Express.Instance.Delete(int.Parse(iID.ToString()));
        }

    }
}