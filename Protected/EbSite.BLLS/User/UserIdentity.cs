using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.Data.Interface;
using EbSite.Data.User.Interface;

namespace EbSite.BLL.User
{
	/// <summary>
	/// 业务逻辑类EB_FriendList 的摘要说明。
	/// </summary>
    public class UserIdentity
	{

        #region 对一般用户登录cookie的处理 可以重写用户coolie接口 

        public static void WriteUserIdentity(string UserID, string UserName, string UserNiName, string UserPass, string RoleID)
        {
            int LoginExpires = Base.Configs.SysConfigs.ConfigsControl.Instance.LoginExpires;
            WriteUserIdentity(UserID, UserName, UserNiName, UserPass, LoginExpires, RoleID);
        }
        public static void WriteUserIdentity(string UserID, string UserName, string UserNiName, string UserPass, int ExpiresTime, string RoleID)
        {
            DbProviderUser.GetInstance().WriteUserIdentity(UserID, UserName, UserNiName, UserPass, ExpiresTime,RoleID);
            //与membership登录同步
            //EBPrincipal newUser = new EBPrincipal(int.Parse(UserID), UserName, ucf.LastLoginDate, ucf.IsLockedOut);
            
            EBPrincipal newUser = new EBPrincipal(int.Parse(UserID), UserName, DateTime.Now,false);
            HttpContext.Current.User = newUser;
            FormsAuthentication.SetAuthCookie(UserName, false);
        }

	    public static void SignOutUser()
        {
            DbProviderUser.GetInstance().SignOutUser();
            //同时退出membership
            FormsAuthentication.SignOut();	
        }
        //public static int GetManagerID
        //{
        //    get { return DbProviderUser.GetInstance().GetManagerID(); }
        //}
        public static string GetUserName
        {
            get
            {
                return DbProviderUser.GetInstance().GetUserName().Trim();
            }
        }
        public static string GetUserNiName
        {
            get
            {
                return DbProviderUser.GetInstance().GetUserNiName().Trim();

            }
        }
        /// <summary>
        /// 当前登录的用户密码(已解密),未登录为空
        /// </summary>
        public static string GetUserPass
        {
            get
            {
                try
                {
                   return DbProviderUser.GetInstance().GetUserPass().Trim();
                }
                catch (Exception)
                {
                    //清理所有cookie
                   SignOutAdmin();
                   SignOutUser();

                    return string.Empty;
                }
                 

            }
        }

        /// <summary>
        /// 当前登录的用户ID
        /// </summary>
        public static int GetUserID
        {
            get
            {
                return DbProviderUser.GetInstance().GetUserId();

            }
        }
        public static int GetRoleID
         {
            get
            {
                return DbProviderUser.GetInstance().GetRoleID();

            }
        }
        
        /// <summary>
        /// 加密密码的办法
        /// </summary>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static string PassWordEncode(string Password)
        {
            return DbProviderUser.GetInstance().PassWordEncode(Password);
        }
        

        #endregion

        #region 管理员登录cookie管理

        private const string sCookieHeader_admin = "ebadm";
        private const string sIsadminMark = "isadm";


