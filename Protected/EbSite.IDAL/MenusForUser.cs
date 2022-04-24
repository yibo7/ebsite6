using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类MenusForUser。
	/// </summary>
    public partial interface IDataProviderCms
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool MenusForUser_Exists(Guid id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
        void MenusForUser_Add(Entity.MenusForUser model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void MenusForUser_Update(Entity.MenusForUser model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
        void MenusForUser_Delete(Guid id);
        void MenusForUser_DeleteByModulID(Guid mid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Entity.MenusForUser MenusForUser_GetEntity(Guid id);
		/// <summary>
		/// 获取统计
		/// </summary>
		int MenusForUser_GetCount(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet MenusForUser_GetList(int Top, string strWhere, string filedOrder);
		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.MenusForUser> MenusForUser_GetListArray(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.MenusForUser> MenusForUser_GetListArray(int Top, string strWhere, string filedOrder);
		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.MenusForUser> MenusForUser_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);
		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.MenusForUser MenusForUser_ReaderBind(IDataReader dataReader);
        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="SoureClassID">源分类ID</param>
        /// <param name="TargetClassID">目标分类ID</param>
        /// <param name="IsAsChildnode">是否作为作为目标分类的子分类</param>
        /// <returns></returns>
        void MenusForUser_Move(Guid SoureClassID, Guid TargetClassID, bool IsAsChildnode);

        int MenusForUser_GetMaxOrderID(Guid iParentClassID);
		#endregion  成员方法
	}
}

