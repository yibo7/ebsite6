using System;
namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
	/// <summary>
	/// 实体类Comment
	/// </summary>
	[Serializable]
	public class Comment: Base.Entity.EntityBase<Comment,int>
	{
		public Comment()
		{
			base.CurrentModel = this;
		}
		public Comment(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<Comment, int> Bll()
		{
			 
				return BLL.Comment.Instance;
			 
		}
		#region Model
		private int? _ansewerid;
		private string _contenttxt;
		private int? _userid;
		private DateTime? _addtime;
		private bool _isdel;
		/// <summary>
		/// 回复表中ID
		/// </summary>
		public int? AnsewerID
		{
			set{ _ansewerid=value;}
			get{return _ansewerid;}
		}
		/// <summary>
		/// 评论内容
		/// </summary>
		public string ContentTxt
		{
			set{ _contenttxt=value;}
			get{return _contenttxt;}
		}
		/// <summary>
		/// 用户iD
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 发表时间
		/// </summary>
		public DateTime? addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		#endregion Model

	}
}

