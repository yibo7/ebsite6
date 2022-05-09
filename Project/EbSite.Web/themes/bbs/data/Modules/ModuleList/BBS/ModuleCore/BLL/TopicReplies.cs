using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.BBS.ModuleCore.BLL
{
    /// <summary>
    /// 业务逻辑类TopicReplies 的摘要说明。
    /// </summary>
    public class TopicReplies  
    {
        public static readonly TopicReplies Instance = new TopicReplies();
        protected static DALInterface.IDataProvider dalHelper
        {
            get
            {
                return DAL.DataProfile.DalFactory.DalProvider;
            }
        }
        private TopicReplies()
        {
        }

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public long GetMaxId(int classid)
        {
            return dalHelper.TopicReplies_GetMaxId(classid);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long id, int classid)
        {
            return dalHelper.TopicReplies_Exists(id, classid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
         public long Add(Entity.TopicReplies model, int classid)
        {
             
            return dalHelper.TopicReplies_Add(model, classid);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
         public void Update(Entity.TopicReplies model, int classid)
        {
             
            dalHelper.TopicReplies_Update(model, classid);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
         public void Delete(long id, int classid)
        {
            

            dalHelper.TopicReplies_Delete(id, classid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         public Entity.TopicReplies GetEntity(long id, int classid)
        {
            return dalHelper.TopicReplies_GetEntity(id, classid);
            //string rawKey = string.Concat("GetEntity-", id);
            //Entity.TopicReplies etEntity = base.GetCacheItem(rawKey) as Entity.TopicReplies;
            //if (Equals(etEntity, null))
            //{
            //    etEntity = dalHelper.TopicReplies_GetEntity(id, classid);
            //    if (!Equals(etEntity, null))
            //        base.AddCacheItem(rawKey, etEntity);
            //}
            //return etEntity;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCount(string strWhere, int classid)
        {
            return dalHelper.TopicReplies_GetCount(strWhere, classid);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCountCache(string strWhere, int classid)
        {
            return GetCountCache(strWhere, classid);

            //string rawKey = string.Concat("GetCount-", strWhere);
            //string sCount = base.GetCacheItem(rawKey) as string;
            //if (string.IsNullOrEmpty(sCount))
            //{
            //    sCount = GetCountCache(strWhere, classid).ToString();
            //    if (!string.IsNullOrEmpty(sCount))
            //        base.AddCacheItem(rawKey, sCount);
            //}
            //if (!string.IsNullOrEmpty(sCount))
            //{
            //    return int.Parse(sCount);
            //}
            //return 0;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCount(int classid)
        {
            return GetCountCache("", classid);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, int classid)
        {
            return GetListCache(0, strWhere, "", classid);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int classid)
        {
            return GetList("", classid);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder, int classid)
        {
            return dalHelper.TopicReplies_GetList(Top, strWhere, filedOrder, classid);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListCache(int Top, string strWhere, string filedOrder, int classid)
        {
            return GetList(Top, strWhere, filedOrder, classid);
            //string rawKey = string.Concat("GetList-", strWhere, Top, filedOrder);
            //DataSet lstData = base.GetCacheItem(rawKey) as DataSet;
            //if (Equals(lstData, null))
            //{
            //    lstData = GetList(Top, strWhere, filedOrder, classid);
            //    if (!Equals(lstData, null))
            //        base.AddCacheItem(rawKey, lstData);
            //}
            //return lstData;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
         public List<Entity.TopicReplies> GetListArray(int Top, string strWhere, string filedOrder, int classid)
        {
            return dalHelper.TopicReplies_GetListArray(Top, strWhere, filedOrder, classid);
        }
         /// <summary>
         /// 获得数据列表
         /// </summary>
         public List<Entity.TopicReplies> GetListArrayCache(int Top, string strWhere, string filedOrder, int classid)
         {
             return GetListArray(Top, strWhere, filedOrder, classid);

             //string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
             //List<Entity.TopicReplies> lstData = base.GetCacheItem(rawKey) as List<Entity.TopicReplies>;
             //if (Equals(lstData, null))
             //{
             //    //从基类调用，激活事件
             //    lstData = base.GetListArrayEv(Top, strWhere, filedOrder);
             //    if (!Equals(lstData, null))
             //        base.AddCacheItem(rawKey, lstData);
             //}
             //return lstData;
         }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.TopicReplies> GetListArray(int Top, string filedOrder, int classid)
        {
            return GetListArrayCache(Top, "", filedOrder, classid);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.TopicReplies> GetListArray(string strWhere, int classid)
        {
            return GetListArrayCache(0, strWhere, "", classid);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.TopicReplies> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount, int classid)
        {
            return dalHelper.TopicReplies_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount, classid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.TopicReplies> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount, int classid)
        {
            return GetListPages( PageIndex,  PageSize,  strWhere,  Fileds,  oderby, out  RecordCount,  classid);
             
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.TopicReplies> GetListPages(int PageIndex, int PageSize, out int RecordCount, int classid)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount, classid);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.TopicReplies> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount, int classid)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount, classid);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.TopicReplies> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, int classid)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount, classid);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.TopicReplies> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName, int classid)
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(sKeyWord)) strWhere = string.Format("{0} like '%{1}%'", ColumnName, sKeyWord);
            if (string.IsNullOrEmpty(strWhere))
            {
                RecordCount = 0;
                return null;
            }
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount, classid);
        }
     
        #endregion  成员方法

        #region  自定义方法

        public int TopicReplies_Copy(string TableName)
        {
            return dalHelper.TopicReplies_Copy(TableName);
        }

        public List<Entity.TopicReplies> GetListPagesByPostID(int PageIndex, int PageSize, out int RecordCount, long ContentID, int classid)
        {
            return dalHelper.TopicReplies_GetListPages(PageIndex, PageSize, string.Concat("TopicID=", ContentID), "", " id asc ", out  RecordCount, classid);
        }

        public List<Entity.TopicReplies> GetListArrayByTopicId(long TopicId, int classid)
        {
            string sWhere = string.Format("TopicID='{0}'", TopicId);
            return GetListArray(sWhere, classid);
        }
        public List<Entity.TopicReplies> GetListPageByCls(int PageIndex, int PageSize, out int RecordCount, string cls, string getWhere, int classid)
        {
            string sWhere = "";
            if (string.IsNullOrEmpty(cls)) //全部帖子为没有删除的
            {
                sWhere = string.Format("DeleteFlag!='{0}'", "1");
            }
            else if (string.Equals(cls, "1"))//没有审核的帖子
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
            return GetListPagesCache(PageIndex, PageSize, sWhere.Trim(), "", "", out RecordCount, classid);

        }
        /// <summary>
        /// 回复一个帖子
        /// </summary>
        /// <param name="postid">帖子ID</param>
        /// <param name="c">回复内容</param>
        /// <param name="rc">引用内容id</param>
        /// <param name="allcount">当前回复的总数</param>
        /// <param name="site">当前站点ID</param>
        /// <returns></returns>
        public string AddHf(int postid, string c, string rc, int allcount, int site, int endpageindex, out bool isok, int classid)
        {

            if (!string.IsNullOrEmpty(c) && c.Length > 2)
            {

                ModuleCore.Entity.TopicReplies md = new Entity.TopicReplies();

                //string rcContent = string.Empty;

                //if (rcid>0)
                //{

                //    Entity.TopicReplies mdReference = GetEntity(rcid);
                //    rcContent = Core.Strings.GetString.CutLen(mdReference.ReplyContent,50);
                //}


                md.AuditFlag = 1;
                md.CreatedIP = Core.Utils.GetClientIP();
                md.CreatedTime = DateTime.Now;
                md.DeleteFlag = 0;
                md.IsBadCount = 0;
                md.IsGoodCount = 0;
                md.ReferenceContent = rc;
                md.ReferenceFlag = string.IsNullOrEmpty(rc) ? 0 : 1;
                md.ReplyContent = c;
                md.TopicID = postid;
                md.UpdatedTime = md.CreatedTime;

                Entity.imitateuser mdimitateuser = imitateuser.Instance.GetRandByUserID(EbSite.Base.Host.Instance.UserID);
                if (!Equals(mdimitateuser, null)) //模拟发帖
                {
                    if (mdimitateuser.UserID > 0)
                    {
                        md.UserID = mdimitateuser.ImitateUserID;
                        md.UserName = mdimitateuser.ImitateUserRealName;
                    }

                }
                else
                {
                    md.UserID = EbSite.Base.Host.Instance.UserID;
                    md.UserName = EbSite.Base.AppStartInit.UserNiName;
                }


                Add(md, classid);

                EbSite.Entity.NewsContent mdContent = EbSite.Base.AppStartInit.GetNewsContentInst(classid).GetModel(postid, site);
                //默认初始化当前用户为最后回复人
                mdContent.Annex2 = md.UserName; //最后回复人姓名
                mdContent.Annex3 = md.UserID.ToString();//最后回复人ID
                mdContent.AddTime = DateTime.Now;//最后回复时间
                mdContent.CommentNum = allcount + 1;

                EbSite.Base.AppStartInit.GetNewsContentInst(classid).Update(mdContent);
                BBSClass.UpdateCountAddOne(mdContent.ClassID, false, mdContent.ID, mdContent.NewsTitle, md.UserID,
                                           md.UserName);

                isok = true;

                return GetLinks.ContentPage(postid, endpageindex, site, classid);
            }
            else
            {
                isok = false;
                return EbSite.Base.Host.Instance.GetTips("文明发帖，请不要灌水，谢谢！");
            }

        }
        public void EditeReply(long id, string ContentHtml, int classid)
        {

            dalHelper.EditeReply(id, ContentHtml, classid);
        }

        #endregion  自定义方法

        #region PostContent

        public void UpdatePost(int SetTop, int PostLab, int TitleFont, string TitleColor, string IDs, int ManagerUserId, string ManagerUserNiName, int classid)
        {
            dalHelper.UpdatePost(SetTop, PostLab, TitleFont, TitleColor, IDs, ManagerUserId, ManagerUserNiName, classid);
        }
         
        #endregion
        public void Update(int id, string Col, string sValue, int classid)
        {
            dalHelper.TopicReplies_Update(id, Col, sValue, classid);
        }

        public void SetPostToDel(int id, int classid)
        {
            Update(id, "DeleteFlag", "1", classid);
             
        }
        public void SetPostToHY(int id, int classid)
        {
            Update(id, "DeleteFlag", "0", classid);
             
        }


    }
}

