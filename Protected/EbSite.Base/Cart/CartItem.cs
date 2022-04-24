//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Configuration;
//using System.Web;
//using System.Web.Profile;
//using EbSite.Base;
//using EbSite.Base.EBSiteEventArgs;
//using EbSite.Entity;

//namespace EbSite.Base.Cart
//{
//    public class CartItem 
//    {
//        private decimal _memberprice;//会员价，销售价
//        private string _productname;//商品名称
//        private decimal _marketprice;
//        private string _productid;
//        private int _quantity;//订购数量
//        /// <summary>
//        /// 商品ID，对应ebsite的内容ID，自增
//        /// </summary>
//        public string ProductId
//        {
//            set { _productid = value; }
//            get { return _productid; }
//        }
//        /// <summary>
//        /// 订购数量
//        /// </summary>
//        public int Quantity
//        {
//            set { _quantity = value; }
//            get { return _quantity; }
//        }
//        /// <summary>
//        /// 会员价，销售价
//        /// </summary>
//        public decimal MemberPrice
//        {
//            set { _memberprice = value; }
//            get { return _memberprice; }
//        }
//        /// <summary>
//        /// 商品名称
//        /// </summary>
//        public string ProductName
//        {
//            set { _productname = value; }
//            get { return _productname; }
//        }
//        /// <summary>
//        /// 市场价
//        /// </summary>
//        public decimal MarketPrice
//        {
//            set { _marketprice = value; }
//            get { return _marketprice; }
//        }

//    }
//}