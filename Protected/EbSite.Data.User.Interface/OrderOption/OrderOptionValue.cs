using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace EbSite.Data.User.Interface
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
    public partial interface IDataProviderUser
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int OrderOptionValue_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool OrderOptionValue_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int OrderOptionValue_Add(Entity.OrderOptionValue model);

        int OrderOptionValue_Add(Entity.OrderOptionValue model, DbTransaction Trans);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void OrderOptionValue_Update(Entity.OrderOptionValue model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int OrderOptionValue_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void OrderOptionValue_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.OrderOptionValue OrderOptionValue_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.OrderOptionValue> OrderOptionValue_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet OrderOptionValue_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.OrderOptionValue> OrderOptionValue_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.OrderOptionValue> OrderOptionValue_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.OrderOptionValue OrderOptionValue_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

