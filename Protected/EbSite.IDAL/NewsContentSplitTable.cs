using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

//请先添加引用
namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类NewsContent。
	/// </summary>
	public partial interface IDataProviderCms
	{
		#region  成员方法

	    /// <summary>
	    /// 得到最大ID
	    /// </summary>
        long NewsContent_GetMaxId(string TableName);
	    /// <summary>
	    /// 是否存在该记录
	    /// </summary>
        bool NewsContent_Exists(string sWhere, string TableName);

        void NewsContent_UpdateAllRule(string sRule, string TableName);
	    /// <summary>
	    /// 增加一条数据
	    /// </summary>
        int NewsContent_Add(EbSite.Entity.NewsContent model, string TableName);
	    /// <summary>
	    /// 更新一条数据
	    /// </summary>
        void NewsContent_Update(EbSite.Entity.NewsContent model, string TableName);
	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
        EbSite.Entity.NewsContent NewsContent_GetModel(long ID, string TableName, int SiteID);
        EbSite.Entity.NewsContent NewsContent_GetModel(long ID, string TableName,int ClassId, int SiteID);
        

        /// <summary>
        /// 合并分类，及数据
        /// </summary>
        /// <param name="iSID">源分类ID及其下的所有子分类ID列表，用逗号分开</param>
        /// <param name="iTID">目标分类ID</param>
        void NewsContent_MergeClass(string SIDs, int TID, string TClassName, string TableName);
        
	    /// <summary>
	    /// 添加点击,指定更新点击数
	    /// </summary>
	    /// <param name="iMusicID"></param>
        void NewsContent_AddHits(int iMusicID, int iNum, string TableName);
	    /// <summary>
	    /// 对点击数清零
	    /// </summary>
        void NewsContent_ResetHits(string Interval, string TableName);

	    /// <summary>
	    /// 获取最后一条记录
	    /// </summary>
         EbSite.Entity.NewsContent NewsContent_GetLastModel(string TableName,int SiteID);
	    
	    /// <summary>
	    /// 推荐新闻或取消推荐新闻
	    /// </summary>
	    /// <param name="iID"></param>
         void NewsContent_UploadIsGood(long iID, string TableName);
	    /// <summary>
	    /// 删除一条数据
	    /// </summary>
         void NewsContent_Delete(long ID, string TableName);
         void NewsContent_Delete(string IDs, string TableName);
         
	    /// 获取某个专题的数据-分页
	    /// </summary>
	    /// <param name="startRowIndex"></param>
	    /// <param name="maxinmumRows"></param>
	    /// <param name="SpecialClassID"></param>
	    /// <returns></returns>
         List<EbSite.Entity.NewsContent> NewsContent_GetListPagesFromSpecialID(int PageIndex, int PageSize,
                                                                         int SpecialClassID, out int Count, int SiteID);
	    /// <summary>
	    /// 获取某个专题的数据-分页
	    /// </summary>
	    /// <param name="startRowIndex"></param>
	    /// <param name="maxinmumRows"></param>
	    /// <param name="SpecialClassID"></param>
	    /// <returns></returns>
         List<EbSite.Entity.NewsContent> NewsContent_GetListFromSpecialID(int SpecialClassID, int top, bool IsGetSub, int SiteID);
         List<EbSite.Entity.NewsContent> NewsContent_GetListPagesFromTagID(int PageIndex, int PageSize, int TagID,
                                                                     out int Count, int SiteID);
         int NewsContent_GetCountByTagID(int tid, int SiteID, string TableName);
	    /// <summary>
         /// 获取总记录条数
	    /// </summary>
	    /// <param name="strWhere"></param>
	    /// <param name="IsAuditing">-1获取全部，0获取未审核，1获取已经通过审核的</param>
	    /// <returns></returns>
         int NewsContent_GetCount(string strWhere, int IsAuditing, int SiteID, string TableName);
	    /// <summary>
	    /// 对象实体绑定数据
	    /// </summary>
        // EbSite.Entity.NewsContent NewsContent_ReaderBind(IDataReader dataReader);

         void NewsContent_UpdateCommentNum(long iID, int iNum, string TableName);
         void NewsContent_UpdateFavorableNum(long iID, int iNum, string TableName);

         List<EbSite.Entity.NewsContent> NewsContent_GetTagRelate(int top, long ContentId, string Fields, int SiteID, string TableName);

        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<EbSite.Entity.NewsContent> NewsContent_GetGoodList(int itop, string classids, int SiteID, string TableName);

         DataSet NewsContent_GetListDataSet(string strWhere, int iTop, string oderby, int SiteID, string TableName);

         List<EbSite.Entity.NewsContent> NewsContent_GetListArray(string strWhere, int iTop, string oderby, string Fields, int SiteID, string TableName);

        List<EbSite.Entity.NewsContent> NewsContent_GetListArray(string strWhere, int iTop, string oderby, string Fields, int SiteID, string TableName, bool? IsAuditing);

        List<EbSite.Entity.NewsContent> GetListGood(int iTop, int iClassid, bool IsGetSub, bool IsImg, string Fields, int SiteID, string TableName);
         void NewsContent_ToDefault(EbSite.Entity.NewsContent md, string TableName);
         void NewsContent_InitNum(int itype, int SiteID, string TableName);
         void NewsContent_InitClassName(int SiteID, string TableName);

        //void UpdateConfigsofContent(int iClassID,  Guid ContentModelID, Guid ContentTemID, bool IsUpdateToSub,int SiteID);

        List<EbSite.Entity.NewsContent> NewsContent_GetListPages(int PageIndex, int PageSize, string strWhere,string Fileds,
                                                           string oderby, bool? IsAuditing, bool IsGood, out int Count, int SiteID, string TableName);

        List<EbSite.Entity.NewsContent> NewsContent_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,
                                                          string oderby, bool? IsAuditing, bool IsGood, out int Count, int SiteID, string TableName, int iAddDataToSpecialByID);
        /// <summary>
        /// 分页获取数据列表 
        /// </summary>
        List<EbSite.Entity.NewsContent> NewsContent_GetListPages(int PageIndex, int PageSize, string strWhere,
                                                           string oderby, bool? IsAuditing, bool IsGood, out int Count, int SiteID, string TableName);



        string GetContentsFromSpecialIDSqlWhere(int SpecialClassID, string TableName);
        /// <summary>
        /// 喜欢一条记录或不喜欢一条记录
        /// </summary>
        /// <param name="contentid">内容ID</param>
        /// <param name="itype">0,为不喜欢，1为喜欢</param>
        void NewsContent_LikeOrNo(int contentid, int itype, string TableName);


        EbSite.Entity.NewsContent NewsContent_GetModel(string sField, string strWhere, string TableName,int SiteID);

	    List<Entity.NewsContent> NewsContent_Related(bool IsHaveImg, int top, int ClassId, int siteid, long NoInId,
	        string TableName);

        void NewsContent_Update(long id, string Col, string sValue, string TableName);
        #endregion  成员方法
        void NewsContent_Update(string Where, string Col, string sValue, string TableName);


        void DeleteNewsContentOutSiteData(string siteids, string TableName);

        List<Entity.NewsContent> GetVisiteByUserID(int UserID, string TableName,int SiteID);

        void NewsContent_Update(EbSite.Entity.NewsContent model, DbTransaction Trans, string TableName);


	    bool NewTb_Exists(string sTbName);

	    bool NewTb_Create(string sTbName);

	    List<EbSite.Entity.NewsContent> NewsContentUn_GetListPages(int PageIndex, int PageSize, string strWhere,
	                                                               string Fileds, bool IsAuditing,
	                                                               bool IsGood, out int Count, int SiteID,
                                                                   string TableNames, string OrderBy);

        bool NewColumnName_Add(string sTbName, string ColumnName, EbSite.Base.EntityAPI.EDataFiledType ColumnType, int iLength);

	    bool NewColumnName_Del(string sTbName, string ColumnName);


	    string NewTbName(string TbName);



        //List<EbSite.Entity.NewsContent> NewsContentUn_GetListPagesFromSpecialID(int PageIndex, int PageSize, int SpecialClassID,
        //                                                             out int Count, int SiteID, string TableNames);

	    List<EbSite.Entity.NewsContent> NewsContentUn_GetListArray(string strWhere, int iTop, string oderby, string Fileds,
	                                                               int SiteID, string TableNames);

        long NewsContent_GetMinId(string TableName);
        EbSite.Entity.NewsContent NewsContent_GetNext(string TableName,long Id);
        //List<EbSite.Entity.NewsContent> NewsContent_GetListHtmlNameReWrite(string sTableName, int SiteId);

    }
}

