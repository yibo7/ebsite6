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
        int FriendList_GetMaxId();

	    /// <summary>
	    /// 是否存在该记录
	    /// </summary>
        int FriendList_Exists(int UserID, int FriendID);

	    /// <summary>
	    /// 增加一条数据
	    /// </summary>
        int FriendList_Add(EbSite.BLL.FriendList model);

	    /// <summary>
	    /// 更新一条数据
	    /// </summary>
        void FriendList_Update(EbSite.BLL.FriendList model);

	    /// <summary>
	    /// 删除一条数据
	    /// </summary>
        void FriendList_Delete(int id);
        /// <summary>
        /// 通过邀请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool FriendList_Allow(BLL.FriendList model);

	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
        EbSite.BLL.FriendList FriendList_GetModel(int id);

	    /// <summary>
	    /// 获得数据列表
	    /// </summary>
        List<EbSite.BLL.FriendList> FriendList_GetList(int Top, string strWhere, string filedOrder);
        List<EbSite.BLL.FriendList> FriendList_GetList(int Top, string strWhere, string filedOrder,int IsAllow);

        EbSite.BLL.FriendList FriendList_ReaderBind(IDataReader dataReader);

	    #endregion  成员方法
	}
}

