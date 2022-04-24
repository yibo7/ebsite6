using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.Core.Cart
{
    /// <summary>
    /// 积分兑换商品的购物车
    /// </summary>
    public partial class CartManger
    {

        private Dictionary<int, Entity.Buy_CreditCartItem> _CreditCartItems = new Dictionary<int, Entity.Buy_CreditCartItem>();


        /// <summary>
        /// 添加一个商品到购物车
        /// </summary>

        public void AddCredit(int iCreditProductID)
        {
            if (iCreditProductID > 0)
            {
                Entity.Buy_CreditCartItem CreditCartItem;
                ModuleCore.Entity.creditproduct md = null;

                bool IsHave = ModuleCore.BLL.creditproduct.Instance.Exists(iCreditProductID);
                if (IsHave)
                {
                    md = ModuleCore.BLL.creditproduct.Instance.GetEntity(iCreditProductID);

                    if (!_CreditCartItems.TryGetValue(iCreditProductID, out CreditCartItem))
                    {
                        _CreditCartItems.Add(iCreditProductID, new Entity.Buy_CreditCartItem(md));
                    }
                    else
                    {
                        CreditCartItem.Quantity++;
                    }

                }

            }

        }

        /// <summary>
        /// 返回购物车商品列表
        /// </summary>
        /// <returns>Collection of CartItemInfo</returns>
        public ICollection<Entity.Buy_CreditCartItem> CreditCartItems
        {
            get { return _CreditCartItems.Values; }
        }

        /// <summary>
        /// 添加一个商品到购物中心车
        /// </summary>
        /// <param name="item">要添加的商品对象</param>
        public void AddCreditCartItem(Entity.Buy_CreditCartItem item)
        {
            Entity.Buy_CreditCartItem creditCartItems;
            if (!_CreditCartItems.TryGetValue(item.CreditProductID, out creditCartItems))
                _CreditCartItems.Add(item.CreditProductID, item);
            else
                creditCartItems.Quantity += item.Quantity;
        }
        /// <summary>
        /// 设置  积分兑换 商品的数量
        /// </summary>
        /// <param name="ProductID">商品ID</param>
        /// <param name="qty">数量</param>
        public void SetCreditQuantity(int ProductID, int qty)
        {
            _CreditCartItems[ProductID].Quantity = qty;

        }
        /// <summary>
        /// 从购物车删除一个商品
        /// </summary>
        /// <param name="ProductID">商品ID</param>
        public void RemoveCredit(int ProductID)
        {
            _CreditCartItems.Remove(ProductID);
        }
        /// <summary>
        /// 积分商的总数量
        /// </summary>
        public int CreditCount
        {
            get
            {
                int total = 0;
                foreach (Entity.Buy_CreditCartItem item in _CreditCartItems.Values)
                    total += item.Quantity;
                return total;
            }
        }
        /// <summary>
        /// 积分商品 所需要的总积分
        /// </summary>
        public int CreditSocre
        {
            get
            {
                int iScore = 0;
                foreach (Entity.Buy_CreditCartItem item in _CreditCartItems.Values)
                    iScore += item.Credit * item.Quantity;
                return iScore;
            }
        }
    }
}