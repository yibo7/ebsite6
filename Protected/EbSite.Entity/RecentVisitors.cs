using System;
namespace EbSite.Entity
{
    /// <summary>
    /// 实体类Favorite 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class RecentVisitors
    {
        public RecentVisitors()
		{}
        #region Model
        private int _id;
        private int _userid;
        private string _username;
        private DateTime _adddatetime;
        private int _visitorid;
        private string _visitorname;
        private string _visitorniname;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 受访用户ID
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 受访用户帐号
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 受访时间
        /// </summary>
        public DateTime AddDateTime
        {
            set { _adddatetime = value; }
            get { return _adddatetime; }
        }
        /// <summary>
        /// 来访用户ID
        /// </summary>
        public int VisitorID
        {
            set { _visitorid = value; }
            get { return _visitorid; }
        }
        /// <summary>
        /// 来访用户帐号
        /// </summary>
        public string VisitorName
        {
            set { _visitorname = value; }
            get { return _visitorname; }
        }
        /// <summary>
        /// 来访用户昵称
        /// </summary>
        public string VisitorNiName
        {
            set { _visitorniname = value; }
            get { return _visitorniname; }
        }



        /// <summary>
        /// 用户头像-小
        /// </summary>
        public string AvatarSmall
        {
            get
            {
                return BLL.User.MembershipUserEb.Instance.GetAvatarFileName(this.VisitorID, 3);
            }

        }
        /// <summary>
        /// 用户头像-小
        /// </summary>
        public string AvatarMid
        {
            get
            {
                return BLL.User.MembershipUserEb.Instance.GetAvatarFileName(this.VisitorID, 2);
            }

        }
        /// <summary>
        /// 用户头像-大
        /// </summary>
        public string AvatarBig
        {
            get
            {
                return BLL.User.MembershipUserEb.Instance.GetAvatarFileName(this.VisitorID, 1);
            }

        }
        #endregion Model

        public int LastDateTimeInt { get; set; }

    }
}

