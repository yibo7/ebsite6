using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
    //public class PayTypeInfo : EbSite.Base.Datastore.XMLProviderBaseInt<Entity.PayTypeInfo>
    //{
    //    public static readonly PayTypeInfo Instance = new PayTypeInfo();

    //    /// <summary>
    //    /// 重写菜单的保存路径-绝对
    //    /// </summary>
    //    public override string SavePath
    //    {
    //        get
    //        {
    //            return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/PayType/"));
    //        }

    //    }
    //    private PayTypeInfo()
    //    {
    //        if (!FObject.IsExist(SavePath, FsoMethod.Folder))
    //        {
    //            FObject.Create(SavePath, FsoMethod.Folder);

    //        }
    //    }
    //    public IEnumerable<Entity.PayTypeInfo> GetParent()
    //    {
    //        List<Entity.PayTypeInfo> lst = base.FillList();
    //       return lst.Where(d => d.ParentID == 0);
    //    }
    //    public IEnumerable<Entity.PayTypeInfo> GetSub(int parentid)
    //    {
    //        List<Entity.PayTypeInfo> lst = base.FillList();
    //        return lst.Where(d => d.ParentID == parentid);
    //    }

    //    public List<Entity.PayTypeInfo> GetSalesTeamTree(int iTop)
    //    {
    //        List<Entity.PayTypeInfo> getsites = base.FillList();
    //        List<Entity.PayTypeInfo> getTree1 = new List<Entity.PayTypeInfo>();
    //        foreach (Entity.PayTypeInfo tree in getsites)
    //        {
    //            if (tree.ParentID == 0)
    //            {
    //                tree.Name = "╋" + tree.Name;
    //                getTree1.Add(tree);
    //                GetSubItem(tree.id, ref getTree1, "", getsites);
    //            }
    //        }
    //        return getTree1;
    //    }

    //    private void GetSubItem(int id, ref List<Entity.PayTypeInfo> NewClass, string blank, List<Entity.PayTypeInfo> OldClass)
    //    {
    //        foreach (Entity.PayTypeInfo tree in OldClass)
    //        {
    //            if (tree.ParentID == id)
    //            {
    //                string str = blank + "─";
    //                tree.Name = str + "『" + tree.Name + "』";
    //                NewClass.Add(tree);
    //                GetSubItem(tree.id, ref NewClass, str, OldClass);
    //            }
    //        }
    //    }
    //}


    public class PayTypeInfo : Base.BLL.BllBase<Entity.PayTypeInfo, int>
    {
        public static readonly PayTypeInfo Instance = new PayTypeInfo();
        private PayTypeInfo()
        {
        }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbProviderUser.GetInstance().paytypeinfo_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return DbProviderUser.GetInstance().paytypeinfo_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.PayTypeInfo model)
        {
            base.InvalidateCache();
            return DbProviderUser.GetInstance().paytypeinfo_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.PayTypeInfo model)
        {
            base.InvalidateCache();
            DbProviderUser.GetInstance().paytypeinfo_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            DbProviderUser.GetInstance().paytypeinfo_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.PayTypeInfo GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.PayTypeInfo etEntity = base.GetCacheItem<Entity.PayTypeInfo>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = DbProviderUser.GetInstance().paytypeinfo_GetEntity(id);
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
            return DbProviderUser.GetInstance().paytypeinfo_GetCount(strWhere);
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
            return DbProviderUser.GetInstance().paytypeinfo_GetList(Top, strWhere, filedOrder);
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
        override public List<Entity.PayTypeInfo> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return DbProviderUser.GetInstance().paytypeinfo_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.PayTypeInfo> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.PayTypeInfo> lstData = base.GetCacheItem<List<Entity.PayTypeInfo>>(rawKey)  ;
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
        public List<Entity.PayTypeInfo> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.PayTypeInfo> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.PayTypeInfo> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return DbProviderUser.GetInstance().paytypeinfo_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.PayTypeInfo> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.PayTypeInfo> lstData = base.GetCacheItem<List<Entity.PayTypeInfo>>(rawKey);
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
        public List<Entity.PayTypeInfo> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.PayTypeInfo> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.PayTypeInfo> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.PayTypeInfo> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.PayTypeInfo mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ParentID".ToLower()))
                    {
                        sValue = mdEt.ParentID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Name".ToLower()))
                    {
                        sValue = mdEt.Name.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Demo".ToLower()))
                    {
                        sValue = mdEt.Demo.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
                    {
                        sValue = mdEt.OrderID.ToString();
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
            Entity.PayTypeInfo mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ParentID".ToLower()))
                    {
                        mdEntity.ParentID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Name".ToLower()))
                    {
                        mdEntity.Name = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Demo".ToLower()))
                    {
                        mdEntity.Demo = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "OrderID".ToLower()))
                    {
                        mdEntity.OrderID = int.Parse(column.ColumnValue);
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
        public Entity.PayTypeInfo GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.PayTypeInfo mdEt = new Entity.PayTypeInfo();
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
                else if (Equals(uc.ID.ToLower(), "ParentID".ToLower()))
                {
                    mdEt.ParentID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Name".ToLower()))
                {
                    mdEt.Name = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Demo".ToLower()))
                {
                    mdEt.Demo = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
                {
                    mdEt.OrderID = int.Parse(sValue);
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法
         public IEnumerable<Entity.PayTypeInfo> GetParent()
        {
            List<Entity.PayTypeInfo> lst = GetListArray("");
            return lst.Where(d => d.ParentID == 0);
        }
         public IEnumerable<Entity.PayTypeInfo> GetSub(int parentid)
         {
             List<Entity.PayTypeInfo> lst = GetListArray("");
             return lst.Where(d => d.ParentID == parentid);
         }

         public List<Entity.PayTypeInfo> GetSalesTeamTree(int iTop)
         {
             List<Entity.PayTypeInfo> getsites = GetListArray("");
             List<Entity.PayTypeInfo> getTree1 = new List<Entity.PayTypeInfo>();
             foreach (Entity.PayTypeInfo tree in getsites)
             {
                 if (tree.ParentID == 0)
                 {
                     tree.Name = "╋" + tree.Name;
                     getTree1.Add(tree);
                     GetSubItem(tree.id, ref getTree1, "", getsites);
                 }
             }
             return getTree1;
         }

         private void GetSubItem(int id, ref List<Entity.PayTypeInfo> NewClass, string blank, List<Entity.PayTypeInfo> OldClass)
         {
             foreach (Entity.PayTypeInfo tree in OldClass)
             {
                 if (tree.ParentID == id)
                 {
                     string str = blank + "─";
                     tree.Name = str + "『" + tree.Name + "』";
                     NewClass.Add(tree);
                     GetSubItem(tree.id, ref NewClass, str, OldClass);
                 }
             }
         }
        #endregion  自定义方法
    }
}
