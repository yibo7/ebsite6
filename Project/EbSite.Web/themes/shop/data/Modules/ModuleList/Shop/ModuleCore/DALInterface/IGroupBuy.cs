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
		int GroupBuy_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool GroupBuy_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int GroupBuy_Add(Entity.GroupBuy model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void GroupBuy_Update(Entity.GroupBuy model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="Status">团购状态</param>
        /// <param name="id">团购ID</param>
        void GroupBuy_Update(int Status,int id);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int GroupBuy_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void GroupBuy_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.GroupBuy GroupBuy_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.GroupBuy> GroupBuy_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GroupBuy_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.GroupBuy> GroupBuy_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.GroupBuy> GroupBuy_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.GroupBuy GroupBuy_ReaderBind(IDataReader dataReader);

        /// <summary>
        /// 获取团购数量
        /// </summary>
        /// <param name="strWhere">团购ID</param>
        /// <returns></returns>
        int GroupBuy_GetOrderCount(int groupID);

		#endregion  成员方法

        #region 定时更新团购状态

        /// <summary>
        /// 定时更新团购状态
        /// </summary>
        /// <returns></returns>
        bool GroupBuy_UpdateStatus();

        #endregion 定时更新团购状态

    }
}

