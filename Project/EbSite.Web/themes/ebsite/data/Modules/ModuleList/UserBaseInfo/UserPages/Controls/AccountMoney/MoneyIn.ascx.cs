using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.BLL;
using PayLog = EbSite.Entity.PayLog;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.AccountMoney
{
    public partial class MoneyIn : MPUCBaseListForUserRp
    {
        //public override bool IsCloseTagsTitle
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!EbSite.Base.Host.Instance.IsOpenBalance(base.UserID))
                {
                    //没有开启 预付款功能
                    Response.Redirect(EbSite.Base.Host.Instance.GetOpenBalance);

                }
                else
                {
                    tdPayType1.Visible = false;

                    rbList.DataTextField = "PaymentName";
                    rbList.DataValueField = "id";
                    rbList.DataSource = BLL.Payment.Instance.GetListArrayYF();
                    rbList.DataBind();
                    rbList.SelectedIndex = 0;


                   // List<Entity.PayPass> ls = EbSite.BLL.PayPass.Instance.GetListArray(1, "UserId=" + base.UserID, "");
                    Entity.PayPass payModel = BLL.PayPass.Instance.GetEntity(base.UserID);
                    if (!Equals(payModel,null))
                    {
                        CountMoney = payModel.Balance;
                    }
                    else
                    {
                        CountMoney = 0;
                    }
                }

            }
        }
        public override int OrderID
        {
            get
            {
                return 2;
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("c79a50b4-d5d0-4dfc-a4be-03c571b90830");
            }
        }
        public override string PageName
        {
            get
            {
                return "预付款充值";
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
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "7";
            }
        }

        /// <summary>
        /// 请注意box与t的意义
        /// </summary>
        protected string GetModifyUrl
        {
            get
            {
                return "?box=1&t=1&id=";
            }

        }

        public static decimal CountMoney;//总金额
        override protected object LoadList(out int iCount)
        {    
            iCount = 0;
            return BLL.Payment.Instance.GetListArray("");
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }

        override protected void Delete(object iID)
        {

        }


        protected void bntSave_Click(object sender, EventArgs e)
        {

            Entity.Payment pInfo = EbSite.BLL.Payment.Instance.GetEntity(int.Parse(rbList.SelectedValue));

            decimal dPayMoney = decimal.Parse(txtPayMoney.CtrValue);

            ViewState["PaymentID"] = rbList.SelectedValue;
            ViewState["PayMoney"] = txtPayMoney.CtrValue;
            tdPayType1.Visible = true;
            tdPayType.Visible = false;
            tdMoney.InnerHtml = txtPayMoney.CtrValue+" 元";
            tdPayName.InnerHtml = string.Format("{0} (手续费{1})", rbList.SelectedItem.Text, pInfo.GetFree(dPayMoney));
            bntSave.Visible = false;
           
            bntSaveOrderToPay.Visible = true;

        }

        protected void bntSaveOrderToPay_Click(object sender, EventArgs e)
        {
            int iPaymentID = int.Parse(ViewState["PaymentID"].ToString());
            decimal dPayMoney = decimal.Parse(ViewState["PayMoney"].ToString());

            Entity.Payment pInfo = EbSite.BLL.Payment.Instance.GetEntity(iPaymentID);

            Entity.PayLog pl = new PayLog();
            pl.id = Core.SqlDateTimeInt.NewOrderNumberLong();
            pl.AddDateTime = DateTime.Now;
            pl.Free = pInfo.GetFree(dPayMoney);
            pl.Income = dPayMoney;
            pl.UserID = UserID;
            pl.UserName = UserNiname;
            BLL.PayLog.Instance.Add(pl);

            //EbSite.Entity.AccountMoneyLog dd = new Entity.AccountMoneyLog();
            //dd.Balance = CountMoney + dPayMoney;
            //dd.UserId = base.UserID;
            //dd.UserName = base.UserName;
            //dd.TradeDate = DateTime.Now;
            //dd.TradeType = Convert.ToInt32(BLL.EAccountMoneyType.自助充值);
            //dd.Income = dPayMoney;
            //dd.Add();
            //更新 总资产
            //List<Entity.PayPass> ls = EbSite.BLL.PayPass.Instance.GetListArray(1, "UserId=" + base.UserID, "");
            //if (ls.Count == 0)
            //{
            //    Entity.PayPass model = new Entity.PayPass();
            //    model.Balance = dd.Balance;
            //    model.UserID = base.UserID;
            //    model.Add();
            //}
            //else
            //{
            //    Entity.PayPass model = ls[0];
            //    model.Balance = dd.Balance;
            //    model.Update();
            //}
            string sOrderNumber = string.Concat("yfko_", pl.id);
            Response.Redirect(pInfo.GetPayLink(dPayMoney, sOrderNumber, string.Concat("用户预付款充值，用户标识[",UserID,"]，单号:", sOrderNumber)));

        }
    }
}