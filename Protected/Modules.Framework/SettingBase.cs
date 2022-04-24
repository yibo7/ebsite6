using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modules.Framework
{
    public class SettingBase
    {
        protected   IniParser iniParser;
        public void Init(IniParser _iniParser)
        {
          
            iniParser = _iniParser;
        }

        
       
    }
}