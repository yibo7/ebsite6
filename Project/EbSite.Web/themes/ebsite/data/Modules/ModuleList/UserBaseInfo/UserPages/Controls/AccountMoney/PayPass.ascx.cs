using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.BLL.User;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.AccountMoney
{
    public partial class PayPass : MPUCBaseSaveForUser
    {
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
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
                return 5;
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
                
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("c6dd03df-5606-41a2-b09e-6e6981dc3b2e");
            }
        }
        public override string PageName
        {
            get
            {
                return "修改支付密码";
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

        override protected void InitModifyCtr()
        {

            EbSite.BLL.SpaceSetting.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {

            string sVUserName = UserName;
            string sOldPass = txtOldPass.Text.Trim();
            string sNewPass = txtPassWord.Text.Trim();
            string sComfirPass = txtCfPassWord.Text.Trim();

            if (!string.IsNullOrEmpty(sNewPass) && !string.IsNullOrEmpty(sComfirPass) )//&& !string.IsNullOrEmpty(sOldPass)
            {
                if (sNewPass.Equals(sComfirPass))
                {
                    List<Entity.PayPass> ls=new List<Entity.PayPass>();
                    if(string.IsNullOrEmpty(sOldPass))
                    {
                        ls = BLL.PayPass.Instance.GetListArray(1, "userid=" + base.UserID + "", "");
                    }
                    else
                    {
                        sOldPass = UserIdentity.PassWordEncode(sOldPass);
                        ls = BLL.PayPass.Instance.GetListArray(1, "userid=" + base.UserID + " and pass='" + sOldPass + "'", "");
                    }
                
                    if(ls.Count>0)
                    {
                        sNewPass = UserIdentity.PassWordEncode(sNewPass);
                        Entity.PayPass model = ls[0];
                        model.Pass = sNewPass;
                        model.Update();
                    }
                    else
                    {
                        base.TipsAlert("密码修改失败,请联系管理员!");
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