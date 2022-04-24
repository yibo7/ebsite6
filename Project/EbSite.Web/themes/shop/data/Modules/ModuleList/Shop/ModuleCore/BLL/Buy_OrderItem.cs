using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Shop.ModuleCore.BLL
{
    /// <summary>
    /// 业务逻辑类Buy_OrderItem 的摘要说明。
    /// </summary>
    public class Buy_OrderItem : Base.BLLBase<Entity.Buy_OrderItem, int>
    {
        public static readonly Buy_OrderItem Instance = new Buy_OrderItem();
        private Buy_OrderItem()
        {
        }

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dalHelper.Buy_OrderItem_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dalHelper.Buy_OrderItem_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.Buy_OrderItem model)
        {
            base.InvalidateCache();
            return dalHelper.Buy_OrderItem_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.Buy_OrderItem model)
        {
            base.InvalidateCache();
            dalHelper.Buy_OrderItem_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            dalHelper.Buy_OrderItem_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.Buy_OrderItem GetEntity(int id)
        {
            Entity.Buy_OrderItem etEntity =dalHelper.Buy_OrderItem_GetEntity(id);
            return etEntity;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dalHelper.Buy_OrderItem_GetCount(strWhere);
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
            return dalHelper.Buy_OrderItem_GetList(Top, strWhere, filedOrder);
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
                lstData = EbSite.Core.DataSetHelper.RetrieveDataSet(ibyte);
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.Buy_OrderItem> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dalHelper.Buy_OrderItem_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Buy_OrderItem> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.Buy_OrderItem> lstData = base.GetCacheItem<List<Entity.Buy_OrderItem>>(rawKey);
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
        public List<Entity.Buy_OrderItem> GetListArray(int Top, string filedOrder)
        {
            base.InvalidateCache();
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Buy_OrderItem> GetListArray(string strWhere)
        {
            base.InvalidateCache();
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.Buy_OrderItem> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dalHelper.Buy_OrderItem_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Buy_OrderItem> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.Buy_OrderItem> lstData = base.GetCacheItem<List<Entity.Buy_OrderItem>>(rawKey);
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
        public List<Entity.Buy_OrderItem> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Buy_OrderItem> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Buy_OrderItem> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.Buy_OrderItem> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.Buy_OrderItem mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "OrderId".ToLower()))
                    {
                        sValue = mdEt.OrderId.ToString();
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
            Entity.Buy_OrderItem mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "OrderId".ToLower()))
                    {
                        mdEntity.OrderId =long.Parse( column.ColumnValue);
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
        public Entity.Buy_OrderItem GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.Buy_OrderItem mdEt = new Entity.Buy_OrderItem();
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
                else if (Equals(uc.ID.ToLower(), "OrderId".ToLower()))
                {
                    mdEt.OrderId =long.Parse( sValue);
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
        ////要实现这个方法
        //public List<Entity.Buy_OrderItem> GetCartItems(int uniqueID, string applicationName)
        //{
        //    return dalHelper.Buy_OrderItem_GetListArray(0, string.Concat("BuyUserID=", uniqueID), "");
        //}
        ///// <summary>
        ///// 删除某个用户标识下的记录
        ///// </summary>
        ///// <param name="uniqueID"></param>
        //public void DeleteByUniqueID(int uniqueID)
        //{
        //    dalHelper.DeleteByUniqueID(uniqueID);
          
        //}

        ////要实现这个方法 往购物车中添加
        //public void SetCartItems(int uniqueID, ICollection<Entity.Buy_OrderItem> cartItems)
        //{
        //    DeleteByUniqueID(uniqueID); //先删除，所以修改的时候也是重新添加
        //    if (cartItems.Count > 0)
        //    {
        //        foreach (Entity.Buy_OrderItem li in cartItems)
        //        {
        //            li.UpdateActivityInfo();//批发打折,买几关几
        //            li.BuyUserID = uniqueID;//很重要，不能直接取userid,这里由profile生成的ID，如果登录为真实id,如果没登录为临时ID
        //            Add(li);

        //        }

        //    }
        //}

        /// <summary>
        /// 修改订单商品信息
        /// </summary>
        /// <param name="dicArray">要修改的字段集合</param>
        /// <param name="tid">ID</param>
        /// <returns></returns>
        public bool UpdateByDic(Dictionary<string, object> dicArray, int tid)
        {
            return dalHelper.UpdateByDic_OrderItems(dicArray, tid);
        }
        /// <summary>
        /// 修改订单商品信息
        /// </summary>
        /// <param name="dicArray">要修改的字段集合</param>
        /// <param name="tid">ID</param>
        /// <returns></returns>
        public bool UpdateByDic(Dictionary<string, object> dicArray, Dictionary<string, object> dicArrayOrder, int tid, int rid)
        {
            return dalHelper.UpdateByDic_OrderItems(dicArray,dicArrayOrder,tid,rid);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="dicData">要更新的集合</param>
        /// <param name="rid">ID</param>
        public bool UpdateOrderItemByDic(Dictionary<string, object> dicArray, int id)
        {
            return dalHelper.Buy_OrderItem_UpdateByDic(dicArray, id);
        }


        public bool UpdateCreditByDic(Dictionary<string, object> dicArray, int id)

        {
            return dalHelper.Buy_OrderItem_UpdateByDic(dicArray, id);
        }

         /// <summary>
        /// 获取指定用户的退换货列表
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        public DataTable GetTHOrderItemList(int uid)
        {
            return dalHelper.Buy_OrderItem_GetTHOrderItemList(uid);
        }
        /// <summary>
        /// 获取指定用户的退换货列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTHOrderItemList()
        {
            return dalHelper.Buy_OrderItem_GetTHOrderItemList();
        }


     public List<Entity.Buy_OrderItem> GetTHOrderItem_GetListPages(int PageIndex, int PageSize,
                                                                                 out int RecordCount, string orderid)
     {
         return dalHelper.Buy_OrderItem_GetTHOrderItem_GetListPages(PageIndex, PageSize, out RecordCount, orderid);
     }

     public List<Entity.Buy_OrderItem> GetTHOrderItem_GetListPages(int uid, int PageIndex, int PageSize,
                                                                                 out int RecordCount)
     {
         return dalHelper.Buy_OrderItem_GetTHOrderItem_GetListPages(uid,PageIndex, PageSize, out RecordCount);
     }
        /// <summary>
        /// 获取商品销售排行
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="itop">前几条</param>
        /// <returns></returns>
        public DataTable GetSaleTop(string strWhere, int itop)
        {
            return dalHelper.Buy_OrderItem_GetSaleTop(strWhere,itop);
        }

        #endregion  自定义方法
    }
}

