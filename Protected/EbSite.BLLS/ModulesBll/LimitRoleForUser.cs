using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.BLL.ModulesBll
{
    public class LimitRoleForUser : LimitRole<int>
    {
        public LimitRoleForUser(Guid ModuleID)
            : base(ModuleID)
        {
            
        }
        public override string DataFolder
        {
            get
            {
                return "LimitRoleForUser";
            }
        }
         /// <summary>
        /// 菜单的相对保存路径
        /// </summary>
       override public string MenuPath
        {
            get
            {
                return string.Concat(_sLimitRolePath, "/DataStore/Limits/MenusForUser/");
            }
        }
    }
}
