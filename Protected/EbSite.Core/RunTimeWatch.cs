using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Core
{
    public class RunTimeWatch
    {
        private int mintStart;

        public void start()
        {
            mintStart = Environment.TickCount;
        }

        public long elapsed()
        {
            return Environment.TickCount - mintStart;
        } 


    }
}
