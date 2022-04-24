using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类b。
	/// </summary>
    public partial interface IDataProviderCms
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int outlinks_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool outlinks_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int outlinks_Add(Entity.outlinks model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void outlinks_Update(Entity.outlinks model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int outlinks_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void outlinks_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.outlinks outlinks_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.outlinks> outlinks_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet outlinks_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.outlinks> outlinks_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.outlinks> outlinks_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.outlinks outlinks_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

