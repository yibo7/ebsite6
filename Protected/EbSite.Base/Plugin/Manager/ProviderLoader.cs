using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using EbSite.Base;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;

namespace EbSite.Base.Plugin
{
    /// <summary>
    /// 加载插件的 Provider
    /// </summary>
    public static class ProviderLoader
    {
       

        /// <summary>
        /// 加载插件
        /// </summary>
        public static void LoadAll()
        {
            string[] pluginAssemblies = EbSite.Base.Plugin.PluginManager.Instance.ListPluginAssemblies();
            ;//EbSite.BLL.Plugins.Plugin.Instance.ListPluginAssemblies();

            #region 插件载入处理

            //分别创建2个对象以存放开始和禁用的插件
            List<IEmailManager> Emails = new List<IEmailManager>();
            List<IEmailManager> dEmails = new List<IEmailManager>();

            List<IMobileSend> Mobiles = new List<IMobileSend>();
            List<IMobileSend> dMobiles = new List<IMobileSend>();

            List<ITimerTask> TimerTasks = new List<ITimerTask>();
            List<ITimerTask> dTimerTasks = new List<ITimerTask>();

            List<IPayment> Payments = new List<IPayment>();
            List<IPayment> dPayments = new List<IPayment>();

            List<IDelivery> Deliverys = new List<IDelivery>();
            List<IDelivery> dDeliverys = new List<IDelivery>();

            List<IUserLoginApi> UserLoginApis = new List<IUserLoginApi>();
            List<IUserLoginApi> dUserLoginApis = new List<IUserLoginApi>();

            List<IDataExport> DataExports = new List<IDataExport>();
            List<IDataExport> dDataExports = new List<IDataExport>();

            List<IDataImport> DataImports = new List<IDataImport>();
            List<IDataImport> dDataImports = new List<IDataImport>();

            List<ISearchEngine> SearchEngines = new List<ISearchEngine>();
            List<ISearchEngine> dSearchEngines = new List<ISearchEngine>();


            List<IIPToArea> IPToAreas = new List<IIPToArea>();
            List<IIPToArea> dIPToAreas = new List<IIPToArea>();

            List<ICache> ICaches = new List<ICache>();
            List<ICache> dICaches = new List<ICache>();
            

            for (int i = 0; i < pluginAssemblies.Length; i++)
            {
                IEmailManager[] e;
                IMobileSend[] m;
                ITimerTask[] t;
                IPayment[] p;
                IDelivery[] d;
                IUserLoginApi[] f;

                IDataExport[] de;
                IDataImport[] di;

                ISearchEngine[] se;

                IIPToArea[] ipa;

                ICache[] ich;

                LoadFrom(pluginAssemblies[i], out e, out m, out t, out p, out d, out f, out de, out di, out se,out ipa,out ich);

                Emails.AddRange(e);
                Mobiles.AddRange(m);
                TimerTasks.AddRange(t);
                Payments.AddRange(p);
                Deliverys.AddRange(d);
                UserLoginApis.AddRange(f);

                DataExports.AddRange(de);

                DataImports.AddRange(di);

                SearchEngines.AddRange(se);

                IPToAreas.AddRange(ipa);

                ICaches.AddRange(ich);
            }

            for (int i = 0; i < Emails.Count; i++)
            {
                //加载并初始化启用插件
                Initialize<IEmailManager>(Emails[i],Collectors.UseIEmailManagerCollector,Collectors.DisabledIEmailManagerCollector);
            }
            for (int i = 0; i < Mobiles.Count; i++)
            {
                //加载并初始化启用插件
                Initialize<IMobileSend>(Mobiles[i], Collectors.UseIMobileSendCollector, Collectors.DisabledIMobileSendCollector);
            }
            for (int i = 0; i < TimerTasks.Count; i++)
            {
                //加载并初始化启用插件
                Initialize<ITimerTask>(TimerTasks[i], Collectors.UseITimerTaskCollector, Collectors.DisabledITimerTaskCollector);
            }
            for (int i = 0; i < Payments.Count; i++)
            {
                //加载并初始化启用插件
                Initialize<IPayment>(Payments[i], Collectors.UseIPaymentCollector, Collectors.DisabledIPaymentCollector);
            }
            for (int i = 0; i < Deliverys.Count; i++)
            {
                //加载并初始化启用插件
                Initialize<IDelivery>(Deliverys[i], Collectors.UseIDeliveryCollector, Collectors.DisabledIDeliveryCollector);
            }
            for (int i = 0; i < UserLoginApis.Count; i++)
            {
                //加载并初始化启用插件
                Initialize<IUserLoginApi>(UserLoginApis[i], Collectors.UseIUserLoginApiCollector, Collectors.DisabledIUserLoginApiCollector);
            }
            for (int i = 0; i < DataExports.Count; i++)
            {
                //加载并初始化启用插件
                Initialize<IDataExport>(DataExports[i], Collectors.UseIDataExportCollector, Collectors.DisabledIDataExportCollector);
            }
            for (int i = 0; i < DataImports.Count; i++)
            {
                //加载并初始化启用插件
                Initialize<IDataImport>(DataImports[i], Collectors.UseIDataImportCollector, Collectors.DisabledIDataImportCollector);
            }

            for (int i = 0; i < SearchEngines.Count; i++)
            {
                //加载并初始化启用插件
                Initialize<ISearchEngine>(SearchEngines[i], Collectors.UseISearchEngineCollector, Collectors.DisabledISearchEngineCollector);
            }

            for (int i = 0; i < IPToAreas.Count; i++)
            {
                //加载并初始化启用插件
                Initialize<IIPToArea>(IPToAreas[i], Collectors.UseIIPToAreaCollector, Collectors.DisabledIIPToAreaCollector);
            }

            for (int i = 0; i < ICaches.Count; i++)
            {
                //加载并初始化启用插件
                Initialize<ICache>(ICaches[i], Collectors.UseICacheCollector, Collectors.DisabledICacheCollector);
            }
            
            #endregion




        }
        /// <summary>
        /// 从程序集里读取一个提供程序（插件）
        /// </summary>
        /// <param name="assembly">如 DownloadCounterPlugin.dll</param>
        public static int LoadFromAuto(string assembly)
        {
            IEmailManager[] aEmail;
            IMobileSend[] aMobile;
            ITimerTask[] aTimerTask;
            IPayment[] aPayment;
            IDelivery[] aDelivery;
            IUserLoginApi[] aUserLoginApi;

            IDataExport[] aDataExport;
            IDataImport[] aDataImport;

            ISearchEngine[] aISearchEngine;

            IIPToArea[] aIIPToArea;

            ICache[] aICache;

            LoadFrom(assembly, out aEmail, out aMobile, out aTimerTask, out aPayment, out aDelivery, out aUserLoginApi, out aDataExport, out aDataImport, out aISearchEngine, out aIIPToArea, out aICache);

            int count = 0;

            // Init and add to the Collectors, starting from files providers
            //将插件添加到 容器 Collectors 并启动
            for (int i = 0; i < aEmail.Length; i++)
            {
                Initialize<IEmailManager>(aEmail[i], Collectors.UseIEmailManagerCollector, Collectors.DisabledIEmailManagerCollector);
                count++;
            }

            for (int i = 0; i < aMobile.Length; i++)
            {
                Initialize<IMobileSend>(aMobile[i], Collectors.UseIMobileSendCollector, Collectors.DisabledIMobileSendCollector);
                count++;
            }
            for (int i = 0; i < aTimerTask.Length; i++)
            {
                Initialize<ITimerTask>(aTimerTask[i], Collectors.UseITimerTaskCollector, Collectors.DisabledITimerTaskCollector);
                count++;
            }
            for (int i = 0; i < aPayment.Length; i++)
            {
                Initialize<IPayment>(aPayment[i], Collectors.UseIPaymentCollector, Collectors.DisabledIPaymentCollector);
                count++;
            }
            for (int i = 0; i < aDelivery.Length; i++)
            {
                Initialize<IDelivery>(aDelivery[i], Collectors.UseIDeliveryCollector, Collectors.DisabledIDeliveryCollector);
                count++;
            }
            for (int i = 0; i < aUserLoginApi.Length; i++)
            {
                Initialize<IUserLoginApi>(aUserLoginApi[i], Collectors.UseIUserLoginApiCollector, Collectors.DisabledIUserLoginApiCollector);
                count++;
            }
            for (int i = 0; i < aDataExport.Length; i++)
            {
                Initialize<IDataExport>(aDataExport[i], Collectors.UseIDataExportCollector, Collectors.DisabledIDataExportCollector);
                count++;
            }
            for (int i = 0; i < aDataImport.Length; i++)
            {
                Initialize<IDataImport>(aDataImport[i], Collectors.UseIDataImportCollector, Collectors.DisabledIDataImportCollector);
                count++;
            }
            for (int i = 0; i < aISearchEngine.Length; i++)
            {
                Initialize<ISearchEngine>(aISearchEngine[i], Collectors.UseISearchEngineCollector, Collectors.DisabledISearchEngineCollector);
                count++;
            }

            for (int i = 0; i < aIIPToArea.Length; i++)
            {
                Initialize<IIPToArea>(aIIPToArea[i], Collectors.UseIIPToAreaCollector, Collectors.DisabledIIPToAreaCollector);
                count++;
            }

            for (int i = 0; i < aICache.Length; i++)
            {
                Initialize<ICache>(aICache[i], Collectors.UseICacheCollector, Collectors.DisabledICacheCollector);
                count++;
            }

            return count;
        }
        /// <summary>
        /// 检测插件是否被禁用
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <returns></returns>
        public static bool IsDisabled(string typeName)
        {

            return !PluginManager.Instance.ExtensionEnabled(typeName) ;// !BLL.Plugins.Plugin.Instance.GetPluginStatus(typeName); 
        }
        /// <summary>
        /// 读取一个程序集的二进数据
        /// </summary>
        /// <param name="assemblyName">程序集名称 如 DownloadCounterPlugin.dll</param>
        /// <returns></returns>
        private static byte[] LoadAssemblyFromProvider(string filename)
        {
            return PluginManager.Instance.RetrievePluginAssembly(filename);//BLL.Plugins.Plugin.Instance.RetrievePluginAssembly(filename); 
        }
       
