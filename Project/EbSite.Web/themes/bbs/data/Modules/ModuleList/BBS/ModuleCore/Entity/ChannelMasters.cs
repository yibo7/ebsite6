using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	/// 版主表 实体类ChannelMasters 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ChannelMasters: Base.Entity.EntityBase<ChannelMasters,int>
	{
		public ChannelMasters()
		{
			base.CurrentModel = this;
		}
		public ChannelMasters(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<ChannelMasters, int> Bll
		{
			get
			{
				return BLL.ChannelMasters.Instance;
			}
		}
		#region Model
		private int? _channelid;
		private string _channelname;
		private int _userid;
		private string _username;
		private DateTime _createdtime=DateTime.Now;
		private int? _companyid;
		/// <summary>
		/// 版块ID
		/// </summary>
		public int? ChannelID
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
		/// 用户ID
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
		/// 建创日期
		/// </summary>
		public DateTime CreatedTime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
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

