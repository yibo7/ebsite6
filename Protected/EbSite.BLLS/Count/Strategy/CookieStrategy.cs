using System;
using System.Collections.Generic;

using System.Web;

namespace EbSite.BLL.Count.Strategy
{
    public class CookieStrategy : IStrategyPrevent
    {
        
        private string CookieName = "EbSiteCookieStrategyKey";
        //private string CookieStrategyKey = "CookieStrategyKey";
        private double ExpiresTime = 10;
        public bool IsAllowAdd()
        {
            bool bl = false;
            
            if (Equals(HttpContext.Current.Request.Cookies[CookieName], null))
            {
                HttpCookie cookie = new HttpCookie(CookieName);
                //cookie.Values[CookieStrategyKey] = DateTime.Now.ToString();
                cookie.Expires = DateTime.Now.AddHours(ExpiresTime);
                HttpContext.Current.Response.AppendCookie(cookie);
                bl = true;
            }

            return bl;
        }
    }
}
