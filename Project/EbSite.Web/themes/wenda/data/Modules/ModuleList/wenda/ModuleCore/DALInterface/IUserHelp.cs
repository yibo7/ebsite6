using System;
using System.Collections.Generic;
using System.Data;
		
namespace EbSite.Modules.Wenda.ModuleCore.DALInterface
{
	/// <summary>
	/// 数据访问类Ask。
	/// </summary>
	public partial interface IDataProvider
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int UserHelp_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool UserHelp_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int UserHelp_Add(Entity.UserHelp model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void UserHelp_Update(Entity.UserHelp model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int UserHelp_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void UserHelp_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.UserHelp UserHelp_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.UserHelp> UserHelp_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet UserHelp_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.UserHelp> UserHelp_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.UserHelp> UserHelp_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.UserHelp UserHelp_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.UserHelp UserHelp_GetEntityByUserID(int UserID);


	    int SumAskNum();
        DataSet GetRandomContent(int top);
	    DataSet GetRandomContentIDS(string ids);

        DataSet GetRandomContentIDS(int top,string ids);
         /// <summary>
        /// 给首页 最新问答提供数据源 每天更新5000条
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        DataSet GetNewsContent5000(int top);



        DataSet GetNewsPageContent(int PageIndex, int PageSize);
	}
}

