using System;
using System.Collections.Generic;

using System.Web;

namespace EbSite.BLL.Count.Strategy
{
    public class SessionStrategy : IStrategyPrevent
    {
        private string SessionStrategyKey = "SessionStrategyKey";
        public bool IsAllowAdd()
        {
            bool bl = false;

            if (object.Equals(HttpContext.Current.Session[SessionStrategyKey], null))
            {
                bl = true;

                HttpContext.Current.Session[SessionStrategyKey] = new object();
            }

            return bl;
        }
    }
}
