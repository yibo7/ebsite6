using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.BLL.Email;
using EbSite.BLL.GetLink;
using EbSite.BLL.User;

namespace EbSite.Web.Pages
{
    public partial class lostpassword : EbSite.Base.Page.CustomPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.Title = "找回密码";
                if(!string.IsNullOrEmpty(GetAct))
                {
                    
                    tbPass.Visible = true;
                    tbEmail.Visible = false;
                }
                else
                {
                    tbPass.Visible =  false;
                    tbEmail.Visible = true;
                }
            }
            
        }
      
        private string GetAct
        {
            get
            {
                return Request.QueryString["act"];
            }
        }
        private string GetMobileCode
        {
            get
            {
                return Request.QueryString["mc"];
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(GetAct))
            {

                //bool isEmail = Equals(txtMobileCode, null);

                //string sEmailOrMobile = txtEmail.Text.Trim();//isEmail为true这里输入的是email,否则这里输入的是手机号
                //if (isEmail)
                //{
                //    string sUserName = Membership.GetUserNameByEmail(sEmailOrMobile);

                //    if (!string.IsNullOrEmpty(sUserName))
                //    {
                //        //UserCustomField UCF = UserCustomField.GetUserCustomField(sUserName);

                //        MembershipUser mu = Membership.GetUser(sUserName);

                //        string sWebName = SiteName;
                //        string sWebUrl = Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName;
                //        string iisPath = Base.Configs.SysConfigs.ConfigsControl.Instance.IISPath;

                //        string ActivateCorde = EbSite.BLL.User.MembershipUserEb.Instance.GetActivateEncode(sUserName, mu.GetPassword(), 0, 0);
                //        //string sUrlFull = string.Format("{0}{1}{3}?act={2}", sWebUrl, iisPath, ActivateCorde, HrefFactory.GetMainInstance.LostpasswordRw);
                //        string sUrlFull = string.Format("{0}{1}{3}?act={2}", sWebUrl, iisPath, ActivateCorde, HostApi.LostpasswordRw);
                //        string sContent = string.Format("感谢使用{0},请点击此连接，系统将引导您更改密码，此连接24小时内有效 <a href='{1}'>{1}</a><br>帐号:{2}",
                //            sWebName, sUrlFull, sUserName
                //            );
                //        EmailBLL.SendEmail(sEmailOrMobile, "请在24小时内更改您的密码!", sContent);
                //        //用这个时间来代替
                //        mu.LastActivityDate = DateTime.Now;
                //        Membership.UpdateUser(mu);
                //        //Tips("邮件已经发送", "邮件已经发送，请到您的邮箱查看，并在24小时内更改密码!", HrefFactory.GetMainInstance.LoginRw);
                //        Tips("邮件已经发送", "邮件已经发送，请到您的邮箱查看，并在24小时内更改密码!", HostApi.LoginRw);
                //    }
                //    else
                //    {
                //        Tips("邮件发送失败", "抱歉，不存在此邮箱，请再想想您注册时填写的邮箱地址!");
                //    }
                //}
                //else
                //{
                    

                //    if (MembershipUserEb.Instance.ExistsMobile(sEmailOrMobile))
                //    {
                //        //获取手机验证码
                //        string sSafeCode = txtMobileCode.Text;
                //        bool isok = BLL.User.UserIdentity.ValidateSafeCodeMobile(sSafeCode, true);

                //        if (isok)
                //        {
                //            MembershipUser mu = Membership.GetUser(sEmailOrMobile);

                //            //string sWebName = SiteName;
                //            string sWebUrl = "";// Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName;
                //            string iisPath = Base.Configs.SysConfigs.ConfigsControl.Instance.IISPath;

                //            string ActivateCorde = EbSite.BLL.User.MembershipUserEb.Instance.GetActivateEncode(sEmailOrMobile, mu.GetPassword(), 0, 0);
                //            //string sUrlFull = string.Format("{0}{1}{3}?act={2}", sWebUrl, iisPath, ActivateCorde, HrefFactory.GetMainInstance.LostpasswordRw);
                //            string sUrlFull = string.Format("{0}{1}{3}?act={2}", sWebUrl, iisPath, ActivateCorde, HostApi.LostpasswordRw);

                //            //用这个时间来代替
                //            mu.LastActivityDate = DateTime.Now;
                //            Membership.UpdateUser(mu);

                //            Response.Redirect(sUrlFull);
                //        }
                //        else
                //        {
                //            Tips("发送失败", "抱歉，不存在此邮箱，请再想想您注册时填写的邮箱地址!");
                //        }
                         
                //    }
                //    else
                //    {
                //        Tips("发送失败", "抱歉，不存在此邮箱，请再想想您注册时填写的邮箱地址!");
                //    }
                //}
                
            }
            else  //修改密码，暂时只支持手机号
            {
                bool isok = false;
                  string ChangePassMobileValCode = HttpContext.Current.Session["ChangePassMobileValCode"] as string;
                if (!string.IsNullOrEmpty(ChangePassMobileValCode))
                {
                    isok = UserIdentity.ValidateSafeCodeMobile(ChangePassMobileValCode, true);
                }

                if (isok)
                {
                    string sVUserName;
                    string sOldPass;
                    //进行验证
                    isok = BLL.User.MembershipUserEb.Instance.IsPassValiOK(GetAct, out sVUserName, out sOldPass);
                    if (isok)
                    {
                        string sNewPass = txtPassWord.Text.Trim();
                        string sComfirPass = txtCfPassWord.Text.Trim();
                        if (!string.IsNullOrEmpty(sNewPass) && !string.IsNullOrEmpty(sComfirPass))
                        {
                            if (sNewPass.Equals(sComfirPass))
                            {
                                MembershipUser mu = Membership.GetUser(sVUserName);

                                bool ischanged = mu.ChangePassword(sOldPass, sNewPass);
                                if (ischanged)
                                {
                                    //Tips("密码修改成功", "密码修改成功,将返回登录页面!", HrefFactory.GetMainInstance.LoginRw);
                                    Tips("密码修改成功", "密码修改成功,将返回登录页面!", HostApi.LoginRw);
                                }
                                else
                                {
                                    //Tips("失败", "密码修改失败,请联系管理员!", HrefFactory.GetMainInstance.LoginRw);
                                    Tips("失败", "密码修改失败,请联系管理员!", HostApi.LoginRw);

                                }

                            }
                            else
                            {
                                Tips("两次输入密码不相等", "请确认密码!");
                            }
                        }
                        else
                        {
                            Tips("密码不能为空", "请输入新密码与确认新密码!");
                        }
                    }
                    else
                    {
                        AppStartInit.RedirectToIndex();
                    }
                }
                else
                {
                    Tips("认证出错", "验证码不对或已过期!");
                }
                               
                    
            }
            
            
            
        }
    }
}