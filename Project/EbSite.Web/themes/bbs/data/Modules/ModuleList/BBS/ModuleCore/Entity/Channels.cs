using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	///版块描述 实体类Channels 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Channels: Base.Entity.EntityBase<Channels,int>
	{
		public Channels()
		{
			base.CurrentModel = this;
		}
		public Channels(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<Channels, int> Bll
		{
			get
			{
				return BLL.Channels.Instance;
			}
		}
		#region Model
		private string _channelname;
		private string _channeldescription;
		private string _channelimageurl;
		private int? _orderflag;
		private DateTime? _createdtime;
		private DateTime? _updatedtime;
		private int _topiccount;
		private int _replycount;
		private int _postcount;
		private int? _todaypostcount;
		private DateTime? _satisticstime;
		private int? _channelflag;
		private int? _readflag;
		private int? _writeflag;
		private int? _channellinkflag;
		private string _channellinkurl;
		private int? _latestbbstopicid;
		private string _latestbbstopictitle;
		private int? _latestbbstopicuserid;
		private string _latestbbstopicusername;
		private DateTime? _latestbbstopicrepliedtime;
		private int? _companyid;
	    protected int _parentid;
        /// <summary>
        /// 父类ID
        /// </summary>
	    public int ParentID
	    {
	        get
	        {
	            return _parentid;
	        }
            set
            {
                _parentid = value;
            }
	    }
		/// <summary>
		/// 版块名称
		/// </summary>
		public string ChannelName
		{
			set{ _channelname=value;}
			get{return _channelname;}
		}
		/// <summary>
		/// 版块描述内容
		/// </summary>
		public string ChannelDescription
		{
			set{ _channeldescription=value;}
			get{return _channeldescription;}
		}
		/// <summary>
		/// 版块图标
		/// </summary>
		public string ChannelImageUrl
		{
			set{ _channelimageurl=value;}
			get{return _channelimageurl;}
		}
		/// <summary>
		/// 排序ID
		/// </summary>
		public int? OrderFlag
		{
			set{ _orderflag=value;}
			get{return _orderflag;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreatedTime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
		}
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime? UpdatedTime
		{
			set{ _updatedtime=value;}
			get{return _updatedtime;}
		}
		/// <summary>
		/// 帖子总条数
		/// </summary>
		public int TopicCount
		{
			set{ _topiccount=value;}
			get{return _topiccount;}
		}
		/// <summary>
		/// 回复总条数
		/// </summary>
		public int ReplyCount
		{
			set{ _replycount=value;}
			get{return _replycount;}
		}
		/// <summary>
		/// 主题总数
		/// </summary>
		public int PostCount
		{
			set{ _postcount=value;}
			get{return _postcount;}
		}
		/// <summary>
		/// 今日帖子的总数量
		/// </summary>
		public int? TodayPostCount
		{
			set{ _todaypostcount=value;}
			get{return _todaypostcount;}
		}
		/// <summary>
		/// 最后发表主题 的时间
		/// </summary>
		public DateTime? SatisticsTime
		{
			set{ _satisticstime=value;}
			get{return _satisticstime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ChannelFlag
		{
			set{ _channelflag=value;}
			get{return _channelflag;}
		}
		/// <summary>
		/// 版块是否允许读 
		/// </summary>
		public int? ReadFlag
		{
			set{ _readflag=value;}
			get{return _readflag;}
		}
		/// <summary>
		/// 是否允许 写
		/// </summary>
		public int? WriteFlag
		{
			set{ _writeflag=value;}
			get{return _writeflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ChannelLinkFlag
		{
			set{ _channellinkflag=value;}
			get{return _channellinkflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChannelLinkUrl
		{
			set{ _channellinkurl=value;}
			get{return _channellinkurl;}
		}
		/// <summary>
		///  最后发表主题 的ID
		/// </summary>
		public int? LatestBBSTopicID
		{
			set{ _latestbbstopicid=value;}
			get{return _latestbbstopicid;}
		}
		/// <summary>
		/// 最后发表主题 的标题
		/// </summary>
		public string LatestBBSTopicTitle
		{
			set{ _latestbbstopictitle=value;}
			get{return _latestbbstopictitle;}
		}
		/// <summary>
        /// 最后发表主题人用户ID
		/// </summary>
		public int? LatestBBSTopicUserID
		{
			set{ _latestbbstopicuserid=value;}
			get{return _latestbbstopicuserid;}
		}
		/// <summary>
		/// 最后发表主题人姓名
		/// </summary>
		public string LatestBBSTopicUserName
		{
			set{ _latestbbstopicusername=value;}
			get{return _latestbbstopicusername;}
		}
		/// <summary>
		/// 最后回复时间
		/// </summary>
		public DateTime? LatestBBSTopicRepliedTime
		{
			set{ _latestbbstopicrepliedtime=value;}
			get{return _latestbbstopicrepliedtime;}
		}
		/// <summary>
		/// 公司ID
		/// </summary>
		public int? CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		#endregion Model

	}
}

