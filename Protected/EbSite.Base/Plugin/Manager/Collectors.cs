using System;
using System.Collections.Generic;
using System.Text;

using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;

namespace EbSite.Base.Plugin
{
    /// <summary>
    /// 包含了 Providers 集合的实例
    /// </summary>
    public static class Collectors
    {
        /// <summary>
        /// Contains the file names of the DLLs containing each provider (provider->file).
        /// 包含包含每个提供程序（提供程序->“文件）的DLL文件名。
        /// 对应关系  Dictionary<插件类型名称(eboa.plugins.test), 插件程序集名称（test.dll）>
        /// </summary>
        public static Dictionary<string, string> FileNames;

        #region IEmailManager  

        /// <summary>
        /// 使用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IEmailManager> UseIEmailManagerCollector;

        /// <summary>
        /// 禁用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IEmailManager> DisabledIEmailManagerCollector;

        #endregion

        #region ITimerTask

        /// <summary>
        /// 使用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<ITimerTask> UseITimerTaskCollector;

        /// <summary>
        /// 禁用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<ITimerTask> DisabledITimerTaskCollector;

        #endregion

        #region IPayment

        /// <summary>
        /// 使用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IPayment> UseIPaymentCollector;

        /// <summary>
        /// 禁用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IPayment> DisabledIPaymentCollector;

        #endregion

        #region IMobileSend

        /// <summary>
        /// 使用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IMobileSend> UseIMobileSendCollector;

        /// <summary>
        /// 禁用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IMobileSend> DisabledIMobileSendCollector;

        #endregion
        #region IDelivery

        /// <summary>
        /// 使用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IDelivery> UseIDeliveryCollector;

        /// <summary>
        /// 禁用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IDelivery> DisabledIDeliveryCollector;

        #endregion

        #region IUserLoginApi

        /// <summary>
        /// 使用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IUserLoginApi> UseIUserLoginApiCollector;

        /// <summary>
        /// 禁用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IUserLoginApi> DisabledIUserLoginApiCollector;

        #endregion

        #region IDataExport
        /// <summary>
        /// 使用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IDataExport> UseIDataExportCollector;

        /// <summary>
        /// 禁用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IDataExport> DisabledIDataExportCollector;

        #endregion

        #region IDataImport
        /// <summary>
        /// 使用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IDataImport> UseIDataImportCollector;

        /// <summary>
        /// 禁用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IDataImport> DisabledIDataImportCollector;

        #endregion

        #region ISearchEngine
        /// <summary>
        /// 使用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<ISearchEngine> UseISearchEngineCollector;

        /// <summary>
        /// 禁用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<ISearchEngine> DisabledISearchEngineCollector;

        #endregion

        #region IIPToArea
        /// <summary>
        /// 使用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IIPToArea> UseIIPToAreaCollector;

        /// <summary>
        /// 禁用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<IIPToArea> DisabledIIPToAreaCollector;

        #endregion

        #region ICache
        /// <summary>
        /// 使用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<ICache> UseICacheCollector;

        /// <summary>
        /// 禁用中的格式化插件的 Provider 集合
        /// </summary>
        public static ProviderCollector<ICache> DisabledICacheCollector;

        #endregion


