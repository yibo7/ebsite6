using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;


namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类Remark。
	/// </summary>
	public partial interface IDataProviderCms
	{
		
		#region  成员方法

	    /// <summary>
	    /// 得到最大ID
	    /// </summary>
        int Remark_GetMaxId();

	    /// <summary>
	    /// 是否存在该记录
	    /// </summary>
        bool Remark_Exists(int ID);

	    /// <summary>
	    /// 获取总记录条数
	    /// </summary>
	    /// <returns></returns>
        int Remark_GetCount(string strWhere);
        /// <summary>
        /// 统计评分
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        int Remark_CountScore(string strWhere);
	    int Remark_GetCount(int cid, int classid,int contentid, bool IsAuditing);

        int Remark_GetCountByClassID(int ClassID, bool IsAuditing);

	    /// <summary>
	    /// 增加一条数据
	    /// </summary>
        void Remark_Add(EbSite.Entity.Remark model);

	    /// <summary>
	    /// 帖子操作
	    /// </summary>
	    /// <param name="postid"></param>
	    /// <param name="flag"></param>
        void Remark_ExecutePost(int postid, int flag);

	    /// <summary>
	    /// 更新一条数据
	    /// </summary>
        void Remark_Update(EbSite.Entity.Remark model);

	    /// <summary>
	    /// 删除一条数据
	    /// </summary>
        void Remark_Delete(int ID);

	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
        EbSite.Entity.Remark Remark_GetModel(int ID);

	    /// <summary>
	    /// 获得数据列表
	    /// </summary>
        DataSet Remark_GetList(string strWhere);
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="oderby"></param>
        /// <param name="IsAuditing">为-1,所有数据，1，已经审核的数据，0，未审核的数据</param>
        /// <returns></returns>
        List<EbSite.Entity.Remark> Remark_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, int IsAuditing);

        EbSite.Entity.Remark Remark_ReaderBind(IDataReader dataReader);

	    List<EbSite.Entity.Remark> Remark_GetListArray(string strWhere, int iTop, string OrderBy);

		#endregion  成员方法
	}
}

