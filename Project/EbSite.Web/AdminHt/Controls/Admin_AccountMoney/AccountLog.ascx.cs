using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_AccountMoney
{
    public partial class AccountLog : UserControlListBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 权限

        public override string Permission
        {
            get
            {
                return "263";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "263";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "263";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "263";
            }
        }

        #endregion
        /// <summary>
        /// 对应 预付款充值
        /// </summary>
        public override string PageName
        {
            get
            {
                return "预付款进出";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {
            return EbSite.BLL.PayLog.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
           
        }
        protected override void BindToolBar()
        {
            base.BindToolBar(true,true,true,false,false);
        }
    }
}