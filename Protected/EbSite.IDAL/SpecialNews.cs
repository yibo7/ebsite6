using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;
//请先添加引用
namespace EbSite.Data.Interface
{
	/// <summary>
	/// 数据访问类SpecialNews。
	/// </summary>
	public partial interface IDataProviderCms
	{ 
		
		#region  成员方法

	    /// <summary>
	    /// 得到最大ID
	    /// </summary>
        int SpecialNews_GetMaxId();

	    /// <summary>  
	    /// 获取总记录条数
	    /// </summary>
	    /// <returns></returns>
        int SpecialNews_GetCount(string strWhere);

	    /// <summary>
	    /// 是否存在该记录
	    /// </summary>
        bool SpecialNews_Exists(int id);

	    /// <summary>
	    /// 是否存在符合某条件的记录
	    /// </summary>
        bool SpecialNews_Exists(string sWhere);

	    /// <summary>
	    /// 增加一条数据
	    /// </summary>
        int SpecialNews_Add(EbSite.Entity.SpecialNews model);

	    /// <summary>
	    /// 更新一条数据
	    /// </summary>
        void SpecialNews_Update(EbSite.Entity.SpecialNews model);

	    /// <summary>
	    /// 删除一条数据
	    /// </summary>
        void SpecialNews_Delete(int id);

	    /// <summary>
	    /// 删除一条数据
	    /// </summary>
        void SpecialNews_Delete(long newsid, int SpecialID);


	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
        EbSite.Entity.SpecialNews SpecialNews_GetModel(int id);

	    /// <summary>
	    /// 获得数据列表
	    /// </summary>
        DataSet SpecialNews_GetList(string strWhere);

	    /// <summary>
	    /// 获得数据列表（比DataSet效率高，推荐使用）-根据排序
	    /// </summary>
	    /// <param name="strWhere"></param>
	    /// <param name="iTop">大于0才有效,否则为全部</param>
	    /// <param name="oderby"></param>
	    /// <returns></returns>
        List<EbSite.Entity.SpecialNews> SpecialNews_GetListArray(string strWhere, int iTop, string oderby);

	    /// <summary>
	    /// 获得数据列表
	    /// </summary>
	    //public List<EbSite.Entity.SpecialNews> GetModelList(string strWhere)
	    //{
	    //    DataSet ds = GetList(strWhere);
	    //    List<EbSite.Entity.SpecialNews> modelList = new List<EbSite.Entity.SpecialNews>();
	    //    int rowsCount = ds.Tables[0].Rows.Count;
	    //    if (rowsCount > 0)
	    //    {
	    //        Model.SpecialNews model;
	    //        for (int n = 0; n < rowsCount; n++)
	    //        {
	    //            model = new Model.SpecialNews();
	    //            if (ds.Tables[0].Rows[n]["id"].ToString() != "")
	    //            {
	    //                model.id = int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
	    //            }
	    //            if (ds.Tables[0].Rows[n]["NewsID"].ToString() != "")
	    //            {
	    //                model.NewsID = int.Parse(ds.Tables[0].Rows[n]["NewsID"].ToString());
	    //            }
	    //            if (ds.Tables[0].Rows[n]["SpecialClassID"].ToString() != "")
	    //            {
	    //                model.SpecialClassID = int.Parse(ds.Tables[0].Rows[n]["SpecialClassID"].ToString());
	    //            }
	    //            if (ds.Tables[0].Rows[n]["orderid"].ToString() != "")
	    //            {
	    //                model.orderid = int.Parse(ds.Tables[0].Rows[n]["orderid"].ToString());
	    //            }
	    //            if (ds.Tables[0].Rows[n]["subclassid"].ToString() != "")
	    //            {
	    //                model.subclassid = int.Parse(ds.Tables[0].Rows[n]["subclassid"].ToString());
	    //            }
	    //            modelList.Add(model);
	    //        }
	    //    }
	    //    return modelList;
	    //}
	    /// <summary>
	    /// 对象实体绑定数据
	    /// </summary>
        EbSite.Entity.SpecialNews SpecialNews_ReaderBind(IDataReader dataReader);
        /// <summary>
        /// 合并专题
        /// </summary>
        /// <param name="SIDs">源专题ID及其下的子专题ID列表，用逗号分开</param>
        /// <param name="TID">目标专题ID</param>
	    void SpecialNews_MergeSpecail(string SIDs, int TID);

	    #endregion  成员方法
	}
}

