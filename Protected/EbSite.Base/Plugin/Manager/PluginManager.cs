using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Modules;
using EbSite.Base.Plugin.Base;
using EbSite.Base.Plugin.Manager;
using EbSite.Core;

namespace EbSite.Base.Plugin
{
    public class PluginManager : ManagerExtBase
    {
        public static readonly PluginManager Instance = new PluginManager();
        public override Core.DataStore.SettingsBase GetExtensionSettings(string key)
        {
            return new EbSite.Core.DataStore.PluginSettings(key);
        }
        public override string CacheKey
        {
            get
            {
                return "ExtPlugins";
            }
        }
        override protected void LoadExtensions()
        {
        }
        public void LoadExtensions(Type type,string sPluginType)
        {
            object[] attributes = type.GetCustomAttributes(typeof(ExtensionAttribute), false);
            
            foreach (object attribute in attributes)
            {
                ExtensionAttribute xa = (ExtensionAttribute)attribute;
                string sDataKey = type.FullName;
                // try to load from storage
                ManagedExtension x = DataStoreExtension(sDataKey);
                // if nothing, crete new extension
                //如果为null,说明还没有生成此插件相关的配置文件,要先生成
                if (x == null)
                {
                    x = new ManagedExtension(sDataKey, xa.Version, xa.Description, xa.Author, sPluginType);
                    _newExtensions.Add(sDataKey);
                    //保存配置到数据库或xml
                    SaveToStorage(x);
                }
                else
                {
                    // update attributes from assembly
                    x.Version = xa.Version;
                    x.Description = xa.Description;
                    x.Author = xa.Author;
                    x.Priority = xa.Priority;
                }
                _extensions.Add(x);
            }

        }
        

        /// <summary>
        /// 获取所有程序集列表 如 DownloadCounterPlugin.dll
        /// </summary>
        /// <returns></returns>
        public string[] ListPluginAssemblies()
        {
            lock (this)
            {
                string[] files = Directory.GetFiles(GetFullPath, "*.dll");
                string[] result = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                    result[i] = Path.GetFileName(files[i]);
                return result;
            }
        }
        /// <summary>
        /// 插件dll文件的存放目录
        /// </summary>
        private string GetFullPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Plugins\"); //lunix下要修改成 Plugins/
            }
        }

        /// <summary>
        /// 获取一个程序集的真实路径 如 D:\\web\\plugins\\test.dll
        /// </summary>
        /// <param name="name">程序集名称 如test.dll</param>
        /// <returns></returns>
        private string GetFullPathForPlugin(string name)
        {
            return Path.Combine(GetFullPath, name);
        }
        /// <summary>
        /// 读取一个程序集的二进数据
        /// </summary>
        /// <param name="filename">程序集名称 如 DownloadCounterPlugin.dll</param>
        public byte[] RetrievePluginAssembly(string filename)
        {
            if (filename == null) throw new ArgumentNullException("filename");
            if (filename.Length == 0) throw new ArgumentException("文件名称不能为空", "filename");

            if (!File.Exists(GetFullPathForPlugin(filename))) return null;

            lock (this)
            {
                try
                {
                    return File.ReadAllBytes(GetFullPathForPlugin(filename));
                }
                catch (IOException)
                {
                    return null;
                }
            }
        }
        public List<ListItemModel> GetPluginType
        {
            get
            {
                List<ListItemModel> lst = new List<ListItemModel>();

                ListItemModel md = new ListItemModel("所有插件", "");

                lst.Add(md);

                md = new ListItemModel("邮件发送", "IEmailManager");

                lst.Add(md);

                md = new ListItemModel("手机短信发送", "IMobileSend");
                lst.Add(md);

                md = new ListItemModel("定时执行任务", "ITimerTask");
                lst.Add(md);

                md = new ListItemModel("支付接口", "IPayment");
                lst.Add(md);
                md = new ListItemModel("配送方式", "IDelivery");
                lst.Add(md);
                md = new ListItemModel("第三方登录插件", "IUserLoginApi");
                lst.Add(md);
                md = new ListItemModel("数据导出插件", "IDataExport");
                lst.Add(md);
                md = new ListItemModel("数据导入插件", "IDataImport");
                lst.Add(md);

                md = new ListItemModel("搜索引擎插件", "ISearchEngine");
                lst.Add(md);

                md = new ListItemModel("从IP获取地区信息插件", "IIPToArea");
                lst.Add(md);

                md = new ListItemModel("缓存处理程序", "ICache");
                lst.Add(md);
                
                return lst;
            }
        }
        public IPayment GetPayment(string fullTypeName)
        {
            ProviderCollector<IPayment> lst = Collectors.UseIPaymentCollector;

            foreach (IPayment payment in lst.AllProviders)
            {
                if (payment.GetType().FullName.Equals(fullTypeName))
                    return payment;
            }
            return null;
        }

        public List<PaymentUseingInfo> GetPayments(string OrderName, string TotalPrice, string OrderNumber)
        {
            List<PaymentUseingInfo> lstRz = new List<PaymentUseingInfo>();
            ProviderCollector<IPayment> lst = Collectors.UseIPaymentCollector;

            foreach (IPayment payment in lst.AllProviders)
            {
                PaymentUseingInfo pui = new PaymentUseingInfo(payment, OrderName, TotalPrice, OrderNumber);
                lstRz.Add(pui);
            }

            return lstRz;
        }

       /// <summary>
       /// 查询插件信息列表
       /// </summary>
       /// <param name="sType">为空查询所有,IEmailManager(邮件),ITimerTask(定时),IPayment(支付),IDelivery(配送)</param>
       /// <param name="iEnabled">-1为所有,0为禁用，1为启用</param>
       /// <returns></returns>
        public List<ManagedExtension> GetPluginInfoByType(string sType,int iEnabled)
        {
            List<ManagedExtension> lst =  Extensions;
            List<ManagedExtension> lstRz1 = new List<ManagedExtension>();
            string sBaseType = sType;
            if (!string.IsNullOrEmpty(sBaseType))
            {
                
                foreach (ManagedExtension info in lst)
                {
                   
                    if (info.BaseType.Equals(sBaseType))
                    {
                        if (iEnabled == -1)
                        {
                            lstRz1.Add(info);
                        }
                        else if(iEnabled == 0)
                        {
                            if(!info.Enabled)
                                lstRz1.Add(info);
                        }
                        else if (iEnabled == 1)
                        {
                            if (info.Enabled)
                                lstRz1.Add(info);
                        }
                        
                    }

                }
            }
            else
            {
                lstRz1 = lst;
            }
            return lstRz1;
        }

    }
}
