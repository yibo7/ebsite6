using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbSite.Log
{
    public interface Ilog
    {
        void ErrorLog(string msg);
        void InfoLog(string msg);
        void EmailLog(string msg);
    }
}
