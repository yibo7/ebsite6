//using System;
//using System.Collections.Generic;
//using System.Data;
		
//namespace EbSite.Modules.BBS.ModuleCore.DALInterface
//{
//    /// <summary>
//    /// 数据访问类toupiaobt。
//    /// </summary>
//    public partial interface IDataProvider
//    {
//        #region  成员方法
//        /// <summary>
//        /// 是否存在该记录
//        /// </summary>
//        bool toupiaobt_Exists(long id);
//        /// <summary>
//        /// 增加一条数据
//        /// </summary>
//        int toupiaobt_Add(Entity.toupiaobt model);
//        /// <summary>
//        /// 更新一条数据
//        /// </summary>
//        void toupiaobt_Update(Entity.toupiaobt model);
//        /// <summary>
//        /// 删除一条数据
//        /// </summary>
//        void toupiaobt_Delete(long id);
//        /// <summary>
//        /// 得到一个对象实体
//        /// </summary>
//        Entity.toupiaobt toupiaobt_GetEntity(long id);
//        /// <summary>
//        /// 获取统计
//        /// </summary>
//        int toupiaobt_GetCount(string strWhere);
//        /// <summary>
//        /// 获得前几行数据
//        /// </summary>
//        DataSet toupiaobt_GetList(int Top, string strWhere, string filedOrder);
//        /// <summary>
//        /// 获得数据列表（比DataSet效率高，推荐使用）
//        /// </summary>
//        List<Entity.toupiaobt> toupiaobt_GetListArray(string strWhere);
//        /// <summary>
//        /// 获得前几行数据
//        /// </summary>
//        List<Entity.toupiaobt> toupiaobt_GetListArray(int Top, string strWhere, string filedOrder);
//        /// <summary>
//        /// 获得分页数据
//        /// </summary>
//        List<Entity.toupiaobt> toupiaobt_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);
//        /// <summary>
//        /// 对象实体绑定数据
//        /// </summary>
//        Entity.toupiaobt toupiaobt_ReaderBind(IDataReader dataReader);
//        #endregion  成员方法
//    }
//}

