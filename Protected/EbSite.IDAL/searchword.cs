using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类a。
	/// </summary>
    public partial interface IDataProviderCms
	{
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool searchword_Exists(Guid id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		void searchword_Add(Entity.searchword model);
        void searchword_Add(string keyword);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void searchword_Update(Entity.searchword model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int searchword_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void searchword_Delete(Guid id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.searchword searchword_GetEntity(Guid id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.searchword> searchword_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet searchword_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.searchword> searchword_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.searchword> searchword_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.searchword searchword_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

	    void searchword_DeleteALL();
	}
}

