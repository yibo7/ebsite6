using System;
namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
    /// <summary>
    /// ʵ����UserHelp �û���Ϣ����
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
        /// ��������
        /// </summary>
        public int QCount
        {
            set { _qcount = value; }
            get { return _qcount; }
        }
        /// <summary>
        /// �ش�����
        /// </summary>
        public int ACount
        {
            set { _acount = value; }
            get { return _acount; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int AdoptionCount
        {
            set { _adoptioncount = value; }
            get { return _adoptioncount; }
        }
        /// <summary>
        /// ������
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
        /// ��������
        /// </summary>
        public string HelpUserCount
        {
            get
            {
                return ModuleCore.BLL.Answers.Instance.HelpUserCount(UserID);
            }
        }
        /// <summary>
        /// ϲ���ش������,������Ϊ�Ƽ���
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

        #region ��չ

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

