using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类EbSite。
	/// </summary>
	public partial interface IDataProviderCms
    {
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool spiderlog_Exists(long Id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int spiderlog_Add(Entity.spiderlog model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void spiderlog_Update(Entity.spiderlog model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int spiderlog_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void spiderlog_Delete(long Id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.spiderlog spiderlog_GetEntity(long Id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.spiderlog> spiderlog_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet spiderlog_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.spiderlog> spiderlog_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.spiderlog> spiderlog_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.spiderlog spiderlog_ReaderBind(IDataReader dataReader);
        /// <summary>
        /// 统计来访数据
        /// </summary>
        /// <param name="spiderid">The spiderid.</param>
        /// <param name="itype">类型,1.今日来访，2昨日来访，3前7天来访，4前30天来访</param>
        /// <returns>System.Int32.</returns>
        int GetLogCount(int spiderid, int itype);

        /// <summary>
        /// 受访频次
        /// </summary>
        /// <param name="sWhere">The s where.</param>
        /// <returns>System.Int32.</returns>
        List<Entity.ListItemModel> GetVisitSum(string sWhere,int iTop);
        /// <summary>
        /// 最近时段分析
        /// </summary>
        /// <param name="itype">请求类型，1为今天，2为昨天，3为最近7天，4为最近30天.</param>
        /// <returns>List&lt;Entity.ListItemModel&gt;.</returns>
        List<Entity.ListItemModel> GetVisitTime(int itype);
        #endregion  成员方法
    }
}

