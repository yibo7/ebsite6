//using System;
//using System.Collections.Generic;
//using System.Data;
		
//namespace EbSite.Data.Interface
//{
//	/// <summary>
//	/// 数据访问类EbSite。
//	/// </summary>
//	public partial interface IDataProviderCms
//    {
//		#region  成员方法

//		/// <summary>
//		/// 得到最大ID
//		/// </summary>
//		int ClassSetConfig_GetMaxId();

//		/// <summary>
//		/// 是否存在该记录
//		/// </summary>
//		bool ClassSetConfig_Exists(int Id);

//		/// <summary>
//		/// 增加一条数据
//		/// </summary>
//		int ClassSetConfig_Add(Entity.ClassSetConfig model);

//		/// <summary>
//		/// 更新一条数据
//		/// </summary>
//		void ClassSetConfig_Update(Entity.ClassSetConfig model);
		
//		/// <summary>
//		/// 获取统计
//		/// </summary>
//		int ClassSetConfig_GetCount(string strWhere);

//		/// <summary>
//		/// 删除一条数据
//		/// </summary>
//		void ClassSetConfig_Delete(int Id);

//		/// <summary>
//		/// 得到一个对象实体
//		/// </summary>
//		Entity.ClassSetConfig ClassSetConfig_GetEntity(int Id);

//		/// <summary>
//		/// 获得数据列表（比DataSet效率高，推荐使用）
//		/// </summary>
//		List<Entity.ClassSetConfig> ClassSetConfig_GetListArray(string strWhere);

//		/// <summary>
//		/// 获得前几行数据
//		/// </summary>
//		DataSet ClassSetConfig_GetList(int Top,string strWhere,string filedOrder);
		
//		/// <summary>
//		/// 获得前几行数据
//		/// </summary>
//		List<Entity.ClassSetConfig> ClassSetConfig_GetListArray(int Top,string strWhere,string filedOrder);

//		/// <summary>
//		/// 获得分页数据
//		/// </summary>
//		List<Entity.ClassSetConfig> ClassSetConfig_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

//		/// <summary>
//		/// 对象实体绑定数据
//		/// </summary>
//		Entity.ClassSetConfig ClassSetConfig_ReaderBind(IDataReader dataReader);

//	    void ClassSetConfig_UpdateConfigId(Entity.ClassSetConfig md);
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="ClassIds">用逗号分开</param>
//        void ClassSetConfig_DeleteByClassIds(string ClassIds);

//        #endregion  成员方法
//    }
//}

