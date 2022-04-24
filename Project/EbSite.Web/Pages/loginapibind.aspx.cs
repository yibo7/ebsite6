using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Plugin;
using EbSite.BLL.User;
using System.Web.Security;

namespace EbSite.Web.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public partial class loginapibind : LoginapibindBase
    {
        private string ViewToken
        {
            get { return ViewState["_viewtoken"].ToString(); }
            set { ViewState["_viewtoken"] = value; }
        }
        /// <summary>
        /// 获取用户组ID，如果此ID大于0那么默认当前注册的用户将归于当前用户组
        /// </summary>
        private string GetGroupID
        {
            get
            {
                return Request["gid"];
            }
        }
        private string GetCode
        {
            get
            {
                if (Request.Params["code"] != null)
                {
                    return Request.Params["code"];
                }
                else
                {
                    if (Request.Params["token"] != null)
                    {
                        return Request.Params["token"];
                    }
                }
                return "";
            }
        }
        private string GetAppName
        {
            get
            {
                return Request["t"].ToUpper();
            }
        } 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                    string sKey = EbSite.Base.Host.Instance.DecodeByKey(EbSite.Core.Utils.GetCookie("loginapi"));
                    if (sKey.ToUpper().Equals(GetAppName))
                    {
                        if (!string.IsNullOrEmpty(GetCode))
                        {
                            try
                            {
                                ViewToken = base.LoginApi.GetToken(GetCode);
                            }
                            catch (Exception)
                            {

                                Tips("出错了", "受权码可能已经过期，请重新登录！");
                                return;
                            }

                            
                                //初始化跳转链接
                                if (!string.IsNullOrEmpty(ViewToken))
                                {
                                    //标示是新浪还是腾讯
                                    string strFlag = base.LoginApi.ApiName;
                                    //获取授权码
                                    string strToken = ViewToken;
                                    if (!string.IsNullOrEmpty(strToken))
                                    {

                                        //判断是否已经用此账号登录过网站
                                        bool isExist = EbSite.BLL.TheThirdLoginCode.Instance.Exists(strToken);
                                        if (isExist)
                                        {
                                            if (EbSite.BLL.TheThirdLoginCode.Instance.IsBind(strToken)) //已经绑定过帐号,这种情况不需要完成资料，直接登录
                                            {
                                                Base.EntityAPI.MembershipUserEb uModel = GetUserByByToken(strToken);
                                                AutoLogin(uModel.UserName, uModel.Password, true, uModel.id, uModel.NiName, false, uModel.GroupID);
                                            }

                                        }
                                        else //没有绑定过
                                        {
                                            if (UserID >0) //用户已经登录网站
                                            {
                                                EbSite.Entity.TheThirdLoginCode model = new Entity.TheThirdLoginCode();
                                                model.userid = UserID;
                                                model.username = UserName;
                                                model.tokencode = strToken;
                                                model.appname = strFlag;
                                                model.IsBind = 1;
                                                model.otherinfo = "";
                                                model.adddate = DateTime.Now;
                                                EbSite.BLL.TheThirdLoginCode.Instance.Add(model);
                                                string BackUrl = EbSite.Core.Utils.GetCookie("loginapiback");
                                                if(!string.IsNullOrEmpty(BackUrl))
                                                {
                                                    Response.Redirect(BackUrl);
                                                }
                                                else
                                                {
                                                    Response.Redirect(EbSite.Base.Host.Instance.UccUrl);
                                                }

                                            }
                                        }
                                        //绑定头像
                                        this.imgIcon.ImageUrl = base.LoginApi.GetUserIco(strToken);
                                        string newNickName = base.LoginApi.GetUserNickName(strToken);
                                        if (!string.IsNullOrEmpty(newNickName))
                                        {
                                            this.reg_username.Text = newNickName;
                                        }
                                        
                                    }
                                }
                            

                           
                        }
                        else
                        {
                            Tips("出错了", "参数有误！");
                        }
                    }
               

                


            }
            btnRegUser.Click += new EventHandler(btnRegUser_Click);
            lbtnNext.Click += new EventHandler(lbtnNext_Click);
        }
        protected void btnRegUser_Click(object sender, EventArgs e)
        {
            

            string strEmail = this.reg_email.Text;
            string strPwd = this.reg_pwd.Text;
            string strUName = this.reg_username.Text;
            string strFlag = base.LoginApi.ApiName.ToLower();
            string strToken = ViewToken;
            //验证此用户已经存在
            string sErr = "";
            string Passend = UserIdentity.PassWordEncode(strPwd);
            //bool isok = Host.Instance.EBMembershipInstance.IsHaveUser(strEmail, Passend);
            Base.EntityAPI.MembershipUserEb mdUser = Host.Instance.EBMembershipInstance.GetUserByEmail(strEmail, Passend);

            if (!Equals(mdUser,null)) //已经存在,也说是说用户输入的用户名与密码是正确的，说明原来已经注册过，此时进行绑定就行
            {
                //int uid = BLL.User.MembershipUserEb.Instance.GetUserIDByUserName(strEmail);
                //添加到附加表中
                EbSite.Entity.TheThirdLoginCode model = new Entity.TheThirdLoginCode();
                model.userid = mdUser.id;
                model.username = mdUser.UserName;
                model.tokencode = strToken;
                model.appname = strFlag;
                model.IsBind = 1;
                model.otherinfo = "";
                model.adddate = DateTime.Now;
                EbSite.BLL.TheThirdLoginCode.Instance.Add(model);
                AutoLogin(mdUser.UserName, Passend, true, mdUser.id, mdUser.NiName, false, mdUser.GroupID);
                //ActionUser();
                //return newUID;
            }
            else  
            {
                
                bool isExist = EbSite.BLL.TheThirdLoginCode.Instance.Exists(strToken); //是否有临时注册过
                if (!isExist) //进行全新注册一个用户
                {
                    //注册用户基方法
                    RegBaseUser(strEmail, strUName, strPwd, strEmail, 1, strToken, strFlag);
                     
                }
                else //这种情况是用户原来点击跳过，注册过一个临时帐号,此时更新用户名与密码到这个帐户就行
                {


                    int newUID = EbSite.BLL.TheThirdLoginCode.Instance.GetUserIDByToken(strToken);
                    //Base.EntityAPI.MembershipUserEb uModel = new Base.EntityAPI.MembershipUserEb(newUID);

                    Base.EntityAPI.MembershipUserEb uModel = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(newUID);
                    uModel.UserName = strEmail;
                    uModel.NiName = strUName;
                    uModel.Password = Passend;
                    uModel.emailAddress = strEmail;
                    uModel.Save();

                    EbSite.Entity.TheThirdLoginCode tModel = new Entity.TheThirdLoginCode();
                    tModel.username = strEmail;
                    tModel.tokencode = strToken;
                    tModel.IsBind = 1;
                    EbSite.BLL.TheThirdLoginCode.Instance.UpdateByToken(tModel);
                    AutoLogin(uModel.UserName, uModel.Password, true, newUID, uModel.NiName, true, mdUser.GroupID);

                }
            }
        }
        /// <summary>
        /// 由于有些网站的Token会有逗号这样的非法字符，所以要去掉
        /// </summary>
        /// <param name="sToken"></param>
        /// <returns></returns>
        private string GetUserName(string sToken)
        {
            sToken = Core.Strings.GetString.CutLen(sToken, 32);
            return sToken.Replace(",", "-").Replace("‘","");

        }
        protected void lbtnNext_Click(object sender, EventArgs e)
        {
            //int newUID = RegNewUser("", "", "", false);
            //if (newUID > 0)
            //{
            //    AutoLogin(ViewToken, base.LoginApi.ApiName.ToLower(), false);
            //}
            bool isExist = EbSite.BLL.TheThirdLoginCode.Instance.Exists(ViewToken);
            if(!isExist)
            {
                string strFlag = base.LoginApi.ApiName.ToLower();
                //string sUserName = GetUserName(ViewToken);
                //RegBaseUser(sUserName, strFlag, reg_username.Text, strFlag, "", 0);
                RegBaseUser(ViewToken, reg_username.Text, strFlag, "", 0, ViewToken, strFlag);
            }
            else
            {
                Base.EntityAPI.MembershipUserEb uModel = GetUserByByToken(ViewToken);
                AutoLogin(uModel.UserName, uModel.Password, true, uModel.id, uModel.NiName, false, uModel.GroupID);
            }
            
        }
        private Base.EntityAPI.MembershipUserEb GetUserByByToken(string strToken)
        {
            int newUID = EbSite.BLL.TheThirdLoginCode.Instance.GetUserIDByToken(strToken);
            return EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(newUID);
        }
       


        /// <summary>
        /// 自动登录
        /// </summary>
        /// <param name="strUName"></param>
        /// <param name="strPwd"></param>
        private void AutoLogin(string strUName, string strPwd, bool pwdIsEncry, int UserID, string UserNiName, bool IsSaveIco,int roleid)
        {

            string sUserName = strUName;//txtUserName.Text.Trim();
            string sPass = (pwdIsEncry) ? strPwd : UserIdentity.PassWordEncode(strPwd); ;//已经加过密码
            BLL.User.UserIdentity.WriteUserIdentity(UserID.ToString(), sUserName, UserNiName, sPass, roleid.ToString());

            if (IsSaveIco)//更新头像
                EbSite.BLL.User.MembershipUserEb.Instance.UpdateAvatar(UserID, base.LoginApi.GetUserIco(ViewToken));
            Response.Redirect(Base.Host.Instance.UccUrl);

        }
        private void RegBaseUser(string sUserName, string strUiName, string strPwd, string strEmail, int isBind, string strToken, string sAppType)
        {
            RegStatus ms;
            //添加用户到用户表中
            //int UserID = EbSite.BLL.User.MembershipUserEb.Instance.RegUser(string.IsNullOrEmpty(strEmail) ? strUName : strEmail, strPwd, strEmail, out ms, false, GetGroupID, 0);
            string RetunUrl = "";
            string FromUrl = "";
            string Mobile = "";
            int RegType = 1; //email

            string Ip = EbSite.Core.Utils.GetClientIP();

            string regusername = GetUserName(sUserName);
            
            int iUserID =  EbSite.BLL.User.MembershipUserEb.Instance.RegUserByGroupKey(regusername,
                    strPwd, strEmail, out ms, false, GetGroupID, out RetunUrl, 0, FromUrl, Mobile, RegType, strUiName, false, Ip,"来自第三方登录邦定页");
            if (iUserID > 0 && ms == RegStatus.注册成功)
            {
                //Base.EntityAPI.MembershipUserEb uModel = new Base.EntityAPI.MembershipUserEb(UserID);
                //uModel.NiName = strUiName;
                //uModel.Save();
                //添加到附加表中
                EbSite.Entity.TheThirdLoginCode model = new Entity.TheThirdLoginCode();
                model.userid = iUserID;
                model.username = regusername;
                model.tokencode = strToken;
                model.appname = sAppType;
                model.IsBind = isBind;
                model.otherinfo = ""; //保用用户的基本信息
                model.adddate = DateTime.Now;
                EbSite.BLL.TheThirdLoginCode.Instance.Add(model);
                Response.Redirect(RetunUrl);
            }
            else
            {

                Tips("用户注册失败", "对不起,用户注册失败");
               
            }
        }


    }
}