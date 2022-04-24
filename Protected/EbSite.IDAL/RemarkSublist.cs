using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;


namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类RemarkSublistSublist。
	/// </summary>
	public partial interface IDataProviderCms
	{
		
		#region  成员方法

	    /// <summary>
	    /// 得到最大ID
	    /// </summary>
        int RemarkSublist_GetMaxId();

	    /// <summary>
	    /// 是否存在该记录
	    /// </summary>
        bool RemarkSublist_Exists(int ID);

	    /// <summary>
	    /// 获取总记录条数
	    /// </summary>
	    /// <returns></returns>
        int RemarkSublist_GetCount(string strWhere);

	    int RemarkSublist_GetCount( string Mark, bool IsAuditing);

        int RemarkSublist_GetCountByClassID( bool IsAuditing);

	    /// <summary>
	    /// 增加一条数据
	    /// </summary>
        void RemarkSublist_Add(EbSite.Entity.RemarkSublist model);

	    /// <summary>
	    /// 帖子操作
	    /// </summary>
	    /// <param name="postid"></param>
	    /// <param name="flag"></param>
        void RemarkSublist_ExecutePost(int postid, int flag);

	    /// <summary>
	    /// 更新一条数据
	    /// </summary>
        void RemarkSublist_Update(EbSite.Entity.RemarkSublist model);

	    /// <summary>
	    /// 删除一条数据
	    /// </summary>
        void RemarkSublist_Delete(int ID);

	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
        EbSite.Entity.RemarkSublist RemarkSublist_GetModel(int ID);

	    /// <summary>
	    /// 获得数据列表
	    /// </summary>
        DataSet RemarkSublist_GetList(string strWhere);
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="oderby"></param>
        /// <param name="IsAuditing">为-1,所有数据，1，已经审核的数据，0，未审核的数据</param>
        /// <returns></returns>
        List<EbSite.Entity.RemarkSublist> RemarkSublist_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, int IsAuditing);

        EbSite.Entity.RemarkSublist RemarkSublist_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
	}
}

