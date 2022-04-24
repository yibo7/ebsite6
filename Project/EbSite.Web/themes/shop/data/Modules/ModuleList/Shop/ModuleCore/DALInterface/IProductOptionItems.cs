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
		int ProductOptionItems_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool ProductOptionItems_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int ProductOptionItems_Add(Entity.ProductOptionItems model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void ProductOptionItems_Update(Entity.ProductOptionItems model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int ProductOptionItems_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void ProductOptionItems_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.ProductOptionItems ProductOptionItems_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.ProductOptionItems> ProductOptionItems_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet ProductOptionItems_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.ProductOptionItems> ProductOptionItems_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.ProductOptionItems> ProductOptionItems_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.ProductOptionItems ProductOptionItems_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        List<Entity.ProductOptionItems> ProductOptionItems_GetListArrayInIDs(string IDs);

	    int ProductOptionItems_Add(Entity.ProductOptionItems model, MySqlTransaction Trans);

	    List<Entity.ProductOptionItems> ProductOptionItems_GetListArrayByProductID(int ProductID);
	}
}

