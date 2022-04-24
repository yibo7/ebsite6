using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类PromotionPriceFree 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PromotionPriceFree: Base.Entity.EntityBase<PromotionPriceFree,int>
	{
		public PromotionPriceFree()
		{
			base.CurrentModel = this;
		}
		public PromotionPriceFree(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<PromotionPriceFree, int> Bll()
		{
			 
				return BLL.PromotionPriceFree.Instance;
			 
		}
		#region Model
		private int? _promotionsid;
		private decimal? _amount;
		private bool _freightfree;
		private bool _servicefree;
		private bool _payfee;
		/// <summary>
		/// 关联表Promotions的ID
		/// </summary>
		public int? PromotionsID
		{
			set{ _promotionsid=value;}
			get{return _promotionsid;}
		}
		/// <summary>
		/// 满足金额
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 是否选择运费
		/// </summary>
		public bool FreightFree
		{
			set{ _freightfree=value;}
			get{return _freightfree;}
		}
		/// <summary>
		/// 是否选择 订单可选项产生的费用
		/// </summary>
		public bool ServiceFree
		{
			set{ _servicefree=value;}
			get{return _servicefree;}
		}
		/// <summary>
		/// 是否选择支付手续费
		/// </summary>
		public bool PayFee
		{
			set{ _payfee=value;}
			get{return _payfee;}
		}
		#endregion Model

	}
    public class PromotionPriceFreeWithName : PromotionPriceFree
    {
        public int PromotionsId { get; set; }
        public string PromotionsName { get; set; }
    }
}

