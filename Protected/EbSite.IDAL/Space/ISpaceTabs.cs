using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
		
namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类EbSitePlace。
	/// </summary>
    public partial interface IDataProviderCms
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int SpaceTabs_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool SpaceTabs_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int SpaceTabs_Add(Entity.SpaceTabs model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void SpaceTabs_Update(Entity.SpaceTabs model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int SpaceTabs_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void SpaceTabs_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.SpaceTabs SpaceTabs_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.SpaceTabs> SpaceTabs_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet SpaceTabs_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.SpaceTabs> SpaceTabs_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.SpaceTabs> SpaceTabs_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.SpaceTabs SpaceTabs_ReaderBind(IDataReader dataReader);

        string SpaceTabs_GetLayoutName(int id);

		#endregion  成员方法
        int SpaceTabs_GetMaxOrderID(int UserId);
        void SpaceTabs_UpdateOrders(int UserId, Hashtable ht);

	    /// <summary>
	    /// 更改版式
	    /// </summary>
	    /// <param name="TabID">当前标签ID</param>
	    /// <param name="LayoutName">版式英文名称</param>
        void SpaceTabs_UpdateLayout(int UserID, int TabID, string LayoutName);
        int SpaceTabs_GetTabIDFormMark(int ParentID,string Mark);
	}
}

