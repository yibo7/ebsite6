using System;
using System.Collections.Generic;
using System.Data;
		
namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类EbSitePlace。
	/// </summary>
    public partial interface IDataProviderCms
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int SpaceSetting_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool SpaceSetting_Exists(int id);


		/// <summary>
		/// 增加一条数据
		/// </summary>
		int SpaceSetting_Add(Entity.SpaceSetting model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void SpaceSetting_Update(Entity.SpaceSetting model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int SpaceSetting_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void SpaceSetting_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.SpaceSetting SpaceSetting_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.SpaceSetting> SpaceSetting_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet SpaceSetting_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.SpaceSetting> SpaceSetting_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.SpaceSetting> SpaceSetting_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.SpaceSetting SpaceSetting_ReaderBind(IDataReader dataReader);

        string SpaceSetting_GetThemePath(int UserID);

	    int SpaceSetting_GetSpaceIDByUserID(int UserID);

		#endregion  成员方法
        /// <summary>
        /// 修改皮肤
        /// </summary>
        /// <param name="UserID">当前登录用户ID</param>
        /// <param name="ThemeID">所选皮肤ID</param>
        /// <param name="ThemePath">所选皮肤英文名称</param>
        void SpaceSetting_UpdateTheme(int UserID, int ThemeID, string ThemePath);
        int SpaceSetting_GetDefaultTabID(int UserID);

	}
}

