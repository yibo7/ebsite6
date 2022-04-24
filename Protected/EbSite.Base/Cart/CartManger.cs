//using System;
//using System.Collections.Generic;
//using System.Web;
//namespace EbSite.Base.Cart
//{
//    /// <summary>
//    /// 一个购物车处理类
//    /// </summary>
//    [Serializable]
//    public class CartManger
//    {

//        // 购物车集合  
//        private Dictionary<string, CartItem> cartItems = new Dictionary<string, CartItem>();

//        /// <summary>
//        /// 统计整个购物车中商品的市场价格
//        /// </summary>
//        public decimal Total
//        {
//            get
//            {
//                decimal total = 0;
//                foreach (CartItem item in cartItems.Values)
//                    total += item.MarketPrice * item.Quantity;
//                return total;
//            }
//        }
//        /// <summary>
//        /// 统计整个购物车中商品的会员价格
//        /// </summary>
//        public decimal TotalMember
//        {
//            get
//            {
//                decimal total = 0;
//                foreach (CartItem item in cartItems.Values)
//                    total += item.MemberPrice * item.Quantity;
//                return total;
//            }
//        }
//        /// <summary>
//        /// 统计本次购物节省多少钱
//        /// </summary>
//        public decimal TotalFrugal
//        {
//            get { return Total - TotalMember; }
//        }
//        /// <summary>
//        /// 统计购物车里有多少条记录
//        /// </summary>
//        public int Count
//        {
//            get
//            {
//                int total  = 0;
//                foreach (CartItem item in cartItems.Values)
//                    total += item.Quantity;
//                return total;
//            }
//        }

//        /// <summary>
//        /// 设置商品的购物数量
//        /// </summary>
//        /// <param name="ProductID">商品ID</param>
//        /// <param name="qty">数量</param>
//        public void SetQuantity(string sku, int qty)
//        {
//            cartItems[sku].Quantity = qty;
//        }
       

//        ///// <summary>
//        ///// 添加一个商品到购物车
//        ///// </summary>
//        ///// <param name="ProductID">商品ID</param>
//        //public void Add(int ProductID)
//        //{
//        //    Entity.Buy_OrderItem cartItem;
//        //    if (!cartItems.TryGetValue(ProductID, out cartItem))
//        //    {
//        //        bool IsHave = EbSite.BLL.NewsContent.Exists(ProductID);//选通过ID判断是否存在此商品
//        //        if (IsHave)
//        //        {
//        //            EbSite.Entity.NewsContent md = EbSite.BLL.NewsContent.GetModel(ProductID);
//        //            cartItems.Add(ProductID, new Entity.Buy_OrderItem(md));
//        //        }
//        //    }
//        //    else
//        //        cartItem.Quantity++;
//        //}

//       /// <summary>
//        /// 添加一个商品到购物车
//       /// </summary>
//       /// <param name="ProductID">商品ID</param>
//       /// <param name="Num">购买数量</param>
//        /// <param name="NormKey">NormKey规格ID</param>
//        public void Add(int iProductID, int Num, string NormKey)
//        {
//            if(Num>0)
//            {
//                CartItem cartItem;

//                string ProductNumber = string.Empty;
//                ModuleCore.Entity.NormRelationProduct nrp = null;
//                EbSite.Entity.NewsContent md = null;
                
//                bool IsHave = EbSite.BLL.NewsContent.Exists(iProductID);
//                if (IsHave)
//                {
//                    md = EbSite.BLL.NewsContent.GetModel(iProductID);
//                    ProductNumber = md.Annex1;
//                }
                
//                if (!string.IsNullOrEmpty(NormKey))
//                {
//                    nrp = ModuleCore.BLL.NormRelationProduct.Instance.GetEntityByNormID(NormKey.Trim());
//                    ProductNumber = nrp.PNumber;
//                }
//                if (!Equals(md,null))
//                {
//                    if (!cartItems.TryGetValue(ProductNumber, out cartItem))
//                    {
//                        cartItems.Add(ProductNumber, new Entity.Buy_OrderItem(md, Num, nrp));
//                    }
//                    else
//                        cartItem.Quantity++;
//                }
                
//            }
            
//        }

        

//        /// <summary>
//        /// 添加一个商品到购物中心车
//        /// </summary>
//        /// <param name="item">要添加的商品对象</param>
//        public void Add(CartItem item)
//        {
//            CartItem cartItem;
//            if (!cartItems.TryGetValue(item.SKU, out cartItem))
//                cartItems.Add(item.SKU, item);
//            else
//                cartItem.Quantity += item.Quantity;
//        }

//        /// <summary>
//        /// 从购物车删除一个商品
//        /// </summary>
//        /// <param name="ProductID">商品ID</param>
//        public void Remove(string ProductID)
//        {
//            cartItems.Remove(ProductID);
//        }

//        /// <summary>
//        /// 返回购物车商品列表
//        /// </summary>
//        /// <returns>Collection of CartItemInfo</returns>
//        public ICollection<CartItem> CartItems
//        {
//            get { return cartItems.Values; }
//        }
//        /// <summary>
//        /// 清空购物车
//        /// </summary>
//        public void Clear()
//        {
//            cartItems.Clear();
//        }
        
//    }
//}