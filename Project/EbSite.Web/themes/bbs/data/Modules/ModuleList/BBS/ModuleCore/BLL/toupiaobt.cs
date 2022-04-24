using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace EbSite.Modules.BBS.ModuleCore.BLL
{
    /// <summary>
    /// 业务逻辑类toupiaobt 的摘要说明。
    /// </summary>
    public class toupiaobt : Base.BLLBase<Entity.toupiaobt, long>
    {
        public static readonly toupiaobt Instance = new toupiaobt();
        private toupiaobt()
        {
        }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long id)
        {
            return dalHelper.toupiaobt_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public long Add(Entity.toupiaobt model)
        {
            base.InvalidateCache();
           // model.CompanyID = EbOA.Base.User.UserIdentity.GetCompanyID;
            return dalHelper.toupiaobt_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.toupiaobt model)
        {
            base.InvalidateCache();
            dalHelper.toupiaobt_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(long id)
        {
            base.InvalidateCache();

            dalHelper.toupiaobt_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.toupiaobt GetEntity(long id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.toupiaobt etEntity = base.GetCacheItem(rawKey) as Entity.toupiaobt;
            if (Equals(etEntity, null))
            {
                etEntity = dalHelper.toupiaobt_GetEntity(id);
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
            return dalHelper.toupiaobt_GetCount(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCountCache(string strWhere)
        {
            string rawKey = string.Concat("GetCount-", strWhere);
            string sCount = base.GetCacheItem(rawKey) as string;
            if (string.IsNullOrEmpty(sCount))
            {
                sCount = GetCountCache(strWhere).ToString();
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
            return dalHelper.toupiaobt_GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetList-", strWhere, Top, filedOrder);
            DataSet lstData = base.GetCacheItem(rawKey) as DataSet;
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
        override public List<Entity.toupiaobt> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dalHelper.toupiaobt_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.toupiaobt> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.toupiaobt> lstData = base.GetCacheItem(rawKey) as List<Entity.toupiaobt>;
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
        public List<Entity.toupiaobt> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.toupiaobt> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.toupiaobt> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dalHelper.toupiaobt_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.toupiaobt> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.toupiaobt> lstData = base.GetCacheItem(rawKey) as List<Entity.toupiaobt>;
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
                string sCount = base.GetCacheItem(rawKeyCount) as string;
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
        public List<Entity.toupiaobt> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.toupiaobt> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.toupiaobt> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.toupiaobt> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                long ThisId = long.Parse(id);
                Entity.toupiaobt mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "title".ToLower()))
                    {
                        sValue = mdEt.title.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "xuanze".ToLower()))
                    {
                        sValue = mdEt.xuanze.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "username".ToLower()))
                    {
                        sValue = mdEt.username.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "realname".ToLower()))
                    {
                        sValue = mdEt.realname.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Gkusername".ToLower()))
                    {
                        sValue = mdEt.Gkusername.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Gkrealname".ToLower()))
                    {
                        sValue = mdEt.Gkrealname.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "type".ToLower()))
                    {
                        sValue = mdEt.type.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ifopen".ToLower()))
                    {
                        sValue = mdEt.ifopen.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CompanyID".ToLower()))
                    {
                        sValue = mdEt.CompanyID.ToString();
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
            Entity.toupiaobt mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = long.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "title".ToLower()))
                    {
                        mdEntity.title = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "xuanze".ToLower()))
                    {
                        mdEntity.xuanze = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "username".ToLower()))
                    {
                        mdEntity.username = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "realname".ToLower()))
                    {
                        mdEntity.realname = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Gkusername".ToLower()))
                    {
                        mdEntity.Gkusername = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Gkrealname".ToLower()))
                    {
                        mdEntity.Gkrealname = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "type".ToLower()))
                    {
                        mdEntity.type = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ifopen".ToLower()))
                    {
                        mdEntity.ifopen = column.ColumnValue;
                    }

                    else if (Equals(column.ColumnName.ToLower(), "CompanyID".ToLower()))
                    {
                        mdEntity.CompanyID = int.Parse(column.ColumnValue);
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
        public Entity.toupiaobt GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.toupiaobt mdEt = new Entity.toupiaobt();
            string sKeyID;
            if (GetIDFromCtr(ph, out sKeyID))
            {
                mdEt = GetEntity(long.Parse(sKeyID));
            }

            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = GetValueFromControl(uc);
                if (Equals(uc.ID.ToLower(), "id".ToLower()))
                {
                    mdEt.id = long.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "title".ToLower()))
                {
                    mdEt.title = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "xuanze".ToLower()))
                {
                    mdEt.xuanze = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "username".ToLower()))
                {
                    mdEt.username = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "realname".ToLower()))
                {
                    mdEt.realname = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Gkusername".ToLower()))
                {
                    mdEt.Gkusername = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Gkrealname".ToLower()))
                {
                    mdEt.Gkrealname = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "type".ToLower()))
                {
                    mdEt.type = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ifopen".ToLower()))
                {
                    mdEt.ifopen = sValue;
                }



                else if (Equals(uc.ID.ToLower(), "CompanyID".ToLower()))
                {
                    mdEt.CompanyID = int.Parse(sValue);
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法
        public List<Entity.toupiaobt> GetNewVote(int Top, string UserName)
        {
            string sWhere = string.Format("ifopen='公开' and  CHARINDEX(',{0},',','+Gkusername+',')   >   0 ", UserName);

            return GetListArray(Top, sWhere, "id desc");
        }

        public List<Entity.toupiaobt> GetListPagesByGkuName(int PageIndex, int PageSize, out int RecordCount, string UserName)
        {
            string sWhere = string.Format("ifopen='公开' and  CHARINDEX(',{0},',','+Gkusername+',')   >   0 ", UserName);
            return GetListPagesCache(PageIndex, PageSize, sWhere, "", "", out RecordCount);

        }
        public List<Entity.toupiaobt> GetListPagesByUname(int PageIndex, int PageSize, out int RecordCount, string uName)
        {
            string sWhere = string.Format("username='{0}'", uName);
            return GetListPagesCache(PageIndex, PageSize, sWhere, "", "", out RecordCount);
        }

        public List<Entity.toupiaobt> GetListArrayByUname(string uName)
        {
            string sWhere = string.Format("username='{0}'", uName);
            return GetListArray(sWhere);
        }
        #endregion  自定义方法

        #region  自定义方法
      
        #endregion  自定义方法
    }
}

