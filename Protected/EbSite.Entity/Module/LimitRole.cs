using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity.Module
{
    [Serializable]
    public class LimitRoleInfo<LimitType> : XmlEntityBase<Guid>
    {
        private LimitType _LimitID;
        private long _RoleID;
        /// <summary>
        /// 权限ID
        /// </summary>
        public LimitType LimitID
        {
            get
            {
                return _LimitID;
            }
            set
            {
                _LimitID = value;
            }
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        
        public long RoleID
        {
            get
            {
                return _RoleID;
            }
            set
            {
                _RoleID = value;
            }
        }
    }
}
