using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类exam_answer 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class exam_answer: Base.Entity.EntityBase<exam_answer,int>
	{
		public exam_answer()
		{
			base.CurrentModel = this;
		}
		public exam_answer(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<exam_answer, int> Bll
        //{
        //    get
        //    {
        //        return BLL.exam_answer.Instance;
        //    }
        //}
		#region Model
		private int? _testresultid;
		private string _answer;
		private int? _userid;
		private int? _questionid;
		/// <summary>
		/// 
		/// </summary>
		public int? TestResultID
		{
			set{ _testresultid=value;}
			get{return _testresultid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Answer
		{
			set{ _answer=value;}
			get{return _answer;}
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
		public int? QuestionId
		{
			set{ _questionid=value;}
			get{return _questionid;}
		}
		#endregion Model

	}
}

