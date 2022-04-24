using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_KuaiDi
{
    public partial class SenderMsg : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "302";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "302";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "302";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "302";
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        override protected string AddUrl
        {
            get
            {
                return "t=2";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return EbSite.BLL.Shippers.Instance.GetListArray("");
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

            BLL.Shippers.Instance.Delete(int.Parse(iID.ToString()));
        }
    }
}