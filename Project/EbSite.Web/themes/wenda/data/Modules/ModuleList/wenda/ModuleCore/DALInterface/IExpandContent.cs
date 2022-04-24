using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Modules.Wenda.ModuleCore.DALInterface
{
    public partial interface IDataProvider
    {
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
       int ExpandContent_GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
       bool ExpandContent_Exists(int id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
       int ExpandContent_Add(Entity.ExpandContent model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
       void ExpandContent_Update(Entity.ExpandContent model);

        /// <summary>
        /// 获取统计
        /// </summary>
       int ExpandContent_GetCount(string strWhere);

        /// <summary>
        /// 删除一条数据
        /// </summary>
       void ExpandContent_Delete(int id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       Entity.ExpandContent ExpandContent_GetEntity(int id);

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
       List<Entity.ExpandContent> ExpandContent_GetListArray(string strWhere);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
       DataSet ExpandContent_GetList(int Top, string strWhere, string filedOrder);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
       List<Entity.ExpandContent> ExpandContent_GetListArray(int Top, string strWhere, string filedOrder);

        /// <summary>
        /// 获得分页数据
        /// </summary>
       List<Entity.ExpandContent> ExpandContent_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount);

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
       Entity.ExpandContent ExpandContent_ReaderBind(IDataReader dataReader);

        #endregion  成员方法
    }
}
