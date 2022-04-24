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
        int FavoriteClass_GetCount(string strWhere);
	    /// <summary>
	    /// 增加一条数据
	    /// </summary>
        int FavoriteClass_Add(EbSite.Entity.FavoriteClass model);
	    /// <summary>
	    /// 删除一条数据-分类
	    /// </summary>
	    void FavoriteClass_DeleteOFClass(int ID, string UserName);

	    /// <summary>
	    /// 获得前几行数据
	    /// </summary>
        List<EbSite.Entity.FavoriteClass> FavoriteClass_GetListArr(int Top, string strWhere, string filedOrder);

	    /// <summary>
	    /// 对象实体绑定数据
	    /// </summary>
        EbSite.Entity.FavoriteClass FavoriteClass_ReaderBind(IDataReader dataReader);

        /// <summary>
        /// 分页列表
        /// </summary>
        List<Entity.FavoriteClass> FavoriteClass_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,
                                                           string oderby, out int RecordCount);

        EbSite.Entity.FavoriteClass FavoriteClass_GetModel(int ID);

	    void FavoriteClass_Update(Entity.FavoriteClass model);
		#endregion  成员方法
	}
}

