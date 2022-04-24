using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	///回复帖子表 实体类TopicReplies 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class TopicReplies: Base.Entity.EntityBase<TopicReplies,long>
	{
		public TopicReplies()
		{
			base.CurrentModel = this;
		}
		public TopicReplies(long ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<TopicReplies, long> Bll
        //{
        //    get
        //    {
        //        return BLL.TopicReplies.Instance;
        //    }
        //}
		#region Model
		private int _topicid;
		private int _userid;
		private string _username;
		private int? _isgoodcount;
		private int? _isbadcount;
		private int? _deleteflag;
		private int? _auditflag;
		private string _replycontent;
		private int? _referenceflag;
		private string _referencecontent;
		private DateTime? _createdtime;
		private string _createdip;
		private DateTime? _updatedtime;
		private int? _companyid;
		/// <summary>
		/// 回复帖子的ID
		/// </summary>
		public int TopicID
		{
			set{ _topicid=value;}
			get{return _topicid;}
		}
		/// <summary>
		/// 回复人ID
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 回复人姓名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsGoodCount
		{
			set{ _isgoodcount=value;}
			get{return _isgoodcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsBadCount
		{
			set{ _isbadcount=value;}
			get{return _isbadcount;}
		}
		/// <summary>
		/// 假删除 1:删除。
		/// </summary>
		public int? DeleteFlag
		{
			set{ _deleteflag=value;}
			get{return _deleteflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AuditFlag
		{
			set{ _auditflag=value;}
			get{return _auditflag;}
		}
		/// <summary>
		/// 回复内容
		/// </summary>
		public string ReplyContent
		{
			set{ _replycontent=value;}
			get{return _replycontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ReferenceFlag
		{
			set{ _referenceflag=value;}
			get{return _referenceflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReferenceContent
		{
			set{ _referencecontent=value;}
			get{return _referencecontent;}
		}
		/// <summary>
		/// 回复时间
		/// </summary>
		public DateTime? CreatedTime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
		}
		/// <summary>
		/// 回复人IP
		/// </summary>
		public string CreatedIP
		{
			set{ _createdip=value;}
			get{return _createdip;}
		}
		/// <summary>
		/// 回复人修改时间
		/// </summary>
		public DateTime? UpdatedTime
		{
			set{ _updatedtime=value;}
			get{return _updatedtime;}
		}
		#endregion Model

	}
}

