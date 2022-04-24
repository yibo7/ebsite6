using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Wenda.ModuleCore.BLL
{
    /// <summary>
    /// 业务逻辑类UserHelp 的摘要说明。
    /// </summary>
    public class UserHelp : Base.BLLBase<Entity.UserHelp, int>
    {
        public static readonly UserHelp Instance = new UserHelp();
        private UserHelp()
        {
        }

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dalHelper.UserHelp_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dalHelper.UserHelp_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.UserHelp model)
        {
            base.InvalidateCache();
            return dalHelper.UserHelp_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.UserHelp model)
        {
            base.InvalidateCache();
            dalHelper.UserHelp_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            dalHelper.UserHelp_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.UserHelp GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.UserHelp etEntity = base.GetCacheItem<Entity.UserHelp>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = dalHelper.UserHelp_GetEntity(id);
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
            return dalHelper.UserHelp_GetCount(strWhere);
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
            return dalHelper.UserHelp_GetList(Top, strWhere, filedOrder);
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
        override public List<Entity.UserHelp> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dalHelper.UserHelp_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.UserHelp> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder, EbSite.Base.Host.Instance.CurrentSite.id);
            List<Entity.UserHelp> lstData = base.GetCacheItem<List<Entity.UserHelp>>(rawKey);
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
        public List<Entity.UserHelp> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.UserHelp> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.UserHelp> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dalHelper.UserHelp_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.UserHelp> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.UserHelp> lstData = base.GetCacheItem<List<Entity.UserHelp>>(rawKey);
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
        public List<Entity.UserHelp> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.UserHelp> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.UserHelp> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.UserHelp> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.UserHelp mdEt = GetEntity(ThisId);
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
                    else if (Equals(uc.ID.ToLower(), "QCount".ToLower()))
                    {
                        sValue = mdEt.QCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ACount".ToLower()))
                    {
                        sValue = mdEt.ACount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "AdoptionCount".ToLower()))
                    {
                        sValue = mdEt.AdoptionCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "LikeAskClass".ToLower()))
                    {
                        sValue = mdEt.LikeAskClass.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TotalScore".ToLower()))
                    {
                        sValue = mdEt.TotalScore.ToString();
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
            Entity.UserHelp mdEntity = GetEntityFromCtr(ph);
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
                    else if (Equals(column.ColumnName.ToLower(), "QCount".ToLower()))
                    {
                        mdEntity.QCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ACount".ToLower()))
                    {
                        mdEntity.ACount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "AdoptionCount".ToLower()))
                    {
                        mdEntity.AdoptionCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "LikeAskClass".ToLower()))
                    {
                        mdEntity.LikeAskClass = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TotalScore".ToLower()))
                    {
                        mdEntity.TotalScore = long.Parse(column.ColumnValue);
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
        public Entity.UserHelp GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.UserHelp mdEt = new Entity.UserHelp();
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
                else if (Equals(uc.ID.ToLower(), "QCount".ToLower()))
                {
                    mdEt.QCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ACount".ToLower()))
                {
                    mdEt.ACount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "AdoptionCount".ToLower()))
                {
                    mdEt.AdoptionCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "LikeAskClass".ToLower()))
                {
                    mdEt.LikeAskClass = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "TotalScore".ToLower()))
                {
                    mdEt.TotalScore = long.Parse(sValue);
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法
        public Entity.UserHelp GetEntityByUserID(int UserID)
        {
            return dalHelper.UserHelp_GetEntityByUserID(UserID);
        }
        /// <summary>
        /// 共回答问题的总条数
        /// </summary>
        /// <returns></returns>
        public int SumAskNum()
        {
            return dalHelper.SumAskNum();
        }
        /// <summary>
        /// 获取随机数据
        /// </summary>
        /// <param name="top">前几条数据</param>
        /// <returns></returns>
        public DataSet GetRandomContent(int top)
        {
            return dalHelper.GetRandomContent(top);
        }

        public DataSet GetRandomContentIDS(string ids)
        {
            return dalHelper.GetRandomContentIDS(ids);
        }

        public DataSet GetRandomContentIDS(int top,string ids)
        {
            return dalHelper.GetRandomContentIDS(top,ids);
        }
        /// <summary>
        /// 给首页 最新问答提供数据源 每天更新5000条
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public DataSet GetNewsContent5000(int top)
        {
            return dalHelper.GetNewsContent5000(top);
        }


        public DataSet GetNewsPageContent(int PageIndex, int PageSize)
        {
            return dalHelper.GetNewsPageContent(PageIndex, PageSize);
        }
        #endregion  自定义方法
    }
}

