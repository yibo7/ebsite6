using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Web.UI.WebControls;
using EbSite.Base.Static;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类PayPass 的摘要说明。
    /// </summary>
    public class PayPass : Base.BLL.BllBase<Entity.PayPass, int>
    {
        public static readonly PayPass Instance = new PayPass();
        private PayPass()
        {
        }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbProviderUser.GetInstance().PayPass_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return DbProviderUser.GetInstance().PayPass_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.PayPass model)
        {
            base.InvalidateCache();
            return DbProviderUser.GetInstance().PayPass_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.PayPass model)
        {
            base.InvalidateCache();
            DbProviderUser.GetInstance().PayPass_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            DbProviderUser.GetInstance().PayPass_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体 通过用户ID 查询
        /// </summary>
        override public Entity.PayPass GetEntity(int uid)
        {

            string rawKey = string.Concat("GetEntity-", uid);
            Entity.PayPass etEntity = base.GetCacheItem<Entity.PayPass>(rawKey)  ;
            if (Equals(etEntity, null))
            {
                etEntity = DbProviderUser.GetInstance().PayPass_GetEntity(uid);
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
            return DbProviderUser.GetInstance().PayPass_GetCount(strWhere);
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
            return DbProviderUser.GetInstance().PayPass_GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetList-", strWhere, Top, filedOrder);
            DataSet lstData = EbSite.Base.Host.CacheRawApp.GetCacheItem<DataSet>(rawKey, "paypass"); //base.GetCacheItem<DataSet>(rawKey);
            if (Equals(lstData, null))
            {
                lstData = GetList(Top, strWhere, filedOrder);
                if (!Equals(lstData, null))
                    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, lstData, 60, ETimeSpanModel.FZ, "paypass");//base.AddCacheItem(rawKey, lstData);
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.PayPass> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return DbProviderUser.GetInstance().PayPass_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.PayPass> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.PayPass> lstData = base.GetCacheItem<List<Entity.PayPass>>(rawKey)  ;
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
        public List<Entity.PayPass> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.PayPass> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.PayPass> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return DbProviderUser.GetInstance().PayPass_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.PayPass> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.PayPass> lstData = base.GetCacheItem<List<Entity.PayPass>>(rawKey)  ;
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
        public List<Entity.PayPass> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.PayPass> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.PayPass> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.PayPass> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.PayPass mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
                    {
                        sValue = mdEt.UserID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Pass".ToLower()))
                    {
                        sValue = mdEt.Pass.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "EndType".ToLower()))
                    {
                        sValue = mdEt.EndType.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Balance".ToLower()))
                    {
                        sValue = mdEt.Balance.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "RequestBalance".ToLower()))
                    {
                        sValue = mdEt.RequestBalance.ToString();
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
            Entity.PayPass mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UserID".ToLower()))
                    {
                        mdEntity.UserID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Pass".ToLower()))
                    {
                        mdEntity.Pass = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "EndType".ToLower()))
                    {
                        mdEntity.EndType = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Balance".ToLower()))
                    {
                        mdEntity.Balance = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "RequestBalance".ToLower()))
                    {
                        mdEntity.RequestBalance = decimal.Parse(column.ColumnValue);
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
        public Entity.PayPass GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.PayPass mdEt = new Entity.PayPass();
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
                else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
                {
                    mdEt.UserID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Pass".ToLower()))
                {
                    mdEt.Pass = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "EndType".ToLower()))
                {
                    mdEt.EndType = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Balance".ToLower()))
                {
                    mdEt.Balance = decimal.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "RequestBalance".ToLower()))
                {
                    mdEt.RequestBalance = decimal.Parse(sValue);
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByUserID(int UserId)
        {
            return DbProviderUser.GetInstance().PayPass_ExistsByUserID(UserId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.PayPass GetEntityByUserID(int UserId)
        {
            return DbProviderUser.GetInstance().PayPass_GetEntityByUserID(UserId);
        }

        public void Update(Entity.PayPass model, DbTransaction Trans)
        {
            DbProviderUser.GetInstance().PayPass_Update(model,Trans);
        }
        #endregion  自定义方法
    }
}