        /// <summary>
        /// 写入管理员登录cookie
        /// </summary>
        public static void WriteAdminLogInTag()
        {
            WriteAdminLogInTag("adm");
        }
        /// <summary>
        /// 对管理员登录 cookie的操作
        /// </summary>
        /// <param name="Tag"></param>
        public static void WriteAdminLogInTag(string Tag)
        {
            HttpCookie cookie = new HttpCookie(sCookieHeader_admin);
            cookie.Values[sIsadminMark] = Tag;

            string cookieDomain = Base.Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
            if (cookieDomain != string.Empty && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && Validate.IsValidDomain(HttpContext.Current.Request.Url.Host))
            {
                cookie.Domain = cookieDomain;
            }

            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 检测管理员是不是已经登录
        /// </summary>
        /// <returns></returns>
        public static bool IsAdminLogIn()
        {
            string sIsLogin = EbSite.Core.Utils.GetSingleVlue(sCookieHeader_admin, sIsadminMark);

            return !string.IsNullOrEmpty(sIsLogin);
        }
        /// <summary>
        /// 登出管理员登录
        /// </summary>
        public static void SignOutAdmin()
        {
            HttpCookie cookie = new HttpCookie(sCookieHeader_admin);
            cookie.Values.Clear();
            cookie.Expires = DateTime.Now.AddYears(-1);
            string cookieDomain = Base.Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
            if (cookieDomain != string.Empty && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && Validate.IsValidDomain(HttpContext.Current.Request.Url.Host))
                cookie.Domain = cookieDomain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        #endregion

        #region 对在线用户cookie的管理


        private const string sCookieHeader_Online = "ol";
        private const string sOnlineidMark = "olid";

        /// <summary>
        /// 写入一个用户的在线ID
        /// </summary>
        /// <param name="OnlineID"></param>
        public static void WriteUserOnlineID(string OnlineID, HttpContext _HttpContext)
        {
            _HttpContext.Session[sOnlineidMark] = OnlineID;
            //HttpCookie cookie = new HttpCookie(sCookieHeader_Online);
            //cookie.Values[sOnlineidMark] = OnlineID;

            //string cookieDomain = Base.Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
            //if (cookieDomain != string.Empty && _HttpContext.Request.Url.Host.IndexOf(cookieDomain) > -1 && Validate.IsValidDomain(_HttpContext.Request.Url.Host))
            //{
            //    cookie.Domain = cookieDomain;
            //}

            //int LoginExpires = Base.Configs.SysConfigs.ConfigsControl.Instance.LoginExpires;

            //cookie.Expires = DateTime.Now.AddMinutes(LoginExpires);

            //_HttpContext.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 获取当前用户的在线ID
        /// </summary>
        /// <returns></returns>
        public static string GetUserOnlineID()
        {
            return HttpContext.Current.Session[sOnlineidMark] as string;
            //return EbSite.Core.Utils.GetSingleVlue(sCookieHeader_Online, sOnlineidMark);

        }

        #endregion

        #region 安全登录相关的一此辅助操作

        //////////////////////////////安全登录相关的一此辅助操作/////////////////////////////
        /// <summary>
        /// 检测是否超过预定错误登录次数
        /// </summary>
        /// <returns></returns>
        public static bool IsOverErrLoginNum()
        {
            bool bl = false;
            if ((HttpContext.Current.Session["PassErrorCountAdmin"] != null) && (HttpContext.Current.Session["PassErrorCountAdmin"].ToString() != ""))
            {
                int PassErroeCount = Convert.ToInt32(HttpContext.Current.Session["PassErrorCountAdmin"]);
                if (PassErroeCount > (Base.Configs.SysConfigs.ConfigsControl.Instance.ErrLoginNum - 1))
                {

                    bl = true;
                }

            }
            return bl;
        }
        /// <summary>
        /// 累加错误登录次数
        /// </summary>
        public static void AddErrLoginNum()
        {
            if (GetErrNum > 0)
            {

                HttpContext.Current.Session["PassErrorCountAdmin"] = GetErrNum + 1;
            }
            else
            {
                HttpContext.Current.Session["PassErrorCountAdmin"] = 1;
            }
        }
        /// <summary>
        /// 获取错误登录次数
        /// </summary>
        public static int GetErrNum
        {
            get
            {
                int inum = 0;
                if ((HttpContext.Current.Session["PassErrorCountAdmin"] != null) && (HttpContext.Current.Session["PassErrorCountAdmin"].ToString() != ""))
                {
                    inum = Convert.ToInt32(HttpContext.Current.Session["PassErrorCountAdmin"]);

                }

                return inum;
            }
        }
        public static bool ValidateSafeCode(string Code)
        {
            return ValidateSafeCode(Code, true);
        }

	    /// <summary>
        /// 验证用户输入的安全码是否正确
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static bool ValidateSafeCode(string Code,bool IsOKSetNull)
        {
            bool bl = false;
            if (!string.IsNullOrEmpty(Code))
            {
                if (!Equals(HttpContext.Current.Session["CheckCode"], null) && HttpContext.Current.Session["CheckCode"].ToString().Trim() != string.Empty)
                {
                    if (HttpContext.Current.Session["CheckCode"].ToString().ToLower() == Code.ToLower())
                    {
                       
                        bl = true;
                        if(IsOKSetNull)
                            HttpContext.Current.Session["CheckCode"] = null;
                    }


                }
            }

            return bl;
        }
        /// <summary>
        /// 验证用户输入的安全码是否正确
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static bool ValidateSafeCodeMobile(string Code, bool IsOKSetNull)
        {
            bool bl = false;
            if (!string.IsNullOrEmpty(Code))
            {
                if (!Equals(HttpContext.Current.Session["MobileValCode"], null) && HttpContext.Current.Session["MobileValCode"].ToString().Trim() != string.Empty)
                {
                    if (HttpContext.Current.Session["MobileValCode"].ToString().ToLower() == Code.ToLower())
                    {

                        bl = true;
                        if (IsOKSetNull)
                            HttpContext.Current.Session["MobileValCode"] = null;
                    }


                }
            }

            return bl;
        }
        #endregion
    }
}

