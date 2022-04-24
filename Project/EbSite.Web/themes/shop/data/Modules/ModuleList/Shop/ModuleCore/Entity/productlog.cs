using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类productlog 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class productlog: Base.Entity.EntityBase<productlog,int>
	{
		public productlog()
		{
			base.CurrentModel = this;
		}
		public productlog(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<productlog, int> Bll()
		{
			 
				return BLL.productlog.Instance;
			 
		}
		#region Model
		private long _productid;
		private string _pnumber;
		private int? _userid;
		private string _username;
		private DateTime? _adddate;
		private string _content;
		private int? _number;
		/// <summary>
		/// 
		/// </summary>
		public long ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PNumber
		{
			set{ _pnumber=value;}
			get{return _pnumber;}
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
		public DateTime? AddDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		#endregion Model

	}
}

