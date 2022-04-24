using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Modules.Shop.ModuleCore.Cart;

namespace EbSite.Modules.Shop.ModuleCore.BLL
{
    /// <summary>
    /// 业务逻辑类Buy_CartItem 的摘要说明。
    /// </summary>
    public class Buy_CartItem : Base.BLLBase<Entity.Buy_CartItem, int>
    {
        public static readonly Buy_CartItem Instance = new Buy_CartItem();
        private Buy_CartItem()
        {
        }

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dalHelper.Buy_CartItem_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dalHelper.Buy_CartItem_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.Buy_CartItem model)
        {
            base.InvalidateCache();
            return dalHelper.Buy_CartItem_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.Buy_CartItem model)
        {
            base.InvalidateCache();
            dalHelper.Buy_CartItem_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            dalHelper.Buy_CartItem_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.Buy_CartItem GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.Buy_CartItem etEntity = base.GetCacheItem<Entity.Buy_CartItem>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = dalHelper.Buy_CartItem_GetEntity(id);
                if (!Equals(etEntity, null))
                    base.AddCacheItem(rawKey, etEntity);
            }
            return etEntity;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dalHelper.Buy_CartItem_GetCount(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCountCache(string strWhere)
        {
            string rawKey = string.Concat("GetCount-", strWhere);
            string sCount = base.GetCacheItem<string>(rawKey);
            if (string.IsNullOrEmpty(sCount))
            {
                sCount = GetCount(strWhere).ToString();
                if (!string.IsNullOrEmpty(sCount))
                    base.AddCacheItem(rawKey, sCount);
            }
            if (!string.IsNullOrEmpty(sCount))
            {
                return int.Parse(sCount);
            }
            return 0;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCount()
        {
            return GetCountCache("");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return GetListCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return GetList("");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dalHelper.Buy_CartItem_GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetList-", strWhere, Top, filedOrder);
            byte[] ibyte = base.GetCacheItem<byte[]>(rawKey);
            DataSet lstData = null;
            if (Equals(ibyte, null))
            {
                lstData = GetList(Top, strWhere, filedOrder);
                ibyte = EbSite.Core.DataSetHelper.GetBinaryFormatDataSet(lstData);
                if (!Equals(ibyte, null))
                    base.AddCacheItem(rawKey, ibyte);
            }
            else
            {
                lstData =EbSite.Core.DataSetHelper.RetrieveDataSet(ibyte);
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.Buy_CartItem> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dalHelper.Buy_CartItem_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Buy_CartItem> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.Buy_CartItem> lstData = base.GetCacheItem<List<Entity.Buy_CartItem>>(rawKey);
            if (Equals(lstData, null))
            {
                //从基类调用，激活事件
                lstData = base.GetListArrayEv(Top, strWhere, filedOrder);
                if (!Equals(lstData, null))
                    base.AddCacheItem(rawKey, lstData);
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Buy_CartItem> GetListArray(int Top, string filedOrder)
        {
            base.InvalidateCache();
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Buy_CartItem> GetListArray(string strWhere)
        {
            base.InvalidateCache();
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.Buy_CartItem> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dalHelper.Buy_CartItem_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Buy_CartItem> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.Buy_CartItem> lstData = base.GetCacheItem<List<Entity.Buy_CartItem>>(rawKey);
            int iRecordCount = -1;
            if (Equals(lstData, null))
            {
                //从基类调用，激活事件
                lstData = base.GetListPagesEv(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
                if (!Equals(lstData, null))
                {
                    base.AddCacheItem(rawKey, lstData);
                    base.AddCacheItem(rawKeyCount, RecordCount.ToString());
                }
            }
            if (iRecordCount == -1)
            {
                string sCount = base.GetCacheItem<string>(rawKeyCount);
                if (!string.IsNullOrEmpty(sCount))
                {
                    RecordCount = int.Parse(sCount);
                }
                else
                {
                    RecordCount = GetCountCache(strWhere);
                }
            }
            else
            {
                RecordCount = iRecordCount;
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Buy_CartItem> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Buy_CartItem> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Buy_CartItem> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.Buy_CartItem> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(sKeyWord)) strWhere = string.Format("{0} like '%{1}%'", ColumnName, sKeyWord);
            if (string.IsNullOrEmpty(strWhere))
            {
                RecordCount = 0;
                return null;
            }
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 修改时获取当前实例，并载入控件到PlaceHolder
        /// </summary>
        public void InitModifyCtr(string id, PlaceHolder ph)
        {
            if (!string.IsNullOrEmpty(id))
            {
                int ThisId = int.Parse(id);
                Entity.Buy_CartItem mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CartNumber".ToLower()))
                    {
                        sValue = mdEt.CartNumber.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "WholesaleDiscountId".ToLower()))
                    {
                        sValue = mdEt.WholesaleDiscountId.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "WholesaleDiscountName".ToLower()))
                    {
                        sValue = mdEt.WholesaleDiscountName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "IsGift".ToLower()))
                    {
                        sValue = mdEt.IsGift.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SKUContent".ToLower()))
                    {
                        sValue = mdEt.SKUContent.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ThumbnailsUrl".ToLower()))
                    {
                        sValue = mdEt.ThumbnailsUrl.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SKU".ToLower()))
                    {
                        sValue = mdEt.SKU.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Quantity".ToLower()))
                    {
                        sValue = mdEt.Quantity.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "MemberPrice".ToLower()))
                    {
                        sValue = mdEt.MemberPrice.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ProductName".ToLower()))
                    {
                        sValue = mdEt.ProductName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ClassName".ToLower()))
                    {
                        sValue = mdEt.ClassName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "MarketPrice".ToLower()))
                    {
                        sValue = mdEt.MarketPrice.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CategoryId".ToLower()))
                    {
                        sValue = mdEt.CategoryId.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ProductId".ToLower()))
                    {
                        sValue = mdEt.ProductId.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "BuyUserID".ToLower()))
                    {
                        sValue = mdEt.BuyUserID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "IsBuy".ToLower()))
                    {
                        sValue = mdEt.IsBuy.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "AddDateTime".ToLower()))
                    {
                        sValue = mdEt.AddDateTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Weight".ToLower()))
                    {
                        sValue = mdEt.Weight.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "NormIDs".ToLower()))
                    {
                        sValue = mdEt.NormIDs.ToString();
                    }
                    SetValueFromControl(uc, sValue);
                }
            }
        }
        /// <summary>
        /// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
        /// </summary>
        public void SaveEntityFromCtr(PlaceHolder ph)
        {
            SaveEntityFromCtr(ph, null);
        }
        /// <summary>
        /// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
        /// </summary>
        public void SaveEntityFromCtr(PlaceHolder ph, List<EbSite.Base.BLL.OtherColumn> lstOtherColumn)
        {
            Entity.Buy_CartItem mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CartNumber".ToLower()))
                    {
                        mdEntity.CartNumber = long.Parse( column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "WholesaleDiscountId".ToLower()))
                    {
                        mdEntity.WholesaleDiscountId = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "WholesaleDiscountName".ToLower()))
                    {
                        mdEntity.WholesaleDiscountName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "IsGift".ToLower()))
                    {
                        mdEntity.IsGift = bool.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "SKUContent".ToLower()))
                    {
                        mdEntity.SKUContent = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ThumbnailsUrl".ToLower()))
                    {
                        mdEntity.ThumbnailsUrl = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "SKU".ToLower()))
                    {
                        mdEntity.SKU = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Quantity".ToLower()))
                    {
                        mdEntity.Quantity = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "MemberPrice".ToLower()))
                    {
                        mdEntity.MemberPrice = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ProductName".ToLower()))
                    {
                        mdEntity.ProductName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ClassName".ToLower()))
                    {
                        mdEntity.ClassName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "MarketPrice".ToLower()))
                    {
                        mdEntity.MarketPrice = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CategoryId".ToLower()))
                    {
                        mdEntity.CategoryId = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ProductId".ToLower()))
                    {
                        mdEntity.ProductId = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "BuyUserID".ToLower()))
                    {
                        mdEntity.BuyUserID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "IsBuy".ToLower()))
                    {
                        mdEntity.IsBuy = bool.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "AddDateTime".ToLower()))
                    {
                        mdEntity.AddDateTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Weight".ToLower()))
                    {
                        mdEntity.Weight = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "NormIDs".ToLower()))
                    {
                        mdEntity.NormIDs = column.ColumnValue;
                    }
                }
            }
            if (mdEntity.id > 0)
            {
                Update(mdEntity);
            }
            else
            {
                Add(mdEntity);
            }
        }
        /// <summary>
        /// 从PlaceHolder中获取一个实例
        /// </summary>
        public Entity.Buy_CartItem GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.Buy_CartItem mdEt = new Entity.Buy_CartItem();
            string sKeyID;
            if (GetIDFromCtr(ph, out sKeyID))
            {
                mdEt = GetEntity(int.Parse(sKeyID));
            }
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = GetValueFromControl(uc);
                if (Equals(uc.ID.ToLower(), "id".ToLower()))
                {
                    mdEt.id = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "CartNumber".ToLower()))
                {
                    mdEt.CartNumber =long.Parse( sValue);
                }
                else if (Equals(uc.ID.ToLower(), "WholesaleDiscountId".ToLower()))
                {
                    mdEt.WholesaleDiscountId = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "WholesaleDiscountName".ToLower()))
                {
                    mdEt.WholesaleDiscountName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "IsGift".ToLower()))
                {
                    mdEt.IsGift = bool.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "SKUContent".ToLower()))
                {
                    mdEt.SKUContent = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ThumbnailsUrl".ToLower()))
                {
                    mdEt.ThumbnailsUrl = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "SKU".ToLower()))
                {
                    mdEt.SKU = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Quantity".ToLower()))
                {
                    mdEt.Quantity = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "MemberPrice".ToLower()))
                {
                    mdEt.MemberPrice = decimal.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ProductName".ToLower()))
                {
                    mdEt.ProductName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ClassName".ToLower()))
                {
                    mdEt.ClassName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "MarketPrice".ToLower()))
                {
                    mdEt.MarketPrice = decimal.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "CategoryId".ToLower()))
                {
                    mdEt.CategoryId = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ProductId".ToLower()))
                {
                    mdEt.ProductId = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "BuyUserID".ToLower()))
                {
                    mdEt.BuyUserID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "IsBuy".ToLower()))
                {
                    mdEt.IsBuy = bool.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "AddDateTime".ToLower()))
                {
                    mdEt.AddDateTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Weight".ToLower()))
                {
                    mdEt.Weight = decimal.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "NormIDs".ToLower()))
                {
                    mdEt.NormIDs = sValue;
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法
        //要实现这个方法
        public List<Entity.Buy_CartItem> GetCartItems(int uniqueID, string applicationName, out List<ModuleCore.Entity.Buy_CreditCartItem> lstBuy_CreditCartItem)
        {
            List<Entity.Buy_CartItem> lc = dalHelper.Buy_CartItem_GetListArray(0, string.Concat("BuyUserID=", uniqueID), "");// and IsRobBuy=0 and IsGroup=0
            lstBuy_CreditCartItem = BLL.Buy_CreditCartItem.Instance.GetListArray(string.Concat("UserID=", uniqueID));
            return lc;
        }
        /// <summary>
        /// 删除某个用户标识下的记录
        /// </summary>
        /// <param name="uniqueID"></param>
        public void DeleteByUniqueID(int uniqueID)
        {
            dalHelper.DeleteByUniqueID(uniqueID);
          
        }

        //要实现这个方法 往购物车中添加
        //public void SetCartItems(int uniqueID, ICollection<Entity.Buy_CartItem> cartItems)
        //{
        //    DeleteByUniqueID(uniqueID); //先删除，所以修改数量的时候也是重新添加
        //    if (cartItems.Count > 0)
        //    {
        //        foreach (Entity.Buy_CartItem li in cartItems)
        //        {
        //            li.UpdateActivityInfo();//批发打折,买几关几
        //            li.BuyUserID = uniqueID;//很重要，不能直接取userid,这里由profile生成的ID，如果登录为真实id,如果没登录为临时ID
        //            Add(li);

        //        }

        //    }
        //}



        ///// <summary>
        ///// 修改订单商品信息  2013-9-10注释
        ///// </summary>
        ///// <param name="dicArray">要修改的字段集合</param>
        ///// <param name="tid">ID</param>
        ///// <returns></returns>
        //public bool UpdateByDic(Dictionary<string, object> dicArray, int tid)
        //{
        //    return dalHelper.UpdateByDic_OrderItems(dicArray, tid);
        //}
        ///// <summary>
        ///// 修改订单商品信息 2013-9-10注释
        ///// </summary>
        ///// <param name="dicArray">要修改的字段集合</param>
        ///// <param name="tid">ID</param>
        ///// <returns></returns>
        //public bool UpdateByDic(Dictionary<string, object> dicArray, Dictionary<string, object> dicArrayOrder, int tid, int rid)
        //{
        //    return dalHelper.UpdateByDic_OrderItems(dicArray,dicArrayOrder,tid,rid);
        //}


        public CartManger GetCartManger(int uniqueID, string applicationName)
        {
            CartManger cart = new CartManger();

            List<ModuleCore.Entity.Buy_CreditCartItem> lstBuy_CreditCartItem = null;
            List<ModuleCore.Entity.Buy_CartItem> lst = ModuleCore.BLL.Buy_CartItem.Instance.GetCartItems(uniqueID,
                                                                                                           applicationName, out lstBuy_CreditCartItem);
            foreach (ModuleCore.Entity.Buy_CartItem cartItem in lst)
            {
                //需要优化查询
                cartItem.SelOptionItems = ModuleCore.BLL.cartproductoptionvalue.Instance.GetListArrayByCarItemID(cartItem.CartNumber);
                cartItem.Gives = ModuleCore.BLL.giftcartproduct.Instance.GetListArrayByCarItemID(cartItem.CartNumber);
                cart.Add(cartItem);
            }

            if (!Equals(lstBuy_CreditCartItem, null))
            {
                foreach (ModuleCore.Entity.Buy_CreditCartItem creditcartitem in lstBuy_CreditCartItem)
                {
                    cart.AddCreditCartItem(creditcartitem);
                }

            }
           

            return cart;
        }
        /// <summary>
        /// 要实现这个方法 往购物车中添加
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <param name="cart"></param>
        public void SetCartItems(int uniqueID, CartManger cart)
        {
            ICollection<Entity.Buy_CartItem> cartItems = cart.CartItems;
            ICollection<Entity.Buy_CreditCartItem> cartCreditItems = cart.CreditCartItems;
            DeleteByUniqueID(uniqueID); //先删除，所以修改数量的时候也是重新添加

            if (cartItems.Count > 0)
            {
                foreach (Entity.Buy_CartItem li in cartItems)
                {
                    if (!li.IsGroup&&!li.IsRobBuy)//  是否团购 yhl 2013-09-13 2014-1-17 yhl 修改 添加  抢购
                    {
                        li.UpdateActivityInfo(); //批发打折,买几关几
                    }
                    li.BuyUserID = uniqueID;//很重要，不能直接取userid,这里由profile生成的ID，如果登录为真实id,如果没登录为临时ID
                    Add(li);
                }
            }

            if (cartCreditItems.Count > 0)
            {
                foreach (Entity.Buy_CreditCartItem li in cartCreditItems)
                {
                    li.UserID = uniqueID;
                    BLL.Buy_CreditCartItem.Instance.Add(li);
                }
            }
            else
            {
                BLL.Buy_CreditCartItem.Instance.ClearCache();
            }
           
            
        }

        #endregion  自定义方法
    }
}

