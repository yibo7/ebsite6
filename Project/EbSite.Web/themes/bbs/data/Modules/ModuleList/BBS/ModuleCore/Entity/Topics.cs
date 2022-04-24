using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	///帖子表 实体类Topics 。(属性说明自动提取数据库字段的描述信息)
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
        private int _viewcount = 0;//浏览总次数 大于50是热帖子
        private int _replycount = 0;//回复总条数
        private int _userid=Base.Host.Instance.UserID;//发帖子人 用户ID
		private string _username=Base.Host.Instance.UserName;
        private int _ordertopflag = 0;//单个版块置顶帖子 OrderTopFlag=1  || OrderTopFlag=0取消版块置顶
        private DateTime _ordertoptime = DateTime.Now;//置顶 操作时间
        private int _ordertopmasteruserid;//置顶操用人ID
		private string _ordertopmasterusername;
        private int _recommendflag = 0;//RecommendFlag=1 推荐主题 |RecommendFlag=0取消推荐
        private DateTime _recommendtime = DateTime.Now;//推荐时操用的时间点
        private int _recommendmasteruserid = 0;//推荐人的用户ID
		private string _recommendmasterusername;
        private int _replystatusflag = 0;//回复状态 已经回复的为1 
        private int _modifystatusflag = 0;//帖子修改状态
        private int _hasimageflag = 0;//帖子内容含有图片 
		private string _topicimageurl;
        private int _isbadcount = 0;//反对的总个数 
        private int _isgoodcount = 0;//支持的总个数
        private int _conclusionflag = 0;//帖子是否关闭 0:不关闭 1:关闭
        private int _auditflag = 0;//AuditFlag=0 没有审核的帖子 
        private int _latestreplyuserid = 0;//最后回复人 ID
		private string _latestreplyusername;
        private DateTime _latestrepliedtime = DateTime.Now;//最后回复时间
        private int _goodflag = 0;//精华帖子 GoodFlag=1 ;非精华 GoodFlag=0
        private DateTime _goodtime = DateTime.Now;//成为精华帖子的时间 
		private string _gooddescription;
		private string _goodimageurl;
        private int _goodmasteruserid = 0;//操作人成为精华的用户ID
		private string _goodmasterusername;
        private int _siteordertopflag = 0;//全站,所有版块 置顶帖子 SiteOrderTopFlag =1 ||SiteOrderTopFlag =0取消全站置顶
        private DateTime _siteordertoptime = DateTime.Now;//所有版块 置顶帖子操作时间
        private int _siteordertopmasteruserid = 0;//所有版块 置顶帖子 操作人的ID
		private string _siteordertopmasterusername;
		private int? _topicflag;
		private int? _referenceid;
        private int _deleteflag = 0;//删除标志 1:删除 0:没有删除
		private DateTime _createdtime=DateTime.Now;//创建帖子时间
		private string _createdip;
		private DateTime? _updatedtime;
        private int _titleboldflag = 0;//标题加粗 0 没有加粗 1表示加粗
        private DateTime _titleboldtime = DateTime.Now;//标题加粗时间;
		private int _titlecolorflag=0;//村里变色 0 不变 1变色
		private string _titlecolorcode;
		private DateTime _titlecolortime=DateTime.Now;
		private int? _companyid;
        private int _tag = 0;//投票标志 1:开启 0：关闭
		/// <summary>
		/// 版块ID
		/// </summary>
		public int ChannelID
		{
			set{ _channelid=value;}
			get{return _channelid;}
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
		/// 帖子标题
		/// </summary>
		public string TopicTitle
		{
			set{ _topictitle=value;}
			get{return _topictitle;}
		}
		/// <summary>
		/// 帖子内容
		/// </summary>
		public string TopicContent
		{
			set{ _topiccontent=value;}
			get{return _topiccontent;}
		}
		/// <summary>
		/// 帖子描述
		/// </summary>
		public string TopicDescription
		{
			set{ _topicdescription=value;}
			get{return _topicdescription;}
		}
		/// <summary>
		/// 浏览总次数 大于50是热帖子
		/// </summary>
		public int ViewCount
		{
			set{ _viewcount=value;}
			get{return _viewcount;}
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
		///发帖子人 用户ID
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户名称
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
        /// 单个版块置顶帖子 OrderTopFlag=1  || OrderTopFlag=0取消版块置顶
		/// </summary>
		public int OrderTopFlag
		{
			set{ _ordertopflag=value;}
			get{return _ordertopflag;}
		}
		/// <summary>
        /// 置顶 操作时间
		/// </summary>
		public DateTime OrderTopTime
		{
			set{ _ordertoptime=value;}
			get{return _ordertoptime;}
		}
		/// <summary>
        /// 置顶操用人ID
		/// </summary>
		public int OrderTopMasterUserID
		{
			set{ _ordertopmasteruserid=value;}
			get{return _ordertopmasteruserid;}
		}
		/// <summary>
        /// 置顶操作人姓名
		/// </summary>
		public string OrderTopMasterUserName
		{
			set{ _ordertopmasterusername=value;}
			get{return _ordertopmasterusername;}
		}
		/// <summary>
        /// RecommendFlag=1 推荐主题 |RecommendFlag=0取消推荐
		/// </summary>
		public int RecommendFlag
		{
			set{ _recommendflag=value;}
			get{return _recommendflag;}
		}
		/// <summary>
		/// 推荐时操用的时间点
		/// </summary>
		public DateTime RecommendTime
		{
			set{ _recommendtime=value;}
			get{return _recommendtime;}
		}
		/// <summary>
		/// 推荐人的用户ID
		/// </summary>
		public int RecommendMasterUserID
		{
			set{ _recommendmasteruserid=value;}
			get{return _recommendmasteruserid;}
		}
		/// <summary>
        /// 推荐人的用户 名称
		/// </summary>
		public string RecommendMasterUserName
		{
			set{ _recommendmasterusername=value;}
			get{return _recommendmasterusername;}
		}
		/// <summary>
        /// 回复状态  已经回复的为1 帖子发了，但没有回复 为0
		/// </summary>
		public int ReplyStatusFlag
		{
			set{ _replystatusflag=value;}
			get{return _replystatusflag;}
		}
		/// <summary>
		///帖子修改状态  
		/// </summary>
		public int ModifyStatusFlag
		{
			set{ _modifystatusflag=value;}
			get{return _modifystatusflag;}
		}
		/// <summary>
		/// 帖子内容含有图片 0没有图片 1有图片
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
		/// 反对的总个数 
		/// </summary>
		public int IsBadCount
		{
			set{ _isbadcount=value;}
			get{return _isbadcount;}
		}
		/// <summary>
		/// 支持的总个数
		/// </summary>
		public int IsGoodCount
		{
			set{ _isgoodcount=value;}
			get{return _isgoodcount;}
		}
		/// <summary>
		/// 帖子是否关闭 0:不关闭 1:关闭
		/// </summary>
		public int ConclusionFlag
		{
			set{ _conclusionflag=value;}
			get{return _conclusionflag;}
		}
		/// <summary>
        /// AuditFlag=0 没有审核的帖子 
		/// </summary>
		public int AuditFlag
		{
			set{ _auditflag=value;}
			get{return _auditflag;}
		}
		/// <summary>
        /// 最后回复人 ID
		/// </summary>
		public int LatestReplyUserID
		{
			set{ _latestreplyuserid=value;}
			get{return _latestreplyuserid;}
		}
		/// <summary>
        /// 最后回复姓名
		/// </summary>
		public string LatestReplyUserName
		{
			set{ _latestreplyusername=value;}
			get{return _latestreplyusername;}
		}
		/// <summary>
		/// 最后回复时间
		/// </summary>
		public DateTime LatestRepliedTime
		{
			set{ _latestrepliedtime=value;}
			get{return _latestrepliedtime;}
		}
		/// <summary>
        /// 精华帖子 GoodFlag=1 ;非精华 GoodFlag=0
		/// </summary>
		public int GoodFlag
		{
			set{ _goodflag=value;}
			get{return _goodflag;}
		}
		/// <summary>
        /// 成为精华帖子的时间 
		/// </summary>
		public DateTime GoodTime
		{
			set{ _goodtime=value;}
			get{return _goodtime;}
		}
		/// <summary>
        /// 精华帖子备注
		/// </summary>
		public string GoodDescription
		{
			set{ _gooddescription=value;}
			get{return _gooddescription;}
		}
		/// <summary>
        /// 精华帖子图片路径
		/// </summary>
		public string GoodImageUrl
		{
			set{ _goodimageurl=value;}
			get{return _goodimageurl;}
		}
		/// <summary>
        /// 操作人成为精华的用户ID
		/// </summary>
		public int GoodMasterUserID
		{
			set{ _goodmasteruserid=value;}
			get{return _goodmasteruserid;}
		}
		/// <summary>
        /// 操作人成为精华的用户姓名
		/// </summary>
		public string GoodMasterUserName
		{
			set{ _goodmasterusername=value;}
			get{return _goodmasterusername;}
		}
		/// <summary>
        /// 全站,所有版块 置顶帖子 SiteOrderTopFlag =1 ||SiteOrderTopFlag =0取消全站置顶
		/// </summary>
		public int SiteOrderTopFlag
		{
			set{ _siteordertopflag=value;}
			get{return _siteordertopflag;}
		}
		/// <summary>
        /// 所有版块 置顶帖子操作时间
		/// </summary>
		public DateTime SiteOrderTopTime
		{
			set{ _siteordertoptime=value;}
			get{return _siteordertoptime;}
		}
		/// <summary>
        /// 所有版块 置顶帖子 操作人的ID
		/// </summary>
		public int SiteOrderTopMasterUserID
		{
			set{ _siteordertopmasteruserid=value;}
			get{return _siteordertopmasteruserid;}
		}
		/// <summary>
        /// 所有版块 置顶帖子 操作人的姓名
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
		/// 删除标志 1:删除 0:没有删除
		/// </summary>
		public int DeleteFlag
		{
			set{ _deleteflag=value;}
			get{return _deleteflag;}
		}
		/// <summary>
		/// 原创操用时间
		/// </summary>
		public DateTime CreatedTime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
		}
		/// <summary>
		/// 原创人IP
		/// </summary>
		public string CreatedIP
		{
			set{ _createdip=value;}
			get{return _createdip;}
		}
		/// <summary>
		/// 发帖子人自己修改时间
		/// </summary>
		public DateTime? UpdatedTime
		{
			set{ _updatedtime=value;}
			get{return _updatedtime;}
		}
		/// <summary>
		/// 标题加粗 0 没有加粗 1表示加粗
		/// </summary>
		public int TitleBoldFlag
		{
			set{ _titleboldflag=value;}
			get{return _titleboldflag;}
		}
		/// <summary>
		/// 标题加粗时间
		/// </summary>
		public DateTime TitleBoldTime
		{
			set{ _titleboldtime=value;}
			get{return _titleboldtime;}
		}
		/// <summary>
		/// 标题变色 0 不变 1变色
		/// </summary>
		public int TitleColorFlag
		{
			set{ _titlecolorflag=value;}
			get{return _titlecolorflag;}
		}
		/// <summary>
		/// 标题的颜色
		/// </summary>
		public string TitleColorCode
		{
			set{ _titlecolorcode=value;}
			get{return _titlecolorcode;}
		}
		/// <summary>
		/// 标题变色时间
		/// </summary>
		public DateTime TitleColorTime
		{
			set{ _titlecolortime=value;}
			get{return _titlecolortime;}
		}
		/// <summary>
		/// 公司ID
		/// </summary>
		public int? CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 投票标志 1:开启 0：关闭
		/// </summary>
		public int tag
		{
			set{ _tag=value;}
			get{return _tag;}
		}
		#endregion Model

	}
}

