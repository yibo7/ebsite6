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
		/// 得到最大ID
		/// </summary>
		int order_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool order_Exists(long id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int order_Add(Entity.order model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void order_Update(Entity.order model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int order_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void order_Delete(long id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.order order_GetEntity(long id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.order> order_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet order_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.order> order_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.order> order_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.order order_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

