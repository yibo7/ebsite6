using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类giftorderproduct 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class giftorderproduct: Base.Entity.EntityBase<giftorderproduct,int>
	{
		public giftorderproduct()
		{
			base.CurrentModel = this;
		}
		public giftorderproduct(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<giftorderproduct, int> Bll()
		{
			 
				return BLL.giftorderproduct.Instance;
			 
		}
		#region Model
		private int? _orderid;
		private long _ordernumber;
		private long _orderitemid;
		private int? _buyproductid;
		private int _giftproductid;
		private int? _quantity;
		private int? _buycount;
		/// <summary>
        ///  关联订单自增ID
		/// </summary>
		public int? OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
        /// 关联订单号
		/// </summary>
		public long OrderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
		}
		/// <summary>
        /// 关联订单产品明细key
		/// </summary>
		public long OrderItemID
		{
			set{ _orderitemid=value;}
			get{return _orderitemid;}
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
        ///  关联赠品产品ID
		/// </summary>
		public int GiftProductId
		{
			set{ _giftproductid=value;}
			get{return _giftproductid;}
		}
		/// <summary>
        /// 赠送数量
		/// </summary>
		public int? Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
        /// 购买商品的数量
		/// </summary>
		public int? BuyCount
		{
			set{ _buycount=value;}
			get{return _buycount;}
		}
		#endregion Model

        //扩展
        //b.NewsTitle,b.SmallPic,b.Annex16
        public string NewsTitle { get; set; }
        public string SmallPic { get; set; }
        public string Annex16 { get; set; }

	}
}

