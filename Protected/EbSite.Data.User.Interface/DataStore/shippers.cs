using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.User.Interface
{
    /// <summary>
    /// 数据访问类qq。
    /// </summary>
    public partial interface IDataProviderUser
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int shippers_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool shippers_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int shippers_Add(Entity.Shippers model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void shippers_Update(Entity.Shippers model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int shippers_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void shippers_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.Shippers shippers_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.Shippers> shippers_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet shippers_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.Shippers> shippers_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.Shippers> shippers_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.Shippers shippers_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

