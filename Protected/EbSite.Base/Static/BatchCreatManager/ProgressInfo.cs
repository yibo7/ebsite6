using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Base.Static.BatchCreatManager
{
    public class ProgressInfo
    {
        private  string SPLITTER_RECORD = "{\r\r*\r\r}";
        static  string _InfoOfProgress = "";
        public  string GetProgressInfo
        {
            get
            {
                return _InfoOfProgress;
            }
        }
        
        public void BackProgressInfo(string sInfo, int CurrentProgess)
        {
            _InfoOfProgress = string.Concat(sInfo, SPLITTER_RECORD, CurrentProgess);
        }
    }
}
