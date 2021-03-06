

using System;
using System.IO;
using System.Web;
using EbSite.Base.Configs.ConfigsBase;

namespace EbSite.Base.Configs.PicConfigs
{
    public class ConfigsControl
    {

        private static ConfigsManager<ConfigsInfo> BaseInstance;
        private static object _SyncRoot = new object();
        private static ConfigsInfo _ConfigsEntity;
        
        static public ConfigsInfo Instance
        {
            get
            {
                if (_ConfigsEntity == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_ConfigsEntity == null)
                        {
                            _ConfigsEntity = BaseInstance.LoadConfig();
                        }
                    }
                }

                return _ConfigsEntity;
            }
        }
        static ConfigsControl()
        {
            if (BaseInstance == null)
                BaseInstance = new ConfigsManager<ConfigsInfo>(GetBaseConfigsPath);

        }
        public static void SaveConfig()
        {
            BaseInstance.Save(Instance);
        }
        public static void SaveConfig(ConfigsInfo Configs)
        {
            BaseInstance.Save(Configs);
        }

        private static string filename = null;
        private static string GetBaseConfigsPath
        {
            get
            {
                if (filename == null)
                {
                    if (!Equals(HttpContext.Current,null))
                    {
                        filename = HttpContext.Current.Server.MapPath("~/ConfigsFile/PicConfigs.config");    
                    }
                    else
                    {
                        filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConfigsFile\\PicConfigs.config");
                    }
                    
                }

                return filename;
            }

        }
    }
}
