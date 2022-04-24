using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类pointdetails 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pointdetails: Base.Entity.EntityBase<pointdetails,int>
	{
		public pointdetails()
		{
			base.CurrentModel = this;
		}
		public pointdetails(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<pointdetails, int> Bll()
		{
			 
				return BLL.pointdetails.Instance;
			 
		}
		#region Model
		private int? _userid;
		private int _tradetype;
		private int _increased;
		private int _reduced;
		private int? _points;
		private DateTime? _tradedate;
		private long _orderid;
		private string _remark;
		/// <summary>
        /// 用户id
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
        ///  类型  1.兑换礼品 2.购物奖励
		/// </summary>
		public int TradeType
		{
			set{ _tradetype=value;}
			get{return _tradetype;}
		}
		/// <summary>
        ///   增加积分
		/// </summary>
		public int Increased
		{
			set{ _increased=value;}
			get{return _increased;}
		}
		/// <summary>
        /// 减少积分
		/// </summary>
		public int Reduced
		{
			set{ _reduced=value;}
			get{return _reduced;}
		}
		/// <summary>
        /// 目前总积分
		/// </summary>
		public int? Points
		{
			set{ _points=value;}
			get{return _points;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TradeDate
		{
			set{ _tradedate=value;}
			get{return _tradedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

