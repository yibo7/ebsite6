using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类creditproductorder 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class creditproductorder: Base.Entity.EntityBase<creditproductorder,int>
	{
		public creditproductorder()
		{
			base.CurrentModel = this;
		}
		public creditproductorder(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<creditproductorder, int> Bll()
		{
			 
				return BLL.creditproductorder.Instance;
			 
		}
		#region Model
		private long? _orderid;
		private int? _creditproductid;
		private int? _userid;
		private int? _quantity;
		private DateTime? _addtime;
		private int? _credit;
		/// <summary>
		/// 
		/// </summary>
		public long? OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreditProductID
		{
			set{ _creditproductid=value;}
			get{return _creditproductid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Credit
		{
			set{ _credit=value;}
			get{return _credit;}
		}
		#endregion Model

        /// <summary>
        /// 积分商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 积分商品 图片路径
        /// </summary>
        public string SmallImg { get; set; }

	}
}

