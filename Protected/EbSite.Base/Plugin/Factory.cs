using System;
using System.Collections.Generic;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.EntityAPI;
using EbSite.Base.Plugin.Default;

namespace EbSite.Base.Plugin
{
    /*
     添加插件类型流程:
     * 
     * 1.完成 Collectors.cs 相关设置
     * 2.完成PluginManager.cs下的GetPluginType追加
     * 3.完成ProviderLoader.cs下的相关设置
     * 4.加载EbSite.Core.StartupTools.Startup() 下的一些配置
     */
    public class Factory
    {

        static public IEmailManager GetEmail(string apptype)
        {
            if (!string.IsNullOrEmpty(apptype))
            {
                IEmailManager[] lst = Collectors.UseIEmailManagerCollector.AllProviders;

                foreach (IEmailManager se in lst)
                {
                    if (se.GetType().ToString().Equals(apptype))
                    {
                        return se;
                    }
                }

            }
            throw new Exception("找不到email发送插件 原因:1.还没有安装相关的email发送插件，请到官方下载并安装后再重试！2.已经安装插件，但没有到系统设置的默认邮件发送插件里选择插件！");
        }

        static public void SendEmail(EmailModel md,string Atta)
        {
            IEmailManager em = GetEmail(ConfigsControl.Instance.EmailSendPlugin);
           em.SMTP_Send(md);
           //if (!string.IsNullOrEmpty(Atta))
           //    em.SMTP_Attachments(Atta);


            //IEmailManager[] lst = Collectors.UseIEmailManagerCollector.AllProviders;

            //foreach (IEmailManager em in lst)
            //{
            //    //使用所有启用的email发送组件

            //    em.SMTP_Send(md);
            //    if (!string.IsNullOrEmpty(Atta))
            //        em.SMTP_Attachments(Atta);
            //}

        }

        static public IMobileSend GetMobile(string apptype)
        {
            if (!string.IsNullOrEmpty(apptype))
            {
                IMobileSend[] lst = Collectors.UseIMobileSendCollector.AllProviders;

                foreach (IMobileSend se in lst)
                {
                    if (se.GetType().ToString().Equals(apptype))
                    {
                        return se;
                    }
                }

            }
            throw new Exception("找不到手机短信发送插件 原因:1.还没有安装相关的手机短信发送插件，请到官方下载并安装后再重试！2.已经安装插件，但没有到系统设置的默认手机短信发送插件里选择插件！");
        }
        

        static public void SendMobile(string Msg, string MobiNumber, string UserName)
        {
            IMobileSend ms = GetMobile(ConfigsControl.Instance.MobileMsgSendPlugin);
            ms.SendMsg(Msg, MobiNumber, UserName);
            //IMobileSend[] lst = Collectors.UseIMobileSendCollector.AllProviders;

            //foreach (IMobileSend em in lst)
            //{
            //    //使用所有启用的email发送组件
            //    em.SendMsg(Msg, MobiNumber, UserName);


            //}

        }




        static public IUserLoginApi GetLoginApi(string apptype)
        {
            IUserLoginApi[] lst = Collectors.UseIUserLoginApiCollector.AllProviders;
            if (!string.IsNullOrEmpty(apptype))
            {
                foreach (IUserLoginApi ula in lst)
                {
                    if (ula.ApiName.ToLower().Equals(apptype.ToLower()))
                    {
                        return ula;
                    }

                }
            }
            
            return null;

        }

        static public ITimerTask GetTimerTaskApi(string apptype)
        {
            ITimerTask[] lst = Collectors.UseITimerTaskCollector.AllProviders;
            if (!string.IsNullOrEmpty(apptype))
            {
                foreach (ITimerTask ula in lst)
                {
                    if (ula.ToString().ToLower().Equals(apptype.ToLower()))
                    {
                        return ula;
                    }
                }
                
            }
            return null;
        }

        static public IDataExport GetExportApi(string apptype)
        {
            IDataExport[] lst = Collectors.UseIDataExportCollector.AllProviders;
            if (!string.IsNullOrEmpty(apptype))
            {
                foreach (IDataExport ula in lst)
                {
                    if (ula.Description.ToLower().Equals(apptype.ToLower()))
                    {
                        return ula;
                    }

                }
            }

            return null;

        }


