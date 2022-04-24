using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类requestgroup 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class requestgroup: Base.Entity.EntityBase<requestgroup,int>
	{
		public requestgroup()
		{
			
		}

		#region Model
		private int? _userid;
		private string _username;
		private int? _productid;
		private decimal? _requestprice;
		private DateTime? _adddatetime;
		private string _mobile;
		private string _email;
		private int? _isnotice;
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
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? RequestPrice
		{
			set{ _requestprice=value;}
			get{return _requestprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddDateTime
		{
			set{ _adddatetime=value;}
			get{return _adddatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsNotice
		{
			set{ _isnotice=value;}
			get{return _isnotice;}
		}
		#endregion Model

	}
}

