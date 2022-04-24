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
        int TagRelateNews_GetMaxId();

	    /// <summary>
	    /// 是否存在该记录
	    /// </summary>
        bool TagRelateNews_Exists(int id);

	    /// <summary>
	    /// 增加一条数据
	    /// </summary>
        int TagRelateNews_Add(EbSite.Entity.TagRelateNews model);

	    /// <summary>
	    /// 更新一条数据
	    /// </summary>
        void TagRelateNews_Update(EbSite.Entity.TagRelateNews model);

	    /// <summary>
	    /// 删除一条数据
	    /// </summary>
        void TagRelateNews_Delete(int id);

	    /// <summary>
	    /// 当删除某个标签时同时删除与其关联的数据
	    /// </summary>
	    /// <param name="tagid"></param>
        void TagRelateNews_DeleteByTagDelete(int tagid);

	    /// <summary>
	    /// 删除与某条内容脱离关联的记录
	    /// </summary>
	    /// <param name="ReserveIDs">更新后当前的标签ID</param>
	    /// <param name="ContentID">内容ID</param>
        void TagRelateNews_DeleteByRemove(string ReserveIDs, long ContentID);


	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
        EbSite.Entity.TagRelateNews TagRelateNews_GetModel(int id);

	    /// <summary>
	    /// 获得数据列表
	    /// </summary>
        DataSet TagRelateNews_GetList(string strWhere);

        string TagRelateNews_GetTagsByContentID(long ContentID);

	    /// <summary>
	    /// 获得数据列表
	    /// </summary>
        List<EbSite.Entity.TagRelateNews> TagRelateNews_GetModelList(string strWhere);

        EbSite.Entity.TagRelateNews TagRelateNews_ReaderBind(IDataReader dataReader);

	    #endregion  成员方法
	}
}

