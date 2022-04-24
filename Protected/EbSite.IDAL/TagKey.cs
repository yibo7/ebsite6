using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
//请先添加引用
namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类TagKey。
	/// </summary>
	public partial interface IDataProviderCms
	{
		
		#region  成员方法

	    /// <summary>
	    /// 得到最大ID
	    /// </summary>
        int TagKey_GetMaxId();

	    /// <summary>
	    /// 是否存在该记录
	    /// </summary>
        bool TagKey_Exists(int id);

	    /// <summary>
	    /// 是否存在符合某条件的记录
	    /// </summary>
        bool TagKey_Exists(string sWhere,int SiteID);

	    /// <summary>
	    /// 检查添加一个标签-递减型
	    /// </summary>
	    /// <param name="tagid"></param>
        int TagKey_UpdateByDelete(int tagid);

	    /// <summary>
	    /// 检查添加一个标签-递增型,如果已经有相同名称的标签将不做添加操作，中在num上加一
	    /// </summary>
	    /// <param name="tagname"></param>
	    /// <param name="ContentID"></param>
	    /// <returns></returns>
        int TagKey_UpdateByAdd(string tagname, int SiteID);

	    /// <summary>
	    /// 检查添加一个标签-递增型,如果已经有相同名称的标签将不做添加操作，中在num上加一
	    /// </summary>
	    /// <param name="tagname"></param>
        int TagKey_UpdateByAdd(string tagname, long ContentID, int SiteID);

	    /// <summary>
	    /// 增加一条数据
	    /// </summary>
        int TagKey_Add(EbSite.Entity.TagKey model);

	    /// <summary>
	    /// 获取总记录条数
	    /// </summary>
	    /// <returns></returns>
        int TagKey_GetCount(string strWhere, int SiteID);

	    /// <summary>
	    /// 获取所有id列表
	    /// </summary>
	    /// <returns></returns>
        List<int> TagKey_GetIDList(string sWhere, int SiteID);

	    /// <summary>
	    /// 更新一条数据
	    /// </summary>
        void TagKey_Update(EbSite.Entity.TagKey model);

	    List<EbSite.Entity.TagKey> TagKey_GetTagByContentID(int ContentID, int ClassId, string OrderByCol, int Top,
	        int SiteID,int Num);

        /// <summary>
        /// 分页获取数据列表 只适用 sql 2005
        /// </summary>
        List<EbSite.Entity.TagKey> TagKey_GetListPages(int startRowIndex, int maxinmumRows, string strWhere, string oderby, out int Count, int SiteID);

	    /// <summary>
	    /// 删除一条数据
	    /// </summary>
        void TagKey_Delete(int id);

	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
        EbSite.Entity.TagKey TagKey_GetModel(int id);

	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
         int TagKey_GetTagIDByName(string sTag);

	    /// <summary>
	    /// 获得数据列表
	    /// </summary>
         List<EbSite.Entity.TagKey> TagKey_GetListArr(string strWhere, int Top, string OrderBy, int SiteID,int Num);
         List<EbSite.Entity.TagKey> TagKey_GetTagKeysByClassID(int Top, int ClassID, string OrderBy, int SiteID, int Num);

         void TagKey_UpdateAllHtmlRule(string Rule);

         void TagKey_UpdateHtmlName(string Name,int KeyID);
         void TagKey_MergeLable(int iID, int TargetID);
	    /// <summary>
	    /// 对象实体绑定数据
	    /// </summary>
        EbSite.Entity.TagKey TagKey_ReaderBind(IDataReader dataReader);

        //DataSet TagKey_GetList(string strWhere);

        ///// 获得数据列表
        ///// </summary>
        //DataSet TagKey_GetList(int top);


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
			parameters[0].Value = "TagKey";
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

