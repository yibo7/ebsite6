using System;
using System.Collections.Generic;
using EbSite.Base.EntityAPI;
using EbSite.Base.Plugin.Base;

namespace EbSite.Base.Plugin
{
    public interface IDataImport : IProvider
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
        /// 执行一个导入操作
      /// </summary>
        /// <param name="sFilePath">数据源的绝对路径</param>
      /// <param name="CountNum">数据总共条数</param>
      /// <param name="SuccessNum">居功导入条数</param>
      /// <param name="FailNum">导入失败条数</param>
        /// <returns>是否有导入成功</returns>
        bool Import(string sFilePath, out int CountNum, out int SuccessNum, out int FailNum);

       
    }
}

