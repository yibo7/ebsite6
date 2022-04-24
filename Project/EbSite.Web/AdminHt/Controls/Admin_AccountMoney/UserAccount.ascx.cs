using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_AccountMoney
{
    public partial class UserAccount : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "262";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "262";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "262";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "262";
            }
        }

        #endregion
        public override string PageName
        {
            get
            {
                return "会员预付款";
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
            return EbSite.BLL.PayPass.Instance.GetListPages(this.pcPage.PageIndex, pcPage.PageSize, "", "", out iCount);
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

        }

        //public decimal FrozenMoney(int uid)
        //{
        //    decimal num = 0;
        //    List<Entity.AccountMoneyLog> AMLog = EbSite.BLL.AccountMoneyLog.Instance.GetListArray(0, "TradeType=4 and UserId=" + uid, "");
        //    if (AMLog.Count > 0)
        //    {
        //        num = (from i in AMLog select i.Expenses).Sum();
        //    }
        //    return num;
        //}
        protected override void BindToolBar()
        {
            base.BindToolBar(true, true, false, false, false);
        }

       
    }
}