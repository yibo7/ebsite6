//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Common;

////请先添加引用
//namespace EbSite.Data.Interface
//{
//    /// <summary>
//    /// 数据访问类NewsContent。
//    /// </summary>
//    public partial interface IDataProviderCms
//    {
//        #region  成员方法

//        /// <summary>
//        /// 得到最大ID
//        /// </summary>
//        int NewsContent_GetMaxId();
//        /// <summary>
//        /// 是否存在该记录
//        /// </summary>
//         bool NewsContent_Exists(string sWhere);

//        void NewsContent_UpdateAllRule(string sRule);
//        /// <summary>
//        /// 增加一条数据
//        /// </summary>
//         int NewsContent_Add(EbSite.Entity.NewsContent model);
//        /// <summary>
//        /// 更新一条数据
//        /// </summary>
//         void NewsContent_Update(EbSite.Entity.NewsContent model);
//        /// <summary>
//        /// 得到一个对象实体
//        /// </summary>
//         EbSite.Entity.NewsContent NewsContent_GetModel(int ID);

//         /// <summary>
//         /// 合并分类，及数据
//         /// </summary>
//         /// <param name="iSID">源分类ID及其下的所有子分类ID列表，用逗号分开</param>
//         /// <param name="iTID">目标分类ID</param>
//         void NewsContent_MergeClass(string SIDs, int TID, string TClassName);
        
//        /// <summary>
//        /// 添加点击,指定更新点击数
//        /// </summary>
//        /// <param name="iMusicID"></param>
//        void NewsContent_AddHits(int iMusicID, int iNum);
//        /// <summary>
//        /// 对点击数清零
//        /// </summary>
//        void NewsContent_ResetHits(string Interval);

//        /// <summary>
//        /// 获取最后一条记录
//        /// </summary>
//         EbSite.Entity.NewsContent NewsContent_GetLastModel();
	    
//        /// <summary>
//        /// 推荐新闻或取消推荐新闻
//        /// </summary>
//        /// <param name="iID"></param>
//         void NewsContent_UploadIsGood(int iID);
//        /// <summary>
//        /// 删除一条数据
//        /// </summary>
//         void NewsContent_Delete(int ID);
//         void NewsContent_Delete(string IDs);
         
//        /// 获取某个专题的数据-分页
//        /// </summary>
//        /// <param name="startRowIndex"></param>
//        /// <param name="maxinmumRows"></param>
//        /// <param name="SpecialClassID"></param>
//        /// <returns></returns>
//         List<EbSite.Entity.NewsContent> NewsContent_GetListPagesFromSpecialID(int PageIndex, int PageSize,
//                                                                         int SpecialClassID, out int Count,int SiteID);
//        /// <summary>
//        /// 获取某个专题的数据-分页
//        /// </summary>
//        /// <param name="startRowIndex"></param>
//        /// <param name="maxinmumRows"></param>
//        /// <param name="SpecialClassID"></param>
//        /// <returns></returns>
//         List<EbSite.Entity.NewsContent> NewsContent_GetListFromSpecialID(int SpecialClassID, int top,bool IsGetSub,int SiteID);
//         List<EbSite.Entity.NewsContent> NewsContent_GetListPagesFromTagID(int PageIndex, int PageSize, int TagID,
//                                                                     out int Count,int SiteID);
//         int NewsContent_GetCountByTagID(int tid,int SiteID);
//        /// <summary>
//         /// 获取总记录条数
//        /// </summary>
//        /// <param name="strWhere"></param>
//        /// <param name="IsAuditing">-1获取全部，0获取未审核，1获取已经通过审核的</param>
//        /// <returns></returns>
//         int NewsContent_GetCount(string strWhere, int IsAuditing,int SiteID);
//        /// <summary>
//        /// 对象实体绑定数据
//        /// </summary>
//         EbSite.Entity.NewsContent NewsContent_ReaderBind(IDataReader dataReader);

//        void NewsContent_UpdateCommentNum(int iID, int iNum);
//        void NewsContent_UpdateFavorableNum(int iID, int iNum);

//        List<EbSite.Entity.NewsContent> NewsContent_GetTagRelate(int top, int ContentId,string Fields,int SiteID);

//        /// <summary>
//        /// 获得数据列表
//        /// </summary>
//        List<EbSite.Entity.NewsContent> NewsContent_GetGoodList(int itop, string classids,int SiteID);

//        DataSet NewsContent_GetListDataSet(string strWhere, int iTop, string oderby, int SiteID);

//        List<EbSite.Entity.NewsContent> NewsContent_GetListArray(string strWhere, int iTop, string oderby, string Fields, int SiteID);

//        List<EbSite.Entity.NewsContent> GetListGood(int iTop, int iClassid, bool IsGetSub, bool IsImg, string Fields, int SiteID);
//        void NewsContent_ToDefault(EbSite.Entity.NewsContent md);
//        void NewsContent_InitNum(int itype, int SiteID);
//        void NewsContent_InitClassName(int SiteID);

//        //void UpdateConfigsofContent(int iClassID,  Guid ContentModelID, Guid ContentTemID, bool IsUpdateToSub,int SiteID);

//        List<EbSite.Entity.NewsContent> NewsContent_GetListPages(int PageIndex, int PageSize, string strWhere,string Fileds,
//                                                           string oderby, bool IsAuditing, bool IsGood, out int Count, int SiteID);
//        /// <summary>
//        /// 分页获取数据列表 
//        /// </summary>
//        List<EbSite.Entity.NewsContent> NewsContent_GetListPages(int PageIndex, int PageSize, string strWhere,
//                                                           string oderby, bool IsAuditing, bool IsGood, out int Count, int SiteID);



//        string GetContentsFromSpecialIDSqlWhere(int SpecialClassID);
//        /// <summary>
//        /// 喜欢一条记录或不喜欢一条记录
//        /// </summary>
//        /// <param name="contentid">内容ID</param>
//        /// <param name="itype">0,为不喜欢，1为喜欢</param>
//        void NewsContent_LikeOrNo(int contentid,int itype);


//        EbSite.Entity.NewsContent NewsContent_GetModel(string sField, string strWhere);

//        DataSet NewsContent_Related(int bid, int top, int count,int siteid);

//        void NewsContent_Update(int id, string Col, string sValue);
//        #endregion  成员方法
//        void NewsContent_Update(string Where, string Col, string sValue);


//        void DeleteNewsContentOutSiteData(string siteids);

//        List<Entity.NewsContent> GetVisiteByUserID(int UserID);

//        void NewsContent_Update(EbSite.Entity.NewsContent model, DbTransaction Trans);
//    }
//}

