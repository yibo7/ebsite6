using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Modules.Shop.ModuleCore;

namespace EbSite.Modules.Shop.Core.Cart
{
    /// <summary>
    /// 一个购物车处理类
    /// </summary>
    [Serializable]
    public partial class CartManger
    {

        // 购物车集合  
        private Dictionary<string, Entity.Buy_CartItem> cartItems = new Dictionary<string, Entity.Buy_CartItem>();

        /// <summary>
        /// 统计整个购物车中商品的市场价格
        /// </summary>
        public decimal TotalMarket
        {
            get
            {
                decimal total = 0;
                foreach (Entity.Buy_CartItem item in cartItems.Values)
                    total += item.TotalMarketPrice;
                return total;
            }
        }
        /// <summary>
        /// 统计整个购物车中商品的会员价格
        /// </summary>
        public decimal TotalMember
        {
            get
            {
                decimal total = 0;
                foreach (Entity.Buy_CartItem item in cartItems.Values)
                {
                    //total += item.TotalMemberPrice;
                    total += (item.TotalMemberPrice + item.ProductOptionFree);
                }
                    
                return total;
            }
        }
       
        /// <summary>
        /// 商品折扣后，并非订单折扣后，折扣后实际要付款的钱,还没有扣除订单折扣费用，[只是扣除满量折扣,DiscountAmount 是最终整个订单要付款的钱  XXX]
        /// </summary>
        public decimal TotalRealSellPrice
        {
            get
            {
                decimal total = 0;
                foreach (Entity.Buy_CartItem item in cartItems.Values)
                {
                    total += (item.TotalRealSellPrice + item.ProductOptionFree);
                }
                    
                return total;
            }
        }
        

        /// <summary>
        /// 统计整个购物车中商品的重量，运费计算依据
        /// </summary>
        public decimal TotalWeight
        {
            get
            {
                decimal total = 0;
                foreach (Entity.Buy_CartItem item in cartItems.Values)
                    total += item.TotalWeight;
                return total;
            }
        }
        /// <summary>
        /// 统计购物车中的商品成本价格
        /// </summary>
        public decimal TotalCostPrice
        {
            get
            {
                decimal total = 0;
                foreach (Entity.Buy_CartItem item in cartItems.Values)
                    total += item.TotalCostPrice;
                return total;
            }
        }
        /// <summary>
        /// 统计本次物流的订单成本利润价格
        /// </summary>
        public decimal TotalProfit
        {
            get
            {
                return TotalRealSellPrice - TotalCostPrice;
            }
        }
        /// <summary>
        /// 统计本次购物可得积分
        /// </summary>
        public int TotalPoints
        {
            get
            {
                int total = 0;
                foreach (Entity.Buy_CartItem item in cartItems.Values)
                    total += item.TotalPoints;
                return total;
            }
        }
        
        
        /// <summary>
        /// 统计本次购物节省多少钱
        /// </summary>
        public decimal TotalFrugal
        {
            get { return TotalMarket - TotalRealSellPrice; }
        }

        /// <summary>
        /// 包括赠送,统计购物车里有多少条记录
        /// </summary>
        public int CountTotal
        {
            get { return Count + TotalGiveQuantity; }
        }

        /// <summary>
        /// 统计购物车里有多少条记录
        /// </summary>
        public int Count
        {
            get
            {
                int total  = 0;
                foreach (Entity.Buy_CartItem item in cartItems.Values)
                    total += item.Quantity;
                return total;
            }
        }
        /// <summary>
        /// 统计赠送多少个
        /// </summary>
        public int TotalGiveQuantity
        {
            get
            {
                int total = 0;
                foreach (Entity.Buy_CartItem item in cartItems.Values)
                    total += item.GiveQuantity;
                return total;
            }
        }
        #region 满额免费用活动计算

        private int _activityid;
        /// <summary>
        /// 满额免费用活动ID
        /// </summary>
        public int ActivityId
        {
            //set { _activityid = value; }
            get { return _activityid; }
        }

        private string _activityname;
        /// <summary>
        /// 满额免费用活动名称
        /// </summary>
        public string ActivityName
        {
            //set { _activityname = value; }
            get { return _activityname; }
        }

        private bool _eightfree;
        /// <summary>
        /// 满额免费用--运费(1代表免0代表不免)
        /// </summary>
        public bool EightFree
        {
            //set { _eightfree = value; }
            get { return _eightfree; }
        }

