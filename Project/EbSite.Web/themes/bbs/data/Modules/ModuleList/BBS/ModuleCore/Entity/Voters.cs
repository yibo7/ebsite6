using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	/// 实体类Voters 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Voters: Base.Entity.EntityBase<Voters,int>
	{
		public Voters()
		{
			base.CurrentModel = this;
		}
		public Voters(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<Voters, int> Bll
		{
			get
			{
				return BLL.Voters.Instance;
			}
		}
		#region Model
		private int? _voteid;
		private string _votecontent;
		private int? _userid;
		private string _username;
		private string _userheadimageurl;
		private DateTime? _createdtime;
		private string _createdip;
		private int? _companyid;
		/// <summary>
		/// 
		/// </summary>
		public int? VoteID
		{
			set{ _voteid=value;}
			get{return _voteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VoteContent
		{
			set{ _votecontent=value;}
			get{return _votecontent;}
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
		public int? CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		#endregion Model

	}
}

