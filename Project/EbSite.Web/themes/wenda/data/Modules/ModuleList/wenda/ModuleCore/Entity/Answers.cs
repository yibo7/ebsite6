using System;
namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
	/// <summary>
	/// �ش��  ʵ����Answers ��newscontent���ʵĻش�
	/// </summary>
	[Serializable]
	public class Answers: Base.Entity.EntityBase<Answers,int>
	{
		public Answers()
		{
			base.CurrentModel = this;
		}
		public Answers(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<Answers, int> Bll()
		{
			 
				return BLL.Answers.Instance;
			 
		}
		#region Model
		private long _qid;
		private int _quserid;
		private int _answeruserid;
		private string _answercontent;
		private bool _isadoption;
		private DateTime? _answertime;
		private bool _isdel;
		private string _answerip;
		private string _referbook;
		private bool _isanonymity;
		private DateTime? _answerupdatetime;
		private int? _score;
	    private int? _goodask;
	    private int? _isapproved;
	    private string _thanksinfo;
        /// <summary>
        /// �����а������ܸ���
        /// </summary>
	    public  int? GoodAsk
	    {
            set { _goodask = value; }
            get { return _goodask; }
	    }
		/// <summary>
		/// ����ID
		/// </summary>
		public long QID
		{
			set{ _qid=value;}
			get{return _qid;}
		}
		/// <summary>
		/// �����û�ID
		/// </summary>
		public int QUserID
		{
			set{ _quserid=value;}
			get{return _quserid;}
		}
		/// <summary>
		/// �ش��û�ID
		/// </summary>
		public int AnswerUserID
		{
			set{ _answeruserid=value;}
			get{return _answeruserid;}
		}
		/// <summary>
		/// �ش�����
		/// </summary>
		public string AnswerContent
		{
			set{ _answercontent=value;}
			get{return _answercontent;}
		}
		/// <summary>
		/// �Ƿ񱻲��� 1:���� 0: û��
		/// </summary>
		public bool IsAdoption
		{
			set{ _isadoption=value;}
			get{return _isadoption;}
		}
		/// <summary>
		/// �ظ�ʱ��
		/// </summary>
		public DateTime? AnswerTime
		{
			set{ _answertime=value;}
			get{return _answertime;}
		}
		/// <summary>
		/// �Ƿ�ɾ�� 1:ɾ�� 0:û��
		/// </summary>
		public bool IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// �ظ���IP
		/// </summary>
		public string AnswerIP
		{
			set{ _answerip=value;}
			get{return _answerip;}
		}
		/// <summary>
		/// �ο�����
		/// </summary>
		public string ReferBook
		{
			set{ _referbook=value;}
			get{return _referbook;}
		}
		/// <summary>
		/// �Ƿ����� 1:���� 0: ������.
		/// </summary>
		public bool IsAnonymity
		{
			set{ _isanonymity=value;}
			get{return _isanonymity;}
		}
		/// <summary>
		/// �ش����޸�ʱ��
		/// </summary>
		public DateTime? AnswerUpdateTime
		{
			set{ _answerupdatetime=value;}
			get{return _answerupdatetime;}
		}
		/// <summary>
		/// ���ε÷�
		/// </summary>
		public int? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
        /// <summary>
        /// ��� 1��ͨ�� 0���ܾ�
        /// </summary>
	    public int? IsApproved
	    {
            set { _isapproved = value; }
            get { return _isapproved; }
	    }
        /// <summary>
        /// ����
        /// </summary>
	    public string ThanksInfo
	    {
            get { return _thanksinfo; }
            set { _thanksinfo = value; }
	    }
		#endregion Model

        #region ���������ֶ� eb_newscontent
        public string NewsTitle { get; set; }
        public int ClassID { get; set; }
        public int SiteID { get; set; }
        #endregion

    }
}

