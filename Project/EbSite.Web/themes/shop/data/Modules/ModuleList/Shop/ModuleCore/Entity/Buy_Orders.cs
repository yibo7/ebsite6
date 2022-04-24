using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类eb_buy_orders 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Buy_Orders: Base.Entity.EntityBase<Buy_Orders,int>
	{
		public Buy_Orders()
		{
			
		}

		#region Model
 
		private long _orderid;
		private string _remark;
		private int _merchandisermarkid = 1;
		private string _merchandiserremark;
		private decimal _adjusteddiscount = 0;
		private int _orderstatus;
		private string _closereason;
		private DateTime _orderadddate;
		private DateTime? _paydate;
		private DateTime? _senddate;
		private DateTime? _finishdate;
		private int _userid;
		private string _username;
		private string _emailaddress;
		private string _realname;
		private string _qq;
		private string _wangwang;
		private string _msn;
		private string _sendregion;
		private string _address;
		private string _zipcode;
		private string _sendtousername;
		private string _telphone;
		private string _cellphone;
		private int? _shippingmodeid;
		private string _modename;
		private int _realshippingmodeid;
		private string _realmodename;
		private int? _regionid;
		private decimal _freight;
		private decimal? _adjustedfreight;
		private string _deliveryordernumber;
		private int? _weight;
		private string _expresscompanyname;
		private string _expresscompanyabb;
		private int _paymenttypeid;
		private string _paymenttype;
		private decimal _payfree;
		private decimal? _adjustedpayfree;
		private int? _refundstatus;
		private decimal? _refundamount;
		private string _refundremark;
		private decimal _ordertotal;
		private int _orderpoint;
		private decimal? _ordercostprice;
		private decimal? _orderprofit;
		private decimal? _actualfreight;
		private decimal? _othercost;
		private decimal _optionprice;
		private decimal _amount;
		private int? _activityid;
		private string _activityname;
		private bool _eightfree;
		private bool _payfreefree;
		private bool _orderoptionfree;
		private int? _discountid;
		private string _discountname;
		private decimal? _discountvalue;
		private int? _discountvaluetype;
		private decimal _discountamount;
		private string _couponname;
		private string _couponcode;
		private decimal? _couponamount;
		private decimal _couponvalue;
		private int? _groupid;
		private decimal? _groupprice;
		private int? _groupbuystatus;
		private string _gatewayorderid;
		private int _isprinted;
		private string _taobaoorderid;
        private int _timenumber =EbSite.Core.SqlDateTimeInt.GetSecond(DateTime.Now);
        private DateTime? _reviewedorderdate;
        private DateTime? _surereceiptdate;
        private DateTime? _delorderdate;
	    private int? _panicbuyingid;

     
	    private decimal? _userBalance;

	    private int _icome;

		/// <summary>
		/// 订单编号
		/// </summary>
		public long OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 订单留言
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 标准图标号(0:,1:,2:,3:,4:,5:)
		/// </summary>
		public int MerchandiserMarkID
		{
			set{ _merchandisermarkid=value;}
			get{return _merchandisermarkid;}
		}
		/// <summary>
		/// 标注备忘录
		/// </summary>
		public string MerchandiserRemark
		{
			set{ _merchandiserremark=value;}
			get{return _merchandiserremark;}
		}
		/// <summary>
		/// 涨价或减价(元)：  为负代表折扣，为正代表涨价  (管理员在后台修改价格)
		/// </summary>
		public decimal AdjustedDiscount
		{
			set{ _adjusteddiscount=value;}
			get{return _adjusteddiscount;}
		}
		/// <summary>
        /// 订单状态  0.提交订单 (1.审核订单-货到付款 2.等待付款-在线支付)  3.已发货 4.确认收货 5.交易完成 6.回收站  		
        ///  </summary>
		public int OrderStatus
		{
			set{ _orderstatus=value;}
			get{return _orderstatus;}
		}

	    public string OrderStatusText { 
            get
            {

               return ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(OrderStatus);

                //switch (OrderStatus)
                //{

                //    case 0:
                //        return "等待买家付款";
                        
                //    case 1:
                //        return "等待发货";
                       
                //    case 2:
                //        return "已发货";
                       
                //    case 3:
                //        return "成功订单";
                        
                //    case 4:
                //        return "已关闭";
                       
                //    case 5:
                //        return "历史订单";
                       
                //    case 6:
                //        return "已删除";
                       
                //}
                //return "未知";
	        }
        }

	    /// <summary>
		/// 关闭订单时填写的理由，一般由1.联系不到买家  2.买家不想买了 3.已经同城见面交易 4.暂时缺货 5.其他原因   （过期没付款，自动关闭 这个是由系统自动更新）
		/// </summary>
		public string CloseReason
		{
			set{ _closereason=value;}
			get{return _closereason;}
		}
		/// <summary>
		/// 下单日期
		/// </summary>
		public DateTime OrderAddDate
		{
			set{ _orderadddate=value;}
			get{return _orderadddate;}
		}
		/// <summary>
		/// 付款日期,没有付款为 NULL
		/// </summary>
		public DateTime? PayDate
		{
			set{ _paydate=value;}
			get{return _paydate;}
		}
		/// <summary>
		/// 发货日期
		/// </summary>
		public DateTime? SendDate
		{
			set{ _senddate=value;}
			get{return _senddate;}
		}
		/// <summary>
		/// 订单完成日期
		/// </summary>
		public DateTime? FinishDate
		{
			set{ _finishdate=value;}
			get{return _finishdate;}
		}
		/// <summary>
		/// 购买用户ID-来自注册信息
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 购买用户帐号-来自注册信息
		/// </summary>
		public string Username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 购买用户Email地址-来自注册信息
		/// </summary>
		public string EmailAddress
		{
			set{ _emailaddress=value;}
			get{return _emailaddress;}
		}
		/// <summary>
		/// 购买用户真实姓名-来自注册信息
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 购买用户QQ-来自注册信息
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 购买用户旺旺-来自注册信息
		/// </summary>
		public string Wangwang
		{
			set{ _wangwang=value;}
			get{return _wangwang;}
		}
		/// <summary>
		/// 购买用户MSN-来自注册信息
		/// </summary>
		public string MSN
		{
			set{ _msn=value;}
			get{return _msn;}
		}
		/// <summary>
		/// 收货区域 如:浙江省，杭州市，下城区 即用户下单时选择的下拉,这里是区域ID，用逗号分开
		/// </summary>
		public string SendRegion
		{
			set{ _sendregion=value;}
			get{return _sendregion;}
		}
        /// <summary>
        /// 区域ID 在配送方式设置时添加的区域，如华东，西北
        /// </summary>
        public int? RegionId
        {
            set { _regionid = value; }
            get { return _regionid; }
        }
		/// <summary>
		/// 收货地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 收货邮编
		/// </summary>
		public string ZipCode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 收货人姓名
		/// </summary>
		public string SendToUserName
		{
			set{ _sendtousername=value;}
			get{return _sendtousername;}
		}
		/// <summary>
		/// 收货电话
		/// </summary>
		public string TelPhone
		{
			set{ _telphone=value;}
			get{return _telphone;}
		}
		/// <summary>
		/// 收货手机
		/// </summary>
		public string CellPhone
		{
			set{ _cellphone=value;}
			get{return _cellphone;}
		}
		/// <summary>
		/// 配送方式ID
		/// </summary>
		public int? ShippingModeId
		{
			set{ _shippingmodeid=value;}
			get{return _shippingmodeid;}
		}
		/// <summary>
		/// 配送方式
		/// </summary>
		public string ModeName
		{
			set{ _modename=value;}
			get{return _modename;}
		}
		/// <summary>
		/// 实际配送方式ID-在后台点发货时可以修改
		/// </summary>
		public int RealShippingModeId
		{
			set{ _realshippingmodeid=value;}
			get{return _realshippingmodeid;}
		}
		/// <summary>
		/// 实际配送方式名称-在后台点发货时可以修改
		/// </summary>
		public string RealModeName
		{
			set{ _realmodename=value;}
			get{return _realmodename;}
		}
		
		/// <summary>
		/// 运费-程序计算的运费
		/// </summary>
		public decimal Freight
		{
			set{ _freight=value;}
			get{return _freight;}
		}
		/// <summary>
		/// 调整运费 实际运费 因为运费无法计算得十分准确，这个是实际运费
		/// </summary>
		public decimal? AdjustedFreight
		{
			set{ _adjustedfreight=value;}
			get{return _adjustedfreight;}
		}
        /// <summary>
        /// 实际运费,未使用
        /// </summary>
        public decimal? ActualFreight
        {
            set { _actualfreight = value; }
            get { return _actualfreight; }
        }
		/// <summary>
		/// 快递运单号
		/// </summary>
		public string DeliveryOrderNumber
		{
			set{ _deliveryordernumber=value;}
			get{return _deliveryordernumber;}
		}
		/// <summary>
		/// 订单总重量
		/// </summary>
		public int? Weight
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		/// <summary>
		/// 快递公司 对应ShippingModeId 关联下的快递公司，由管理员在后台发货时选择
		/// </summary>
		public string ExpressCompanyName
		{
			set{ _expresscompanyname=value;}
			get{return _expresscompanyname;}
		}
		/// <summary>
		/// 快递100Code
		/// </summary>
		public string ExpressCompanyAbb
		{
			set{ _expresscompanyabb=value;}
			get{return _expresscompanyabb;}
		}
		/// <summary>
        /// 支付接口的ID 为-1时表示货到付款 对应的 PayFree 为货到付款费用
		/// </summary>
		public int PaymentTypeId
		{
			set{ _paymenttypeid=value;}
			get{return _paymenttypeid;}
		}
		/// <summary>
		/// 支付接口类型  如 支付宝即时到帐
		/// </summary>
		public string PaymentType
		{
			set{ _paymenttype=value;}
			get{return _paymenttype;}
		}
		/// <summary>
		/// 支付接口手续费
		/// </summary>
		public decimal PayFree
		{
			set{ _payfree=value;}
			get{return _payfree;}
		}
		/// <summary>
		/// 调整支付接口手续费-实际支付接口手续费 由管理员在后台修改订单价格时可以操作
		/// </summary>
		public decimal? AdjustedPayFree
		{
			set{ _adjustedpayfree=value;}
			get{return _adjustedpayfree;}
		}
		/// <summary>
		/// (只有在发货后才可以退款,退款时间为FinishDate)退货操作选项 1.我已经跟买家联系，使用线下操作完成退款,2.使用预付款功能退款到买家的预付款账户。
		/// </summary>
		public int? RefundStatus
		{
			set{ _refundstatus=value;}
			get{return _refundstatus;}
		}
		/// <summary>
		/// 退款金额(退款金额不得大于订单总金额.已发货订单允许全额或部分退款,退款后订单自动变为交易成功状态。)
		/// </summary>
		public decimal? RefundAmount
		{
			set{ _refundamount=value;}
			get{return _refundamount;}
		}
		/// <summary>
		/// 在这里您可以填写相关买家的银行信息及相关退款事宜，以便日后查询。
		/// </summary>
		public string RefundRemark
		{
			set{ _refundremark=value;}
			get{return _refundremark;}
		}
		/// <summary>
        /// 订单总价格(产品价格Amount+订单费用运费订单选项费-订单折扣,用户实际付款价)
		/// </summary>
		public decimal OrderTotal
		{
			set{ _ordertotal=value;}
			get{return _ordertotal;}
		}
        /// <summary>
        /// 商品折扣后，并非订单折扣后，折扣后实际要付款的钱,还没有扣除订单折扣费用，[只是扣除满量折扣,DiscountAmount 是最终整个订单要付款的钱  XXX]
        /// 对应购物车里的 TotalRealSellPrice
        /// </summary>
        public decimal Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
		/// <summary>
		/// 订单可得积分
		/// </summary>
		public int OrderPoint
		{
			set{ _orderpoint=value;}
			get{return _orderpoint;}
		}
		/// <summary>
		/// 订单成本价格
		/// </summary>
		public decimal? OrderCostPrice
		{
			set{ _ordercostprice=value;}
			get{return _ordercostprice;}
		}

		/// <summary>
		/// 订单成本利润价格
		/// </summary>
		public decimal? OrderProfit
		{
			set{ _orderprofit=value;}
			get{return _orderprofit;}
		}
		
		/// <summary>
		/// 其他成本,未使用
		/// </summary>
		public decimal? OtherCost
		{
			set{ _othercost=value;}
			get{return _othercost;}
		}
		/// <summary>
		/// 订单选项费用
		/// </summary>
		public decimal OptionPrice
		{
			set{ _optionprice=value;}
			get{return _optionprice;}
		}
		
		/// <summary>
		/// 满额免费用活动ID
		/// </summary>
		public int? ActivityId
		{
			set{ _activityid=value;}
			get{return _activityid;}
		}
		/// <summary>
		/// 满额免费用活动名称
		/// </summary>
		public string ActivityName
		{
			set{ _activityname=value;}
			get{return _activityname;}
		}
		/// <summary>
		/// 满额免费用--运费(1代表免0代表不免)
		/// </summary>
		public bool EightFree
		{
			set{ _eightfree=value;}
			get{return _eightfree;}
		}
		/// <summary>
		/// 满额免费用--支付手续费(1代表免0代表不免)
		/// </summary>
		public bool PayFreeFree
		{
			set{ _payfreefree=value;}
			get{return _payfreefree;}
		}
		/// <summary>
		/// 满额免费用--订单可选项产生的费用(1代表免0代表不免)
		/// </summary>
		public bool OrderOptionFree
		{
			set{ _orderoptionfree=value;}
			get{return _orderoptionfree;}
		}
		/// <summary>
		/// 满额打折活动ID
		/// </summary>
		public int? DiscountId
		{
			set{ _discountid=value;}
			get{return _discountid;}
		}
		/// <summary>
		/// 满额打折活动名称
		/// </summary>
		public string DiscountName
		{
			set{ _discountname=value;}
			get{return _discountname;}
		}
		/// <summary>
		/// 满额打折活动值 对应 DiscountValueType 0为实际金额,1为打折率
		/// </summary>
		public decimal? DiscountValue
		{
			set{ _discountvalue=value;}
			get{return _discountvalue;}
		}
		/// <summary>
		/// 满额打折活动值类型,0为实际优惠金额,1为打折率8折为80.00
		/// </summary>
		public int? DiscountValueType
		{
			set{ _discountvaluetype=value;}
			get{return _discountvaluetype;}
		}
      
		/// <summary>
		/// 商品优惠多少钱 
        /// </summary>   //yhl 于 2013-08-28 给改的  商品折扣后，并且订单折扣后，这个是最终用户付款的钱  满额打折折扣金额 Amount(订单产品价格)*((100-DiscountValue)/100)
		public decimal DiscountAmount
		{
			set{ _discountamount=value;}
			get{return _discountamount;}
		}
		/// <summary>
		/// 优惠券
		/// </summary>
		public string CouponName
		{
			set{ _couponname=value;}
			get{return _couponname;}
		}
		/// <summary>
		/// 优惠券号码
		/// </summary>
		public string CouponCode
		{
			set{ _couponcode=value;}
			get{return _couponcode;}
		}
		/// <summary>
		/// 优惠券满足金额
		/// </summary>
		public decimal? CouponAmount
		{
			set{ _couponamount=value;}
			get{return _couponamount;}
		}
		/// <summary>
		/// 优惠券可抵扣金额
		/// </summary>
		public decimal CouponValue
		{
			set{ _couponvalue=value;}
			get{return _couponvalue;}
		}
		/// <summary>
		/// 团购ID
		/// </summary>
		public int? GroupId
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 团购价格
		/// </summary>
		public decimal? GroupPrice
		{
			set{ _groupprice=value;}
			get{return _groupprice;}
		}
		/// <summary>
		/// 团购状态
		/// </summary>
		public int? GroupBuyStatus
		{
			set{ _groupbuystatus=value;}
			get{return _groupbuystatus;}
		}
		/// <summary>
		/// 网关ID
		/// </summary>
		public string GatewayOrderId
		{
			set{ _gatewayorderid=value;}
			get{return _gatewayorderid;}
		}
		/// <summary>
		/// 是否已经打印订单(每一位代表一个打印状态，1代表未打印，2代表已打印 左起第一位代表：快递单，左起第二位：购货单，左起第三位：配送单)
		/// </summary>
		public int IsPrinted
		{
			set{ _isprinted=value;}
			get{return _isprinted;}
		}
		/// <summary>
		/// 淘宝订单ID?
		/// </summary>
		public string TaobaoOrderId
		{
			set{ _taobaoorderid=value;}
			get{return _taobaoorderid;}
		}
        /// <summary>
        /// 下单日期 OrderAddDate 
        /// </summary>
	    public int TimeNumber
	    {
            get { return _timenumber; }
            set { _timenumber = value; }
	    }
        /// <summary>
        /// 审核订单时间
        /// </summary>
        public DateTime? ReviewedOrderDate
        {
            set { _reviewedorderdate = value; }
            get { return _reviewedorderdate; }
        }
        /// <summary>
        /// 确认收货时间
        /// </summary>
        public DateTime? SureReceiptDate
        {
            set { _surereceiptdate = value; }
            get { return _surereceiptdate; }
        }
        /// <summary>
        /// 回收站日期
        /// </summary>
        public DateTime? DelOrderDate
        {
            set { _delorderdate = value; }
            get { return _delorderdate; }
        }
        /// <summary>
        /// 抢购id
        /// </summary>
	    public int? PanicBuyingId
	    {
	        get { return _panicbuyingid; }
            set { _panicbuyingid = value; }
	    }
        /// <summary>
        /// 使用余款 （使当前账户中的余额）
        /// </summary>
	    public decimal? UserBalance
	    {
            get { return _userBalance; }
            set { _userBalance = value; }
	    }

        /// <summary>
        ///  来源 0：pc  1:手机
        /// </summary>
	    public int iCome
	    {
            get { return _icome; }
            set { _icome = value; }
	    }
		#endregion Model
        /// <summary>
        /// 加上费用就是前台用户应付的钱 减去优惠券价格
        /// </summary>
	    public decimal ToPayMoney
	    {
	        get
	        {
                if (!EightFree)
                {
                    this.OrderTotal += Freight;  //加运费
                }
                if (!PayFreeFree)
                {
                    this.OrderTotal += PayFree;  //支付手续费
                }
                if (!OrderOptionFree)
                {
                    this.OrderTotal += OptionPrice; //加上定单选项费
                }
                this.OrderTotal = this.OrderTotal - CouponValue;//减去优惠券
                string s = this.OrderTotal.ToString("#0.00");
                return decimal.Parse(s);

                //yhl 2013-08-27 上面  DiscountAmount   mdOrder.OrderTotal = mdOrder.ToPayMoney;//将计算结果更新更数据库
                // 原因： OrderTotal 和 DiscountAmount 永远是一样的值是错的。
                //this.OrderTotal = this.Amount -this.DiscountAmount;
                //if (!EightFree)
                //{
                //    this.OrderTotal += Freight;
                //}
                //if (!PayFreeFree)
                //{
                //    this.OrderTotal += PayFree;
                //}
                //if (!OrderOptionFree)
                //{
                //    this.OrderTotal += OptionPrice;
                //}
                //this.OrderTotal = this.OrderTotal - CouponValue;
                //string s = this.OrderTotal.ToString("#0.00");
                //return decimal.Parse(s);
	        }
	    }

	}
}

