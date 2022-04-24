using System;
namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
	/// <summary>
	/// 回答表  实体类Answers 存newscontent提问的回答
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
        /// 对人有帮助的总个数
        /// </summary>
	    public  int? GoodAsk
	    {
            set { _goodask = value; }
            get { return _goodask; }
	    }
		/// <summary>
		/// 问题ID
		/// </summary>
		public long QID
		{
			set{ _qid=value;}
			get{return _qid;}
		}
		/// <summary>
		/// 提问用户ID
		/// </summary>
		public int QUserID
		{
			set{ _quserid=value;}
			get{return _quserid;}
		}
		/// <summary>
		/// 回答用户ID
		/// </summary>
		public int AnswerUserID
		{
			set{ _answeruserid=value;}
			get{return _answeruserid;}
		}
		/// <summary>
		/// 回答内容
		/// </summary>
		public string AnswerContent
		{
			set{ _answercontent=value;}
			get{return _answercontent;}
		}
		/// <summary>
		/// 是否被采纳 1:采纳 0: 没有
		/// </summary>
		public bool IsAdoption
		{
			set{ _isadoption=value;}
			get{return _isadoption;}
		}
		/// <summary>
		/// 回复时间
		/// </summary>
		public DateTime? AnswerTime
		{
			set{ _answertime=value;}
			get{return _answertime;}
		}
		/// <summary>
		/// 是否被删除 1:删除 0:没有
		/// </summary>
		public bool IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 回复者IP
		/// </summary>
		public string AnswerIP
		{
			set{ _answerip=value;}
			get{return _answerip;}
		}
		/// <summary>
		/// 参考资料
		/// </summary>
		public string ReferBook
		{
			set{ _referbook=value;}
			get{return _referbook;}
		}
		/// <summary>
		/// 是否匿名 1:匿名 0: 不匿名.
		/// </summary>
		public bool IsAnonymity
		{
			set{ _isanonymity=value;}
			get{return _isanonymity;}
		}
		/// <summary>
		/// 回答者修改时间
		/// </summary>
		public DateTime? AnswerUpdateTime
		{
			set{ _answerupdatetime=value;}
			get{return _answerupdatetime;}
		}
		/// <summary>
		/// 本次得分
		/// </summary>
		public int? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
        /// <summary>
        /// 审核 1：通过 0：拒绝
        /// </summary>
	    public int? IsApproved
	    {
            set { _isapproved = value; }
            get { return _isapproved; }
	    }
        /// <summary>
        /// 感言
        /// </summary>
	    public string ThanksInfo
	    {
            get { return _thanksinfo; }
            set { _thanksinfo = value; }
	    }
		#endregion Model

        #region 辅助调用字段 eb_newscontent
        public string NewsTitle { get; set; }
        public int ClassID { get; set; }
        public int SiteID { get; set; }
        #endregion

    }
}

