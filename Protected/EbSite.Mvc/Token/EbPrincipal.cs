using System;
using System.Security.Principal;

namespace EbSite.Mvc.Token
{
    public class EbPrincipal : IPrincipal
    {
        public EbPrincipal(int userID)
        {
            this.identity = new EbIdentity(userID);

        }
        public EbPrincipal(TokenInfo userInfo)
        {
            this.identity = new EbIdentity(userInfo);

        }
        public EbPrincipal(string sUserName)
        {
            this.identity = new EbIdentity(sUserName);

        }
        public EbPrincipal(int UserID, string currentUserName, DateTime dtLastLoginTime, bool IsLockOut)
        {
            this.identity = new EbIdentity(UserID, currentUserName, dtLastLoginTime, IsLockOut);
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