        /// <summary>
        /// 获取搜索引擎
        /// </summary>
        /// <param name="apptype"></param>
        /// <returns></returns>
        static public ISearchEngine GetSearchEngine(string apptype)
        {
            ISearchEngine[] lst = Collectors.UseISearchEngineCollector.AllProviders;

            foreach (ISearchEngine se in lst)
            {
                if (se.GetType().ToString().Equals(apptype))
                {
                    return se;
                }
            }
            return new SearchEg();
        }

        /// <summary>
        /// IP转换区域
        /// </summary>
        /// <param name="apptype"></param>
        /// <returns></returns>
        static public IIPToArea GetIPToArea(string apptype)
        {
            IIPToArea[] lst = Collectors.UseIIPToAreaCollector.AllProviders;

            foreach (IIPToArea se in lst)
            {
                if (se.GetType().ToString().Equals(apptype))
                {
                    return se;
                }
            }
            return new IpToArea();
        }

        /// <summary>
        /// 快递查询处理插件
        /// </summary>
        /// <param name="apptype"></param>
        /// <returns></returns>
        static public IDelivery GetKuaiDi()
        {

            string apptype = Configs.SysConfigs.ConfigsControl.Instance.KuaiDiPluginName;
            if (!string.IsNullOrEmpty(apptype))
            {
                IDelivery[] lst = Collectors.UseIDeliveryCollector.AllProviders;
                foreach (IDelivery se in lst)
                {
                    if (se.GetType().ToString().Equals(apptype))
                    {
                        return se;
                    }
                }

                throw new Exception("设置的快递查询插件找不到！");
            }
            else
            {
                throw new Exception("没有设置快递查询插件，请在系统设置里设置！");
            }
            
            
        }


        /// <summary>
        /// 获取缓存处理程序
        /// </summary>
        /// <param name="apptype">类型</param>
        /// <returns></returns>
        static public ICache GetCache(string apptype)
        {
            if (!string.IsNullOrEmpty(apptype))
            {
                ICache[] lst = Collectors.UseICacheCollector.AllProviders;

                foreach (ICache se in lst)
                {
                    if (se.GetType().ToString().Equals(apptype))
                    {
                        return se;
                    }
                }
              
            }
             return GetDefaultCache();
        }

        public static ICache GetDefaultCache()
        {
            return new EBCacheRaw();
        }

        //public static ICache GetSTSdbCache()
        //{
        //    return  CacheSTSdb.Instance;
        //}

        #region 放弃代码


        //public class EmailManager
        //{

        //    ///// <summary>
        //    ///// 获取默认的email处理组件
        //    ///// </summary>
        //    //public static IEmailManager DefaultInstance
        //    //{
        //    //    get
        //    //    {
        //    //        IEmailManager md;
        //    //        string sCf = ConfigsControl.Instance.Smtpserver;
        //    //        if (!string.IsNullOrEmpty(sCf))
        //    //        {
        //    //            md = Core.Plugin.Collectors.UseIEmailManagerCollector.GetProvider(sCf);
        //    //        }
        //    //        else
        //    //        {
        //    //            throw new Exception("没有设置默认Email处理组件!");
        //    //        }

        //    //        return md;

        //    //    }
        //    //}
        //    public void Send()
        //    {
        //        IEmailManager[] lst = Core.Plugin.Collectors.UseIEmailManagerCollector.AllProviders;

        //        foreach (IEmailManager em in lst)
        //        {
        //            //如果要使用所有发送组件
        //        }

        //    }
        //}

        //public class MobileSend
        //{

        //    /// <summary>
        //    /// 获取默认的IMobileSend处理组件
        //    /// </summary>
        //    public static IMobileSend DefaultInstance
        //    {
        //        get
        //        {
        //            IMobileSend md;
        //            string sCf = ConfigsControl.Instance.SMSpserver;
        //            if (!string.IsNullOrEmpty(sCf))
        //            {
        //                md = Core.Plugin.Collectors.UseIMobileSendCollector.GetProvider(sCf);
        //            }
        //            else
        //            {
        //                throw new Exception("没有设置默认MobileSend处理组件!");
        //            }

        //            return md;

        //        }
        //    }

        //}

        #endregion

        
    }
}

