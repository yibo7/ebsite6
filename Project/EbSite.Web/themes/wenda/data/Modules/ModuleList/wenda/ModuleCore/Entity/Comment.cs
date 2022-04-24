using System;
namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
	/// <summary>
	/// ʵ����Comment
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
		/// �ظ�����ID
		/// </summary>
		public int? AnsewerID
		{
			set{ _ansewerid=value;}
			get{return _ansewerid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string ContentTxt
		{
			set{ _contenttxt=value;}
			get{return _contenttxt;}
		}
		/// <summary>
		/// �û�iD
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime? addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// �Ƿ�ɾ��
		/// </summary>
		public bool IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		#endregion Model

	}
}