        private bool _payfreefree;
        /// <summary>
        /// 满额免费用--支付手续费(1代表免0代表不免)
        /// </summary>
        public bool PayFreeFree
        {
            //set { _payfreefree = value; }
            get { return _payfreefree; }
        }

        private bool _orderoptionfree;
        /// <summary>
        /// 满额免费用--订单可选项产生的费用(1代表免0代表不免)
        /// </summary>
        public bool OrderOptionFree
        {
            //set { _orderoptionfree = value; }
            get { return _orderoptionfree; }
        }

        #endregion


        #region 满额打折活动计算

        private int _discountid;
        /// <summary>
        /// 满额打折活动ID
        /// </summary>
        public int DiscountId
        {
            //set { _discountid = value; }
            get { return _discountid; }
        }

        private string _discountname;
        /// <summary>
        /// 满额打折活动名称
        /// </summary>
        public string DiscountName
        {
            //set { _discountname = value; }
            get { return _discountname; }
        }

        private decimal _discountvalue;
        /// <summary>
        /// 满额打折活动值类型,0为实际优惠金额,1为打折率8折为80.00
        /// </summary>
        public decimal DiscountValue
        {
            //set { _discountvalue = value; }
            get { return _discountvalue; }
        }

        private int _discountvaluetype;
        /// <summary>
        /// 满额打折活动值 对应 DiscountValueType 0为实际金额,1为打折率 
        /// </summary>
        public int DiscountValueType
        {
            //set { _discountvaluetype = value; }
            get { return _discountvaluetype; }
        }

        private decimal _discountamount;
        /// <summary>
        /// 商品折扣后并且订单折扣后 满额打折折扣金额 此值大于0,说明本次购物订单里有优惠
        /// </summary>
        public decimal DiscountAmount
        {
            //set { _discountamount = value; }
            get { return _discountamount; }
        }


        private decimal _OrderTotal;
        /// <summary>
        /// 商品折扣后并且订单折扣后 
        /// </summary>
        public decimal OrderTotal
        {
            //set { _discountamount = value; }
            get { return _OrderTotal; }
        }



        #endregion

        /// <summary>
        /// 更新促销活动信息,只要应用于，绑定购物车时(显示去客户)与下单时使用(下到订单表里)
        /// </summary>
        public void UpdateActivityInfo()
        {
            #region
            ////重置数据
            //_discountid = 0;
            //_discountname = string.Empty;
            //_discountvaluetype = 0;
            //_discountamount = 0;// TotalRealSellPrice;
            //_discountvalue = 0;

            //_activityid = 0;
            //_activityname = string.Empty;
            //_eightfree = false;
            //_payfreefree = false;
            //_orderoptionfree = false;

            //int RoleID = EbSite.Base.Host.Instance.RoleID;
            //if (RoleID > 0)
            //{
            //    Entity.PromotionFullPriceCutWithName pfpwn;
            //    Entity.PromotionPriceFreeWithName pwwn;
            //    ModuleCore.BLL.Promotions.Instance.GetActivityInfo(RoleID, TotalMember, out pfpwn, out pwwn);

            //    if (pfpwn.PromotionsId > 0)  //满额打折
            //    {
            //        _discountid = pfpwn.PromotionsId;
            //        _discountname = pfpwn.PromotionsName;
            //        _discountvaluetype = pfpwn.ValueType;
            //        //decimal d = pfpwn.DiscountValue/100;
            //        _discountvalue = pfpwn.DiscountValue; //yhl 2013-08-27 加
            //        if (_discountvaluetype == 1)
            //        {
            //            _discountamount = ((100-pfpwn.DiscountValue)*TotalRealSellPrice)/100; //TotalRealSellPrice
            //        }
            //        else
            //        {
            //            _discountamount = TotalRealSellPrice - _discountvalue; 
            //        }
            //    }
            //    if (pwwn.PromotionsId > 0)  //满额免费用
            //    {
            //        _activityid = pwwn.PromotionsId;
            //        _activityname = pwwn.PromotionsName;
            //        _eightfree = pwwn.FreightFree;
            //        _payfreefree = pwwn.PayFee;
            //        _orderoptionfree = pwwn.ServiceFree;
            //    }
            //}

            #endregion
            //重置数据
            _discountid = 0; //满额打折活动ID
            _discountname = string.Empty; //满额打折活动名称
            _discountvaluetype = 0; //满额打折活动值 对应 DiscountValueType 0为实际金额,1为打折率 
            _OrderTotal = TotalRealSellPrice; //商品折扣后并且订单折扣后 满额打折折扣金额 Amount(订单产品价格)*((100-DiscountValue)/100)  

            _activityid = 0;
            _activityname = string.Empty;
            _eightfree = false;
            _payfreefree = false;
            _orderoptionfree = false;

            int RoleID = EbSite.Base.Host.Instance.RoleID;
            if (RoleID > 0)
            {
                Entity.PromotionFullPriceCutWithName pfpwn;
                Entity.PromotionPriceFreeWithName pwwn;
                ModuleCore.BLL.Promotions.Instance.GetActivityInfo(RoleID, TotalMember, out pfpwn, out pwwn);

                if (pfpwn.PromotionsId > 0)  //满额打折
                {
                    _discountid = pfpwn.PromotionsId;
                    _discountname = pfpwn.PromotionsName;
                    _discountvaluetype = pfpwn.ValueType;
                    //decimal d = pfpwn.DiscountValue/100;
                    if (_discountvaluetype == 1) //百分比
                    {

                        _OrderTotal = (pfpwn.DiscountValue * TotalRealSellPrice) / 100;
                        _discountamount = TotalRealSellPrice - _OrderTotal;
                    }
                    else //直接金额
                    {
                        _OrderTotal = TotalRealSellPrice - pfpwn.DiscountValue;
                        _discountamount = pfpwn.DiscountValue; 
                    }
                    
                }
                if (pwwn.PromotionsId > 0)  //满额免费用
                {
                    _activityid = pwwn.PromotionsId;
                    _activityname = pwwn.PromotionsName;
                    _eightfree = pwwn.FreightFree;
                    _payfreefree = pwwn.PayFee;
                    _orderoptionfree = pwwn.ServiceFree;
                }
            }

        }

