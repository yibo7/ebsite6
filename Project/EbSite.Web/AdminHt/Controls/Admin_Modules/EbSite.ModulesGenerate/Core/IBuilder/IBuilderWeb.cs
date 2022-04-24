using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Core.DataBase.Entity;

namespace EbSite.ModulesGenerate.Core.IBuilder
{
    public interface IBuilderWeb
    {
        #region 公有属性
        /// <summary>
        /// 搜索字段
        /// </summary>
        List<FieldInfo> SearchColum
        {
            set;
            get;
        }
        /// <summary>
        /// 高级搜索字段
        /// </summary>
        List<FieldInfo> SearchAdvColum
        {
            set;
            get;
        }
        /// <summary>
        ///  添加字段
        /// </summary>
        List<FieldInfo> AddColum
        {
            set;
            get;
        }
        /// <summary>
        /// 列表字段
        /// </summary>
        List<FieldInfo> ListColum
        {
            set;
            get;
        }
        /// <summary>
        /// 显示字段
        /// </summary>
        List<FieldInfo> ShowColum
        {
            set;
            get;
        }
        /// <summary>
        /// 数据层名称
        /// </summary>
        string DalName
        {
            set; 
            get;
        }
        /// <summary>
        /// 顶级命名空间名 
        /// </summary>
        string NameSpace
        {
            set;
            get;
        }
        string Folder
        {
            set;
            get;
        }
        /// <summary>
        /// model类名
        /// </summary>
        string ModelName
        {
            set;
            get;
        }
        string BLLName
        {
            set;
            get;
        }
        /// <summary>
        /// 选择的字段集合
        /// </summary>
        List<ColumnInfo> Fieldlist
        {
            set;
            get;
        }
        /// <summary>
        /// 主键或条件字段列表 
        /// </summary>
        List<ColumnInfo> Keys
        {
            set;
            get;
        }
        #endregion

        #region Aspx页面html
        /// <summary>
        /// 路由页面html
        /// </summary>
        /// <returns></returns>
        string GetRouteHTML();

        /// <summary>
        /// 得到表示层增加窗体的html代码
        /// </summary>      
        string GetAddHTML();
        /// <summary>
        /// 得到表示层增加窗体的html代码
        /// </summary>      
        string GetListHTML();
        /// <summary>
        /// 得到表示层显示窗体的html代码
        /// </summary>     
        string GetShowHTML();

        ///// <summary>
        ///// 增删改3个页面代码
        ///// </summary>      
        //string GetWebHtmlCode(bool ExistsKey, bool AddForm, bool UpdateForm, bool ShowForm, bool SearchForm);

        #endregion

        #region 表示层 CS
        /// <summary>
        /// 路由页面后台代码
        /// </summary>
        /// <returns></returns>
        string GetRouteCS();
        /// <summary>
        /// 得到表示层增加窗体的代码
        /// </summary>      
        string GetAddCs();
        /// <summary>
        /// 得到修改窗体的代码
        /// </summary>      
        string GetListCs();
        /// <summary>
        /// 得到表示层显示窗体的代码
        /// </summary>       
        string GetShowCs();
        ///// <summary>
        ///// 删除页面
        ///// </summary>
        ///// <returns></returns>
        //string CreatDeleteForm();
        //string CreatSearchForm();
        //string GetWebCode(bool ExistsKey, bool AddForm, bool UpdateForm, bool ShowForm, bool SearchForm);

        #endregion//表示层

        #region  生成aspx.designer.cs
        /// <summary>
        /// 得到路由页面设计代码
        /// </summary>
        /// <returns></returns>
        string GetRouteDesigner();

        /// <summary>
        /// 得到表示层增加窗体的html代码
        /// </summary>      
        string GetAddDesigner();
        /// <summary>
        /// 得到表示层增加窗体的html代码
        /// </summary>      
        string GetListDesigner();
        /// <summary>
        /// 得到表示层显示窗体的html代码
        /// </summary>     
        string GetShowDesigner();
        #endregion
    }
}