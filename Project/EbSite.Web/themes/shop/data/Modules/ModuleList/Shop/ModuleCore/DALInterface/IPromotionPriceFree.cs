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
		int PromotionPriceFree_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool PromotionPriceFree_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int PromotionPriceFree_Add(Entity.PromotionPriceFree model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void PromotionPriceFree_Update(Entity.PromotionPriceFree model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int PromotionPriceFree_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void PromotionPriceFree_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.PromotionPriceFree PromotionPriceFree_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.PromotionPriceFree> PromotionPriceFree_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet PromotionPriceFree_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.PromotionPriceFree> PromotionPriceFree_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.PromotionPriceFree> PromotionPriceFree_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.PromotionPriceFree PromotionPriceFree_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.PromotionPriceFree PromotionPriceFree_GetEntity(string strWhere);

        #endregion 自定义方法
	}
}

