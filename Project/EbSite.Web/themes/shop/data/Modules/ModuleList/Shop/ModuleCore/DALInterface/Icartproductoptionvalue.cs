using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

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
		int cartproductoptionvalue_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool cartproductoptionvalue_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int cartproductoptionvalue_Add(Entity.cartproductoptionvalue model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void cartproductoptionvalue_Update(Entity.cartproductoptionvalue model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int cartproductoptionvalue_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void cartproductoptionvalue_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.cartproductoptionvalue cartproductoptionvalue_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.cartproductoptionvalue> cartproductoptionvalue_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet cartproductoptionvalue_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.cartproductoptionvalue> cartproductoptionvalue_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.cartproductoptionvalue> cartproductoptionvalue_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.cartproductoptionvalue cartproductoptionvalue_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        int cartproductoptionvalue_Add(Entity.cartproductoptionvalue model,MySqlTransaction Trans);
	}
}

