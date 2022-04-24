using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类Coupons 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Coupons: Base.Entity.EntityBase<Coupons,int>
	{
		public Coupons()
		{
			base.CurrentModel = this;
		}
		public Coupons(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        protected override EbSite.Base.BLL.BllBase<Coupons, int> Bll()
        {
            
                return BLL.Coupons.Instance;
            
        }
		#region Model
		private string _couponname;
		private DateTime? _enddatetime;
		private decimal? _amount;
		private decimal? _discountprice;
		private string _description;
		private int? _sentcount;
		private int? _usedcount;
		private int _needpoint;
		/// <summary>
		/// 优惠券名称
		/// </summary>
		public string CouponName
		{
			set{ _couponname=value;}
			get{return _couponname;}
		}
		/// <summary>
		/// 结束日期
		/// </summary>
		public DateTime? EndDateTime
		{
			set{ _enddatetime=value;}
			get{return _enddatetime;}
		}
		/// <summary>
		/// 满足金额 满足金额只能是数值，0.01-10000000，且不能超过2位小数
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 可抵扣金额 可抵扣金额只能是数值，0.01-10000000，且不能超过2位小数
		/// </summary>
		public decimal? DiscountPrice
		{
			set{ _discountprice=value;}
			get{return _discountprice;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 导出数量 导出数量只能是数字，必须大于等于O,0表示不导出
		/// </summary>
		public int? SentCount
		{
			set{ _sentcount=value;}
			get{return _sentcount;}
		}
		/// <summary>
		/// 已经使用数量
		/// </summary>
		public int? UsedCount
		{
			set{ _usedcount=value;}
			get{return _usedcount;}
		}
		/// <summary>
		/// 兑换需积分 兑换所需积分只能是数字，必须大于等于O,0表示不能兑换
		/// </summary>
		public int NeedPoint
		{
			set{ _needpoint=value;}
			get{return _needpoint;}
		}
		#endregion Model

	}
}

