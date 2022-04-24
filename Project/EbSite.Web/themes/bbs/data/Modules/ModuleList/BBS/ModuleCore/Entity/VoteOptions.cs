using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	/// 实体类VoteOptions 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class VoteOptions: Base.Entity.EntityBase<VoteOptions,int>
	{
		public VoteOptions()
		{
			base.CurrentModel = this;
		}
		public VoteOptions(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<VoteOptions, int> Bll
		{
			get
			{
				return BLL.VoteOptions.Instance;
			}
		}
		#region Model
		private int? _voteid;
		private string _optionname;
		private int? _votecount;
		private decimal? _votepercent;
		private DateTime? _createdtime;
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
		public string OptionName
		{
			set{ _optionname=value;}
			get{return _optionname;}
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
		public decimal? VotePercent
		{
			set{ _votepercent=value;}
			get{return _votepercent;}
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
		public int? CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		#endregion Model

	}
}

