using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.BLL.ModulesBll
{
    public class LimitsForUser : Limits
    {
        public LimitsForUser(Guid _ModuleID)
            : base(_ModuleID)
        {
            
        }
        override  protected string LimitsDataFile 
        { 
            get
            {
                return "/DataStore/Limits_User.txt";
            }
        }
    }
}
