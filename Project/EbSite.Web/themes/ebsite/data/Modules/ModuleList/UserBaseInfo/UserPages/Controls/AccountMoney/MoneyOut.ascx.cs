using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.BLL.User;
using EbSite.Entity;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.AccountMoney
{
    public partial class MoneyOut : MPUCBaseListForUserRp
    {
        //public override bool IsCloseTagsTitle
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}
        public override int OrderID
        {
            get
            {
                return 4;
            }
        }
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
                    this.PanAdd.Visible = true;
                    this.PanOK.Visible = false;
                    this.LitMessage.Visible = false;
                }
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("fe7c0cda-ca3c-4c25-821f-7879d7ac018d");
            }
        }
        public override string PageName
        {
            get
            {
                return "申请提现";
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


        override protected object LoadList(out int iCount)
        {

            iCount = 0;
            return null;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        public static decimal CountMoney;//总金额
        override protected void Delete(object iID)
        {

        }
        protected void bntSave_Click(object sender, EventArgs e)
        {
            //先要验证 密码 
            //List<Entity.PayPass> ls = BLL.PayPass.Instance.GetListArray(1, "userid=" + base.UserID, "");
            Entity.PayPass payModel = BLL.PayPass.Instance.GetEntity(base.UserID);
            if (!Equals(payModel,null))
            {
                string sPass = txtPwd.Text.Trim();
                sPass = UserIdentity.PassWordEncode(sPass);
                if (payModel.Pass == sPass)
                {
                    //进行添加
                    //进行比较 不能超过总金额
                    //添加 冻结金额

                    if (CountMoney > Convert.ToDecimal(this.txtAmount.Text))
                    {

                        // 检测 上笔提现管理员还没有处理，只有处理完后才能再次申请提现
                        List<EbSite.Entity.WithdrawList> lsWith = EbSite.BLL.WithdrawList.Instance.GetListArray(0, "UserId="+base.UserID, "");
                        if (lsWith.Count > 0)
                        {
                            this.LitMessage.Visible = true;
                        }
                        else
                        {
                            this.LitMessage.Visible = false;
                            this.PanAdd.Visible = false;
                            this.PanOK.Visible = true;

                            this.lbMoney.Text = txtAmount.Text;
                            this.lbBankName.Text = txtBankName.Text;
                            this.lbAccountName.Text = txtAccountName.Text;
                            this.lbCardNumber.Text = txtCardNumber.Text;
                            this.lbDemo.Text = txtRemark.Text;
                        }
                    }
                    else
                    {
                        base.TipsAlert(" 金额不足");
                    }

                }
                else
                {
                    base.TipsAlert(" 密码不对");
                }
            }
        }
        protected void bntOK_Click(object sender, EventArgs e)
        {

            //安全 事务

            Entity.WithdrawList model = new WithdrawList();
            model.UserId = base.UserID;
            model.UserName = base.UserName;
            model.RequestTime = DateTime.Now;
            model.Amount = Convert.ToDecimal(this.txtAmount.Text);
            model.AccountName = txtAccountName.Text;
            model.BankName = txtBankName.Text;
            model.CardNumber = txtCardNumber.Text;
            model.Remark = txtRemark.Text;

            bool iKey = EbSite.BLL.WithdrawList.Instance.BalanceDrawRequest_Add(model, Convert.ToDecimal(this.txtAmount.Text),
                                                                      base.UserID);

          
            if (iKey)
            {
                //base.TipsAlert(" 操作成功");
                Response.Redirect(EbSite.Base.Host.Instance.GetOpenBalance);
               
            }
            else
            {
                base.TipsAlert(" 操作失败，请联系管理人员。");
            }
        }
    }
}