        /// <summary>
        /// 团购 yhl 2013-09-13
        /// </summary>
        public void UpdateGroupActivityInfo()
        {
           
            //重置数据
            _discountid = 0; //满额打折活动ID
            _discountname = string.Empty; //满额打折活动名称
            _discountvaluetype = 0; //满额打折活动值 对应 DiscountValueType 0为实际金额,1为打折率 
            _OrderTotal = TotalRealSellPrice; //商品折扣后并且订单折扣后 满额打折折扣金额 Amount(订单产品价格)*((100-DiscountValue)/100)  

            _activityid = 0;
            _activityname = string.Empty;
            _eightfree = false;
            _payfreefree = false;
            _orderoptionfree = false;

           

        }
        /// <summary>
        /// 设置商品的购物数量
        /// </summary>
        /// <param name="ProductID">商品ID</param>
        /// <param name="qty">数量</param>
        public void SetQuantity(string sku, int qty)
        {
            cartItems[sku].Quantity = qty;

        }
        /// <summary>
        /// 在购物车里修改商品费用选项
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="opts"></param>
        public void ModifyProductOptions(string sku, string opts)
        {

            Entity.Buy_CartItem it = cartItems[sku];

            //decimal _ProductOptionFree = 0;
            List<Entity.cartproductoptionvalue> _SelOptionItems = ModuleCore.BLL.cartproductoptionvalue.Instance.GetSelOptionItemsByID(opts, it.ProductId, it.CartNumber,
                                                                                         it.Quantity, it.MemberPrice);
            
            cartItems[sku].SelOptionItems = _SelOptionItems;
            //cartItems[sku].ProductOptionFree = _ProductOptionFree;
            ModuleCore.BLL.cartproductoptionvalue.Instance.ClearCache();
        }
     

