using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类ProductOptionItems 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ProductOptionItems: Base.Entity.EntityBase<ProductOptionItems,int>
	{
		public ProductOptionItems()
		{
			base.CurrentModel = this;
		}
		public ProductOptionItems(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<ProductOptionItems, int> Bll()
		{
			 
				return BLL.ProductOptionItems.Instance;
			 
		}
		#region Model
		private int _productoptionid;
		private string _itemname;
        private bool _isgive;
		
		private decimal _appendmoney;
		private int _calculatemode;
		private string _remark;
		/// <summary>
		/// 关联OrderOptions中的ID
		/// </summary>
		public int ProductOptionID
		{
			set{ _productoptionid=value;}
			get{return _productoptionid;}
		}
		/// <summary>
		/// 选项名称
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		/// <summary>
		/// 是否允许赠送
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
		/// 费用计算模式 0.固定金额 1.购物车金额百分比 
		/// </summary>
		public int CalculateMode
		{
			set{ _calculatemode=value;}
			get{return _calculatemode;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
       
		#endregion Model

        //public decimal ProductPrice { get; set; } 

        //public decimal TotalPrice
        //{
        //    get
        //    {
        //        if (CalculateMode == 0)
        //        {
        //            return AppendMoney * Quantity;
        //        }
        //        else
        //        {
        //            return ProductPrice * AppendMoney * Quantity/100;
        //        }
        //    }
        //}
        /// <summary>
        /// 父选项名称
        /// </summary>
        public string OptionName { get; set; }

        //private int _quantity;//订购数量
        ///// <summary>
        ///// 订购数量
        ///// </summary>
        //public int Quantity
        //{
        //    set { _quantity = value; }
        //    get { return _quantity; }
        //}

	}
}

