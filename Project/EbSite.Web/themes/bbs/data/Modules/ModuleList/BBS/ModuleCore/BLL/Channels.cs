using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.BBS.ModuleCore.BLL
{
    /// <summary>
    /// 业务逻辑类Channels 的摘要说明。
    /// </summary>
    public class Channels : Base.BLLBase<Entity.Channels, int>
    {
        public static readonly Channels Instance = new Channels();
        private Channels()
        {
        }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dalHelper.Channels_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dalHelper.Channels_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.Channels model)
        {
            base.InvalidateCache();
            return dalHelper.Channels_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.Channels model)
        {
            base.InvalidateCache();
            dalHelper.Channels_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            dalHelper.Channels_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.Channels GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.Channels etEntity = base.GetCacheItem(rawKey) as Entity.Channels;
            if (Equals(etEntity, null))
            {
                etEntity = dalHelper.Channels_GetEntity(id);
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
            return dalHelper.Channels_GetCount(strWhere);
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
            return dalHelper.Channels_GetList(Top, strWhere, filedOrder);
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
        override public List<Entity.Channels> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dalHelper.Channels_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Channels> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.Channels> lstData = base.GetCacheItem(rawKey) as List<Entity.Channels>;
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
        public List<Entity.Channels> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Channels> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.Channels> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dalHelper.Channels_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Channels> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.Channels> lstData = base.GetCacheItem(rawKey) as List<Entity.Channels>;
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
        public List<Entity.Channels> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Channels> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Channels> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.Channels> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.Channels mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ChannelName".ToLower()))
                    {
                        sValue = mdEt.ChannelName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ChannelDescription".ToLower()))
                    {
                        sValue = mdEt.ChannelDescription.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ChannelImageUrl".ToLower()))
                    {
                        sValue = mdEt.ChannelImageUrl.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "OrderFlag".ToLower()))
                    {
                        sValue = mdEt.OrderFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CreatedTime".ToLower()))
                    {
                        sValue = mdEt.CreatedTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "UpdatedTime".ToLower()))
                    {
                        sValue = mdEt.UpdatedTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TopicCount".ToLower()))
                    {
                        sValue = mdEt.TopicCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ReplyCount".ToLower()))
                    {
                        sValue = mdEt.ReplyCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "PostCount".ToLower()))
                    {
                        sValue = mdEt.PostCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TodayPostCount".ToLower()))
                    {
                        sValue = mdEt.TodayPostCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SatisticsTime".ToLower()))
                    {
                        sValue = mdEt.SatisticsTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ChannelFlag".ToLower()))
                    {
                        sValue = mdEt.ChannelFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ReadFlag".ToLower()))
                    {
                        sValue = mdEt.ReadFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "WriteFlag".ToLower()))
                    {
                        sValue = mdEt.WriteFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ChannelLinkFlag".ToLower()))
                    {
                        sValue = mdEt.ChannelLinkFlag.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ChannelLinkUrl".ToLower()))
                    {
                        sValue = mdEt.ChannelLinkUrl.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "LatestBBSTopicID".ToLower()))
                    {
                        sValue = mdEt.LatestBBSTopicID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "LatestBBSTopicTitle".ToLower()))
                    {
                        sValue = mdEt.LatestBBSTopicTitle.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "LatestBBSTopicUserID".ToLower()))
                    {
                        sValue = mdEt.LatestBBSTopicUserID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "LatestBBSTopicUserName".ToLower()))
                    {
                        sValue = mdEt.LatestBBSTopicUserName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "LatestBBSTopicRepliedTime".ToLower()))
                    {
                        sValue = mdEt.LatestBBSTopicRepliedTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CompanyID".ToLower()))
                    {
                        sValue = mdEt.CompanyID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ParentID".ToLower()))
                    {
                        sValue = mdEt.ParentID.ToString();
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
            Entity.Channels mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ChannelName".ToLower()))
                    {
                        mdEntity.ChannelName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ChannelDescription".ToLower()))
                    {
                        mdEntity.ChannelDescription = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ChannelImageUrl".ToLower()))
                    {
                        mdEntity.ChannelImageUrl = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "OrderFlag".ToLower()))
                    {
                        mdEntity.OrderFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CreatedTime".ToLower()))
                    {
                        mdEntity.CreatedTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UpdatedTime".ToLower()))
                    {
                        mdEntity.UpdatedTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TopicCount".ToLower()))
                    {
                        mdEntity.TopicCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ReplyCount".ToLower()))
                    {
                        mdEntity.ReplyCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "PostCount".ToLower()))
                    {
                        mdEntity.PostCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TodayPostCount".ToLower()))
                    {
                        mdEntity.TodayPostCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "SatisticsTime".ToLower()))
                    {
                        mdEntity.SatisticsTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ChannelFlag".ToLower()))
                    {
                        mdEntity.ChannelFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ReadFlag".ToLower()))
                    {
                        mdEntity.ReadFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "WriteFlag".ToLower()))
                    {
                        mdEntity.WriteFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ChannelLinkFlag".ToLower()))
                    {
                        mdEntity.ChannelLinkFlag = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ChannelLinkUrl".ToLower()))
                    {
                        mdEntity.ChannelLinkUrl = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "LatestBBSTopicID".ToLower()))
                    {
                        mdEntity.LatestBBSTopicID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "LatestBBSTopicTitle".ToLower()))
                    {
                        mdEntity.LatestBBSTopicTitle = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "LatestBBSTopicUserID".ToLower()))
                    {
                        mdEntity.LatestBBSTopicUserID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "LatestBBSTopicUserName".ToLower()))
                    {
                        mdEntity.LatestBBSTopicUserName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "LatestBBSTopicRepliedTime".ToLower()))
                    {
                        mdEntity.LatestBBSTopicRepliedTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CompanyID".ToLower()))
                    {
                        mdEntity.CompanyID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ParentID".ToLower()))
                    {
                        mdEntity.ParentID = int.Parse(column.ColumnValue);
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
        public Entity.Channels GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.Channels mdEt = new Entity.Channels();
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
                else if (Equals(uc.ID.ToLower(), "ChannelName".ToLower()))
                {
                    mdEt.ChannelName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ChannelDescription".ToLower()))
                {
                    mdEt.ChannelDescription = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ChannelImageUrl".ToLower()))
                {
                    mdEt.ChannelImageUrl = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "OrderFlag".ToLower()))
                {
                    mdEt.OrderFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "CreatedTime".ToLower()))
                {
                    mdEt.CreatedTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "UpdatedTime".ToLower()))
                {
                    mdEt.UpdatedTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "TopicCount".ToLower()))
                {
                    mdEt.TopicCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ReplyCount".ToLower()))
                {
                    mdEt.ReplyCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "PostCount".ToLower()))
                {
                    mdEt.PostCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "TodayPostCount".ToLower()))
                {
                    mdEt.TodayPostCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "SatisticsTime".ToLower()))
                {
                    mdEt.SatisticsTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ChannelFlag".ToLower()))
                {
                    mdEt.ChannelFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ReadFlag".ToLower()))
                {
                    mdEt.ReadFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "WriteFlag".ToLower()))
                {
                    mdEt.WriteFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ChannelLinkFlag".ToLower()))
                {
                    mdEt.ChannelLinkFlag = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ChannelLinkUrl".ToLower()))
                {
                    mdEt.ChannelLinkUrl = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "LatestBBSTopicID".ToLower()))
                {
                    mdEt.LatestBBSTopicID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "LatestBBSTopicTitle".ToLower()))
                {
                    mdEt.LatestBBSTopicTitle = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "LatestBBSTopicUserID".ToLower()))
                {
                    mdEt.LatestBBSTopicUserID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "LatestBBSTopicUserName".ToLower()))
                {
                    mdEt.LatestBBSTopicUserName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "LatestBBSTopicRepliedTime".ToLower()))
                {
                    mdEt.LatestBBSTopicRepliedTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "CompanyID".ToLower()))
                {
                    mdEt.CompanyID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ParentID".ToLower()))
                {
                    mdEt.ParentID = int.Parse(sValue);
                }

            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法

        public List<Entity.Channels> GetTree_pic(int iTop)
        {
            List<Entity.Channels> getClass = GetListArray(iTop, "", "");
            List<Entity.Channels> getTree = new List<Entity.Channels>();


            string sPatch = string.Concat("<img src=\"",EbSite.Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (Entity.Channels tree in getClass)
            {
                //Entity.Menus mdTem = tree.Clone();
                if (tree.ParentID == 0)
                {

                    tree.ChannelName = sPatch + string.Format("<b><font color=red>{0}</font></b><a name=\"a{1}\"></a>", tree.ChannelName, tree.id);
                    getTree.Add(tree);
                    GetSubItem_pic(tree.id, ref getTree, "", getClass);
                }

            }
            return getTree;
        }
        /// <summary>
        /// 获取某个记录下的子记录，从而构建树形(递归调用)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="GetTree"></param>
        /// <param name="blank"></param>
        private void GetSubItem_pic(int id, ref List<Entity.Channels> NewClass, string blank, List<Entity.Channels> OldClass)
        {
            string sW3 = string.Concat("<img src=\"", EbSite.Base.AppStartInit.IISPath, "Images/tree/w3.gif\" align=absmiddle>");
            string sW1 = string.Concat("<img src=\"", EbSite.Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (Entity.Channels mdModel in OldClass)
            {
                //Entity.Menus mdTem = mdModel.Clone();
                if (mdModel.ParentID == id)
                {
                    string str = blank;
                    str = string.Concat(str, sW3);
                    mdModel.ChannelName = str + sW1 + mdModel.ChannelName;
                    NewClass.Add(mdModel);
                    GetSubItem_pic(mdModel.id, ref NewClass, str, OldClass);
                }
            }
        }
        public List<Entity.Channels> GetTree(int iTop)
        {


            List<Entity.Channels> getClass = GetListArray(iTop, "", "");
            List<Entity.Channels> getTree = new List<Entity.Channels>();

            foreach (Entity.Channels tree in getClass)
            {
                if (tree.ParentID == 0)
                {
                    tree.ChannelName = "╋" + tree.ChannelName;
                    getTree.Add(tree);
                    GetSubItem(tree.id, ref getTree, "├", getClass);
                }

            }
            return getTree;

          
        }
        /// <summary>
        /// 获取某个记录下的子记录，从而构建树形(递归调用)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="GetTree"></param>
        /// <param name="blank"></param>
        private void GetSubItem(int id, ref List<Entity.Channels> NewClass, string blank, List<Entity.Channels> OldClass)
        {
            foreach (Entity.Channels mdModel in OldClass)
            {
                if (mdModel.ParentID == id)
                {
                    string str = blank + "─";
                    mdModel.ChannelName = str + "『" + mdModel.ChannelName + "』";
                    NewClass.Add(mdModel);
                    GetSubItem(mdModel.id, ref NewClass, str, OldClass);
                }
            }
        }

        #endregion  自定义方法
        #region 欢乐添加
        /// <summary>
        /// 得到定向页面的地址 若还有子类到 | 没有子类 t=12;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetUrlT(int id)
        {
            string strUrl = "";
            string T1 = "<a href='?t=1&tid=" + id + "'> <img src=\"/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png\"></img></a> ";
            string T2 = "<a href='?t=1&tid=" + id + "'> <img src=\"/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default_Father.png\"></img></a> ";

            List<ModuleCore.Entity.Channels> ls = ModuleCore.BLL.Channels.Instance.GetListArray("parentid=" + id);
            if (ls.Count > 0)
            {
                strUrl = T2;
            }
            else
            {
                strUrl = T1;
            }
            return strUrl;
        }
        /// <summary>
        /// 线条 三个一组
        /// </summary>
        /// <param name="reID"></param>
        /// <param name="pID"></param>
        /// <returns></returns>
        public static string RebackLine(int reID, int pID)
        {
            List<ModuleCore.Entity.Channels> ls = ModuleCore.BLL.Channels.Instance.GetListArray("parentid=" + pID);

            string str = "";
            string strLine = " <div class=\"bbs-line\"></div>";
            if (reID != ls.Count)
            {
                if (reID % 3 == 0)
                {
                    str = strLine;
                }
            }
            return str;

        }
        #endregion
    }
}

