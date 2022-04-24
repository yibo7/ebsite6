using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类qwerty。
	/// </summary>
    public partial interface IDataProviderCms
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int tool_chatlist_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool tool_chatlist_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int tool_chatlist_Add(Entity.Tool_ChatList model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void tool_chatlist_Update(Entity.Tool_ChatList model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int tool_chatlist_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
        void tool_chatlist_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Entity.Tool_ChatList tool_chatlist_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.Tool_ChatList> tool_chatlist_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet tool_chatlist_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.Tool_ChatList> tool_chatlist_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.Tool_ChatList> tool_chatlist_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.Tool_ChatList tool_chatlist_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 获取聊天记录
        /// </summary>
        /// <param name="salerID">销售员ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        DataTable GetChatList(int salerID,int userID);
        /// <summary>
        /// 获取聊天记录
        /// </summary>
        /// <param name="salerID">销售员ID</param>
        /// <returns></returns>
        DataTable GetChatList(int salerID); 

        #endregion 自定义方法
    }
}

