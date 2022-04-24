using System;
using System.Data;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using EbSite.BLL.User;
using EbSite.Data.Interface;

namespace EbSite.BLL
{

    public class SiteIdentity : IIdentity
    {
        private int userID;
        private string userName;
        private bool isLock = false;
        private DateTime lastLoginTime = DateTime.Now;

        public DateTime LastLoginTime
        {
            get
            {
                return this.lastLoginTime;
            }
            set
            {
                this.lastLoginTime = value;
            }
        }

        public bool IsLock
        {
            get
            {
                return this.isLock;
            }
            set
            {
                this.isLock = value;
            }
        }

        public int UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }
        public SiteIdentity(int UserID, string currentUserName, DateTime dtLastLoginTime, bool IsLockOut)
        {
            this.userID = UserID;
            this.userName = currentUserName;
            this.IsLock = IsLockOut;
            this.LastLoginTime = dtLastLoginTime;
        }

        /// <summary>
        /// 拓展当前Identity--用户ID
        /// </summary>
        /// <param name="currentUserID">用户ID</param>
        public SiteIdentity(int currentUserID)
        {
            
            //DataRow row = DbProviderCms.GetInstance().userp(currentUserID);
            //this.userID = (int)row["UserID"];
            //this.userName = (string)row["UserName"];
            //this.IsLock = (bool)row["IsLock"];
            //this.LastLoginTime = (DateTime)row["LastLoginTime"];

          Base.EntityAPI.MembershipUserEb md =   MembershipUserEb.Instance.GetEntity(currentUserID);

          this.userID = currentUserID;
          this.userName = md.UserName;
          this.IsLock = md.IsLockedOut;
          this.LastLoginTime = md.LastLoginDate;

            
        }
        /// <summary>
        /// 拓展当前Identity--用户账号
        /// </summary>
        /// <param name="currentUserName">用户账号</param>
        public SiteIdentity(string currentUserName)
        {
            //DataRow row = DbProviderCms.GetInstance().AdminUser_RetrieveAdmin(currentUserName);
            //this.userID = (int)row["UserID"];
            //this.userName = (string)row["UserName"];
            //this.IsLock = (bool)row["IsLock"];
            //this.LastLoginTime = (DateTime)row["LastLoginTime"];

            Base.EntityAPI.MembershipUserEb md = MembershipUserEb.Instance.GetEntity(currentUserName);

            this.userID = md.id;
            this.userName = md.UserName;
            this.IsLock = md.IsLockedOut;
            this.LastLoginTime = md.LastLoginDate;
        }
        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns></returns>
        //public int TestPassword(string password)
        //{
        //    byte[] bytes = new UnicodeEncoding().GetBytes(password);
        //    byte[] encPassword = new SHA1CryptoServiceProvider().ComputeHash(bytes);
        //   // XsAccounts.Data.User user = new XsAccounts.Data.User(PubConstant.ConnectionString);
        //    return DbProviderCms.GetInstance().AdminUser_TestPasswordAdmin(this.userID, encPassword);
        //}

        public string AuthenticationType
        {
            get
            {
                return "Custom Authentication";
            }
            set
            {
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return this.userName;
            }
        }
    }
}

