using System;
using System.Collections.Generic;
using System.Linq;
namespace EbSite.Modules.Shop.Core.Entity
{
    /// <summary>
    /// 购物车里的一个订单对像，一旦下单，与Buy_Order形成一对多关系IsBuy
    /// </summary>
    [Serializable]
    public class Buy_CartItem : Base.Entity.EntityBase<Buy_CartItem, int>
    {
        public Buy_CartItem()
        {
            base.CurrentModel = this;
        }
        public Buy_CartItem(int ID)
        {
            base.id = ID;
            base.InitData(this);
            base.CurrentModel = this;
        }
        protected override EbSite.Base.BLL.BllBase<Buy_CartItem, int> Bll()
        {
            
                return BLL.Buy_CartItem.Instance;
            
        }

        /// <summary>
        /// 通过内容ID去获取一个商品的相关信息
        /// </summary>
        /// <param name="md">商品实体</param>
        /// <param name="Quantity">购买数量</param>
        /// <param name="mdNorm">规格</param>
        /// <param name="OptIDs">附加选项</param>
        public Buy_CartItem(EbSite.Entity.NewsContent md, int Quantity, ModuleCore.Entity.NormRelationProduct mdNorm, string OptIDs)
        {
           
            if (md!=null)
            {
                CartNumber = EbSite.Core.SqlDateTimeInt.NewOrderNumberLong();
                //this.BuyUserID = EbSite.Base.Host.Instance.UserID;不能在此获取，真正添加到数据库的时候由profile生成的Id
                this.IsBuy = false;
                //this.WholesaleDiscountId = 批发折扣ID 要到数据库查询
                //this.WholesaleDiscountName = 批发折扣名称 要到数据库查询
                this.IsGift = false; //是否有赠品
                
                this.ThumbnailsUrl = md.SmallPic;
                this.Quantity = Quantity;
                this.ProductName = md.NewsTitle;
                this.ClassName = md.ClassName;
                this.CategoryId = md.ClassID;
                this.ProductId = md.ID;
                this.IsGroup = false;
                if (!string.IsNullOrEmpty(md.Annex6))
                {
                    this.Points = EbSite.Core.Utils.StrToInt(md.Annex6,0);
                }

                if (!string.IsNullOrEmpty(md.Annex2))
                {
                    this.MarketPrice = decimal.Parse(md.Annex2);//市场价
                }
                if (!Equals(mdNorm,null))
                {
                    //ModuleCore.Entity.NormRelationProduct nrp =
                    //    ModuleCore.BLL.NormRelationProduct.Instance.GetEntityByNormID(NormKey);
                    this.MemberPrice = mdNorm.SalePrice;//销售价
                    this.CostPrice = mdNorm.CostPrice;//成本价格
                    this.SKU = mdNorm.PNumber;
                    this.Weight = mdNorm.Weight;
                    //ModuleCore.
                    this.SKUContent = BLL.NormRelationProduct.Instance.GetShowInfoByNormKey(mdNorm.NormsValues);//由用户在外面post过来的 商品的规格 如 尺码：XXL; 颜色：卡其; 
                }
                else
                {
                    this.MemberPrice = md.Annex16;//销售价
                    this.CostPrice = md.Annex17;//市场价
                    this.SKU = md.Annex1;//商品编号
                    this.Weight = md.Annex18;
                    
                }
                //计算附加选项费用
                if (!string.IsNullOrEmpty(OptIDs))
                {
                    //string[] aID = OptIDs.Split('_');
                    //string IDs = string.Join(",", aID);
                    //List<Entity.ProductOptionItems> lst = ModuleCore.BLL.ProductOptionItems.Instance.GetListArrayInIDs(IDs);
                    //SelOptionItems = new List<cartproductoptionvalue>();
                    //foreach (ProductOptionItems  Item in lst)
                    //{
                    //    cartproductoptionvalue modle = new cartproductoptionvalue(Item, this.ProductId, CartNumber,
                    //                                                              this.Quantity, this.MemberPrice);
                    //    this.ProductOptionFree += modle.TotalPrice;
                    //    SelOptionItems.Add(modle);
                        
                    //}
                    //decimal _ProductOptionFree = 0;
                  SelOptionItems =   ModuleCore.BLL.cartproductoptionvalue.Instance.GetSelOptionItemsByID(OptIDs, ProductId, CartNumber,
                                                                                         Quantity, MemberPrice);
                  //this.ProductOptionFree = _ProductOptionFree;

                }


                List<ModuleCore.Entity.Gift> lstGift = ModuleCore.BLL.Gift.Instance.ListByProductID(md.ID);
                if (lstGift.Count > 0)
                {
                   Gives = new List<giftcartproduct>();

                    foreach (var gift in lstGift)
                    {
                        Gives.Add(new giftcartproduct(gift, CartNumber, this.Quantity));
                    }
                }


                
            }
          

        }


