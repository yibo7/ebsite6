using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EbSite.Data.Interface
{
    /// <summary>
    /// 数据访问类Menus。
    /// </summary>
    public partial interface IDataProviderCms
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Menus_Exists(Guid id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Menus_Add(Entity.Menus model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Menus_Update(Entity.Menus model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Menus_Delete(Guid id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.Menus Menus_GetEntity(Guid id);
        /// <summary>
        /// 获取统计
        /// </summary>
        int Menus_GetCount(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet Menus_GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        List<Entity.Menus> Menus_GetListArray(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        List<Entity.Menus> Menus_GetListArray(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 获得分页数据
        /// </summary>
        List<Entity.Menus> Menus_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount);
        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        Entity.Menus Menus_ReaderBind(IDataReader dataReader);

        List<Entity.Menus> Menus_GetListByParentID(Guid ParentID,int SiteID);

        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="SoureClassID">源分类ID</param>
        /// <param name="TargetClassID">目标分类ID</param>
        /// <param name="IsAsChildnode">是否作为作为目标分类的子分类</param>
        /// <returns></returns>
        void Menus_Move(Guid SoureClassID, Guid TargetClassID, bool IsAsChildnode);

        int Menus_GetMaxOrderID(Guid iParentClassID);
        /// <summary>
        /// 删除某个模块下的所有菜单
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        void Menus_DeleteByModuleID(Guid ModuleID);
        #endregion  成员方法
    }
}
