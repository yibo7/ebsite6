using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.User.Interface
{
	/// <summary>
	/// 数据访问类qwef。
	/// </summary>
    public partial interface IDataProviderUser
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int thethirdlogincode_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool thethirdlogincode_Exists(int ID);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool thethirdlogincode_Exists(string strToken);
        
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int thethirdlogincode_Add(Entity.TheThirdLoginCode model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void thethirdlogincode_Update(Entity.TheThirdLoginCode model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int thethirdlogincode_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void thethirdlogincode_Delete(int ID);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.TheThirdLoginCode thethirdlogincode_GetEntity(int ID);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.TheThirdLoginCode> thethirdlogincode_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet thethirdlogincode_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.TheThirdLoginCode> thethirdlogincode_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.TheThirdLoginCode> thethirdlogincode_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.TheThirdLoginCode thethirdlogincode_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 是否已经绑定过
        /// </summary>
        /// <param name="strToken">授权码</param>
        /// <returns></returns>
        bool thethirdlogincode_IsBind(string strToken);
        /// <summary>
        /// 根据授权码更新
        /// </summary>
        /// <param name="strToken">授权码</param>
        /// <returns></returns>
        bool thethirdlogincode_UpdateByToken(Entity.TheThirdLoginCode model);
        /// <summary>
        /// 根据授权码获取用户ID
        /// </summary>
        /// <param name="strToken"></param>
        /// <returns></returns>
        int thethirdlogincode_GetUserIDByToken(string strToken);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.TheThirdLoginCode thethirdlogincode_GetEntity(string Uid,string appName);

        #endregion 自定义方法
    }
}

