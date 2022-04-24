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
		int P_UserBook_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool P_UserBook_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int P_UserBook_Add(Entity.P_UserBook model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void P_UserBook_Update(Entity.P_UserBook model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int P_UserBook_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void P_UserBook_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.P_UserBook P_UserBook_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.P_UserBook> P_UserBook_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet P_UserBook_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.P_UserBook> P_UserBook_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.P_UserBook> P_UserBook_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.P_UserBook P_UserBook_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

