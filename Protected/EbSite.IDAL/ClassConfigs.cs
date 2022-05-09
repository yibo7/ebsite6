using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类ebsite。
	/// </summary>
    public partial interface IDataProviderCms
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int ClassConfigs_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool ClassConfigs_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int ClassConfigs_Add(Entity.ClassConfigs model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
        void ClassConfigs_Update(Entity.ClassConfigs model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int ClassConfigs_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void ClassConfigs_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Entity.ClassConfigs ClassConfigs_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
        List<Entity.ClassConfigs> ClassConfigs_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet ClassConfigs_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
        List<Entity.ClassConfigs> ClassConfigs_GetListArray(int Top, string strWhere, string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
        List<Entity.ClassConfigs> ClassConfigs_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
        Entity.ClassConfigs ClassConfigs_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

	    bool IsHaveClassConfigs(int SiteID);
        //bool IsHaveClassConfigsByClassID(int ClassID);
	    Entity.ClassConfigs GeClassConfigs(int SiteID);
        //void UpdateDefaultClassConfigs(Entity.ClassConfigs Model);
        Entity.ClassConfigs GeClassConfigsByClassID(int ClassID);
        List<Entity.ClassConfigs> GeClassConfigsByModuleId(Guid mid);
        //void DeleteByClassID(int ClassID);
		/// <summary>
		/// 将某个设置更新为默认
		/// </summary>
		/// <param name="id"></param>
		/// <param name="siteId"></param>
		void UpdateDefault(int id,int siteId);
		/// <summary>
		/// 获取某个站点下的默认配置Id
		/// </summary>
		/// <param name="siteId"></param>
		/// <returns></returns>
		int GetDefaultConfigId(int siteId);
	}
}

