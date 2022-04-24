using System;
using System.Collections.Generic;

using System.Web;

namespace EbSite.BLL.Count.Strategy
{
    public class StrategyFactory
    {
        /// <summary>
        /// 采用不同的策略来防作弊
        /// </summary>
        /// <returns></returns>
        static public IStrategyPrevent CreateInstance()
        {
            //检测浏览器是否支持cookie
            if (Base.Configs.SysConfigs.ConfigsControl.Instance.IsUpdateHisCookieOrSession == 0)
            {
                return new CookieStrategy();
            }
            else
            {
                return new SessionStrategy();
            }

            
        }
    }
}
