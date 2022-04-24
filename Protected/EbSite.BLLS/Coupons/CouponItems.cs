using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Web.UI.WebControls;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类CouponItems 的摘要说明。
    /// </summary>
    public class CouponItems : Base.BLL.BllBase<Entity.CouponItems, int>
    {
        public static readonly CouponItems Instance = new CouponItems();
        private CouponItems()
        {
        }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbProviderUser.GetInstance().CouponItems_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return DbProviderUser.GetInstance().CouponItems_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.CouponItems model)
        {
            base.InvalidateCache();
            return DbProviderUser.GetInstance().CouponItems_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.CouponItems model)
        {
            base.InvalidateCache();
            DbProviderUser.GetInstance().CouponItems_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            DbProviderUser.GetInstance().CouponItems_Delete(id);
        }

        public void Delete(int id, DbTransaction Trans)
        {
            DbProviderUser.GetInstance().CouponItems_Delete(id,Trans);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.CouponItems GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.CouponItems etEntity = base.GetCacheItem<Entity.CouponItems>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = DbProviderUser.GetInstance().CouponItems_GetEntity(id);
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
            return DbProviderUser.GetInstance().CouponItems_GetCount(strWhere);
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
            return DbProviderUser.GetInstance().CouponItems_GetList(Top, strWhere, filedOrder);
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
                lstData = Core.DataSetHelper.RetrieveDataSet(ibyte);
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.CouponItems> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return DbProviderUser.GetInstance().CouponItems_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.CouponItems> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.CouponItems> lstData = base.GetCacheItem<List<Entity.CouponItems>>(rawKey);
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
        public List<Entity.CouponItems> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.CouponItems> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.CouponItems> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return DbProviderUser.GetInstance().CouponItems_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.CouponItems> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.CouponItems> lstData = base.GetCacheItem<List<Entity.CouponItems>>(rawKey);
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
        public List<Entity.CouponItems> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.CouponItems> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.CouponItems> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.CouponItems> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.CouponItems mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CouponId".ToLower()))
                    {
                        sValue = mdEt.CouponId.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "LotNumber".ToLower()))
                    {
                        sValue = mdEt.LotNumber.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ClaimCode".ToLower()))
                    {
                        sValue = mdEt.ClaimCode.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "UserId".ToLower()))
                    {
                        sValue = mdEt.UserId.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "EmailAddress".ToLower()))
                    {
                        sValue = mdEt.EmailAddress.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "AddDateTime".ToLower()))
                    {
                        sValue = mdEt.AddDateTime.ToString();
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
            Entity.CouponItems mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CouponId".ToLower()))
                    {
                        mdEntity.CouponId = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "LotNumber".ToLower()))
                    {
                        mdEntity.LotNumber = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ClaimCode".ToLower()))
                    {
                        mdEntity.ClaimCode = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UserId".ToLower()))
                    {
                        mdEntity.UserId = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "EmailAddress".ToLower()))
                    {
                        mdEntity.EmailAddress = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "AddDateTime".ToLower()))
                    {
                        mdEntity.AddDateTime = DateTime.Parse(column.ColumnValue);
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
        public Entity.CouponItems GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.CouponItems mdEt = new Entity.CouponItems();
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
                else if (Equals(uc.ID.ToLower(), "CouponId".ToLower()))
                {
                    mdEt.CouponId = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "LotNumber".ToLower()))
                {
                    mdEt.LotNumber = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ClaimCode".ToLower()))
                {
                    mdEt.ClaimCode = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "UserId".ToLower()))
                {
                    mdEt.UserId = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "EmailAddress".ToLower()))
                {
                    mdEt.EmailAddress = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "AddDateTime".ToLower()))
                {
                    mdEt.AddDateTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Status".ToLower()))
                {
                    mdEt.Status = bool.Parse(sValue);
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法
        public Entity.CouponItems GetEntity(string CouponCode, out string CouponName, out decimal Amount,
                                                 out decimal CouponValue)
        {
            return DbProviderUser.GetInstance().CouponItems_GetEntity(CouponCode, out  CouponName, out  Amount,
                                                 out  CouponValue);
        }

        public List<Entity.CouponItems> Union_GetListArray(int Top, string strWhere, string filedOrder)
        {
            return DbProviderUser.GetInstance().CouponItemsUnion_GetListArray(Top, strWhere, filedOrder);
        }
        public Entity.CouponItems GetEntity(string ClaimCode)
        {
            return DbProviderUser.GetInstance().CouponItems_GetEntity(ClaimCode);
        }
        #endregion  自定义方法
    }
}

