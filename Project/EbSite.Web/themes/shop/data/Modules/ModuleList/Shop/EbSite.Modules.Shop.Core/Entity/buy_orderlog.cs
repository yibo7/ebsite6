using System;
namespace EbSite.Modules.Shop.Core.Entity
{
	/// <summary>
	/// 实体类buy_orderlog 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public class buy_orderlog : Base.Entity.EntityBase<buy_orderlog, int>
	{
		public buy_orderlog()
		{
			base.CurrentModel = this;
		}
		#region Model
		private long _orderid;
		private DateTime? _opdate;
		private int? _opuserid;
		private string _opusername;
		private int? _optype;
		private string _opctent;
		/// <summary>
		/// 
		/// </summary>
		public long OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OpDate
		{
			set{ _opdate=value;}
			get{return _opdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OpUserId
		{
			set{ _opuserid=value;}
			get{return _opuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OpUserName
		{
			set{ _opusername=value;}
			get{return _opusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OpType
		{
			set{ _optype=value;}
			get{return _optype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OpCtent
		{
			set{ _opctent=value;}
			get{return _opctent;}
		}
		#endregion Model

	}
}

