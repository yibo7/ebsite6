using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;


namespace EbSite.Data.User.Interface
{
	/// <summary>
	/// 数据访问类Favorite。
	/// </summary>
    public partial interface IDataProviderUser
	{
		#region  成员方法
        /// <summary>
        /// 获得总条数
        /// </summary>
	    int Favorite_GetCount(string strWhere);
	    /// <summary>
	    /// 增加一条数据
	    /// </summary>
        int Favorite_Add(EbSite.Entity.Favorite model);

	    /// <summary>
	    /// 删除一条数据-内容
	    /// </summary>
        void Favorite_DeleteOFContent(int ContentID, string UserName);
        /// <summary>
        /// 删除一条数据-分类
        /// </summary>
        void Favorite_DeleteOFClass(int ContentID, string UserName);

	    /// <summary>
	    /// 获得前几行数据
	    /// </summary>
        List<EbSite.Entity.Favorite> Favorite_GetListArr(int Top, string strWhere, string filedOrder);

	    /// <summary>
	    /// 对象实体绑定数据
	    /// </summary>
        EbSite.Entity.Favorite Favorite_ReaderBind(IDataReader dataReader);
        /// <summary>
        /// 分页列表
        /// </summary>
	    List<Entity.Favorite> Favorite_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,
	                                                       string oderby, out int RecordCount);

	    EbSite.Entity.Favorite Favorite_GetModel(int ID);
	    void Favorite_Update(Entity.Favorite model);
        void Favorite_DeleteInIDs(string IDs);
		#endregion  成员方法
	}
}

