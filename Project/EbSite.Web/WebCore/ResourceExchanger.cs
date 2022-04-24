using System;
using System.Collections.Generic;
using System.Resources;
using System.Web;
using EbSite.Core.Resource;

namespace EbSite.Web.WebCore
{
    /// <summary>
    /// 实现资源文件获取接口
    /// </summary>
    public class ResourceExchanger : IResourceExchanger
    {
        private ResourceManager manager;

        /// <summary>
        /// Initialises a new instance of the <b>ResourceExchanger</b> class.
        /// 初始化，创建 ResourceManager 对象
        /// </summary>
        public ResourceExchanger()
        {
            
            //manager = new ResourceManager("ScrewTurn.Wiki.Properties.Messages", typeof(Properties.).Assembly);
            manager = new ResourceManager("Resources.lang", System.Reflection.Assembly.Load("App_GlobalResources"));
        }

        /// <summary>
        /// Gets a Resource String.
        /// 根据KEY以获取相应的资源
        /// </summary>
        /// <param name="name">The Name of the Resource.资源的 key</param>
        /// <returns>The Resource String.</returns>
        public string GetResource(string name)
        {
            return manager.GetString(name);
        }
    }
}