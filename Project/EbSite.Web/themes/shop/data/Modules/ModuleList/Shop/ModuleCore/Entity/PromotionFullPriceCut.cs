using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类PromotionFullPriceCut 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PromotionFullPriceCut: Base.Entity.EntityBase<PromotionFullPriceCut,int>
	{
		public PromotionFullPriceCut()
		{
			base.CurrentModel = this;
		}
		public PromotionFullPriceCut(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<PromotionFullPriceCut, int> Bll()
		{
			 
				return BLL.PromotionFullPriceCut.Instance;
			 
		}
		#region Model
		private int? _promotionsid;
		private decimal? _amount;
		private int _discountvalue;
		private int _valuetype;
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
		/// (ValueType=0优惠金额)/(ValueType=1折扣率) 
		/// </summary>
		public int DiscountValue
		{
			set{ _discountvalue=value;}
			get{return _discountvalue;}
		}
		/// <summary>
		/// 打折方式： 0.优惠金额 1.折扣率
		/// </summary>
		public int ValueType
		{
			set{ _valuetype=value;}
			get{return _valuetype;}
		}
		#endregion Model

	}
    public class PromotionFullPriceCutWithName : PromotionFullPriceCut
    {
        public int PromotionsId { get; set; }
        public string PromotionsName { get; set; }
    }
}