        ///// <summary>
        ///// Loads the Configuration data of a Provider.
        ///// 获取一个插件的配置文件
        ///// </summary>
        ///// <param name="typeName">The Type Name of the Provider.</param>
        ///// <returns>The Configuration, if available, otherwise an empty string.</returns>
        //public static string LoadConfiguration(string typeName)
        //{
        //    return BLL.Plugins.Plugin.Instance.GetPluginConfiguration(typeName);
            
        //}
        /// <summary>
        /// Saves the Status of a Provider.
        /// </summary>
        /// <param name="typeName">The Type Name of the Provider.</param>
        /// <param name="enabled">A value specifying whether or not the Provider is enabled.</param>
        public static void SaveStatus(string typeName, bool enabled)
        {
            PluginManager.Instance.ChangeStatus(typeName, enabled);
            //BLL.Plugins.Plugin.Instance.SetPluginStatus(typeName, enabled);
        }
        /// <summary>
        /// 初始化插件 Provider 主要是将已经加载的插件分配到启用或未启用及加载配置信息
        /// </summary>
        /// <typeparam name="T">当前插件接口类型</typeparam>
        /// <param name="instance">插件实体</param>
        /// <param name="collectorEnabled">开启中的插件集合</param>
        /// <param name="collectorDisabled">禁用中的插件集合</param>
        private static void Initialize<T>(T instance, ProviderCollector<T> collectorEnabled,ProviderCollector<T> collectorDisabled) where T : class, IProvider
        {
            //检测这个插件是否已经安装，以插件的类型来做判断，所以插件的类型也具有唯一性
            if (collectorEnabled.GetProvider(instance.GetType().FullName) != null ||collectorDisabled.GetProvider(instance.GetType().FullName) != null)
            {
                //EbSite.Base.AppStartInit.InsertLog("插件初始化出错", "Initialize 时调用GetProvider(instance.GetType().FullName) 返回空置！ ");
                 
                return;
            }

            bool enabled = !IsDisabled(instance.GetType().FullName);
            try
            {
                if (enabled)
                {
                    EbSite.Base.Extension.Manager.ExtensionSettings es = instance.GetSettings();
                    instance.Init(Host.Instance, es);
                    //配置使用别一种形式 instance.GetSettings() 可实现更加丰富的数据,参照动态组件
                    //LoadConfiguration(instance.GetType().FullName);
                }
            }
            catch (InvalidConfigurationException)
            {
                // Disable Provider
                enabled = false;
                //EbSite.Base.AppStartInit.InsertLog("关闭一个插件", instance.GetType().FullName+"插件初始时发生异常，已经关闭！ ");
                SaveStatus(instance.GetType().FullName, false);
            }
            catch
            {
                // Disable Provider
                enabled = false;
                //EbSite.Base.AppStartInit.InsertLog("关闭一个插件", instance.GetType().FullName + "插件初始时发生异常，已经关闭！ ");
                SaveStatus(instance.GetType().FullName, false);
                throw; // Exception is rethrown because it's not a normal condition
            }
            if (enabled)   //加入到插件容器
            {
                collectorEnabled.AddProvider(instance);
            }
            else
            {
                collectorDisabled.AddProvider(instance);
            }

            //EbSite.Base.AppStartInit.InsertLog("插件", instance.GetType().FullName + "加载完成" + (enabled ? "已开启" : "关闭") + "！ ");


        }

