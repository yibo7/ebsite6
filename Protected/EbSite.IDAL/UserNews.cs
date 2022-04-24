using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
//请先添加引用
namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类TagRelateNews。 
	/// </summary>
    public partial interface IDataProviderCms
	{
		
		#region  成员方法

	    /// <summary>
	    /// 得到最大ID
	    /// </summary>
        int UserNews_GetMaxId();

	    /// <summary>
	    /// 是否存在该记录
	    /// </summary>
        bool UserNews_Exists(int id);

	    /// <summary>
	    /// 增加一条数据
	    /// </summary>
        int UserNews_Add(EbSite.Entity.UserNews model);

	    /// <summary>
	    /// 更新一条数据
	    /// </summary>
        void UserNews_Update(EbSite.Entity.UserNews model);

	    /// <summary>
	    /// 删除一条数据
	    /// </summary>
        void UserNews_Delete(int id);


	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
        EbSite.Entity.UserNews UserNews_GetModel(int id);

	    /// <summary>
	    /// 获得数据列表
	    /// </summary>
        List<EbSite.Entity.UserNews> UserNews_GetList(int Top, string strWhere, string filedOrder);

        EbSite.Entity.UserNews UserNews_ReaderBind(IDataReader dataReader);

	    #endregion  成员方法
	}
}

