//using System;
//using System.Collections.Generic;
//using System.Data;
		
//namespace EbSite.Modules.BBS.ModuleCore.DALInterface
//{
//    /// <summary>
//    /// 数据访问类BBS。
//    /// </summary>
//    public partial interface IDataProvider
//    {
//        #region  成员方法

//        /// <summary>
//        /// 得到最大ID
//        /// </summary>
//        long Topics_GetMaxId();

//        /// <summary>
//        /// 是否存在该记录
//        /// </summary>
//        bool Topics_Exists(long id);

//        /// <summary>
//        /// 增加一条数据
//        /// </summary>
//        long Topics_Add(Entity.Topics model);

//        /// <summary>
//        /// 更新一条数据
//        /// </summary>
//        void Topics_Update(Entity.Topics model);
		
//        /// <summary>
//        /// 获取统计
//        /// </summary>
//        int Topics_GetCount(string strWhere);

//        /// <summary>
//        /// 删除一条数据
//        /// </summary>
//        void Topics_Delete(long id);

//        /// <summary>
//        /// 得到一个对象实体
//        /// </summary>
//        Entity.Topics Topics_GetEntity(long id);

//        /// <summary>
//        /// 获得数据列表（比DataSet效率高，推荐使用）
//        /// </summary>
//        List<Entity.Topics> Topics_GetListArray(string strWhere);

//        /// <summary>
//        /// 获得前几行数据
//        /// </summary>
//        DataSet Topics_GetList(int Top,string strWhere,string filedOrder);
		
//        /// <summary>
//        /// 获得前几行数据
//        /// </summary>
//        List<Entity.Topics> Topics_GetListArray(int Top,string strWhere,string filedOrder);

//        /// <summary>
//        /// 获得分页数据
//        /// </summary>
//        List<Entity.Topics> Topics_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

//        /// <summary>
//        /// 对象实体绑定数据
//        /// </summary>
//        Entity.Topics Topics_ReaderBind(IDataReader dataReader);

//        #endregion  成员方法
//    }
//}

