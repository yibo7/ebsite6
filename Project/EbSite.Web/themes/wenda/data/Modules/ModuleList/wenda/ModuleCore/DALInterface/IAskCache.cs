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
		int AskCache_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool AskCache_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int AskCache_Add(Entity.AskCache model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void AskCache_Update(Entity.AskCache model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void AskCache_UpdateEx(Entity.AskCache model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int AskCache_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void AskCache_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.AskCache AskCache_GetEntity(int id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.AskCache AskCache_GetEntity(int keyid,int keytype);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.AskCache> AskCache_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet AskCache_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.AskCache> AskCache_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.AskCache> AskCache_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.AskCache AskCache_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 判断是否过期
        /// </summary>
        /// <param name="keyid">关联ID</param>
        /// <param name="keytype">关联类型</param>
        /// <returns></returns>
        bool AskCache_IsTimeOut(int keyid,int keytype);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="keyid">关联ID</param>
        /// <param name="keytype">关联类型</param>
        bool AskCache_Exists(int keyid, int keytype);

        #endregion 自定义方法
    }
}

