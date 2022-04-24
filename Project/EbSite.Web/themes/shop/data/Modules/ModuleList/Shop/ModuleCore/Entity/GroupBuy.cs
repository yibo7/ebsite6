using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类GroupBuy 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class GroupBuy: Base.Entity.EntityBase<GroupBuy,int>
	{
		public GroupBuy()
		{
			base.CurrentModel = this;
		}
		public GroupBuy(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<GroupBuy, int> Bll()
		{
			 
				return BLL.GroupBuy.Instance;
			 
		}
		#region Model
		private int _productid;
		private decimal? _needprice;
		private DateTime _startdate;
		private DateTime _enddate;
		private int? _maxcount;
		private string _content;
		private int _status;
		private int? _orderid;
		/// <summary>
		/// 商品ID
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 违约金
		/// </summary>
		public decimal? NeedPrice
		{
			set{ _needprice=value;}
			get{return _needprice;}
		}
		/// <summary>
		/// 开始日期
		/// </summary>
		public DateTime StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 结束日期
		/// </summary>
		public DateTime EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 限购总数量
		/// </summary>
		public int? MaxCount
		{
			set{ _maxcount=value;}
			get{return _maxcount;}
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
		/// 0进行中 1成功结束
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 显示顺序
		/// </summary>
		public int? OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}

		

        private decimal _price;
        private string _title;
        private string _smallimg;
        private int _sdateline;
        private int _edateline;

        /// <summary>
        /// 开始日期(整型)
        /// </summary>
        public int SDateLine
        {
            get { return _sdateline; }
            set { _sdateline = value; }
        }
        /// <summary>
        /// 结束日期(整型)
        /// </summary>
        public int EDateLine
        {
            get { return _edateline; }
            set { _edateline = value; }
        }

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

        public int BuyCount { get; set; }
        public decimal BuyPrice { get; set; }


	    private int? _buyed;
	    private int? _buysumorder;
        /// <summary>
        /// 已经购买的人数
        /// </summary>
	    public  int? Buyed
	    {
            get { return _buyed; }
            set { _buyed = value; }
	    }
        /// <summary>
        /// 购买产品总数量
        /// </summary>
	    public int? BuySumOrder
	    {
            get { return _buysumorder; }
            set { _buysumorder = value; }
	    }
        #endregion Model

       

       
       
       


       // #region 扩展字段

       // /// <summary>
       // /// 订单数量
       // /// </summary>
       // public string ordernum { get; set; }
       ///// <summary>
       ///// 购买产品总数量
       ///// </summary>
       // public string sumorder { get; set; }
       // #endregion

    }
}

