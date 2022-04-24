using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
//请先添加引用
namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类TagRelateUser。
	/// </summary>
	public partial interface IDataProviderCms
	{
		
		#region  成员方法

	    /// <summary>
	    /// 得到最大ID
	    /// </summary>
        int TagRelateUser_GetMaxId();

	    /// <summary>
	    /// 是否存在该记录
	    /// </summary>
        bool TagRelateUser_Exists(int id);

	    /// <summary>
	    /// 增加一条数据
	    /// </summary>
        int TagRelateUser_Add(EbSite.Entity.TagRelateUser model);

	    /// <summary>
	    /// 更新一条数据
	    /// </summary>
        void TagRelateUser_Update(EbSite.Entity.TagRelateUser model);

	    /// <summary>
	    /// 删除一条数据
	    /// </summary>
        void TagRelateUser_Delete(int id);

	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
        EbSite.Entity.TagRelateUser TagRelateUser_GetModel(int id);

        void TagRelateUser_DeleteByRemove(string ReserveIDs, int UserID);
	    /// <summary>
	    /// 获得数据列表
	    /// </summary>
        List<EbSite.Entity.TagRelateUser> TagRelateUser_GetList(string strWhere);
		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "TagRelateUser";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

