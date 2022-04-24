using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
//请先添加引用
namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类SpecialClass。
	/// </summary>
    public partial interface IDataProviderCms
	{
		
		#region  成员方法

	    /// <summary>
	    /// 得到最大ID
	    /// </summary>
        int SpecialClass_GetMaxId();

	    /// <summary>
	    /// 获取总记录条数
	    /// </summary>
	    /// <returns></returns>
        int SpecialClass_GetCount(string strWhere,int SiteID);

	    /// <summary>
	    /// 是否存在该记录
	    /// </summary>
        bool SpecialClass_Exists(int id);


	    /// <summary>
	    /// 增加一条数据
	    /// </summary>
        int SpecialClass_Add(EbSite.Entity.SpecialClass model);

	    /// <summary>
	    /// 更新一条数据
	    /// </summary>
        void SpecialClass_Update(EbSite.Entity.SpecialClass model);

	  /// <summary>
	  /// 批量删除，用逗号分开ID
	  /// </summary>
	  /// <param name="ids"></param>
        void SpecialClass_Delete(string ids);

	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
        EbSite.Entity.SpecialClass SpecialClass_GetModel(int id);

	    /// <summary>
	    /// 获得数据列表（比DataSet效率高，推荐使用）
	    /// </summary>
        List<EbSite.Entity.SpecialClass> SpecialClass_GetListArray(string strWhere, int SiteID);
       
	    /// <summary>
	    /// 获得数据列表（比DataSet效率高，推荐使用）
	    /// </summary>
        List<EbSite.Entity.SpecialClass> SpecialClass_GetListArray(string strWhere, int iTop, string sOderby, int SiteID);

	    List<EbSite.Entity.SpecialClass> SpecialClass_GetListPages(int PageIndex, int PageSize, string strWhere,
                                                                   string oderby, int SiteID);
	    /// <summary>
	    /// 对象实体绑定数据
	    /// </summary>
	     EbSite.Entity.SpecialClass SpecialClass_ReaderBind(IDataReader dataReader);
        /// <summary>
        /// 移动专题
        /// </summary>
        /// <param name="SoureClassID"></param>
        /// <param name="TargetClassID"></param>
        /// <param name="IsAsChildnode"></param>
         void SpecialClass_Move(int SoureClassID, int TargetClassID, bool IsAsChildnode, int SiteID);

         int SpecialClass_GetMaxOrderID(int ParentID, int SiteID);

         /// <summary>
         /// 删除分类时要更新比当前分类排序ID大的orderid - 1
         /// </summary>
         /// <param name="OrderID"></param>
         /// <returns></returns>
         void SpecialClass_DeleteClassUpdateOrderID(int OrderID, int ParentID, int SiteID);

         void SpecialClass_UpdateOrderID(int iSpecailID, int iValue, int SiteID);
        List<int> SpecialClass_GetSubID(int iParentID);

		#endregion  成员方法
        /// <summary>
        /// 通过存储过程 调取向上的递归父类
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="OrderBy"></param>
        /// <returns></returns>
        List<EbSite.Entity.SpecialClass> SpecialClass_GetParents(int cid, string OrderBy);
        /// <summary>
        /// 获取下内容相关的专题
        /// </summary>
        /// <param name="ContentId"></param>
        /// <param name="ClassId"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        List<EbSite.Entity.SpecialClass> SpecialClass_GetListByContentId(long ContentId,int ClassId,int Top);


        void SpecialClass_Update(string Where, string Col, string sValue);
        List<EbSite.Entity.SpecialClass> SpecialClass_GetListHtmlNameReWrite();

	    List<EbSite.Entity.SpecialClass> SpecialClass_GetListArray(string strWhere, int iTop, string sOderby);

	}
}

