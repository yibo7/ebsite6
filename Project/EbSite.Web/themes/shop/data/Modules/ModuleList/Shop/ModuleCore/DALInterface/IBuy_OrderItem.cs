using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

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
        int Buy_OrderItem_GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Buy_OrderItem_Exists(int id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Buy_OrderItem_Add(Entity.Buy_OrderItem model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Buy_OrderItem_Update(Entity.Buy_OrderItem model);

        /// <summary>
        /// 获取统计
        /// </summary>
        int Buy_OrderItem_GetCount(string strWhere);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Buy_OrderItem_Delete(int id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.Buy_OrderItem Buy_OrderItem_GetEntity(int id);

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        List<Entity.Buy_OrderItem> Buy_OrderItem_GetListArray(string strWhere);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet Buy_OrderItem_GetList(int Top, string strWhere, string filedOrder);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        List<Entity.Buy_OrderItem> Buy_OrderItem_GetListArray(int Top, string strWhere, string filedOrder);

        /// <summary>
        /// 获得分页数据
        /// </summary>
        List<Entity.Buy_OrderItem> Buy_OrderItem_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount);

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        Entity.Buy_OrderItem Buy_OrderItem_ReaderBind(IDataReader dataReader);

        //void DeleteByUniqueID(int UniqueID);
        //List<Entity.Buy_OrderItem> GetCartItems(int uniqueID, string applicationName);
        #endregion  成员方法

        #region 自定义方法

        int Buy_OrderItem_Add(Entity.Buy_OrderItem model, MySqlTransaction Trans);
        ///// <summary>
        ///// 修改订单商品信息
        ///// </summary>
        ///// <param name="dicArray">要修改的字段集合</param>
        ///// <param name="tid">ID</param>
        ///// <returns></returns>
        //bool UpdateByDic_OrderItems(Dictionary<string,object> dicArray,int tid);
        ///// <summary>
        ///// 修改订单商品价格
        ///// </summary>
        ///// <param name="dicArray">要修改的订单商品字段集合</param>
        ///// <param name="dicArrayOrder">要修改的订单字段集合</param>
        ///// <param name="tid">订单商品ID</param>
        ///// <param name="rid">订单ID</param>
        ///// <returns></returns>
        //bool UpdateByDic_OrderItems(Dictionary<string, object> dicArray,Dictionary<string,object> dicArrayOrder,int tid,int rid);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="dicData">要更新的集合</param>
        /// <param name="rid">ID</param>
        bool Buy_OrderItem_UpdateByDic(Dictionary<string, object> dicArray, int id);
        /// <summary>
        /// 修改订单商品价格
        /// </summary>
        /// <param name="dicArray">要修改的订单商品字段集合</param>
        /// <param name="dicArrayOrder">要修改的订单字段集合</param>
        /// <param name="tid">订单商品ID</param>
        /// <param name="rid">订单ID</param>
        /// <returns></returns>
        bool UpdateByDic_OrderItems(Dictionary<string, object> dicArray, Dictionary<string, object> dicArrayOrder, int tid, int rid);
        /// <summary>
        /// 获取指定用户的退换货列表
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        DataTable Buy_OrderItem_GetTHOrderItemList(int uid);
        /// <summary>
        /// 获取退换货列表
        /// </summary>
        /// <returns></returns>
        DataTable Buy_OrderItem_GetTHOrderItemList();


        List<Entity.Buy_OrderItem> Buy_OrderItem_GetTHOrderItem_GetListPages(int PageIndex, int PageSize,
                                                                             out int RecordCount, string orderid);

        List<Entity.Buy_OrderItem> Buy_OrderItem_GetTHOrderItem_GetListPages(int uid, int PageIndex, int PageSize,
                                                                             out int RecordCount);
        /// <summary>
        /// 获取商品销售排行
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="itop">前几条</param>
        /// <returns></returns>
        DataTable Buy_OrderItem_GetSaleTop(string strWhere,int itop);

        #endregion 自定义方法
    }
}

