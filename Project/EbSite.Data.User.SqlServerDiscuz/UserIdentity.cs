using System;
using System.Web;
using EbSite.Configs.SysConfigs;
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.Entity;

namespace EbSite.Data.User.SqlServerDiscuz
{
    public partial class DataProviderUser : Interface.IDataProviderUser
    {
        private const string sCookieHeader_User = "dnt";

        private const string sUserIDMark = "userid";//保存用户ID
        private const string sUsernameMark = "un";//保存用户帐号
        private const string sUserNinameMark = "uni";//保存用户昵称
        private const string sUserPassMark = "password";//保存用户密码
        /// <summary>
        /// 当用户登录后，写入用户的cookie
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserName"></param>
        /// <param name="UserNiName"></param>
        /// <param name="UserPass"></param>
        /// <param name="ExpiresTime"></param>
       public void WriteUserIdentity(string UserID, string UserName, string UserNiName, string UserPass, int ExpiresTime)
       {
           if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(UserNiName) && !string.IsNullOrEmpty(UserPass))
           {
               HttpCookie cookie = new HttpCookie(sCookieHeader_User);
               cookie.Values[sUserIDMark] = UserID;
               cookie.Values[sUsernameMark] = UserName;

               //dnt并不在cookie里保存昵称，所以获取要取自数据库
               //cookie.Values[sUserNinameMark] = Utils.UrlEncode(UserNiName);

               cookie.Values[sUserPassMark] = Utils.UrlEncode(DESCrypto.Encode(UserPass, Configs.ConformConfig.ConfigsControl.Instance.PassKey));


               //dnt论坛多出以下
               //cookie.Values["tpp"] = userinfo.Tpp.ToString();
               //cookie.Values["ppp"] = userinfo.Ppp.ToString();
               //cookie.Values["pmsound"] = userinfo.Pmsound.ToString();
               //if (invisible != 0 || invisible != 1)
               //{
               //    invisible = userinfo.Invisible;
               //}
               //cookie.Values["invisible"] = invisible.ToString();

               //cookie.Values["referer"] = "index.aspx";
               //cookie.Values["sigstatus"] = userinfo.Sigstatus.ToString();
               ////////////////////////////////////////////////////////////////
               cookie.Values["invisible"] = "0";
               cookie.Values["expires"] = ExpiresTime.ToString();
               cookie.Expires = DateTime.Now.AddMinutes(ExpiresTime);

               string cookieDomain = Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
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
            string cookieDomain = Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
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
            string username =  EbSite.Core.Utils.GetSingleVlue(sCookieHeader_User, sUsernameMark);
            
           if(!string.IsNullOrEmpty(username.Trim()))
           {
               return username;
           }
           else  //如果用户在论坛登录，那么只能获取userid 再取用户名
           {
               int uid = GetUserId();
               BLL.User.UserCustomField md = BLL.User.UserCustomField.GetUserCustomField(uid);

               if(!Equals(md,null))
               {
                   username = md.UserName;
                   string UserNiName = md.NiName;
                   string UserPass = GetUserPass();
                   WriteUserIdentity(uid.ToString(), username, UserNiName, UserPass, int.MaxValue);
               }
           }

            return username;
        }
        /// <summary>
        /// 获取当前登录用户的昵称
        /// </summary>
       public string GetUserNiName()
        {
            string sun = GetUserName();
            if (!string.IsNullOrEmpty(sun))
            {
                sun = BLL.User.UserCustomField.GetUserCustomField(sun).NiName;
            }
            return sun;
        }

        /// <summary>
        /// 获取当前登录的用户密码(已解密),未登录为空
        /// </summary>
       public string GetUserPass()
        {
            string Pass = EbSite.Core.Utils.GetSingleVlue(sCookieHeader_User, sUserPassMark);

            if (!string.IsNullOrEmpty(Pass))
            {
                string sKey = Configs.ConformConfig.ConfigsControl.Instance.PassKey;
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
             string sid =  EbSite.Core.Utils.GetSingleVlue(sCookieHeader_User, sUserIDMark);

             if(!string.IsNullOrEmpty(sid))
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
           PassWordType passWordType = Configs.SysConfigs.ConfigsControl.Instance.PassType;
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