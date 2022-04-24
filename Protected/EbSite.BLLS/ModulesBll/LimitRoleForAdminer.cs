using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.BLL.ModulesBll
{
    public class LimitRoleForAdminer : LimitRole<int>
    {
        public LimitRoleForAdminer(Guid ModuleID)
            : base(ModuleID)
        {
            
        }
        public override string DataFolder
        {
            get
            {
                return "LimitRoleForAdminer";
            }
        }
         /// <summary>
        /// 菜单的相对保存路径
        /// </summary>
       override public string MenuPath
        {
            get
            {
                return string.Concat(_sLimitRolePath, "/DataStore/Limits/LimitRole/");
            }
        }
    }
}
