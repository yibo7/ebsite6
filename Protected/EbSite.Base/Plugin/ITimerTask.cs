using System;
using System.Collections.Generic;
using EbSite.Base.EntityAPI;
using EbSite.Base.Plugin.Base;
using EbSite.Base.Static;

namespace EbSite.Base.Plugin
{
    public interface ITimerTask : IProvider
    {
       /// <summary>
       /// 要定时执行的任务
       /// </summary>
        void CallTask();
        /// <summary>
        /// 时间间隔类型，支持分钟，小时，天，不支持秒
        /// </summary>
        /// <value>The type of the time span.</value>
        ETimeSpanModel TimeSpanType { get;  }

        /// <summary>
        /// 时间，如1分，1天
        /// </summary>
        /// <value>The times.</value>
        int Times { get; }

    }
}

