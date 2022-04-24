using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EbSite.Base.Static;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
    //public class UserLevel : EbSite.Base.Datastore.XMLProviderBaseInt<Entity.UserLevel>
    //{
    //    public static readonly UserLevel Instance = new UserLevel();
    //    /// <summary>
    //    /// 重写菜单的保存路径-绝对
    //    /// </summary>
    //    public override string SavePath
    //    {
    //        get
    //        {
    //            return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/UserLevel/"));
    //        }
    //    }
    //    private UserLevel()
    //    {
    //        if (!FObject.IsExist(SavePath, FsoMethod.Folder))
    //        {
    //            FObject.Create(SavePath, FsoMethod.Folder);
    //        }
    //    }
    //    public string GetUserLevelName(int lvid)
    //    {
    //        List<Entity.UserLevel> lst = base.FillList();
    //        Entity.UserLevel rz = lst.SingleOrDefault(p => p.id == lvid);
    //        if(!Equals(rz,null))
    //        {
    //            return rz.LevelName;
    //        }
    //        else
    //        {
    //            return string.Empty;
    //        }

    //    }

    //    public Entity.UserLevel GetUserLevelForScore(int iScore)
    //    {

    //        List<Entity.UserLevel> lst = base.FillList();
    //        List<Entity.UserLevel> nls = (from li in lst
    //                                      orderby li.id //descending
    //                                      select li).ToList();
    //        Entity.UserLevel RZ;
    //        if(iScore>0)
    //        {

    //            RZ = nls.SingleOrDefault(p => p.MaxCredit >= iScore && p.MinCredit <= iScore);
    //            if (Equals(RZ, null))
    //            {
    //                RZ = nls[nls.Count - 1];
    //            }
    //        }
    //        else
    //        {
    //            RZ = nls[0];
    //        }

    //        return RZ;
    //    }
    //}


    public class UserLevel : Base.BLL.BllBase<Entity.UserLevel, int>
    {
        public static readonly UserLevel Instance = new UserLevel();
        private const string CacheUserLevel = "userlevel";
        const double CacheDuration = 60.0;
        private UserLevel()
        {
        }

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbProviderUser.GetInstance().userlevel_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return DbProviderUser.GetInstance().userlevel_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public override int Add(Entity.UserLevel model)
        {
            base.InvalidateCache();
            return DbProviderUser.GetInstance().userlevel_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public override void Update(Entity.UserLevel model)
        {
            base.InvalidateCache();
            DbProviderUser.GetInstance().userlevel_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public override void Delete(int id)
        {
            base.InvalidateCache();

            DbProviderUser.GetInstance().userlevel_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public override Entity.UserLevel GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.UserLevel etEntity = base.GetCacheItem<Entity.UserLevel>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = DbProviderUser.GetInstance().userlevel_GetEntity(id);
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
            return DbProviderUser.GetInstance().userlevel_GetCount(strWhere);
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
            return DbProviderUser.GetInstance().userlevel_GetList(Top, strWhere, filedOrder);
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
        public override List<Entity.UserLevel> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return DbProviderUser.GetInstance().userlevel_GetListArray(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.UserLevel> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.UserLevel> lstData = EbSite.Base.Host.CacheRawApp.GetCacheItem<List<Entity.UserLevel>>(rawKey, CacheUserLevel);//base.GetCacheItem<List<Entity.UserLevel>>(rawKey)  ;
            if (Equals(lstData, null))
            {
                //从基类调用，激活事件
                lstData = base.GetListArrayEv(Top, strWhere, filedOrder);
                if (!Equals(lstData, null))
                    EbSite.Base.Host.CacheRawApp.AddCacheItem(rawKey, lstData, 60, ETimeSpanModel.FZ, CacheUserLevel); //base.AddCacheItem(rawKey, lstData);
            }
            return lstData;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.UserLevel> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.UserLevel> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public override List<Entity.UserLevel> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,
                                                            string oderby, out int RecordCount)
        {
            return DbProviderUser.GetInstance()
                                 .userlevel_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out RecordCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.UserLevel> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,
                                                        string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.UserLevel> lstData = base.GetCacheItem<List<Entity.UserLevel>>(rawKey)  ;
            int iRecordCount = -1;
            if (Equals(lstData, null))
            {
                //从基类调用，激活事件
                lstData = base.GetListPagesEv(PageIndex, PageSize, strWhere, Fileds, oderby, out RecordCount);
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
        public List<Entity.UserLevel> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out RecordCount);
        }

        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.UserLevel> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby,
                                                   out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out RecordCount);
        }

        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.UserLevel> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }

        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.UserLevel> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount,
                                                 string sKeyWord, string ColumnName)
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(sKeyWord)) strWhere = string.Format("{0} like '%{1}%'", ColumnName, sKeyWord);
            if (string.IsNullOrEmpty(strWhere))
            {
                RecordCount = 0;
                return null;
            }
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out RecordCount);
        }

        /// <summary>
        /// 修改时获取当前实例，并载入控件到PlaceHolder
        /// </summary>
        public void InitModifyCtr(string id, PlaceHolder ph)
        {
            if (!string.IsNullOrEmpty(id))
            {
                int ThisId = int.Parse(id);
                Entity.UserLevel mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "LevelName".ToLower()))
                    {
                        sValue = mdEt.LevelName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "LevelId".ToLower()))
                    {
                        sValue = mdEt.LevelId.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ImgPath".ToLower()))
                    {
                        sValue = mdEt.ImgPath.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "MinCredit".ToLower()))
                    {
                        sValue = mdEt.MinCredit.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "MaxCredit".ToLower()))
                    {
                        sValue = mdEt.MaxCredit.ToString();
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
            Entity.UserLevel mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "LevelName".ToLower()))
                    {
                        mdEntity.LevelName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "LevelId".ToLower()))
                    {
                        mdEntity.LevelId = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ImgPath".ToLower()))
                    {
                        mdEntity.ImgPath = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "MinCredit".ToLower()))
                    {
                        mdEntity.MinCredit = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "MaxCredit".ToLower()))
                    {
                        mdEntity.MaxCredit = int.Parse(column.ColumnValue);
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
        public Entity.UserLevel GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.UserLevel mdEt = new Entity.UserLevel();
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
                else if (Equals(uc.ID.ToLower(), "LevelName".ToLower()))
                {
                    mdEt.LevelName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "LevelId".ToLower()))
                {
                    mdEt.LevelId = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ImgPath".ToLower()))
                {
                    mdEt.ImgPath = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "MinCredit".ToLower()))
                {
                    mdEt.MinCredit = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "MaxCredit".ToLower()))
                {
                    mdEt.MaxCredit = int.Parse(sValue);
                }
            }
            return mdEt;
        }

        #endregion


        public string GetUserLevelName(int lvid)
        {
            List<Entity.UserLevel> lst = GetListArray("");
            Entity.UserLevel rz = lst.SingleOrDefault(p => p.id == lvid);
            if (!Equals(rz, null))
            {
                return rz.LevelName;
            }
            else
            {
                return string.Empty;
            }

        }

        public Entity.UserLevel GetUserLevelForScore(int iScore)
        {

            List<Entity.UserLevel> lst = GetListArray("");
            List<Entity.UserLevel> nls = (from li in lst
                                          orderby li.id //descending
                                          select li).ToList();
            Entity.UserLevel RZ;
            if (iScore > 0)
            {

                RZ = nls.SingleOrDefault(p => p.MaxCredit >= iScore && p.MinCredit <= iScore);
                if (Equals(RZ, null))
                {
                    RZ = nls[nls.Count - 1];
                }
            }
            else
            {
                RZ = nls[0];
            }

            return RZ;
        }
    }

}
