using System;
using System.Security.Principal;

namespace EbSite.Mvc.Token
{
    public class EbIdentity : IIdentity
    {
        //private string userName; 
        public DateTime LastLoginTime { get; set; }

        public bool IsLock { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }
        public string UserNiName { get; set; }
        public string Pass { get; set; }
        /// <summary>
        /// 用户组ID  5=vip 
        /// </summary>
        public int GroupID { get; set; }
         

        public EbIdentity(TokenInfo tkUser)
        {
            if (!Equals(tkUser, null))
            {
                this.UserID = tkUser.UserId;
                this.UserName = tkUser.UserName;
                this.LastLoginTime = tkUser.LastTime;
                this.UserNiName = tkUser.UserNiname;
                this.Pass = tkUser.UserNiname;
                this.GroupID = tkUser.GroupId;
            }
            //this.SessionId = sessionid;
        }

        public EbIdentity()
        {
            _IsAuthenticated = false;
        }

        public EbIdentity(int UserID, string currentUserName, DateTime dtLastLoginTime, bool IsLockOut)
        {
            this.UserID = UserID;
            this.UserName = currentUserName;
            this.IsLock = IsLockOut;
            this.LastLoginTime = dtLastLoginTime;
        }

        /// <summary>
        /// 拓展当前Identity--用户ID
        /// </summary>
        /// <param name="currentUserID">用户ID</param>
        public EbIdentity(int currentUserID)
        {

            //DataRow row = DbProviderCms.GetInstance().userp(currentUserID);
            //this.userID = (int)row["UserID"];
            //this.userName = (string)row["UserName"];
            //this.IsLock = (bool)row["IsLock"];
            //this.LastLoginTime = (DateTime)row["LastLoginTime"];

            Base.EntityAPI.MembershipUserEb md = BLL.User.MembershipUserEb.Instance.GetEntity(currentUserID);

            this.UserID = currentUserID;
            this.UserName = md.UserName;
            this.IsLock = md.IsLockedOut;
            this.LastLoginTime = md.LastLoginDate;


        }
        /// <summary>
        /// 拓展当前Identity--用户账号
        /// </summary>
        /// <param name="currentUserName">用户账号</param>
        public EbIdentity(string currentUserName)
        {

            Base.EntityAPI.MembershipUserEb md = BLL.User.MembershipUserEb.Instance.GetEntity(currentUserName);

            this.UserID = md.id;
            this.UserName = md.UserName;
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

        private bool _IsAuthenticated = true;

        public bool IsAuthenticated
        {
            get
            {
                return _IsAuthenticated;
            }
        }

        public string Name
        {
            get
            {
                return this.UserName;
            }
        }
    }
}