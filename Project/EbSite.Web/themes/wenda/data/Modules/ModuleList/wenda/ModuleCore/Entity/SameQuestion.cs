using System;
namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
	/// <summary>
	/// 实体类SameQuestion 同问 查一个问题 有多少同问。
	/// </summary>
	[Serializable]
	public class SameQuestion: Base.Entity.EntityBase<SameQuestion,int>
	{
		public SameQuestion()
		{
			base.CurrentModel = this;
		}
		public SameQuestion(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<SameQuestion, int> Bll
        //{
        //    get
        //    {
        //        return BLL.SameQuestion.Instance;
        //    }
        //}
		#region Model
		private int? _userid;
		private int? _cid;
		private DateTime? _tdate;
		/// <summary>
		/// 用户ID
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 文章ID
		/// </summary>
		public int? Cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 操作日期
		/// </summary>
		public DateTime? TDate
		{
			set{ _tdate=value;}
			get{return _tdate;}
		}
		#endregion Model

	}
}

