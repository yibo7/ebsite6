using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类exam_questionsclass 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class exam_questionsclass: Base.Entity.EntityBase<exam_questionsclass,int>
	{
		public exam_questionsclass()
		{
			base.CurrentModel = this;
		}
		public exam_questionsclass(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<exam_questionsclass, int> Bll
        //{
        //    get
        //    {
        //        return BLL.exam_questionsclass.Instance;
        //    }
        //}
		#region Model
		private int? _examid;
		private string _classname;
		private int? _adduserid;
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
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AddUserID
		{
			set{ _adduserid=value;}
			get{return _adduserid;}
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