        /// <summary>
        /// 通过内容ID去获取一个 团购 商品的相关信息 yhl 2013-09-13
        /// </summary>
        /// <param name="md">商品实体</param>
        /// <param name="Quantity">购买数量</param>
        /// <param name="mdNorm">规格</param>
        /// <param name="gid"> 团购id</param>
        /// <param name="qid">抢购id</param>
        public Buy_CartItem(EbSite.Entity.NewsContent md, int Quantity, ModuleCore.Entity.NormRelationProduct mdNorm,int gid,int qid)
        {
            if (md != null)
            {
                CartNumber = EbSite.Core.SqlDateTimeInt.NewOrderNumberLong();
                //this.BuyUserID = EbSite.Base.Host.Instance.UserID;不能在此获取，真正添加到数据库的时候由profile生成的Id
                this.IsBuy = false;
                //this.WholesaleDiscountId = 批发折扣ID 要到数据库查询
                //this.WholesaleDiscountName = 批发折扣名称 要到数据库查询
                this.IsGift = false; //是否有赠品

                this.ThumbnailsUrl = md.SmallPic;
                this.Quantity = Quantity;
                this.ProductName = md.NewsTitle;
                this.ClassName = md.ClassName;
                this.CategoryId = md.ClassID;
                this.ProductId = md.ID;

                
                //团购时 没有积分 yhl 2013-09-13
                //if (!string.IsNullOrEmpty(md.Annex6))
                //{
                //    this.Points = EbSite.Core.Utils.StrToInt(md.Annex6, 0);
                //}
                this.Points = 0;
                if (qid > 0)//抢购有积分
                {
                    if (!string.IsNullOrEmpty(md.Annex6))
                    {
                        this.Points = EbSite.Core.Utils.StrToInt(md.Annex6, 0);
                    }
                    this.IsRobBuy = true;
                    this.IsGroup = false;
                }
               
                //查出团购价 或 抢购价
                decimal GroupPrice = 0;
                if (gid > 0)//团
                {
                    ModuleCore.Entity.GroupBuy groupModel = ModuleCore.BLL.GroupBuy.Instance.GetEntity(gid);
                    if (!Equals(groupModel, null))
                    {
                        GroupPrice = groupModel.BuyPrice;//团购价
                    }
                    this.IsGroup = true;
                    this.IsRobBuy = false;
                }
                if (qid > 0)//抢
                {
                    ModuleCore.Entity.CountDownBuy groupModel = ModuleCore.BLL.CountDownBuy.Instance.GetEntity(qid);
                    if (!Equals(groupModel, null))
                    {
                        GroupPrice = groupModel.CountDownPrice;//抢价
                    }
                }
                if (!string.IsNullOrEmpty(md.Annex2))
                {
                    this.MarketPrice = decimal.Parse(md.Annex2);//市场价
                }
                if (!Equals(mdNorm, null))
                {
                    //ModuleCore.Entity.NormRelationProduct nrp =
                    //    ModuleCore.BLL.NormRelationProduct.Instance.GetEntityByNormID(NormKey);
                    this.MemberPrice = GroupPrice;//mdNorm.SalePrice;//销售价
                    this.CostPrice = mdNorm.CostPrice;//成本价格
                    this.SKU = mdNorm.PNumber;
                    this.Weight = mdNorm.Weight;
                    //ModuleCore.
                    this.SKUContent = BLL.NormRelationProduct.Instance.GetShowInfoByNormKey(mdNorm.NormsValues);//由用户在外面post过来的 商品的规格 如 尺码：XXL; 颜色：卡其; 
                }
                else
                {
                    this.MemberPrice = GroupPrice;// md.Annex16;//销售价
                    this.CostPrice = md.Annex17;//市场价
                    this.SKU = md.Annex1;//商品编号
                    this.Weight = md.Annex18;

                }

                this.AdjustedPrice = GroupPrice;//yhl 2013-09-13 在这里赋值，别的地方没有找到呢。
            }


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
                //decimal pr = this._quantity*this.AdjustedPrice;
                //return pr + ProductOptionFree;
            }
        }
        /// <summary>
        /// 优惠折扣的金额，如果大于0,说明有优惠
        /// </summary>
        public decimal DiscountAmount
        {
            get { return TotalMemberPrice - TotalRealSellPrice; }
        }

