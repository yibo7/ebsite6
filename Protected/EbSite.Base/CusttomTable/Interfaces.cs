using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace EbSite.Base.CusttomTable
{
   /// <summary>
   /// 自定义数据表保存接口
   /// </summary>
    public interface ISettingsBehavior<IType>
    {
        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="SavePath">保存的目录</param>
        /// <param name="exId">保存的Id</param>
        /// <param name="settings">一个数据对象</param>
        /// <returns></returns>
        bool SaveSettings(string SavePath, string exId, IType settings);

      /// <summary>
      /// 获取一条数据
      /// </summary>
      /// <param name="SavePath">数据所在目录</param>
      /// <param name="exId"></param>
      /// <returns></returns>
        StringDictionary GetSettings(string SavePath, string exId);
    }

}
