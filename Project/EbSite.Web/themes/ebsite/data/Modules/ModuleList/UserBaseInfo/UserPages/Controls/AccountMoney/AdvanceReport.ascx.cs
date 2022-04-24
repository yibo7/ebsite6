using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL.User;
using EbSite.Base.Modules;
using EbSite.Entity;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.AccountMoney
{
    public partial class AdvanceReport : MPUCBaseListForUserRp
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

            //若用户开启了 预付款功能 就在Eb_PayPass中 写入 一条记录。
            if (!IsPostBack)
            {
                BindData();

            }
        }

        private void BindData()
        {
           // List<Entity.PayPass> ls = EbSite.BLL.PayPass.Instance.GetListArray(1, "UserId=" + base.UserID, "");
            EbSite.Entity.PayPass payModel = EbSite.BLL.PayPass.Instance.GetEntityByUserID(UserID);
            if (!Equals(payModel,null))
            {
                RegAccount.Visible = false;
                AccountInfo.Visible = true;
                CountMoney = payModel.Balance;

                FrozenMondy = payModel.RequestBalance;
                //List<Entity.AccountMoneyLog> AMLog = EbSite.BLL.AccountMoneyLog.Instance.GetListArray(0, "TradeType=4 and UserId=" + base.UserID, "");
                //if (AMLog.Count > 0)
                //{
                //    FrozenMondy = (from i in AMLog select i.Expenses).Sum();
                //}
            }
            else
            {
                RegAccount.Visible = true;
                AccountInfo.Visible = false;


                CountMoney = 0;
            }

        }
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("e67667e0-8526-4140-b294-8bafb8fc5faf");
            }
        }
        public override string PageName
        {
            get
            {
                return "预付款余额";
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

        public decimal CountMoney;//总金额
        public decimal FrozenMondy = 0;//冻结

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

        override protected void Delete(object iID)
        {

        }
        protected void bntOpenBalance_Click(object sender, EventArgs e)
        {
            string sNewPass = txtPassWord.Text.Trim();
            string sComfirPass = txtCfPassWord.Text.Trim();

            if (!string.IsNullOrEmpty(sNewPass) && !string.IsNullOrEmpty(sComfirPass))//&& !string.IsNullOrEmpty(sOldPass)
            {
                if (sNewPass.Equals(sComfirPass))
                {
                    List<Entity.PayPass> ls  = BLL.PayPass.Instance.GetListArray(1, "userid=" + base.UserID + "", "");
                    
                  
                    if (ls.Count == 0)
                    {
                        sNewPass = UserIdentity.PassWordEncode(sNewPass);
                        Entity.PayPass model = new Entity.PayPass();
                        model.Pass = sNewPass;
                        model.UserID = base.UserID;

                        model.Add();

                        BindData();
                    }
                    else
                    {
                        base.TipsAlert("预付款开启失败,请联系管理员!");
                    }
                }
                else
                {
                    TipsAlert("两次输入密码不相等,请确认密码!");
                }
            }
            else
            {
                TipsAlert("密码不能为空,请输入新密码与确认新密码!");
            }
        }

    }
}