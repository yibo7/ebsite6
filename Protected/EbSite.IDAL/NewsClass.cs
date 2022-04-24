
using System;
using System.Collections.Generic;
using System.Data;
//请先添加引用
namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类NewsClass。
	/// </summary>
	public partial interface IDataProviderCms
	{
		#region  成员方法

	    /// <summary>
	    /// 得到最大ID
	    /// </summary>
        int NewsClass_GetMaxId();

	    /// <summary>
	    /// 是否存在该记录
	    /// </summary>
        bool NewsClass_Exists(int ID);
        int NewsClass_Add(EbSite.Entity.NewsClass model);

	    /// <summary>
	    /// 更新一条数据
	    /// </summary>
        void NewsClass_Update(EbSite.Entity.NewsClass model);

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs">ID列表，用逗号分开</param>
        void NewsClass_Delete(string IDs);

       ///// <summary>
       // /// 删除一条数据
       ///// </summary>
       ///// <param name="ID">当前分类ID</param>
       // /// <param name="SubIds">子分类ID列表，用逗号分开</param>
       // void NewsClass_Delete(int ID);

	    
	    /// <summary>
	    /// 将相关配置更新当前分类的子分类
	    /// </summary>
	    /// <param name="Parent">当前分类（父）</param>
	    /// <param name="sSubIDs">当前分类的子分类ID，用逗号分开</param>
	    /// <param name="Type">类别，1代表分类的命名规则，2代表内容的命名规则,3子类内容模型,4代表分类模板，5代表内容模板</param>
        //void NewsClass_UpdateConfigsToSub(EbSite.Entity.NewsClass Parent, int Type, string sSubIDs);

	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
        EbSite.Entity.NewsClass NewsClass_GetModel(int ID);

	   
	    /// <summary>
	    /// 获得数据列表（比DataSet效率高，推荐使用）
	    /// </summary>
        List<EbSite.Entity.NewsClass> NewsClass_GetListArray(string strWhere,int SiteID);

	    /// <summary>
	    /// 获取总记录条数
	    /// </summary>
	    /// <returns></returns>
        int NewsClass_GetCount(string strWhere,int SiteID);

	    /// <summary>
	    /// 分页获取数据列表
	    /// </summary>
        List<EbSite.Entity.NewsClass> NewsClass_GetListPages(int startRowIndex, int maxinmumRows, string strWhere, string oderby, int SiteID);
        List<EbSite.Entity.NewsClass> NewsClass_GetListHtmlNameReWrite();
	    /// <summary>
	    /// 获得数据列表（比DataSet效率高，推荐使用）
	    /// </summary>
        List<EbSite.Entity.NewsClass> NewsClass_GetListArray(string strWhere, int iTop, string OrderBy, int SiteID);

	    List<EbSite.Entity.NewsClass> NewsClass_GetListArray(string sField, string strWhere, int iTop, string OrderBy,
	                                                         int SiteID);

	    /// <summary>
	    /// 对象实体绑定数据
	    /// </summary>
        EbSite.Entity.NewsClass NewsClass_ReaderBind(IDataReader dataReader);

	    /// <summary>
	    /// 获取最大排序ID
	    /// </summary>
	    /// <returns></returns>
        int NewsClass_GetMaxOrderID(int iParentClassID, int SiteID);
        ///// <summary>
        ///// 向上移
        ///// </summary>
        ///// <returns></returns>
        //void NewsClass_UpClassOrderID(int classid);

        ///// <summary>
        ///// 向下移
        ///// </summary>
        ///// <returns></returns>
        //void NewsClass_DownClassOrderID(int classid);

        /// <summary>
        /// 删除分类时要更新比当前分类排序ID大的orderid - 1
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        void NewsClass_DeleteClassUpdateOrderID(int OrderID,int ParentID,int SiteID);


	    void NewsClass_UpdateCommentNum(int iID, int iNum);
	    void NewsClass_UpdateFavorableNum(int iID, int iNum);
	    void NewsClass_AddHits(int iID, int iNum);
	    void NewsClass_ResetHits(string Interval);

        //void NewsClass_ToDefault(EbSite.Entity.NewsClass md);
        void NewsClass_InitNum(int itype);
	    List<int> NewsClass_GetSubID(int iParentID);
        void NewsClass_UpdateOrderID(int iClassID, int iValue, int SiteID);

	    List<EbSite.Entity.NewsClass> GetClassInIDs(string IDs,int SiteID);
        /// <summary>
        /// 重置分类模型或模板
        /// </summary>
        /// <param name="iClassID"></param>
        /// <param name="ClassTempID"></param>
        /// <param name="ClassModelID"></param>
        /// <param name="IsUpdateToSub"></param>
        //void UpdateConfigsofClassAndSub(int iClassID, Guid ClassTempID, Guid ClassModelID, Guid ContentModelID, Guid ContentTemID, bool IsUpdateToSub, int SiteID);
        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="SoureClassID">源分类ID</param>
        /// <param name="TargetClassID">目标分类ID</param>
        /// <param name="IsAsChildnode">是否作为作为目标分类的子分类</param>
        /// <returns></returns>
        void NewsClass_Move(int SoureClassID, int TargetClassID, bool IsAsChildnode,int SiteID);
        /// <summary>
        /// 获取某个记录上级父集合
        /// </summary>
        /// <param name="ClassID">当前记录的ParentID</param>
        /// <returns></returns>
        List<EbSite.Entity.NewsClass> GetParents(int ClassID, string OrderBy);
        //List<EbSite.Entity.NewsClass> GetParents(string sFiles, int ParentID);

        ///// <summary>
        ///// 获取某个分类的父对象
        ///// </summary>
        ///// <param name="SubID"></param>
        ///// <returns></returns>
        //EbSite.Entity.NewsClass GetParentBySub(int SubID);

        EbSite.Entity.NewsClass NewsClass_GetModel(string sField, string strWhere);

	    #endregion  成员方法

        Guid NewsClass_TemID(int ClassID);
         void NewsClass_Update(string Where, string Col, string sValue);

	    void SetSubSiteToMainUpdateSiteID(int MainSiteID, int SubSiteID);

        
       void DeleteNewsClassOutSiteData(string siteids);

       List<EbSite.Entity.NewsClass> NewsClassGetSubIDs(int ParentID, int SiteID, out string SubIDs);

        List<EbSite.Entity.NewsClass> NewsClass_ModelIDGetListPages(int PageIndex, int PageSize, string sWhere,
                                                                    string oderby, int SiteID, out int RecordCount, Guid ClassModelId
                                                                   );

        List<EbSite.Entity.NewsClass> NewsClass_ModelIDGetListArray(string sField, string strWhere, int iTop,
	                                                                string OrderBy, int SiteID,Guid ClassModelId);

        List<int> GetChildIDClass(int ParentID, int SiteID);
       List<Entity.NewsClass> GetChildClass(int ParentID, int SiteID);
        List<EbSite.Entity.NewsClass> NewsClass_GetListArrayFormConfigId(int iConfigId);

        List<EbSite.Entity.NewsClass> NewsClass_GetNotConfig(string sWhere);

    }
}

