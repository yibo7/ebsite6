using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类exam_questions 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class exam_questions: Base.Entity.EntityBase<exam_questions,int>
	{
		public exam_questions()
		{
			base.CurrentModel = this;
		}
		public exam_questions(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<exam_questions, int> Bll
        //{
        //    get
        //    {
        //        return BLL.exam_questions.Instance;
        //    }
        //}
		#region Model
		private int _examid;
		private int _classid;
		private int _questionstype;
		private string _questions;
		private string _answerinput;
		private bool _answerjudge;
		private string _answera;
		private string _answerb;
		private string _answerc;
		private string _answerd;
		private string _answere;
		private string _answerf;
		private string _answerg;
		private string _rightabc;
		private string _analysis;
		private int _adddatetimeint;
		private int _adduserid;
		private string _adduserniname;
		private int _rightusercount;
		private int _errorusercount;
		private int _orderid;
		/// <summary>
		/// 
		/// </summary>
		public int ExamID
		{
			set{ _examid=value;}
			get{return _examid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ClassID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int QuestionsType
		{
			set{ _questionstype=value;}
			get{return _questionstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Questions
		{
			set{ _questions=value;}
			get{return _questions;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AnswerInput
		{
			set{ _answerinput=value;}
			get{return _answerinput;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool AnswerJudge
		{
			set{ _answerjudge=value;}
			get{return _answerjudge;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AnswerA
		{
			set{ _answera=value;}
			get{return _answera;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AnswerB
		{
			set{ _answerb=value;}
			get{return _answerb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AnswerC
		{
			set{ _answerc=value;}
			get{return _answerc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AnswerD
		{
			set{ _answerd=value;}
			get{return _answerd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AnswerE
		{
			set{ _answere=value;}
			get{return _answere;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AnswerF
		{
			set{ _answerf=value;}
			get{return _answerf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AnswerG
		{
			set{ _answerg=value;}
			get{return _answerg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RightABC
		{
			set{ _rightabc=value;}
			get{return _rightabc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Analysis
		{
			set{ _analysis=value;}
			get{return _analysis;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AddDateTimeInt
		{
			set{ _adddatetimeint=value;}
			get{return _adddatetimeint;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AddUserID
		{
			set{ _adduserid=value;}
			get{return _adduserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AddUserNiName
		{
			set{ _adduserniname=value;}
			get{return _adduserniname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int RightUserCount
		{
			set{ _rightusercount=value;}
			get{return _rightusercount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ErrorUserCount
		{
			set{ _errorusercount=value;}
			get{return _errorusercount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}


        public decimal Score { get; set; }

		#endregion Model

	}
}

