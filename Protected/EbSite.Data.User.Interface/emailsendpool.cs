using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.User.Interface
{
	/// <summary>
	/// 数据访问类aaa。
	/// </summary>
    public partial interface IDataProviderUser
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int emailsendpool_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool emailsendpool_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int emailsendpool_Add(Entity.emailsendpool model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void emailsendpool_Update(Entity.emailsendpool model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int emailsendpool_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void emailsendpool_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.emailsendpool emailsendpool_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.emailsendpool> emailsendpool_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet emailsendpool_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.emailsendpool> emailsendpool_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.emailsendpool> emailsendpool_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.emailsendpool emailsendpool_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

