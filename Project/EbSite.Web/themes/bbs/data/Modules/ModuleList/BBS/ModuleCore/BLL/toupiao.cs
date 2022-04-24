using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace EbSite.Modules.BBS.ModuleCore.BLL
{
    /// <summary>
    /// 业务逻辑类toupiao 的摘要说明。
    /// </summary>
    public class toupiao : Base.BLLBase<Entity.toupiao, long>
    {
        public static readonly toupiao Instance = new toupiao();
        private toupiao()
        {
        }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long id)
        {
            return  dalHelper.toupiao_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public long Add(Entity.toupiao model)
        {
            base.InvalidateCache();
          //  model.CompanyID = EbOA.Base.User.UserIdentity.GetCompanyID;
            return dalHelper .toupiao_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.toupiao model)
        {
            base.InvalidateCache();
            dalHelper.toupiao_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(long id)
        {
            base.InvalidateCache();

            dalHelper.toupiao_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.toupiao GetEntity(long id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.toupiao etEntity = base.GetCacheItem(rawKey) as Entity.toupiao;
            if (Equals(etEntity, null))
            {
                etEntity = dalHelper.toupiao_GetEntity(id);
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
            return dalHelper.toupiao_GetCount(strWhere);
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
            return dalHelper.toupiao_GetList(Top, strWhere, filedOrder);
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
        override public List<Entity.toupiao> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dalHelper.toupiao_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.toupiao> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.toupiao> lstData = base.GetCacheItem(rawKey) as List<Entity.toupiao>;
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
        public List<Entity.toupiao> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.toupiao> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.toupiao> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dalHelper.toupiao_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.toupiao> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.toupiao> lstData = base.GetCacheItem(rawKey) as List<Entity.toupiao>;
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
        public List<Entity.toupiao> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.toupiao> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.toupiao> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.toupiao> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.toupiao mdEt = GetEntity(ThisId);
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
                    else if (Equals(uc.ID.ToLower(), "color".ToLower()))
                    {
                        sValue = mdEt.color.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "piaoshu".ToLower()))
                    {
                        sValue = mdEt.piaoshu.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "bigId".ToLower()))
                    {
                        sValue = mdEt.bigId.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "bigtitle".ToLower()))
                    {
                        sValue = mdEt.bigtitle.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "shuoming".ToLower()))
                    {
                        sValue = mdEt.shuoming.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TpUsername".ToLower()))
                    {
                        sValue = mdEt.TpUsername.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TpRealname".ToLower()))
                    {
                        sValue = mdEt.TpRealname.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "username".ToLower()))
                    {
                        sValue = mdEt.username.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "realname".ToLower()))
                    {
                        sValue = mdEt.realname.ToString();
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
            Entity.toupiao mdEntity = GetEntityFromCtr(ph);
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
                    else if (Equals(column.ColumnName.ToLower(), "color".ToLower()))
                    {
                        mdEntity.color = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "piaoshu".ToLower()))
                    {
                        mdEntity.piaoshu = long.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "bigId".ToLower()))
                    {
                        mdEntity.bigId = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "bigtitle".ToLower()))
                    {
                        mdEntity.bigtitle = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "shuoming".ToLower()))
                    {
                        mdEntity.shuoming = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TpUsername".ToLower()))
                    {
                        mdEntity.TpUsername = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TpRealname".ToLower()))
                    {
                        mdEntity.TpRealname = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "username".ToLower()))
                    {
                        mdEntity.username = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "realname".ToLower()))
                    {
                        mdEntity.realname = column.ColumnValue;
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
        public Entity.toupiao GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.toupiao mdEt = new Entity.toupiao();
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
                else if (Equals(uc.ID.ToLower(), "color".ToLower()))
                {
                    mdEt.color = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "piaoshu".ToLower()))
                {
                    mdEt.piaoshu = long.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "bigId".ToLower()))
                {
                    mdEt.bigId = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "bigtitle".ToLower()))
                {
                    mdEt.bigtitle = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "shuoming".ToLower()))
                {
                    mdEt.shuoming = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "TpUsername".ToLower()))
                {
                    mdEt.TpUsername = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "TpRealname".ToLower()))
                {
                    mdEt.TpRealname = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "username".ToLower()))
                {
                    mdEt.username = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "realname".ToLower()))
                {
                    mdEt.realname = sValue;
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
        public List<Entity.toupiao> GetListPagesByBigId(int PageIndex, int PageSize, out int RecordCount, string uName, string bigId)
        {
            string sWhere = string.Format("username='{0}' and bigId='{1}'", uName, bigId);
            return GetListPagesCache(PageIndex, PageSize, sWhere, "", "", out RecordCount);
        }

        public List<Entity.toupiao> getArrayListBybigId(string bId)
        {
            string sWhere = string.Format("bigId='{0}'", bId);
            return GetListArray(sWhere);
        }
        public Entity.toupiao getByTpUsername(string uName, string id)
        {
            string sWhere = string.Format("CHARINDEX(',{0},',','+TpUsername+',')=0 and id='{1}'", uName, id);
            List<Entity.toupiao> tpList = GetListArray(sWhere);
            if (tpList.Count > 0)
            {
                return tpList[0];
            }
            else
            {
                return null;
            }
        }
        #endregion  自定义方法
        #region  自定义方法
       
        #endregion  自定义方法
    }
}

