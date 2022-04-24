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
		int ProductsImg_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool ProductsImg_Exists(int ID);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int ProductsImg_Add(Entity.ProductsImg model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void ProductsImg_Update(Entity.ProductsImg model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int ProductsImg_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void ProductsImg_Delete(int ID);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.ProductsImg ProductsImg_GetEntity(int ID);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.ProductsImg> ProductsImg_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet ProductsImg_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.ProductsImg> ProductsImg_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.ProductsImg> ProductsImg_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.ProductsImg ProductsImg_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

	    DataSet GetProductShowData(int id);
	}
}

