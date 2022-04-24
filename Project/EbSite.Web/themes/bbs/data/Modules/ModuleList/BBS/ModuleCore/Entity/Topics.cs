using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	///���ӱ� ʵ����Topics ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Topics: Base.Entity.EntityBase<Topics,long>
	{
		public Topics()
		{
			base.CurrentModel = this;
		}
		public Topics(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<Topics, long> Bll
		{
			get
			{
				return BLL.Topics.Instance;
			}
		}
		#region Model
		private int _channelid;
		private string _channelname;
		private string _topictitle;
		private string _topiccontent;
		private string _topicdescription;
        private int _viewcount = 0;//����ܴ��� ����50��������
        private int _replycount = 0;//�ظ�������
        private int _userid=Base.Host.Instance.UserID;//�������� �û�ID
		private string _username=Base.Host.Instance.UserName;
        private int _ordertopflag = 0;//��������ö����� OrderTopFlag=1  || OrderTopFlag=0ȡ������ö�
        private DateTime _ordertoptime = DateTime.Now;//�ö� ����ʱ��
        private int _ordertopmasteruserid;//�ö�������ID
		private string _ordertopmasterusername;
        private int _recommendflag = 0;//RecommendFlag=1 �Ƽ����� |RecommendFlag=0ȡ���Ƽ�
        private DateTime _recommendtime = DateTime.Now;//�Ƽ�ʱ���õ�ʱ���
        private int _recommendmasteruserid = 0;//�Ƽ��˵��û�ID
		private string _recommendmasterusername;
        private int _replystatusflag = 0;//�ظ�״̬ �Ѿ��ظ���Ϊ1 
        private int _modifystatusflag = 0;//�����޸�״̬
        private int _hasimageflag = 0;//�������ݺ���ͼƬ 
		private string _topicimageurl;
        private int _isbadcount = 0;//���Ե��ܸ��� 
        private int _isgoodcount = 0;//֧�ֵ��ܸ���
        private int _conclusionflag = 0;//�����Ƿ�ر� 0:���ر� 1:�ر�
        private int _auditflag = 0;//AuditFlag=0 û����˵����� 
        private int _latestreplyuserid = 0;//���ظ��� ID
		private string _latestreplyusername;
        private DateTime _latestrepliedtime = DateTime.Now;//���ظ�ʱ��
        private int _goodflag = 0;//�������� GoodFlag=1 ;�Ǿ��� GoodFlag=0
        private DateTime _goodtime = DateTime.Now;//��Ϊ�������ӵ�ʱ�� 
		private string _gooddescription;
		private string _goodimageurl;
        private int _goodmasteruserid = 0;//�����˳�Ϊ�������û�ID
		private string _goodmasterusername;
        private int _siteordertopflag = 0;//ȫվ,���а�� �ö����� SiteOrderTopFlag =1 ||SiteOrderTopFlag =0ȡ��ȫվ�ö�
        private DateTime _siteordertoptime = DateTime.Now;//���а�� �ö����Ӳ���ʱ��
        private int _siteordertopmasteruserid = 0;//���а�� �ö����� �����˵�ID
		private string _siteordertopmasterusername;
		private int? _topicflag;
		private int? _referenceid;
        private int _deleteflag = 0;//ɾ����־ 1:ɾ�� 0:û��ɾ��
		private DateTime _createdtime=DateTime.Now;//��������ʱ��
		private string _createdip;
		private DateTime? _updatedtime;
        private int _titleboldflag = 0;//����Ӵ� 0 û�мӴ� 1��ʾ�Ӵ�
        private DateTime _titleboldtime = DateTime.Now;//����Ӵ�ʱ��;
		private int _titlecolorflag=0;//�����ɫ 0 ���� 1��ɫ
		private string _titlecolorcode;
		private DateTime _titlecolortime=DateTime.Now;
		private int? _companyid;
        private int _tag = 0;//ͶƱ��־ 1:���� 0���ر�
		/// <summary>
		/// ���ID
		/// </summary>
		public int ChannelID
		{
			set{ _channelid=value;}
			get{return _channelid;}
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
		/// ���ӱ���
		/// </summary>
		public string TopicTitle
		{
			set{ _topictitle=value;}
			get{return _topictitle;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string TopicContent
		{
			set{ _topiccontent=value;}
			get{return _topiccontent;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string TopicDescription
		{
			set{ _topicdescription=value;}
			get{return _topicdescription;}
		}
		/// <summary>
		/// ����ܴ��� ����50��������
		/// </summary>
		public int ViewCount
		{
			set{ _viewcount=value;}
			get{return _viewcount;}
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
		///�������� �û�ID
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �û�����
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
        /// ��������ö����� OrderTopFlag=1  || OrderTopFlag=0ȡ������ö�
		/// </summary>
		public int OrderTopFlag
		{
			set{ _ordertopflag=value;}
			get{return _ordertopflag;}
		}
		/// <summary>
        /// �ö� ����ʱ��
		/// </summary>
		public DateTime OrderTopTime
		{
			set{ _ordertoptime=value;}
			get{return _ordertoptime;}
		}
		/// <summary>
        /// �ö�������ID
		/// </summary>
		public int OrderTopMasterUserID
		{
			set{ _ordertopmasteruserid=value;}
			get{return _ordertopmasteruserid;}
		}
		/// <summary>
        /// �ö�����������
		/// </summary>
		public string OrderTopMasterUserName
		{
			set{ _ordertopmasterusername=value;}
			get{return _ordertopmasterusername;}
		}
		/// <summary>
        /// RecommendFlag=1 �Ƽ����� |RecommendFlag=0ȡ���Ƽ�
		/// </summary>
		public int RecommendFlag
		{
			set{ _recommendflag=value;}
			get{return _recommendflag;}
		}
		/// <summary>
		/// �Ƽ�ʱ���õ�ʱ���
		/// </summary>
		public DateTime RecommendTime
		{
			set{ _recommendtime=value;}
			get{return _recommendtime;}
		}
		/// <summary>
		/// �Ƽ��˵��û�ID
		/// </summary>
		public int RecommendMasterUserID
		{
			set{ _recommendmasteruserid=value;}
			get{return _recommendmasteruserid;}
		}
		/// <summary>
        /// �Ƽ��˵��û� ����
		/// </summary>
		public string RecommendMasterUserName
		{
			set{ _recommendmasterusername=value;}
			get{return _recommendmasterusername;}
		}
		/// <summary>
        /// �ظ�״̬  �Ѿ��ظ���Ϊ1 ���ӷ��ˣ���û�лظ� Ϊ0
		/// </summary>
		public int ReplyStatusFlag
		{
			set{ _replystatusflag=value;}
			get{return _replystatusflag;}
		}
		/// <summary>
		///�����޸�״̬  
		/// </summary>
		public int ModifyStatusFlag
		{
			set{ _modifystatusflag=value;}
			get{return _modifystatusflag;}
		}
		/// <summary>
		/// �������ݺ���ͼƬ 0û��ͼƬ 1��ͼƬ
		/// </summary>
		public int HasImageFlag
		{
			set{ _hasimageflag=value;}
			get{return _hasimageflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TopicImageUrl
		{
			set{ _topicimageurl=value;}
			get{return _topicimageurl;}
		}
		/// <summary>
		/// ���Ե��ܸ��� 
		/// </summary>
		public int IsBadCount
		{
			set{ _isbadcount=value;}
			get{return _isbadcount;}
		}
		/// <summary>
		/// ֧�ֵ��ܸ���
		/// </summary>
		public int IsGoodCount
		{
			set{ _isgoodcount=value;}
			get{return _isgoodcount;}
		}
		/// <summary>
		/// �����Ƿ�ر� 0:���ر� 1:�ر�
		/// </summary>
		public int ConclusionFlag
		{
			set{ _conclusionflag=value;}
			get{return _conclusionflag;}
		}
		/// <summary>
        /// AuditFlag=0 û����˵����� 
		/// </summary>
		public int AuditFlag
		{
			set{ _auditflag=value;}
			get{return _auditflag;}
		}
		/// <summary>
        /// ���ظ��� ID
		/// </summary>
		public int LatestReplyUserID
		{
			set{ _latestreplyuserid=value;}
			get{return _latestreplyuserid;}
		}
		/// <summary>
        /// ���ظ�����
		/// </summary>
		public string LatestReplyUserName
		{
			set{ _latestreplyusername=value;}
			get{return _latestreplyusername;}
		}
		/// <summary>
		/// ���ظ�ʱ��
		/// </summary>
		public DateTime LatestRepliedTime
		{
			set{ _latestrepliedtime=value;}
			get{return _latestrepliedtime;}
		}
		/// <summary>
        /// �������� GoodFlag=1 ;�Ǿ��� GoodFlag=0
		/// </summary>
		public int GoodFlag
		{
			set{ _goodflag=value;}
			get{return _goodflag;}
		}
		/// <summary>
        /// ��Ϊ�������ӵ�ʱ�� 
		/// </summary>
		public DateTime GoodTime
		{
			set{ _goodtime=value;}
			get{return _goodtime;}
		}
		/// <summary>
        /// �������ӱ�ע
		/// </summary>
		public string GoodDescription
		{
			set{ _gooddescription=value;}
			get{return _gooddescription;}
		}
		/// <summary>
        /// ��������ͼƬ·��
		/// </summary>
		public string GoodImageUrl
		{
			set{ _goodimageurl=value;}
			get{return _goodimageurl;}
		}
		/// <summary>
        /// �����˳�Ϊ�������û�ID
		/// </summary>
		public int GoodMasterUserID
		{
			set{ _goodmasteruserid=value;}
			get{return _goodmasteruserid;}
		}
		/// <summary>
        /// �����˳�Ϊ�������û�����
		/// </summary>
		public string GoodMasterUserName
		{
			set{ _goodmasterusername=value;}
			get{return _goodmasterusername;}
		}
		/// <summary>
        /// ȫվ,���а�� �ö����� SiteOrderTopFlag =1 ||SiteOrderTopFlag =0ȡ��ȫվ�ö�
		/// </summary>
		public int SiteOrderTopFlag
		{
			set{ _siteordertopflag=value;}
			get{return _siteordertopflag;}
		}
		/// <summary>
        /// ���а�� �ö����Ӳ���ʱ��
		/// </summary>
		public DateTime SiteOrderTopTime
		{
			set{ _siteordertoptime=value;}
			get{return _siteordertoptime;}
		}
		/// <summary>
        /// ���а�� �ö����� �����˵�ID
		/// </summary>
		public int SiteOrderTopMasterUserID
		{
			set{ _siteordertopmasteruserid=value;}
			get{return _siteordertopmasteruserid;}
		}
		/// <summary>
        /// ���а�� �ö����� �����˵�����
		/// </summary>
		public string SiteOrderTopMasterUserName
		{
			set{ _siteordertopmasterusername=value;}
			get{return _siteordertopmasterusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TopicFlag
		{
			set{ _topicflag=value;}
			get{return _topicflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ReferenceID
		{
			set{ _referenceid=value;}
			get{return _referenceid;}
		}
		/// <summary>
		/// ɾ����־ 1:ɾ�� 0:û��ɾ��
		/// </summary>
		public int DeleteFlag
		{
			set{ _deleteflag=value;}
			get{return _deleteflag;}
		}
		/// <summary>
		/// ԭ������ʱ��
		/// </summary>
		public DateTime CreatedTime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
		}
		/// <summary>
		/// ԭ����IP
		/// </summary>
		public string CreatedIP
		{
			set{ _createdip=value;}
			get{return _createdip;}
		}
		/// <summary>
		/// ���������Լ��޸�ʱ��
		/// </summary>
		public DateTime? UpdatedTime
		{
			set{ _updatedtime=value;}
			get{return _updatedtime;}
		}
		/// <summary>
		/// ����Ӵ� 0 û�мӴ� 1��ʾ�Ӵ�
		/// </summary>
		public int TitleBoldFlag
		{
			set{ _titleboldflag=value;}
			get{return _titleboldflag;}
		}
		/// <summary>
		/// ����Ӵ�ʱ��
		/// </summary>
		public DateTime TitleBoldTime
		{
			set{ _titleboldtime=value;}
			get{return _titleboldtime;}
		}
		/// <summary>
		/// �����ɫ 0 ���� 1��ɫ
		/// </summary>
		public int TitleColorFlag
		{
			set{ _titlecolorflag=value;}
			get{return _titlecolorflag;}
		}
		/// <summary>
		/// �������ɫ
		/// </summary>
		public string TitleColorCode
		{
			set{ _titlecolorcode=value;}
			get{return _titlecolorcode;}
		}
		/// <summary>
		/// �����ɫʱ��
		/// </summary>
		public DateTime TitleColorTime
		{
			set{ _titlecolortime=value;}
			get{return _titlecolortime;}
		}
		/// <summary>
		/// ��˾ID
		/// </summary>
		public int? CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// ͶƱ��־ 1:���� 0���ر�
		/// </summary>
		public int tag
		{
			set{ _tag=value;}
			get{return _tag;}
		}
		#endregion Model

	}
}

