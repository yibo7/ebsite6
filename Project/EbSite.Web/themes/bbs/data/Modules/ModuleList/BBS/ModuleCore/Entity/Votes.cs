using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	///投票管理 实体类Votes 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Votes: Base.Entity.EntityBase<Votes,int>
	{
		public Votes()
		{
			base.CurrentModel = this;
		}
		public Votes(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<Votes, int> Bll
		{
			get
			{
				return BLL.Votes.Instance;
			}
		}
		#region Model
		private string _votename;
		private int? _userid;
		private string _username;
		private string _userheadimageurl;
		private string _votedescription;
		private string _voteconclusion;
		private int? _optioncount;
		private int? _optionflag;
		private int? _votecount;
		private DateTime? _createdtime;
		private string _createdip;
		private DateTime? _updatedtime;
		private DateTime? _expiredtime;
		private int? _lockflag;
		private long? _bbstopicid;
		private int? _companyid;
		/// <summary>
		/// 
		/// </summary>
		public string VoteName
		{
			set{ _votename=value;}
			get{return _votename;}
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
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserHeadImageUrl
		{
			set{ _userheadimageurl=value;}
			get{return _userheadimageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VoteDescription
		{
			set{ _votedescription=value;}
			get{return _votedescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VoteConclusion
		{
			set{ _voteconclusion=value;}
			get{return _voteconclusion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OptionCount
		{
			set{ _optioncount=value;}
			get{return _optioncount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OptionFlag
		{
			set{ _optionflag=value;}
			get{return _optionflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VoteCount
		{
			set{ _votecount=value;}
			get{return _votecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedTime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreatedIP
		{
			set{ _createdip=value;}
			get{return _createdip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdatedTime
		{
			set{ _updatedtime=value;}
			get{return _updatedtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ExpiredTime
		{
			set{ _expiredtime=value;}
			get{return _expiredtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LockFlag
		{
			set{ _lockflag=value;}
			get{return _lockflag;}
		}
		/// <summary>
		/// 投票对应的帖子ID
		/// </summary>
		public long? BBSTopicID
		{
			set{ _bbstopicid=value;}
			get{return _bbstopicid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		#endregion Model

	}
}

