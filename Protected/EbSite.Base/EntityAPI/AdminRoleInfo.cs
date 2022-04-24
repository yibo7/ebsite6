using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Base.EntityAPI
{
    [Serializable]
    public class AdminRoleInfo : EntityBase<AdminRoleInfo, int>
    {
        private string _RoleName;
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            set
            {
                _RoleName = value;
            }
            get { return _RoleName; }
        }
    }
}
