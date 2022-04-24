using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类exam_testuser 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class exam_testresult: Base.Entity.EntityBase<exam_testresult,int>
	{
		public exam_testresult()
		{
			base.CurrentModel = this;
		}
        public exam_testresult(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<exam_testuser, int> Bll
        //{
        //    get
        //    {
        //        return BLL.exam_testuser.Instance;
        //    }
        //}
		#region Model
		private int? _examid;
		private int? _userid;
		private string _userniname;
		private int? _score;
		private int? _scorelevel;
		private string _comment;
		private int? _adddatetimeint;
		private DateTime? _adddatetime;
		/// <summary>
		/// 
		/// </summary>
		public int? ExamID
		{
			set{ _examid=value;}
			get{return _examid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserNiName
		{
			set{ _userniname=value;}
			get{return _userniname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ScoreLevel
		{
			set{ _scorelevel=value;}
			get{return _scorelevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AddDateTimeInt
		{
			set{ _adddatetimeint=value;}
			get{return _adddatetimeint;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddDateTime
		{
			set{ _adddatetime=value;}
			get{return _adddatetime;}
		}
		#endregion Model

	}
}

