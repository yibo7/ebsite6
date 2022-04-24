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
//        int Voters_GetMaxId();

//        /// <summary>
//        /// 是否存在该记录
//        /// </summary>
//        bool Voters_Exists(int id);

//        /// <summary>
//        /// 增加一条数据
//        /// </summary>
//        int Voters_Add(Entity.Voters model);

//        /// <summary>
//        /// 更新一条数据
//        /// </summary>
//        void Voters_Update(Entity.Voters model);
		
//        /// <summary>
//        /// 获取统计
//        /// </summary>
//        int Voters_GetCount(string strWhere);

//        /// <summary>
//        /// 删除一条数据
//        /// </summary>
//        void Voters_Delete(int id);

//        /// <summary>
//        /// 得到一个对象实体
//        /// </summary>
//        Entity.Voters Voters_GetEntity(int id);

//        /// <summary>
//        /// 获得数据列表（比DataSet效率高，推荐使用）
//        /// </summary>
//        List<Entity.Voters> Voters_GetListArray(string strWhere);

//        /// <summary>
//        /// 获得前几行数据
//        /// </summary>
//        DataSet Voters_GetList(int Top,string strWhere,string filedOrder);
		
//        /// <summary>
//        /// 获得前几行数据
//        /// </summary>
//        List<Entity.Voters> Voters_GetListArray(int Top,string strWhere,string filedOrder);

//        /// <summary>
//        /// 获得分页数据
//        /// </summary>
//        List<Entity.Voters> Voters_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

//        /// <summary>
//        /// 对象实体绑定数据
//        /// </summary>
//        Entity.Voters Voters_ReaderBind(IDataReader dataReader);

//        #endregion  成员方法
//    }
//}