        /// <summary>
        /// 动态加载自程序集的插件
        /// </summary>
        /// <param name="assembly">程序集名称 如 DownloadCounterPlugin.dll</param>
        /// <param name="formatters">格式化插件数组，可同时加载多个</param>
        public static void LoadFrom(string assembly, 
            out IEmailManager[] Emails, 
            out IMobileSend[] Mobiles, 
            out ITimerTask[] TimerTask, 
            out IPayment[] Payments,
            out IDelivery[] Deliverys,
            out IUserLoginApi[] UserLoginApis,
            out IDataExport[] DataExports,
            out IDataImport[] DataImports,
            out ISearchEngine[] SearchEngines,
            out IIPToArea[] IPToAreas,
            out ICache[] Caches
            )
        {
            Assembly asm = null;
            try
            {
                //asm = Assembly.LoadFile(assembly);
                // 使用此方法可让DLL不会被锁住，加载完后还可以被删除
                asm = Assembly.Load(LoadAssemblyFromProvider(Path.GetFileName(assembly)));
            }
            catch
            {
                Emails = new IEmailManager[0];
                Mobiles = new IMobileSend[0];
                TimerTask = new ITimerTask[0];
                Payments = new IPayment[0];
                Deliverys = new IDelivery[0];
                UserLoginApis = new IUserLoginApi[0];

                DataExports = new IDataExport[0];
                DataImports = new IDataImport[0];
                SearchEngines = new ISearchEngine[0];

                IPToAreas = new IIPToArea[0];

                Caches = new ICache[0];

                //EbSite.Base.AppStartInit.InsertLog("加载插件出错", "加载插件出错 Assembly.Load(LoadAssemblyFromProvider(Path.GetFileName(assembly)));");
                //Log.LogEntry("Unable to load assembly " + Path.GetFileNameWithoutExtension(assembly), EntryType.Error, Log.SystemUsername););
                return;
            }
           //加载数据配置等信息
            
            Type[] types = null;

            try
            {
                types = asm.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                Emails = new IEmailManager[0];
                Mobiles = new IMobileSend[0];
                TimerTask = new ITimerTask[0];
                Payments = new IPayment[0];
                Deliverys = new IDelivery[0];
                UserLoginApis=new IUserLoginApi[0];
                DataExports = new IDataExport[0];
                DataImports = new IDataImport[0];
                SearchEngines = new ISearchEngine[0];

                IPToAreas = new IIPToArea[0];

                Caches = new ICache[0];

                //EbSite.Base.AppStartInit.InsertLog("加载插件出错", "加载插件出错 types = asm.GetTypes();" +e.Message);
               
                //Log.LogEntry("Unable to load providers from (probably v2) assembly " + Path.GetFileNameWithoutExtension(assembly), EntryType.Error, Log.SystemUsername);
                return;
            }

            List<IEmailManager> ems = new List<IEmailManager>();
            List<IMobileSend> mbs = new List<IMobileSend>();
            List<ITimerTask> tts = new List<ITimerTask>();
            List<IPayment> pms = new List<IPayment>();
            List<IDelivery> dlvs = new List<IDelivery>();
            List<IUserLoginApi> ula = new List<IUserLoginApi>();

            List<IDataExport> des = new List<IDataExport>();
            List<IDataImport> dis = new List<IDataImport>();

            List<ISearchEngine> ses = new List<ISearchEngine>();

            List<IIPToArea> ipa = new List<IIPToArea>();

            List<ICache> ich = new List<ICache>();


            Type[] interfaces;
            for (int i = 0; i < types.Length; i++)
            {
                // 避免加载到抽象类，它们不能被实例化
                if (types[i].IsAbstract) 
                    continue;
                
                interfaces = types[i].GetInterfaces();
                //插件类别,要与 PluginManager.GetPluginType 对应
                string sPluginClass = string.Empty;

                foreach (Type iface in interfaces)
                {
                    //这里也可以添加其他插件的 proivder，加多几个 if 判断即可
                    
                    if (iface == typeof(IEmailManager))
                    {
                        
                        IEmailManager tmpf = CreateInstance<IEmailManager>(asm, types[i]);
                        if (tmpf != null)
                        {
                            ems.Add(tmpf);
                            Collectors.FileNames[tmpf.GetType().FullName] = assembly;
                            sPluginClass = "IEmailManager";
                        }
                        
                    }
                    else if (iface == typeof(IMobileSend))
                    {
                        IMobileSend tmpf = CreateInstance<IMobileSend>(asm, types[i]);
                        if (tmpf != null)
                        {
                            mbs.Add(tmpf);
                            Collectors.FileNames[tmpf.GetType().FullName] = assembly;
                            sPluginClass = "IMobileSend";
                        }
                    }
                    else if (iface == typeof(ITimerTask))
                    {
                        ITimerTask tmpf = CreateInstance<ITimerTask>(asm, types[i]);
                        if (tmpf != null)
                        {
                            tts.Add(tmpf);
                            Collectors.FileNames[tmpf.GetType().FullName] = assembly;
                            sPluginClass = "ITimerTask";
                        }
                    }
                    else if (iface == typeof(IPayment))
                    {
                        IPayment tmpf = CreateInstance<IPayment>(asm, types[i]);
                        if (tmpf != null)
                        {
                            pms.Add(tmpf);
                            Collectors.FileNames[tmpf.GetType().FullName] = assembly;
                            sPluginClass = "IPayment";
                        }
                    }
                    else if (iface == typeof(IDelivery))
                    {
                        IDelivery tmpf = CreateInstance<IDelivery>(asm, types[i]);
                        if (tmpf != null)
                        {
                            dlvs.Add(tmpf);
                            Collectors.FileNames[tmpf.GetType().FullName] = assembly;
                            sPluginClass = "IDelivery";
                        }
                    }
                    else if (iface == typeof(IUserLoginApi))
                    {
                        IUserLoginApi tmpf = CreateInstance<IUserLoginApi>(asm, types[i]);
                        if (tmpf != null)
                        {
                            ula.Add(tmpf);
                            Collectors.FileNames[tmpf.GetType().FullName] = assembly;
                            sPluginClass = "IUserLoginApi";
                        }
                    }

                    else if (iface == typeof(IDataExport))
                    {
                        IDataExport tmpf = CreateInstance<IDataExport>(asm, types[i]);
                        if (tmpf != null)
                        {
                            des.Add(tmpf);
                            Collectors.FileNames[tmpf.GetType().FullName] = assembly;
                            sPluginClass = "IDataExport";
                        }
                    }
                    else if (iface == typeof(IDataImport))
                    {
                        IDataImport tmpf = CreateInstance<IDataImport>(asm, types[i]);
                        if (tmpf != null)
                        {
                            dis.Add(tmpf);
                            Collectors.FileNames[tmpf.GetType().FullName] = assembly;
                            sPluginClass = "IDataImport";
                        }
                    }

                    else if (iface == typeof(ISearchEngine))
                    {
                        ISearchEngine tmpf = CreateInstance<ISearchEngine>(asm, types[i]);
                        if (tmpf != null)
                        {
                            ses.Add(tmpf);
                            Collectors.FileNames[tmpf.GetType().FullName] = assembly;
                            sPluginClass = "ISearchEngine";
                        }
                    }
                    else if (iface == typeof(IIPToArea))
                    {
                        IIPToArea tmpf = CreateInstance<IIPToArea>(asm, types[i]);
                        if (tmpf != null)
                        {
                            ipa.Add(tmpf);
                            Collectors.FileNames[tmpf.GetType().FullName] = assembly;
                            sPluginClass = "IIPToArea";
                        }
                    }
                    else if (iface == typeof(ICache))
                    {
                        ICache tmpf = CreateInstance<ICache>(asm, types[i]);
                        if (tmpf != null)
                        {
                            ich.Add(tmpf);
                            Collectors.FileNames[tmpf.GetType().FullName] = assembly;
                            sPluginClass = "ICache";
                        }
                    }
                    
                }

                if (!string.IsNullOrEmpty(sPluginClass))
                {
                    PluginManager.Instance.LoadExtensions(types[i], sPluginClass);
                }
            }
            Emails = ems.ToArray();
            Mobiles = mbs.ToArray();
            TimerTask = tts.ToArray();
            Payments = pms.ToArray();
            Deliverys = dlvs.ToArray();
            UserLoginApis = ula.ToArray();

            DataExports = des.ToArray();
            DataImports = dis.ToArray();

            SearchEngines = ses.ToArray();

            IPToAreas = ipa.ToArray();

            Caches = ich.ToArray();
        }

        /// <summary>
        /// 创建一个提供者的实例
        /// </summary>
        /// <typeparam name="T">提供者接口类型</typeparam>
        /// <param name="asm">包含指定类型的程序集</param>
        /// <param name="type">要创建的实例类型</param>
        /// <returns>创建的实例，或者 <c>null</c>.</returns>
        private static T CreateInstance<T>(Assembly asm, Type type) where T : class, IProvider
        {
            T instance;
            try
            {
                instance = asm.CreateInstance(type.ToString()) as T;
                return instance;
            }
            catch
            {
                throw;
            }
        }

       

       

    }
}
