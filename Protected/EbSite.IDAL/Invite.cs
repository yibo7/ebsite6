using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类a。
	/// </summary>
    public partial interface IDataProviderCms
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int Invite_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Invite_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Invite_Add(Entity.Invite model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
        void Invite_Update(Entity.Invite model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int Invite_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Invite_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Entity.Invite Invite_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.Invite> Invite_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet Invite_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.Invite> Invite_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.Invite> Invite_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.Invite Invite_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

