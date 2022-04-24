using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace EbSite.BLL.User
{
    public class EBPrincipal : IPrincipal
    {

        public EBPrincipal(int userID)
        {
            this.identity = new SiteIdentity(userID);

        }
        public EBPrincipal(string sUserName)
        {
            this.identity = new SiteIdentity(sUserName);
            
        }
        public EBPrincipal(int UserID, string currentUserName, DateTime dtLastLoginTime, bool IsLockOut)
        {
            this.identity = new SiteIdentity(UserID, currentUserName, dtLastLoginTime, IsLockOut);
        }

        /// <summary>
        /// 判断当前用户是否存在于某用户组(角色)--名称
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
       virtual public bool IsInRole(string role)
        {
            return false;
        }
       protected IIdentity identity;
        /// <summary>
        /// 当前用户身份标识
        /// </summary>
       virtual public IIdentity Identity
        {
            get
            {
                return this.identity;
            }
            set
            {
                this.identity = value;
            }
        }
    }
}
