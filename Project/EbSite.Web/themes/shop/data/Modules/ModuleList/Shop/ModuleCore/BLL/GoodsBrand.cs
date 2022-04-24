using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Core.FSO;

namespace EbSite.Modules.Shop.ModuleCore.BLL
{
//    /// <summary>
//    /// 业务逻辑类Supplier 的摘要说明。
//    /// </summary>
//    public class GoodsBrand : EbSite.Base.Datastore.XMLProviderBaseInt<Entity.GoodsBrand>
//    {
//        public static readonly GoodsBrand Instance = new GoodsBrand();
//        /// <summary>
//        /// 重写数据的保存路径-绝对
//        /// </summary>
//        public override string SavePath
//        {
//            get
//            {
//                string mpath = EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"));
//                //string mpath =
//                  //  EbSite.BLL.ModulesBll.Modules.Instance.GetModelPath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"));
//                if (!Equals(HttpContext.Current, null))
//                {
                    
//                    return HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Brand/");
//                }
//                return "";
//            }
//        }
//        public string GetBrandNameByID(string ID)
//        {
//            int iid = int.Parse(ID);
//            List<Entity.GoodsBrand> lst = base.FillList();
//            Entity.GoodsBrand md = lst.SingleOrDefault(d => d.id == iid);

//            if(!Equals(md,null))
//            {
//                return md.BrandName;
//            }
//            return "";
//        }
//        private GoodsBrand()
//        {
//            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
//            {
//                FObject.Create(SavePath, FsoMethod.Folder);
//            }
//        }
//    }

    /// <summary>
    /// 业务逻辑类GoodsBrand 的摘要说明。
    /// </summary>
    public class GoodsBrand : Base.BLLBase<Entity.GoodsBrand, int>
    {
        public static readonly GoodsBrand Instance = new GoodsBrand();
        private GoodsBrand()
        {
        }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dalHelper.goodsbrand_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dalHelper.goodsbrand_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.GoodsBrand model)
        {
            base.InvalidateCache();
            return dalHelper.goodsbrand_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.GoodsBrand model)
        {
            base.InvalidateCache();
            dalHelper.goodsbrand_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            dalHelper.goodsbrand_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.GoodsBrand GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.GoodsBrand etEntity = base.GetCacheItem<Entity.GoodsBrand>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = dalHelper.goodsbrand_GetEntity(id);
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
            return dalHelper.goodsbrand_GetCount(strWhere);
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
            return dalHelper.goodsbrand_GetList(Top, strWhere, filedOrder);
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
        override public List<Entity.GoodsBrand> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dalHelper.goodsbrand_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.GoodsBrand> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.GoodsBrand> lstData = base.GetCacheItem<List<Entity.GoodsBrand>>(rawKey);
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
        public List<Entity.GoodsBrand> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.GoodsBrand> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.GoodsBrand> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dalHelper.goodsbrand_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.GoodsBrand> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.GoodsBrand> lstData = base.GetCacheItem<List<Entity.GoodsBrand>>(rawKey) ;
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
        public List<Entity.GoodsBrand> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.GoodsBrand> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.GoodsBrand> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.GoodsBrand> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.GoodsBrand mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "BrandName".ToLower()))
                    {
                        sValue = mdEt.BrandName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Logo".ToLower()))
                    {
                        sValue = mdEt.Logo.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Description".ToLower()))
                    {
                        sValue = mdEt.Description.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
                    {
                        sValue = mdEt.OrderID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "GroupID".ToLower()))
                    {
                        sValue = mdEt.GroupID.ToString();
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
            Entity.GoodsBrand mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "BrandName".ToLower()))
                    {
                        mdEntity.BrandName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Logo".ToLower()))
                    {
                        mdEntity.Logo = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Description".ToLower()))
                    {
                        mdEntity.Description = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "OrderID".ToLower()))
                    {
                        mdEntity.OrderID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "GroupID".ToLower()))
                    {
                        mdEntity.GroupID = int.Parse(column.ColumnValue);
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
        public Entity.GoodsBrand GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.GoodsBrand mdEt = new Entity.GoodsBrand();
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
                else if (Equals(uc.ID.ToLower(), "BrandName".ToLower()))
                {
                    mdEt.BrandName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Logo".ToLower()))
                {
                    mdEt.Logo = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Description".ToLower()))
                {
                    mdEt.Description = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
                {
                    mdEt.OrderID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "GroupID".ToLower()))
                {
                    mdEt.GroupID = int.Parse(sValue);
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法
        public string GetBrandNameByID(int ID)
        {
           if (ID > 0)
           {
               Entity.GoodsBrand md = GetEntity(ID);

               if (!Equals(md, null))
               {
                   return md.BrandName;
               }
           }
            
            return "";
        }
        #endregion  自定义方法
    }
}

