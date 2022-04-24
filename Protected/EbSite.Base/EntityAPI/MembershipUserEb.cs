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
    public class MembershipUserEb : EntityBase<MembershipUserEb, int>
    {
        #region Model
        private string _username;
        private string _password;
        private string _emailaddress;
        private bool _isapproved;
        private bool _islockedout;
        private DateTime _createdate = DateTime.Now;
        private DateTime _lastlogindate = DateTime.Now;
        private DateTime _lastpasswordchangeddate = DateTime.Now;
        private DateTime _lastlockoutdate = DateTime.Now;
        private int _failedpasswordattemptcount;
        private DateTime _lastactivitydate = DateTime.Now;
        private int _credits;
        private string _niname;
        private string _sign;
        private string _mobilenumber;
        public int UserLevel { get; set; }
        public string IP { get; set; }
        public string RegRemark { get; set; }
        public int GroupID { get; set; }
        public int LoginCount { get; set; }
        /// <summary>
        /// 用户帐号
        /// </summary>
        public string UserName
        {
            set
            {
                _username = value;
            }
            get { return _username; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            set
            {
                _password = value;
            }
            get { return _password; }
        }
        /// <summary>
        /// email
        /// </summary>
        public string emailAddress
        {
            set
            {
                _emailaddress = value;
            }
            get { return _emailaddress; }
        }
        /// <summary>
        /// 是否通过
        /// </summary>
        public bool IsApproved
        {
            set
            {
                _isapproved = value;
            }
            get { return _isapproved; }
        }
        /// <summary>
        /// 是否已经锁定
        /// </summary>
        public bool IsLockedOut
        {
            set
            {
                _islockedout = value;
            }
            get { return _islockedout; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateDate
        {
            set
            {
                _createdate = value;
            }
            get { return _createdate; }
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginDate
        {
            set
            {
                _lastlogindate = value;
            }
            get { return _lastlogindate; }
        }
        /// <summary>
        /// 最后密码更改时间
        /// </summary>
        public DateTime LastPasswordChangedDate
        {
            set
            {
                _lastpasswordchangeddate = value;
            }
            get { return _lastpasswordchangeddate; }
        }
        /// <summary>
        /// 最后被锁定时间
        /// </summary>
        public DateTime LastLockoutDate
        {
            set
            {
                _lastlockoutdate = value;
            }
            get { return _lastlockoutdate; }
        }
        /// <summary>
        /// 错误登录密码次数
        /// </summary>
        public int FailedPasswordAttemptCount
        {
            set
            {
                _failedpasswordattemptcount = value;
            }
            get { return _failedpasswordattemptcount; }
        }
        /// <summary>
        /// 最后活动时间 可以用来实现在线用户，不过本系统采用一个单独表来记录在线用户
        /// </summary>
        public DateTime LastActivityDate
        {
            set
            {
                _lastactivitydate = value;
            }
            get { return _lastactivitydate; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int Credits
        {
            set
            {
                _credits = value;
            }
            get { return _credits; }
        }
        /// <summary>
        /// 昵称，或者在某些情况可以用来记录真实姓名
        /// </summary>
        public string NiName
        {
            set
            {
                _niname = value;
            }
            get { return _niname; }
        }
       
        /// <summary>
        /// 签名
        /// </summary>
        public string Sign
        {
            set
            {
                _sign = value;
            }
            get { return _sign; }
        }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string MobileNumber
        {
            set
            {
                _mobilenumber = value;
            }
            get { return _mobilenumber; }
        }
        #endregion Model

        #region 自定义

        public MembershipUserEb()
        {
            base.CurrentModel = this;
        }
        public MembershipUserEb(int ID)
        {
            base.id = ID;
            base.InitData(this);
            base.CurrentModel = this;
        }

        protected override EbSite.Base.BLL.BllBase<MembershipUserEb, int> Bll()
        {
            return EbSite.BLL.User.MembershipUserEb.Instance;

        }

        /// <summary>
        /// 获取用户的头像路径(不包含文件名称)
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static string GetAvatarPath(int UserID)
        {
            return EbSite.Base.Host.Instance.GetAvatarPath(UserID);
            //string UserName = UserID.ToString();
            //UserName = Utils.FormatUid(UserName);
            //string sPath = string.Format("{0}/avatars/{1}/{2}/{3}/{4}/",
            //   Core.Base.AppStartInit.UserUploadPath, UserName.Substring(0, 3), UserName.Substring(3, 2), UserName.Substring(5, 2), UserName.Substring(7, 2));

            //return sPath;
        }

        /// <summary>
        /// 获取头像的路径包括文件名
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="iSize"></param>
        /// <returns></returns>
        public static string GetAvatarFileName(int UserID, int iSize)
        {
            return EbSite.BLL.User.MembershipUserEb.Instance.GetAvatarFileName(UserID, iSize);
        }
        /// <summary>
        /// 用户头像-小
        /// </summary>
        public string AvatarSmall
        {
            get
            {
                return Host.Instance.AvatarBig(this.id);//调用头像，支付跨站，动态处理
            }

        }
        /// <summary>
        /// 用户头像-小
        /// </summary>
        public string AvatarMid
        {
            get
            {
                return Host.Instance.AvatarBig(this.id);//调用头像，支付跨站，动态处理
            }

        }
        /// <summary>
        /// 用户头像-大
        /// </summary>
        public string AvatarBig
        {
            get
            {
                return Host.Instance.AvatarBig(this.id);//调用头像，支付跨站，动态处理
            }

        }

        //public bool IsHaveAvatar
        //{
        //    get
        //    {
        //        //暂时只考虑HttpContext.Current不为空的情况
        //        if (!Equals(HttpContext.Current, null))
        //        {
        //            string sPath = "";
        //            sPath = HttpContext.Current.Server.MapPath(AvatarBig);
        //            return Core.FSO.FObject.IsExist(sPath, FsoMethod.File);
        //        }
        //        else
        //        {
        //            return true;
        //        }
               

        //    }
        //}
        public string UserLevelName //最好避免在循环中调用此属性
        {
            get
            {
               return EbSite.BLL.UserLevel.Instance.GetUserLevelName(this.UserLevel);
            }
        }
        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnline
        {
            get { return EbSite.BLL.User.UserOnline.IsOnline(this.id); }

        }

        #endregion

        /// <summary>
        /// 是否管理员,管理员ID大于0，表示是管理员
        /// </summary>
        public int ManagerID
        {

            get
            {

                return EbSite.BLL.AdminUser.GetManagerID(this.UserName);
            }
        }

        /// <summary>
        /// 重写ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.UserName;
        }
        /// <summary>
        /// 获取当前用户空间皮肤目录
        /// </summary>
        public string SpaceThemePath
        {
            get
            {
                return EbSite.BLL.SpaceSetting.Instance.GetThemePathByUserID(this.id).Trim();
            }
        }
        public string SiteUrl
        {
            get
            {
                return EbSite.Base.Host.Instance.GetUserSiteUrl(base.id);
            }
        }

        public string UserICO
        {
            get {return EbSite.Base.Host.Instance.GetAvatarFileName(this.id, 3); }
        }
        
        
    }
}
