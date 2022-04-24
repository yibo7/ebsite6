using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类PromotionFullNumGive 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PromotionFullNumGive: Base.Entity.EntityBase<PromotionFullNumGive,int>
	{
		public PromotionFullNumGive()
		{
			base.CurrentModel = this;
		}
		public PromotionFullNumGive(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<PromotionFullNumGive, int> Bll()
		{
			 
				return BLL.PromotionFullNumGive.Instance;
			 
		}
		#region Model
		private int _promotionsid;
		private int _buyquantity;
		private int _givequantity;
		/// <summary>
		/// 关联表Promotions的ID
		/// </summary>
		public int PromotionsID
		{
			set{ _promotionsid=value;}
			get{return _promotionsid;}
		}
		/// <summary>
		/// 满足购买数量
		/// </summary>
		public int BuyQuantity
		{
			set{ _buyquantity=value;}
			get{return _buyquantity;}
		}
		/// <summary>
		/// 赠送数量
		/// </summary>
		public int GiveQuantity
		{
			set{ _givequantity=value;}
			get{return _givequantity;}
		}
		#endregion Model

	}
    public class PromotionFullNumGiveWithName : PromotionFullNumGive
    {
        public int PromotionsId { get; set; }
        public string PromotionsName { get; set; }
    }
}