        /// <summary>
        /// 查找一个 provider.
        /// </summary>
        /// <param name="typeName">Provider 类型名称</param>
        /// <param name="enabled">指定此 Provider 是否开启</param>
        public static IProvider FindProvider(string typeName, out bool enabled, out bool canDisable) //, out bool canDisable 好像没用到
        {
            enabled = true;
            canDisable = true;
            IProvider prov = null;
            ////////////////////////IEmailManager//////////////////////////////////
            //canDisable = typeName != Settings.DefaultPagesProvider;
            prov = UseIEmailManagerCollector.GetProvider(typeName);
            if (prov == null)
            {
                prov = DisabledIEmailManagerCollector.GetProvider(typeName);
                if (prov != null) enabled = false;
            }
            if (prov != null) return prov;
            ////////////////////////IMobileSend////////////////////////////////
            prov = UseIMobileSendCollector.GetProvider(typeName);
            if (prov == null)
            {
                prov = DisabledIMobileSendCollector.GetProvider(typeName);
                if (prov != null) enabled = false;
            }
            if (prov != null) return prov;

            ////////////////////////ITimerTask////////////////////////////////
            prov = UseITimerTaskCollector.GetProvider(typeName);
            if (prov == null)
            {
                prov = DisabledITimerTaskCollector.GetProvider(typeName);
                if (prov != null) enabled = false;
            }
            if (prov != null) return prov;

            ////////////////////////IPayment////////////////////////////////
            prov = UseIPaymentCollector.GetProvider(typeName);
            if (prov == null)
            {
                prov = DisabledIPaymentCollector.GetProvider(typeName);
                if (prov != null) enabled = false;
            }
            if (prov != null) return prov;

            ////////////////////////IUserLoginApi////////////////////////////////
            prov = UseIUserLoginApiCollector.GetProvider(typeName);
            if (prov == null)
            {
                prov = DisabledIUserLoginApiCollector.GetProvider(typeName);
                if (prov != null) enabled = false;
            }
            if (prov != null) return prov;

            ////////////////////////IDataExport////////////////////////////////
            prov = UseIDataExportCollector.GetProvider(typeName);
            if (prov == null)
            {
                prov = DisabledIDataExportCollector.GetProvider(typeName);
                if (prov != null) enabled = false;
            }
            if (prov != null) return prov;

            ////////////////////////IDataExport////////////////////////////////
            prov = UseIDataImportCollector.GetProvider(typeName);
            if (prov == null)
            {
                prov = DisabledIDataImportCollector.GetProvider(typeName);
                if (prov != null) enabled = false;
            }
            if (prov != null) return prov;


            ////////////////////////ISearchEngine////////////////////////////////
            prov = UseISearchEngineCollector.GetProvider(typeName);
            if (prov == null)
            {
                prov = DisabledISearchEngineCollector.GetProvider(typeName);
                if (prov != null) enabled = false;
            }
            if (prov != null) return prov;


            ////////////////////////IIPToArea////////////////////////////////
            prov = UseIIPToAreaCollector.GetProvider(typeName);
            if (prov == null)
            {
                prov = DisabledIIPToAreaCollector.GetProvider(typeName);
                if (prov != null) enabled = false;
            }
            if (prov != null) return prov;


            ////////////////////////ICache////////////////////////////////
            prov = UseICacheCollector.GetProvider(typeName);
            if (prov == null)
            {
                prov = DisabledICacheCollector.GetProvider(typeName);
                if (prov != null) enabled = false;
            }
            if (prov != null) return prov;
            
          
            return null;
        }

        /// <summary>
        /// 尝试卸载一个 provider.
        /// </summary>
        /// <param name="typeName">provider 名称</param>
        public static void TryUnload(string typeName)
        {
            bool enabled, canDisable;
            IProvider prov = FindProvider(typeName, out enabled, out canDisable);
            /////////////IEmailManager/////////////
            UseIEmailManagerCollector.RemoveProvider(prov as IEmailManager);
            DisabledIEmailManagerCollector.RemoveProvider(prov as IEmailManager);
            /////////////IMobileSend/////////////
            UseIMobileSendCollector.RemoveProvider(prov as IMobileSend);
            DisabledIMobileSendCollector.RemoveProvider(prov as IMobileSend);
            /////////////ITimerTask/////////////
            UseITimerTaskCollector.RemoveProvider(prov as ITimerTask);
            DisabledITimerTaskCollector.RemoveProvider(prov as ITimerTask);

            /////////////IPayment/////////////
            UseIPaymentCollector.RemoveProvider(prov as IPayment);
            DisabledIPaymentCollector.RemoveProvider(prov as IPayment);

            /////////////IUserLoginApi/////////////
            UseIUserLoginApiCollector.RemoveProvider(prov as IUserLoginApi);
            DisabledIUserLoginApiCollector.RemoveProvider(prov as IUserLoginApi);

            /////////////IUserLoginApi/////////////
            UseIDataExportCollector.RemoveProvider(prov as IDataExport);
            DisabledIDataExportCollector.RemoveProvider(prov as IDataExport);

            /////////////IDataImport/////////////
            UseIDataImportCollector.RemoveProvider(prov as IDataImport);
            DisabledIDataImportCollector.RemoveProvider(prov as IDataImport);

            /////////////ISearchEngine/////////////
            UseISearchEngineCollector.RemoveProvider(prov as ISearchEngine);
            DisabledISearchEngineCollector.RemoveProvider(prov as ISearchEngine);

            /////////////IIPToArea/////////////
            UseIIPToAreaCollector.RemoveProvider(prov as IIPToArea);
            DisabledIIPToAreaCollector.RemoveProvider(prov as IIPToArea);

            /////////////ICache/////////////
            UseICacheCollector.RemoveProvider(prov as ICache);
            DisabledICacheCollector.RemoveProvider(prov as ICache);
            
         
        }

