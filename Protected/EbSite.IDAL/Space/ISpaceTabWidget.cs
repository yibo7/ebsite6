using System;
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
		int SpaceTabWidget_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool SpaceTabWidget_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int SpaceTabWidget_Add(Entity.SpaceTabWidget model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void SpaceTabWidget_Update(Entity.SpaceTabWidget model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int SpaceTabWidget_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void SpaceTabWidget_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.SpaceTabWidget SpaceTabWidget_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.SpaceTabWidget> SpaceTabWidget_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet SpaceTabWidget_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.SpaceTabWidget> SpaceTabWidget_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.SpaceTabWidget> SpaceTabWidget_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.SpaceTabWidget SpaceTabWidget_ReaderBind(IDataReader dataReader);

        void SpaceTabWidget_UpdateChange(int id, string Layout, Guid WidgetID, int OrderNum);

        bool SpaceTabWidget_Exists(int UserID, int TabID, Guid WidgetsID);

        void SpaceTabWidget_Dels(int UserID, int TabID, string WidgetsIDs);

	    #endregion  成员方法


	}
}

