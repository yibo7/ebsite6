using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Base.Plugin
{
    /// <summary>
    /// 实现一个泛型插件 Provider 集合
    /// </summary>
    /// <typeparam name="T">集合类型.</typeparam>
    public class ProviderCollector<T>
    {
        private List<T> list;

        /// <summary>
        /// 初始化新的实体
        /// </summary>
        public ProviderCollector()
        {
            list = new List<T>(3);
        }

        /// <summary>
        /// 添加一个 Provider 到集合
        /// </summary>
        /// <param name="provider">需添加的 Provider.</param>
        public void AddProvider(T provider)
        {
            lock (this)
            {
                list.Add(provider);
            }
        }

        /// <summary>
        /// 从集合里移除一个 Provider
        /// </summary>
        /// <param name="provider">需移除的 Provider</param>
        public void RemoveProvider(T provider)
        {
            lock (this)
            {
                list.Remove(provider);
            }
        }

        /// <summary>
        /// 获取所有的 Providers (返回数组).
        /// </summary>
        public T[] AllProviders
        {
            get
            {
                lock (this)
                {
                    return list.ToArray();
                }
            }
        }

        /// <summary>
        /// 获取一个 Provider, 按类型名称搜索
        /// 可用于检测这个插件是否已经安装，以插件的类型来做判断，所以插件的类型也具有唯一性
        /// 也可以获取指定插件，因为有此某个插件在整个系统中只要用一个实例，可在配置里设置好，然后再调用此办法来获取
        /// </summary>
        /// <param name="typeName">类型名称 如 EbOA.Base.Plugin.Test</param>
        /// <returns>所找到的 Provider</returns>
        public T GetProvider(string typeName)
        {
            lock (this)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].GetType().FullName.Equals(typeName)) return list[i];
                }
                return default(T);
            }
        }
    }
}