        /// <summary>
        /// 尝试禁用一个 provider.
        /// </summary>
        /// <param name="typeName">provider 名称</param>
        public static void TryDisable(string typeName)
        {
            IProvider prov = null;
            /////////////IEmailManager/////////////
            prov = UseIEmailManagerCollector.GetProvider(typeName);
            if (prov != null)
            {
                DisabledIEmailManagerCollector.AddProvider((IEmailManager)prov);
                UseIEmailManagerCollector.RemoveProvider((IEmailManager)prov);
                return;
            }
            /////////////IMobileSend/////////////
            prov = UseIMobileSendCollector.GetProvider(typeName);
            if (prov != null)
            {
                DisabledIMobileSendCollector.AddProvider((IMobileSend)prov);
                UseIMobileSendCollector.RemoveProvider((IMobileSend)prov);
                return;
            }
            /////////////ITimerTask/////////////
            prov = UseITimerTaskCollector.GetProvider(typeName);
            if (prov != null)
            {
                DisabledITimerTaskCollector.AddProvider((ITimerTask)prov);
                UseITimerTaskCollector.RemoveProvider((ITimerTask)prov);
                return;
            }
            /////////////IPayment/////////////
            prov = UseIPaymentCollector.GetProvider(typeName);
            if (prov != null)
            {
                DisabledIPaymentCollector.AddProvider((IPayment)prov);
                UseIPaymentCollector.RemoveProvider((IPayment)prov);
                return;
            }
            /////////////IUserLoginApi/////////////
            prov = UseIUserLoginApiCollector.GetProvider(typeName);
            if (prov != null)
            {
                DisabledIUserLoginApiCollector.AddProvider((IUserLoginApi)prov);
                UseIUserLoginApiCollector.RemoveProvider((IUserLoginApi)prov);
                return;
            }

            /////////////IDataExport/////////////
            prov = UseIDataExportCollector.GetProvider(typeName);
            if (prov != null)
            {
                DisabledIDataExportCollector.AddProvider((IDataExport)prov);
                UseIDataExportCollector.RemoveProvider((IDataExport)prov);
                return;
            }

            /////////////IDataImport/////////////
            prov = UseIDataImportCollector.GetProvider(typeName);
            if (prov != null)
            {
                DisabledIDataImportCollector.AddProvider((IDataImport)prov);
                UseIDataImportCollector.RemoveProvider((IDataImport)prov);
                return;
            }

            /////////////ISearchEngine/////////////
            prov = UseISearchEngineCollector.GetProvider(typeName);
            if (prov != null)
            {
                DisabledISearchEngineCollector.AddProvider((ISearchEngine)prov);
                UseISearchEngineCollector.RemoveProvider((ISearchEngine)prov);
                return;
            }

            /////////////IIPToArea/////////////
            prov = UseIIPToAreaCollector.GetProvider(typeName);
            if (prov != null)
            {
                DisabledIIPToAreaCollector.AddProvider((IIPToArea)prov);
                UseIIPToAreaCollector.RemoveProvider((IIPToArea)prov);
                return;
            }

            /////////////ICache/////////////
            prov = UseICacheCollector.GetProvider(typeName);
            if (prov != null)
            {
                DisabledICacheCollector.AddProvider((ICache)prov);
                UseICacheCollector.RemoveProvider((ICache)prov);
                return;
            }
            
            
            
        }

