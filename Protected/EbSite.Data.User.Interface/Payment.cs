using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.User.Interface
{
	/// <summary>
	/// 数据访问类FSDFSF。
	/// </summary>
    public partial interface IDataProviderUser
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int Payment_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Payment_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Payment_Add(Entity.Payment model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Payment_Update(Entity.Payment model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int Payment_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Payment_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.Payment Payment_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.Payment> Payment_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet Payment_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.Payment> Payment_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.Payment> Payment_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.Payment Payment_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

