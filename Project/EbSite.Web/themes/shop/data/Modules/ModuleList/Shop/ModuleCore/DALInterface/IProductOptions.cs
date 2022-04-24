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
		int ProductOptions_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool ProductOptions_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int ProductOptions_Add(Entity.ProductOptions model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void ProductOptions_Update(Entity.ProductOptions model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int ProductOptions_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void ProductOptions_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.ProductOptions ProductOptions_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.ProductOptions> ProductOptions_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet ProductOptions_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.ProductOptions> ProductOptions_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.ProductOptions> ProductOptions_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.ProductOptions ProductOptions_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        #region 自定义方法

        bool ProductOptions_DeleteProductOption(long productID);

        #endregion 自定义方法
    }
}

