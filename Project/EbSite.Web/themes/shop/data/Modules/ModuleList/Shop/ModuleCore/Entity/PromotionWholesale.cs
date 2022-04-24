using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类PromotionWholesale 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PromotionWholesale: Base.Entity.EntityBase<PromotionWholesale,int>
	{
		public PromotionWholesale()
		{
			base.CurrentModel = this;
		}
		public PromotionWholesale(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<PromotionWholesale, int> Bll()
		{
			 
				return BLL.PromotionWholesale.Instance;
			 
		}
		#region Model
		private int? _promotionsid;
		private int? _quantity;
		private int _discountvalue;
		/// <summary>
		/// 关联表Promotions的ID
		/// </summary>
		public int? PromotionsID
		{
			set{ _promotionsid=value;}
			get{return _promotionsid;}
		}
		/// <summary>
		/// 购买数量
		/// </summary>
		public int? Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 折扣值1-100之间
		/// </summary>
		public int DiscountValue
		{
			set{ _discountvalue=value;}
			get{return _discountvalue;}
		}
		#endregion Model

	}
    public class PromotionWholesaleWithName : PromotionWholesale
    {
        public int PromotionsId { get; set; }
        public string PromotionsName { get; set; }
    }
}

