using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	///������� ʵ����Channels ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ����ID
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
		/// �������
		/// </summary>
		public string ChannelName
		{
			set{ _channelname=value;}
			get{return _channelname;}
		}
		/// <summary>
		/// �����������
		/// </summary>
		public string ChannelDescription
		{
			set{ _channeldescription=value;}
			get{return _channeldescription;}
		}
		/// <summary>
		/// ���ͼ��
		/// </summary>
		public string ChannelImageUrl
		{
			set{ _channelimageurl=value;}
			get{return _channelimageurl;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int? OrderFlag
		{
			set{ _orderflag=value;}
			get{return _orderflag;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime? CreatedTime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime? UpdatedTime
		{
			set{ _updatedtime=value;}
			get{return _updatedtime;}
		}
		/// <summary>
		/// ����������
		/// </summary>
		public int TopicCount
		{
			set{ _topiccount=value;}
			get{return _topiccount;}
		}
		/// <summary>
		/// �ظ�������
		/// </summary>
		public int ReplyCount
		{
			set{ _replycount=value;}
			get{return _replycount;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public int PostCount
		{
			set{ _postcount=value;}
			get{return _postcount;}
		}
		/// <summary>
		/// �������ӵ�������
		/// </summary>
		public int? TodayPostCount
		{
			set{ _todaypostcount=value;}
			get{return _todaypostcount;}
		}
		/// <summary>
		/// ��󷢱����� ��ʱ��
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
		/// ����Ƿ������ 
		/// </summary>
		public int? ReadFlag
		{
			set{ _readflag=value;}
			get{return _readflag;}
		}
		/// <summary>
		/// �Ƿ����� д
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
		///  ��󷢱����� ��ID
		/// </summary>
		public int? LatestBBSTopicID
		{
			set{ _latestbbstopicid=value;}
			get{return _latestbbstopicid;}
		}
		/// <summary>
		/// ��󷢱����� �ı���
		/// </summary>
		public string LatestBBSTopicTitle
		{
			set{ _latestbbstopictitle=value;}
			get{return _latestbbstopictitle;}
		}
		/// <summary>
        /// ��󷢱��������û�ID
		/// </summary>
		public int? LatestBBSTopicUserID
		{
			set{ _latestbbstopicuserid=value;}
			get{return _latestbbstopicuserid;}
		}
		/// <summary>
		/// ��󷢱�����������
		/// </summary>
		public string LatestBBSTopicUserName
		{
			set{ _latestbbstopicusername=value;}
			get{return _latestbbstopicusername;}
		}
		/// <summary>
		/// ���ظ�ʱ��
		/// </summary>
		public DateTime? LatestBBSTopicRepliedTime
		{
			set{ _latestbbstopicrepliedtime=value;}
			get{return _latestbbstopicrepliedtime;}
		}
		/// <summary>
		/// ��˾ID
		/// </summary>
		public int? CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		#endregion Model

	}
}

