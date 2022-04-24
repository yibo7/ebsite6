using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Payment
{
    public partial class Payment : UserControlListBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 权限

        public override string Permission
        {
            get
            {
                return "160";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "159";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "230";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "229";
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
            return BLL.Payment.Instance.GetListArray(0, "OrderNumber");
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

            BLL.Payment.Instance.Delete(int.Parse(iID.ToString()));
        }
    }
}