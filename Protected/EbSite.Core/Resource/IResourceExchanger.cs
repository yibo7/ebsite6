using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Core.Resource
{
    /// <summary>/// 
    /// 发布接口以获取资源
    /// </summary>
    public interface IResourceExchanger
    {  
       /// <summary>
        /// 获取对应资源.
       /// </summary>
        /// <param name="name">资源名称，即KEY</param>
        /// <returns>对应的资源</returns>
         string GetResource(string name);
    } 

}
