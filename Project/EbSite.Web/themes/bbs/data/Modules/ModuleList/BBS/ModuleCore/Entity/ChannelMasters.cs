using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	/// ������ ʵ����ChannelMasters ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ���ID
		/// </summary>
		public int? ChannelID
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
		/// �û�ID
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
		/// ��������
		/// </summary>
		public DateTime CreatedTime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
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

