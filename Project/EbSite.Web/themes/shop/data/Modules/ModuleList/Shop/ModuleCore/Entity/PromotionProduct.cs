using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类PromotionProduct 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PromotionProduct: Base.Entity.EntityBase<PromotionProduct,int>
	{
		public PromotionProduct()
		{
			base.CurrentModel = this;
		}
		public PromotionProduct(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        protected override EbSite.Base.BLL.BllBase<PromotionProduct, int> Bll()
		{
			 
				return BLL.PromotionProduct.Instance;
			 
		}
		#region Model
		private int? _promotionsid;
		private int? _productid;
		/// <summary>
		/// 关联表Promotions的ID
		/// </summary>
		public int? PromotionsID
		{
			set{ _promotionsid=value;}
			get{return _promotionsid;}
		}
		/// <summary>
		/// 关联商品表ID
		/// </summary>
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		#endregion Model

	}
}

