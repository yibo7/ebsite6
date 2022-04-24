using System;
using System.Collections.Generic;
using System.Data;
		
namespace EbSite.Modules.Shop.ModuleCore.DALInterface
{
	/// <summary>
	/// 数据访问类shop。
	/// </summary>
	public partial interface IDataProvider
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		long Buy_Orders_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Buy_Orders_Exists(int ID);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Buy_Orders_Add(Entity.Buy_Orders model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Buy_Orders_Update(Entity.Buy_Orders model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int Buy_Orders_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Buy_Orders_Delete(int ID);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.Buy_Orders Buy_Orders_GetEntity(int ID);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.Buy_Orders> Buy_Orders_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet Buy_Orders_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.Buy_Orders> Buy_Orders_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.Buy_Orders> Buy_Orders_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.Buy_Orders Buy_Orders_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="dicData">要更新的集合</param>
        /// <param name="rid">要更新的ID</param>
        bool UpdateByDic(Dictionary<string, object> dicArray, int rid);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="dicData">要更新的集合</param>
        /// <param name="rids">要更新的ID集合</param>
        bool UpdateByDic(Dictionary<string, object> dicArray, string rids);

        bool AddOrder(Entity.Buy_Orders md, ICollection<Entity.Buy_CartItem> CartItems, ICollection<Entity.Buy_CreditCartItem> CreditCartItems, int CouponItemID, List<EbSite.Entity.OrderOptionValue> lstOov, Entity.GroupBuy GroupMd, Entity.CountDownBuy RushMd, decimal Prepayments);

        Entity.Buy_Orders Buy_Orders_GetEntity(long OrderNumber);
        /// <summary>
        /// 将一个订单状态更新为已经支付状态,同时更新此订单后商品的库存里(在事务里执行)
        /// </summary>
        /// <param name="OrderID"></param>
	    void UpdateOrderPayed(string OrderID);
        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="rID"></param>
        /// <returns></returns>
        bool Buy_Orders_CloseOrder(int rID, string CloseReason);

	    #endregion 自定义方法

        #region 订单统计

        /// <summary>
        /// 统计订单数据
        /// </summary>
        /// <param name="dateType">日期类型(m:月，d:天)</param>
        /// <param name="dateVal">日期值(2013,201306)</param>
        /// <param name="fieldType">要统计的字段名称(l:交易量，e:交易额，r:利润)</param>
        /// <param name="sumCount">总数</param>
        /// <param name="maxCount">最大交易数</param>
        /// <returns></returns>
        DataTable Buy_Orders_GetOrderCount(string dateType, int dateVal, string fieldType, out int sumCount, out int maxCount);

        /// <summary>
        /// 获取总金额
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="strTotalProfit">总利润</param>
        /// <returns></returns>
        string Buy_Orders_GetTotalOrderPrice(string strWhere,out string strTotalProfit);

        /// <summary>
        /// 获取订单转化率的信息
        /// </summary>
        /// <param name="p_OrderTotalPrice">订单总额</param>
        /// <param name="p_TotalMemberQuantity">总会员数</param>
        /// <param name="p_TotalViewTimes">总访问次数</param>
        /// <param name="p_TotalOrderQuantity">总订单数量</param>
        /// <param name="p_HaveOrderMemberQuantity">下过订单的会员数量</param>
        void Buy_Orders_GetOrderConverRate(out decimal p_OrderTotalPrice,out int p_TotalMemberQuantity,out int p_TotalViewTimes,out int p_TotalOrderQuantity,out int p_HaveOrderMemberQuantity);

        /// <summary>
        /// 获取订单访问购买率
        /// </summary>
        /// <returns></returns>
        /// <param name="iTop">获取条数</param>
        DataTable Buy_Orders_GetOrderViewRate(int iTop);

        #endregion 订单统计

        #region 更新要定时更新的订单

        /// <summary>
        /// 更新在超过规定的天数内需要关闭的订单
        /// </summary>
        /// <param name="closeDays">规定的天数</param>
        /// <returns></returns>
        bool Buy_Orders_UpdateAutoCloseOrder(int closeDays);
        /// <summary>
        /// 更新在超过规定的天数内自动完成的订单
        /// </summary>
        /// <param name="finishDays">规定的天数</param>
        /// <returns></returns>
        bool Buy_Orders_UpdateAutoFinishOrder(int finishDays);

        #endregion 更新要定时更新的订单
    }
}
