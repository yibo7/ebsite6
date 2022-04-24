using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_AccountMoney
{
    public partial class WithdrawRequest : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "264";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "264";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "264";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "264";
            }
        }

        #endregion

        public override string PageName
        {
            get
            {
                return "会员提现申请";
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
            return EbSite.BLL.WithdrawList.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, "", "", out iCount);
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

        }
        public decimal CountMoney(int uid)
        {
            decimal num = 0;
            List<Entity.PayPass> ls = EbSite.BLL.PayPass.Instance.GetListArray(1, "UserId=" + uid, "");
            if (ls.Count > 0)
            {
                num = ls[0].Balance;
            }
            else
            {
                num = 0;
            }
            return num;
        }
        protected override void BindToolBar()
        {
            base.BindToolBar(true,true,false,false,false);
        }

        #region gdList事件扩展
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "OkModel"))
            {
                int uid =EbSite.Core.Utils.StrToInt( e.CommandArgument.ToString(),0);
                EbSite.BLL.WithdrawList.Instance.BalanceDrawRequest_Update(uid, true);
                //这里要刷新GridView
                base.gdList_Bind();

            }
            else if (Equals(e.CommandName, "NoModel"))
            {
                int uid = EbSite.Core.Utils.StrToInt(e.CommandArgument.ToString(), 0);
                EbSite.BLL.WithdrawList.Instance.BalanceDrawRequest_Update(uid, false);
                base.gdList_Bind();

            }
        }
        #endregion
    }
}