using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类CouponItems 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class CouponItems: Base.Entity.EntityBase<CouponItems,int>
	{
		public CouponItems()
		{
			base.CurrentModel = this;
		}
		public CouponItems(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        protected override EbSite.Base.BLL.BllBase<CouponItems, int> Bll()
        {
           
                return BLL.CouponItems.Instance;
            
        }
		#region Model
		private int? _couponid;
		private string _lotnumber;
		private string _claimcode;
		private int? _userid;
		private string _emailaddress;
		private DateTime? _adddatetime;
	    private bool _status;
		/// <summary>
		/// Coupons对应的ID
		/// </summary>
		public int? CouponId
		{
			set{ _couponid=value;}
			get{return _couponid;}
		}
		/// <summary>
		/// 优惠券批次号
		/// </summary>
		public string LotNumber
		{
			set{ _lotnumber=value;}
			get{return _lotnumber;}
		}
		/// <summary>
		/// 优惠券号码
		/// </summary>
		public string ClaimCode
		{
			set{ _claimcode=value;}
			get{return _claimcode;}
		}
		/// <summary>
		/// 可以使用的用户ID
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 可以使用的用户Email
		/// </summary>
		public string EmailAddress
		{
			set{ _emailaddress=value;}
			get{return _emailaddress;}
		}
		/// <summary>
		/// 生成时间
		/// </summary>
		public DateTime? AddDateTime
		{
			set{ _adddatetime=value;}
			get{return _adddatetime;}
		}

        /// <summary>
        /// 0.未使用 1.使用
        /// </summary>
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }
		#endregion Model

        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string CouponName
        {
            set; get;
        }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDateTime
        {
            set;
            get;
        }
        /// <summary>
        /// 满足金额 满足金额只能是数值，0.01-10000000，且不能超过2位小数
        /// </summary>
        public decimal? Amount
        {
            set;
            get;
        }
        /// <summary>
        /// 可抵扣金额 可抵扣金额只能是数值，0.01-10000000，且不能超过2位小数
        /// </summary>
        public decimal? DiscountPrice
        {
            set;
            get;
        }
       

	}
}

