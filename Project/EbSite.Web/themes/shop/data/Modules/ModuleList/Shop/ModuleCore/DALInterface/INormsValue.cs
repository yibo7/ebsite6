using System;
using System.Collections.Generic;
using System.Data;
		
namespace EbSite.Modules.Shop.ModuleCore.DALInterface
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
	public partial interface IDataProvider
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int NormsValue_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool NormsValue_Exists(int ID);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int NormsValue_Add(Entity.NormsValue model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void NormsValue_Update(Entity.NormsValue model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int NormsValue_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void NormsValue_Delete(int ID);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.NormsValue NormsValue_GetEntity(int ID);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.NormsValue> NormsValue_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet NormsValue_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.NormsValue> NormsValue_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.NormsValue> NormsValue_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.NormsValue NormsValue_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

