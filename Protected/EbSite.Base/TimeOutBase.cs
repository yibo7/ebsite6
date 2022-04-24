using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Core.Strings;

namespace EbSite.Base
{
    abstract public class TimeOutBase
    {
        private const string sCookieHeader = "otb";
        public void Init()
        {
            if (TimeSpan > 0)
            {
                string sT = EbSite.Core.Utils.GetSingleVlue(sCookieHeader, KeyName);
                if (string.IsNullOrEmpty(sT))
                {
                    HttpCookie cookie = new HttpCookie(sCookieHeader);
                    cookie.Values[KeyName] = DateTime.Now.AddYears(-1).ToString(); //置为过期
                    cookie.Expires = DateTime.Now.AddYears(1);
                    HttpContext.Current.Response.AppendCookie(cookie);
                }
             
            }

        }
        public void UpdateTime()
        {
            if (TimeSpan > 0)
            {
                HttpCookie cookie = new HttpCookie(sCookieHeader);
                DateTime dt = DateTime.Now.AddMinutes(TimeSpan);
                cookie.Values[KeyName] = dt.ToString();
                cookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.AppendCookie(cookie);
            }
          
        }
        protected abstract string KeyName { get; }
        /// <summary>
        /// 时间间隔(分钟)
        /// </summary>
        virtual public int TimeSpan
        {
            get
            {
                return ConfigsControl.Instance.PostTimeOut;
                
            }

        }

        private DateTime GetLastTime
        {
            get
            {
                string sT = EbSite.Core.Utils.GetSingleVlue(sCookieHeader, KeyName);
                if (!string.IsNullOrEmpty(sT))
                {
                    return DateTime.Parse(sT);
                }
                return DateTime.Now.AddYears(-1); //置为过期
            }
        }
        /// <summary>
        /// 是否允许执行
        /// </summary>
        public bool IsAllow
        {
            get
            {
                if (TimeSpan > 0)
                {
                    if (DateTime.Compare(DateTime.Now, GetLastTime) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;

            }
        }
    }
}
