using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Modules.Shop.ModuleCore.DALInterface
{
	/// <summary>
	/// 数据访问类369369。
	/// </summary>
	public partial interface IDataProvider
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int P_BestGroup_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool P_BestGroup_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int P_BestGroup_Add(Entity.P_BestGroup model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void P_BestGroup_Update(Entity.P_BestGroup model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int P_BestGroup_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void P_BestGroup_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.P_BestGroup P_BestGroup_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.P_BestGroup> P_BestGroup_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet P_BestGroup_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.P_BestGroup> P_BestGroup_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.P_BestGroup> P_BestGroup_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.P_BestGroup P_BestGroup_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

