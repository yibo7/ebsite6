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
		int PromotionFullNumGive_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool PromotionFullNumGive_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int PromotionFullNumGive_Add(Entity.PromotionFullNumGive model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void PromotionFullNumGive_Update(Entity.PromotionFullNumGive model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int PromotionFullNumGive_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void PromotionFullNumGive_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.PromotionFullNumGive PromotionFullNumGive_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.PromotionFullNumGive> PromotionFullNumGive_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet PromotionFullNumGive_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.PromotionFullNumGive> PromotionFullNumGive_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.PromotionFullNumGive> PromotionFullNumGive_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.PromotionFullNumGive PromotionFullNumGive_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.PromotionFullNumGive PromotionFullNumGive_GetEntity(string strWhere);

        #endregion 自定义方法
	}
}