        /// <summary>
        /// 尝试开启一个 provider. 禁用了一个插件后，我们再开启时调用此方法
        /// </summary>
        /// <param name="typeName">provider 名称</param>
        public static void TryEnable(string typeName)
        {
            IProvider prov = null;
            ////////////////IEmailManager////////////////////
            prov = DisabledIEmailManagerCollector.GetProvider(typeName);
            if (prov != null)
            {
                UseIEmailManagerCollector.AddProvider((IEmailManager)prov);
                DisabledIEmailManagerCollector.RemoveProvider((IEmailManager)prov);
                return;
            }
            /////////////IMobileSend/////////////
            prov = UseIMobileSendCollector.GetProvider(typeName);
            if (prov != null)
            {
                UseIMobileSendCollector.AddProvider((IMobileSend)prov);
                DisabledIMobileSendCollector.RemoveProvider((IMobileSend)prov);
                return;
            }
            /////////////ITimerTask/////////////
            prov = UseITimerTaskCollector.GetProvider(typeName);
            if (prov != null)
            {
                UseITimerTaskCollector.AddProvider((ITimerTask)prov);
                DisabledITimerTaskCollector.RemoveProvider((ITimerTask)prov);
                return;
            }
            /////////////IPayment/////////////
            prov = UseIPaymentCollector.GetProvider(typeName);
            if (prov != null)
            {
                UseIPaymentCollector.AddProvider((IPayment)prov);
                DisabledIPaymentCollector.RemoveProvider((IPayment)prov);
                return;
            }
            /////////////IUserLoginApi/////////////
            prov = UseIUserLoginApiCollector.GetProvider(typeName);
            if (prov != null)
            {
                UseIUserLoginApiCollector.AddProvider((IUserLoginApi)prov);
                DisabledIUserLoginApiCollector.RemoveProvider((IUserLoginApi)prov);
                return;
            }

            /////////////IDataExport/////////////
            prov = UseIDataExportCollector.GetProvider(typeName);
            if (prov != null)
            {
                UseIDataExportCollector.AddProvider((IDataExport)prov);
                DisabledIDataExportCollector.RemoveProvider((IDataExport)prov);
                return;
            }

            /////////////IDataImport/////////////
            prov = UseIDataImportCollector.GetProvider(typeName);
            if (prov != null)
            {
                UseIDataImportCollector.AddProvider((IDataImport)prov);
                DisabledIDataImportCollector.RemoveProvider((IDataImport)prov);
                return;
            }

            /////////////ISearchEngine/////////////
            prov = UseISearchEngineCollector.GetProvider(typeName);
            if (prov != null)
            {
                UseISearchEngineCollector.AddProvider((ISearchEngine)prov);
                DisabledISearchEngineCollector.RemoveProvider((ISearchEngine)prov);
                return;
            }

            /////////////IIPToArea/////////////
            prov = UseIIPToAreaCollector.GetProvider(typeName);
            if (prov != null)
            {
                UseIIPToAreaCollector.AddProvider((IIPToArea)prov);
                DisabledIIPToAreaCollector.RemoveProvider((IIPToArea)prov);
                return;
            }

            /////////////ICache/////////////
            prov = UseICacheCollector.GetProvider(typeName);
            if (prov != null)
            {
                UseICacheCollector.AddProvider((ICache)prov);
                DisabledICacheCollector.RemoveProvider((ICache)prov);
                return;
            }
           
        }

        /// <summary>
        /// 获取所有 providers, 包含启用和禁用的
        /// </summary>
        /// <returns>providers 的名称.</returns>
        public static string[] GetAllProviders()
        {
            List<string> result = new List<string>(20);

            //////////////////IEmailManager///////////////////////
            foreach (IProvider prov in UseIEmailManagerCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }

            foreach (IProvider prov in DisabledIEmailManagerCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            //////////////////IMobileSend///////////////////////
            foreach (IProvider prov in UseIMobileSendCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            foreach (IProvider prov in DisabledIMobileSendCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            //////////////////ITimerTask///////////////////////
            foreach (IProvider prov in UseITimerTaskCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            foreach (IProvider prov in DisabledITimerTaskCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            //////////////////IPayment///////////////////////
            foreach (IProvider prov in UseIPaymentCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            foreach (IProvider prov in DisabledIPaymentCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }

            //////////////////IUserLoginApi///////////////////////
            foreach (IProvider prov in UseIUserLoginApiCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            foreach (IProvider prov in DisabledIUserLoginApiCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }


            //////////////////IDataExport///////////////////////
            foreach (IProvider prov in UseIDataExportCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            foreach (IProvider prov in DisabledIDataExportCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }

            //////////////////IDataImport///////////////////////
            foreach (IProvider prov in UseIDataImportCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            foreach (IProvider prov in DisabledIDataImportCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }

            //////////////////ISearchEngine///////////////////////
            foreach (IProvider prov in UseISearchEngineCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            foreach (IProvider prov in DisabledISearchEngineCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }


            //////////////////IIPToArea///////////////////////
            foreach (IProvider prov in UseIIPToAreaCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            foreach (IProvider prov in DisabledIIPToAreaCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }

            //////////////////ICache///////////////////////
            foreach (ICache prov in UseICacheCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            foreach (ICache prov in DisabledICacheCollector.AllProviders)
            {
                result.Add(prov.GetType().FullName);
            }
            

            return result.ToArray();
        }
    }
}
