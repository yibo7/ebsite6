using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Modules.Wenda.ModuleCore.DALInterface
{
	/// <summary>
	/// 数据访问类bb。
	/// </summary>
	public partial interface IDataProvider
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int SameQuestion_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool SameQuestion_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int SameQuestion_Add(Entity.SameQuestion model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void SameQuestion_Update(Entity.SameQuestion model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int SameQuestion_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void SameQuestion_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.SameQuestion SameQuestion_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.SameQuestion> SameQuestion_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet SameQuestion_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.SameQuestion> SameQuestion_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.SameQuestion> SameQuestion_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.SameQuestion SameQuestion_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

