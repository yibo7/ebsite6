using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

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
		int CouponItems_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool CouponItems_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int CouponItems_Add(Entity.CouponItems model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
		void CouponItems_Update(Entity.CouponItems model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int CouponItems_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void CouponItems_Delete(int id);
        

       
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.CouponItems CouponItems_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.CouponItems> CouponItems_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet CouponItems_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.CouponItems> CouponItems_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.CouponItems> CouponItems_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.CouponItems CouponItems_ReaderBind(IDataReader dataReader);

		#endregion  成员方法

	    Entity.CouponItems CouponItems_GetEntity(string CouponCode, out string CouponName, out decimal Amount,
	                                             out decimal CouponValue);


	    List<Entity.CouponItems> CouponItemsUnion_GetListArray(int Top, string strWhere, string filedOrder);

	    Entity.CouponItems CouponItems_GetEntity(string ClaimCode);


        void CouponItems_Delete(int id, DbTransaction Trans);
	}
}

