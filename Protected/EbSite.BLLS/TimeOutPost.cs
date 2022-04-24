using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base;

namespace EbSite.BLL
{
    public class TimeOutPost : TimeOutBase
    {
        static public readonly TimeOutPost Instance = new TimeOutPost();
        protected override string KeyName
        {
            get { return "timeoutpost"; }

        }
        
    }
}
