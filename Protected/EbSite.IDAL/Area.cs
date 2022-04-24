using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类area。
	/// </summary>
    public partial interface IDataProviderCms
	{
		#region  成员方法

	

		/// <summary>
		/// 增加一条数据
		/// </summary>
        int AreaInfo_Add(Entity.AreaInfo model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
        void AreaInfo_Update(Entity.AreaInfo model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
        int AreaInfo_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
        void AreaInfo_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Entity.AreaInfo AreaInfo_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
        List<Entity.AreaInfo> AreaInfo_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        DataSet AreaInfo_GetList(int Top, string strWhere, string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
        List<Entity.AreaInfo> AreaInfo_GetListArray(int Top, string strWhere, string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
        List<Entity.AreaInfo> AreaInfo_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
        Entity.AreaInfo AreaInfo_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

	    bool AreaDataAllAdd(string url);
	}

}

