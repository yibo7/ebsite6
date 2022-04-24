using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Control;

namespace EbSite.Web.AdminHt.Controls.Admin_AccountMoney
{
    public partial class RequestedLog : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "265";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "265";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "265";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "265";
            }
        }

        #endregion

        public override string PageName
        {
            get
            {
                return "会员账户明细";
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
            string sWhere = "";
            if (UserId > 0)
            {
                sWhere = " userid=" + UserId; 
            }
            return EbSite.BLL.AccountMoneyLog.Instance.GetListPages(this.pcPage.PageIndex, this.pcPage.PageSize, sWhere, "", out iCount);
        }
        /// <summary>
        /// 用户id 从外界传 用来查询
        /// </summary>
        private int UserId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
                {
                    return Convert.ToInt32(Request.QueryString["uid"]);
                }
                return 0;
            }
        }

        protected string SqlWhere = "";
        override protected object SearchList(out int iCount)
        {
            SqlWhere = EbSite.BLL.AccountMoneyLog.Instance.StrWhere(ucToolBar.GetItemVal(DateBegin), ucToolBar.GetItemVal(DateEnd),
                                                                    ucToolBar.GetItemVal(sendType), UserId);
            return EbSite.BLL.AccountMoneyLog.Instance.GetListPages(this.pcPage.PageIndex, this.pcPage.PageSize,
                                                                    base.GetWhere(true), "", out iCount);
        }
        override protected void Delete(object iID)
        {

        }

        protected override string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            return SqlWhere;
        }
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected EbSite.Control.DatePicker DateBegin = new DatePicker();
        protected EbSite.Control.DatePicker DateEnd = new DatePicker();

        protected System.Web.UI.WebControls.Label LbPS = new Label();
        protected System.Web.UI.WebControls.DropDownList sendType = new System.Web.UI.WebControls.DropDownList();
        protected override void BindToolBar()
        {
            base.BindToolBar(true,true,false,false,false);
            LbName.ID = "LbName";
            LbName.Text = "选择时间段";
            ucToolBar.AddCtr(LbName);
            DateBegin.ID = "DateBegin";
            DateBegin.Attributes.Add("style", "width:90px");
            ucToolBar.AddCtr(DateBegin);

            DateEnd.ID = "DateEnd";
            DateEnd.Attributes.Add("style", "width:90px");
            ucToolBar.AddCtr(DateEnd);


            LbPS.ID = "LbPS";
            LbPS.Text = "类型";
            sendType.ID = "ddlSendType";
            sendType.Width = 80;
            BindDrop();

            ucToolBar.AddCtr(LbPS);
            ucToolBar.AddCtr(sendType);

            base.ShowCustomSearch("查询");
        }
        protected void BindDrop()
        {
            sendType.DataSource = EbSite.BLL.AccountMoneyType.GetAccountMoneyTypes();
            sendType.DataTextField = "Text";
            sendType.DataValueField = "ID";
            sendType.DataBind();

        }
    }
}