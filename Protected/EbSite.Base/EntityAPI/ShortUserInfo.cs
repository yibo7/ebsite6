using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Security;
using EbSite.Base.Entity;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.Base.EntityAPI
{
    /// <summary>
    /// 扩展MembershipUser 实际上是表Users实体
    /// </summary>

    [Serializable]
    public class ShortUserInfo
    {
        public ShortUserInfo()
        {

        }
        public ShortUserInfo(int _uid, string _UserName, string _UserNiName, int _GroupID, string _Password)
        {
            this.UserID = _uid;
            this.UserName = _UserName;
            this.UserNiName = _UserNiName;
            this.GroupID = _GroupID;
            this.Password = _Password;
        }
        public int UserID { get; set; }
        /// <summary>
        /// 用户帐号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 昵称,也可真实姓名
        /// </summary>
        public string UserNiName { get; set; }
        /// <summary>
        /// 用户组ID
        /// </summary>
        public int GroupID { get; set; }

        public string Password { get; set; }
    }
}
