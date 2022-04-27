using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base;
using EbSite.Base.Page;
using EbSite.BLL;
using EbSite.Entity;

namespace EbSite.Web.AdminHt
{
    public partial class SysLogin : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //foreach (EbSite.BLL.MenuManager.MenuTree md in EbSite.BLL.MenuManager.MenuTree.Menus)
            //{
            //    Entity.Menus mdN =  BLL.Menus.Instance.GetEntity(md.Id);
            //    if(mdN!=null)
            //    {
            //        mdN.CtrPath = md.CtrPath;
            //        BLL.Menus.Instance.Update(mdN);
            //    }
            //} 
        }

        protected override void OnLoad(EventArgs e)
        {
           
            if (!IsPostBack)
            {
                //先退出
                BLL.User.UserIdentity.SignOutAdmin();
                EbSite.BLL.User.UserIdentity.SignOutUser();
            }
            base.OnLoad(e);
        }

        protected override void AddHeaderPram()
        {
            InitStyle();
        }

        protected override void InitStyle()
        {
            AddStylesheetInclude(string.Concat(AppStartInit.AdminPath, "themes/green/css.css"));

            //if (!Equals(CurrentSite, null))
            //{
            //    if (!string.IsNullOrEmpty(CurrentSite.AdminTheme))
            //    {
            //        AddStylesheetInclude(string.Concat(AppStartInit.AdminPath, "themes/", CurrentSite.AdminTheme, "/css.css"));
            //    }
            //}
            //else
            //{
            //    AddStylesheetInclude(string.Concat(AppStartInit.AdminPath, "themes/blues/css.css"));
            //}
            
        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
           
            if (BLL.User.UserIdentity.IsOverErrLoginNum())
            {
                //stCommon.Strings.cJavascripts.MessageShowBack("对不起，你错误登录了三次，系统登录锁定！!");
                lbErrInfo.Text = "对不起，你错误登录了" + Base.Configs.SysConfigs.ConfigsControl.Instance.ErrLoginNum + "次，系统登录锁定！!";
                
                return;
            }
           
            string sSafeCoder = txtSafeCoder.Text.Trim();
            if (string.IsNullOrEmpty(sSafeCoder))
            {
                lbErrInfo.Text = "验证码不能为空 !";
                return;
            }
            if (!BLL.User.UserIdentity.ValidateSafeCode(sSafeCoder))
            {
                lbErrInfo.Text = "所填写的验证码与所给的不符 !";
                 
                return;
            }

            string sUserName = txtUserName.Text.Trim();
            string sPass = txtPassWord.Text.Trim();
            string sErr = "";
            EbSite.Base.EntityAPI.MembershipUserEb ucf =  BLL.User.MembershipUserEb.Instance.ValidateUser(sUserName, sPass, -1, out sErr);
            Entity.Logs logAdmin = new EbSite.Entity.Logs();
            //验证是不是合法用户
            if (!Equals(ucf, null) && string.IsNullOrEmpty(sErr))
            {
                 
                //验证是不是管理员
                if(EbSite.BLL.AdminUser.HasUser(sUserName))
                {
                    
                    BLL.User.UserIdentity.WriteAdminLogInTag();

                    logAdmin.Title = string.Concat("管理员:", sUserName, "登录成功!!");
                    logAdmin.Description = string.Concat(sUserName, "登录成功!!");
                    logAdmin.AddDate = DateTime.Now;
                    logAdmin.IP = EbSite.Base.AppStartInit.CurrentUserIP;

                    BLL.AdminLoginLog.InsertLogs(logAdmin);
                    Response.Redirect("main.aspx");
                    //Response.Redirect("Admin_WelCome.aspx"); 
                }
                else 
                {
                     
                    BLL.User.UserIdentity.AddErrLoginNum();
                    logAdmin.Title = string.Concat("非法登录-来自用户",sUserName);
                    logAdmin.Description = string.Concat(sUserName, "非法登录系统后台管理,请对此用户提高警惕!!");
                    logAdmin.AddDate = DateTime.Now;

                    logAdmin.IP = EbSite.Base.AppStartInit.CurrentUserIP;
                    BLL.AdminLoginLog.InsertLogs(logAdmin);
                    //Base.AppStartInit.LoginToReurl();
                    lbErrInfo.Text = "登录失败:你不是管理员，已启用报警日志！";
                }

                
            }
            else
            {
                 
                BLL.User.UserIdentity.AddErrLoginNum();
                lbErrInfo.Text = sErr;
                EbSite.BLL.User.UserIdentity.SignOutUser();
                //if (BLL.User.UserIdentity.GetErrNum > 1)
                //{
                //    Base.AppStartInit.RedirectToIndex();
                //}

                BLL.User.UserIdentity.AddErrLoginNum();
                logAdmin.Title = string.Concat("非法登录-来自用户", sUserName);
                logAdmin.Description = string.Concat(sUserName, "非法登录系统后台管理,请对此用户提高警惕!!");
                logAdmin.AddDate = DateTime.Now;
                logAdmin.IP = EbSite.Base.AppStartInit.CurrentUserIP;
                BLL.AdminLoginLog.InsertLogs(logAdmin);
                //AppStartInit.LoginToReurl();

                lbErrInfo.Text = "登录失败:" + sErr;

                 

            }
        }
    }
}
