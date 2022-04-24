using System;
using System.Collections.Generic;
using System.Data;
		
namespace EbSite.Modules.BBS.ModuleCore.DALInterface
{
	/// <summary>
	/// 数据访问类BBS。
	/// </summary>
	public partial interface IDataProvider
	{
		#region  成员方法
        int TopicReplies_Copy(string tablename);
		/// <summary>
		/// 得到最大ID
		/// </summary>
		long TopicReplies_GetMaxId(int classid);

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        bool TopicReplies_Exists(long id, int classid);

		/// <summary>
		/// 增加一条数据
		/// </summary>
        long TopicReplies_Add(Entity.TopicReplies model, int classid);

		/// <summary>
		/// 更新一条数据
		/// </summary>
        void TopicReplies_Update(Entity.TopicReplies model, int classid);
		
		/// <summary>
		/// 获取统计
		/// </summary>
        int TopicReplies_GetCount(string strWhere, int classid);

		/// <summary>
		/// 删除一条数据
		/// </summary>
        void TopicReplies_Delete(long id, int classid);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Entity.TopicReplies TopicReplies_GetEntity(long id, int classid);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
        List<Entity.TopicReplies> TopicReplies_GetListArray(string strWhere, int classid);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        DataSet TopicReplies_GetList(int Top, string strWhere, string filedOrder, int classid);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
        List<Entity.TopicReplies> TopicReplies_GetListArray(int Top, string strWhere, string filedOrder, int classid);

		/// <summary>
		/// 获得分页数据
		/// </summary>
        List<Entity.TopicReplies> TopicReplies_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount, int classid);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.TopicReplies TopicReplies_ReaderBind(IDataReader dataReader);

        void EditeReply(long id, string ContentHtml, int classid);

	    void UpdatePost(int SetTop, int PostLab, int TitleFont, string TitleColor, string IDs, int ManagerUserId,
                        string ManagerUserNiName, int classid);

        void TopicReplies_Update(int id, string Col, string sValue, int classid);

	    #endregion  成员方法
	}
}

