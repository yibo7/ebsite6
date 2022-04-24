using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类TagRelateClass。
	/// </summary>
    public partial interface IDataProviderCms
	{
		#region  成员方法
      
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool TagRelateClass_Exists(long id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int TagRelateClass_Add(Entity.TagRelateClass model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void TagRelateClass_Update(Entity.TagRelateClass model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void TagRelateClass_Delete(long id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.TagRelateClass TagRelateClass_GetEntity(long id);
		/// <summary>
		/// 获取统计
		/// </summary>
		int TagRelateClass_GetCount(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet TagRelateClass_GetList(int Top, string strWhere, string filedOrder);
		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
        //List<Entity.TagRelateClass> TagRelateClass_GetListArray(string strWhere);
        ///// <summary>
        ///// 获得前几行数据
        ///// </summary>
        //List<Entity.TagRelateClass> TagRelateClass_GetListArray(int Top, string strWhere, string filedOrder);
        ///// <summary>
        ///// 获得分页数据
        ///// </summary>
        //List<Entity.TagRelateClass> TagRelateClass_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);
        ///// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.TagRelateClass TagRelateClass_ReaderBind(IDataReader dataReader);

        void TagRelateClass_DeleteByRemove(string ReserveIDs, int iClassID);
		#endregion  成员方法
	}
}

