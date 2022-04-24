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
		int PromotionProduct_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool PromotionProduct_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int PromotionProduct_Add(Entity.PromotionProduct model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void PromotionProduct_Update(Entity.PromotionProduct model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int PromotionProduct_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void PromotionProduct_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.PromotionProduct PromotionProduct_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.PromotionProduct> PromotionProduct_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet PromotionProduct_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.PromotionProduct> PromotionProduct_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.PromotionProduct> PromotionProduct_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.PromotionProduct PromotionProduct_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool PromotionProduct_Delete(int promotionID,int productID);
        bool PromotionProduct_ExistsProductID(int ProductID);
        bool PromotionProduct_ExistsProductAndPromotionsID(int ProductID, int PromotionsID);
        #endregion 自定义方法
    }
}

