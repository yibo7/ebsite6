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
		int buy_orderlog_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool buy_orderlog_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int buy_orderlog_Add(Entity.buy_orderlog model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void buy_orderlog_Update(Entity.buy_orderlog model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int buy_orderlog_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void buy_orderlog_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.buy_orderlog buy_orderlog_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.buy_orderlog> buy_orderlog_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet buy_orderlog_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.buy_orderlog> buy_orderlog_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.buy_orderlog> buy_orderlog_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.buy_orderlog buy_orderlog_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="orderID">订单号</param>
        /// <param name="logMsg">日志内容</param>
        /// <param name="uid">用户ID</param>
        /// <param name="uname">用户姓名</param>
        /// <param name="orderShowType">日志类型</param>
        /// <returns></returns>
        int buy_orderlog_Add(string orderID,string logMsg,int uid,string uname,SystemEnum.OrderLogType orderShowType);

        #endregion 自定义方法
    }
}

