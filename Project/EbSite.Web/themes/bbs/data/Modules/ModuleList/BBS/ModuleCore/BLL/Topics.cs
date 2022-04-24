using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.BBS.ModuleCore.BLL
{
    /// <summary>
    /// 业务逻辑类Topics 的摘要说明。
    /// </summary>
    public class Topics : Base.BLLBase<Entity.Topics, long>
    {
        public static readonly Topics Instance = new Topics();
        private Topics()
        {
        }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public long GetMaxId()
        {
            return dalHelper.Topics_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dalHelper.Topics_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public long Add(Entity.Topics model)
        {
            base.InvalidateCache();
            return dalHelper.Topics_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.Topics model)
        {
            base.InvalidateCache();
            dalHelper.Topics_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(long id)
        {
            base.InvalidateCache();

            dalHelper.Topics_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.Topics GetEntity(long id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.Topics etEntity = base.GetCacheItem(rawKey) as Entity.Topics;
            if (Equals(etEntity, null))
            {
                etEntity = dalHelper.Topics_GetEntity(id);
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
            return dalHelper.Topics_GetCount(strWhere);
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
            return dalHelper.Topics_GetList(Top, strWhere, filedOrder);
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
        override public List<Entity.Topics> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dalHelper.Topics_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Topics> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.Topics> lstData = base.GetCacheItem(rawKey) as List<Entity.Topics>;
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
        public List<Entity.Topics> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Topics> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.Topics> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dalHelper.Topics_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Topics> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.Topics> lstData = base.GetCacheItem(rawKey) as List<Entity.Topics>;
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
        public List<Entity.Topics> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Topics> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Topics> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.Topics> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.Topics mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ChannelID".ToLower()))
                    {
                        sValue = mdEt.ChannelID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ChannelName".ToLower()))
                    {
                        sValue = mdEt.ChannelName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TopicTitle".ToLower()))
                    {
                        sValue = mdEt.TopicTitle.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TopicContent".ToLower()))
                    {
                        sValue = mdEt.TopicContent.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TopicDescription".ToLower()))
                    {
                        sValue = mdEt.TopicDescription.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ViewCount".ToLower()))
                    {
                        sValue = mdEt.ViewCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ReplyCount".ToLower()))
                    {
                        sValue = mdEt.ReplyCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
                    {
                        sValue = mdEt.UserID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "UserName".ToLower()))
                    {
                        sValue = mdEt.UserName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "OrderTopFlag".ToLower()))
                    {
                        sValue = mdEt.OrderTopFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "OrderTopTime".ToLower()))
                    {
                        sValue = mdEt.OrderTopTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "OrderTopMasterUserID".ToLower()))
                    {
                        sValue = mdEt.OrderTopMasterUserID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "OrderTopMasterUserName".ToLower()))
                    {
                        sValue = mdEt.OrderTopMasterUserName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "RecommendFlag".ToLower()))
                    {
                        sValue = mdEt.RecommendFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "RecommendTime".ToLower()))
                    {
                        sValue = mdEt.RecommendTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "RecommendMasterUserID".ToLower()))
                    {
                        sValue = mdEt.RecommendMasterUserID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "RecommendMasterUserName".ToLower()))
                    {
                        sValue = mdEt.RecommendMasterUserName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ReplyStatusFlag".ToLower()))
                    {
                        sValue = mdEt.ReplyStatusFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ModifyStatusFlag".ToLower()))
                    {
                        sValue = mdEt.ModifyStatusFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "HasImageFlag".ToLower()))
                    {
                        sValue = mdEt.HasImageFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TopicImageUrl".ToLower()))
                    {
                        sValue = mdEt.TopicImageUrl.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "IsBadCount".ToLower()))
                    {
                        sValue = mdEt.IsBadCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "IsGoodCount".ToLower()))
                    {
                        sValue = mdEt.IsGoodCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ConclusionFlag".ToLower()))
                    {
                        sValue = mdEt.ConclusionFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "AuditFlag".ToLower()))
                    {
                        sValue = mdEt.AuditFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "LatestReplyUserID".ToLower()))
                    {
                        sValue = mdEt.LatestReplyUserID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "LatestReplyUserName".ToLower()))
                    {
                        sValue = mdEt.LatestReplyUserName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "LatestRepliedTime".ToLower()))
                    {
                        sValue = mdEt.LatestRepliedTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "GoodFlag".ToLower()))
                    {
                        sValue = mdEt.GoodFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "GoodTime".ToLower()))
                    {
                        sValue = mdEt.GoodTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "GoodDescription".ToLower()))
                    {
                        sValue = mdEt.GoodDescription.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "GoodImageUrl".ToLower()))
                    {
                        sValue = mdEt.GoodImageUrl.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "GoodMasterUserID".ToLower()))
                    {
                        sValue = mdEt.GoodMasterUserID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "GoodMasterUserName".ToLower()))
                    {
                        sValue = mdEt.GoodMasterUserName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SiteOrderTopFlag".ToLower()))
                    {
                        sValue = mdEt.SiteOrderTopFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SiteOrderTopTime".ToLower()))
                    {
                        sValue = mdEt.SiteOrderTopTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SiteOrderTopMasterUserID".ToLower()))
                    {
                        sValue = mdEt.SiteOrderTopMasterUserID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SiteOrderTopMasterUserName".ToLower()))
                    {
                        sValue = mdEt.SiteOrderTopMasterUserName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TopicFlag".ToLower()))
                    {
                        sValue = mdEt.TopicFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ReferenceID".ToLower()))
                    {
                        sValue = mdEt.ReferenceID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "DeleteFlag".ToLower()))
                    {
                        sValue = mdEt.DeleteFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CreatedTime".ToLower()))
                    {
                        sValue = mdEt.CreatedTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CreatedIP".ToLower()))
                    {
                        sValue = mdEt.CreatedIP.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "UpdatedTime".ToLower()))
                    {
                        sValue = mdEt.UpdatedTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TitleBoldFlag".ToLower()))
                    {
                        sValue = mdEt.TitleBoldFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TitleBoldTime".ToLower()))
                    {
                        sValue = mdEt.TitleBoldTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TitleColorFlag".ToLower()))
                    {
                        sValue = mdEt.TitleColorFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TitleColorCode".ToLower()))
                    {
                        sValue = mdEt.TitleColorCode.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TitleColorTime".ToLower()))
                    {
                        sValue = mdEt.TitleColorTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CompanyID".ToLower()))
                    {
                        sValue = mdEt.CompanyID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "tag".ToLower()))
                    {
                        sValue = mdEt.tag.ToString();
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
        public long SaveEntityFromCtr(PlaceHolder ph, List<EbSite.Base.BLL.OtherColumn> lstOtherColumn)
        {
            Entity.Topics mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ChannelID".ToLower()))
                    {
                        mdEntity.ChannelID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ChannelName".ToLower()))
                    {
                        mdEntity.ChannelName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TopicTitle".ToLower()))
                    {
                        mdEntity.TopicTitle = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TopicContent".ToLower()))
                    {
                        mdEntity.TopicContent = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TopicDescription".ToLower()))
                    {
                        mdEntity.TopicDescription = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ViewCount".ToLower()))
                    {
                        mdEntity.ViewCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ReplyCount".ToLower()))
                    {
                        mdEntity.ReplyCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UserID".ToLower()))
                    {
                        mdEntity.UserID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UserName".ToLower()))
                    {
                        mdEntity.UserName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "OrderTopFlag".ToLower()))
                    {
                        mdEntity.OrderTopFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "OrderTopTime".ToLower()))
                    {
                        mdEntity.OrderTopTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "OrderTopMasterUserID".ToLower()))
                    {
                        mdEntity.OrderTopMasterUserID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "OrderTopMasterUserName".ToLower()))
                    {
                        mdEntity.OrderTopMasterUserName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "RecommendFlag".ToLower()))
                    {
                        mdEntity.RecommendFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "RecommendTime".ToLower()))
                    {
                        mdEntity.RecommendTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "RecommendMasterUserID".ToLower()))
                    {
                        mdEntity.RecommendMasterUserID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "RecommendMasterUserName".ToLower()))
                    {
                        mdEntity.RecommendMasterUserName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ReplyStatusFlag".ToLower()))
                    {
                        mdEntity.ReplyStatusFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ModifyStatusFlag".ToLower()))
                    {
                        mdEntity.ModifyStatusFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "HasImageFlag".ToLower()))
                    {
                        mdEntity.HasImageFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TopicImageUrl".ToLower()))
                    {
                        mdEntity.TopicImageUrl = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "IsBadCount".ToLower()))
                    {
                        mdEntity.IsBadCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "IsGoodCount".ToLower()))
                    {
                        mdEntity.IsGoodCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ConclusionFlag".ToLower()))
                    {
                        mdEntity.ConclusionFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "AuditFlag".ToLower()))
                    {
                        mdEntity.AuditFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "LatestReplyUserID".ToLower()))
                    {
                        mdEntity.LatestReplyUserID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "LatestReplyUserName".ToLower()))
                    {
                        mdEntity.LatestReplyUserName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "LatestRepliedTime".ToLower()))
                    {
                        mdEntity.LatestRepliedTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "GoodFlag".ToLower()))
                    {
                        mdEntity.GoodFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "GoodTime".ToLower()))
                    {
                        mdEntity.GoodTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "GoodDescription".ToLower()))
                    {
                        mdEntity.GoodDescription = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "GoodImageUrl".ToLower()))
                    {
                        mdEntity.GoodImageUrl = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "GoodMasterUserID".ToLower()))
                    {
                        mdEntity.GoodMasterUserID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "GoodMasterUserName".ToLower()))
                    {
                        mdEntity.GoodMasterUserName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "SiteOrderTopFlag".ToLower()))
                    {
                        mdEntity.SiteOrderTopFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "SiteOrderTopTime".ToLower()))
                    {
                        mdEntity.SiteOrderTopTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "SiteOrderTopMasterUserID".ToLower()))
                    {
                        mdEntity.SiteOrderTopMasterUserID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "SiteOrderTopMasterUserName".ToLower()))
                    {
                        mdEntity.SiteOrderTopMasterUserName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TopicFlag".ToLower()))
                    {
                        mdEntity.TopicFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ReferenceID".ToLower()))
                    {
                        mdEntity.ReferenceID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "DeleteFlag".ToLower()))
                    {
                        mdEntity.DeleteFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CreatedTime".ToLower()))
                    {
                        mdEntity.CreatedTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CreatedIP".ToLower()))
                    {
                        mdEntity.CreatedIP = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UpdatedTime".ToLower()))
                    {
                        mdEntity.UpdatedTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TitleBoldFlag".ToLower()))
                    {
                        mdEntity.TitleBoldFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TitleBoldTime".ToLower()))
                    {
                        mdEntity.TitleBoldTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TitleColorFlag".ToLower()))
                    {
                        mdEntity.TitleColorFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TitleColorCode".ToLower()))
                    {
                        mdEntity.TitleColorCode = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TitleColorTime".ToLower()))
                    {
                        mdEntity.TitleColorTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CompanyID".ToLower()))
                    {
                        mdEntity.CompanyID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "tag".ToLower()))
                    {
                        mdEntity.tag = int.Parse(column.ColumnValue);
                    }
                }
            }
            if (mdEntity.id > 0)
            {
                Update(mdEntity);
                return 0;
            }
            else
            {
                return Add(mdEntity);
            }
        }
        /// <summary>
        /// 从PlaceHolder中获取一个实例
        /// </summary>
        public Entity.Topics GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.Topics mdEt = new Entity.Topics();
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
                else if (Equals(uc.ID.ToLower(), "ChannelID".ToLower()))
                {
                    mdEt.ChannelID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ChannelName".ToLower()))
                {
                    mdEt.ChannelName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "TopicTitle".ToLower()))
                {
                    mdEt.TopicTitle = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "TopicContent".ToLower()))
                {
                    mdEt.TopicContent = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "TopicDescription".ToLower()))
                {
                    mdEt.TopicDescription = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ViewCount".ToLower()))
                {
                    mdEt.ViewCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ReplyCount".ToLower()))
                {
                    mdEt.ReplyCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
                {
                    mdEt.UserID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "UserName".ToLower()))
                {
                    mdEt.UserName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "OrderTopFlag".ToLower()))
                {
                    mdEt.OrderTopFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "OrderTopTime".ToLower()))
                {
                    mdEt.OrderTopTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "OrderTopMasterUserID".ToLower()))
                {
                    mdEt.OrderTopMasterUserID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "OrderTopMasterUserName".ToLower()))
                {
                    mdEt.OrderTopMasterUserName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "RecommendFlag".ToLower()))
                {
                    mdEt.RecommendFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "RecommendTime".ToLower()))
                {
                    mdEt.RecommendTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "RecommendMasterUserID".ToLower()))
                {
                    mdEt.RecommendMasterUserID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "RecommendMasterUserName".ToLower()))
                {
                    mdEt.RecommendMasterUserName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ReplyStatusFlag".ToLower()))
                {
                    mdEt.ReplyStatusFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ModifyStatusFlag".ToLower()))
                {
                    mdEt.ModifyStatusFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "HasImageFlag".ToLower()))
                {
                    mdEt.HasImageFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "TopicImageUrl".ToLower()))
                {
                    mdEt.TopicImageUrl = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "IsBadCount".ToLower()))
                {
                    mdEt.IsBadCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "IsGoodCount".ToLower()))
                {
                    mdEt.IsGoodCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ConclusionFlag".ToLower()))
                {
                    mdEt.ConclusionFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "AuditFlag".ToLower()))
                {
                    mdEt.AuditFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "LatestReplyUserID".ToLower()))
                {
                    mdEt.LatestReplyUserID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "LatestReplyUserName".ToLower()))
                {
                    mdEt.LatestReplyUserName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "LatestRepliedTime".ToLower()))
                {
                    mdEt.LatestRepliedTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "GoodFlag".ToLower()))
                {
                    mdEt.GoodFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "GoodTime".ToLower()))
                {
                    mdEt.GoodTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "GoodDescription".ToLower()))
                {
                    mdEt.GoodDescription = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "GoodImageUrl".ToLower()))
                {
                    mdEt.GoodImageUrl = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "GoodMasterUserID".ToLower()))
                {
                    mdEt.GoodMasterUserID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "GoodMasterUserName".ToLower()))
                {
                    mdEt.GoodMasterUserName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "SiteOrderTopFlag".ToLower()))
                {
                    mdEt.SiteOrderTopFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "SiteOrderTopTime".ToLower()))
                {
                    mdEt.SiteOrderTopTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "SiteOrderTopMasterUserID".ToLower()))
                {
                    mdEt.SiteOrderTopMasterUserID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "SiteOrderTopMasterUserName".ToLower()))
                {
                    mdEt.SiteOrderTopMasterUserName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "TopicFlag".ToLower()))
                {
                    mdEt.TopicFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ReferenceID".ToLower()))
                {
                    mdEt.ReferenceID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "DeleteFlag".ToLower()))
                {
                    mdEt.DeleteFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "CreatedTime".ToLower()))
                {
                    mdEt.CreatedTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "CreatedIP".ToLower()))
                {
                    mdEt.CreatedIP = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "UpdatedTime".ToLower()))
                {
                    mdEt.UpdatedTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "TitleBoldFlag".ToLower()))
                {
                    mdEt.TitleBoldFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "TitleBoldTime".ToLower()))
                {
                    mdEt.TitleBoldTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "TitleColorFlag".ToLower()))
                {
                    mdEt.TitleColorFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "TitleColorCode".ToLower()))
                {
                    mdEt.TitleColorCode = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "TitleColorTime".ToLower()))
                {
                    mdEt.TitleColorTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "CompanyID".ToLower()))
                {
                    mdEt.CompanyID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "tag".ToLower()))
                {
                    mdEt.tag = int.Parse(sValue);
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法

        public List<Entity.Topics> GetListPagesCacheByCls(int PageIndex, int PageSize, out int RecordCount, string cls, string getWhere)
        {
            string sWhere = "";
            if (string.IsNullOrEmpty(cls)) //全部帖子为没有删除的
            {
                sWhere = string.Format("DeleteFlag!='{0}'", "1");
            }
            else if (string.Equals(cls, "1"))//没有审核的帖子
            {
                sWhere = string.Format("AuditFlag='{0}'", "0");
            }
            else if (string.Equals(cls, "2"))
            {
                sWhere = string.Format("RecommendFlag='{0}'", "1");
            }
            else if (string.Equals(cls, "3"))
            {
                sWhere = string.Format("OrderTopFlag='{0}'", "1");
            }
            else if (string.Equals(cls, "4"))
            {
                sWhere = string.Format("SiteOrderTopFlag='{0}'", "1");
            }
            else if (string.Equals(cls, "5"))
            {
                sWhere = string.Format("GoodFlag='{0}'", "1");
            }
            else if (string.Equals(cls, "6"))
            {
                sWhere = string.Format("DeleteFlag='{0}'", "1");
            }
            if (!string.IsNullOrEmpty(getWhere))
            {
                if (!string.IsNullOrEmpty(sWhere))
                {
                    sWhere = sWhere + " and " + getWhere;
                }
                else
                {
                    sWhere = getWhere;
                }
            }
            return GetListPagesCache(PageIndex, PageSize, sWhere.Trim(), "", "", out RecordCount);

        }

        public Entity.Topics GetEntityByChannelID(int ChannelId)
        {
            string sWhere = string.Format("ChannelID='{0}' order by CreatedTime desc", ChannelId);
            if (GetListArray(sWhere).Count > 0)
            {
                return GetListArray(sWhere)[0];
            }
            else
            {
                return null;
            }
        }
        public List<Entity.Topics> getListArrayByXT()
        {
            string sWhere = string.Format("DeleteFlag =0 order by CreatedTime desc");
            return GetListArrayCache(10, sWhere, "");
        }

        public List<Entity.Topics> getListArrayByJH()
        {
            string sWhere = string.Format("GoodFlag=1 and DeleteFlag =0 order by CreatedTime desc");
            return GetListArrayCache(10, sWhere, "");
        }

        public List<Entity.Topics> getListArrayByQZZD()
        {
            string sWhere = string.Format("SiteOrderTopFlag =1 and DeleteFlag =0 order by CreatedTime desc");
            return GetListArrayCache(10, sWhere, "");
        }

        public List<Entity.Topics> getListArrayByBKZD(string ChannelId)
        {
            string sWhere = string.Format("ChannelId='{0}' and OrderTopFlag=1 and DeleteFlag =0 order by CreatedTime desc", ChannelId);
            return GetListArrayCache(10, sWhere, "");
        }

        public List<Entity.Topics> GetListPagesByChannelId(int PageIndex, int PageSize, out int RecordCount, string ChannelId)
        {
            string sWhere = string.Format("DeleteFlag =0 and OrderTopFlag=0 and ChannelId='{0}'", ChannelId);
            return GetListPagesCache(PageIndex, PageSize, sWhere, "", "CreatedTime desc", out RecordCount);
        }

        public List<Entity.Topics> GetListArrayByUserId(string uId, string word)
        {
            string sWhere = "";
            if (string.IsNullOrEmpty(word))
            {
                sWhere = string.Format("DeleteFlag =0 and UserID='{0}'", uId);
            }
            else
            {
                sWhere = string.Format("DeleteFlag =0 and UserID='{0}' and GoodFlag=1", uId);
            }

            return GetListArray(sWhere);
        }

        public List<Entity.Topics> GetListArrayByBkId(string bkId, string IsToday)
        {
            string sWhere = "";
            DateTime startTime = DateTime.Now.Date;
            DateTime endTime = startTime.AddHours(23);
            endTime = endTime.AddMinutes(59);
            endTime = endTime.AddSeconds(59);
            if (string.IsNullOrEmpty(IsToday))
            {
                sWhere = string.Format("DeleteFlag =0 and ChannelID='{0}'", bkId);
            }
            else
            {
                sWhere = string.Format("DeleteFlag =0 and ChannelID='{0}' and CreatedTime  between '{1}' and  '{2}'", bkId, startTime, endTime);
            }
            return GetListArray(sWhere);
        }
        #endregion  自定义方法

        #region  自定义方法
        /// <summary>
        /// 查出一定时间内的帖子总数 =主题+回复
        /// </summary>
        /// <param name="strsql">今日 昨日 的条件</param>
        /// <param name="isTheme">true 帖子 false 主题</param>
        /// <returns></returns>
        public static long TopicSum(string strsql, bool isTheme)
        {
            long tSum = 0;
            List<ModuleCore.Entity.Topics> TaDayls = ModuleCore.BLL.Topics.Instance.GetListArray(strsql);

            if (TaDayls.Count > 0)
            {
                tSum = TaDayls.Count;
                if (isTheme)
                {
                    foreach (ModuleCore.Entity.Topics topicse in TaDayls)
                    {
                        List<ModuleCore.Entity.TopicReplies> repList =
                            ModuleCore.BLL.TopicReplies.Instance.GetListArray("DeleteFlag=0 and TopicID=" + topicse.id);
                        if (repList.Count > 0)
                        {
                            tSum += repList.Count;
                        }
                    }
                }
            }
            return tSum;
        }
        #endregion
    }
}

