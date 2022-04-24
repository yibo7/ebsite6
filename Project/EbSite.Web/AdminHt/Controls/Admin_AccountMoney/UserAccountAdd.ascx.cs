using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_AccountMoney
{
    public partial class UserAccountAdd : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "262";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        protected void BindDrop()
        {
            dropDB.DataSource = EbSite.BLL.AccountMoneyType.GetAccountMoneyTypesHt();
            dropDB.DataTextField = "Text";
            dropDB.DataValueField = "ID";
            dropDB.DataBind();

        }
        /// <summary>
        /// 可用余额
        /// </summary>
        public string UserMoney
        {
            get
            {
                string imoney = Request.QueryString["um"];
                return imoney;
            }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get
            {
                string uname = "";

                if (Uid > 0)
                {
                    uname = EbSite.Base.Host.Instance.GetUserUserName(Uid);
                }
                return uname;
            }
        }

        protected int Uid
        {
            get
            {
                int iUID = 0;
                if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
                {
                    iUID = Convert.ToInt32(Request.QueryString["uid"]);
                }
                return iUID;
            }
        }
        override protected void InitModifyCtr()
        {
        }
        override protected void SaveModel()
        {
            EbSite.Entity.PayPass md = EbSite.BLL.PayPass.Instance.GetEntity(Uid);
            if (!Equals(md, null))
            {
                md.Balance += Convert.ToDecimal(txtAddMoney.Text);
                EbSite.BLL.PayPass.Instance.Update(md);

                //增加一条日志
                EbSite.Entity.AccountMoneyLog moneyLog = new AccountMoneyLog();
                moneyLog.UserId = Uid;
                moneyLog.Remark = Demo.Text;
                moneyLog.UserName = UserName;
                moneyLog.TradeDate = DateTime.Now;
                moneyLog.TradeType = Convert.ToInt32(dropDB.SelectedValue);
                moneyLog.Income = Convert.ToDecimal(txtAddMoney.Text);
                moneyLog.Expenses = 0;
                moneyLog.Balance = md.Balance;
                int iKey = EbSite.BLL.AccountMoneyLog.Instance.Add(moneyLog);

                if (iKey > 0)
                {
                    base.TipsAlert("加款成功");
                }


            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDrop();
                this.lbUName.Text = UserName;
                this.lbUserMoney.Text = UserMoney;
            }
        }

    }
}