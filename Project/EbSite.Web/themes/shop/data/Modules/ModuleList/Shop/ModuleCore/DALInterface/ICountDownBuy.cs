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
		int CountDownBuy_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool CountDownBuy_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int CountDownBuy_Add(Entity.CountDownBuy model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void CountDownBuy_Update(Entity.CountDownBuy model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int CountDownBuy_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void CountDownBuy_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.CountDownBuy CountDownBuy_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.CountDownBuy> CountDownBuy_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet CountDownBuy_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.CountDownBuy> CountDownBuy_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.CountDownBuy> CountDownBuy_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.CountDownBuy CountDownBuy_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        /// <summary>
        /// 定时更新抢购状态
        /// </summary>
        /// <returns></returns>
        bool CountDownBuy_UpdateStatus();
	}
}

