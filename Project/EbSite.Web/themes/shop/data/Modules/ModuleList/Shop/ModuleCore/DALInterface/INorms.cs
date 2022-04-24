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
		int Norms_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Norms_Exists(int ID);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Norms_Add(Entity.Norms model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Norms_Update(Entity.Norms model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int Norms_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Norms_Delete(int ID);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.Norms Norms_GetEntity(int ID);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.Norms> Norms_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet Norms_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.Norms> Norms_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.Norms> Norms_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.Norms Norms_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

