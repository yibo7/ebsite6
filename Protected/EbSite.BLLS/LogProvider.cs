using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace EbSite.BLL
{
    public class LogProvider:Log.Ilog
    {
        public LogProvider()
        {
            errorLog = LogManager.GetLogger("ErrorLogger");
            infoLog = LogManager.GetLogger("InfoLogger");
            emailLog = LogManager.GetLogger("EmailLogger");
        }
        private  ILog errorLog;
        private  ILog infoLog;
        private  ILog emailLog;
        public void ErrorLog(string msg)
        {
            //Core.Utils.TestDebug(msg);
            errorLog.Error(msg);
        }

        public void InfoLog(string msg)
        {
            //Core.Utils.TestDebug(msg);
            infoLog.Error(msg);
        }

        public void EmailLog(string msg)
        {
            //Core.Utils.TestDebug(msg);
            emailLog.Error(msg);
        }
    }
}
