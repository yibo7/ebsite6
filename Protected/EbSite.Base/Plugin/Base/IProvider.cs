using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Base.Extension.Manager;

namespace EbSite.Base.Plugin.Base
{
    /// <summary>
    /// 所有插件的基类
    /// </summary>
    public interface  IProvider
    {
        /// <summary>
        /// 初始化插件
        /// </summary>
        /// <param name="host">主系统对象，可让插件调用主系统里的方法，以达到解耦合</param>
        /// <param name="config">插件配置文件</param>
        void Init(Host host, ExtensionSettings settings);//string config
        //void Init(IHost host, string config);//string config
        /// <summary>
        /// 注销插件  
        /// </summary>
        void Shutdown();

        ///// <summary>
        ///// 插件信息
        ///// </summary>
        //ProviderInfo Information { get; }
        /// <summary>
        /// 插件帮助信息
        /// </summary>
        string ConfigHelpHtml { get; }
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        Extension.Manager.ExtensionSettings GetSettings();
    }

    
}





//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace EbOA.Base.Plugin.Base
//{
//    /// <summary>
//    /// 所有插件的基类
//    /// </summary>
//    public abstract class IProvider
//    {
//        private string m_ConfigurationString;
//        /// <summary>
//        /// 配置文件的文本
//        /// </summary>
//        protected  string ConfigurationString
//        {
//            get
//            {
//                return m_ConfigurationString;
//            }
//            set
//            {
//                m_ConfigurationString = value;

//                //此处可通过主程序读取配置文件信息，在此就不作详细代码了，请自行实现，
//                //其实只是读取文本文件的配置，当然你也可以用XML，以下代码就先注释掉了
//            }
//        }
//        /// <summary>
//        /// 提供主系统常用信息
//        /// </summary>
//        public IHost Host;
//        /// <summary>
//        /// 初始化插件
//        /// </summary>
//        /// <param name="host">提供宿主的重要信息</param>
//        /// <param name="config">配置文件</param>
//        public  void Init(IHost host, string config)
//        {
//            if (host == null) throw new ArgumentNullException("host");
//            if (config == null) throw new ArgumentNullException("config");
//            this.Host = host;
//            this.ConfigurationString = config;
//        }
//        /// <summary>
//        /// 注销插件
//        /// </summary>
//        public abstract void Shutdown();
//        /// <summary>
//        /// 插件信息
//        /// </summary>
//        public abstract ProviderInfo Information { get; }
//        /// <summary>
//        /// 插件帮助信息
//        /// </summary>
//        public abstract string ConfigHelpHtml { get; }
//    }
//}
