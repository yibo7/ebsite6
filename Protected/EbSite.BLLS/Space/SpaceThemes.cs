using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类SpaceThemes 的摘要说明。
    /// </summary>
    public class SpaceThemes : Base.BLL.BllBase<Entity.SpaceThemes, int>
    {
        public static readonly SpaceThemes Instance = new SpaceThemes();
        private SpaceThemes()
        {
        }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.SpaceThemes_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.SpaceThemes_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.SpaceThemes model)
        {
            base.InvalidateCache();
            return dal.SpaceThemes_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.SpaceThemes model)
        {
            base.InvalidateCache();
            dal.SpaceThemes_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            dal.SpaceThemes_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.SpaceThemes GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.SpaceThemes etEntity = base.GetCacheItem<Entity.SpaceThemes>(rawKey)  ;
            if (Equals(etEntity, null))
            {
                etEntity = dal.SpaceThemes_GetEntity(id);
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
            return dal.SpaceThemes_GetCount(strWhere);
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
            return dal.SpaceThemes_GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetList-", strWhere, Top, filedOrder);
            DataSet lstData = base.GetCacheItem<DataSet>(rawKey) ;
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
        override public List<Entity.SpaceThemes> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dal.SpaceThemes_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.SpaceThemes> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.SpaceThemes> lstData = base.GetCacheItem<List<Entity.SpaceThemes>>(rawKey);
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
        public List<Entity.SpaceThemes> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.SpaceThemes> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.SpaceThemes> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dal.SpaceThemes_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.SpaceThemes> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.SpaceThemes> lstData = base.GetCacheItem<List<Entity.SpaceThemes>>(rawKey);
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
        public List<Entity.SpaceThemes> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.SpaceThemes> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.SpaceThemes> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.SpaceThemes> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.SpaceThemes mdEt = GetEntity(ThisId);
                bool IsTableFiled = false;
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    IsTableFiled = false;
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                        IsTableFiled = true;
                    }
                    else if (Equals(uc.ID.ToLower(), "ThemeName".ToLower()))
                    {
                        sValue = mdEt.ThemeName.ToString();
                        IsTableFiled = true;
                    }
                    else if (Equals(uc.ID.ToLower(), "ThemePath".ToLower()))
                    {
                        sValue = mdEt.ThemePath.ToString();
                        IsTableFiled = true;
                    }
                    else if (Equals(uc.ID.ToLower(), "Author".ToLower()))
                    {
                        sValue = mdEt.Author.ToString();
                        IsTableFiled = true;
                    }
                    else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
                    {
                        sValue = mdEt.UserID.ToString();
                        IsTableFiled = true;
                    }
                    else if (Equals(uc.ID.ToLower(), "AddTime".ToLower()))
                    {
                        sValue = mdEt.AddTime.ToString();
                        IsTableFiled = true;
                    }
                    else if (Equals(uc.ID.ToLower(), "ThemeClassID".ToLower()))
                    {
                        sValue = mdEt.ThemeClassID.ToString();
                        IsTableFiled = true;
                    }
                    else if (Equals(uc.ID.ToLower(), "UserGroupID".ToLower()))
                    {
                        sValue = mdEt.UserGroupID.ToString();
                        IsTableFiled = true;
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
            Entity.SpaceThemes mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ThemeName".ToLower()))
                    {
                        mdEntity.ThemeName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ThemePath".ToLower()))
                    {
                        mdEntity.ThemePath = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Author".ToLower()))
                    {
                        mdEntity.Author = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UserID".ToLower()))
                    {
                        mdEntity.UserID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "AddTime".ToLower()))
                    {
                        mdEntity.AddTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ThemeClassID".ToLower()))
                    {
                        mdEntity.ThemeClassID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UserGroupID".ToLower()))
                    {
                        mdEntity.UserGroupID = int.Parse(column.ColumnValue);
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
        public Entity.SpaceThemes GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.SpaceThemes mdEt = new Entity.SpaceThemes();
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
                else if (Equals(uc.ID.ToLower(), "ThemeName".ToLower()))
                {
                    mdEt.ThemeName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ThemePath".ToLower()))
                {
                    mdEt.ThemePath = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Author".ToLower()))
                {
                    mdEt.Author = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
                {
                    mdEt.UserID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "AddTime".ToLower()))
                {
                    mdEt.AddTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ThemeClassID".ToLower()))
                {
                    mdEt.ThemeClassID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "UserGroupID".ToLower()))
                {
                    mdEt.UserGroupID = int.Parse(sValue);
                }

            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法
        public string GetPathByID(int themeid)
        {
            return dal.SpaceThemes_GetPathByID(themeid);
        }
        public List<Entity.SpaceThemes> GetListArrayByClassID(int ClassID)
        {
            return GetListArrayByClassID(ClassID, "","");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClassID"></param>
        /// <param name="ThemeName"></param>
        /// <param name="ThemeClassIDs">yhl 2012-01-05 用户皮肤分类集合</param>
        /// <returns></returns>
        public List<Entity.SpaceThemes> GetListArrayByClassID(int ClassID, string ThemeName,string ThemeClassIDs)
        {
            string sWhere = "";
            if (ClassID > 0)
            {
                sWhere = string.Format("ThemeClassID={0}", ClassID);
            }
            else
            {
                sWhere = string.Format("ThemeClassID in ({0})", ThemeClassIDs);
            }
            if (!string.IsNullOrEmpty(ThemeName))
                sWhere = string.Format(" {2} {1} ThemeName='%{0}%'", ThemeName, (ClassID > 0) ? " and " : "", sWhere);

            return GetListArray(0, sWhere, "");
        }
        /// <summary>
        /// 2012-01-04 杨欢乐 查询条件
        /// </summary>
        /// <param name="keyword">名称</param>
        /// <param name="typeid">类别</param>
        /// <returns></returns>
        public string StrWhere(string keyword,string typeid)
        {
            string strsql = "";
            if(!string.IsNullOrEmpty(keyword))
            {
                strsql += " ThemeName like '%"+keyword+"%' and";
            }
            if(!string.IsNullOrEmpty(typeid))
            {
                strsql += " ThemeClassID ="+typeid+" and";
            }
            if (!string.IsNullOrEmpty(strsql))
                strsql = strsql.Remove(strsql.Length - 3, 3);

            return strsql;
        }
        #endregion  自定义方法
    }
}

