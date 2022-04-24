using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

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
		int AccountMoneyLog_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool AccountMoneyLog_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int AccountMoneyLog_Add(Entity.AccountMoneyLog model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void AccountMoneyLog_Update(Entity.AccountMoneyLog model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int AccountMoneyLog_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void AccountMoneyLog_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.AccountMoneyLog AccountMoneyLog_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.AccountMoneyLog> AccountMoneyLog_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet AccountMoneyLog_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.AccountMoneyLog> AccountMoneyLog_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.AccountMoneyLog> AccountMoneyLog_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.AccountMoneyLog AccountMoneyLog_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

	    int AccountMoneyLog_Add(Entity.AccountMoneyLog model, DbTransaction Trans);

	    bool AccountMoney_Add(Entity.AccountMoneyLog accountMoneyMd, Entity.PayPass payModel);
	}
}

