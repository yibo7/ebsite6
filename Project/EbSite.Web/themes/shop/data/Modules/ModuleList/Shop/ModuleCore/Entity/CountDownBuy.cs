using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类CountDownBuy 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class CountDownBuy: Base.Entity.EntityBase<CountDownBuy,int>
	{
		public CountDownBuy()
		{
			base.CurrentModel = this;
		}
		public CountDownBuy(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<CountDownBuy, int> Bll()
		{
			 
				return BLL.CountDownBuy.Instance;
			 
		}
		#region Model
		private int _productid;
		private DateTime _startdate;
		private DateTime _enddate;
		private string _content;
		private int _orderid;
		private decimal _countdownprice;
		/// <summary>
		/// 关联产品ID
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 开始日期时间
		/// </summary>
		public DateTime StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 结束日期时间
		/// </summary>
		public DateTime EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 活动说明
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 显示顺序
		/// </summary>
		public int OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 限时抢购价格
		/// </summary>
		public decimal CountDownPrice
		{
			set{ _countdownprice=value;}
			get{return _countdownprice;}
		}
		#endregion Model

        #region 新加字段

        private decimal _price;
        private string _title;
        private string _smallimg;

        /// <summary>
        /// 市场价格
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string SmallImg
        {
            set { _smallimg = value; }
            get { return _smallimg; }
        }


        public int Status { get; set; }
        public int Buyed { get; set; }
        #endregion 新加字段
	}
}

