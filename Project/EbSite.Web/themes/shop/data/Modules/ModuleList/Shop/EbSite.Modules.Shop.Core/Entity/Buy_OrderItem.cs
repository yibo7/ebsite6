using System;
using System.Collections.Generic;
using System.Linq;
namespace EbSite.Modules.Shop.Core.Entity
    /// <summary>
    /// 购物车里的一个订单对像，一旦下单，与Buy_Order形成一对多关系IsBuy
    /// </summary>
    [Serializable]
    public class Buy_OrderItem : Base.Entity.EntityBase<Buy_OrderItem, int>
    {
        public Buy_OrderItem()
        {
            base.CurrentModel = this;
        }
        public Buy_OrderItem(int ID)
        {
            base.id = ID;
            base.InitData(this);
            base.CurrentModel = this;
        }
        public Buy_OrderItem(Buy_CartItem mdCartItem, long OrderID)
        {
            this.OrderId = OrderID;
            this.AddDateTime = DateTime.Now;
            this.AdjustedPrice = mdCartItem.AdjustedPrice;
            this.BuyUserID = mdCartItem.BuyUserID;
            this.CategoryId = mdCartItem.CategoryId;
            this.ClassName = mdCartItem.ClassName;
            this.CostPrice = mdCartItem.CostPrice;
            this.GiveQuantity = mdCartItem.GiveQuantity;
            this.IsGift = mdCartItem.IsGift;
            this.MarketPrice = mdCartItem.MarketPrice;
            this.NormIDs = mdCartItem.NormIDs;
            this.Points = mdCartItem.Points;
            this.ProductId = mdCartItem.ProductId;
            this.ProductName = mdCartItem.ProductName;
            this.PurchaseGiftId = mdCartItem.PurchaseGiftId;
            this.PurchaseGiftName = mdCartItem.PurchaseGiftName;
            this.Quantity = mdCartItem.Quantity;
            this.SKU = mdCartItem.SKU;
            this.SKUContent = mdCartItem.SKUContent;
            this.ThumbnailsUrl = mdCartItem.ThumbnailsUrl;
            this.Weight = mdCartItem.Weight;
            this.WholesaleDiscountId = mdCartItem.WholesaleDiscountId;
            this.WholesaleDiscountName = mdCartItem.WholesaleDiscountName;
            this.MemberPrice = mdCartItem.MemberPrice;
        }
        protected override EbSite.Base.BLL.BllBase<Buy_OrderItem, int> Bll()
        {
             
                return BLL.Buy_OrderItem.Instance;
             
        }
        #region 自定义属性
        /// <summary>
        /// 统计商品重量 克
        /// </summary>
        public decimal TotalWeight
        {
            //未能确定重量是否应由RealQuantity来算
            get { return (decimal)(this._quantity * this.Weight); }
        }
        /// <summary>
        /// 统计会员价 打折后的价格小计
        /// </summary>
        public decimal TotalMemberPrice
        {
            get { return (decimal)(this._quantity * this.MemberPrice); }
            //get { return (decimal)(this._quantity * this.AdjustedPrice); }
        }
        /// <summary>
        /// 打折后的价格小计
        /// </summary>
        public decimal TotalRealSellPrice
        {
            get
            {
                return this._quantity * this.AdjustedPrice;
            }
        }
        public string TotalRealSellPriceInfo
        {
            get
            {
                if (TotalMemberPrice > TotalRealSellPrice)
                {
                    return string.Format("已优惠:-{0}元", TotalMemberPrice - TotalRealSellPrice);
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 统计市场价
        /// </summary>
        public decimal TotalMarketPrice
        {
            get { return (decimal)(this._quantity * this.MarketPrice); }
        }

        /// <summary>
        /// 统计成本价格
        /// </summary>
        public decimal TotalCostPrice
        {
            get { return (decimal)(this._quantity * this.CostPrice); }
        }
        /// <summary>
        /// 统计所得积分
        /// </summary>
        public int TotalPoints
        {
            get { return this._quantity * this.Points; }
        }
        /// <summary>
        /// 实际发货数量
        /// </summary>
        public int RealQuantity
        {
            get
            {
                return Quantity + GiveQuantity;
            }
        }
        /// <summary>
        /// 实际发货数量
        /// </summary>
        public int SendQuantity
        {
            get
            {
                return Quantity + GiveQuantity;
            }
        }
        /// <summary>
        /// 邦定物流车时显示
        /// </summary>
        public string GiveQuantityInfo
        {
            get
            {
                if (GiveQuantity > 0)
                {
                    return string.Concat("赠送:", GiveQuantity);
                }
                return string.Empty;
            }
        }
        public string WholesaleDiscountInfo
        {
            get
            {
                if (WholesaleDiscountId > 0)
                {
                    return string.Format("<a href='' target=_blank >{0}</a>", WholesaleDiscountName);
                }
                return string.Empty;
            }
        }
        public string PurchaseGiftInfo
        {
            get
            {
                if (PurchaseGiftId > 0)
                {
                    return string.Format("<a href='' target=_blank >{0}</a>", PurchaseGiftName);
                }
                return string.Empty;
            }
        }
        private int? _expresscompanyid;
        private long _orderitemkey;



        /// <summary>
        ///  物流公司ID
        /// </summary>
        public int? ExpressCompanyID
        {
            set { _expresscompanyid = value; }
            get { return _expresscompanyid; }
        }
        /// <summary>
        /// 事务【 赠品关联id】
        /// </summary>
        public long OrderItemKey
        {
            set { _orderitemkey = value; }
            get { return _orderitemkey; }
        }

        private int? _servicetype;
        /// <summary>
        /// 服务类型(0:换货 1:退货 2:维修)
        /// </summary>
        public int? ServiceType
        {
            get { return _servicetype; }
            set { _servicetype = value; }
        }

        private int? _submitquantity;
        /// <summary>
        /// 提交的数量(退货、换货、维修)
        /// </summary>
        public int? SubmitQuantity
        {
            get { return _submitquantity; }
            set { _submitquantity = value; }
        }

        private int? _applyproof;
        /// <summary>
        /// 申请凭据
        /// </summary>
        public int? ApplyProof
        {
            get { return _applyproof; }
            set { _applyproof = value; }
        }

        private string _questiondesc;
        /// <summary>
        /// 问题描述
        /// </summary>
        public string QuestionDesc
        {
            get { return _questiondesc; }
            set { _questiondesc = value; }
        }

        private DateTime? _returndate;
        /// <summary>
        /// 处理日期(退货、换货、维修)
        /// </summary>
        public DateTime? ReturnDate
        {
            get { return _returndate; }
            set { _returndate = value; }
        }

        private int? _itemstatus;
        /// <summary>
        /// 订单子状态(0:正常 1:已申请[退货、换货、维修] 2:申请通过 3:申请失败)
        /// </summary>
        public int? ItemStatus
        {
            get { return _itemstatus; }
            set { _itemstatus = value; }
        }

        private string _reason;
        /// <summary>
        /// 审核退货订单处理的结果
        /// </summary>
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        #endregion

        #region Model

        public decimal Weight { get; set; }
        /// <summary>
        /// 规格值ID,对应SKUContent
        /// </summary>
        public string NormIDs { get; set; }

        private long _orderid;
        private int _wholesalediscountid;//批发折扣ID
        private string _wholesalediscountname;//批发折扣名称
        private bool _isgift;//是否赠品
        private string _skucontent;//商品的规格 如 尺码：XXL; 颜色：卡其; 
        private string _thumbnailsurl;//缩略图
        private string _sku;//商品货号
        private int _quantity;//订购数量
        private decimal _memberprice;//会员价，销售价
        private string _productname;//商品名称
        private string _classname;//分类名称
        private decimal _marketprice;
        private int _categoryid;//分类ID
        private int _productid;

        /// <summary>
        /// 订单号 由日期_id生成  在还没有提交订单时，也就是只在购物车里，订单ID为空
        /// </summary>
        public long OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }

        /// <summary>
        /// 是否有赠品,如果有可以通过ProductId去获取
        /// </summary>
        public bool IsGift
        {
            set { _isgift = value; }
            get { return _isgift; }
        }
        /// <summary>
        /// 商品的规格 如 尺码：XXL; 颜色：卡其; 
        /// </summary>
        public string SKUContent
        {
            set { _skucontent = value; }
            get { return _skucontent; }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbnailsUrl
        {
            set { _thumbnailsurl = value; }
            get { return _thumbnailsurl; }
        }
        /// <summary>
        /// 商品货号
        /// </summary>
        public string SKU
        {
            set { _sku = value; }
            get { return _sku; }
        }
        /// <summary>
        /// 订购数量
        /// </summary>
        public int Quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }

        /// <summary>
        /// 会员价，销售价
        /// </summary>
        public decimal MemberPrice
        {
            set { _memberprice = value; }
            get { return _memberprice; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string ClassName
        {
            set { _classname = value; }
            get { return _classname; }
        }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice
        {
            set { _marketprice = value; }
            get { return _marketprice; }
        }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 商品ID，对应ebsite的内容ID，自增
        /// </summary>
        public int ProductId
        {
            set { _productid = value; }
            get { return _productid; }
        }

        /// <summary>
        /// 购买用户的ID
        /// </summary>
        public int BuyUserID { get; set; }
        /// <summary>
        /// 是否已经下单，分为两种情况，一种只是放到购物车，一种是已经下单 已经分表，不使用
        /// </summary>
        public bool IsBuy { get; set; }

        public DateTime _adddatetime = DateTime.Now;
        /// <summary>
        /// 购买时间
        /// </summary>
        public DateTime AddDateTime
        {
            set { _adddatetime = value; }
            get { return _adddatetime; }
        }

        private decimal _CostPrice;
        /// <summary>
        /// 成本价格
        /// </summary>
        public decimal CostPrice
        {
            set { _CostPrice = value; }
            get { return _CostPrice; }
        }

        private int _Points = 0;
        /// <summary>
        /// 购买此商品可得积分
        /// </summary>
        public int Points
        {
            set { _Points = value; }
            get { return _Points; }
        }

        private int _GiveQuantity = 0;
        /// <summary>
        /// 赠送数量,目前此字段只要应用于促销活动中的，买几送几,不计算到价格
        /// </summary>
        public int GiveQuantity
        {
            set { _GiveQuantity = value; }
            get { return _GiveQuantity; }
        }



        private decimal _AdjustedPrice;
        /// <summary>
        /// 调整后的价格 与批发折扣关联，折扣率*MemberPrice
        /// </summary>
        public decimal AdjustedPrice
        {
            set { _AdjustedPrice = value; }
            get { return _AdjustedPrice; }
        }

        /// <summary>
        /// 批发折扣ID
        /// </summary>
        public int WholesaleDiscountId
        {
            set { _wholesalediscountid = value; }
            get { return _wholesalediscountid; }
        }
        /// <summary>
        /// 批发折扣名称
        /// </summary>
        public string WholesaleDiscountName
        {
            set { _wholesalediscountname = value; }
            get { return _wholesalediscountname; }
        }


        private int _PurchaseGiftId;
        /// <summary>
        /// 满几送几的ID
        /// </summary>
        public int PurchaseGiftId
        {
            set { _PurchaseGiftId = value; }
            get { return _PurchaseGiftId; }
        }

        private string _PurchaseGiftName;
        /// <summary>
        /// 满几送几的名称
        /// </summary>
        public string PurchaseGiftName
        {
            set { _PurchaseGiftName = value; }
            get { return _PurchaseGiftName; }
        }
        #endregion Model

    }
}

