using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.BLL.ModulesBll;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class MenusForUserRole : LimitRole<Guid>
    {
        /// <summary>
        /// 菜单的相对保存路径
        /// </summary>
        override public string MenuPath
        {
            get
            {
                return string.Concat(IISPath, "DataStore/MenusForUserRole/");
            }
        }
        public override string DataFolder
        {
            get
            {
                return "MenusForUserRole";
            }
        }
        public MenusForUserRole()
            : base()
        {
            
        }
       


    }
}
