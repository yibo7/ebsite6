using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类cartproductoptionvalue 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class cartproductoptionvalue: Base.Entity.EntityBase<cartproductoptionvalue,int>
	{
        /// <summary>
        /// 创建一个对像
        /// </summary>
        /// <param name="md">ProductOptionItems实体</param>
        /// <param name="productID">关联商品ID</param>
        /// <param name="CartItemID">关联购物车ID</param>
        public cartproductoptionvalue(ProductOptionItems md, long productID, long CartItemID, int _Quantity, decimal _ProductPrice)
        {
            this.OptionName = md.OptionName;
            this.ItemName = md.ItemName;
            this.AppendMoney = md.AppendMoney;
            this.CalculateMode = md.CalculateMode;
            this.IsGive = md.IsGive;
            this.ProductOptionId = md.ProductOptionID;
            this.ProductOptionItemId = md.id;
            this.ProductID = productID;
            this.CartItemID = CartItemID;
            this.Quantity = _Quantity;
            this.ProductPrice = _ProductPrice;

        }

		public cartproductoptionvalue()
		{
			base.CurrentModel = this;
		}
		public cartproductoptionvalue(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<cartproductoptionvalue, int> Bll()
		{
			 
				return BLL.cartproductoptionvalue.Instance;
			 
		}
		#region Model
        private long _cartitemid;
		private long _productid;
		private int? _productoptionid;
		private int? _productoptionitemid;
		private string _optionname;
		private string _itemname;
		private bool _isgive;
		private decimal _appendmoney;
		private int _calculatemode;
		/// <summary>
        /// 关联购物车数据项ID
		/// </summary>
        public long CartItemID
		{
			set{ _cartitemid=value;}
			get{return _cartitemid;}
		}
		/// <summary>
        /// 商品ID  
		/// </summary>
		public long ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
        /// 对应表ProductOptions的ID
		/// </summary>
		public int? ProductOptionId
		{
			set{ _productoptionid=value;}
			get{return _productoptionid;}
		}
		/// <summary>
        /// 对应表ProductOptionItems的ID
		/// </summary>
		public int? ProductOptionItemId
		{
			set{ _productoptionitemid=value;}
			get{return _productoptionitemid;}
		}
		/// <summary>
        /// 对应表ProductOptions的OptionName 
		/// </summary>
		public string OptionName
		{
			set{ _optionname=value;}
			get{return _optionname;}
		}
		/// <summary>
        /// 对应表ProductOptionItems的ItemName  
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		/// <summary>
        ///  赠送(有些服务默认为赠送) 
		/// </summary>
		public bool IsGive
		{
			set{ _isgive=value;}
			get{return _isgive;}
		}
		/// <summary>
        /// 当CalculateMode为0时:固定金额,为1时:购物车金额百分比
		/// </summary>
		public decimal AppendMoney
		{
			set{ _appendmoney=value;}
			get{return _appendmoney;}
		}
		/// <summary>
        /// 费用计算模式 0.固定金额 1.当前商品金额百分比 
		/// </summary>
		public int CalculateMode
		{
			set{ _calculatemode=value;}
			get{return _calculatemode;}
		}
        public int BuyUserID { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }

        public decimal TotalPrice {
            get
            {
                if (IsGive)
                {
                    return 0;
                }

                if (CalculateMode == 0)
                {
                    return AppendMoney * Quantity;
                }
                else
                {
                   // return Quantity * ProductPrice * CalculateMode/100;
                    return Quantity * ProductPrice * AppendMoney / 100; //yhl 2013-08-28
                }

               
            }
        }
		#endregion Model

	}
}

