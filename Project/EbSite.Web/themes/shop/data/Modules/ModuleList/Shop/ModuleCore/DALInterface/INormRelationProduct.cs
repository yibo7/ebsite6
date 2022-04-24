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
		int NormRelationProduct_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool NormRelationProduct_Exists(int ID);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int NormRelationProduct_Add(Entity.NormRelationProduct model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void NormRelationProduct_Update(Entity.NormRelationProduct model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int NormRelationProduct_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void NormRelationProduct_Delete(int ID);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.NormRelationProduct NormRelationProduct_GetEntity(int ID);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.NormRelationProduct> NormRelationProduct_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet NormRelationProduct_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.NormRelationProduct> NormRelationProduct_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.NormRelationProduct> NormRelationProduct_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.NormRelationProduct NormRelationProduct_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.NormRelationProduct NormRelationProduct_GetEntityByNormID(string ID);

        List<Entity.NormRelationProduct> NormRelationProduct_UnionGetListPages(int PageIndex, int PageSize, out int RecordCount, string strWhere);

        bool NormRelationProduct_UpdateStocks(int id, int stocks,ModuleCore.Entity.productlog md);

        bool NormRelationProduct_UpdateStocksNoNorms(int productID,int stocks,ModuleCore.Entity.productlog md);
	}
}

