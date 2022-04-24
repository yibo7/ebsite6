using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base;

namespace EbSite.BLL
{
    public class TimeOutExecutePost : TimeOutBase
    {
        static public readonly TimeOutExecutePost Instance = new TimeOutExecutePost();
        protected override string KeyName
        {
            get { return "TimeOutExecutePost"; }

        }
        /// <summary>
        /// 时间间隔(分钟)
        /// </summary>
        override public int TimeSpan
        {
            get
            {
                return 1;

            }

        }

    }
}