       /// <summary>
        /// 添加一个商品到购物车
       /// </summary>
       /// <param name="ProductID">商品ID</param>
       /// <param name="Num">购买数量</param>
        /// <param name="NormKey">NormKey规格ID</param>
        /// <param name="Opts">商品选项ID,用_分开 ,ID1_ID2</param>
        public void Add(int iProductID, int Num, string NormKey,string Opts)
        {
            if(Num>0)
            {
                Entity.Buy_CartItem cartItem;
                string ProductNumber = string.Empty;
                ModuleCore.Entity.NormRelationProduct nrp = null;
                EbSite.Entity.NewsContent md = null;


                bool IsHave = Base.AppStartInit.NewsContentInstDefault.Exists(iProductID,EbSite.Base.Host.Instance.GetSiteID);
                if (IsHave)
                {
                    md = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(iProductID);
                    
                    if (!string.IsNullOrEmpty(NormKey))
                    {
                        nrp = ModuleCore.BLL.NormRelationProduct.Instance.GetEntityByNormID(NormKey.Trim());
                        ProductNumber = nrp.PNumber;//如果用户选择了规格，将以规格的商品号为准
                    }
                    else
                    {
                        ProductNumber = md.Annex1; //否则以默认商品号为准
                    }
                    if (!cartItems.TryGetValue(ProductNumber, out cartItem))
                    {
                        cartItems.Add(ProductNumber, new Entity.Buy_CartItem(md, Num, nrp, Opts));
                    }
                    else
                    {
                        cartItem.Quantity++;
                    }
                        
                }
               
                
                
            }
            
        }

        /// <summary>
        /// 添加一个商品到购物车 团购
        /// </summary>
        /// <param name="iProductID">商品ID</param>
        /// <param name="Num">购买数量</param>
        /// <param name="NormKey">NormKey规格ID</param>
        /// <param name="gid">团购id</param>
        /// <param name="qid">抢购id</param>
        public void Add(int iProductID, int Num, string NormKey, int gid, int qid)
        {
            if (Num > 0)
            {
                Entity.Buy_CartItem cartItem;
                string ProductNumber = string.Empty;
                ModuleCore.Entity.NormRelationProduct nrp = null;
                EbSite.Entity.NewsContent md = null;


                bool IsHave = EbSite.Base.AppStartInit.NewsContentInstDefault.Exists(iProductID,EbSite.Base.Host.Instance.GetSiteID);
                if (IsHave)
                {
                    md = EbSite.Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(iProductID);

                    if (!string.IsNullOrEmpty(NormKey))
                    {
                        nrp = ModuleCore.BLL.NormRelationProduct.Instance.GetEntityByNormID(NormKey.Trim());
                        ProductNumber = nrp.PNumber;//如果用户选择了规格，将以规格的商品号为准
                    }
                    else
                    {
                        ProductNumber = md.Annex1; //否则以默认商品号为准
                    }
                    if (!cartItems.TryGetValue(ProductNumber, out cartItem))
                    {
                        if (gid > 0)
                        {
                            cartItems.Add(ProductNumber, new Entity.Buy_CartItem(md, Num, nrp, gid,0));
                        }
                        if (qid > 0)
                        {
                            cartItems.Add(ProductNumber, new Entity.Buy_CartItem(md, Num, nrp, 0,qid));
                        }
                    }
                    else
                    {
                        cartItem.Quantity++;
                    }
                }
            }
        }

       
        /// <summary>
        /// 添加一个商品到购物中心车
        /// </summary>
        /// <param name="item">要添加的商品对象</param>
        public void Add(Entity.Buy_CartItem item)
        {
            Entity.Buy_CartItem cartItem;
            if (!cartItems.TryGetValue(item.SKU, out cartItem))
                cartItems.Add(item.SKU, item);
            else
                cartItem.Quantity += item.Quantity;
        }

        /// <summary>
        /// 从购物车删除一个商品
        /// </summary>
        /// <param name="ProductID">商品ID</param>
        public void Remove(string ProductID)
        {
            cartItems.Remove(ProductID);
        }

        /// <summary>
        /// 返回购物车商品列表
        /// </summary>
        /// <returns>Collection of CartItemInfo</returns>
        public ICollection<Entity.Buy_CartItem> CartItems
        {
            get { return cartItems.Values; }
        }
        /// <summary>
        /// 清空购物车
        /// </summary>
        public void Clear()
        {
            cartItems.Clear();
            _CreditCartItems.Clear();
        }
        ///// <summary>
        ///// Method to convert all cart items to order line items
        ///// </summary>
        ///// <returns>A new array of order line items</returns>
        //public LineItemInfo[] GetOrderLineItems()
        //{

        //    LineItemInfo[] orderLineItems = new LineItemInfo[cartItems.Count];
        //    int lineNum = 0;

        //    foreach (CartItemInfo item in cartItems.Values)
        //        orderLineItems[lineNum] = new LineItemInfo(item.ItemId, item.Name, ++lineNum, item.Quantity, item.Price);

        //    return orderLineItems;
        //}

        
    }
}