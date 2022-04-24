using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
    //public class Shippers : EbSite.Base.Datastore.XMLProviderBaseInt<Entity.Shippers>
    //{
    //    public static readonly Shippers Instance = new Shippers();
    //    /// <summary>
    //    /// 重写菜单的保存路径-绝对
    //    /// </summary>
    //    public override string SavePath
    //    {
    //        get
    //        {
    //            return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/Shippers/"));
    //        }
    //    }

    //    private Shippers()
    //    {

    //        if (!FObject.IsExist(SavePath, FsoMethod.Folder))
    //        {
    //            FObject.Create(SavePath, FsoMethod.Folder);
    //        }
    //    }
    //}


    public class Shippers : Base.BLL.BllBase<Entity.Shippers, int>
    {
        public static readonly Shippers Instance = new Shippers();
        private Shippers()
        {
        }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbProviderUser.GetInstance().shippers_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return DbProviderUser.GetInstance().shippers_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.Shippers model)
        {
            base.InvalidateCache();
            return DbProviderUser.GetInstance().shippers_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.Shippers model)
        {
            base.InvalidateCache();
            DbProviderUser.GetInstance().shippers_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            DbProviderUser.GetInstance().shippers_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.Shippers GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.Shippers etEntity = base.GetCacheItem<Entity.Shippers>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = DbProviderUser.GetInstance().shippers_GetEntity(id);
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
            return DbProviderUser.GetInstance().shippers_GetCount(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCountCache(string strWhere)
        {
            string rawKey = string.Concat("GetCount-", strWhere);
            string sCount = base.GetCacheItem<string>(rawKey) ;
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
            return DbProviderUser.GetInstance().shippers_GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetList-", strWhere, Top, filedOrder);
            DataSet lstData = base.GetCacheItem<DataSet>(rawKey)  ;
            if (Equals(lstData, null))
            {
                lstData = GetList(Top, strWhere, filedOrder);
                if (!Equals(lstData, null))
                    base.AddCacheItem(rawKey, lstData);
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.Shippers> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return DbProviderUser.GetInstance().shippers_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Shippers> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.Shippers> lstData = base.GetCacheItem<List<Entity.Shippers>>(rawKey);
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
        public List<Entity.Shippers> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Shippers> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.Shippers> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return DbProviderUser.GetInstance().shippers_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Shippers> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.Shippers> lstData = base.GetCacheItem<List<Entity.Shippers>>(rawKey)  ;
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
                string sCount = base.GetCacheItem<string>(rawKeyCount) ;
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
        public List<Entity.Shippers> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Shippers> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Shippers> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.Shippers> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.Shippers mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "IsDefault".ToLower()))
                    {
                        sValue = mdEt.IsDefault.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ShipperTag".ToLower()))
                    {
                        sValue = mdEt.ShipperTag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ShipperName".ToLower()))
                    {
                        sValue = mdEt.ShipperName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "RegionId".ToLower()))
                    {
                        sValue = mdEt.RegionId.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Address".ToLower()))
                    {
                        sValue = mdEt.Address.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CellPhone".ToLower()))
                    {
                        sValue = mdEt.CellPhone.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TelPhone".ToLower()))
                    {
                        sValue = mdEt.TelPhone.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Zipcode".ToLower()))
                    {
                        sValue = mdEt.Zipcode.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Remark".ToLower()))
                    {
                        sValue = mdEt.Remark.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ShopName".ToLower()))
                    {
                        sValue = mdEt.ShopName.ToString();
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
            Entity.Shippers mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "IsDefault".ToLower()))
                    {
                        mdEntity.IsDefault = bool.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ShipperTag".ToLower()))
                    {
                        mdEntity.ShipperTag = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ShipperName".ToLower()))
                    {
                        mdEntity.ShipperName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "RegionId".ToLower()))
                    {
                        mdEntity.RegionId = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Address".ToLower()))
                    {
                        mdEntity.Address = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CellPhone".ToLower()))
                    {
                        mdEntity.CellPhone = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TelPhone".ToLower()))
                    {
                        mdEntity.TelPhone = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Zipcode".ToLower()))
                    {
                        mdEntity.Zipcode = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Remark".ToLower()))
                    {
                        mdEntity.Remark = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ShopName".ToLower()))
                    {
                        mdEntity.ShopName = column.ColumnValue;
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
        public Entity.Shippers GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.Shippers mdEt = new Entity.Shippers();
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
                else if (Equals(uc.ID.ToLower(), "IsDefault".ToLower()))
                {
                    mdEt.IsDefault = bool.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ShipperTag".ToLower()))
                {
                    mdEt.ShipperTag = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ShipperName".ToLower()))
                {
                    mdEt.ShipperName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "RegionId".ToLower()))
                {
                    mdEt.RegionId = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Address".ToLower()))
                {
                    mdEt.Address = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "CellPhone".ToLower()))
                {
                    mdEt.CellPhone = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "TelPhone".ToLower()))
                {
                    mdEt.TelPhone = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Zipcode".ToLower()))
                {
                    mdEt.Zipcode = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Remark".ToLower()))
                {
                    mdEt.Remark = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ShopName".ToLower()))
                {
                    mdEt.ShopName = sValue;
                }
                
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法

        #endregion  自定义方法
    }

}
