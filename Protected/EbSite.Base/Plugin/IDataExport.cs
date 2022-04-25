using System;
using System.Collections.Generic;
using EbSite.Base.EntityAPI;
using EbSite.Base.Plugin.Base;

namespace EbSite.Base.Plugin
{
    /// <summary>
    /// （已废弃）
    /// </summary>
    public interface IDataExport : IProvider
    {

        ///// <summary>
        ///// 显示在后台的说明  在帮助里写就行
        ///// </summary>
        //string DefaultDescription { get; }
        /// <summary>
        /// 显示在前台的说明
        /// </summary>
        string Description { get; }
        /// <summary>
        /// 执行一个导出操作
        /// </summary>
        /// <param name="lstData">要导出的数据源</param>
        /// <returns>返回生成的数据包相对路径</returns>
        /// <param name="fileName">要保存的文件夹的名称</param>
        string Export(object lstData,string fileName);
        

       
    }
}

