using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace EbSite.Modules.Shop.ModuleCore.DALInterface
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
	public partial interface IDataProvider
	{
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		int giftcartproduct_GetMaxId();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool giftcartproduct_Exists(int id);

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int giftcartproduct_Add(Entity.giftcartproduct model);
        
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void giftcartproduct_Update(Entity.giftcartproduct model);
		
		/// <summary>
		/// 获取统计
		/// </summary>
		int giftcartproduct_GetCount(string strWhere);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		void giftcartproduct_Delete(int id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.giftcartproduct giftcartproduct_GetEntity(int id);

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		List<Entity.giftcartproduct> giftcartproduct_GetListArray(string strWhere);

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet giftcartproduct_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		List<Entity.giftcartproduct> giftcartproduct_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// 获得分页数据
		/// </summary>
		List<Entity.giftcartproduct> giftcartproduct_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		Entity.giftcartproduct giftcartproduct_ReaderBind(IDataReader dataReader);

		#endregion  成员方法
        int giftcartproduct_Add(Entity.giftcartproduct model, MySqlTransaction Trans);
	}
}

