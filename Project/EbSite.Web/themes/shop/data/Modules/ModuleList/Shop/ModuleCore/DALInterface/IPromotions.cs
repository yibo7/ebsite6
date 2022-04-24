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
		int Promotions_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Promotions_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Promotions_Add(Entity.Promotions model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Promotions_Update(Entity.Promotions model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int Promotions_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Promotions_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.Promotions Promotions_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.Promotions> Promotions_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet Promotions_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.Promotions> Promotions_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.Promotions> Promotions_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.Promotions Promotions_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 删除相关联的数据
        /// </summary>
        void Promotions_DeleteByType(int id,ModuleCore.BLL.EPromotionsType pType);

	    void GetActivityInfo(int RoleID, int Quantity, long ProductId, out Entity.PromotionFullNumGiveWithName pfgwn,
	                         out Entity.PromotionWholesaleWithName pwwn);

	    void GetActivityInfo(int RoleID, decimal Price, out Entity.PromotionFullPriceCutWithName pfpwn,
	                         out Entity.PromotionPriceFreeWithName ppwn);

	    List<Entity.Activities> GetShowList(int PageIndex, int PageSize, int AcivitieID, string oderby, out int RecordCount);
        #endregion 自定义方法
    }
}