        public string TotalRealSellPriceInfo
        {
            get
            {
                decimal da = DiscountAmount;
                if (da > 0)
                {
                    return string.Format("优惠:-{0}", da);
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

        ///// <summary>
        ///// 实际发货数量
        ///// </summary>
        //public int SendQuantity
        //{
        //    get
        //    {
        //        return Quantity + GiveQuantity;
        //    }
        //}
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

        #endregion

        #region Model
        public decimal Weight { get; set; }
        /// <summary>
        /// 规格值ID,对应SKUContent
        /// </summary>
        public string NormIDs { get; set; }

        private long _carnumber;
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
        private bool _isgroup;//是否 团购
        private bool _isrobbuy;//是否 抢购
        ////public decimal ProductOptionFree { get; set; }//订单费用选项

        public decimal ProductOptionFree
        {
            get
            {
                decimal OptionFee = 0;
                if (!Equals(SelOptionItems, null))
                {
                    foreach (var cartproductoptionvalue in SelOptionItems)
                    {
                        OptionFee += cartproductoptionvalue.TotalPrice;
                    }
                }
               
                return OptionFee;
            }
        }

        /// <summary>
        /// 订单号   在还没有提交订单时，也就是只在购物车里，订单ID为空
        /// </summary>
        public long CartNumber
        {
            set { _carnumber = value; }
            get { return _carnumber; }
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
        /// 是否团购
        /// </summary>
        public  bool IsGroup
        {
            get { return _isgroup; }
            set { _isgroup = value; }
        }
        /// <summary>
        /// 是否 抢购
        /// </summary>
        public  bool IsRobBuy
        {
            get { return _isrobbuy; }
            set { _isrobbuy = value;}
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
        /// 是否已经下单，分为两种情况，一种只是放到购物车，一种是已经下单  已经分表，不使用
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


        public List<Entity.cartproductoptionvalue> SelOptionItems;

        public List<Entity.giftcartproduct> Gives;

        /// <summary>
        /// 更新 满几送几 这个方法可以优化
        /// </summary>
        public void UpdateActivityInfo()
        {
            //重置活动信息
            PurchaseGiftId = 0;
            PurchaseGiftName = string.Empty;
            GiveQuantity = 0;

            WholesaleDiscountId = 0;
            WholesaleDiscountName = string.Empty;
            AdjustedPrice = MemberPrice;

            int RoleID = EbSite.Base.Host.Instance.RoleID;
            if (RoleID > 0)
            {
                Entity.PromotionFullNumGiveWithName pfgwn;
                Entity.PromotionWholesaleWithName pwwn;
                ModuleCore.BLL.Promotions.Instance.GetActivityInfo(RoleID, Quantity, ProductId, out pfgwn, out pwwn);

                if (pfgwn.PromotionsId > 0)  //存在满几送几
                {
                    PurchaseGiftId = pfgwn.PromotionsId;
                    PurchaseGiftName = pfgwn.PromotionsName;
                    GiveQuantity = pfgwn.GiveQuantity;
                }
                if (pwwn.PromotionsId > 0)  //存在满量打折
                {
                    WholesaleDiscountId = pwwn.PromotionsId;
                    WholesaleDiscountName = pwwn.PromotionsName;
                    AdjustedPrice = (pwwn.DiscountValue * MemberPrice) / 100;
                }
            }

            //更新相关数量
            if (!Equals(SelOptionItems, null))
            {
                foreach (var cartproductoptionvalue in SelOptionItems)
                {
                    cartproductoptionvalue.Quantity = Quantity;
                }
            }
            if (!Equals(Gives, null))
            {
                foreach (var givs in Gives)
                {
                    givs.BuyCount = Quantity;
                }
            }


            #region old
            //if (EbSite.Base.Host.Instance.RoleIDs.Count > 0)
            //{
            //    //促销活动类型 1.满额打折 2.买几送几 3.满额免费用 4.批发打折 
            //    //先查看是否存在 满几送几活动
            //    List<Entity.Promotions> lstPromotions = ModuleCore.BLL.Promotions.Instance.GetBuyNumGiveNum();
            //    if (lstPromotions.Count > 0)
            //    {
            //        string PromotionsIDs = ModuleCore.BLL.Promotions.Instance.ExistsPurchaseGift(lstPromotions);
            //        if (!string.IsNullOrEmpty(PromotionsIDs))
            //        {
            //            //检测当前用户角色下是否存在于这些活动ID
            //            List<Entity.PromotionsRole> prs = ModuleCore.BLL.PromotionsRole.Instance.ExistsPromotionsRole(PromotionsIDs,
            //                                                                        EbSite.Base.Host.Instance.RoleIDs[0]);
            //            if (prs.Count > 0) //有多个，要获取最有价值的那个,一般来说只有一个
            //            {
            //                int PromotionsID = prs[0].PromotionsID;
            //                if (ModuleCore.BLL.PromotionProduct.Instance.ExistsProductAndPromotionsID(ProductId,
            //                                                                                      PromotionsID))
            //                {
            //                    Entity.PromotionFullNumGive md = ModuleCore.BLL.PromotionFullNumGive.Instance.GetEntityByPromotionsID(PromotionsID);
            //                    if (!Equals(md, null))
            //                    {
            //                        if (md.BuyQuantity >= Quantity)
            //                        {
            //                            GiveQuantity = md.GiveQuantity;

            //                            //IEnumerable<Entity.Promotions> iePromotions = lstPromotions.Where(d => d.id == PromotionsID);
            //                            //if(iePromotions.Count()>0)
            //                            //{
            //                            //    PurchaseGiftId = PromotionsID;
            //                            //    PurchaseGiftName = iePromotions
            //                            //}

            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }

            //}
            #endregion

        }


    }
}

