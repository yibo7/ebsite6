using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.User.Interface
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
    public partial interface IDataProviderUser
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int Coupons_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Coupons_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Coupons_Add(Entity.Coupons model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Coupons_Update(Entity.Coupons model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int Coupons_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Coupons_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.Coupons Coupons_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.Coupons> Coupons_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet Coupons_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.Coupons> Coupons_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.Coupons> Coupons_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.Coupons Coupons_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 获取我的优惠券
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="endDate">当前日期</param>
        /// <returns></returns>
        List<Entity.Coupons> Coupons_GetListArray(int uid);

        #endregion 自定义方法
    }
}

