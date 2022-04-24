using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	///�ظ����ӱ� ʵ����TopicReplies ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �ظ����ӵ�ID
		/// </summary>
		public int TopicID
		{
			set{ _topicid=value;}
			get{return _topicid;}
		}
		/// <summary>
		/// �ظ���ID
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �ظ�������
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
		/// ��ɾ�� 1:ɾ����
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
		/// �ظ�����
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
		/// �ظ�ʱ��
		/// </summary>
		public DateTime? CreatedTime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
		}
		/// <summary>
		/// �ظ���IP
		/// </summary>
		public string CreatedIP
		{
			set{ _createdip=value;}
			get{return _createdip;}
		}
		/// <summary>
		/// �ظ����޸�ʱ��
		/// </summary>
		public DateTime? UpdatedTime
		{
			set{ _updatedtime=value;}
			get{return _updatedtime;}
		}
		#endregion Model

	}
}

