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
        int Buy_CartItem_GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Buy_CartItem_Exists(int id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Buy_CartItem_Add(Entity.Buy_CartItem model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Buy_CartItem_Update(Entity.Buy_CartItem model);

        /// <summary>
        /// 获取统计
        /// </summary>
        int Buy_CartItem_GetCount(string strWhere);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Buy_CartItem_Delete(int id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.Buy_CartItem Buy_CartItem_GetEntity(int id);

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        List<Entity.Buy_CartItem> Buy_CartItem_GetListArray(string strWhere);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet Buy_CartItem_GetList(int Top, string strWhere, string filedOrder);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        List<Entity.Buy_CartItem> Buy_CartItem_GetListArray(int Top, string strWhere, string filedOrder);

        /// <summary>
        /// 获得分页数据
        /// </summary>
        List<Entity.Buy_CartItem> Buy_CartItem_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount);

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        Entity.Buy_CartItem Buy_CartItem_ReaderBind(IDataReader dataReader);

        void DeleteByUniqueID(int UniqueID);
        List<Entity.Buy_CartItem> GetCartItems(int uniqueID, string applicationName);
        #endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 修改订单商品信息
        /// </summary>
        /// <param name="dicArray">要修改的字段集合</param>
        /// <param name="tid">ID</param>
        /// <returns></returns>
        bool UpdateByDic_OrderItems(Dictionary<string,object> dicArray,int tid);
       

        #endregion 自定义方法
    }
}

