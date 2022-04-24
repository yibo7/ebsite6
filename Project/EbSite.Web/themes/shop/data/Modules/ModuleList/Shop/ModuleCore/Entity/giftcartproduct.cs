using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类giftcartproduct 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class giftcartproduct: Base.Entity.EntityBase<giftcartproduct,int>
	{



        public giftcartproduct(Gift md, long cartitemid, int _BuyCount)
        {
            CartItemID = cartitemid;
            BuyProductId = md.BuyProductId;
            GiftProductId = md.GiftProductId;
            Quantity = md.Quantity;
            BuyCount = _BuyCount;
            ProductName = md.ProductName;
            SmallImg = md.SmallImg;

        }

	    public giftcartproduct()
		{
			base.CurrentModel = this;
		}
		public giftcartproduct(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<giftcartproduct, int> Bll()
		{
			 
				return BLL.giftcartproduct.Instance;
			 
		}
		#region Model
        private long _cartitemid;
		private int? _buyproductid;
		private int _giftproductid;
		private int _quantity;
		private int _buycount;
		/// <summary>
        /// 关联购物车数据项
		/// </summary>
        public long CartItemID
		{
			set{ _cartitemid=value;}
			get{return _cartitemid;}
		}
		/// <summary>
        /// 关联购买产品ID
		/// </summary>
		public int? BuyProductId
		{
			set{ _buyproductid=value;}
			get{return _buyproductid;}
		}
		/// <summary>
        /// 关联赠品产品ID
		/// </summary>
		public int GiftProductId
		{
			set{ _giftproductid=value;}
			get{return _giftproductid;}
		}
		/// <summary>
        /// 赠送数量
		/// </summary>
		public int Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
        /// 购买商品的数量(可能暂时用不上,直接从商品计算，免得还得更新此值)
		/// </summary>
		public int BuyCount
		{
			set{ _buycount=value;}
			get{return _buycount;}
		}
		#endregion Model

        public int BuyUserID { get; set; }

        public string ProductName { get; set; }
        public string SmallImg { get; set; }

	    public int TotalGivQuantity
	    {
	        get { return Quantity*BuyCount; }
	    }

	}
}

