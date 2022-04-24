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
		int goods_visite_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool goods_visite_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int goods_visite_Add(Entity.goods_visite model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void goods_visite_Update(Entity.goods_visite model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int goods_visite_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void goods_visite_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.goods_visite goods_visite_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.goods_visite> goods_visite_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet goods_visite_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.goods_visite> goods_visite_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.goods_visite> goods_visite_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.goods_visite goods_visite_ReaderBind(IDataReader dataReader);

        Entity.goods_visite goods_visite_GetEntity(int ContentID, int UserID, long IP);
	    //Entity.goods_visite goods_visite_Adds(List<Entity.goods_visite> lst);

	    #endregion  成员方法
        List<Entity.goods_visite> goods_visite_ListByProductID(int Top, string strWhere, string filedOrder,int ClassID);
	}
}

