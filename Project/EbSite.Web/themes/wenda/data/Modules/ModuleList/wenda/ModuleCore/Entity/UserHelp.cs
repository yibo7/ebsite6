using System;
namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
    /// <summary>
    /// 实体类UserHelp 用户信息汇总
    /// </summary>
    [Serializable]
    public class UserHelp : Base.Entity.EntityBase<UserHelp, int>
    {
        public UserHelp()
        {
            base.CurrentModel = this;
        }
        public UserHelp(int ID)
        {
            base.id = ID;
            base.InitData(this);
            base.CurrentModel = this;
        }
        protected override EbSite.Base.BLL.BllBase<UserHelp, int> Bll()
        {
            
                return BLL.UserHelp.Instance;
            
        }
        #region Model
        private int _userid;
        private int _qcount;
        private int _acount;
        private int _adoptioncount;
        private string _likeaskclass;
        private long _TotalScore;
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 提问总数
        /// </summary>
        public int QCount
        {
            set { _qcount = value; }
            get { return _qcount; }
        }
        /// <summary>
        /// 回答总数
        /// </summary>
        public int ACount
        {
            set { _acount = value; }
            get { return _acount; }
        }
        /// <summary>
        /// 采纳总数
        /// </summary>
        public int AdoptionCount
        {
            set { _adoptioncount = value; }
            get { return _adoptioncount; }
        }
        /// <summary>
        /// 采纳率
        /// </summary>
        public string Accept
        {
            get
            {
                if (AdoptionCount > 0 && ACount > 0 && AdoptionCount < ACount)
                    return (AdoptionCount * 100 / ACount).ToString();
                return "0";
            }
        }
        /// <summary>
        /// 帮助人数
        /// </summary>
        public string HelpUserCount
        {
            get
            {
                return ModuleCore.BLL.Answers.Instance.HelpUserCount(UserID);
            }
        }
        /// <summary>
        /// 喜欢回答的类型,可以做为推荐用
        /// </summary>
        public string LikeAskClass
        {
            set { _likeaskclass = value; }
            get { return _likeaskclass; }
        }
        public long TotalScore
        {
            set { _TotalScore = value; }
            get { return _TotalScore; }
        }
        #endregion Model

        #region 扩展

        public string UserNiName
        {
            get
            {
                return EbSite.Base.Host.Instance.GetUserByID(UserID).NiName;
            }
        }
        public int Credits
        {
            get
            {
                return EbSite.Base.Host.Instance.GetUserByID(UserID).Credits;
            }
        }
        #endregion

    }
}

