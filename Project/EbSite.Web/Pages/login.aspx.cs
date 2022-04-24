using System;
using System.Web.UI;
using EbSite.Base;
using EbSite.Base.Page;

namespace EbSite.Web.Pages
{
    public partial class login : EbSite.Base.Page.CustomPage
    {
        private int GetExpiresTime
        {
            get
            {
                if(!string.IsNullOrEmpty(Request["expires"]))
                {
                    return int.Parse(Request["expires"]);
                }
                else
                {
                    return Base.Configs.SysConfigs.ConfigsControl.Instance.LoginExpires;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //if (!string.IsNullOrEmpty(EbSite.Base.AppStartInit.UserName))
                //{
                //    Core.AplicationGlobal.LoginToReurl();
                //}
                //UserCustomLogin();
                //是否开户验证码
                //if (!Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpenSafeCoder)
                //{
                //    IsOpenSafeCoder.Visible = false;
                //}
                //if (BLL.User.UserIdentity.GetErrNum > 0) IsOpenSafeCoder.Visible = true;
                SeoTitle = string.Concat("用户登录-", SiteName);
                
            }
        }
        ///// <summary>
        ///// 是不是用户自定义登录
        ///// </summary>
        //private void UserCustomLogin()
        //{
        //    string sUserName = Request["u"];
        //    string sPass = Request["p"];
        //    string sSaft = Request["s"];

        //    if(!string.IsNullOrEmpty(sUserName)&&!string.IsNullOrEmpty(sPass))
        //    {
        //        ToLogin(sUserName, sPass, sSaft);
        //    }

        //}
        private void ToLogin(string sUserName, string sPass, string sSafeCoder)
        {
            if (BLL.User.UserIdentity.IsOverErrLoginNum())
            {
                lbErrInfo.Text = "对不起，你错误登录了" + Base.Configs.SysConfigs.ConfigsControl.Instance.ErrLoginNum + "次，系统登录锁定！!";

                return;
            }
            //如果开验证码
            if (BLL.User.UserIdentity.GetErrNum > 0 || Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpenSafeCoder)
            {
                

                if (!BLL.User.UserIdentity.ValidateSafeCode(sSafeCoder))
                {
                    lbErrInfo.Text = "所填写的验证码与所给的不符 !";
                    return;
                }
            }
            string sErr = "";
            EbSite.Base.EntityAPI.MembershipUserEb ucf = BLL.User.MembershipUserEb.Instance.ValidateUser(sUserName, sPass, -1, out sErr);

            if (!Equals(ucf, null) && string.IsNullOrEmpty(sErr)) //登录成功
            {
                AppStartInit.LoginToReurl();

               
            }
            else
            {
                BLL.User.UserIdentity.AddErrLoginNum();
                //开户验证码
                if (!Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpenSafeCoder)
                {
                    IsOpenSafeCoder.Visible = true;
                }

                lbErrInfo.Text = sErr;
            }
        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            string sUserName = txtUserName.Text.Trim();
            string sPass = txtPassWord.Text.Trim();
            string sSafeCoder = txtSafeCoder.Text.Trim();
            ToLogin(sUserName, sPass, sSafeCoder);
            
        }
        
        
    }
}
