using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ModuleCore.BLL
{
    /// <summary>
    /// 业务逻辑类ProductOptionItems 的摘要说明。
    /// </summary>
    public class ProductOptionItems : Base.BLLBase<Entity.ProductOptionItems, int>
    {
        public static readonly ProductOptionItems Instance = new ProductOptionItems();
        private ProductOptionItems()
        {
        }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dalHelper.ProductOptionItems_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dalHelper.ProductOptionItems_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.ProductOptionItems model)
        {
            base.InvalidateCache();
            return dalHelper.ProductOptionItems_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.ProductOptionItems model)
        {
            base.InvalidateCache();
            dalHelper.ProductOptionItems_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            dalHelper.ProductOptionItems_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.ProductOptionItems GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.ProductOptionItems etEntity = base.GetCacheItem<Entity.ProductOptionItems>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = dalHelper.ProductOptionItems_GetEntity(id);
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
            return dalHelper.ProductOptionItems_GetCount(strWhere);
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
            return dalHelper.ProductOptionItems_GetList(Top, strWhere, filedOrder);
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
        override public List<Entity.ProductOptionItems> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dalHelper.ProductOptionItems_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.ProductOptionItems> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.ProductOptionItems> lstData = base.GetCacheItem<List<Entity.ProductOptionItems>>(rawKey);
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
        public List<Entity.ProductOptionItems> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.ProductOptionItems> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.ProductOptionItems> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dalHelper.ProductOptionItems_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.ProductOptionItems> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.ProductOptionItems> lstData = base.GetCacheItem<List<Entity.ProductOptionItems>>(rawKey);
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
        public List<Entity.ProductOptionItems> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.ProductOptionItems> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.ProductOptionItems> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.ProductOptionItems> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.ProductOptionItems mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ProductOptionID".ToLower()))
                    {
                        sValue = mdEt.ProductOptionID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ItemName".ToLower()))
                    {
                        sValue = mdEt.ItemName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "IsGive".ToLower()))
                    {
                        sValue = mdEt.IsGive.ToString();
                    }

                    else if (Equals(uc.ID.ToLower(), "AppendMoney".ToLower()))
                    {
                        sValue = mdEt.AppendMoney.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CalculateMode".ToLower()))
                    {
                        sValue = mdEt.CalculateMode.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Remark".ToLower()))
                    {
                        sValue = mdEt.Remark.ToString();
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
            Entity.ProductOptionItems mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ProductOptionID".ToLower()))
                    {
                        mdEntity.ProductOptionID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ItemName".ToLower()))
                    {
                        mdEntity.ItemName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "IsGive".ToLower()))
                    {
                        mdEntity.IsGive = bool.Parse(column.ColumnValue);
                    }

                    else if (Equals(column.ColumnName.ToLower(), "AppendMoney".ToLower()))
                    {
                        mdEntity.AppendMoney = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CalculateMode".ToLower()))
                    {
                        mdEntity.CalculateMode = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Remark".ToLower()))
                    {
                        mdEntity.Remark = column.ColumnValue;
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
        public Entity.ProductOptionItems GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.ProductOptionItems mdEt = new Entity.ProductOptionItems();
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
                else if (Equals(uc.ID.ToLower(), "ProductOptionID".ToLower()))
                {
                    mdEt.ProductOptionID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ItemName".ToLower()))
                {
                    mdEt.ItemName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "IsGive".ToLower()))
                {
                    mdEt.IsGive = bool.Parse(sValue);
                }

                else if (Equals(uc.ID.ToLower(), "AppendMoney".ToLower()))
                {
                    mdEt.AppendMoney = decimal.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "CalculateMode".ToLower()))
                {
                    mdEt.CalculateMode = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Remark".ToLower()))
                {
                    mdEt.Remark = sValue;
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法

        public List<Entity.ProductOptionItems> GetListArrayInIDs(string IDs)
        {
            return dalHelper.ProductOptionItems_GetListArrayInIDs(IDs);
        }

        public List<Entity.ProductOptionItems> GetListArrayByOptionID(int optionid)
        {
            return dalHelper.ProductOptionItems_GetListArray(0, string.Concat("ProductOptionID=", optionid), "");
        }
        public List<Entity.ProductOptionItems> GetListArrayByProductID(int ProductID)
        {
            return dalHelper.ProductOptionItems_GetListArrayByProductID(ProductID);
        }
        public List<Entity.ProductOption> GetListArrayByPID(int ProductID)
        {
            List<Entity.ProductOptionItems> lst = GetListArrayByProductID(ProductID);

            //将取出来的数据整合为一个主从关系表

            var proOption = (from i in lst
                             group i by new { ProductOptionID = i.ProductOptionID,OptionName=i.OptionName }
                                 into g
                                 select new
                                 {
                                     g.Key,
                                     ProductOptionID = g.Key.ProductOptionID,
                                     OptionName=g.Key.OptionName
                                  }).ToList();

            List<Entity.ProductOption> NList = new List<Entity.ProductOption>();
            foreach (var ipro in proOption)
            {
                Entity.ProductOption model = new ProductOption();
                model.id = ipro.ProductOptionID;
                model.OptionName = ipro.OptionName;

                var smallproOption = (from i in lst where i.ProductOptionID == ipro.ProductOptionID select i).ToList();
                List<ProductItem> SmallItem = new List<ProductItem>();
                foreach (var sOp in smallproOption)
                {
                    ProductItem md = new ProductItem();
                    md.id = sOp.id;
                    md.OptionName = sOp.OptionName;
                    md.ItemName = sOp.ItemName;
                    md.IsGive = sOp.IsGive.ToString();
                    md.AppendMoney = sOp.AppendMoney;
                    md.CalculateMode = sOp.CalculateMode.ToString();
                    md.Remark = sOp.Remark;
                    md.ProductOptionID = sOp.ProductOptionID;
                    SmallItem.Add(md);

                }
                model.ProductItems = SmallItem;

                NList.Add(model);
            }
            return NList;
           
        }

        #endregion  自定义方法
    }
}

