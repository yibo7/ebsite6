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
//        int VoteOptions_GetMaxId();

//        /// <summary>
//        /// 是否存在该记录
//        /// </summary>
//        bool VoteOptions_Exists(int id);

//        /// <summary>
//        /// 增加一条数据
//        /// </summary>
//        int VoteOptions_Add(Entity.VoteOptions model);

//        /// <summary>
//        /// 更新一条数据
//        /// </summary>
//        void VoteOptions_Update(Entity.VoteOptions model);
		
//        /// <summary>
//        /// 获取统计
//        /// </summary>
//        int VoteOptions_GetCount(string strWhere);

//        /// <summary>
//        /// 删除一条数据
//        /// </summary>
//        void VoteOptions_Delete(int id);

//        /// <summary>
//        /// 得到一个对象实体
//        /// </summary>
//        Entity.VoteOptions VoteOptions_GetEntity(int id);

//        /// <summary>
//        /// 获得数据列表（比DataSet效率高，推荐使用）
//        /// </summary>
//        List<Entity.VoteOptions> VoteOptions_GetListArray(string strWhere);

//        /// <summary>
//        /// 获得前几行数据
//        /// </summary>
//        DataSet VoteOptions_GetList(int Top,string strWhere,string filedOrder);
		
//        /// <summary>
//        /// 获得前几行数据
//        /// </summary>
//        List<Entity.VoteOptions> VoteOptions_GetListArray(int Top,string strWhere,string filedOrder);

//        /// <summary>
//        /// 获得分页数据
//        /// </summary>
//        List<Entity.VoteOptions> VoteOptions_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

//        /// <summary>
//        /// 对象实体绑定数据
//        /// </summary>
//        Entity.VoteOptions VoteOptions_ReaderBind(IDataReader dataReader);

//        #endregion  成员方法
//    }
//}

