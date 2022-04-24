using System;
using System.Web;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.Entity;

namespace EbSite.Data.User.SqlServer
{
    public partial class DataProviderUser : Interface.IDataProviderUser
    {
        private const string sCookieHeader_User = "ebu";

        private const string sUserIDMark = "uid";//保存用户ID
        private const string sUsernameMark = "un";//保存用户帐号
        private const string sUserNinameMark = "uni";//保存用户昵称
        private const string sUserPassMark = "pa";//保存用户密码

       
       public  void WriteUserIdentity(string UserID, string UserName, string UserNiName, string UserPass, int ExpiresTime)
       {
           if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(UserNiName) && !string.IsNullOrEmpty(UserPass))
           {
               HttpCookie cookie = new HttpCookie(sCookieHeader_User);
               cookie.Values[sUserIDMark] = UserID;
               cookie.Values[sUsernameMark] = UserName;
               cookie.Values[sUserNinameMark] = Utils.UrlEncode(UserNiName);
               cookie.Values[sUserPassMark] = Utils.UrlEncode(DESCrypto.Encode(UserPass, Base.Configs.SysConfigs.ConfigsControl.Instance.Passwordkey));


               cookie.Values["expires"] = ExpiresTime.ToString();
               cookie.Expires = DateTime.Now.AddMinutes(ExpiresTime);

               string cookieDomain = Base.Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
               if (!string.IsNullOrEmpty(cookieDomain) && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && Validate.IsValidDomain(HttpContext.Current.Request.Url.Host))
               {
                   cookie.Domain = cookieDomain;
               }

               HttpContext.Current.Response.AppendCookie(cookie);
           }


       }
        /// <summary>
        /// 用户退出后，清除用户已经登录的coolie
        /// </summary>
       public void SignOutUser()
        {
            HttpCookie cookie = new HttpCookie(sCookieHeader_User);
            cookie.Values.Clear();
            cookie.Expires = DateTime.Now.AddYears(-1);
            string cookieDomain = Base.Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
            if (cookieDomain != string.Empty && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && Validate.IsValidDomain(HttpContext.Current.Request.Url.Host))
                cookie.Domain = cookieDomain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 获取当前登录用户的用户帐号
        /// </summary>
        /// <returns></returns>
       public string GetUserName()
        {
            return EbSite.Core.Utils.GetSingleVlue(sCookieHeader_User, sUsernameMark);
        }
        /// <summary>
        /// 获取当前登录用户的昵称
        /// </summary>
       public string GetUserNiName()
        {
            return EbSite.Core.Utils.GetSingleVlue(sCookieHeader_User, sUserNinameMark);
        }

        /// <summary>
        /// 获取当前登录的用户密码(已解密),未登录为空
        /// </summary>
       public string GetUserPass()
        {
            string Pass = EbSite.Core.Utils.GetSingleVlue(sCookieHeader_User, sUserPassMark);

            if (!string.IsNullOrEmpty(Pass))
            {
                string sKey = Base.Configs.SysConfigs.ConfigsControl.Instance.Passwordkey;
                if (string.IsNullOrEmpty(Pass)) return string.Empty;
                return DESCrypto.Decode(Pass, sKey);
            }
            return "";
        }

       /// <summary>
       /// 获取当前登录的用户的id,未登录等于-1
       /// </summary>
       public int GetUserId()
       {
           string sid = EbSite.Core.Utils.GetSingleVlue(sCookieHeader_User, sUserIDMark);

           if (!string.IsNullOrEmpty(sid))
           {
               return int.Parse(sid);
           }
           else
           {
               return -1;
           }
       }
        /// <summary>
        /// 获取加密后的密码md5等
        /// </summary>
        /// <param name="Pass"></param>
        /// <returns></returns>
       public string PassWordEncode(string Pass)
       {
           PassWordType passWordType = Base.Configs.SysConfigs.ConfigsControl.Instance.PassType;
            string pass;
           if (passWordType == PassWordType.MD5)
           {
               pass = Core.Utils.MD5(Pass);
           }
           else
           {
               pass = StringEncrypt.SHA256(Pass);
           }
            return pass;
       }


    }
}